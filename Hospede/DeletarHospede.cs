using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudHotel;

namespace CrudHotel;

public partial class CrudHotel
{
    static void DeletarHospede()
    {
        using (DBContext dbContext = new DBContext())
        {
            var hospedes = dbContext.hospedes.ToList();

            if (hospedes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Não há hóspedes cadastrados. Aperte qualquer tecla para retornar ao menu principal.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuHospede();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Deletando hóspede. Selecione o hóspede que deseja deletar:");
                Console.WriteLine();

                foreach (var hospede in hospedes)
                {
                    Console.WriteLine($"ID: {hospede.id} | Nome: {hospede.Name} | CPF: {hospede.CPF}");
                }

                Console.WriteLine();
                Console.WriteLine("Digite o ID do hóspede que deseja deletar:");
                string idInput = Console.ReadLine();

                if (int.TryParse(idInput, out int id))
                {
                    var hospede = dbContext.hospedes.FirstOrDefault(x => x.id == id);

                    if (hospede == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hóspede não encontrado. Aperte qualquer tecla para retornar ao menu principal.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        ShowMenuHospede();
                    }
                    else
                    {
                        dbContext.hospedes.Remove(hospede);
                        dbContext.SaveChanges();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hóspede deletado com sucesso! Aperte qualquer tecla para retornar ao menu principal.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        ShowMenuHospede();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada inválida! Por favor, insira somente números. Aperte qualquer tecla para retornar ao menu principal.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuHospede();
                }
            }
        }
    }
}
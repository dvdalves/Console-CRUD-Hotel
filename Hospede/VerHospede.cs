using CrudHotel;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;


namespace CrudHotel
{
    public partial class CrudHotel
    {
        static void VerHospedes()
        {
            using (var context = new DBContext())
            {
                var hospedes = context.hospedes.ToList();

                if (hospedes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   Não há hóspedes cadastrados. Aperte qualquer tecla para retornar ao menu anterior.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    foreach (var hospede in hospedes)
                    {
                        Console.Write("Id: " + hospede.id);
                        Console.WriteLine(" Nome: " + hospede.Name);
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Escolha pelo (ID) o hóspede que você deseja ver as informações (somente números, até 1000 caracteres): ");
                    Console.ResetColor();

                    string entrada = Console.ReadLine();
                    
                    int escolha;

                    if (int.TryParse(entrada, out escolha) && entrada.Length <= 1000)
                    {
                        var hospedeEscolhido = hospedes.FirstOrDefault(x => x.id == escolha);

                        if (hospedeEscolhido != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Nome: " + hospedeEscolhido.Name);
                            Console.WriteLine("CPF: " + hospedeEscolhido.CPF);
                            Console.WriteLine("E-mail: " + hospedeEscolhido.Email);
                            Console.WriteLine("Telefone: " + hospedeEscolhido.Phone);
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hóspede não encontrado! Aperte qualquer tecla para retornar ao menu anterior.");
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada inválida! Por favor, insira somente números e até 1000 caracteres. Aperte qualquer tecla para retornar ao menu anterior.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
            ShowMenuHospede();
        }
    }
}
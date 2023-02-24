using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudHotel;
using Microsoft.Extensions.DependencyInjection;

namespace CrudHotel
{
    public partial class CrudHotel
    {
        static void AtualizarHospede()
        {
            using (var context = new DBContext())
            {
                if (context.hospedes.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   Não há hóspedes cadastrados. Aperte qualquer tecla para retornar ao menu anterior.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuHospede();
                }

                Console.Clear();
                Console.WriteLine("Atualizando hóspede. Aperte 0 para retornar ao menu de hóspedes.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Escolha um hóspede que você deseja atualizar (pelo ID):");
                Console.ResetColor();
                foreach (var hospede in context.hospedes)
                {
                    Console.Write("Id: " + hospede.id);
                    Console.WriteLine(" Nome: " + hospede.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Escolha pelo (ID) o hóspede que você deseja ver as informações: ");

                var escolha = Console.ReadLine();

                if (escolha == "0")
                {
                    Console.Clear();
                    ShowMenuHospede();
                }

                int id;
                try
                {
                    id = int.Parse(escolha);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Entrada inválida. O número digitado é maior do que o limite permitido para um valor inteiro.");
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuHospede();
                    return;
                }

                Hospede client = context.hospedes.FirstOrDefault(x => x.id == id);
                ;

                if (client == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Hóspedes com ID {id} não encontrado. Aperte qualquer tecla para retornar ao menu de hóspedes.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuHospede();
                }
                else
                {
                    Console.WriteLine("Escolha o que deseja alterar:");
                    Console.WriteLine("1. Nome.");
                    Console.WriteLine("2. E-mail.");
                    Console.WriteLine("3. Telefone.");
                    Console.WriteLine("0. Voltar.");
                    Console.WriteLine("Opção:");

                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            
                            Console.WriteLine($"Nome atual: {client.Name}");
                            Console.WriteLine("Novo nome:");
                            string name = Console.ReadLine();
                            while (!string.IsNullOrEmpty(name) && (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$") || name.Length < 6))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nome inválido. Por favor, insira um nome válido somente com letras e com pelo menos 6 caracteres.");
                                Console.ResetColor();
                                name = Console.ReadLine();
                            }
                            if (!string.IsNullOrEmpty(name))
                            {
                                client.Name = name;
                                context.SaveChanges();
                            }
                            break;

                        case 2:
                            Console.WriteLine($"E-mail atual: {client.Email}");
                            Console.WriteLine("E-mail:");
                            string email = Console.ReadLine();
                            while (!string.IsNullOrEmpty(email) && (!Regex.IsMatch(email, @"^([\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)+|([\w-]+.)+([a-zA-Z]{2,}))$")))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido.");
                                Console.ResetColor();
                                email = Console.ReadLine();
                            }
                            if (!string.IsNullOrEmpty(email))
                            {
                                client.Email = email;
                                context.SaveChanges();
                            }
                            break;
                        case 3:
                            Console.WriteLine($"Telefone atual: {client.Phone}");
                            Console.WriteLine("Telefone:");
                            string telefone = Console.ReadLine();
                            while (!string.IsNullOrEmpty(telefone) && (!Regex.IsMatch(telefone, @"^[0-9]+$") || telefone.Length < 8))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Telefone inválido. Por favor, insira um telefone válido somente com números e com pelo menos 8 caracteres.");
                                Console.ResetColor();
                                telefone = Console.ReadLine();
                            }
                            if (!string.IsNullOrEmpty(telefone))
                            {
                                client.Phone = telefone;
                                context.SaveChanges();
                            }
                            break;

                        case 0:
                            Console.Clear();
                            ShowMenuHospede();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opção inválida. Aperte qualquer tecla para tentar novamente.");
                            Console.ResetColor();
                            Console.ReadLine();
                            AtualizarHospede();
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hóspede atualizado com sucesso. Aperte qualquer tecla para retornar ao menu de hóspedes.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuHospede();
            }
        }
    }
}
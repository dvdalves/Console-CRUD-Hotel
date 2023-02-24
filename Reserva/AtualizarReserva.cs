using CrudHotel;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace CrudHotel
{
    public partial class CrudHotel
    {
        public static void AtualizarReserva()
        {
            using (var context = new DBContext())
            {
                if (context.reservas.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   Não há reservas cadastradas. Aperte qualquer tecla para retornar ao menu anterior.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuReserva();
                }

                Console.Clear();
                Console.WriteLine("Atualizando reserva. Aperte 0 para retornar ao menu de reserva.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Escolha uma reserva que você deseja atualizar (pelo ID):");
                Console.Clear();
                Console.ResetColor();
                foreach (var reserva in context.reservas)
                {
                    Console.Clear();
                    Console.Write("Id: " + reserva.id);
                    Console.WriteLine(" Nome: " + reserva.NomeHotel);
                }
                
                Console.WriteLine();
                Console.WriteLine("Escolha pelo (ID) a reserva que você deseja ver as informações: ");

                var escolha = Console.ReadLine();

                if (escolha == "0")
                {
                    Console.Clear();
                    ShowMenuReserva();
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
                    ShowMenuReserva();
                    return;
                }

                Reserva client = context.reservas.FirstOrDefault(x => x.id == id);
                ;

                if (client == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Reservas com ID {id} não encontrado. Aperte qualquer tecla para retornar ao menu de reserva.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuReserva();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Hotel atual: {client.NomeHotel}");
                    Console.WriteLine("Escolha seu novo Hotel:");
                    Console.WriteLine("1.Hotel Prover Barra diária no valor de R$ 200,00.");
                    Console.WriteLine("");
                    Console.WriteLine("2.Hotel Prover Copacabana diária no valor de R$ 150,00.");
                    Console.WriteLine("");
                    Console.WriteLine("3.Hotel Prover Centro diária no valor de R$ 100,00.");

                    string hotel = Console.ReadLine();

                    if (!string.IsNullOrEmpty(hotel))
                    {
                        Reserva res = new Reserva();
                        switch (hotel)
                        {
                            case "1":
                                client.NomeHotel = "Prover Barra";
                                client.PrecoPorDia = 200;
                                client.ValorTotal = 200 * client.DiasReservados;
                                context.reservas.Update(client);
                                context.SaveChanges();
                                break;
                            case "2":
                                client.NomeHotel = "Prover Copacabana";
                                client.PrecoPorDia = 150;
                                client.ValorTotal = 150 * client.DiasReservados;
                                context.reservas.Update(client);
                                context.SaveChanges();
                                break;
                            case "3":
                                client.NomeHotel = "Prover Centro";
                                client.PrecoPorDia = 100;
                                client.ValorTotal = 100 * client.DiasReservados;
                                context.reservas.Update(client);
                                context.SaveChanges();
                                break;

                            default:
                                break;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Reserva atualizada com sucesso. Aperte qualquer tecla para retornar ao menu de reserva.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuReserva();
            }
        }
    }
}
using System;
using CrudHotel;

namespace CrudHotel;
public partial class CrudHotel
{
    static List<Reserva> reserva = new List<Reserva>();

    public static void ShowMenuReserva()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   ==============================================");
            Console.WriteLine("                   *                                            *");
            Console.ResetColor();
            Console.WriteLine("                              - Rede Prover de Hotéis -          ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                            *");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                Cadastro de Reserva              ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                            *");
            Console.WriteLine("                   ==============================================");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("                   Escolha uma opção:");
            Console.WriteLine("                   1. Criar reserva.");
            Console.WriteLine("                   2. Ver reservas.");
            Console.WriteLine("                   3. Atualizar reserva.");
            Console.WriteLine("                   4. Deletar reserva.");
            Console.WriteLine("                   0. Voltar.");

            try
            {

                int option = 0;
                bool isValidInput = int.TryParse(Console.ReadLine(), out option);

                if (isValidInput)
                {

                    switch (option)
                    {
                        case 1:
                            CriarReserva();
                            break;
                        case 2:
                            VerReserva();
                            break;
                        case 3:
                            AtualizarReserva();
                            break;
                        case 4:
                            DeletarReserva();
                            break;
                        case 0:
                            Console.Clear();
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("                   Opção inválida.");
                            Console.Clear();
                            ShowMenuReserva();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   Você precisa inserir um número válido. Aperte uma tecla para voltar.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuReserva();
                }
            }

            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Entrada inválida. Por favor, digite um número. Aperte qualquer tecla para voltar.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuReserva();

            }
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                   Entrada inválida. Por favor, digite um número. Aperte qualquer tecla para voltar.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            ShowMenuReserva();

        }
    }
}
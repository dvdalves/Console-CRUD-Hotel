using CrudHotel;
using System.Data.SqlClient;

namespace CrudHotel
{
    public partial class CrudHotel
    {
        static void Main(string[] args)
        {
            ShowMainMenu();
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   ===============================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                             * ");
            Console.ResetColor();
            Console.WriteLine("                              Bem-vindo ao nosso sistema!          ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                             * ");
            Console.ResetColor();
            Console.WriteLine("                                 Rede de Hotéis Prover             ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                             * ");
            Console.ResetColor();
            Console.WriteLine("                                                                   ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                             * ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                            Sinta-se em casa, mesmo longe          ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                             * ");
            Console.WriteLine("                   ===============================================");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("                   Escolha uma opção:");
            Console.WriteLine("                   1. Cadastro de hóspedes.");
            Console.WriteLine("                   2. Cadastro de reserva.");
            Console.WriteLine("                   0. Sair.");

            try
            {
                int option = 0;
                bool isValidInput = int.TryParse(Console.ReadLine(), out option);

                if (isValidInput)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            ShowMenuHospede();
                            break;
                        case 2:
                            Console.Clear();
                            ShowMenuReserva();
                            break;
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("                   Tem certeza que deseja sair? (S/N)");
                            Console.ResetColor();
                            string? confirmation = Console.ReadLine();
                            if (confirmation.ToUpper() == "S")
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                ShowMainMenu();
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("                   Opção inválida. Aperte uma tecla para voltar.");
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ShowMainMenu();
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
                    ShowMainMenu();
                }
            }

            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Você precisa inserir um número. Aperte uma tecla para voltar.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMainMenu();
            }
        }
    }
}
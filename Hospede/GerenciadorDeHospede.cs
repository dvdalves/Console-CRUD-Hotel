using System;
using CrudHotel;

namespace CrudHotel;
public partial class CrudHotel
{

    static List<Hospede> hospede = new List<Hospede>();

    public static void ShowMenuHospede()
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                Cadastro de Hóspedes             ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                   *                                            *");
            Console.WriteLine("                   ==============================================");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("                   Escolha uma opção:");
            Console.WriteLine("                   1. Criar hóspede.");
            Console.WriteLine("                   2. Ver hóspedes.");
            Console.WriteLine("                   3. Atualizar hóspede.");
            Console.WriteLine("                   4. Deletar hóspede.");
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
                            CriarHospede();
                            break;
                        case 2:
                            VerHospedes();
                            break;
                        case 3:
                            AtualizarHospede();
                            break;
                        case 4:
                            DeletarHospede();
                            break;
                        case 0:
                            Console.Clear();
                            ShowMainMenu();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("                   Opção inválida. Aperte uma tecla para voltar.");
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ShowMenuHospede();
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
                    ShowMenuHospede();
                }
            }

            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Você precisa inserir um número. Aperte uma tecla para voltar.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuHospede();
            }
        }

        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                   Você precisa inserir um número. Aperte uma tecla para voltar.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            ShowMenuHospede();
        }
    }
}
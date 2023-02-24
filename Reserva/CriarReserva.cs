using CrudHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudHotel
{
    public partial class CrudHotel
    {
        public static string? NomeHotel;
        public static int PrecoPorDia;
        public static int numeroDeDias;
        static void CriarReserva()
        {
            DBContext _context = new DBContext();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                        ==============================================");
            Console.WriteLine("                        *                                            *");
            Console.ResetColor();
            Console.WriteLine("                                         Rede Prover                  ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                        *                                            *");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                   Reserve seu Hotel Prover           ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                        *                                            *");
            Console.WriteLine("                        ==============================================");
            Console.ResetColor();
            Console.WriteLine("                                                                                              ");
            Console.WriteLine("                   Bem-vindo ao sistema de reserva de quartos da Rede Hotéis Prover.          ");
            Console.WriteLine("                   Escolha o hotel desejado:                                                  ");
            Console.WriteLine("                   1. Hotel Prover Barra - R$ 200 por dia.                                    ");
            Console.WriteLine("                   2. Hotel Prover Copacabana - R$ 150 por dia.                               ");
            Console.WriteLine("                   3. Hotel Prover Centro - R$ 100 por dia.                                   ");
            Console.WriteLine("                   0. Voltar.                                                                 ");
            Console.WriteLine("                   Digite o número da opção desejada:                                         ");
            
            try
            {
                int? escolhaHotel = int.Parse(Console.ReadLine());
                switch (escolhaHotel)
                {
                    case 1:
                        Console.Clear();
                        NomeHotel = "Hotel Prover Barra";
                        PrecoPorDia = 200;
                        break;
                    case 2:
                        Console.Clear();
                        NomeHotel = "Hotel Prover Copacabana";
                        PrecoPorDia = 150;
                        break;
                    case 3:
                        Console.Clear();
                        NomeHotel = "Hotel Prover Centro";
                        PrecoPorDia = 100;
                        break;
                    case 0:
                        Console.Clear();
                        ShowMenuReserva();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                   Opção inválida. Aperte uma tecla para retornar.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        CriarReserva();
                        break;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Valor inválido. Aperte uma tecla para voltar.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                CriarReserva();
            }

            Console.WriteLine("Escolha o hospede pelo id que deseja fazer a reserva ");
            foreach (var item in _context.hospedes.Where(x => x.Reservaid == null).ToList())
            {
                Console.WriteLine($"Id: {item.id}, Nome: {item.Name}");
            }
            int id = int.Parse(Console.ReadLine());
            var hospede = _context.hospedes.FirstOrDefault(x => x.id == id);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Você escolheu o hotel " + NomeHotel + " com preço por dia de R$ " + PrecoPorDia);
            Console.ResetColor();
            Console.WriteLine("Aceitamos reservas para no máximo 30 dias. Quantos dias deseja ficar hospedado?");
            Console.WriteLine("Se desejar voltar ao menu anterior, digite '0'.");

            int numeroDeDias;
            string input = Console.ReadLine();

            if (input.ToUpper() == "VOLTAR")
            {
                Console.Clear();
                CriarReserva();
            }

            while (!int.TryParse(input, out numeroDeDias) || numeroDeDias < 1 || numeroDeDias > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Reserva cancelada. Digite uma reserva entre 1 e 30 dia. Aperte qualquer tecla para retornar ao menu de escolha.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                CriarReserva();
            }

            try
            {
                if (numeroDeDias > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Desculpe, não é possível fazer uma reserva por mais de 30 dias.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    CriarReserva();
                }
                int totalPrice = numeroDeDias * PrecoPorDia;
                Console.WriteLine("O preço total da sua reserva será de R$ " + totalPrice);
                Console.WriteLine("Confirma a reserva? (S/N)");
                string confirmation = Console.ReadLine();
                if (confirmation.ToUpper() == "S")
                {
                    Reserva res = new Reserva { NomeHotel = NomeHotel, PrecoPorDia = PrecoPorDia, DiasReservados = numeroDeDias, Hospede = hospede };
                    reserva.Add(res);
                    _context.reservas.Add(res);
                    _context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Reserva realizada com sucesso! O pagamento deverá ser feito no momento do Check-in.");
                    Console.ResetColor();
                    Console.WriteLine("Aperte qualquer tecla para retornar ao menu.");
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuReserva();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Reserva cancelada. Para confirmar a reserva digite S e N para cancelar.");
                    Console.ResetColor();
                    Console.WriteLine("Aperte qualquer tecla para retornar.");
                    Console.ReadLine();
                    Console.Clear();
                    CriarReserva();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido. Aperte uma tecla para retornar.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                CriarReserva();
            }

            Console.ReadLine();

        }
    }
}
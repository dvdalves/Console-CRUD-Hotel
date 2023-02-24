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
        static void VerReserva()
        {
            using (var db = new DBContext())
            {
                var reservas = db.reservas.ToList();

                if (reservas.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   Não há reservas cadastradas. Aperte qualquer tecla para retornar ao menu anterior.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenuReserva();
                    return;
                }
                else
                {
                    foreach (var reserva in reservas)
                    {
                        Console.Clear();
                        Console.WriteLine($"ID da reserva: {reserva.id}");
                        Console.WriteLine();
                        Console.WriteLine(reserva.ToString());
                        Console.WriteLine();
                        Console.WriteLine("Aperte qualquer tecla para mostrar a próxima reserva.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }

            ShowMenuReserva();
        }
    }
}

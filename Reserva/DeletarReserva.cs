using CrudHotel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CrudHotel;

public partial class CrudHotel
{
    static void DeletarReserva()
    {
        using (DBContext dbContext = new DBContext())
        {
            if (dbContext.reservas.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   Não há reservas cadastradas. Aperte qualquer tecla para retornar ao menu anterior.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuReserva();
                return;
            }

            Console.Clear();
            Console.WriteLine("Deletando reserva:");
            Console.WriteLine("Digite o ID da reserva:");
            foreach (var item in dbContext.reservas.Include(x => x.Hospede).ToList())
            {
                Console.WriteLine($"Id: {item.id}, Nome: {item.NomeHotel} , hospede: {(item.Hospede != null ? item.Hospede.Name : "sem hospede")}");
            }  
            int id = int.Parse(Console.ReadLine());

            Reserva reserva = dbContext.reservas.Include(d => d.Hospede).FirstOrDefault(x => x.id == id);

            if (reserva == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Reserva não encontrada. Aperte qualquer tecla para retornar ao menu anterior.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                ShowMenuReserva();
                return;
            }
                      
            dbContext.Remove(reserva);            
            dbContext.SaveChanges();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reserva deletada com sucesso. Aperte qualquer tecla para retornar ao menu anterior.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            
            ShowMenuReserva();
        }
    }
}

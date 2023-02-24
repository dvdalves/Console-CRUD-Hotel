using CrudHotel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudHotel.CrudHotel;

namespace CrudHotel
{
    public class DBContext : DbContext
    {
        public DBContext()
        {

        }
        public DbSet<Hospede> hospedes { get; set; }
        public DbSet<Reserva> reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Crud;Trusted_Connection=True;");
        }
    }
}

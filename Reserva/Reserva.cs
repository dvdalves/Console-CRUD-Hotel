using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudHotel;

namespace CrudHotel
{
    public partial class CrudHotel
    {
        public class Reserva
        {
            public int id { get; set; }
            public string NomeHotel { get; set; }
            public int PrecoPorDia { get; set; }
            public int DiasReservados { get; set; }
            public Hospede? Hospede { get; set; }

            public int ValorTotal
            {
                get { return PrecoPorDia * DiasReservados; }
                set { }
            }

            public override string ToString()
            {
                return $"Nome do Hotel: {NomeHotel}, Preço por dia: {PrecoPorDia}, Dias reservados: {DiasReservados}, Total = {ValorTotal}";
            }
        }
    }
}

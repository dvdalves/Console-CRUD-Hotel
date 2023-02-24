using static CrudHotel.CrudHotel;
using CrudHotel;


namespace CrudHotel

{
    public class Hospede
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Reservaid { get; set; }

    }
}


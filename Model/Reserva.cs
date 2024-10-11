namespace BiBliotecaUser.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public int Fk_Membro { get; set; }
        public int Fk_Livro { get; set; }
    }
}
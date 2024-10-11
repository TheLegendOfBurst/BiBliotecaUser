namespace BiBliotecaUser.Model
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int Fk_Membro { get; set; }
        public int Fk_Livro { get; set; }
    }
}

namespace BiBliotecaUser.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int Fk_Categoria { get; set; }
        public bool Disponibilidade { get; set; }
    }
}

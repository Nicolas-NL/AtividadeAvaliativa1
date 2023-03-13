namespace AtividadeAvaliativa1.Models.Enuns
{
    public class Personagem
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int PontosVida { get; set; }

        public int Forca { get; set; }

        public int Defesa { get; set; } 
        public int Inteligencia { get; set; }

        public ClasseEnum Classe { get; set; }
    }
}
namespace SA2.Classes.Entidades
{
    public class Curso
    {
        private Dictionary<int, string> cursos = new Dictionary<int, string>()
        {
            { 1, "Técnico de desenvolvimento de sistemas" },
            { 2 , "Técnico em eletroeletronica"},
            { 3 , "Técnico em mecânica" }

        };
        
        public Dictionary<int, string> Cursos
        {
            get { return cursos; }
            set { cursos = value; }
        }

    }
}

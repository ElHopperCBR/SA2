using SA2.Classes.Entidades.Enumeracoes;

namespace SA2.Classes.Entidades
{
    public class Admin : User
    {
        public Admin()
        {
            Regra = TipoRegra.Admin;
        }
    }
}

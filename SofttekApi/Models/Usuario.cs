namespace SofttekApi.Models
{
    public class Usuario
    {
        public string id { get; set; }
        public string user { get; set; }
        public string password { get; set;}

        public static List<Usuario> usuarios()
        {
            var list = new List<Usuario>()
            {
                new Usuario {
                    id = "1",
                    user = "UsuarioSofttek",
                    password = "S1st3m4s"
                }
            };
            return list;
        }
    }
}

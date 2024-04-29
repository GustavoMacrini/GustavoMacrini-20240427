using Microsoft.AspNetCore.Identity;

namespace GestaoColaboradores.Models.Colaborador
{
    using GestaoColaboradores.Models.User;
    public class Colaborador : Entity
    {
        public string Name { get; set; }
        public Unidade Unidade { get; set; }
        public User Usuario { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(string name, Unidade unidade, User usuario)
        {
            Name = name;
            Unidade = unidade;
            Usuario = usuario;
        }
    }
}

namespace GestaoColaboradores.Models.Colaborador
{
    public class Unidade : Entity
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public Unidade()
        {

        }

        public Unidade(string name)
        {
            Code = Guid.NewGuid();
            Name = name;
            Active = true;
        }

    }
}

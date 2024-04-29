namespace GestaoColaboradores.Models.Colaborador
{
    using GestaoColaboradores.Models.User;
    public class ColaboradorViewModel
    {
        
        public List<User> Usuarios {  get; set; }
        public List<Unidade> Unidades { get; set; }
        public Colaborador Colaborador { get; set; }

        public string Name { get; set; }
        public Guid Usuario { get; set; }
        public Guid Unidade { get; set; }
    
        public ColaboradorViewModel() { }

        public ColaboradorViewModel(List<User> usuarios, List<Unidade> unidades)
        { 
            Usuarios = usuarios;
            Unidades = unidades;
        }

    }
}

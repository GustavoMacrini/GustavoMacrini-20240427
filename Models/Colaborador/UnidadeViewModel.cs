namespace GestaoColaboradores.Models.Colaborador
{
    public class UnidadeViewModel
    {
        public Unidade Unidade { get; set; }
        public List<Colaborador> Colaboradores { get; set; }

        public UnidadeViewModel()
        {

        }

        public UnidadeViewModel(Unidade unidade, List<Colaborador> colaboradores)
        {
            Unidade = unidade;
            Colaboradores = colaboradores;
        }

    }
}

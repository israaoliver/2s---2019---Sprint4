using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class ServicoViewModel : BaseViewModel
    {
        public List<Servicos> Servicos {get;set;}

        public ServicoViewModel()
        {
            this.Servicos = new List<Servicos>();
        }
        public ServicoViewModel(List<Servicos> servicos)
        {
            this.Servicos = servicos;
        }
    }
}
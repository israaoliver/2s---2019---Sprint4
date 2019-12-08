using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class PagamentoViewModel : MensagemViewModel
    {
        public Evento Evento {get;set;}

        public PagamentoViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
        public PagamentoViewModel()
        {
            this.Evento = new Evento();
        }

    }
}
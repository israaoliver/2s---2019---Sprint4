namespace RoleTopMVC.ViewModels
{
    public class MensagemViewModel : BaseViewModel
    {
        public string Mensagem{get;set;}

        public MensagemViewModel()
        {}

        public MensagemViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
    }
}
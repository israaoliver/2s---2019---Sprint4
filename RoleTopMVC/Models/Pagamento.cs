using System.Dynamic;
namespace RoleTopMVC.Models
{
    public class Pagamento
    {
        public Cliente Cliente {get;set;}
        public string nomeTitular {get;set;}
        public string Nurmero {get;set;}
        public uint ValidadeMes {get;set;}
        public uint ValidadeAno {get;set;}
        public uint CVV {get;set;} 
        public uint Parcelas {get;set;}

        public Pagamento(){
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Restaurante.Integracao.Torneiras
{
    public class CurrentCard
    {
        public decimal tst { get; set; }
        public decimal tst2 { get; set; }
        public decimal cardId { get; set; }
        public decimal cardAction { get; set; }
        public decimal moneyAmount { get; set; }
        public decimal plu { get; set; }
        public decimal volumeAmount { get; set; }
        public decimal volumeAmountDp { get; set; }
        public decimal servings { get; set; }
        public decimal servingsLimit { get; set; }
        public string nameStaff { get; set; }
        public string nameCustomer { get; set; }

        public CurrentCard() { }
    }

    public class List_CurrentCard : List<CurrentCard> { }
}

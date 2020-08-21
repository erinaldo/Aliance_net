using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Restaurante.Integracao.Torneiras
{
    public class CardPurchases
    {
        public decimal cardId { get; set; }
        public decimal tstPurchase { get; set; }
        public decimal tstExpiry { get; set; }
        public decimal moneyAmount { get; set; }
        public decimal servingsLimit { get; set; }
        public decimal cadAction { get; set; }
        public string namestaff { get; set; }
        public string nameCustomer { get; set; }

        public CardPurchases() { }
    }

    public class List_CardPurchases : List<CardPurchases> { }
}

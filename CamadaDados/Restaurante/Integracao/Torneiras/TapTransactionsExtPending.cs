using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Restaurante.Integracao.Torneiras
{
    public class TapTransactionsExtPending
    {
        public decimal cardId { get; set; }
        public decimal cardType { get; set; }
        public decimal tstStart { get; set; }
        public decimal tstStop { get; set; }
        public decimal plu { get; set; }
        public decimal moneyAmount { get; set; }
        public decimal volumeAmount { get; set; }
        public decimal volumeAmountDp { get; set; }
        public decimal servings { get; set; }
        public string externalId { get; set; }
        public string comment { get; set; }

        public TapTransactionsExtPending() { }
    }

    public class List_TapTransactionsExtPending : List<TapTransactionsExtPending> { }
}

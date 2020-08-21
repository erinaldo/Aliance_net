using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Restaurante.Integracao.Torneiras
{
    public class TRegistro_TapTransactions
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
        public string Integrado { get; set; } // isnull(Integrado, N(null) - não integrado) = S(sim) - integrado
        public string cardNumber { get; set; }
        public string cdProduto { get; set; }


        public TRegistro_TapTransactions() { }
    }

    public class List_TapTransactions : List<TRegistro_TapTransactions> { }
}

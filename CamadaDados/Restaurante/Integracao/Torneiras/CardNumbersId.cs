using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Restaurante.Integracao.Torneiras
{
    public class CardNumbersId
    {
        public decimal cardId { get; set; }
        public decimal cardNumber { get; set; }

        public CardNumbersId() { }
    }

    public class List_CardNumberId : List<CardNumbersId> { }
}

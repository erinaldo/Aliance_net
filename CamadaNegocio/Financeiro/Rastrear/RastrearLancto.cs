using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Bloqueto;

namespace CamadaNegocio.Financeiro.Rastrear
{
    public enum TP_Rastrear { tm_nf, tm_pedido, tm_estoque, tm_duplicata, tm_bloqueto, tm_caixa, tm_cheque, tm_contabil };

    public class TCN_RastrearLancto
    {
        public static blListaTitulo RastrearBloquetos(TP_Rastrear tp_central, System.Collections.Generic.List<object> filtro)
        {
            switch (tp_central)
            {
                case TP_Rastrear.tm_caixa:
                    {
                        return null;
                    }
            }
            return null;
        }
    }
}

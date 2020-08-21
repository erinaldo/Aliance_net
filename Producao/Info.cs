using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Producao
{
    public class TInfo
    {
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }

        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("120000:NULL:NULL:NULL:Produção|");
            str.Append("120100:120000:PRDAL5:Producao.TFControleProducao:Painel Controle Produção|");
            str.Append("120500:120000:PRDAL1:Producao.TFLanOrdemProducao:Ordem Produção|");
            str.Append("120600:120000:PRDAL2:Producao.TFLanFormulaApontamento:Formulas de Apontamento|");
            str.Append("120700:120000:PRDAL3:Producao.TFLanApontamentoProducao:Apontamento Produção|");
            str.Append("120800:120000:PRDRP4:Producao.TFLanRastreabilidadeProduto:Rastreabilidade Produto|");

            //MENU DASHBOARDS
            str.Append("120900:120000:NULL:NULL:Dashboards|");
            //FILHOS DO MENU DASHBOARDS
            str.Append("120901:120900:PRDB01:Producao.Dashboards.TFDashProduto:Produto|");

            //MENU CADASTROS
            str.Append("125000:120000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("125900:125000:PRDC09:Producao.Cadastros.TFCad_PRD_Custos:Custos|");
            str.Append("126300:125000:PRDC12:Producao.Cadastros.TFCad_PRD_Lote:Cadastro de Lotes|");
            str.Append("126400:125000:PRDC13:Producao.Cadastros.TFCadTurno:Cadastro Turno Produção|");
            
            return str.ToString();
        }

    }
}

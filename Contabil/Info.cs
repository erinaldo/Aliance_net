using System;
using System.Collections.Generic;
using System.Text;

namespace Contabil
{
    public class TInfo
    {
        static public string pub;
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("090000:NULL:NULL:NULL:Contábil|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("090100:090000:CTBCTR:Contabil.TFCentralContabil:Central Contabilidade|");
            str.Append("090500:090000:CTBCFG:Contabil.TFLanConfigContabil:Configuração Contábil|");
            str.Append("090600:090000:CTBCFG:Contabil.TFLan_Patrimonio:Lançamento de Patrimônio|");
            str.Append("090700:090000:CTBZER:Contabil.TFLan_FechamentoContabil:Lançamento de Fechamento Contábil|");
            str.Append("090800:090000:CTBECD:Contabil.TFLanSpedContabil:Sped Contábil|");
            str.Append("090900:090000:CTBAEF:Contabil.TFLanAjusteEstoqueFixar:Ajuste Estoque Fixar|");
            str.Append("091000:090000:CTBAPD:Contabil.TFAuditarProdutor:Auditar Produtor|");

            //MENU CADASTROS
            str.Append("095000:090000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("095100:095000:CTBC01:Contabil.Cadastros.TFCad_PlanoContas:Plano de Contas Contábil|");
            str.Append("095200:095000:CTBC02:Contabil.Cadastros.TFCadPatrimonio:Patrimônio|");
            str.Append("095300:095000:CTBC03:Contabil.Cadastros.TFCadGrupoPatrimonio:Grupo Patrimônio|");
            str.Append("095400:095000:CTBC04:Contabil.Cadastros.TFCadParamZeramento:Cadastro Parametros Zeramento|");
            str.Append("095500:095000:CTBC05:Contabil.Cadastros.TFCad_CTB_DRE:Cadastro DRE|");

            //MENU RELATÓRIOS
            str.Append("097000:090000:NULL:NULL:Relatórios|");
            str.Append("097100:097000:CTBR01:Contabil.Relatorio.TFRel_RazaoContabil:Relatorio Razão Contabil|");

            return str.ToString();
        }

        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}

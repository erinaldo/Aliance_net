using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostoCombustivel
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
            str.Append("180000:NULL:NULL:NULL:Posto Combustivel|");
            str.Append("181000:180000:PDCEB:PostoCombustivel.TFLanEncerranteBico:Encerrante Bico|");
            str.Append("182000:180000:PDCCV:PostoCombustivel.TFLanConvenio:Convenio Venda Combustivel|");
            str.Append("183000:180000:PDCIT:PostoCombustivel.TFLanIntervencaoTecnica:Intervenção Tecnica|");
            str.Append("184000:180000:PDCAT:PostoCombustivel.TFLanMedicaoTanque:Aferição Tanque|");
            str.Append("184100:180000:PDCCV:PostoCombustivel.TFConsultaVendaCombustivel:Consulta Venda Combustivel|");
            str.Append("184200:180000:PDCOS:PostoCombustivel.TFLanOrdemServico:Ordem Serviço|");
            str.Append("184300:180000:PDCCF:PostoCombustivel.TFLanCartaFrete:Consulta - Carta Frete|");

            //MENU CADASTROS
            str.Append("185000:180000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("185100:185000:PDC01:PostoCombustivel.Cadastros.TFCadTanque:Tanque Combustivel|");
            str.Append("185200:185000:PDC02:PostoCombustivel.Cadastros.TFCadBombaAbastecimento:Bomba Combustivel|");
            str.Append("185300:185000:PDC03:PostoCombustivel.Cadastros.TFCadProgCombustivel:Programação Combustivel|");
            str.Append("185400:185000:PDC04:PostoCombustivel.Cadastros.FCadCfgPosto:Configuração Posto|");
            str.Append("185500:185000:PDC05:PostoCombustivel.Cadastros.TFCadCfgPainelVendaConv:Config. Painel Venda Conv|");
            str.Append("185600:185000:PDC06:PostoCombustivel.Cadastros.TFCadPrecoANP:Preço Venda ANP|");
            str.Append("185700:185000:PDC07:PostoCombustivel.Cadastros.TFCadTrans_X_UnidPag:Transportadora X Unidade Pagamento|");

            return str.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frota
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
            str.Append("190000:NULL:NULL:NULL:Frota|");

            //OPÇÕES DO MENU DE LANÇAMENTO
            str.Append("190100:190000:FRTVIA:Frota.TFLanViagem:Consulta  -  Viagens|");
            str.Append("190101:190000:FRTCTR:Frota.TFCentralGerFrota:Central Gerenciamento Frota|");
            str.Append("190110:190000:FRTINF:Frota.TFLanInfracoes:Consulta - Infrações|");
            str.Append("190120:190000:FRTMAN:Frota.TFLanManutencao:Consulta - Manutenções/Despesas|");
            str.Append("190130:190000:FRTSEG:Frota.TFLanSeguros:Consulta - Seguro Veiculo|");
            str.Append("190131:190000:FRTCFT:Frota.TFLanCartaFrete:Consulta - Carta Frete|");
            str.Append("190140:190000:FRTACV:Frota.TFLanAcertoMotorista:Consulta - Acerto Motorista|");
            str.Append("191200:190000:FRTABT:Frota.TFLanAbastVeiculo:Consulta - Abastecimentos|");
            str.Append("191300:190000:FRTABF:Frota.TFLanAbastFrota:Abastecimento Frota|");
            str.Append("191400:190000:FRTCTE:Frota.TFLanCTe:CTe-Conhecimento Transporte Eletrônico|");
            str.Append("191410:190000:FRTMDF:Frota.TFLanMDFe:MDFe - Manifesto Eletrônico de Documentos|");
            str.Append("191500:190000:FRTMVP:Frota.TFLanMovimentacaoPneu:Movimentação de Pneus|");
            str.Append("191600:190000:FRTORE:Frota.TFLanOutrasReceitas:Lançamento - Outras Receitas|");
            str.Append("191700:190000:FRTGPN:Frota.TFLanMovPneu:Gestão de Pneus|");
            
            //MENU CADASTRO
            str.Append("195000:190000:NULL:NULL:Cadastros|");

            //FILHO DO MENU CADASTRO
            str.Append("195100:195000:FRTC01:Frota.Cadastros.TFConsultaVeiculos:Consulta de Veiculos|");
            str.Append("195200:195000:FRTC02:Frota.Cadastros.TFCadRotaFrete:Cadastros de Rota/Frete|");
            str.Append("195300:195000:FRTC03:Frota.Cadastros.TFCadDespesa:Despesas Frota|");
            str.Append("195400:195000:FRTC03:Frota.Cadastros.TFCadMarcaVeiculo:Cadastros de Marca de Veiculos|");
            str.Append("195500:195000:FRTC04:Frota.Cadastros.TFCadRodado:Cadastro de Rodado|");
            str.Append("195999:195000:FRTC99:Frota.Cadastros.TFCadCfgFrota:Configuração Frota|");
            str.Append("196100:195000:FRTC09:Frota.Cadastros.TFCad_CfgMDFe:Configuração MDF-e|");

            return str.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos
{
    class TInfo
    {
        static public string pub;
        public string getInfoMenu()
        {
            StringBuilder str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("070000:NULL:NULL:NULL:Serviço|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("070100:070000:OSEL01:Servicos.TFLanContrato:Contrato de Serviços|");
            str.Append("070200:070000:OSEL02:Servicos.TFLan_Ordem_Servico:Ordem de Serviço|");
            str.Append("070300:070000:OSEL03:Servicos.TFLanServicoOficina:Ordem Serviço Oficina|");
            str.Append("070400:070000:OSEL04:Servicos.TFPainelOSOficina:Central OS Oficina|");
            str.Append("070500:070000:OSEL05:Servicos.TFLanOSServico:Consulta - Ordem Serviço|");
            str.Append("070600:070000:0SEL06:Servicos.TFLanOSTarefa:Painel Gerencial - Projetos|");
            str.Append("070700:070000:OSELO7:Servicos.TFLanAtividades:Consulta - Atividades Projeto|");
            str.Append("070800:070000:OSEL08:Servicos.TFPainelServSalao:Central Serviços Salão|");

            //MENU CADASTROS
            str.Append("075000:070000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("075100:075000:OSEC01:Servico.Cadastros.TFCad_TPOrdem:Tipo de Ordem|");
            str.Append("075200:075000:OSEC02:Servico.Cadastros.TFCadOseEtapaOrdem:Etapas de Ordem|");
            str.Append("075300:075000:OSEC03:Servico.Cadastros.TFCadOseTpOrdemxEtapa:Tipo de Ordem X Etapas|");
            str.Append("075500:075000:OSEC05:Servicos.Cadastros.TFCad_OSE_SerialClifor:Serial Clifor|");
            str.Append("075600:075000:OSEC06:Servicos.Cadastros.TFCad_OseProximaEtapa:Proxima Etapa|");
            str.Append("075900:075000:OSEC09:Servicos.Cadastros.TFCad_ParamOs:Parametros OS|");
            str.Append("076300:075000:OSEC13:Servicos.Cadastros.TFCadVeiculoCliente:Veiculos Cliente|");
            str.Append("077000:075000:OSEC14:Servicos.Cadastros.TFCadCfgContrato:Configuração Contrato|");
            str.Append("078000:075000:OSEC15:Servicos.Cadastros.TFCad_CfgAgendamento:Configuração Agendamento|");
            return str.ToString();
        }
        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}

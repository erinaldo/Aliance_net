using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parametros
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
            str.Append("990000:NULL:NULL:NULL:Parâmetros|");
            //MENU CADASTROS
            str.Append("992000:990000:NULL:NULL:Configurações|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("992100:992000:PRMC01:Parametros.Config.TFCadConfigGer:Configurações Gerais|");
            str.Append("992200:992000:PRMC02:Parametros.Config.TFCadConfigGer_X_Empresa:Configurações por Empresa|");
            str.Append("992300:992000:PRMC04:Parametros.Config.TFCadConfigGer_X_Terminal:Configurações por Terminal|");
            str.Append("992400:992000:PRMC05:Parametros.Config.TFCad_Menu:Gerenciamento de Menu|");
            str.Append("992600:992000:PRMC06:Parametros.Diversos.TFLogEmail:Consulta Email Enviados|");
            str.Append("992700:992000:PRMC07:Parametros.Diversos.TFCentralAudit:Central Auditoria|");

            str.Append("993000:990000:NULL:NULL:Manutenção|");
            str.Append("993100:993000:PRMC31:Parametros.Diversos.TFBackup:Backup Banco Dados|");

            //MENU CADASTROS
            str.Append("995000:990000:NULL:NULL:Diversos|");
            //FILHOS DO MENU CADASTROS
            str.Append("995100:995000:PRMC21:Parametros.Diversos.TFCad_Usuario:Usuários do Sistema|");
            str.Append("995109:995000:PRMC22:Parametros.Diversos.TFListRegraEspecial:Regras Especiais|");
            str.Append("995300:995000:PRMC23:Parametros.Diversos.TFCadEmpresa:Empresas|");
            str.Append("995400:995000:PRMC24:Parametros.Diversos.TFCadFeriado:Feriados|");
            str.Append("995500:995000:PRMC25:Parametros.Diversos.TFCadParamSys:Parâmetros de Cadastros|");
            str.Append("995600:995000:PRMC26:Parametros.Diversos.TFCadProtocolo:Protocolo de Comunicação|");
            str.Append("995700:995000:PRMC27:Parametros.Diversos.TFCadRegiaoVenda:Região de Venda|");

            str.Append("995800:995000:PRMC28:Parametros.Diversos.TFCadTabelaPreco:Tabela de Preço|");
            str.Append("995900:995000:PRMC29:Parametros.Diversos.TFCadTerminal:Terminal de Acesso|");
            str.Append("996000:995000:PRMC3000:Parametros.Diversos.TFCadTerminal_X_Protocolo:Terminal X Protocolo|");
            str.Append("996100:995000:PRMC31:Parametros.Diversos.TFCadTipoTransporte:Tipo de Transporte|");
            str.Append("996200:995000:PRMC32:Parametros.Diversos.TFCadTpVeiculo:Tipo de Veículo|");
            str.Append("996300:995000:PRMC33:Parametros.Diversos.TFCadCargoFuncionario:Cargo Funcionarios|");
            str.Append("996400:995000:PMRC33:Parametros.Diversos.TFLan_Compromisso:Agenda de Compromissos|");
            str.Append("996500:995000:PMRT34:Parametros.Diversos.TFTrigger:Trigger|");
            str.Append("996600:995000:PMRT35:Parametros.Diversos.TFCad_CfgECommerce:Configurar Integração E-Commerce|");
            str.Append("996700:995000:PMRT36:Parametros.Diversos.TFCadLojaVirtual:Loja Virtual|");
            str.Append("996800:995000:PMRT37:Parametros.Diversos.FLayoutEtiqueta:Layout etiqueta|");
            str.Append("996900:995000:PMRT38:Parametros.Diversos.TFCadCfgEmpresa:Configuração Parâmetros Empresa|");
            str.Append("997000:995000:PMRT39:Parametros.Diversos.TFCadRota:Cadastros de Rotas por Clifor|");

            //MENU auditoria
            str.Append("998000:990000:NULL:NULL:Auditoria|");
            str.Append("998100:998000:PMRT50:Parametros.Diversos.TFTrigger:Trigger|");
            str.Append("998200:998000:PMRT51:Parametros.Diversos.TFAuditoria:Auditoria|");

            return str.ToString();
        }

    }
}

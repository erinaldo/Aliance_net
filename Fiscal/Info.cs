using System.Text;

namespace Fiscal
{
    class TInfo
    {
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("040000:NULL:NULL:NULL:Fiscal|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("040100:040000:FISAPI:Fiscal.TFLanProcessarImpostos:Apuração Impostos|");
            str.Append("040800:040000:FISSPF:Fiscal.TFLanSpedFiscal:Gerar Sped Fiscal|");
            str.Append("040810:040000:FISSPC:Fiscal.TFLanSpedPisCofins:Sped PIS/COFINS|");
            str.Append("040900:040000:FISLMC:Fiscal.TFLanLivroLMC:Livro Movimentação Combustivel - LMC|");

            //MENU CADASTROS
            str.Append("045000:040000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("045100:045000:FISC01:Fiscal.Cadastros.TFCadCFOP:CFOP - Cod.Fiscal de Operação|");
            str.Append("045200:045000:FISC02:Fiscal.Cadastros.TFCadCMI:CMI - Cad.Movimentação Interna|");
            str.Append("045300:045000:FISC03:Fiscal.Cadastros.TFCadCondFiscalClifor:Condições Fiscais (CLI-FOR)|");
            str.Append("045400:045000:FISC04:Fiscal.Cadastros.TFCadCondFiscalProduto:Condições Fiscais (ITENS)|");
            str.Append("045500:045000:FISC05:Fiscal.Cadastros.TFCad_CondFiscalICMS:Parametro de ICMS|");
            str.Append("045600:045000:FISC06:Fiscal.Cadastros.TFCad_CondFiscalImpostos:Parametro de IMPOSTOS|");
            str.Append("045700:045000:FISC07:Fiscal.Cadastros.TFCadImposto:Cadastro de Impostos|");
            str.Append("045800:045000:FISC08:Fiscal.Cadastros.TFCadMov_X_CMI:Movimentação X CMI|");
            str.Append("045900:045000:FISC09:Fiscal.Cadastros.TFCadMovimentacao:Movimentação COMERCIAL|");
            str.Append("046000:045000:FISC10:Fiscal.Cadastros.TFCadMov_X_CFOP:Movimentação X CFOP|");
            str.Append("046100:045000:FISC11:Fiscal.Cadastros.TFCadObsFiscal:Observação Fiscal|");
            str.Append("046200:045000:FISC12:Fiscal.Cadastros.TFCadSitTribut:Situação Tributária|");
            str.Append("046300:045000:FISC13:Fiscal.Cadastros.TFCadTpImposto_x_SitTrib:Tipo de Imposto X Situação Tributária|");
            str.Append("046500:045000:FISC15:Fiscal.Cadastros.TFCadNCM:Nomenclatura Comum de Mercadorias (NCM)|");
            str.Append("046600:045000:FISC16:Fiscal.Cadastros.TFCadAjusteICMS:Tabela Ajuste ICMS|");
            str.Append("046700:045000:FISC17:Fiscal.Cadastros.TFCadAjusteIPI:Tabela Ajuste IPI|");
            str.Append("046800:045000:FISC18:Fiscal.Cadastros.TFCadTpBaseCalcCredito:Tipo Base Calculo Credito|");
            str.Append("046900:045000:FISC19:Fiscal.Cadastros.TFCadTpCreditoPisCofins:Tipo Credito PIS/COFINS|");
            str.Append("047000:045000:FISC20:Fiscal.Cadastros.TFCadTpContribuicaoPisCofins:Tipo Contribuição PIS/COFINS|");
            str.Append("047100:045000:FISC21:Fiscal.Cadastros.TFCadDetRecIsentaPisCofins:Natureza Credito Isento PIS/COFINS|");
            str.Append("047200:045000:FISC22:Fiscal.Cadastros.TFCadReceitaPisCofins:Receita PIS/COFINS|");
            str.Append("047300:045000:FISC23:Fiscal.Cadastros.TFCadTabelaSimples:Tabela Simples Nacional|");

            return str.ToString();
        }
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }

    }
}

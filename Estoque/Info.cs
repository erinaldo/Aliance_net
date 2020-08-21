using System;
using System.Collections.Generic;
using System.Text;

namespace Estoque
{
    public class TInfo
    {
        
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("020000:NULL:NULL:NULL:Estoque|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("020200:020000:ESTCON:Estoque.TFConsulta_Estoque:Consulta de Estoque|");
            str.Append("020300:020000:ESTINV:Estoque.TFConsultaInventario:Inventário de Itens em Estoque|");
            str.Append("020400:020000:ESTPRO:Estoque.TFConsultaProvisao:Provisão de Estoque|");
            str.Append("020500:020000:ESTPRE:Estoque.TFConsultaPrecoProduto:Consulta Preços de Venda|");
            str.Append("020700:020000:ESTTRA:Estoque.TFLan_TransfEstoque:Transferência de Local de Estoque|");
            str.Append("020800:020000:ESTTRA:Estoque.TFEtiqueta:Etiquetas |");
            str.Append("020900:020000:ESTFOR:Estoque.TFLanEstFornecedor:Estoque Fornecedor|");

            //MENU CADASTROS
            str.Append("025000:020000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("025100:025000:ESTC01:Estoque.Cadastros.TFCad_Unidade:Unidades de Medidas|");
            str.Append("025200:025000:ESTC02:Estoque.Cadastros.TFCad_LocalArm:Local de Armazenagem|");
            str.Append("025300:025000:ESTC03:Estoque.Cadastros.TFCad_LocalArm_X_Empresa:Local X Empresa|");
            str.Append("025400:025000:ESTC04:Estoque.Cadastros.TFCad_LocalArm_X_Produto:Local X Produto|");
            str.Append("025500:025000:ESTC05:Estoque.Cadastros.TFCad_Moega:Moega de Descarga|");
            
            str.Append("025600:025000:ESTC07:Estoque.Cadastros.TFCad_TpProduto:Tipo de Produto|");
            str.Append("025700:025000:ESTC08:Estoque.Cadastros.TFCadGrupoProduto:Grupo de Produto|");
            str.Append("025800:025000:ESTC09:Estoque.Cadastros.TFCad_Produto:Itens de Estoque / Consumo|");

            str.Append("026000:025000:ESTC11:Estoque.Cadastros.TFCadEmpresa_X_Moega:Empresa X Moega|");
            str.Append("026100:025000:ESTC12:Estoque.Cadastros.TFCadMoega_X_TabDesc:Moega X Tabela Desconto|");
            
            str.Append("026200:025000:ESTC13:Estoque.Cadastros.TFCadTPLanEstoque:Tipo de Lançamento de Estoque|");
            str.Append("026300:025000:ESTC14:Estoque.Cadastros.TFCad_ConvUnidade:Conversão de Unidade|");
            str.Append("026400:025000:ESTC15:Estoque.Cadastros.TFCadMarca:Cadastro de Marcas|");
            
            str.Append("026500:025000:ESTC17:Estoque.Cadastros.TFCad_TpProduto_X_Clifor:Cadastro de Tipo Produto X Clifor|");
            str.Append("026600:025000:ESTC15:Estoque.Cadastros.TFCad_TipoServico:Tipo de Servico|");
            str.Append("026700:025000:ESTC18:Estoque.Cadastros.TFCad_Genero:Cadastro de Genero de Produtos|");
            str.Append("026800:025000:ESTC19:Estoque.Cadastros.TFGradeProduto:Grade Produto|");

            str.Append("027100:025000:ESTC22:Estoque.Cadastros.TFCadMarkup:Indice Markup|");
            str.Append("027200:025000:ESTC23:Estoque.Cadastros.TFCadCodANP:Codigo ANP|");

            return str.ToString();
        }
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}

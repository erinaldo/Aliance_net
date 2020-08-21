using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almoxarifado
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
            StringBuilder str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("080000:NULL:NULL:NULL:Almoxarifado|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("080100:080000:AMXL01:Almoxarifado.TFLanMovimentacao:Movimentação Almoxarifado|");
            //MENU CADASTROS
            str.Append("085000:080000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("085100:085000:AMXC01:Almoxarifado.Cadastros.TFCadAlmoxarifado:Almoxarifado|");
            str.Append("085110:085000:AMXC02:Almoxarifado.Cadastros.TFCadAlmox_X_Empresa:Almoxarifado X Empresa|");
            str.Append("085200:085000:AMXC03:Almoxarifado.Cadastros.TFCadRua:Ruas do Almoxarifado|");
            str.Append("085300:085000:AMXC04:Almoxarifado.Cadastros.TFCadSecao:Seções do Almoxarifado|");
            str.Append("085400:085000:AMXC05:Almoxarifado.Cadastros.TFCadCelulaArm:Células do Almoxarifado|");
            str.Append("085500:085000:AMXC06:Almoxarifado.Cadastros.TFCadItens:Alocação de Itens no Almoxarifado|");

            return str.ToString();
        }

    }
}

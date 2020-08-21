using System.Text;

namespace Restaurante
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
            str.Append("240000:NULL:NULL:NULL:Restaurante|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("240100:240000:RES01:Restaurante.FPainelRestaurante:Painel Restaurante|");
            str.Append("240200:240000:RES02:Restaurante.TFLanMovBarril:Movimentação de Barris|");
            str.Append("240300:240000:RES03:Restaurante.TFReservaChopp:Reserva Chopp|");
            str.Append("240400:240000:RES04:Restaurante.TFLanExpedicaoChopp:Expedição Chopp|");

            ////MENU CADASTROS
            str.Append("245000:240000:NULL:NULL:Cadastros|");
            ////FILHOS DO MENU CADASTROS

            str.Append("245100:245000:RESC01:Restaurante.Cadastro.FCadCFG:Cadastro Cfg.|"); 
            str.Append("245200:245000:RESC02:Restaurante.Cadastro.FCartoes:Cadastro de cartões|");
            str.Append("245300:245000:RESC03:Restaurante.Cadastro.FCadLocalImpressora:Cadastro de portas impressora|");
            str.Append("245400:245000:RESC04:Restaurante.Cadastro.FCadLocal:Cadastro de Local|");
            str.Append("245500:245000:RESC05:Restaurante.Cadastro.FCadMesa:Cadastro de Mesa|");
            str.Append("245600:245000:RESC06:Restaurante.Cadastro.FProduto:Cadastro de produto|");
            str.Append("245700:245000:RESC07:Restaurante.Cadastro.FCadAdicional:Cadastro de adicional|");
            str.Append("245800:245000:RESC08:Restaurante.Cadastro.FCadSabores:Cadastro de Sabores|");
            str.Append("245900:245000:RESC09:Restaurante.Cadastro.FProtocoloBalanca:Cadastro de balanca|");
            str.Append("245901:245000:RESC10:Restaurante.Cadastro.FCadPista:Cadastro de Pista|");
            str.Append("245910:245000:RESC11:Restaurante.Cadastro.TFCadChopeira:Cadastro de Chopeiras|");

            return str.ToString();
        }

        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}

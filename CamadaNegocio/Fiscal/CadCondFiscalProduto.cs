using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;


namespace CamadaNegocio.Fiscal
{
    public class TCN_CadCondFiscalProduto
    {
        public static TList_CadCondFiscalProduto Busca(string cd_condfiscal_produto,
                                                       string ds_condfiscal_produto)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (cd_condfiscal_produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_CondFiscal_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_condfiscal_produto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (ds_condfiscal_produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_CondFiscal_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + ds_condfiscal_produto.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            return new TCD_CadCondFiscalProduto().Select(vBusca, 0, "");
        }
        
        public static string GravarCondFisProduto(TRegistro_CadCondFiscalProduto val)
        {
            TCD_CadCondFiscalProduto prod = new TCD_CadCondFiscalProduto();
            return prod.GravarFisProduto(val);
        }

        public static string DeletarCondFisProduto(TRegistro_CadCondFiscalProduto val)
        {
            TCD_CadCondFiscalProduto prod = new TCD_CadCondFiscalProduto();
            return prod.DeletarFisProduto(val);
        }
    }
}

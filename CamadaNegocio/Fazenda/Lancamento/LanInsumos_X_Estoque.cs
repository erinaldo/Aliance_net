using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Lancamento;
using Utils;

namespace CamadaNegocio.Fazenda.Lancamento
{
    public class TCN_LanInsumos_X_Estoque
    {
        public static TlistLanInsumos_X_Estoque Busca(string vCd_Empresa,
                                                      string vCd_Produto,
                                                      decimal vId_lanctoEstoque,
                                                      decimal vId_Lancto,
                                                      decimal vId_Entrega,
                                                      decimal vId_LanctoAtiv)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (vCd_Empresa !="")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Empresa + "'";
            }
            if (vCd_Produto!= "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vCd_Produto.ToString();
            }
            if (vId_lanctoEstoque > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lanctoestoque";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_lanctoEstoque.ToString();
            }
            if (vId_Lancto > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_Lancto.ToString();
            }
            if (vId_Entrega > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_entrega";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_Entrega.ToString();
            }
            if (vId_LanctoAtiv > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lanctoativ";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_LanctoAtiv.ToString();
            }

            TCD_LanInsumos_X_Estoque cd = new TCD_LanInsumos_X_Estoque();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaLanInsumos_X_Estoque(TRegistro_LanInsumos_X_Estoque val)
        {
            TCD_LanInsumos_X_Estoque cd = new TCD_LanInsumos_X_Estoque();
            return cd.GravaLanInsumos_X_Estoque(val);
        }

        public static string LanInsumos_X_Estoque(TRegistro_LanInsumos_X_Estoque val)
        {
            TCD_LanInsumos_X_Estoque cd = new TCD_LanInsumos_X_Estoque();
            return cd.DeletaLanInsumos_X_Estoque(val);
        }
    }
}

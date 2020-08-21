using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Producao.Dashboard;
using Utils;

namespace CamadaNegocio.Producao.Dashboard
{
    public class TCN_DashProduto
    {
        public static TList_DashProduto Buscar(string vCd_Empresa,
                                               string vCd_TabPreco,
                                               string vCd_Produto,
                                               string vCd_Grupo,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (string.IsNullOrEmpty(vCd_Empresa))
                throw new Exception(message: "Obrigatório informar empresa.");
            if (string.IsNullOrEmpty(vCd_TabPreco))
                throw new Exception(message: "Obrigatório informar tabela de preço.");
            if (!string.IsNullOrEmpty(vCd_Produto))
                Estruturas.CriarParametro(ref filtro, "a.cd_produto", "'" + vCd_Produto + "'");
            if (!string.IsNullOrEmpty(vCd_Grupo))
                Estruturas.CriarParametro(ref filtro, "a.cd_grupo", "'" + vCd_Grupo + "'");

            return new TCD_DashProduto(banco).Select(filtro, 0, vCd_Empresa, vCd_TabPreco);
        }
    }
}

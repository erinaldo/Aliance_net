using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Estoque
{
    public class TCN_ConsultaProdutos
    {
        public static TList_ConsultaProduto busca(string vCd_Produto)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCd_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Produto.Trim() + "'";
            }

            return new TCD_ConsultaProduto().Select(vBusca, 0, string.Empty);
        }

        public static TList_ConsultaProduto buscaLocal(string vCd_empresa,
                                                       string vCd_Produto)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa + "'";
            }
            if (!string.IsNullOrEmpty(vCd_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Produto + "'";
            }

            return new TCD_ConsultaProduto().SelectLocal(vBusca, 0, string.Empty);
        }

        public static TList_ConsultaProduto BuscarVariedade(string Cd_empresa,
                                                            string Cd_produto)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_ConsultaProduto().SelectVariedade(filtro);
        }

        public static TList_ConsultaClifor buscaClifor(string vCd_Clifor)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Clifor + "'";
            }

            return new TCD_ConsultaClifor().SelectClifor(vBusca, 0, string.Empty);
        }

        public static TList_ConsultaClifor buscaCliforContato(string vCd_Clifor)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Clifor + "'";
            }

            return new TCD_ConsultaClifor().SelectCliforContato(vBusca, 0, string.Empty);
        }
                
        public static TList_ConsultaClifor buscaCiforEndereco(string vCd_Clifor)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Clifor.Trim() + "'";
            }
            return new TCD_ConsultaClifor().SelectCliforEndereco(vBusca, 0, string.Empty);
        }

        public static TList_Pedido buscaCliforUltimosFaturamentos(string vCd_Clifor,
                                                                  int vTop,
                                                                  string vTpMovimento)
        {
            TpBusca[] vBusca = new TpBusca[2];

            vBusca[0].vNM_Campo = "a.tp_movimento";
            vBusca[0].vOperador = "=";
            vBusca[0].vVL_Busca = "'" + vTpMovimento + "'";


            vBusca[1].vNM_Campo = "";
            vBusca[1].vOperador = "exists";
            vBusca[1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Clifor + "'";
            }

            return new TCD_Pedido().Select(vBusca, vTop, string.Empty);
        }

        public static TList_LanPrecoItem buscaConsultaPreco(string vCd_Empresa, 
                                                            string vCd_produto,
                                                            string vCd_TabelaPreco,
                                                            string vDt_Preco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vCd_Empresa.Trim();
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length-1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            }
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_TabelaPreco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_TabelaPreco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDt_Preco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_preco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'"+ vDt_Preco +"'";
            }

            return new TCD_LanPrecoItem().SelectConsultaPreco(vBusca, 0, string.Empty);
        }

        public static decimal buscaCliforTotalFaturado(string vCd_Clifor)
        {
            TpBusca[] vBusca = new TpBusca[3];
            vBusca[0].vNM_Campo = "a.Tp_Movimento";
            vBusca[0].vOperador = "=";
            vBusca[0].vVL_Busca = "'S'";

            vBusca[1].vNM_Campo = "isnull(a.ST_Registro ,'A')";
            vBusca[1].vOperador = "=";
            vBusca[1].vVL_Busca = "'A'";

            vBusca[2].vNM_Campo = "";
            vBusca[2].vOperador = "exists";
            vBusca[2].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";



            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Clifor.Trim() + "'";
            }
            object vl_TotalFat = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(vBusca, "isnull(sum (a.Vl_TotalNota),0)");
            return vl_TotalFat != null ? Convert.ToDecimal(vl_TotalFat.ToString()) : 0;
        }

        public static decimal buscaCliforMaiorNota(string vCd_Clifor)
        {
            TpBusca[] vBusca = new TpBusca[3];
            vBusca[0].vNM_Campo = "a.Tp_Movimento";
            vBusca[0].vOperador = "=";
            vBusca[0].vVL_Busca = "'S'";

            vBusca[1].vNM_Campo = "isnull(a.ST_Registro ,'A')";
            vBusca[1].vOperador = "=";
            vBusca[1].vVL_Busca = "'A'";

            vBusca[2].vNM_Campo = "";
            vBusca[2].vOperador = "exists";
            vBusca[2].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";



            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'"+ vCd_Clifor + "'";
            }
            object vl_TotalFat = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(vBusca, "isnull(max (a.Vl_TotalNota),0)");
            return vl_TotalFat != null ? Convert.ToDecimal( vl_TotalFat.ToString()) : 0;
        }
    }
}


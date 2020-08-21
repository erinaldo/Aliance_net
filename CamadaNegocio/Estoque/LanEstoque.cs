using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using System.Globalization;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque
{
    public class TCN_LanEstoque
    {
        public static bool BloquearEstoqueNegativo(string vCD_Empresa, string vCD_Produto, string vCD_Local, decimal vQuantidade, ref decimal vSaldo, TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCD_Empresa) || string.IsNullOrEmpty(vCD_Produto) || string.IsNullOrEmpty(vCD_Local))
                return true;
            if (new TCD_CadProduto(banco).ItemServico(vCD_Produto) || new TCD_CadProduto(banco).ProdutoConsumoInterno(vCD_Produto))
                return false;
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GRAVAR_ESTOQUE_NEGATIVO", vCD_Empresa, banco).Equals("S"))
                return false;
            if (SaldoEstoqueLocal(vCD_Empresa, vCD_Produto, vCD_Local, ref vSaldo, banco))
                if (vQuantidade > vSaldo)
                    return true;
                else
                    return false;
            else
                return true;
        }
        
        public static bool SaldoEstoqueLocal(string vCD_Empresa, string vCD_Produto, string vCd_local, ref decimal vSaldo, TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCD_Empresa) || string.IsNullOrEmpty(vCD_Produto))
             return false;
            
            if((!new TCD_CadProduto(banco).ItemServico(vCD_Produto)) &&
                (!new TCD_CadProduto(banco).ProdutoConsumoInterno(vCD_Produto)))
            {
                TpBusca[] vBusca = new TpBusca[2];
                vBusca[0].vNM_Campo = "a.CD_Empresa";
                vBusca[0].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[0].vOperador = "=";
                
                vBusca[1].vNM_Campo = "a.CD_Produto";
                vBusca[1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[1].vOperador = "=";
                if (!string.IsNullOrEmpty(vCd_local))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_local + "'";
                    vBusca[vBusca.Length - 1].vOperador = "=";

                    object obj = new TCD_LanEstoque("SqlCodeBuscaSaldo_EstoqueLocal", banco).BuscarEscalar(vBusca, "isnull(a.tot_saldo, 0)");
                    if (obj == null)
                        return false;
                    else
                    {
                        vSaldo = Math.Round(Convert.ToDecimal(obj.ToString()), 3, MidpointRounding.AwayFromZero);
                        return true;
                    }
                }
                else
                {
                    object obj = new TCD_LanEstoque("SqlCodeBuscaSaldo_Estoque", banco).BuscarEscalar(vBusca, "isnull(a.tot_saldo, 0)");
                    if (obj == null)
                        return false;
                    else
                    {
                        vSaldo = Math.Round(Convert.ToDecimal(obj.ToString()), 3, MidpointRounding.AwayFromZero);
                        return true;
                    }
                }
            }
            else
                return false;
        }

        public static decimal Vl_MedioLocal(string vCd_empresa,
                                            string vCd_produto,
                                            string vCd_local,
                                            TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCd_empresa) ||
                string.IsNullOrEmpty(vCd_produto) ||
                string.IsNullOrEmpty(vCd_local))
                return decimal.Zero;
            object obj = new TCD_LanEstoque("SqlCodeBuscaSaldo_EstoqueLocal", banco).BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo= "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_local",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_local.Trim() + "'"
                    }
                }, "a.vl_medio");
            return obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
        }

        public static bool VlMedioEstoque(string vCd_empresa, string vCd_Produto, ref decimal vVl_medio, TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCd_empresa) ||
                string.IsNullOrEmpty(vCd_Produto))
                return false;

            object obj = new TCD_LanEstoque(banco).BuscarSaldo_EstoqueEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_Produto.Trim() + "'"
                    }
                }, "a.vl_medio");
            if (obj != null)
            {
                vVl_medio = decimal.Parse(obj.ToString());
                return true;
            }
            else
                return false;
        }

        public static bool Vl_Saldo_Estoque(string vCd_empresa, string vCd_Produto, ref decimal vVl_Saldo_Estoque, TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCd_empresa) || string.IsNullOrEmpty(vCd_Produto))
                return false;
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "a.CD_Empresa";
            filtro[0].vVL_Busca = "'" + vCd_empresa + "'";
            filtro[0].vOperador = "=";
            filtro[1].vNM_Campo = "a.CD_Produto";
            filtro[1].vVL_Busca = "'" + vCd_Produto + "'";
            filtro[1].vOperador = "=";

            System.Data.DataTable tb_estoque = new TCD_LanEstoque(banco).BuscarSaldo_Estoque(filtro, 0, "vl_saldoestoque", string.Empty);
            if (tb_estoque != null)
            {
                if (tb_estoque.Rows.Count > 0)
                {
                    try
                    {
                        vVl_Saldo_Estoque = Convert.ToDecimal(tb_estoque.Rows[0]["vl_saldoestoque"].ToString());
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool Valores_Estoque(string vCd_empresa,
                                           string vCd_Produto,
                                           ref decimal vTot_Entrada,
                                           ref decimal vTot_Saida,
                                           ref decimal vTot_Saldo,
                                           ref decimal vVL_Estoque_ent,
                                           ref decimal vVL_Estoque_sai,
                                           ref decimal vVL_SaldoEstoque,
                                           ref decimal vVL_Medio,
                                           TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCd_empresa) ||
                string.IsNullOrEmpty(vCd_Produto))
                return false;
            
            System.Data.DataTable tb_estoque = new TCD_LanEstoque(banco).BuscarSaldo_Estoque(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa", 
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + vCd_Produto.Trim() + "'"
                    }
                }, 0, string.Empty, string.Empty);
            if (tb_estoque != null)
            {
                if (tb_estoque.Rows.Count > 0)
                {
                    try
                    {
                        
                       vTot_Entrada = Convert.ToDecimal(tb_estoque.Rows[0]["tot_entrada"].ToString());
                       vTot_Saida = Convert.ToDecimal(tb_estoque.Rows[0]["tot_saida"].ToString());
                       vTot_Saldo = Convert.ToDecimal(tb_estoque.Rows[0]["tot_saldo"].ToString());
                       vVL_Estoque_ent = Convert.ToDecimal(tb_estoque.Rows[0]["vl_estoque_ent"].ToString());
                       vVL_Estoque_sai = Convert.ToDecimal(tb_estoque.Rows[0]["vl_estoque_sai"].ToString());
                       vVL_SaldoEstoque = Convert.ToDecimal(tb_estoque.Rows[0]["vl_saldoEstoque"].ToString());
                       vVL_Medio = Convert.ToDecimal(tb_estoque.Rows[0]["vl_medio"].ToString());
                       
                       return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }


        public static void Valores_EstoqueLocal(string vCd_empresa,
                                                string vCd_Produto,
                                                string vCd_local,
                                                ref decimal vTot_Entrada,
                                                ref decimal vTot_Saida,
                                                ref decimal vTot_Saldo,
                                                ref decimal vVL_Estoque_ent,
                                                ref decimal vVL_Estoque_sai,
                                                ref decimal vVL_SaldoEstoque,
                                                ref decimal vVL_Medio,
                                                TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(vCd_empresa)) &&
                (!string.IsNullOrEmpty(vCd_Produto)) &&
                (!string.IsNullOrEmpty(vCd_local)))
            {
                System.Data.DataTable tb_estoque = new TCD_LanEstoque(banco).BuscarSaldo_EstoqueLocal(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + vCd_Produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_local",
                            vOperador = "=",
                            vVL_Busca = "'" + vCd_local.Trim() + "'"
                        }
                    }, 0, string.Empty, string.Empty);
                if (tb_estoque != null)
                {
                    if (tb_estoque.Rows.Count > 0)
                    {
                        try
                        {

                            vTot_Entrada = Convert.ToDecimal(tb_estoque.Rows[0]["tot_entrada"].ToString());
                            vTot_Saida = Convert.ToDecimal(tb_estoque.Rows[0]["tot_saida"].ToString());
                            vTot_Saldo = Convert.ToDecimal(tb_estoque.Rows[0]["tot_saldo"].ToString());
                            vVL_Estoque_ent = Convert.ToDecimal(tb_estoque.Rows[0]["vl_estoque_ent"].ToString());
                            vVL_Estoque_sai = Convert.ToDecimal(tb_estoque.Rows[0]["vl_estoque_sai"].ToString());
                            vVL_SaldoEstoque = Convert.ToDecimal(tb_estoque.Rows[0]["vl_saldoEstoque"].ToString());
                            vVL_Medio = Convert.ToDecimal(tb_estoque.Rows[0]["vl_medio"].ToString());
                        }
                        catch
                        {}
                    }
                }
            }
        }
                                                

        public static TList_RegLanEstoque Busca(string vCD_Empresa,
                                                string vCD_Produto,
                                                string vCd_grupo,
                                                string vTp_produto,
                                                string vCd_marca,
                                                string vID_LanctoEstoque,
                                                string vCD_Local,
                                                string vDT_Lancto,
                                                string vTP_Movimento,
                                                string vTP_Lancto,
                                                string vDT_Inicial,
                                                string vDT_Final,
                                                string vST_Registro,
                                                string vDS_Observacao,
                                                string vID_Provisao,
                                                string vID_Variedade,
                                                Int32 vTop,
                                                string vNM_Campo,
                                                string vOrder,
                                                TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!(vCD_Empresa.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!(vCD_Produto.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCd_grupo.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.cd_grupo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_grupo.Trim() + "%'";
            }
            if (vTp_produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.tp_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_produto.Trim() + "'";
            }
            if (vCd_marca.Trim() != string.Empty)
            {
                if (vCd_grupo.Trim() != string.Empty)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "c.cd_marca";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = vCd_marca;
                }
            }
            if ((!(vID_LanctoEstoque.Trim().Equals(""))) && (!(vID_LanctoEstoque.Trim().Equals("0"))))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_LanctoEstoque";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_LanctoEstoque + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vCD_Local.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Local + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vDT_Lancto.Trim() != "") && (vDT_Lancto.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDT_Lancto).ToString("yyyyMMdd") + "'");
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vTP_Movimento + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vST_Registro + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }

            if ((vDT_Inicial.Trim() != string.Empty) && (vDT_Inicial.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDT_Inicial).ToString("yyyyMMdd") + " 00:00:00'");
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }

            if ((vDT_Final.Trim() != string.Empty) && (vDT_Final.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDT_Final).ToString("yyyyMMdd") + " 23:59:59'");
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }

            if (!(vTP_Lancto.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vTP_Lancto + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }

            if (!(vDS_Observacao.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_Observacao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vDS_Observacao + "%'";
                vBusca[vBusca.Length - 1].vOperador = "like ";
            }

            if (!(vID_Provisao.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "g.ID_Provisao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'"+vID_Provisao+"'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vID_Variedade))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_variedade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Variedade;
            }
            
            return new TCD_LanEstoque(banco).Select(vBusca, vTop, vNM_Campo, string.Empty, vOrder);
        }

        public static TList_RegLanEstoque Busca(string vCD_Empresa,
                                                string vCD_Produto,
                                                string vCd_grupo,
                                                string vTp_produto,
                                                string vCd_marca,
                                                string vID_LanctoEstoque,
                                                string vCD_Local,
                                                string vDT_Lancto,
                                                string vTP_Movimento,
                                                string vTP_Lancto,
                                                string vDT_Inicial,
                                                string vDT_Final,
                                                string vST_Registro,
                                                string vDS_Observacao,
                                                string vID_Provisao,           
                                                string vID_Variedade,
                                                Int32 vTop,
                                                string vNM_Campo,
                                                TObjetoBanco banco)
        {
            return Busca(vCD_Empresa,
                          vCD_Produto,
                          vCd_grupo,
                          vTp_produto,
                          vCd_marca,
                          vID_LanctoEstoque,
                          vCD_Local,
                          vDT_Lancto,
                          vTP_Movimento,
                          vTP_Lancto,
                          vDT_Inicial,
                          vDT_Final,
                          vST_Registro,
                          vDS_Observacao,
                          vID_Provisao,
                          vID_Variedade,
                          0,
                          vNM_Campo,
                          "a.dt_lancto, a.cd_produto",
                          banco);
        }

        public static string GravarEstoque(TRegistro_LanEstoque val, TObjetoBanco banco)
        {
            //Validar Campos obrigatorios para gravar estoque
            if (string.IsNullOrEmpty(val.Cd_empresa))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Empresa\r\n" +
                                    "Método: GravarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if(string.IsNullOrEmpty(val.Cd_produto))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Produto\r\n" +
                                    "Método: GravarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if(val.Dt_lancto.Equals(new DateTime()))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: DT_Lancto\r\n" +
                                    "Método: GravarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if(string.IsNullOrEmpty(val.Tp_movimento))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: TP_Movimento\r\n" +
                                    "Método: GravarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if (string.IsNullOrEmpty(val.Tp_lancto))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: TP_Lancto\r\n" +
                                    "Método: GravarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            bool pode_liberar = false;
            TCD_LanEstoque qtb_estoque = new TCD_LanEstoque();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_estoque.CriarBanco_Dados(true);
                else
                    qtb_estoque.Banco_Dados = banco;
                //Gravar Estoque
                string retorno = string.Empty;
                if ((!new TCD_CadProduto(qtb_estoque.Banco_Dados).ItemServico(val.Cd_produto)) &&
                    (!new TCD_CadProduto(qtb_estoque.Banco_Dados).ProdutoConsumoInterno(val.Cd_produto)))
                {
                    if (val.Tp_movimento.Trim().Equals("S"))
                    {
                        decimal saldo = 0;
                        if (BloquearEstoqueNegativo(val.Cd_empresa, val.Cd_produto, val.Cd_local, val.Qtd_saida, ref saldo, qtb_estoque.Banco_Dados))
                        {
                            throw new Exception("Saldo insuficiente para baixar estoque do produto:\r\n" +
                                            val.Cd_produto + " - " + val.Ds_produto + "\r\n" +
                                            "No local de armazenagem: " + val.Cd_local.Trim() + "-" + val.Ds_local.Trim() +"\r\n" +
                                            "Saldo Disponivel: " + saldo.ToString("### ### ##0.000") + "\r\n" +
                                            "Saldo Requerido: " + val.Qtd_saida.ToString("### ### ##0.000") + "\r\n" +
                                            "Informe o Depto Contabil para lançamento  da provisão de estoque !");
                        }
                    }
                    retorno = qtb_estoque.GravaEstoque(val);
                    val.Id_lanctoestoque = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(retorno, "@@P_ID_LANCTOESTOQUE"));
                    //Gravar Lote Anvisa
                    val.lMovLoteAnvisa.ForEach(p =>
                        {
                            p.Id_lanctoestoque = val.Id_lanctoestoque;
                            Faturamento.LoteAnvisa.TCN_MovLoteAnvisa.Gravar(p, qtb_estoque.Banco_Dados);
                        });
                    //Gravar Grade
                    val.lGrade.ForEach(p => TCN_GradeEstoque.Gravar(new TRegistro_GradeEstoque()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Cd_produto = val.Cd_produto,
                        Id_lanctoestoque = val.Id_lanctoestoque,
                        Id_caracteristica = p.Id_caracteristica,
                        Id_item = p.Id_item,
                        quantidade = p.Vl_mov
                    }, qtb_estoque.Banco_Dados));
                    if (pode_liberar)
                        qtb_estoque.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                return string.Empty;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_estoque.deletarBanco_Dados();
            }
        }

        public static string DeletarEstoque(TRegistro_LanEstoque val, TObjetoBanco banco)
        {
            if (val.Cd_empresa.Trim().Equals(""))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Empresa\r\n" +
                                    "Método: DeletarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if (val.Cd_produto.Trim().Equals(""))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Produto\r\n" +
                                    "Método: DeletarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            if(val.Id_lanctoestoque < 1)
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: ID_LanctoEstoque\r\n" +
                                    "Método: DeletarEstoque\r\n" +
                                    "Classe: TCN_LanEstoque");
            string retorno = string.Empty;
            bool pode_liberar = false;
            TCD_LanEstoque qtb_estoque = new TCD_LanEstoque();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_estoque.CriarBanco_Dados(true);
                else
                    qtb_estoque.Banco_Dados = banco;
                
                retorno = qtb_estoque.DeletaEstoque(val);
                if (pode_liberar)
                    qtb_estoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    qtb_estoque.Banco_Dados.RollBack_Tran();
                return string.Empty;
            }
            finally
            {
                if (pode_liberar)
                    qtb_estoque.deletarBanco_Dados();
            }
        }

        public static void CancelarEstoque(TRegistro_LanEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanEstoque qtb_est = new TCD_LanEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else
                    qtb_est.Banco_Dados = banco;
                qtb_est.CancelarEstoque(val);
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }

        public static decimal Busca_Saldo_Local(string vCD_Empresa, string vCD_Produto, string vCD_Local, TObjetoBanco banco)
        {
            try
            {
                TpBusca[] vBusca = new TpBusca[0];
                if (vCD_Empresa.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                }

                if (vCD_Produto.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                }

                if (vCD_Local.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Local + "'";
                }


                    System.Data.DataTable qtb_Saldo_Local = new TCD_LanEstoque(banco).BuscarSaldo_EstoqueLocal(vBusca, 0, "a.tot_saldo", string.Empty);
                    string saldo = qtb_Saldo_Local.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(saldo))
                        saldo = "0";

                    return Convert.ToDecimal(saldo);
            }
            catch
            {
                return 0;
            }
            finally
            {
            }
        }

        public static decimal BuscarVlEstoqueUltimaCompra(string Cd_empresa,
                                                          string Cd_produto,
                                                          TObjetoBanco banco)
        {
            return new TCD_LanEstoque(banco).BuscarVlEstoqueUltimaCompra(Cd_empresa, Cd_produto);
        }

        public static decimal BuscarVlUltimaCompra(string Cd_empresa, string Cd_produto, TObjetoBanco banco)
        {
            return new TCD_LanEstoque(banco).BuscarVlUltimaCompra(Cd_empresa, Cd_produto);
        }

        public static decimal Valor_Medio_Est_Produto(string vCd_empresa,
                                                      string vCd_Produto,
                                                      TObjetoBanco banco)
        {
            if ((string.IsNullOrEmpty(vCd_empresa)) || (string.IsNullOrEmpty(vCd_Produto)))
                return 0;
            object obj = new TCD_LanEstoque(banco).BuscarSaldo_EstoqueEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCd_Produto.Trim() + "'"
                                }
                            }, "a.vl_medio");
            return obj == null ? decimal.Zero : Convert.ToDecimal(obj.ToString());
        }

        public static decimal CustoTotalEstoque(string vCd_empresa, TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vCd_empresa.Trim() + ")";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            object obj = new TCD_LanEstoque(banco).BuscarEstoqueSintenticoEscalar(filtro, "ISNULL(SUM(isnull(a.tot_saldo,0) * isnull(a.vl_medio,0)), 0)");
            if (obj != null)
                try
                {
                    return Convert.ToDecimal(obj.ToString());
                }
                catch
                { return decimal.Zero; }
            else
                return decimal.Zero;
        }

        public static string AcertarVlMedio(TRegistro_LanEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanEstoque qtb_estoque = new TCD_LanEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_estoque.CriarBanco_Dados(true);
                else
                    qtb_estoque.Banco_Dados = banco;
                string retorno = qtb_estoque.AcertarVlMedio(val);
                if (st_transacao)
                    qtb_estoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro acertar valor medio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_estoque.deletarBanco_Dados();
            }
        }

        public static TList_ReservaEstoque BuscarReservaEstoque(string Cd_empresa,
                                                                string Cd_produto,
                                                                string Cd_local,
                                                                TObjetoBanco banco)
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
            if (!string.IsNullOrEmpty(Cd_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_local.Trim() + "'";
            }
            return new TCD_ReservaEstoque(banco).Select(filtro, 0, string.Empty);
        }
    }

    public class TCN_GradeEstoque
    {
        public static TList_GradeEstoque Buscar(string Cd_empresa,
                                                  string Cd_produto,
                                                  string Id_lanctoestoque,
                                                  string Id_caracteristica,
                                                  string Id_item,
                                                  int vTop,
                                                  string vNm_campo,
                                                  TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lanctoestoque.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lanctoestoque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoestoque;
            }
            if (!string.IsNullOrEmpty(Id_caracteristica.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caracteristica";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caracteristica;
            }
            if (!string.IsNullOrEmpty(Id_item.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            

            return new TCD_GradeEstoque(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_GradeEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_GradeEstoque qtb_gradeestoque = new TCD_GradeEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_gradeestoque.CriarBanco_Dados(true);
                else
                    qtb_gradeestoque.Banco_Dados = banco;
                string retorno = qtb_gradeestoque.GravarGradeEstoque(val);
                if (st_transacao)
                    qtb_gradeestoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_gradeestoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_gradeestoque.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_GradeEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_GradeEstoque qtb_gradeestoque = new TCD_GradeEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_gradeestoque.CriarBanco_Dados(true);
                else
                    qtb_gradeestoque.Banco_Dados = banco;
                qtb_gradeestoque.ExcluirGradeEstoque(val);
                if (st_transacao)
                    qtb_gradeestoque.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_gradeestoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_gradeestoque.deletarBanco_Dados();
            }
        }
    }
}

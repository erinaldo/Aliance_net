using System;
using Utils;
using CamadaDados.Estoque;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_LanPrecoItem
    {
        public static TList_LanPrecoItem Busca(string vCD_TabelaPreco,
                                                string vCD_Produto,
                                                string vDS_Produto,
                                                string vCD_Empresa,
                                                string vDT_Preco,
                                                string vCd_grupo,
                                                string vTp_produto,
                                                string vCd_marca,
                                                string vStatus,
                                                BancoDados.TObjetoBanco banco,
                                                string vDtIniVigencia = "",
                                                string vDtFinVigencia = "")
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_TabelaPreco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaPreco.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDS_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.ds_produto";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vDS_Produto.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
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
                                                      "          where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if ((vDT_Preco.Trim() != string.Empty) && (vDT_Preco.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_preco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Preco).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(vCd_grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.cd_grupo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_grupo.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(vTp_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.tp_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_marca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.cd_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vCd_marca;
            }
            if (vStatus.Trim().Equals("A") || vStatus.Trim().Equals("E"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_finvigencia, getdate()))))";
                vBusca[vBusca.Length - 1].vOperador = vStatus.Trim().Equals("A") ? ">=" : "<";
                vBusca[vBusca.Length - 1].vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))";
            }

            if (!string.IsNullOrEmpty(vDtIniVigencia) && vDtIniVigencia.SoNumero().Length.Equals(8))
                Estruturas.CriarParametro(ref vBusca, "a.dt_preco", "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDtIniVigencia).ToString("yyyyMMdd")) + " 00:00:00'", ">=");
            if (!string.IsNullOrEmpty(vDtFinVigencia) && vDtFinVigencia.SoNumero().Length.Equals(8))
                Estruturas.CriarParametro(ref vBusca, "a.dt_finvigencia", "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDtFinVigencia).ToString("yyyyMMdd")) + " 00:00:00'", "<=");

            return new TCD_LanPrecoItem(banco).Select(vBusca, 0, string.Empty);
        }

        public static void GravaItemPercentual(TList_LanPrecoItem val,
                                               decimal Pc_ajuste,
                                               decimal Pc_markup,
                                               string Tp_markup,
                                               bool St_custo,
                                               bool St_ultimacompra,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPrecoItem qtb_preco = new TCD_LanPrecoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                //Gravar itens
                val.ForEach(p =>
                    {
                        //Ajustar valor de venda
                        p.Vl_NovoPreco = Pc_ajuste > decimal.Zero ?
                             (St_custo ? p.Vl_custoreal + (p.Vl_custoreal * (Pc_ajuste / 100)) :
                             St_ultimacompra ? p.Vl_ultimacompra + (p.Vl_ultimacompra * (Pc_ajuste / 100)) :
                             p.VL_PrecoVenda + (p.VL_PrecoVenda * (Pc_ajuste / 100))) :
                             Tp_markup.Trim().ToUpper().Equals("D") ?
                             (St_custo ? p.Vl_custoreal : St_ultimacompra ? p.Vl_ultimacompra : p.VL_PrecoVenda) / Pc_markup :
                             (St_custo ? p.Vl_custoreal : St_ultimacompra ? p.Vl_ultimacompra : p.VL_PrecoVenda) * Pc_markup;
                        Grava_LanPrecoItem(p, qtb_preco.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar preço venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }

        public static void Grava_LanPrecoItem(TList_LanPrecoItem val,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPrecoItem qtb_preco = new TCD_LanPrecoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                //Gravar itens
                val.ForEach(p => Grava_LanPrecoItem(p, qtb_preco.Banco_Dados));
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar preço venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }

        public static string Grava_LanPrecoItem(TRegistro_LanPrecoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPrecoItem cd = new TCD_LanPrecoItem();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Deleta_LanPrecoItem(TRegistro_LanPrecoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPrecoItem cd = new TCD_LanPrecoItem();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static decimal Busca_ConsultaPreco(string vCD_Empresa, string vCD_Produto, string vCD_TabelaPreco, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_TabelaPreco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaPreco.Trim() + "'";
            }

            object obj_ConsultaPreco = new TCD_LanPrecoItem("SqlCodeBusca_ConsultaPreco", banco).BuscarEscalar(vBusca, "a.Vl_PrecoVenda");
            return obj_ConsultaPreco == null ? decimal.Zero : Convert.ToDecimal(obj_ConsultaPreco.ToString());
        }

        public static decimal BuscarUltimaCompra(string Cd_empresa, string Cd_produto, BancoDados.TObjetoBanco banco)
        {
            TCD_LanPrecoItem qtb_preco = new TCD_LanPrecoItem(banco);
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", Cd_empresa);
            hs.Add("@P_CD_PRODUTO", Cd_produto);
            string retorno = CamadaDados.TDataQuery.getPubVariavel(qtb_preco.executarProc("F_FAT_ULTIMACOMPRA", hs), "@RETURN_VALUE");
            return string.IsNullOrEmpty(retorno) ? decimal.Zero : decimal.Parse(retorno);
        }
    }
}

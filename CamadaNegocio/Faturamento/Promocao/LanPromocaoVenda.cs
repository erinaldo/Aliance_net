using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Promocao;

namespace CamadaNegocio.Faturamento.Promocao
{
    #region Promocao Venda
    public class TCN_PromocaoVenda
    {
        public static TList_PromocaoVenda Buscar(string Id_promocao,
                                                 string Cd_empresa,
                                                 string Ds_promocao,
                                                 string Cd_grupo,
                                                 string Cd_produto,
                                                 string Tp_data,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 string St_registro,
                                                 bool St_expirado,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_promocao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_promocao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_promocao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_promocao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_promocao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_promocao.Trim() + "%')";
            }
            if(!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_promocao_x_grupo x " +
                                                      "where x.id_promocao = a.id_promocao " +
                                                      "and x.cd_grupo = '" + Cd_grupo.Trim() + "')";
            }
            if(!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_promocao_x_grupo x " +
                                                      "where x.id_promocao = a.id_promocao " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (Dt_ini.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("I") ?
                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_ini)))" :
                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_fin)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (Dt_fin.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("I") ?
                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_ini)))" :
                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_fin)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_expirado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_fin";
                filtro[filtro.Length - 1].vOperador = "<";
                filtro[filtro.Length - 1].vVL_Busca = "getDate()";
            }
            return new TCD_PromocaoVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PromocaoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PromocaoVenda qtb_promocao = new TCD_PromocaoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_promocao.CriarBanco_Dados(true);
                else
                    qtb_promocao.Banco_Dados = banco;
                val.Id_promocaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_promocao.Gravar(val), "@P_ID_PROMOCAO");
                //Excluir Grupos
                val.lGrupoDel.ForEach(p => TCN_Promocao_X_Grupo.Excluir(p, qtb_promocao.Banco_Dados));
                //Gravar Grupos
                val.lGrupo.ForEach(p =>
                    {
                        p.Id_promocao = val.Id_promocao;
                        TCN_Promocao_X_Grupo.Gravar(p, qtb_promocao.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_promocao.Banco_Dados.Commit_Tran();
                return val.Id_promocaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_promocao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar promocao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_promocao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PromocaoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PromocaoVenda qtb_promocao = new TCD_PromocaoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_promocao.CriarBanco_Dados(true);
                else
                    qtb_promocao.Banco_Dados = banco;
                val.lGrupo.ForEach(p=> TCN_Promocao_X_Grupo.Excluir(p, qtb_promocao.Banco_Dados));
                val.lGrupoDel.ForEach(p => TCN_Promocao_X_Grupo.Excluir(p, qtb_promocao.Banco_Dados));
                qtb_promocao.Excluir(val);
                if(st_transacao)
                    qtb_promocao.Banco_Dados.Commit_Tran();
                return val.Id_promocaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_promocao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir promocao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_promocao.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Promocao X Grupo
    public class TCN_Promocao_X_Grupo
    {
        public static TList_Promocao_X_Grupo Buscar(string Id_promocao,
                                                    string Cd_grupo,
                                                    string Cd_produto,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_promocao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_promocao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_promocao;
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_Promocao_X_Grupo(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static TRegistro_Promocao_X_Grupo BuscarPromocaoGrupo(string Cd_empresa,
                                                                     string Cd_produto,
                                                                     string Cd_grupo,
                                                                     CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg,
                                                                     decimal Vl_total,
                                                                     BancoDados.TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(Cd_grupo)) && (!string.IsNullOrEmpty(Cd_empresa)))
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                
                if (Cd_grupo.Trim().Length.Equals(2))
                {
                    filtro[0].vNM_Campo = string.Empty;
                    filtro[0].vOperador = string.Empty;
                    filtro[0].vVL_Busca = "(a.cd_grupo = '" + Cd_grupo.Trim() + "') or (a.cd_produto = '" + Cd_produto.Trim() + "'";
                }
                else if (Cd_grupo.Trim().Length.Equals(4))
                {
                    filtro[0].vNM_Campo = string.Empty;
                    filtro[0].vOperador = string.Empty;
                    filtro[0].vVL_Busca = "(a.cd_grupo = '" + Cd_grupo.Trim() + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 2) + "') or " +
                                          "(a.cd_produto = '" + Cd_produto.Trim() + "')";
                }
                else if (Cd_grupo.Trim().Length.Equals(6))
                {
                    filtro[0].vNM_Campo = string.Empty;
                    filtro[0].vOperador = string.Empty;
                    filtro[0].vVL_Busca = "(a.cd_grupo = '" + Cd_grupo.Trim() + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 2) + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 4) + "') or " +
                                          "(a.cd_produto = '" + Cd_produto.Trim() + "')";
                }
                else if (Cd_grupo.Trim().Length.Equals(8))
                {
                    filtro[0].vNM_Campo = string.Empty;
                    filtro[0].vOperador = string.Empty;
                    filtro[0].vVL_Busca = "(a.cd_grupo = '" + Cd_grupo.Trim() + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 2) + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 4) + "') or " +
                                          "(a.cd_grupo = '" + Cd_grupo.Trim().Substring(0, 6) + "') or " +
                                          "(a.cd_produto = '" + Cd_produto.Trim() + "')";
                }
                //Empresa
                filtro[1].vNM_Campo = "b.cd_empresa";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                //Status
                filtro[2].vNM_Campo = "isnull(b.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'F'";
                //Vigente
                filtro[3].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),getdate())))";
                filtro[3].vOperador = "between";
                filtro[3].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.dt_ini))) and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.dt_fin)))";

                TList_Promocao_X_Grupo lGrupo = new TCD_Promocao_X_Grupo(banco).Select(filtro, 1, string.Empty, "a.cd_produto desc, a.cd_grupo desc");
                if (lGrupo.Count > 0)
                {
                    if (rProg != null)
                    {
                        if ((lGrupo[0].Tp_promocao.ToUpper().Equals("V") && rProg.Tp_valor.ToUpper().Equals("V")) ||
                            (lGrupo[0].Tp_promocao.ToUpper().Equals("P") && rProg.Tp_valor.ToUpper().Equals("P")))
                        {
                            if (lGrupo[0].Vl_promocao > rProg.Valor)
                                return lGrupo[0];
                            else
                                return null;
                        }
                        else if ((lGrupo[0].Tp_promocao.ToUpper().Equals("P") && rProg.Tp_valor.ToUpper().Equals("V")))
                        {
                            if ((Vl_total * (lGrupo[0].Vl_promocao / 100) > rProg.Valor))
                                return lGrupo[0];
                            else
                                return null;
                        }
                        else if ((lGrupo[0].Tp_promocao.ToUpper().Equals("P") && rProg.Tp_valor.ToUpper().Equals("V")))
                        {
                            if ((lGrupo[0].Vl_promocao > (Vl_total * (rProg.Valor / 100))))
                                return lGrupo[0];
                            else
                                return null;
                        }
                        else
                            return lGrupo[0];
                    }
                    else
                        return lGrupo[0];
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static string Gravar(TRegistro_Promocao_X_Grupo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Promocao_X_Grupo qtb_promocao = new TCD_Promocao_X_Grupo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_promocao.CriarBanco_Dados(true);
                else
                    qtb_promocao.Banco_Dados = banco;
                string retorno = qtb_promocao.Gravar(val);
                if (st_transacao)
                    qtb_promocao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_promocao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item promoção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_promocao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Promocao_X_Grupo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Promocao_X_Grupo qtb_promocao = new TCD_Promocao_X_Grupo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_promocao.CriarBanco_Dados(true);
                else
                    qtb_promocao.Banco_Dados = banco;
                qtb_promocao.Excluir(val);
                if (st_transacao)
                    qtb_promocao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_promocao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item promoção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_promocao.deletarBanco_Dados();
            }
        }
    }
    #endregion
}

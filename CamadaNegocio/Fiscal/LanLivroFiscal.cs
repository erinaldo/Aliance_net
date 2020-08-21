using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_LivroFiscal
    {
        public static TList_LivroFiscal Buscar(string Cd_empresa,
                                               string Nr_lanctofiscal,
                                               string Nr_notafiscal,
                                               string Nr_serie,
                                               string Tp_movimento,
                                               string Cd_cfop,
                                               string Nr_serieexcluir,
                                               string Tp_data,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string vOrder,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vOperador = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Nr_notafiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_notafiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_notafiscal.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cfop))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cfop";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Cd_cfop.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_serieexcluir))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.nr_serie not in(" + Nr_serieexcluir.Trim() + ") or a.tp_nota = 'T')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_saient";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_saient";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            return new TCD_LivroFiscal(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static TList_LivroFiscal BuscarFatLivro(string Cd_empresa,
                                                       string Nr_lanctofiscal,
                                                       string Especie,
                                                       BancoDados.TObjetoBanco banco)
        {
            return new TCD_LivroFiscal(banco).SelectFatLivro(new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.nr_lanctofiscal",
                        vOperador = "=",
                        vVL_Busca = Nr_lanctofiscal
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.especie",
                        vOperador = "=",
                        vVL_Busca = string.IsNullOrEmpty(Especie) ? "a.especie" : "'" + Especie.Trim().ToUpper() + "'" 
                    }
                });
        }

        public static void ProcessarLivroFiscal(TList_LivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LivroFiscal qtb_livro = new TCD_LivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                val.ForEach(p => Gravar(p, qtb_livro.Banco_Dados));
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if(banco == null)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Processar Livro Fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }

        public static void ReprocessarLivroFiscal(string Cd_empresa,
                                                  string Tp_movimento,
                                                  string Cd_cfop,
                                                  string Nr_serieexcluir,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  BancoDados.TObjetoBanco banco)
        {
            //Montas parametros da busca
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Cd_cfop))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cfop";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Cd_cfop.Trim() + ")";
            }
            if(!string.IsNullOrEmpty(Nr_serieexcluir))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.nr_serie not in(" + Nr_serieexcluir.Trim() + ") or a.tp_nota = 'T')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_movimento.Trim().ToUpper().Equals("E") ? "a.dt_saient" : "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_movimento.Trim().ToUpper().Equals("E") ? "a.dt_saient" : "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            bool st_transacao = false;
            TCD_LivroFiscal qtb_livro = new TCD_LivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                //Buscar lista de registros fiscais para Reprocessar
                new TCD_LivroFiscal(qtb_livro.Banco_Dados).SelectFatLivro(filtro).ForEach(p =>
                    ReprocessarLivroFiscal(p.Cd_empresa,
                                           p.Nr_lanctofiscal,
                                           p.Especie,
                                           TCN_LivroFiscal.BuscarFatLivro(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), p.Especie, qtb_livro.Banco_Dados),
                                           qtb_livro.Banco_Dados));
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Reprocessar livro fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }

        public static void ReprocessarLivroFiscal(string Cd_empresa,
                                                  decimal Nr_lanctofiscal,
                                                  string Tp_registro,
                                                  TList_LivroFiscal val,
                                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LivroFiscal qtb_livro = new TCD_LivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                //Excluir livro fiscal do conhecimento frete
                if (Tp_registro.Trim().ToUpper().Equals("CTRC"))
                {
                    CamadaDados.Faturamento.CTRC.TList_CTRLivroFiscal lLivro =
                    CamadaNegocio.Faturamento.CTRC.TCN_CTRLivroFiscal.Buscar(Cd_empresa,
                                                                             Nr_lanctofiscal.ToString(),
                                                                             string.Empty,
                                                                             0,
                                                                             string.Empty,
                                                                             qtb_livro.Banco_Dados);
                    lLivro.ForEach(p =>
                        {
                            //Excluir Ctr Livro
                            CamadaNegocio.Faturamento.CTRC.TCN_CTRLivroFiscal.Excluir(p, qtb_livro.Banco_Dados);
                            //Excluir Livro Fiscal
                            qtb_livro.Excluir(new TRegistro_LivroFiscal()
                            {
                                Id_livro = p.Id_livro
                            });
                        });
                }//Excluir livro fiscal da nota fiscal
                else if(Tp_registro.Trim().ToUpper().Equals("NFF"))
                {
                    CamadaDados.Faturamento.NotaFiscal.TList_FATLivroFiscal lLivro =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_FATLivroFiscal.Buscar(Cd_empresa,
                                                                                       Nr_lanctofiscal.ToString(),
                                                                                       string.Empty,
                                                                                       qtb_livro.Banco_Dados);
                    lLivro.ForEach(p =>
                        {
                            //Excluir FAT Livro
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_FATLivroFiscal.Excluir(p, qtb_livro.Banco_Dados);
                            //Excluir Livro Fiscal
                            qtb_livro.Excluir(new TRegistro_LivroFiscal()
                            {
                                Id_livro = p.Id_livro
                            });
                        });
                }
                else if (Tp_registro.Trim().ToUpper().Equals("ECF"))
                {
                    CamadaDados.Faturamento.PDV.TList_LivroFiscal lLivro =
                        CamadaNegocio.Faturamento.PDV.TCN_LivroFiscal.Buscar(string.Empty,
                                                                             Nr_lanctofiscal.ToString(),
                                                                             Cd_empresa,
                                                                             qtb_livro.Banco_Dados);
                    lLivro.ForEach(p =>
                        {
                            //Excluir ECF Livro
                            CamadaNegocio.Faturamento.PDV.TCN_LivroFiscal.Excluir(p, qtb_livro.Banco_Dados);
                            //Excluir livro fiscal
                            qtb_livro.Excluir(new TRegistro_LivroFiscal()
                            {
                                Id_livro = p.Id_livro
                            });
                        });
                }
                //Processar Livro Fiscal
                ProcessarLivroFiscal(val, qtb_livro.Banco_Dados);
                val.ForEach(p => 
                    {
                        if (Tp_registro.Trim().ToUpper().Equals("CTRC"))
                            CamadaNegocio.Faturamento.CTRC.TCN_CTRLivroFiscal.Gravar(
                            new CamadaDados.Faturamento.CTRC.TRegistro_CTRLivroFiscal()
                            {
                                Cd_empresa = Cd_empresa,
                                Nr_lanctoctr = Nr_lanctofiscal,
                                Id_livro = p.Id_livro
                            }, qtb_livro.Banco_Dados);
                        else if (Tp_registro.Trim().ToUpper().Equals("NFF"))
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_FATLivroFiscal.Gravar(
                                new CamadaDados.Faturamento.NotaFiscal.TRegistro_FATLivroFiscal()
                                {
                                    Cd_empresa = Cd_empresa,
                                    Nr_lanctofiscal = Nr_lanctofiscal,
                                    Id_livro = p.Id_livro
                                }, qtb_livro.Banco_Dados);
                        else if (Tp_registro.Trim().ToUpper().Equals("ECF"))
                            CamadaNegocio.Faturamento.PDV.TCN_LivroFiscal.Gravar(
                                new CamadaDados.Faturamento.PDV.TRegistro_LivroFiscal()
                                {
                                    Cd_empresa = Cd_empresa,
                                    Id_cupom = Nr_lanctofiscal,
                                    Id_livro = p.Id_livro
                                }, qtb_livro.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprocessar livro fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_LivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LivroFiscal qtb_livro = new TCD_LivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                val.Id_livro = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_livro.Gravar(val), "@P_ID_LIVRO"));
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
                return val.Id_livro.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar livro fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LivroFiscal qtb_livro = new TCD_LivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                qtb_livro.Excluir(val);
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir livro fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }
    }
}

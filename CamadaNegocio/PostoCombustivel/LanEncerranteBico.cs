using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_EncerranteBico
    {
        public static TList_EncerranteBico Buscar(string Id_encerrante,
                                                  string Id_bico,
                                                  string Cd_combustivel,
                                                  string Tp_encerrante,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_encerrante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_encerrante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_encerrante;
            }
            if (!string.IsNullOrEmpty(Id_bico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bico;
            }
            if (!string.IsNullOrEmpty(Cd_combustivel))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_combustivel.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_encerrante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_encerrante";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_encerrante.Trim() + ")";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_encerrante";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_encerrante";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }

            return new TCD_EncerranteBico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EncerranteBico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EncerranteBico qtb_enc = new TCD_EncerranteBico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else
                    qtb_enc.Banco_Dados = banco;
                if (val.Qtd_encerrante.Equals(decimal.Zero))
                    if (new CamadaDados.PostoCombustivel.TCD_EncerranteBico(qtb_enc.Banco_Dados).BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_bico",
                                vOperador = "=",
                                vVL_Busca = val.Id_bicostr
                            }
                        }, "1") != null)
                        throw new Exception("Bico " + val.Id_bicostr + " ja possui encerrante gravado com quantidade maior que zero.\r\n" +
                                            "Não é permitido gravar valor zero para o encerrante deste bico.");
                val.Id_encerrantestr = CamadaDados.TDataQuery.getPubVariavel(qtb_enc.Gravar(val), "@P_ID_ENCERRANTE");
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return val.Id_encerrantestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar encerrante: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EncerranteBico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EncerranteBico qtb_enc = new TCD_EncerranteBico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else
                    qtb_enc.Banco_Dados = banco;
                qtb_enc.Excluir(val);
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir encerrante: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }

        public static void ProcessarEncerrante(List<CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba> lBico, 
                                               string Cd_empresa,
                                               string Tp_encerrante,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EncerranteBico qtb_enc = new TCD_EncerranteBico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else
                    qtb_enc.Banco_Dados = banco;
                
                lBico.ForEach(p =>
                    {
                        object obj = new TCD_EncerranteBico(qtb_enc.Banco_Dados).BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.id_bico",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_bicostr
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_encerrante",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Tp_encerrante.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.dt_encerrante",
                                                vOperador = "between",
                                                vVL_Busca = "'" + (Tp_encerrante.Equals("A") ? CamadaDados.UtilData.Data_Servidor(qtb_enc.Banco_Dados).ToString("dd/MM/yyyy") :
                                                                           CamadaDados.UtilData.Data_Servidor(qtb_enc.Banco_Dados).AddDays(-1).ToString("dd/MM/yyyy")) + "' and '" +
                                                                  (Tp_encerrante.Equals("A") ? CamadaDados.UtilData.Data_Servidor(qtb_enc.Banco_Dados).ToString("dd/MM/yyyy") + " 23:59:59'" :
                                                                           CamadaDados.UtilData.Data_Servidor(qtb_enc.Banco_Dados).AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59'")
                                            }
                                        }, "a.id_encerrante");
                            Gravar(new TRegistro_EncerranteBico()
                            {
                                Id_encerrantestr = obj == null ? string.Empty : obj.ToString(),
                                Id_bico = p.Id_bico,
                                Dt_encerrante = CamadaDados.UtilData.Data_Servidor(qtb_enc.Banco_Dados),
                                Tp_encerrante = Tp_encerrante,
                                Qtd_encerrante = p.Qtd_encerrante
                            }, qtb_enc.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar encerrante bico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }
    }
}

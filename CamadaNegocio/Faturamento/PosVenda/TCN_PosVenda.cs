using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados.Faturamento.PosVenda;
using Utils;

namespace CamadaNegocio.Faturamento.PosVenda
{
    public class TCN_PosVenda
    {
        #region PosVenda
        public static TList_PosVenda Buscar(string CD_Empresa,
                                            string ID_PosVenda,
                                            string Login,
                                            string CD_Clifor,
                                            string ID_Questionario,
                                            string DT_Abertura,
                                            string DT_Encerramento,
                                            string ST_Registro,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
                Estruturas.CriarParametro(ref tpBusca, "a.cd_empresa", "'" + CD_Empresa + "'");
            if (!string.IsNullOrEmpty(ID_PosVenda))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_PosVenda", "'" + ID_PosVenda + "'");
            if (!string.IsNullOrEmpty(Login))
                Estruturas.CriarParametro(ref tpBusca, "a.Login", "'" + Login + "'");
            if (!string.IsNullOrEmpty(CD_Clifor))
                Estruturas.CriarParametro(ref tpBusca, "a.CD_Clifor", "'" + CD_Clifor + "'");
            if (!string.IsNullOrEmpty(ID_Questionario))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_Questionario", "'" + ID_Questionario + "'");

            if ((!string.IsNullOrEmpty(DT_Abertura)) && (DT_Abertura.Trim() != "/  /"))
            {
                Array.Resize(ref tpBusca, tpBusca.Length + 1);
                tpBusca[tpBusca.Length - 1].vNM_Campo = "a.DT_Abertura";
                tpBusca[tpBusca.Length - 1].vOperador = ">=";
                tpBusca[tpBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Abertura).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(DT_Encerramento)) && (DT_Encerramento.Trim() != "/  /"))
            {
                Array.Resize(ref tpBusca, tpBusca.Length + 1);
                tpBusca[tpBusca.Length - 1].vNM_Campo = "a.DT_Encerramento";
                tpBusca[tpBusca.Length - 1].vOperador = "<=";
                tpBusca[tpBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Encerramento).ToString("yyyyMMdd")) + " 00:00:00'";
            }

            if (!string.IsNullOrEmpty(ST_Registro))
                Estruturas.CriarParametro(ref tpBusca, "a.ST_Registro", "(" + ST_Registro + ")", "in");


            return new TCD_PosVenda(banco).Select(tpBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PosVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVenda qtb = new TCD_PosVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                if (string.IsNullOrEmpty(val.Cd_empresa))
                    throw new Exception("Obrigatório informar empresa.");
                else if (string.IsNullOrEmpty(val.Login))
                    throw new Exception("Obrigatório informar login.");
                else if (string.IsNullOrEmpty(val.Cd_clifor))
                    throw new Exception("Obrigatório informar cliente.");

                val.St_registro = "A";
                val.Id_posvendastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_POSVENDA");

                val.DelEventoPosVenda.ForEach(d => TCN_PosVenda.Excluir(d, qtb.Banco_Dados));
                val.lEventoPosVenda.ForEach(r =>
                {
                    r.Id_posvendastr = val.Id_posvendastr;
                    TCN_PosVenda.Gravar(r, qtb.Banco_Dados);
                });

                val.DelPosVendaQuestionario.ForEach(d => TCN_PosVenda.Excluir(d, qtb.Banco_Dados));
                val.lPosVendaQuestionario.ForEach(r =>
                {
                    r.Id_posvendastr = val.Id_posvendastr;
                    TCN_PosVenda.Gravar(r, qtb.Banco_Dados);
                });

                if (val.lOrcamento != null)
                    val.lOrcamento.ToList().ForEach(r =>
                    {
                        TCN_PosVenda.Gravar(
                            new TRegistro_PosVenda_X_Proposta()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Id_posvendastr = val.Id_posvendastr,
                                Nr_orcamentostr = r.Nr_orcamentostr
                            }, qtb.Banco_Dados);
                    });

                if (val.lPosVendaProposta != null)
                    val.lPosVendaProposta.ForEach(r =>
                    {
                        TCN_PosVenda.Gravar(r, qtb.Banco_Dados);
                    });

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar a pós-venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PosVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVenda qtb = new TCD_PosVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                val.St_registro = "C";

                qtb.Gravar(val);

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir pós-venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Encerrar(TRegistro_PosVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVenda qtb = new TCD_PosVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                val.St_registro = "E";
                val.Dt_encerramento = CamadaDados.UtilData.Data_Servidor();
                qtb.Gravar(val);

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir pós-venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
        #endregion

        #region PosVenda_x_Proposta
        public static TList_PosVenda_X_Proposta Buscar(string CD_Empresa,
                                                       string ID_PosVenda,
                                                       string Nr_Orcamento,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
                Estruturas.CriarParametro(ref tpBusca, "a.CD_Empresa", "'" + CD_Empresa + "'");
            if (!string.IsNullOrEmpty(ID_PosVenda))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_PosVenda", "'" + ID_PosVenda + "'");
            if (!string.IsNullOrEmpty(Nr_Orcamento))
                Estruturas.CriarParametro(ref tpBusca, "a.Nr_Orcamento", "'" + Nr_Orcamento + "'");

            return new TCD_PosVenda_X_Proposta(banco).Select(tpBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PosVenda_X_Proposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVenda_X_Proposta qtb = new TCD_PosVenda_X_Proposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                if (string.IsNullOrEmpty(val.Cd_empresa))
                    throw new Exception("Obrigatório informar empresa.");
                else if (string.IsNullOrEmpty(val.Nr_orcamentostr))
                    throw new Exception("Obrigatório informar número de orçamento/ proposta.");

                val.Id_posvendastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_POSVENDA");

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar a pós-venda x proposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PosVenda_X_Proposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVenda_X_Proposta qtb = new TCD_PosVenda_X_Proposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                qtb.Excluir(val);

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir pós-venda x proposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
        #endregion

        #region EventoPosVenda
        public static TList_EventoPosVenda Buscar(string CD_Empresa,
                                                  string ID_PosVenda,
                                                  string ID_Evento,
                                                  string Login,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
                Estruturas.CriarParametro(ref tpBusca, "a.CD_Empresa", "'" + CD_Empresa + "'");
            if (!string.IsNullOrEmpty(ID_PosVenda))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_PosVenda", "'" + ID_PosVenda + "'");
            if (!string.IsNullOrEmpty(ID_Evento))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_Evento", "'" + ID_Evento + "'");
            if (!string.IsNullOrEmpty(Login))
                Estruturas.CriarParametro(ref tpBusca, "a.Login", "'" + Login + "'");


            return new TCD_EventoPosVenda(banco).Select(tpBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EventoPosVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoPosVenda qtb = new TCD_EventoPosVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                if (string.IsNullOrEmpty(val.Cd_empresa))
                    throw new Exception("Obrigatório informar empresa.");
                else if (string.IsNullOrEmpty(val.Id_posvendastr))
                    throw new Exception("Obrigatório informar número de pós-venda.");

                val.Id_posvendastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_POSVENDA");

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar a pós-venda x proposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EventoPosVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoPosVenda qtb = new TCD_EventoPosVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                qtb.Excluir(val);

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir evento pós-venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
        #endregion

        #region PosVendaQuestionario
        public static TList_PosVendaQuestionario Busca(string CD_Empresa,
                                                        string ID_PosVenda,
                                                        string ID_Pergunta,
                                                        string ID_Resposta,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
                Estruturas.CriarParametro(ref tpBusca, "a.cd_empresa", "'" + CD_Empresa + "'");
            if (!string.IsNullOrEmpty(ID_PosVenda))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_PosVenda", "'" + ID_PosVenda + "'");
            if (!string.IsNullOrEmpty(ID_Pergunta))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_Pergunta", "'" + ID_Pergunta + "'");
            if (!string.IsNullOrEmpty(ID_Resposta))
                Estruturas.CriarParametro(ref tpBusca, "a.ID_Resposta", "'" + ID_Resposta + "'");

            return new TCD_PosVendaQuestionario(banco).Select(tpBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PosVendaQuestionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVendaQuestionario qtb = new TCD_PosVendaQuestionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                if (string.IsNullOrEmpty(val.Cd_empresa))
                    throw new Exception("Obrigatório informar empresa.");
                else if (string.IsNullOrEmpty(val.Id_posvendastr))
                    throw new Exception("Obrigatório informar pós-venda.");
                else if (string.IsNullOrEmpty(val.Id_perguntastr))
                    throw new Exception("Obrigatório informar pergunta.");
                else if (string.IsNullOrEmpty(val.Id_respostastr))
                    throw new Exception("Obrigatório informar resposta.");
                //else if (string.IsNullOrEmpty(val.Id_questionario))
                //    throw new Exception("Obrigatório informar questionário.");

                ////Buscar a pós-venda e valido existencia de questionário cadastrado
                //TRegistro_PosVenda _PosVenda = TCN_PosVenda.Buscar(val.Cd_empresa, val.Id_posvendastr, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)[0];
                //if (!string.IsNullOrEmpty(_PosVenda.Id_questionariostr) && !_PosVenda.Id_questionariostr.Equals(val.Id_questionario))
                //    throw new Exception("A pós-venda informada possui o questionário de Id. " + _PosVenda.Id_questionariostr + 
                //        ", não é possível adicionar perguntas e respostas de outros questionários. Questionário diferente selecionado Id. " + val.Id_questionario);

                val.Id_posvendastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_POSVENDA");

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar a pós-venda x questionário: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PosVendaQuestionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PosVendaQuestionario qtb = new TCD_PosVendaQuestionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                qtb.Excluir(val);

                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_posvendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir pós-venda x questionário: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
        #endregion
    }
}

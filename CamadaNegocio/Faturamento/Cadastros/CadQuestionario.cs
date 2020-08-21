using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados.Faturamento.Cadastros;
using Utils;

namespace CamadaNegocio.Faturamento.Cadastros
{
    #region Questionario
    public class TCN_CadQuestionario
    {
        public static TList_Questionario Buscar(string Id_questionario,
                                                string Ds_questionario,
                                                BancoDados.TObjetoBanco banco,
                                                string Cancelado = "")
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_questionario))
                Estruturas.CriarParametro(ref tpBuscas, "a.id_questionario", "'" + Id_questionario + "'");
            if (!string.IsNullOrEmpty(Ds_questionario))
                Estruturas.CriarParametro(ref tpBuscas, "a.ds_questionario", "'" + Ds_questionario + "'");
            if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("1"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'1'");
            else if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("0"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'0'");

            return new TCD_Questionario(banco).Select(tpBuscas, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Questionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Questionario qtb = new TCD_Questionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                val.Id_questionariostr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_QUESTIONARIO");
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_questionariostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Questionário: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Questionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Questionario qtb = new TCD_Questionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                //Validar existencia de perguntas no questionario
                TpBusca[] tp = new TpBusca[0];
                Estruturas.CriarParametro(ref tp, "a.id_questionario", "'" + val.Id_questionariostr + "'");
                if (new TCD_Questionario_X_Pergunta().BuscarEscalar(tp, "1") != null)
                {
                    throw new Exception("Não será possível excluir o questionário, pois possui perguntas.");
                }

                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_questionariostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir questionário: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Questionario X Pergunta
    public class TCN_Questionario_X_Pergunta
    {
        public static TList_Questionario_X_Pergunta Buscar(string Id_questionario,
                                                           string Id_pergunta,
                                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_questionario))
                Estruturas.CriarParametro(ref tpBuscas, "a.id_questionario", "'" + Id_questionario + "'");
            if (!string.IsNullOrEmpty(Id_pergunta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Id_pergunta", "'" + Id_pergunta + "'");

            return new TCD_Questionario_X_Pergunta(banco).Select(tpBuscas, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Questionario_X_Pergunta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Questionario_X_Pergunta qtb = new TCD_Questionario_X_Pergunta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                qtb.Gravar(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_questionariostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Questionário x Pergunta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Questionario_X_Pergunta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Questionario_X_Pergunta qtb = new TCD_Questionario_X_Pergunta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                //Validar existencia de resposta
                TpBusca[] tp = new TpBusca[0];
                Estruturas.CriarParametro(ref tp, "a.id_pergunta", "'" + val.Id_perguntastr + "'");
                if (new TCD_Pergunta_X_Resposta().BuscarEscalar(tp, "1") != null)
                {
                    throw new Exception("Não será possível excluir a pergunta, pois possui respostas relacionadas.");
                }

                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_questionariostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir questionário x pergunta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Pergunta
    public class TCN_Pergunta
    {
        public static TList_Pergunta Buscar(string Id_pergunta,
                                            string Ds_pergunta,
                                            BancoDados.TObjetoBanco banco,
                                            string Cancelado = "")
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_pergunta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Id_pergunta", "'" + Id_pergunta + "'");
            if (!string.IsNullOrEmpty(Ds_pergunta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Ds_pergunta", "'" + Ds_pergunta + "'");
            if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("1"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'1'");
            else if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("0"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'0'");

            return new TCD_Pergunta(banco).Select(tpBuscas, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Pergunta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pergunta qtb = new TCD_Pergunta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                val.Id_perguntastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_PERGUNTA");
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_perguntastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Pergunta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pergunta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pergunta qtb = new TCD_Pergunta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                //Validar se pergunta está sendo utilizada
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.id_pergunta", "'" + val.Id_perguntastr + "'");
                if (new TCD_Questionario_X_Pergunta().BuscarEscalar(tpBuscas, "1") != null)
                    throw new Exception("Está pergunta está sendo utilizada, não será possível excluir.");

                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_perguntastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir a pergunta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Resposta
    public class TCN_Resposta
    {
        public static TList_Resposta Buscar(string Id_resposta,
                                            string Ds_resposta,
                                            BancoDados.TObjetoBanco banco,
                                            string Cancelado = "")
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_resposta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Id_pergunta", "'" + Id_resposta + "'");
            if (!string.IsNullOrEmpty(Ds_resposta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Ds_resposta", "'" + Ds_resposta + "'");
            if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("1"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'1'");
            else if (!string.IsNullOrEmpty(Cancelado) && Cancelado.Equals("0"))
                Estruturas.CriarParametro(ref tpBuscas, "a.cancelado", "'0'");

            return new TCD_Resposta(banco).Select(tpBuscas, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Resposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Resposta qtb = new TCD_Resposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                val.Id_respostastr = CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_RESPOSTA");
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_respostastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Resposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Resposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Resposta qtb = new TCD_Resposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;

                //Validar se resposta está sendo utilizada
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.id_resposta", "'" + val.Id_respostastr + "'");
                if (new TCD_Pergunta_X_Resposta().BuscarEscalar(tpBuscas, "1") != null)
                    throw new Exception("Está resposta está sendo utilizada, não será possível excluir.");

                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_respostastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Resposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Pergunta X Resposta
    public class TCN_Pergunta_X_Resposta
    {
        public static TList_Pergunta_X_Resposta Buscar(string Id_pergunta,
                                                       string Id_resposta,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_pergunta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Id_pergunta", "'" + Id_pergunta + "'");
            if (!string.IsNullOrEmpty(Id_resposta))
                Estruturas.CriarParametro(ref tpBuscas, "a.Id_resposta", "'" + Id_resposta + "'");

            return new TCD_Pergunta_X_Resposta(banco).Select(tpBuscas, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Pergunta_x_Resposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pergunta_X_Resposta qtb = new TCD_Pergunta_X_Resposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                qtb.Gravar(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_perguntastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Pergunta x Resposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pergunta_x_Resposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pergunta_X_Resposta qtb = new TCD_Pergunta_X_Resposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else
                    qtb.Banco_Dados = banco;
                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_perguntastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Pergunta x Resposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
    #endregion
}

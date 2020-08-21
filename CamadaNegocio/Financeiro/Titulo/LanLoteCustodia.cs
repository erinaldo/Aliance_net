using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Titulo;

namespace CamadaNegocio.Financeiro.Titulo
{
    public class TCN_LoteCustodia
    {
        public static TList_LoteCustodia Buscar(string Id_lote,
                                                string Cd_empresa,
                                                string Cd_contager,
                                                string Cd_banco,
                                                string Nr_cheque,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string Ds_lote,
                                                string Nr_lote,
                                                string Tp_registro,
                                                string St_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("L") ? "a.dt_lote" : "a.dt_enviolote";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("L") ? "a.dt_lote" : "a.dt_enviolote";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(Nr_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_lote.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_cheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_titulo_x_lotecustodia x " +
                                                      "where x.id_lote = a.id_lote " +
                                                      "and x.nr_cheque = '" + Nr_cheque.Trim() + "')";
            }   

            return new TCD_LoteCustodia(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteCustodia val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia qtb_lote = new TCD_LoteCustodia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
                //Excluir titulos lote
                val.lChCustodiaDel.ForEach(p => TCN_LoteCustodia_X_Titulo.Excluir(new TRegistro_LoteCustodia_X_Titulo()
                    {
                        Nr_lanctocheque = p.Nr_lanctocheque,
                        Cd_banco = p.Cd_banco,
                        Cd_empresa = p.Cd_empresa,
                        Id_lote = val.Id_lote
                    }, qtb_lote.Banco_Dados));
                //Gravar titulo lote
                val.lChCustodia.ForEach(p =>
                    {
                        TCN_LoteCustodia_X_Titulo.Gravar(new TRegistro_LoteCustodia_X_Titulo()
                            {
                                Nr_lanctocheque = p.Nr_lanctocheque,
                                Cd_banco = p.Cd_banco,
                                Cd_empresa = p.Cd_empresa,
                                Id_lote = val.Id_lote
                            }, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote custodia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteCustodia val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia qtb_lote = new TCD_LoteCustodia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Excluir titulos do lote
                val.lChCustodia.ForEach(p => TCN_LoteCustodia_X_Titulo.Excluir(new TRegistro_LoteCustodia_X_Titulo()
                    {
                        Cd_banco = p.Cd_banco,
                        Cd_empresa = p.Cd_empresa,
                        Nr_lanctocheque = p.Nr_lanctocheque,
                        Id_lote = val.Id_lote
                    }, qtb_lote.Banco_Dados));
                val.lChCustodiaDel.ForEach(p => TCN_LoteCustodia_X_Titulo.Excluir(new TRegistro_LoteCustodia_X_Titulo()
                    {
                        Cd_banco = p.Cd_banco,
                        Cd_empresa = p.Cd_empresa,
                        Nr_lanctocheque = p.Nr_lanctocheque,
                        Id_lote = val.Id_lote
                    }, qtb_lote.Banco_Dados));
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote custodia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void EnviarLote(TRegistro_LoteCustodia val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia qtb_lote = new TCD_LoteCustodia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.St_registro = "E";//Lote enviado
                Gravar(val, qtb_lote.Banco_Dados);
                //Trocar status dos titulo para custodiados
                val.lChCustodia.ForEach(p =>
                    {
                        //Verificar se titulo devolvido
                        if (p.Status_compensado.Trim().ToUpper().Equals("V"))
                            new CamadaDados.Financeiro.Titulo.TCD_DevolucaoCheque(qtb_lote.Banco_Dados).Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctocheque",
                                        vOperador = "=",
                                        vVL_Busca = p.Nr_lanctocheque.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_banco.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.dt_reapresentacao",
                                        vOperador = "is",
                                        vVL_Busca = "null"
                                    }
                                }, 1, string.Empty, string.Empty).ForEach(v =>
                                    {
                                        v.Dt_reapresentacao = CamadaDados.UtilData.Data_Servidor(qtb_lote.Banco_Dados);
                                        CamadaNegocio.Financeiro.Titulo.TCN_DevolucaoCheque.GravarDevolucaoCheque(v, qtb_lote.Banco_Dados);
                                    });
                        p.Status_compensado = val.Tp_registro.Trim().ToUpper().Equals("C") ? "U" : "L";
                        TCN_LanTitulo.AlterarTitulo(p, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro enviar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }

    public class TCN_LoteCustodia_X_Titulo
    {
        public static TList_LoteCustodia_X_Titulo Buscar(string Id_lote,
                                                         string Cd_empresa,
                                                         string Nr_lanctocheque,
                                                         string Cd_banco,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            return new TCD_LoteCustodia_X_Titulo(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanTitulo BuscarCh(string Id_lote,
                                                  BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanTitulo(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_titulo_x_lotecustodia x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and x.id_lote = " + Id_lote + ")"
                    }
                }, 0, string.Empty, string.Empty);
        }   

        public static string Gravar(TRegistro_LoteCustodia_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia_X_Titulo qtb_lote = new TCD_LoteCustodia_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar titulo custodia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void Gravar(TList_LoteCustodia_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia_X_Titulo qtb_lote = new TCD_LoteCustodia_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.ForEach(p => Gravar(p, qtb_lote.Banco_Dados));
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cheque custodia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteCustodia_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCustodia_X_Titulo qtb_lote = new TCD_LoteCustodia_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Excluir lote custodia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
}

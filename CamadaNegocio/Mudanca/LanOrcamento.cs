using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Mudanca;

namespace CamadaNegocio.Mudanca
{
    public class TCN_Orcamento
    {
        public static TList_Orcamento Buscar(string Cd_empresa,
                                             string Id_orcamento,
                                             string Id_mudanca,
                                             string Nm_cliente,
                                             string Tp_data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string Cidade_origem,
                                             string Cidade_destino,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Nm_cliente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_cliente";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_cliente.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_coleta" : Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_entrega" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_coleta" : Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_entrega" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Cidade_origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cidade_origem";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Cidade_origem.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Cidade_destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cidade_destino";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Cidade_destino.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Orcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_orc.Gravar(val), "@P_ID_ORCAMENTO");
                //Excluir itens
                if(val.lItensDel != null)
                    val.lItensDel.ForEach(p => TCN_Orcamento_X_Itens.Excluir(p, qtb_orc.Banco_Dados));
                //Gravar itens
                if(val.lItens != null)
                    val.lItens.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            p.Id_orcamento = val.Id_orcamento;
                            TCN_Orcamento_X_Itens.Gravar(p, qtb_orc.Banco_Dados);
                        });
                //Excluir encaixotamento
                if(val.lEncDel != null)
                    val.lEncDel.ForEach(p => TCN_Encaixotamento.Excluir(p, qtb_orc.Banco_Dados));
                //Gravar encaixotamento
                if (val.lEnc != null)
                    val.lEnc.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_orcamento = val.Id_orcamento;
                        TCN_Encaixotamento.Gravar(p, qtb_orc.Banco_Dados);
                    });

                if (val.lSerDel != null)
                    val.lSerDel.ForEach(p => TCN_ServicoOrc.Excluir(p, qtb_orc.Banco_Dados));

                if (val.lSer != null)
                    val.lSer.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_orcamento = val.Id_orcamento;
                        TCN_ServicoOrc.Gravar(p, qtb_orc.Banco_Dados);
                    });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Excluir itens
                val.lItens.ForEach(p => TCN_Orcamento_X_Itens.Excluir(p, qtb_orc.Banco_Dados));
                val.lItensDel.ForEach(p => TCN_Orcamento_X_Itens.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir encaixotamento
                val.lEnc.ForEach(p => TCN_Encaixotamento.Excluir(p, qtb_orc.Banco_Dados));
                val.lEncDel.ForEach(p => TCN_Encaixotamento.Excluir(p, qtb_orc.Banco_Dados));
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Reprovar(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Reprovar Orçamento
                val.St_registro = "2";
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Orcamento_X_Itens
    {
        public static TList_Orcamento_X_Itens Buscar(string Cd_empresa,
                                                     string Id_orcamento,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            return new TCD_Orcamento_X_Itens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento_X_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_X_Itens qtb_itens = new TCD_Orcamento_X_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento_X_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_X_Itens qtb_itens = new TCD_Orcamento_X_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Encaixotamento
    {
        public static TList_Encaixotamento Buscar(string Cd_empresa,
                                                  string Id_orcamento,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            return new TCD_Encaixotamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Encaixotamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Encaixotamento qtb_enc = new TCD_Encaixotamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                val.Id_encaixotamentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_enc.Gravar(val), "@P_ID_ENCAIXOTAMENTO");
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return val.Id_encaixotamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar encaixotamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Encaixotamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Encaixotamento qtb_enc = new TCD_Encaixotamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                qtb_enc.Excluir(val);
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return val.Id_encaixotamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir encaixotamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ServicoOrc
    {
        public static TList_ServicoOrc Buscar(string Cd_empresa,
                                                  string Id_orcamento,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            return new TCD_ServicoOrc(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ServicoOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ServicoOrc qtb_enc = new TCD_ServicoOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                val.Id_servicostr = CamadaDados.TDataQuery.getPubVariavel(qtb_enc.Gravar(val), "@P_ID_Servico");
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return val.Id_servicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ServicoOrc: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ServicoOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ServicoOrc qtb_enc = new TCD_ServicoOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                qtb_enc.Excluir(val);
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return val.Id_servicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ServicoOrc: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }
    }




}

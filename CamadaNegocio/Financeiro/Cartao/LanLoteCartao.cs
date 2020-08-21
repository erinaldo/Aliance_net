using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cartao;

namespace CamadaNegocio.Financeiro.Cartao
{
    public class TCN_LanLoteCartao
    {
        public static void EstornarLote(TRegistro_LanLoteCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteCartao qtb_lote = new TCD_LanLoteCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Inicio do processo de estornar lote
                if (val.St_registro.Equals("P"))
                {

                    //Excluir registro Lote X Caixa 
                    val.lFatCartao_Caixa.ForEach(p =>
                    {
                        TCN_FaturaCartao_X_Caixa.Excluir(new TRegistro_FaturaCartao_X_Caixa()
                        {
                            Cd_contager = p.Cd_contager,
                            Cd_lanctocaixa = p.Cd_lanctocaixa,
                            Id_fatura = p.Id_fatura
                        }, qtb_lote.Banco_Dados);
                    });

                    //Chamar metodo estorno de caixa
                    val.lLanCaixa.ForEach(p =>
                    {
                        Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_lote.Banco_Dados);
                    });

                    //Alterar o valor da taxa no bloquetos
                    val.lFatCartao.ForEach(p =>
                    {
                        p.Vl_taxa = decimal.Zero;
                        TCN_FaturaCartao.Gravar(p, null);
                    });
                    //Alterar o lote
                    val.St_registro = "A";
                    qtb_lote.Gravar(val);
                    if (st_transacao)
                        qtb_lote.Banco_Dados.Commit_Tran();
                }
                else
                    throw new Exception("Lote não se encontra processado.");
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static TList_LanLoteCartao Buscar(string Cd_empresa,
                                              string Id_lote,
                                              string id_bandeira,
                                              string cd_contager,
                                              string id_lanctoCaixa,
                                              string st_registro,
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
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(id_bandeira))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bandeira";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_bandeira;
            }
            if (!string.IsNullOrEmpty(cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_contager;
            }
            if (!string.IsNullOrEmpty(id_lanctoCaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.id_lanctoCaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_lanctoCaixa;
            }
            if (!string.IsNullOrEmpty(st_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "IN";
                filtro[filtro.Length - 1].vVL_Busca = "("+st_registro+")";
            }
            return new TCD_LanLoteCartao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanLoteCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteCartao qtb_orc = new TCD_LanLoteCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                string retorno = qtb_orc.Gravar(val);
                val.Id_Lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                val.lCartao.ForEach(p =>
                {
                    p.Cd_Empresa = val.Cd_Empresa;
                    p.Id_Lote = val.Id_Lote;
                    TCN_FaturaDescontar.Gravar(p, null);
                });


                return val.Id_Lote.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanLoteCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteCartao qtb_orc = new TCD_LanLoteCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.lCartao.ForEach(p =>
                {
                    TCN_FaturaDescontar.Excluir(p, qtb_orc.Banco_Dados);
                });

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
               

                return val.Id_Lote.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }


    public class TCN_FaturaDescontar
    {
        public static TList_FaturaDescontar Buscar(string Cd_empresa,
                                              string Id_lote,
                                              string id_fatura,
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
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(id_fatura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fatura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_fatura;
            }
            return new TCD_FaturaDescontar(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FaturaDescontar val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaDescontar qtb_orc = new TCD_FaturaDescontar();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                string retorno = qtb_orc.Gravar(val);
                val.Id_Lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
                val.Id_Fatura = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_FATURA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Fatura.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FaturaDescontar val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaDescontar qtb_orc = new TCD_FaturaDescontar();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Lote.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }

}

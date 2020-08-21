using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_Viagem
    {
        public static TList_Viagem Buscar(string Id_viagem,
                                          string Cd_empresa,
                                          string Id_veiculo,
                                          string Placa,
                                          string Cd_motorista,
                                          string vTp_data,
                                          string vDt_ini,
                                          string vDt_fin,  
                                          string Ds_observacao,
                                          string St_viagem,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(c.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_viagem" : "a.dt_retorno") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_viagem" : "a.dt_retorno") + ")))"; 
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(Ds_observacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_observacao.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(St_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_viagem, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_viagem.Trim() + ")";
            }
            return new TCD_Viagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                val.Id_viagemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_viagem.Gravar(val), "@P_ID_VIAGEM");
                //Rota
                val.lRotaDel.ForEach(p =>
                    TCN_Viagem_X_Rota.Excluir(new TRegistro_Viagem_X_Rota()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = val.Id_viagem,
                        Id_rota = p.Id_rota
                    }, qtb_viagem.Banco_Dados));
                val.lRota.ForEach(p => 
                    TCN_Viagem_X_Rota.Gravar(new TRegistro_Viagem_X_Rota()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = val.Id_viagem,
                        Id_rota = p.Id_rota
                    }, qtb_viagem.Banco_Dados));
                //Frete
                val.lFreteDel.ForEach(p =>
                    TCN_Viagem_X_Frete.Excluir(new TRegistro_Viagem_X_Frete()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = val.Id_viagem,
                        Nr_lanctoCTRC = p.Nr_lanctoCTRC
                    }, qtb_viagem.Banco_Dados));
                val.lFrete.ForEach(p =>
                    TCN_Viagem_X_Frete.Gravar(new TRegistro_Viagem_X_Frete()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = val.Id_viagem,
                        Nr_lanctoCTRC = p.Nr_lanctoCTRC
                    }, qtb_viagem.Banco_Dados));
                //Despesas
                val.lDespesasDel.ForEach(p => TCN_DespesasViagem.Excluir(p, qtb_viagem.Banco_Dados));
                val.lDespesas.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_viagem = val.Id_viagem;
                        TCN_DespesasViagem.Gravar(p, qtb_viagem.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
                return val.Id_viagemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                val.St_viagem = "C";
                qtb_viagem.Gravar(val);
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
                return val.Id_viagemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Viagem " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }

        public static void IncluirAdiantamento(TRegistro_Viagem val,
                                               CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                //Gravar Adiantamento
                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, qtb_viagem.Banco_Dados);
                //Gravar Viagem X Adiantamento
                TCN_AdtoViagem.Gravar(new TRegistro_AdtoViagem()
                {
                    Cd_empresa = val.Cd_empresa,
                    Id_viagem = val.Id_viagem,
                    Id_adto = rAdto.Id_adto
                }, qtb_viagem.Banco_Dados);
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro incluir adiantamento viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DespesasViagem
    {
        public static TList_DespesasViagem Buscar(string Id_landespesa,
                                                  string Id_viagem,
                                                  string Cd_empresa,
                                                  string Id_despesa,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_landespesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_landespesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_landespesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_DespesasViagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DespesasViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_des = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_des.CriarBanco_Dados(true);
                else
                    qtb_des.Banco_Dados = banco;
                val.Id_landespesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_des.Gravar(val), "@P_ID_LANDESPESA");
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_des.Banco_Dados);
                    TCN_Despesa_X_Duplicata.Gravar(new TRegistro_Despesa_X_Duplicata()
                    {
                        Id_landespesa = val.Id_landespesa,
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = val.Id_viagem,
                        Nr_lancto = val.rDup.Nr_lancto
                    }, qtb_des.Banco_Dados);
                }
                //Gravar Centro Resultado
                if(val.lCCusto != null)
                    val.lCCusto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_des.Banco_Dados);
                            TCN_DespViagem_X_CCusto.Gravar(new TRegistro_DespViagem_X_CCusto()
                            {
                                Id_landespesa = val.Id_landespesa,
                                Cd_empresa = val.Cd_empresa,
                                Id_viagem = val.Id_viagem,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_des.Banco_Dados);
                        });
                if (st_transacao)
                    qtb_des.Banco_Dados.Commit_Tran();
                return val.Id_landespesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_des.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_des.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DespesasViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_desp = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                //Excluir duplicata
                TCN_Despesa_X_Duplicata.BuscarDup(val.Id_landespesastr,
                                                  val.Cd_empresa,
                                                  val.Id_viagemstr,
                                                  qtb_desp.Banco_Dados).ForEach(p =>
                                                      {
                                                          TCN_Despesa_X_Duplicata.Excluir(new TRegistro_Despesa_X_Duplicata()
                                                          {
                                                              Id_landespesa = val.Id_landespesa,
                                                              Cd_empresa = val.Cd_empresa,
                                                              Id_viagem = val.Id_viagem,
                                                              Nr_lancto = p.Nr_lancto
                                                          }, qtb_desp.Banco_Dados);
                                                          CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_desp.Banco_Dados);
                                                      });
                //Excluir Centro Resultado
                TCN_DespViagem_X_CCusto.Buscar(val.Id_landespesastr,
                                               val.Id_viagemstr,
                                               val.Cd_empresa,
                                               string.Empty,
                                               qtb_desp.Banco_Dados).ForEach(p =>
                                                   {
                                                       //Excluir Despesa x Centro Resultado
                                                       TCN_DespViagem_X_CCusto.Excluir(p, qtb_desp.Banco_Dados);
                                                       //Excluir Centro Resultado
                                                       CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = p.Id_ccustolan
                                                           }, qtb_desp.Banco_Dados);
                                                   });
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_landespesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Despesa_X_Duplicata
    {
        public static TList_Despesa_X_Duplicata Buscar(string Id_landespesa,
                                                       string Id_viagem,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_landespesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_landespesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_landespesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_Despesa_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_landespesa,
                                                                                       string Cd_empresa,
                                                                                       string Id_viagem,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_despesa_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.id_landespesa = " + Id_landespesa + " " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Despesa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa_X_Duplicata qtb_desp = new TCD_Despesa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                string retorno = qtb_desp.Gravar(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Despesa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa_X_Duplicata qtb_desp = new TCD_Despesa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DespViagem_X_CCusto
    {
        public static TList_DespViagem_X_CCusto Buscar(string Id_landespesa,
                                                       string Id_viagem,
                                                       string Cd_empresa,
                                                       string Id_ccustolan,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_landespesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_landespesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_landespesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_DespViagem_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DespViagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespViagem_X_CCusto qtb_desp = new TCD_DespViagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                string retorno = qtb_desp.Gravar(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DespViagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespViagem_X_CCusto qtb_desp = new TCD_DespViagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static void ProcessarDespCResultado(List<TRegistro_DespesasViagem> lDespesas,
                                                   string CD_CentroResult,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespViagem_X_CCusto qtb_desp = new TCD_DespViagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                if (string.IsNullOrEmpty(CD_CentroResult))
                    throw new Exception("Obrigatório informar centro de resultado.");
                lDespesas.ForEach(p =>
                    {
                        //Verificar se despesa possui centro de resultado
                        TCN_DespViagem_X_CCusto.Buscar(p.Id_landespesastr,
                                                       p.Id_viagemstr,
                                                       p.Cd_empresa,
                                                       string.Empty,
                                                       qtb_desp.Banco_Dados).ForEach(v =>
                                                           {
                                                               TCN_DespViagem_X_CCusto.Excluir(v, qtb_desp.Banco_Dados);
                                                               CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                                   new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                                   {
                                                                       Id_ccustolan = v.Id_ccustolan
                                                                   }, qtb_desp.Banco_Dados);
                                                           });
                        //Gravar Lancto Resultado
                        string id = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Cd_centroresult = CD_CentroResult,
                                Vl_lancto = p.Vl_subtotal,
                                Dt_lancto = p.Dt_despesa
                            }, qtb_desp.Banco_Dados);
                        //Amarrar Lancto a Caixa
                        Gravar(new TRegistro_DespViagem_X_CCusto()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_ccustolan = decimal.Parse(id),
                            Id_landespesa = p.Id_landespesa,
                            Id_viagem = p.Id_viagem
                        }, qtb_desp.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar despesas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Viagem_X_Frete
    {
        public static TList_Viagem_X_Frete Buscar(string Id_viagem,
                                                  string Cd_empresa,
                                                  string Nr_lanctoCTR,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctoCTR))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoCTR";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoCTR;
            }

            return new TCD_Viagem_X_Frete(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete BuscarCTRC(string Cd_empresa,
                                                                                      string Id_viagem,
                                                                                      BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_viagem_x_frete x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctoCTR = a.nr_lanctoCTR " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem_X_Frete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_Frete qtb_frete = new TCD_Viagem_X_Frete();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_frete.CriarBanco_Dados(true);
                else
                    qtb_frete.Banco_Dados = banco;
                string retorno = qtb_frete.Gravar(val);
                if (st_transacao)
                    qtb_frete.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_frete.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_frete.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem_X_Frete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_Frete qtb_frete = new TCD_Viagem_X_Frete();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_frete.CriarBanco_Dados(true);
                else
                    qtb_frete.Banco_Dados = banco;
                qtb_frete.Excluir(val);
                if (st_transacao)
                    qtb_frete.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_frete.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Frete " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_frete.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Viagem_X_Rota
    {
        public static TList_Viagem_X_Rota Buscar(string Id_viagem,
                                                  string Cd_empresa,
                                                  string Id_rota,
                                                  string ordem,  
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_rota))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rota";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rota;
            }
            if (!string.IsNullOrEmpty(ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ordem;
            }

            return new TCD_Viagem_X_Rota(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Frota.Cadastros.TList_RotaFrete BuscarRotas(string Cd_empresa,
                                                                              string Id_viagem,
                                                                              BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Frota.Cadastros.TCD_RotaFrete(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_viagem_x_rota x " +
                                    "where x.id_rota = a.id_rota " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem_X_Rota val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_Rota qtb_rota = new TCD_Viagem_X_Rota();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_rota.CriarBanco_Dados(true);
                else
                    qtb_rota.Banco_Dados = banco;
                string retorno = qtb_rota.Gravar(val);
                if (st_transacao)
                    qtb_rota.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rota.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Rota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rota.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem_X_Rota val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_Rota qtb_rota = new TCD_Viagem_X_Rota();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_rota.CriarBanco_Dados(true);
                else
                    qtb_rota.Banco_Dados = banco;
                qtb_rota.Excluir(val);
                if (st_transacao)
                    qtb_rota.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rota.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Rota " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rota.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AdtoViagem
    {
        public static TList_AdtoViagem Buscar(string Id_adto,
                                              string Id_viagem,
                                              string Cd_empresa,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_AdtoViagem(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento BuscarAdto(string Cd_empresa,
                                                                                           string Id_viagem,
                                                                                           BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo= string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_adtoviagem x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem in (" + Id_viagem + "))"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AdtoViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoViagem qtb_adto = new TCD_AdtoViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                string retorno = qtb_adto.Gravar(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AdtoViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoViagem qtb_adto = new TCD_AdtoViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
}

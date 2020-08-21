using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_AcertoMotorista
    {
        public static TList_AcertoMotorista Buscar(string id_acerto,
                                                   string id_viagem, 
                                                   string cd_empresa,
                                                   string cd_motorista,
                                                   string dt_ini,
                                                   string dt_fin,
                                                   string st_registro, 
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_acerto;
            }
            if (!string.IsNullOrEmpty(id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_frt_acerto_X_viagem x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_acerto = a.id_acerto " +
                                                      "and x.id_viagem = '" + id_viagem.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_motorista.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(dt_ini)) && (dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_acerto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(dt_fin)) && (dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_acerto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(st_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + st_registro.Trim() + ")";
            }
            return new TCD_AcertoMotorista(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AcertoMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcertoMotorista qtb_acerto = new TCD_AcertoMotorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                val.Id_acertostr = CamadaDados.TDataQuery.getPubVariavel(qtb_acerto.Gravar(val), "@P_ID_ACERTO");
                //Excluir viagem
                val.lViagemDel.ForEach(p =>
                    TCN_Acerto_X_Viagem.Excluir(
                    new TRegistro_Acerto_X_Viagem()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_acerto = val.Id_acerto,
                        Id_viagem = p.Id_viagem
                    }, qtb_acerto.Banco_Dados));
                //Gravar viagem
                val.lViagem.ForEach(p =>
                    TCN_Acerto_X_Viagem.Gravar(
                    new TRegistro_Acerto_X_Viagem()
                    {
                        Id_acerto = val.Id_acerto,
                        Cd_empresa = val.Cd_empresa,
                        Id_viagem = p.Id_viagem
                    }, qtb_acerto.Banco_Dados));
                //Excluir carta frete
                val.lCartaFreteDel.ForEach(p =>
                    {
                        p.Id_acerto = null;
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Gravar carta frete
                val.lCartaFrete.ForEach(p =>
                    {
                        p.Id_acerto = val.Id_acerto;
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Excluir cheque
                val.lChequeDel.ForEach(p =>
                    TCN_Acerto_X_Titulo.Excluir(new TRegistro_Acerto_X_Titulo()
                    {
                        Id_acerto = val.Id_acerto,
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctocheque = p.Nr_lanctocheque,
                        Cd_banco = p.Cd_banco
                    }, qtb_acerto.Banco_Dados));
                //Gravar cheque
                val.lCheque.ForEach(p =>
                    TCN_Acerto_X_Titulo.Gravar(new TRegistro_Acerto_X_Titulo()
                    {
                        Id_acerto = val.Id_acerto,
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctocheque = p.Nr_lanctocheque,
                        Cd_banco = p.Cd_banco
                    }, qtb_acerto.Banco_Dados));
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return val.Id_acertostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acerto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AcertoMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcertoMotorista qtb_acerto = new TCD_AcertoMotorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                //Excluir viagem
                val.lViagem.ForEach(p =>
                    TCN_Acerto_X_Viagem.Excluir(
                        new TRegistro_Acerto_X_Viagem()
                        {
                            Id_viagem = p.Id_viagem,
                            Id_acerto = val.Id_acerto,
                            Cd_empresa = val.Cd_empresa
                        }, qtb_acerto.Banco_Dados));
                val.lViagemDel.ForEach(p =>
                    TCN_Acerto_X_Viagem.Excluir(
                        new TRegistro_Acerto_X_Viagem()
                        {
                            Id_viagem = p.Id_viagem,
                            Id_acerto = val.Id_acerto,
                            Cd_empresa = val.Cd_empresa
                        }, qtb_acerto.Banco_Dados));
                //Reabrir Viagem
                val.lViagem.ForEach(p =>
                    {
                        p.St_viagem = "E";
                        TCN_Viagem.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Excluir carta frete
                val.lCartaFrete.ForEach(p =>
                    {
                        p.Id_acerto = null;
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                val.lCartaFreteDel.ForEach(p =>
                    {
                        p.Id_acerto = null;
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                qtb_acerto.Excluir(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return val.Id_acertostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir acerto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static void ProcessarAcerto(TRegistro_AcertoMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcertoMotorista qtb_acerto = new TCD_AcertoMotorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                decimal sd_despesa = val.Tot_despesas - val.Vl_cartafrete;
                //Devolver outros adiantamento
                string id_viagem = string.Empty;
                val.lViagem.ForEach(p => id_viagem += p.Id_viagemstr + ", ");
                if (val.Vl_outrosAdto > decimal.Zero && sd_despesa > decimal.Zero)
                    CamadaNegocio.Frota.TCN_OutrasReceitas.Buscar(string.Empty,
                                                                  val.Cd_empresa,
                                                                  !string.IsNullOrEmpty(id_viagem) ? "(" + id_viagem.Trim().TrimEnd(',') + ")" : string.Empty,
                                                                  string.Empty,
                                                                  val.Cd_motorista,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  true,
                                                                  null).ForEach(p =>
                                                                  {
                                                                      if (sd_despesa > decimal.Zero)
                                                                      {
                                                                          TCN_Acerto_X_OutrasRec.Gravar(
                                                                              new TRegistro_Acerto_X_OutrasRec()
                                                                              {
                                                                                  Id_acerto = val.Id_acerto,
                                                                                  Cd_empresa = val.Cd_empresa,
                                                                                  Id_receita = p.Id_receita,
                                                                                  Vl_devolvido = p.Sd_devadtoViagem < sd_despesa ? p.Sd_devadtoViagem : sd_despesa
                                                                              }, qtb_acerto.Banco_Dados);
                                                                          sd_despesa -= p.Sd_devadtoViagem < sd_despesa ? p.Sd_devadtoViagem : sd_despesa;
                                                                      }
                                                                  });
                //Devolver adiantamento
                if ((val.Vl_adiantamentos > decimal.Zero) &&
                    sd_despesa > decimal.Zero)
                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                     val.Cd_empresa,
                                                                                     val.Cd_motorista,
                                                                                     string.Empty,
                                                                                     "'C'",
                                                                                     string.Empty,
                                                                                     decimal.Zero,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     false,
                                                                                     false,
                                                                                     true,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     true,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     0,
                                                                                     string.Empty,
                                                                                     null).ForEach(p =>
                        {
                            if (sd_despesa > decimal.Zero)
                            {
                                p.Vl_devolver = p.Vl_total_devolver < sd_despesa ? p.Vl_total_devolver : sd_despesa;
                                CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa =
                                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.DevolverAdto(p, qtb_acerto.Banco_Dados);
                                TCN_Acerto_X_DevAdto.Gravar(new TRegistro_Acerto_X_DevAdto()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Id_acerto = val.Id_acerto,
                                    Cd_contager = rCaixa.Cd_ContaGer,
                                    Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                                    Id_adto = p.Id_adto
                                }, qtb_acerto.Banco_Dados);
                                sd_despesa -= p.Vl_devolver;
                            }
                        });
                //Processar Viagem
                val.lViagem.ForEach(p =>
                    {
                        p.St_viagem = "F";//Finalizada
                        TCN_Viagem.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Processar Carta frete
                val.lCartaFrete.ForEach(p =>
                    {
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(p.rDup, false, qtb_acerto.Banco_Dados);
                        p.St_registro = "P";
                        p.Nr_lancto = p.rDup.Nr_lancto;
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Gravar contas pagar
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_acerto.Banco_Dados);
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                //Gravar caixa sobra dinheiro
                if (val.rCaixa != null)
                {
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(val.rCaixa, qtb_acerto.Banco_Dados);
                    val.Cd_contager = val.rCaixa.Cd_ContaGer;
                    val.Cd_lanctocaixa = val.rCaixa.Cd_LanctoCaixa;
                }   
                //Gerar adiantamento sobra caixa
                if (val.rAdto != null)
                {
                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(val.rAdto, qtb_acerto.Banco_Dados);
                    val.Id_adto = val.rAdto.Id_adto;
                }
                //Pagamento despesas
                if ((val.Vl_despesas + val.Vl_manutencao + val.Vl_infracoes + val.Vl_abastecimento) > decimal.Zero)
                {
                    //Buscar config frota
                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                    new CamadaDados.Frota.Cadastros.TCD_CfgFrota(qtb_acerto.Banco_Dados).Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
                    if (lCfg.Count.Equals(0))
                        throw new Exception("Não existe configuração frota para a empresa " + val.Cd_empresa.Trim());
                    if(string.IsNullOrEmpty(lCfg[0].Cd_historicoDesp))
                        throw new Exception("Obrigatorio configurar historico de despesas para processar acerto.");
                    if(string.IsNullOrEmpty(lCfg[0].Cd_contager))
                        throw new Exception("Obrigatorio configurar conta caixa para processar acerto.");
                    //Gravar caixa despesas
                    val.Cd_lanctocaixadespstr =
                        CamadaDados.TDataQuery.getPubVariavel(
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                        new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = lCfg[0].Cd_contager,
                            Cd_Empresa = val.Cd_empresa,
                            Nr_Docto = "DESP_AC" + val.Id_acertostr,
                            Cd_Historico = lCfg[0].Cd_historicoDesp,
                            Login = Utils.Parametros.pubLogin,
                            ComplHistorico = "PAGAMENTO DESPESAS DO ACERTO Nº" + val.Id_acertostr,
                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_acerto.Banco_Dados),
                            Vl_PAGAR = val.Vl_despesas + val.Vl_manutencao + val.Vl_infracoes + val.Vl_abastecimento,
                            St_Titulo = "N",
                            St_Estorno = "N",
                            St_avulso = "N"
                        }, qtb_acerto.Banco_Dados), "@P_CD_LANCTOCAIXA");
                    val.Cd_contager = lCfg[0].Cd_contager;
                }
                //Alterar acerto
                val.St_registro = "P";//Processado
                qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar acerto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static void EstornarProc(TRegistro_AcertoMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcertoMotorista qtb_acerto = new TCD_AcertoMotorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                //Buscar lancamentos de caixa quitacao adiantamento
                TCN_Acerto_X_DevAdto.Buscar(val.Id_acertostr,
                                            val.Cd_empresa,
                                            qtb_acerto.Banco_Dados).ForEach(p =>
                                             {
                                                 //Estornar caixa
                                                 CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                                                     CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(p.Cd_contager,
                                                                                                       p.Cd_lanctocaixa.Value.ToString(),
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       decimal.Zero,
                                                                                                       decimal.Zero,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       false,
                                                                                                       string.Empty,
                                                                                                       decimal.Zero,
                                                                                                       false,
                                                                                                       qtb_acerto.Banco_Dados)[0], qtb_acerto.Banco_Dados);
                                                 //Excluir Acerto X DevAdto
                                                 TCN_Acerto_X_DevAdto.Excluir(new TRegistro_Acerto_X_DevAdto()
                                                 {
                                                     Cd_empresa = val.Cd_empresa,
                                                     Id_acerto = val.Id_acerto,
                                                     Id_adto = p.Id_adto,
                                                     Cd_contager = p.Cd_contager,
                                                     Cd_lanctocaixa = p.Cd_lanctocaixa
                                                 }, qtb_acerto.Banco_Dados);
                                             });
                if (val.Nr_lancto.HasValue)
                {
                    //Cancelar financeiro
                    CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                              val.Nr_lancto.Value.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              1,
                                                                              string.Empty,
                                                                              qtb_acerto.Banco_Dados);
                    if (lDup.Count > 0)
                    {
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_acerto.Banco_Dados);
                        val.Nr_lancto = null;
                    }
                }
                //Estornar Carta Frete
                val.lCartaFrete.ForEach(p =>
                    {
                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(p.Cd_empresa,
                                                                                  p.Nr_lanctostr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  qtb_acerto.Banco_Dados);
                        if (lDup.Count > 0)
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_acerto.Banco_Dados);
                        p.Nr_lancto = null;
                        p.St_registro = "A";
                        TCN_CartaFrete.Gravar(p, qtb_acerto.Banco_Dados);
                    });
                //Estornar lancamento de caixa pagamento despesas
                if ((!string.IsNullOrEmpty(val.Cd_contager)) &&
                    val.Cd_lanctocaixadesp.HasValue)
                {
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager,
                                                                                                                                       val.Cd_lanctocaixadespstr,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       decimal.Zero,
                                                                                                                                       decimal.Zero,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       false,
                                                                                                                                       string.Empty,
                                                                                                                                       decimal.Zero,
                                                                                                                                       false,
                                                                                                                                       qtb_acerto.Banco_Dados)[0],
                                                                                    qtb_acerto.Banco_Dados);
                    if(!val.Cd_lanctocaixa.HasValue)
                        val.Cd_contager = string.Empty;
                    val.Cd_lanctocaixadesp = null;
                }
                //Estornar lancamento de caixa sobra dinheiro
                if ((!string.IsNullOrEmpty(val.Cd_contager)) &&
                    val.Cd_lanctocaixa.HasValue)
                {
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager,
                                                                                                                                       val.Cd_lanctocaixastr,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       decimal.Zero,
                                                                                                                                       decimal.Zero,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       string.Empty,
                                                                                                                                       false,
                                                                                                                                       string.Empty,
                                                                                                                                       decimal.Zero,
                                                                                                                                       false,
                                                                                                                                       qtb_acerto.Banco_Dados)[0],
                                                                                    qtb_acerto.Banco_Dados);
                    if(!val.Cd_lanctocaixadesp.HasValue)
                        val.Cd_contager = string.Empty;
                    val.Cd_lanctocaixa = null;
                }
                //Estornar Adiantamento
                if (val.Id_adto.HasValue)
                {
                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Excluir(CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(val.Id_adtostr,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       decimal.Zero,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       decimal.Zero,
                                                                                                                                                       decimal.Zero,
                                                                                                                                                       false,
                                                                                                                                                       false,
                                                                                                                                                       false,
                                                                                                                                                       string.Empty,
                                                                                                                                                       false,
                                                                                                                                                       false,
                                                                                                                                                       string.Empty,
                                                                                                                                                       string.Empty,
                                                                                                                                                       1,
                                                                                                                                                       string.Empty,
                                                                                                                                                       qtb_acerto.Banco_Dados)[0],
                                                                                   qtb_acerto.Banco_Dados);
                    val.Id_adto = null;
                }
                //Alterar acerto
                val.St_registro = "A";
                qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Acerto_X_Viagem
    {
        public static TList_Acerto_X_Viagem Buscar(string id_acerto,
                                                   string cd_empresa,
                                                   string id_viagem,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_acerto;
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_viagem;
            }
            return new TCD_Acerto_X_Viagem(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_Viagem BuscarViagem(string id_acerto,
                                                string cd_empresa,
                                                BancoDados.TObjetoBanco banco)
        {
            return new TCD_Viagem(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_acerto_x_viagem x " +
                                    "where x.cd_empresa = a.cd_empresa "+
                                    "and x.id_viagem = a.id_viagem "+
                                    "and x.cd_empresa = '" + cd_empresa.Trim() + "' " +
                                    "and x.id_acerto = " + id_acerto + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Acerto_X_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_Viagem qtb_acerto = new TCD_Acerto_X_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                string retorno = qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Acerto_X_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_Viagem qtb_acerto = new TCD_Acerto_X_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                qtb_acerto.Excluir(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Acerto_X_DevAdto
    {
        public static TList_Acerto_X_DevAdto Buscar(string id_acerto,
                                                    string cd_empresa,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_acerto;
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            return new TCD_Acerto_X_DevAdto(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixa(string id_acerto,
                                                                              string cd_empresa,
                                                                              BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_acerto_x_devadto x "+
                                    "where x.cd_contager = a.cd_contager "+
                                    "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                    "and x.cd_empresa = '" + cd_empresa.Trim() + "' "+
                                    "and x.id_acerto = " + id_acerto + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Acerto_X_DevAdto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_DevAdto qtb_acerto = new TCD_Acerto_X_DevAdto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                string ret = qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Acerto_X_DevAdto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_DevAdto qtb_acerto = new TCD_Acerto_X_DevAdto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                qtb_acerto.Excluir(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Acerto_X_Titulo
    {
        public static TList_Acerto_X_Titulo Buscar(string Cd_empresa,
                                                   string Id_acerto,
                                                   string Nr_lanctocheque,
                                                   string Cd_banco,
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
            if (!string.IsNullOrEmpty(Id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_acerto;
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
            return new TCD_Acerto_X_Titulo(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Titulo.TList_RegLanTitulo BuscarCheque(string Cd_empresa,
                                                                                    string Id_acerto,
                                                                                    BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_acerto_x_titulo x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_acerto = " + Id_acerto + ")"
                    }
                }, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Acerto_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_Titulo qtb_acerto = new TCD_Acerto_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                string retorno = qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Acerto_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_Titulo qtb_acerto = new TCD_Acerto_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else
                    qtb_acerto.Banco_Dados = banco;
                qtb_acerto.Excluir(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Acerto_X_OutrasRec
    {
        public static TList_Acerto_X_OutrasRec Buscar(string Id_acerto,
                                                      string Cd_empresa,
                                                      string Id_receita,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_acerto;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_receita";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_receita;
            }
            return new TCD_Acerto_X_OutrasRec(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Acerto_X_OutrasRec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_OutrasRec qtb_acerto = new TCD_Acerto_X_OutrasRec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else qtb_acerto.Banco_Dados = banco;
                string retorno = qtb_acerto.Gravar(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Acerto_X_OutrasRec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acerto_X_OutrasRec qtb_acerto = new TCD_Acerto_X_OutrasRec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acerto.CriarBanco_Dados(true);
                else qtb_acerto.Banco_Dados = banco;
                qtb_acerto.Excluir(val);
                if (st_transacao)
                    qtb_acerto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acerto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acerto.deletarBanco_Dados();
            }
        }
    }
}

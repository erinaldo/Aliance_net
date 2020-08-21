using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_OutrasReceitas
    {
        public static TList_OutrasReceitas Buscar(string Id_receita,
                                                  string Cd_empresa,
                                                  string Id_viagem,
                                                  string Id_veiculo,
                                                  string Cd_motorista,
                                                  string Nr_lancto,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  bool St_saldoDev,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_receita";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_receita;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_viagem";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Receita)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Receita)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (St_saldoDev)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_adtoviagem - a.vl_devadtoviagem";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            return new TCD_OutrasReceitas(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OutrasReceitas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OutrasReceitas qtb_receita = new TCD_OutrasReceitas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_receita.CriarBanco_Dados(true);
                else
                    qtb_receita.Banco_Dados = banco;
                //Gravar Duplicata
                if (val.rDup != null)
                {
                    Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_receita.Banco_Dados);
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                //Gravar Receita
                val.Id_receitastr = CamadaDados.TDataQuery.getPubVariavel(qtb_receita.Gravar(val), "@P_ID_RECEITA");
                //Processar Comissao
                ProcessarComissao(val, qtb_receita.Banco_Dados);
                if (st_transacao)
                    qtb_receita.Banco_Dados.Commit_Tran();
                return val.Id_receitastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_receita.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar outras receitas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_receita.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OutrasReceitas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OutrasReceitas qtb_receita = new TCD_OutrasReceitas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_receita.CriarBanco_Dados(true);
                else
                    qtb_receita.Banco_Dados = banco;
                //Cancelar Duplicata
                if (val.Nr_lancto.HasValue)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                                      val.Nr_lanctostr,
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
                                                                                      qtb_receita.Banco_Dados)[0], qtb_receita.Banco_Dados);
                //Verificar se existe comissao na receita
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_receita.Banco_Dados).Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_receita",
                                vOperador = "=",
                                vVL_Busca = val.Id_receitastr
                            }
                        }, 0, string.Empty);
                //Excluir Receita
                if (lComissao.Count > 0)
                    lComissao.ForEach(p=> CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_receita.Banco_Dados));
                if (val.Vl_devadtoViagem > 0)
                {
                    CamadaDados.Frota.Cadastros.TList_DevOutrasReceitas lDev =
                        CamadaNegocio.Frota.Cadastros.TCN_DevOutrasReceitas.Buscar(val.Id_receitastr,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   qtb_receita.Banco_Dados);
                    lDev.ForEach(p =>
                    {
                        //Estornar Caixa
                        new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_receita.Banco_Dados).Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.CD_ContaGer",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.cd_contager.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.CD_LanctoCaixa",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_lanctoCaixastr
                                }
                            }, 0, string.Empty).ForEach(x => CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(x, null, qtb_receita.Banco_Dados));
                        //Excluir devolução adiantamento outras receitas
                        Cadastros.TCN_DevOutrasReceitas.Excluir(p, qtb_receita.Banco_Dados);
                    });
                }
                //Deletar Receita
                qtb_receita.Excluir(val);
                if (st_transacao)
                    qtb_receita.Banco_Dados.Commit_Tran();
                return val.Id_receitastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_receita.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir outras receitas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_receita.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_OutrasReceitas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OutrasReceitas qtb_receita = new TCD_OutrasReceitas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_receita.CriarBanco_Dados(true);
                else
                    qtb_receita.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                      val.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      val.Id_receitastr,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                      string.Empty,
                                                                                      qtb_receita.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    //Verificar se comissao possui faturamento
                    if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_receita.Banco_Dados).BuscarEscalar(
                        new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lComissao[0].Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_comissao",
                                            vOperador = "=",
                                            vVL_Busca = lComissao[0].Id_comissaostr
                                        }
                                    }, "1") == null)
                        CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(lComissao[0], qtb_receita.Banco_Dados);
                    else
                        throw new Exception("Receita possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                }
                if (!string.IsNullOrEmpty(val.Cd_motorista))
                {
                    decimal vl_basecalc = val.Vl_receita;
                    decimal pc_comissao = decimal.Zero;
                    string tp_comissao = "P";
                    decimal vl_comissao = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                                                      val.Cd_motorista,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      decimal.Zero,
                                                                                                                      ref vl_basecalc,
                                                                                                                      ref pc_comissao,
                                                                                                                      ref tp_comissao,
                                                                                                                      qtb_receita.Banco_Dados);
                    //Gravar fechamento comissao
                    if (vl_comissao > decimal.Zero)
                    {
                        CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                            new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_vendedor = val.Cd_motorista,
                                Dt_lancto = val.Dt_receita.HasValue ? val.Dt_receita : CamadaDados.UtilData.Data_Servidor(qtb_receita.Banco_Dados),
                                Id_receita = val.Id_receita,
                                Tp_comissao = tp_comissao,
                                Pc_comissao = pc_comissao,
                                Vl_basecalc = vl_basecalc,
                                Vl_comissao = vl_comissao
                            }, qtb_receita.Banco_Dados);
                        if (st_transacao)
                            qtb_receita.Banco_Dados.Commit_Tran();
                    }
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_receita.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_receita.deletarBanco_Dados();
            }
        }
    }
}

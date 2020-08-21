using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_TrocaEspecie
    {
        public static TList_TrocaEspecie Buscar(string Cd_empresa,
                                                string Id_troca,
                                                string Id_caixa,
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
            if (!string.IsNullOrEmpty(Id_troca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_troca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_troca;
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            return new TCD_TrocaEspecie(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TrocaEspecie val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaEspecie qtb_troca = new TCD_TrocaEspecie();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else
                    qtb_troca.Banco_Dados = banco;
                if (val.rCheque != null)
                {
                    //Gravar cheque
                    val.rCheque.St_lancarcaixa = true;
                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(val.rCheque, qtb_troca.Banco_Dados);
                    val.Cd_banco = val.rCheque.Cd_banco;
                    val.Nr_lanctocheque = val.rCheque.Nr_lanctocheque;
                }
                if (val.rFatura != null)
                {
                    //Gravar fatura
                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Gravar(val.rFatura, qtb_troca.Banco_Dados);
                    val.Id_fatura = val.rFatura.Id_fatura;
                }
                if (val.rCartaFrete != null)
                {
                    //Gravar Carta Frete
                    CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Gravar(val.rCartaFrete, qtb_troca.Banco_Dados);
                    val.Id_cartafrete = val.rCartaFrete.Id_cartafrete;
                }
                if (val.Vl_trocoD > decimal.Zero)
                {
                    //Gravar troco dinheiro
                    string ret_troco = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                        new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                        {
                                            Cd_Empresa = val.Cd_empresa,
                                            Cd_ContaGer = val.Cd_contager,
                                            Cd_Historico = val.Cd_historico,
                                            Cd_LanctoCaixa = decimal.Zero,
                                            ComplHistorico = "TROCA ESPECIE",
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_troca.Banco_Dados),
                                            Nr_Docto = val.rCheque != null ? val.rCheque.Nr_cheque : val.rFatura != null ? val.rFatura.Id_fatura.Value.ToString() : val.rCartaFrete.Nr_cartafrete,
                                            St_Estorno = "N",
                                            St_Titulo = "N",
                                            Vl_PAGAR = val.Vl_trocoD,
                                            Vl_RECEBER = decimal.Zero
                                        }, qtb_troca.Banco_Dados);
                    val.Cd_contager_trocoD = val.Cd_contager;
                    val.Cd_lanctocaixa_trocoD = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA"));
                }
                val.Id_trocastr = CamadaDados.TDataQuery.getPubVariavel(qtb_troca.Gravar(val), "@P_ID_TROCA");
                if(val.lTrocoCHP != null)
                {
                    //Gravar troco cheque proprio
                    val.lTrocoCHP.ForEach(v =>
                    {
                        if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                        {
                            v.St_lancarcaixa = true;
                            v.Status_compensado = "T";
                            CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(v, qtb_troca.Banco_Dados);
                        }
                        //Gravar Troco CH
                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_caixa = val.Id_caixa,
                            Nr_lanctocheque = v.Nr_lanctocheque,
                            Cd_banco = v.Cd_banco,
                            Id_troca = val.Id_troca
                        }, qtb_troca.Banco_Dados);
                    });
                }
                if (val.lTrocoCHT != null)
                {
                    val.lTrocoCHT.ForEach(v =>
                    {
                        //Gravar Troco CH
                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_caixa = val.Id_caixa,
                            Nr_lanctocheque = v.Nr_lanctocheque,
                            Cd_banco = v.Cd_banco,
                            Id_troca = val.Id_troca
                        }, qtb_troca.Banco_Dados);
                    });
                }
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return val.Id_trocastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static void Estornar(TRegistro_TrocaEspecie val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaEspecie qtb_troca = new TCD_TrocaEspecie();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                //Estornar cheque troco
                new TCD_TrocoCH(qtb_troca.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_troca",
                            vOperador = "=",
                            vVL_Busca = val.Id_trocastr
                        }
                    }, 0, string.Empty).ForEach(p => TCN_TrocoCH.Excluir(p, qtb_troca.Banco_Dados));
                //Excluir troca especie
                qtb_troca.Excluir(val);
                //Cancelar cheque
                if (val.Nr_lanctocheque.HasValue)
                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CancelarTitulo(
                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca(val.Cd_empresa,
                                                                            val.Nr_lanctocheque.Value,
                                                                            val.Cd_banco,
                                                                            string.Empty,
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
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            1,
                                                                            string.Empty,
                                                                            qtb_troca.Banco_Dados)[0], qtb_troca.Banco_Dados);
                //Cancelar fatura
                if (val.Id_fatura.HasValue)
                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.CancelarFatura(
                        CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Buscar(val.Id_faturastr,
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
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                false,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                qtb_troca.Banco_Dados)[0], qtb_troca.Banco_Dados);
                //Cancelar carta frete
                if (val.Id_cartafrete.HasValue)
                    CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Excluir(
                        CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Buscar(val.Cd_empresa,
                                                                             val.Id_cartafretestr,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             qtb_troca.Banco_Dados)[0], qtb_troca.Banco_Dados);
                //Estornar caixa troco dinheiro
                if (val.Cd_lanctocaixa_trocoD.HasValue)
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager_trocoD,
                                                                          val.Cd_lanctocaixa_trocoDstr,
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
                                                                          qtb_troca.Banco_Dados)[0], qtb_troca.Banco_Dados);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar troca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocaEspecie val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaEspecie qtb_troca = new TCD_TrocaEspecie();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return val.Id_trocastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }
}

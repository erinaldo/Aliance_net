using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Titulo;
using System.Data;
using Utils;

namespace CamadaNegocio.Financeiro.Titulo
{
    public class TCN_DevolucaoCheque
    {
        public static TList_DevolucaoCheque Buscar(string Id_devolucao,
                                                   string Cd_empresa,
                                                   string Nr_lanctocheque,
                                                   string Cd_banco,
                                                   int vTop,
                                                   string vNm_campo,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_devolucao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devolucao;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctocheque.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (Cd_banco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            return new TCD_DevolucaoCheque(banco).Select(filtro, vTop, vNm_campo, string.Empty);
        }

        public static string GravarDevolucaoCheque(TRegistro_DevolucaoCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoCheque qtb_dev = new TCD_DevolucaoCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else
                    qtb_dev.Banco_Dados = banco;
                
                string retorno = string.Empty;
                if (val.lCheques.Count > 0)
                {
                    CamadaDados.Financeiro.Cadastros.TList_CFGCheque lCfgCheque =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.Buscar(val.lCheques[0].Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_dev.Banco_Dados);
                    if (lCfgCheque.Count < 1)
                        throw new Exception("Não existe configuração de cheque para a empresa " + val.lCheques[0].Cd_empresa.Trim());
                    if (val.lCheques[0].Tp_titulo.Trim().ToUpper().Equals("P"))
                    {
                        if (lCfgCheque[0].Cd_histdev_chemitidos.Trim().Equals(string.Empty))
                            throw new Exception("Não existe historico de devolução de cheques emitidos configurado para a empresa " + val.lCheques[0].Cd_empresa.Trim());
                        if(lCfgCheque[0].Cd_contadev_chemitidos.Trim().Equals(string.Empty))
                            throw new Exception("Não existe conta gerencial de devolução de cheques emitidos configurado para a empresa " + val.lCheques[0].Cd_empresa.Trim());
                    }
                    else
                    {
                        if (lCfgCheque[0].Cd_histdev_chrecebidos.Trim().Equals(string.Empty))
                            throw new Exception("Não existe historico de devolução de cheques recebidos configurado para a empresa " + val.lCheques[0].Cd_empresa.Trim());
                        if (lCfgCheque[0].Cd_contadev_chrecebidos.Trim().Equals(string.Empty))
                            throw new Exception("Não existe conta gerencial de devolução de cheques recebidos configurado para a empresa " + val.lCheques[0].Cd_empresa.Trim());
                    }
                    val.lCheques.ForEach(p =>
                        {
                            //Gravar devolucao cheque
                            val.Cd_banco = p.Cd_banco;
                            val.Cd_empresa = p.Cd_empresa;
                            val.Nr_lanctocheque = p.Nr_lanctocheque;
                            retorno = qtb_dev.GravarDevolucaoCheque(val);
                            //Buscar lancamentos de caixa com st_titulo = S e alterar
                            CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa =
                                new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(

                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                                            vVL_Busca = "'S'",
                                            vOperador = "<>"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_titulo, '')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x "+
                                                        "where x.cd_contager = a.cd_contager "+
                                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                                        "and x.cd_empresa = '"+val.Cd_empresa.Trim()+"' "+
                                                        "and x.cd_banco = '"+val.Cd_banco.Trim()+"' "+
                                                        "and x.nr_lanctocheque = "+val.Nr_lanctocheque.ToString()+" "+
                                                        "and isnull(x.tp_lancto, '')<>'GC')"
                                        }
                                    }, 0, string.Empty);
                            lCaixa.ForEach(v =>
                            {
                                v.St_Titulo = "N";
                                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.AlterarLanCaixa(v, qtb_dev.Banco_Dados);
                            });
                            if (p.Tp_titulo.Trim().ToUpper().Equals("P"))
                            {
                                //Cheques emitidos
                                //Gravar caixa dando entrada do cheque na conta compensada
                                string ret_caixaorig = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = p.Cd_empresa,
                                        Cd_ContaGer = p.Cd_contager,
                                        Nr_Docto = p.Nr_cheque.Trim(),
                                        Dt_lancto = val.Dt_devolucao,
                                        Cd_Historico = lCfgCheque[0].Cd_histdev_chemitidos,
                                        Vl_RECEBER = p.Vl_titulo,
                                        Vl_PAGAR = decimal.Zero,
                                        ComplHistorico = "DEVOLUCAO CHEQUE EMITIDO "+p.Nr_cheque.Trim(),
                                        St_Titulo = "N"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar cheque X Caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_banco = p.Cd_banco,
                                        Cd_contager = p.Cd_contager,
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixaorig, "@P_CD_LANCTOCAIXA")),
                                        Nr_lanctocheque = p.Nr_lanctocheque,
                                        Tp_caixa = "N"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar caixa dando saida no cheque na conta de devolucao
                                string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = p.Cd_empresa,
                                        Cd_ContaGer = lCfgCheque[0].Cd_contadev_chemitidos,
                                        Nr_Docto = p.Nr_cheque.Trim(),
                                        Dt_lancto = val.Dt_devolucao,
                                        Cd_Historico = lCfgCheque[0].Cd_histdev_chemitidos,
                                        Vl_RECEBER = decimal.Zero,
                                        Vl_PAGAR = p.Vl_titulo,
                                        ComplHistorico = "DEVOLUCAO CHEQUE EMITIDO " + p.Nr_cheque.Trim(),
                                        St_Titulo = "S"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar cheque X Caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_banco = p.Cd_banco,
                                        Cd_contager = lCfgCheque[0].Cd_contadev_chemitidos,
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                        Nr_lanctocheque = p.Nr_lanctocheque,
                                        Tp_caixa = "S"
                                    }, qtb_dev.Banco_Dados);
                            }
                            else
                            {
                                //Cheques recebidos
                                //Gravar caixa dando saida do cheque da conta que foi compensado
                                string ret_caixaorig = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = p.Cd_empresa,
                                        Cd_ContaGer = p.Cd_contager,
                                        Nr_Docto = p.Nr_cheque.Trim(),
                                        Dt_lancto = val.Dt_devolucao,
                                        Cd_Historico = lCfgCheque[0].Cd_histdev_chrecebidos,
                                        Vl_RECEBER = decimal.Zero,
                                        Vl_PAGAR = p.Vl_titulo,
                                        ComplHistorico = "DEVOLUCAO CHEQUE RECEBIDO " + p.Nr_cheque.Trim(),
                                        St_Titulo = "N"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar cheque X Caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_banco = p.Cd_banco,
                                        Cd_contager = p.Cd_contager,
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixaorig, "@P_CD_LANCTOCAIXA")),
                                        Nr_lanctocheque = p.Nr_lanctocheque,
                                        Tp_caixa = "N"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar caixa dando entrada no cheque na conta de devolucao
                                string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = p.Cd_empresa,
                                        Cd_ContaGer = lCfgCheque[0].Cd_contadev_chrecebidos,
                                        Nr_Docto = p.Nr_cheque.Trim(),
                                        Dt_lancto = val.Dt_devolucao,
                                        Cd_Historico = lCfgCheque[0].Cd_histdev_chrecebidos,
                                        Vl_RECEBER = p.Vl_titulo,
                                        Vl_PAGAR = decimal.Zero,
                                        ComplHistorico = "DEVOLUCAO CHEQUE RECEBIDO " + p.Nr_cheque.Trim(),
                                        St_Titulo = "S"
                                    }, qtb_dev.Banco_Dados);
                                //Gravar cheque X Caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_banco = p.Cd_banco,
                                        Cd_contager = lCfgCheque[0].Cd_contadev_chrecebidos,
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                        Nr_lanctocheque = p.Nr_lanctocheque,
                                        Tp_caixa = "S"
                                    }, qtb_dev.Banco_Dados);
                            }
                            //Verificar se o lancamento de caixa esta amarrado ao repasse de cheque
                            CamadaDados.Financeiro.Titulo.TList_Rastreab_ChTerceiro lChequesRep =
                                CamadaNegocio.Financeiro.Titulo.TCN_Rastreab_ChTerceiro.Buscar(val.Cd_empresa,
                                                                                               val.Cd_banco,
                                                                                               val.Nr_lanctocheque.Value.ToString(),
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               0,
                                                                                               string.Empty,
                                                                                               qtb_dev.Banco_Dados);
                            //Excluir os lancamentos de repasse
                            lChequesRep.ForEach(v =>
                                    TCN_Rastreab_ChTerceiro.DeletarRastreab_ChTerceiro(new TRegistro_Rastreab_ChTerceiro()
                                    {
                                        Cd_empresa = v.Cd_empresa,
                                        Cd_banco = v.Cd_banco,
                                        Nr_lanctocheque = v.Nr_lanctocheque,
                                        Cd_clifor_origem = v.Cd_clifor_origem
                                    }, qtb_dev.Banco_Dados));
                            //Verificar se titulo esta a um lote de custodia
                            TCN_LoteCustodia_X_Titulo.Buscar(string.Empty,
                                                             val.Cd_empresa,
                                                             val.Nr_lanctocheque.Value.ToString(),
                                                             val.Cd_banco,
                                                             qtb_dev.Banco_Dados).ForEach(v => TCN_LoteCustodia_X_Titulo.Excluir(v, qtb_dev.Banco_Dados));
                            //Mudar status do cheque para devolvido
                            p.Status_compensado = "V";
                            TCN_LanTitulo.GravarTitulo(p, qtb_dev.Banco_Dados);
                        });
                }
                else
                    qtb_dev.GravarDevolucaoCheque(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar devolucao cheque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static string DeletarDevolucaoCheque(TRegistro_DevolucaoCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoCheque qtb_dev = new TCD_DevolucaoCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else
                    qtb_dev.Banco_Dados = banco;
                //Deletar devolucao cheque
                qtb_dev.DeletarDevolucaoCheque(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar devolucao cheque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }
    }
}

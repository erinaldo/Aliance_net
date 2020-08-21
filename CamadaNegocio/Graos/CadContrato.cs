using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaNegocio.Faturamento.Pedido;

namespace CamadaNegocio.Graos
{
    public class TCN_CadContrato
    {
        public static TList_CadContrato Buscar(string vNr_Contrato,
                                               string vCD_TabelaDesconto,
                                               string vTP_Natureza_Classif,
                                               string vTP_Natureza_Pesagem,
                                               string vNR_ContratoOrigem,
                                               string vAnoSafra,
                                               string vCd_Empresa,
                                               string vCD_Clifor,
                                               string vCD_Endereco,
                                               string vDS_ObsGRO,
                                               string vTp_Frete,
                                               string vTP_GMO,
                                               string vDt_Abertura,
                                               string vDt_Encerramento,
                                               string vST_Registro,
                                               string vNm_campo,
                                               int vTop,
                                               TObjetoBanco banco)
        {

            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(vNr_Contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_Registro ";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            if (!string.IsNullOrEmpty(vCD_TabelaDesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_TabelaDesconto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            if (!string.IsNullOrEmpty(vAnoSafra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.AnoSafra";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vAnoSafra.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_Empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }      
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            if (!string.IsNullOrEmpty(vCD_Endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Endereco";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Endereco.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            if (!string.IsNullOrEmpty(vDS_ObsGRO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_ObsGRO";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDS_ObsGRO.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }            
            if (!string.IsNullOrEmpty(vTp_Frete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_Frete";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_Frete.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            if (!string.IsNullOrEmpty(vTP_GMO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_GMO";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vTP_GMO.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }
            if ((!string.IsNullOrEmpty(vDt_Abertura)) && (vDt_Abertura.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.Dt_Abertura)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_Abertura).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((!string.IsNullOrEmpty(vDt_Encerramento)) && (vDt_Encerramento.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.Dt_Encerramento)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_Encerramento).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }            
            return new TCD_CadContrato(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_CadContrato BuscarContrato(string Tp_movimento,
                                                       string Nr_contrato,
                                                       string Cd_empresa,
                                                       string Cd_clifor,
                                                       string Nr_pedido,
                                                       string Cfg_pedido,
                                                       string Anosafra,
                                                       string Cd_tabeladesconto,
                                                       string Cd_produto,
                                                       string Tp_data,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       string St_registro,
                                                       string Tp_prodcontrato,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_movimento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cfg_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Anosafra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.anosafra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Anosafra.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabeladesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_prodcontrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_prodcontrato";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_prodcontrato.Trim() + ")";
            }

            return new TCD_CadContrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarContrato(TRegistro_CadContrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato qtb_Contrato = new TCD_CadContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Contrato.CriarBanco_Dados(true);
                else
                    qtb_Contrato.Banco_Dados = banco;
                
                string retorno = qtb_Contrato.Gravar(val);
                val.Nr_contrato = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_CONTRATO"));
                //Deletar Contrato Headge
                val.lDelContrato_Headge.ForEach(p=> TCN_CadContrato_Headge.DeletarContrato_Headge(p, qtb_Contrato.Banco_Dados));
                //Gravar Contrato Headge
                val.lContrato_Headge.ForEach(p=> 
                    {
                        p.Nr_Contrato = val.Nr_contrato.Value;
                        TCN_CadContrato_Headge.GravarContrato_Headge(p, qtb_Contrato.Banco_Dados);
                    });

                //Deletar Taxa
                val.DelTaxas.ForEach(p=> TCN_CadContratoTaxaDeposito.DeletarContratoTaxaDeposito(p, qtb_Contrato.Banco_Dados));
                //Gravar Taxa
                val.Taxas.ForEach(p=>
                    {
                        p.Nr_contrato = val.Nr_contrato;
                        TCN_CadContratoTaxaDeposito.GravarContratoTaxaDeposito(p, qtb_Contrato.Banco_Dados);
                    });
                //Excluir Desdobro Especial
                val.lDesdobroDel.ForEach(p => TCN_Contrato_X_DesdEspecial.Excluir(p, qtb_Contrato.Banco_Dados));
                //Gravar Desdobro Especial
                val.lDesdobro.ForEach(p =>
                    {
                        p.Nr_contrato = val.Nr_contrato;
                        TCN_Contrato_X_DesdEspecial.Gravar(p, qtb_Contrato.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_Contrato.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar contrato: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Contrato.deletarBanco_Dados();
            }
        }

        public static string AtivarContrato(TRegistro_CadContrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato qtb_contrato = new TCD_CadContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                val.St_registro = "A";//Ativo
                qtb_contrato.Gravar(val);
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
                return val.Nr_contrato.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static void EncerrarContrato(TRegistro_CadContrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato qtb_contrato = new TCD_CadContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                val.Dt_encerramento = CamadaDados.UtilData.Data_Servidor();
                val.St_registro = "E";
                qtb_contrato.Gravar(val);
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static void AdiantamentoContrato(TRegistro_CadContrato val, TObjetoBanco banco)
        {
            if (val.rAdto == null)
                throw new Exception("Não existe adiantamento informado para gravar.");
            bool st_transacao = false;
            TCD_CadContrato qtb_contrato = new TCD_CadContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                TCN_Lan_Adto_Contrato.Gravar(
                    new TRegistro_Adto_Contrato()
                    {
                        Nr_contrato = val.Nr_contrato,
                        Id_adto = Convert.ToDecimal(
                        CamadaDados.TDataQuery.getPubVariavel(
                        CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(val.rAdto, qtb_contrato.Banco_Dados), "@P_ID_ADTO"))
                    }, qtb_contrato.Banco_Dados);
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar adiantamento contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static string DeletarContrato(TRegistro_CadContrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato qtb_Contrato = new TCD_CadContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Contrato.CriarBanco_Dados(true);
                else
                    qtb_Contrato.Banco_Dados = banco;
                //Deletar Contrato Headge
                val.lContrato_Headge.ForEach(p => TCN_CadContrato_Headge.DeletarContrato_Headge(p, qtb_Contrato.Banco_Dados));
                val.lDelContrato_Headge.ForEach(p => TCN_CadContrato_Headge.DeletarContrato_Headge(p, qtb_Contrato.Banco_Dados));
                
                //Deletar Taxa
                val.Taxas.ForEach(p => TCN_CadContratoTaxaDeposito.DeletarContratoTaxaDeposito(p, qtb_Contrato.Banco_Dados));
                val.DelTaxas.ForEach(p => TCN_CadContratoTaxaDeposito.DeletarContratoTaxaDeposito(p, qtb_Contrato.Banco_Dados));
                
                //Deletar desdobro especial
                val.lDesdobro.ForEach(p => TCN_Contrato_X_DesdEspecial.Excluir(p, qtb_Contrato.Banco_Dados));
                val.lDesdobroDel.ForEach(p => TCN_Contrato_X_DesdEspecial.Excluir(p, qtb_Contrato.Banco_Dados));

                //Cancelar lancamento estoque embalagem
                val.lEstoqueEmbalagem.ForEach(p => CamadaNegocio.Estoque.TCN_LanEstoque.DeletarEstoque(
                    p, qtb_Contrato.Banco_Dados));

                //Excluir contrato
                qtb_Contrato.Excluir(val);
                if (st_transacao)
                    qtb_Contrato.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Contrato.deletarBanco_Dados();
            }
        }
    }
}

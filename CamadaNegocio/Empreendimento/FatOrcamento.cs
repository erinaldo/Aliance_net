using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Pedido;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Almoxarifado;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Empreendimento
{
    public class TCN_FatOrcamento
    {
        public static TList_FatOrcamento Buscar(string Cd_empresa,
                                          string Id_orcamento,
                                          string Nr_versao,
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
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;// + " or ( b.id_orc = '" + Id_orcamento + "')";
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            return new TCD_FatOrcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FatOrcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FatOrcamento qtb_orc = new TCD_FatOrcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                //string retorno = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDuplicata, false, qtb_orc.Banco_Dados);
                //val.nr_lanctostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTO");

                string ret = qtb_orc.Gravar(val);
                val.Id_orcamento = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ORCAMENTO"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_execucao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar FATURAMENTO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_FatOrcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FatOrcamento qtb_orc = new TCD_FatOrcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir faturamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static TRegistro_LanFaturamento existeNumeroNota(string vNR_NotaFiscal,
                                                                string vNR_Serie,
                                                                string vCD_Empresa,
                                                                string vCD_Clifor,
                                                                string vInsc_estadual,
                                                                string vTP_Nota,
                                                                BancoDados.TObjetoBanco banco)
        {
            if (vNR_NotaFiscal.Equals(0))
                return null;
            TList_RegLanFaturamento lista = new TList_RegLanFaturamento();
            if (vTP_Nota.Trim().Equals("P"))
                lista = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(vCD_Empresa,
                              vNR_NotaFiscal,
                              vNR_Serie,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              string.Empty,
                              string.Empty,
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
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              decimal.Zero,
                              string.Empty,
                              "'P'",//Propria
                              string.Empty,
                              false,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              1,
                              string.Empty,
                              banco);
            else if (vTP_Nota.Trim().Equals("T"))
                lista = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(vCD_Empresa,
                              vNR_NotaFiscal,
                              vNR_Serie,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              vCD_Clifor,
                              string.Empty,
                              vInsc_estadual,
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
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              decimal.Zero,
                              string.Empty,
                              "'T'",//Terceiro
                              string.Empty,
                              false,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              1,
                              string.Empty,
                              banco);

            if ((vTP_Nota.Trim() == "P") || (vTP_Nota.Trim() == "T"))
            {
                if (lista.Count > 0)
                    return lista[0];
                else
                    return null;
            }
            else
                return null;
        }
        public static bool ExcluirNotaFiscal(TRegistro_LanFaturamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_nf = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nf.CriarBanco_Dados(true);
                else
                    qtb_nf.Banco_Dados = banco;
                //Verificar se NFe e se a mesma foi cancelada junto a receita
                if (val.Cd_modelo.Trim().Equals("55") &&
                    (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal(qtb_nf.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctofiscal",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lanctofiscal.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.status",
                            vOperador = "in",
                            vVL_Busca = "('100', '110')"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "d.tp_ambiente",
                            vOperador = "<>",
                            vVL_Busca = "'2'"//Producao
                        }
                    }, "1") != null))
                    throw new Exception("Não é permitido excluir Nota Fiscal Eletronica ACEITA ou DENEGADA pela receita.");
                //Verificar se a nota fiscal possui imposto processado
                object objfiscal = new CamadaDados.Faturamento.NotaFiscal.TCD_ImpostosNF(banco).BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = val.Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lotefis",
                                            vOperador = "is",
                                            vVL_Busca = "not null"
                                        }
                                    }, "1");
                if (objfiscal != null)
                    throw new Exception("Não é permitido excluir nota fiscal que possui registro fiscal processado.\r\n" +
                                        "Entre em contato com o departamento contabil para excluir a nota fiscal");
                int mes = 0;
                int ano = 0;
                //Verificar se a nota fiscal esta dentro do mes corrente
                if (val.Tp_movimento.Trim().ToUpper().Equals("E"))
                {
                    mes = val.Dt_saient.Value.Month;
                    ano = val.Dt_saient.Value.Year;
                }
                else
                {
                    mes = val.Dt_emissao.Value.Month;
                    ano = val.Dt_emissao.Value.Year;
                }
                if (CamadaDados.UtilData.Data_Servidor().Month.Equals(val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient.Value.Month : val.Dt_emissao.Value.Month) &&
                    CamadaDados.UtilData.Data_Servidor().Year.Equals(val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient.Value.Year : val.Dt_emissao.Value.Year))
                    qtb_nf.ExcluirNotaFiscal(val);
                else if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUIR NOTA FISCAL FORA PERIODO", banco))
                    qtb_nf.ExcluirNotaFiscal(val);
                else
                    throw new Exception("Usuario " + Utils.Parametros.pubLogin.Trim() + " não é tem permissão para excluir nota fiscal com data movimentação fora do mês corrente.");
                if (st_transacao)
                    qtb_nf.Banco_Dados.Commit_Tran();
                return true;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir nota fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nf.deletarBanco_Dados();
            }
        }
    }




}

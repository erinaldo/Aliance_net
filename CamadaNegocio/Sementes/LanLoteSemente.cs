using System;
using CamadaDados.Sementes;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Producao.Producao;
using Utils;

namespace CamadaNegocio.Sementes
{
    #region "Classe Lote Semente"
    public class TCN_LoteSemente
    {
        public static TList_LoteSemente Buscar(string Id_lote,
                                               string Cd_empresa,
                                               string Cd_produto,
                                               string Anosafra,
                                               string Nr_lote,
                                               string Cd_atestado,
                                               string Id_analise,
                                               string Cd_laboratorio,
                                               string Cd_tecnico,
                                               string St_registro,
                                               bool St_vencido,
                                               bool St_semsaldo,
                                               int vTop,
                                               string vNm_campo,
                                               string cd_grupo,
                                               string Nr_nforigem,
                                               string Tp_data,
                                               string DtIni,
                                               string DtFin,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (cd_grupo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_grupo;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Anosafra.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.anosafra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Anosafra.Trim() + "'";
            }
            if (Nr_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lote";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nr_lote.Trim() + "%')";
            }
            if (Cd_atestado.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_atestado";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Cd_atestado.Trim() + "%')";
            }
            if (Id_analise.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_sem_lotesemente_x_tipoanalise x " +
                                                      "where x.id_lote = a.id_lote " +
                                                      "and x.id_analise = " + Id_analise + ")";
            }
            if (Cd_laboratorio.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_laboratorio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_laboratorio.Trim() + "'";
            }
            if (Cd_tecnico.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tecnico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tecnico.Trim() + "'";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_vencido)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_valgerminacao)))";
                filtro[filtro.Length - 1].vOperador = "<";
                filtro[filtro.Length - 1].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),getdate())))";
            }
            if (St_semsaldo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(dbo.F_CONVERTE_UNID(g.cd_unidade, d.cd_unidade, a.qtd_lote) - (isnull((select sum(isnull(x.quantidade, 0))  " +
                                                      "                 from tb_sem_lotesemente_x_nfitem x " +
                                                      "                 inner join tb_fat_notafiscal_item y " +
                                                      "                 on x.cd_empresa = y.cd_empresa " +
                                                      "                 and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "                 and x.id_nfitem = y.id_nfitem " +
                                                      "                 inner join tb_fat_notafiscal z " +
                                                      "                 on y.cd_empresa = z.cd_empresa " +
                                                      "                 and y.nr_lanctofiscal = z.nr_lanctofiscal " +
                                                      "                 where z.tp_movimento = 'S' " +
                                                      "                 and isnull(z.st_registro, 'A') <> 'C' " + //Nota Fiscal Ativa
                                                      "                 and x.tp_movimento = 'D' " +//Notas de venda
                                                      "                 and x.id_lote = a.id_lote ), 0) - " +

                                                      "               isnull((select sum(isnull(x.quantidade, 0)) " +
                                                      "                 from tb_sem_lotesemente_x_nfitem x " +
                                                      "                 inner join tb_fat_notafiscal_item y " +
                                                      "                 on x.cd_empresa = y.cd_empresa " +
                                                      "                 and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "                 and x.id_nfitem = y.id_nfitem " +
                                                      "                 inner join tb_fat_notafiscal z " +
                                                      "                 on y.cd_empresa = z.cd_empresa " +
                                                      "                 and y.nr_lanctofiscal = z.nr_lanctofiscal " +
                                                      "                 inner join tb_fat_notafiscal_cmi cmi " +
                                                      "                 on z.cd_empresa = cmi.cd_empresa " +
                                                      "                 and z.nr_lanctofiscal = cmi.nr_lanctofiscal " +
                                                      "                 where z.tp_movimento = 'E' " +
                                                      "                 and x.tp_movimento = 'D' " +
                                                      "                 and isnull(cmi.st_devolucao, 'N') = 'S' " + //Nota Devolucao Compra
                                                      "                 and isnull(z.st_registro, 'A') <> 'C' " + //Nota Fiscal Ativa
                                                      "                 and x.id_lote = a.id_lote), 0)))";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if(!string.IsNullOrEmpty(Nr_nforigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_SEM_LoteSemente_X_NFItem x " +
                                                      "inner join TB_FAT_NotaFiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "and y.nr_notafiscal = " + Nr_nforigem + ")";
            }
            if(DtIni.IsDateTime())
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("L") ? "a.dt_lote" : "a.dt_valgerminacao") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DtIni).ToString("yyyyMMdd") + "'";
            }
            if(DtFin.IsDateTime())
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("L") ? "a.dt_lote" : "a.dt_valgerminacao") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DtFin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_LoteSemente(banco).Select(filtro, vTop, vNm_campo);
        }

        public static void ProcessarEstornoLoteSemente(TRegistro_LoteSemente val, decimal Qtd_estornar, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Criar lista de formula apontamento
                TList_FormulaApontamento lFormula = TCN_FormulaApontamento.Buscar(val.Cd_empresa,
                                                                                  val.Id_formestornostr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  qtb_lote.Banco_Dados);
                if (lFormula.Count > 0)
                {
                    //Buscar ficha tecnica mprima
                    lFormula[0].LFichaTec_MPrima = TCN_FichaTec_MPrima.Buscar(val.Cd_empresa,
                                                                              val.Id_formestornostr,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              qtb_lote.Banco_Dados);
                }
                else
                    throw new Exception("Não existe formula de produção cadatrada no sistema para a empresa " + val.Cd_empresa.Trim() + "\r\n" +
                                        "Id. Formulação " + val.Id_formestornostr);
                //Quantidade de batidas
                TRegistro_FichaTec_MPrima rMPrima = lFormula[0].LFichaTec_MPrima.Find(p => p.Cd_produto.Trim().Equals(val.Cd_produto.Trim()));
                decimal qtd_batch = 1;
                if (rMPrima != null)
                    qtd_batch = TCN_CadConvUnidade.ConvertUnid(val.Cd_unidade, rMPrima.Cd_unidade, Qtd_estornar, 3, qtb_lote.Banco_Dados) / rMPrima.Qtd_produto;
                else
                    throw new Exception("Não existe materia prima " + val.Cd_amostra.Trim());
                //Apontamento de producao
                TRegistro_ApontamentoProducao rApontamento =
                    new TRegistro_ApontamentoProducao()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Dt_apontamento = val.DT_lote,
                        Dt_validade = (val.Dt_valgerminacao == null ? val.DT_lote : val.Dt_valgerminacao),
                        //Id_formulacao = val.Id_formulacao,
                        LFormulaApontamento = lFormula,
                        Qtd_batch = qtd_batch
                    };
                //Calcular Custo MPD
                TCN_ApontamentoProducao.CalcularCustoMPD(rApontamento, qtb_lote.Banco_Dados);
                //Gravar apontamento de producao
                TCN_ApontamentoProducao.Gravar(rApontamento, 
                                               //false, 
                                               qtb_lote.Banco_Dados);
                //Buscar quantidade de entrada no estoque do produto do lote
                CamadaDados.Estoque.TList_RegLanEstoque lEst =
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_lote.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_prd_apontamento_x_estoque x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.cd_produto = a.cd_produto "+
                                        "and x.id_lanctoestoque = a.id_lanctoestoque "+
                                        "and x.id_apontamento = " + rApontamento.Id_apontamentostr + " " +
                                        "and x.cd_produto = '"+val.Cd_amostra.Trim()+"')"
                        }
                    }, 1, string.Empty, string.Empty, string.Empty);
                
                //Gravar lote semente X apontamento producao
                TCN_LoteSemente_X_Apontamento.Gravar(
                    new TRegistro_LoteSemente_X_Apontamento()
                    {
                        Id_apontamento = rApontamento.Id_apontamento.Value,
                        Id_lote = val.Id_lote
                    }, qtb_lote.Banco_Dados);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar estorno lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ProcessarApontamentoProducaoLoteSemente(TRegistro_LoteSemente val, decimal Qtd_produzir, BancoDados.TObjetoBanco banco)
        {
            if (val.Qtd_produzir <= 0)
                return; //Não existe mais saldo para produzir sementes no lote
            if (Qtd_produzir > val.Qtd_produzir)
                Qtd_produzir = val.Qtd_produzir;
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Criar lista de formula apontamento
                TList_FormulaApontamento lFormula = TCN_FormulaApontamento.Buscar(val.Cd_empresa,
                                                                                  val.Id_formulacaostr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  qtb_lote.Banco_Dados);
                if(lFormula.Count > 0)
                {
                    //Buscar ficha tecnica mprima
                    lFormula[0].LFichaTec_MPrima = TCN_FichaTec_MPrima.Buscar(val.Cd_empresa,
                                                                              val.Id_formulacaostr,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              qtb_lote.Banco_Dados);
                }
                else
                    throw new Exception("Não existe formula de produção cadatrada no sistema para a empresa "+val.Cd_empresa.Trim()+"\r\n"+
                                        "Id. Formulação "+val.Id_formulacaostr);
                //Quantidade de batidas
                TRegistro_FichaTec_MPrima rMPrima = lFormula[0].LFichaTec_MPrima.Find(p=> p.Cd_produto.Trim().Equals(val.Cd_amostra.Trim()));
                decimal qtd_batch = 1;
                if(rMPrima != null)
                    qtd_batch = TCN_CadConvUnidade.ConvertUnid(val.Cd_unidade, rMPrima.Cd_unidade, Qtd_produzir, 3, qtb_lote.Banco_Dados) / rMPrima.Qtd_produto;
                else
                    throw new Exception("Não existe materia prima "+val.Cd_amostra.Trim());
                //Apontamento de producao
                TRegistro_ApontamentoProducao rApontamento = 
                    new TRegistro_ApontamentoProducao()
                                            {
                                                Cd_empresa = val.Cd_empresa,
                                                Dt_apontamento = val.DT_lote,
                                                Dt_validade = (val.Dt_valgerminacao == null ? val.DT_lote : val.Dt_valgerminacao),
                                                //Id_formulacao = val.Id_formulacao,
                                                LFormulaApontamento = lFormula,
                                                Qtd_batch = qtd_batch
                                            };
                //Calcular Custo MPD
                TCN_ApontamentoProducao.CalcularCustoMPD(rApontamento, qtb_lote.Banco_Dados);
                //Gravar apontamento de producao
                string ret_apontamento = TCN_ApontamentoProducao.Gravar(rApontamento, 
                                                                        //false, 
                                                                        qtb_lote.Banco_Dados);
                //Buscar quantidade de entrada no estoque do produto do lote
                CamadaDados.Estoque.TList_RegLanEstoque lEst =
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_lote.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_prd_apontamento_x_estoque x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.cd_produto = a.cd_produto "+
                                        "and x.id_lanctoestoque = a.id_lanctoestoque "+
                                        "and x.id_apontamento = " + rApontamento.Id_apontamentostr + " " +
                                        "and x.cd_produto = '"+val.Cd_produto.Trim()+"')"
                        }
                    }, 1, string.Empty, string.Empty, string.Empty);
                
                //Gravar lote semente X apontamento producao
                TCN_LoteSemente_X_Apontamento.Gravar(
                    new TRegistro_LoteSemente_X_Apontamento()
                    {
                        Id_apontamento = rApontamento.Id_apontamento.Value,
                        Id_lote = val.Id_lote
                    }, qtb_lote.Banco_Dados);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
                //Deletar analise
                val.lLoteXAnaliseDel.ForEach(p => 
                    {
                        p.Id_lote = val.Id_lote;
                        TCN_LoteSemente_X_TipoAnalise.Excluir(p, qtb_lote.Banco_Dados);
                    });
                //Gravar analise
                val.lLoteXAnalise.ForEach(p =>
                    {
                        p.Id_lote = val.Id_lote;
                        TCN_LoteSemente_X_TipoAnalise.Gravar(p, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Alterar(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if(banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                //Deletar analise
                val.lLoteXAnaliseDel.ForEach(p =>
                {
                    p.Id_lote = val.Id_lote;
                    TCN_LoteSemente_X_TipoAnalise.Excluir(p, qtb_lote.Banco_Dados);
                });
                //Gravar analise
                val.lLoteXAnalise.ForEach(p =>
                {
                    p.Id_lote = val.Id_lote;
                    TCN_LoteSemente_X_TipoAnalise.Gravar(p, qtb_lote.Banco_Dados);
                });
                if(st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar lote: " +ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Verificar se existe nf de destino com status diferente de cancelada para o lote
                object objnf =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(qtb_lote.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_sem_lotesemente_x_nfitem x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                        "and x.tp_movimento = 'D' " + //Destino
                                        "and x.id_lote = " + val.Id_lote.ToString() + ")"
                        }
                    }, "1");
                if (objnf != null)
                    if (objnf.ToString().Trim().Equals("1"))
                        throw new Exception("Não é permitido cancelar lote de semente com movimentação.\r\n" +
                                            "Necessario antes cancelar as notas fiscais amarradas ao lote.");
                //Cancelar apontamento de producao
                val.lApontamento.ForEach(p =>
                    {
                        //Excluir Lote Semente X Apontamento
                        TCN_LoteSemente_X_Apontamento.Excluir(
                            new TRegistro_LoteSemente_X_Apontamento()
                            {
                                Id_apontamento = p.Id_apontamento.Value,
                                Id_lote = val.Id_lote
                            }, qtb_lote.Banco_Dados);
                        TCN_ApontamentoProducao.Deletar(p, qtb_lote.Banco_Dados);
                    });
                //Excluir analises
                val.lLoteXAnaliseDel.ForEach(p =>
                    {
                        p.Id_lote = val.Id_lote;
                        TCN_LoteSemente_X_TipoAnalise.Excluir(p, qtb_lote.Banco_Dados);
                    });
                val.lLoteXAnalise.ForEach(p =>
                    {
                        p.Id_lote = val.Id_lote;
                        TCN_LoteSemente_X_TipoAnalise.Excluir(p, qtb_lote.Banco_Dados);
                    });

                //Cancelar lote semente
                val.St_registro = "C";
                Alterar(val, qtb_lote.Banco_Dados);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar lote semente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void Aprovar(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.St_registro = "P";//Aprovado
                qtb_lote.Gravar(val);
                //Verificar se a empresa nao gera apontamento direto pelo faturamento
                if (!ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", val.Cd_empresa, qtb_lote.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    if (val.lLoteNfItens != null)
                        val.lLoteNfItens.ForEach(p => 
                            {
                                p.Id_lote = val.Id_lote;
                                TCN_LoteSemente_X_NFItem.Gravar(p, qtb_lote.Banco_Dados);
                            });
                    ProcessarApontamentoProducaoLoteSemente(val, val.Qtd_lote, qtb_lote.Banco_Dados);
                }
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro aprovar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void Reprovar(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.St_registro = "R";//Reprovar
                qtb_lote.Gravar(val);
                //Gravar nfs de origem do lote
                val.lLoteNfItens.ForEach(p =>
                {
                    p.Id_lote = val.Id_lote;
                    TCN_LoteSemente_X_NFItem.Gravar(p, qtb_lote.Banco_Dados);
                });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprovar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void Encerrar(TRegistro_LoteSemente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente qtb_lote = new TCD_LoteSemente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                if (val.Id_formestorno != null)
                    ProcessarEstornoLoteSemente(val, 
                                                val.Qtd_saldo, 
                                                qtb_lote.Banco_Dados);
                val.St_registro = "E";//Encerrado
                qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Lote Semente X NFItem"
    public class TCN_LoteSemente_X_NFItem
    {
        public static TList_LoteSemente_X_NFItem Buscar(string Id_lote,
                                                        string Cd_empresa,
                                                        string Nr_lanctofiscal,
                                                        string Id_nfitem,
                                                        int vTop,
                                                        string vNm_campo,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctofiscal.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (Id_nfitem.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            return new TCD_LoteSemente_X_NFItem(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item BuscarNfItem(string Id_lote,
                                                                                                   BancoDados.TObjetoBanco banco)
        {
            if (Id_lote.Trim() != string.Empty)
                return new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_sem_lotesemente_x_nfitem x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                        "and x.id_nfitem = a.id_nfitem "+
                                        "and x.id_lote = "+Id_lote+")"
                        }
                    }, 0, string.Empty, string.Empty, "a.id_nfitem");
            else
                return new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
        }

        public static string Gravar(TRegistro_LoteSemente_X_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_NFItem qtb_lote = new TCD_LoteSemente_X_NFItem();
            try
            {
                if(banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                if(st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens nf do lote semente: " +ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteSemente_X_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_NFItem qtb_lote = new TCD_LoteSemente_X_NFItem();
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
                throw new Exception("Erro excluir itens nf do lote semente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Lote Semente X Apontamento"
    public class TCN_LoteSemente_X_Apontamento
    {
        public static TList_LoteSemente_X_Apontamento Buscar(string Id_lote,
                                                             string Id_apontamento,
                                                             int vTop,
                                                             string vNm_campo,
                                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (Id_apontamento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }
            return new TCD_LoteSemente_X_Apontamento(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_LoteSemente_X_Apontamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_Apontamento qtb_lote = new TCD_LoteSemente_X_Apontamento();
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
                throw new Exception("Erro gravar apontamento lote semente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteSemente_X_Apontamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_Apontamento qtb_lote = new TCD_LoteSemente_X_Apontamento();
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
                throw new Exception("Erro excluir apontamento lote semente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Lote Semente X Tipo Analise"
    public class TCN_LoteSemente_X_TipoAnalise
    {
        public static TList_LoteSemente_X_TipoAnalise Buscar(string Id_analise,
                                                             string Id_lote,
                                                             int vTop,
                                                             string vNm_campo,
                                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_analise.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_analise";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_analise;
            }
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            return new TCD_LoteSemente_X_TipoAnalise(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Sementes.Cadastros.TList_TipoAnalise BuscarAnalises(string Id_lote,
                                                                                      BancoDados.TObjetoBanco banco)
        {
            if (Id_lote.Trim() != string.Empty)
                return new CamadaDados.Sementes.Cadastros.TCD_TipoAnalise(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_sem_lotesemente_x_tipoanalise x "+
                                        "where x.id_analise = a.id_analise "+
                                        "and x.id_lote = " + Id_lote + ")"
                        }
                    }, 0, string.Empty);
            else
                return new CamadaDados.Sementes.Cadastros.TList_TipoAnalise();
        }

        public static string Gravar(TRegistro_LoteSemente_X_TipoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_TipoAnalise qtb_lote = new TCD_LoteSemente_X_TipoAnalise();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteSemente_X_TipoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteSemente_X_TipoAnalise qtb_lote = new TCD_LoteSemente_X_TipoAnalise();
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
                throw new Exception("Erro deletar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion
}

using System;
using System.Linq;
using Utils;
using CamadaDados.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Caixa;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Bloqueto
{
    #region Lote Bloqueto
    public class TCN_LoteBloqueto
    {
        public static TList_LoteBloqueto Buscar(string Id_lote,
                                                string Ds_lote,
                                                string Cd_empresa,
                                                string Id_config,
                                                string dt_ini,
                                                string dt_fin,
                                                string St_registro,
                                                int vTop,
                                                string vNm_campo,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote.ToString();
            }
            if (!string.IsNullOrEmpty(Ds_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_lote";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_lote.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_config";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_config;
            }

            if (!string.IsNullOrEmpty(dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_processamento"+ ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }

            if (!string.IsNullOrEmpty(dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_processamento" + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if(!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_LoteBloqueto(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_LoteBloqueto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteBloqueto qtb_lote = new TCD_LoteBloqueto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar Lote
                string retorno = qtb_lote.Gravar(val);
                //Deletar Bloquetos
                val.lBloquetosExcluir.ForEach(p =>
                {
                    TCN_Lote_X_Titulo.Excluir(new TRegistro_Lote_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = val.Id_lote.Value,
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados);
                    //Verificar se o bloqueto tem liquidacao
                    object obj = new CamadaDados.Financeiro.Duplicata.TCD_LanLiquidacao(qtb_lote.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'",
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lancto",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_lancto.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_parcela",
                                            vOperador = "=",
                                            vVL_Busca = p.Cd_parcela.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, "1");
                    if (obj != null)
                        if (obj.ToString().Equals("1"))
                            p.St_registro = "C";
                        else
                            p.St_registro = "A";
                    else
                        p.St_registro = "A";
                    TCN_Titulo.Gravar(p, qtb_lote.Banco_Dados);
                });
                //Gravar Bloquetos
                val.ListaBloqueto.ForEach(p =>
                {
                    TCN_Lote_X_Titulo.Gravar(new TRegistro_Lote_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE")),
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados);
                });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
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
        
        public static string ProcessarLote(TRegistro_LoteBloqueto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteBloqueto qtb_lote = new TCD_LoteBloqueto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Lancamento de caixa no valor liquido
                //Buscar historico na configuracao do banco
                TList_CadCFGBanco lCfg = Cadastros.TCN_CadCFGBanco.Buscar(val.Id_configstr,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          1,
                                                                          qtb_lote.Banco_Dados);
                if (lCfg.Count > 0)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Cd_historico_desconto))
                        throw new Exception("Não existe configuração de historico para desconto de bloquetos\r\n" +
                                            "para a configuração " + val.Ds_config.Trim());
                    decimal total_bloquetos = val.ListaBloqueto.Sum(p => p.Vl_documento);
                    string retorno = TCN_LanCaixa.GravaLanCaixa(
                                        new TRegistro_LanCaixa()
                                        {
                                            Cd_ContaGer = val.Cd_contager,
                                            Cd_Empresa = val.Cd_empresa,
                                            Cd_Historico = lCfg[0].Cd_historico_desconto,
                                            ComplHistorico = "DESCONTO DE BLOQUETOS DO LOTE " + val.Id_lotestr,
                                            Dt_lancto = val.Dt_processamento,
                                            Nr_Docto = "LOTE" + val.Id_lotestr,
                                            St_Estorno = "N",
                                            Vl_PAGAR = 0,
                                            Vl_RECEBER = total_bloquetos
                                        }, qtb_lote.Banco_Dados);
                    //Amarrar este lancamento de caixa ao lote
                    //com o campo TP_Registro = D (DESCONTO)
                    TCN_Bloqueto_X_Caixa.Gravar(new TRegistro_Lote_X_Caixa()
                    {
                        Cd_contager = val.Cd_contager,
                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA")),
                        Id_lote = val.Id_lote.Value,
                        Tp_registro = "D"
                    }, qtb_lote.Banco_Dados);
                    //Lancar Taxa
                    if(string.IsNullOrEmpty(lCfg[0].Cd_historico_taxadesc))
                        throw new Exception("Não existe configuração de historico para taxa desconto de bloquetos\r\n" +
                                            "para a configuração " + val.Ds_config.Trim());
                    retorno = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                {
                                    Cd_ContaGer = val.Cd_contager,
                                    Cd_Empresa = val.Cd_empresa,
                                    Cd_Historico = lCfg[0].Cd_historico_taxadesc,
                                    ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + val.Id_lotestr,
                                    Dt_lancto = val.Dt_processamento,
                                    Nr_Docto = "LOTE" + val.Id_lote,
                                    St_Estorno = "N",
                                    Vl_PAGAR = val.Vl_taxa,
                                    Vl_RECEBER = decimal.Zero
                                }, qtb_lote.Banco_Dados);
                    //Amarrar este lancamento de caixa ao lote
                    //com o campo TP_Registro = T (TAXA)
                    TCN_Bloqueto_X_Caixa.Gravar(new TRegistro_Lote_X_Caixa()
                    {
                        Cd_contager = val.Cd_contager,
                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA")),
                        Id_lote = val.Id_lote.Value,
                        Tp_registro = "T"
                    }, qtb_lote.Banco_Dados);
                    //Gravar centro resultado taxa cobrança
                    if (!string.IsNullOrEmpty(lCfg[0].Cd_centroresultTXCob))
                    {
                        //Gravar Lancto Resultado
                        string id = CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresultTXCob,
                                Vl_lancto = val.Vl_taxa,
                                Dt_lancto = val.Dt_processamento
                            }, qtb_lote.Banco_Dados);
                        //Amarrar Lancto a Caixa
                        TCN_Caixa_X_CCusto.Gravar(new TRegistro_Caixa_X_CCusto()
                        {
                            Cd_contager = val.Cd_contager,
                            Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA")),
                            Id_ccustolan = decimal.Parse(id)
                        }, qtb_lote.Banco_Dados);
                    }
                    val.ListaBloqueto.ForEach(p => 
                        {
                            //Alterar status dos bloquetos para D - Descontado
                            p.St_registro = "D";
                            TCN_Titulo.Gravar(p, qtb_lote.Banco_Dados);
                            //Criar lista de lote x titulo
                            val.lBloquetos.Add(new TRegistro_Lote_X_Titulo()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Cd_parcela = p.Cd_parcela,
                                Id_cobranca = p.Id_cobranca,
                                Id_lote = val.Id_lote.Value,
                                Nr_lancto = p.Nr_lancto,
                                Vl_documento = p.Vl_documento
                            });
                        });
                    //Calcular valor taxa por bloqueto
                    val.lBloquetos.ForEach(p => p.Vl_taxa = Math.Round(((val.Vl_taxa / total_bloquetos) * p.Vl_documento), 2));
                    decimal total_taxa = val.lBloquetos.Sum(p => p.Vl_taxa);
                    if (val.Vl_taxa != total_taxa)
                        val.lBloquetos[val.lBloquetos.Count - 1].Vl_taxa += (val.Vl_taxa - total_taxa);
                    //Gravar lote x titulo com o valor da taxa
                    val.lBloquetos.ForEach(p => TCN_Lote_X_Titulo.Gravar(p, qtb_lote.Banco_Dados));
                    //Limpar lista de bloquetos para
                    //que a gravacao do lote nao altere 
                    //novamente a lista de bloquetos
                    val.ListaBloqueto.Clear();
                    //Alterar status do lote para processado
                    val.St_registro = "P";
                    Gravar(val, qtb_lote.Banco_Dados);
                    if (st_transacao)
                        qtb_lote.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                else
                    throw new Exception("Não existe configuração para emissão de bloquetos para a empresa " + val.Cd_empresa.Trim() +
                                        " e conta gerencial " + val.Cd_contager.Trim());
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

        public static void EstornarLote(TRegistro_LoteBloqueto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteBloqueto qtb_lote = new TCD_LoteBloqueto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Inicio do processo de estornar lote
                if (val.St_registro.Trim().ToUpper().Equals("P"))
                {
                    if (val.ListaCaixa.Count > 0)
                    { 
                        //Verificar se nao existe alguma parcela que originou bloqueto ja liquidada
                        foreach (var p in val.ListaBloqueto)
                        {
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcela =
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela(qtb_lote.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "in",
                                        vVL_Busca = "('L', 'P')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(d.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'A'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and x.cd_parcela = a.cd_parcela " +
                                                    "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "'" +
                                                    "and x.nr_lancto = " + p.Nr_lancto.ToString() +
                                                    "and x.cd_parcela = " + p.Cd_parcela.ToString() + ")"
                                    }
                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            if (lParcela.Count > 0)
                                throw new Exception("Lote não podera ser estornado, existe parcela com liquidação.\r\n\r\n" +
                                                    "Empresa: " + p.Cd_empresa.Trim() + "\r\n" +
                                                    "Duplicata: " + p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString() + "\r\n\r\n" +
                                                    "Obrigatorio estornar primeiro a liquidação.");

                        }
                        
                        val.ListaCaixa.ForEach(p =>
                            {
                                //Excluir registro Lote X Caixa
                                TCN_Bloqueto_X_Caixa.Excluir(new TRegistro_Lote_X_Caixa()
                                {
                                    Cd_contager = p.Cd_ContaGer,
                                    Cd_lanctocaixa = p.Cd_LanctoCaixa,
                                    Id_lote = val.Id_lote.Value
                                }, qtb_lote.Banco_Dados);
                                //Chamar metodo estorno de caixa
                                Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_lote.Banco_Dados);
                            });
                        //Alterar o valor da taxa no bloquetos
                        val.ListaBloqueto.ForEach(p => TCN_Lote_X_Titulo.Gravar(new TRegistro_Lote_X_Titulo()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_parcela = p.Cd_parcela,
                            Id_cobranca = p.Id_cobranca,
                            Id_lote = val.Id_lote.Value,
                            Nr_lancto = p.Nr_lancto,
                            Vl_taxa = 0
                        }, qtb_lote.Banco_Dados));
                        //Alterar o lote
                        val.St_registro = "A";
                        val.Vl_taxa = 0;
                        qtb_lote.Gravar(val);
                        if (st_transacao)
                            qtb_lote.Banco_Dados.Commit_Tran();
                    }
                    else
                        throw new Exception("Não existe lançamento de caixa para ser estornado.");
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
        
        public static string Excluir(TRegistro_LoteBloqueto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteBloqueto qtb_lote = new TCD_LoteBloqueto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Alterar o status dos bloquetos para A - Ativo
                val.ListaBloqueto.ForEach(p =>
                {
                    p.St_registro = "A";
                    TCN_Titulo.Gravar(p, qtb_lote.Banco_Dados);
                    //Deletar tabela lote X titulo
                    TCN_Lote_X_Titulo.Excluir(new TRegistro_Lote_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = val.Id_lote.Value,
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados);
                });
                val.lBloquetosExcluir.ForEach(p =>
                {
                    p.St_registro = "A";
                    TCN_Titulo.Gravar(p, qtb_lote.Banco_Dados);
                    //Deletar tabela lote X titulo
                    TCN_Lote_X_Titulo.Excluir(new TRegistro_Lote_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = val.Id_lote.Value,
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados);
                });
                //Deletar Lote
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
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
    }
    #endregion

    #region Lote Bloqueto X Titulo
    public class TCN_Lote_X_Titulo
    {
        public static TList_Lote_X_Titulo Buscar(decimal? id_lote,
                                                 string cd_empresa,
                                                 decimal? nr_lancto,
                                                 decimal? id_parcela,
                                                 decimal? id_cobranca,
                                                 int vTop,
                                                 string vNm_campo,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (id_lote != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_lote.Value.ToString();
            }
            if (cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (nr_lancto != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_lancto.Value.ToString();
            }
            if (id_parcela != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_parcela.Value.ToString();
            }
            if (id_cobranca != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cobranca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cobranca.Value.ToString();
            }
            return new TCD_Lote_X_Titulo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static blListaTitulo BuscarBloquetos(decimal? Id_lote,
                                               int vTop,
                                               string vNm_campo,
                                               BancoDados.TObjetoBanco banco)
        {
            if (Id_lote != null)
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = string.Empty;
                filtro[0].vOperador = "exists";
                filtro[0].vVL_Busca = "(select 1 from tb_cob_lote_x_titulo x " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.nr_lancto = a.nr_lancto " +
                                      "and x.cd_parcela = a.cd_parcela " +
                                      "and x.id_cobranca = a.id_cobranca " +
                                      "and x.id_lote = " + Id_lote.Value.ToString() + ")";
                return new TCD_Titulo(banco).Select(filtro, vTop, vNm_campo);
            }
            else
                return new blListaTitulo();
        }

        public static string Gravar(TRegistro_Lote_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Titulo qtb_lote = new TCD_Lote_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar Lote X Titulo
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static void GravarTitulosLote(TList_Lote_X_Titulo lTitulos, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Titulo qtb_lote = new TCD_Lote_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                lTitulos.ForEach(p => qtb_lote.Gravar(p));
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro incluir titulos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lote_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Titulo qtb_lote = new TCD_Lote_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Deletar Lote X Titulo
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
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
    }
    #endregion

    #region Lote Bloqueto X Caixa
    public class TCN_Bloqueto_X_Caixa
    {
        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixa(decimal Id_lote,
                                                                              int vTop,
                                                                              string vNm_campo,
                                                                              BancoDados.TObjetoBanco banco)
        {
            if (Id_lote > 0)
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = string.Empty;
                filtro[0].vOperador = "exists";
                filtro[0].vVL_Busca = "(select 1 from tb_cob_lote_x_caixa x " +
                                      "where x.cd_contager = a.cd_contager " +
                                      "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                      "and x.id_lote = " + Id_lote.ToString() + ")";
                return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(banco).Select(filtro, vTop, vNm_campo);
            }
            else
                return new CamadaDados.Financeiro.Caixa.TList_LanCaixa();
        }

        public static string Gravar(TRegistro_Lote_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Caixa qtb_lote = new TCD_Lote_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar Lote X Caixa
                string retorno = qtb_lote.GravarLote_X_Caixa(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static string Excluir(TRegistro_Lote_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Caixa qtb_lote = new TCD_Lote_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Deletar Bloqueto X Caixa
                qtb_lote.DeletarLote_X_Caixa(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
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
    }
    #endregion
}

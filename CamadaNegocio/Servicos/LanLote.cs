using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public static class TCN_LoteOS
    {
        public static TList_LoteOS Buscar(string Id_lote,
                                   string Cd_fornecedor,
                                   string Cd_endfornecedor,
                                   string Ds_lote,
                                   string Ds_observacao,
                                   string St_registro,
                                   string Cd_cliforOS,
                                   string Cd_produtoOS,
                                   string Nr_nfremessa,
                                   string Nr_nfretorno,
                                   int vTop,
                                   string vNm_campo,
                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (Cd_endfornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endfornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endfornecedor.Trim() + "'";
            }
            if (Ds_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_lote";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_lote.Trim() + "%')";
            }
            if (Ds_observacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (Cd_cliforOS.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_servico y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_os = y.id_os " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and y.cd_clifor = '" + Cd_cliforOS.Trim() + "')";
            }
            if (Cd_produtoOS.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_servico y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_os = y.id_os " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and y.cd_produtoOS = '" + Cd_produtoOS.Trim() + "')";
            }
            if (Nr_nfremessa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                      "inner join tb_fat_notafiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_pedido = a.nr_pedido " +
                                                      "and y.nr_notafiscal = " + Nr_nfremessa + ")";
            }
            if (Nr_nfretorno.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                      "inner join tb_fat_notafiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_pedido = a.nr_pedido " +
                                                      "and y.nr_notafiscal = " + Nr_nfretorno + ")";
            }

            return new TCD_LoteOS(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarLoteOS(TRegistro_LoteOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteOS qtb_lote = new TCD_LoteOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar lote OS
                string retorno = qtb_lote.GravarLoteOS(val);
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
                //Deletar Lote X Servicos
                val.lOsDel.ForEach(p =>
                    {
                        TCN_Lote_X_Servicos.DeletarLote_X_Servicos(new TRegistro_Lote_X_Servicos()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_lote = val.Id_lote,
                            Id_os = p.Id_os
                        }, qtb_lote.Banco_Dados);
                    });
                //Gravar Lote X Servicos
                val.lOs.ForEach(p =>
                    {
                        TCN_Lote_X_Servicos.GravarLote_X_Servicos(new TRegistro_Lote_X_Servicos()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_lote = val.Id_lote,
                            Id_os = p.Id_os
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
                throw new Exception("Erro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ProcessarLoteOS(TRegistro_LoteOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteOS qtb_lote = new TCD_LoteOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                
                if (val.St_gerarpedidoremessa)
                {
                    //Buscar config. os para gerar pedido de remessa de envio de mercadoria para conserto
                    CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                        CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(val.lOs[0].Tp_ordemstr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                qtb_lote.Banco_Dados);
                    if (lParam.Count > 0)
                    {
                        if (lParam[0].Cfg_pedido_transpremessaenvio.Trim().Equals(string.Empty))
                            throw new Exception("Não existe configuração de remessa de envio para o tipo de ordem serviço: " + val.lOs[0].Tp_ordemstr.Trim());
                        if (lParam[0].Cd_moeda.Trim().Equals(string.Empty))
                            throw new Exception("Não existe configuração de moeda para o tipo de ordem serviço: " + val.lOs[0].Tp_ordemstr.Trim());
                        //Gerar pedido de remessa
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido pedido = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                        pedido.CD_Empresa = val.Cd_empresa;
                        pedido.DT_Pedido = val.Dt_enviolote;
                        pedido.TP_Movimento = "S";
                        pedido.CFG_Pedido = lParam[0].Cfg_pedido_transpremessaenvio;
                        pedido.CD_Clifor = val.Cd_fornecedor;
                        pedido.CD_Endereco = val.Cd_endfornecedor;
                        pedido.CD_TRANSPORTADORA = lParam[0].Cd_transportadora;
                        pedido.CD_ENDERECOTRANSP = lParam[0].Cd_enderecoTransp;
                        pedido.ST_Pedido = "F";
                        pedido.ST_Registro = "F";
                        pedido.Cd_moeda = lParam[0].Cd_moeda;
                        //Itens do pedido
                        pedido.Pedido_Itens = val.lItensPedido;
                        string ret_ped = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(pedido, qtb_lote.Banco_Dados);
                        val.Nr_pedido = Convert.ToDecimal(ret_ped);
                    }
                    else
                        throw new Exception("Não existe configuração para o tipo de ordem serviço: " + val.lOs[0].Tp_ordemstr.Trim());
                }
                //Gravar lote
                val.St_registro = "P";
                GravarLoteOS(val, qtb_lote.Banco_Dados);
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

        public static void EstornarProcessamentoLoteOS(TRegistro_LoteOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteOS qtb_lote = new TCD_LoteOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Verificar se o pedido amarrado ao lote nao esta cancelado
                object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_lote x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_empresa = '"+val.Cd_empresa.Trim() + "' " +
                                        "and x.id_lote = "+val.Id_lotestr + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_pedido, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, "a.nr_pedido");
                if (obj != null)
                    throw new Exception("Para estornar processamento do lote é necessario cancelar antes o pedido " + obj.ToString() + ".");
                //Voltar status do lote para A - Aberto
                val.St_registro = "A";
                qtb_lote.GravarLoteOS(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string DeletarLoteOS(TRegistro_LoteOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteOS qtb_lote = new TCD_LoteOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Verificar se o lote ja se encontra processado
                if (val.St_registro.Trim().ToUpper().Equals("P"))
                {
                    //Verificar se o pedido de remessa esta cancelado
                    object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_ose_lote x "+
                                                        "where a.nr_pedido = x.nr_pedido "+
                                                        "and x.nr_pedido = "+val.Nr_pedido.Value.ToString()+")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_pedido, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, "NR_Pedido");
                    if (obj != null)
                        throw new Exception("Para cancelar o lote e necessario cancelar antes o pedido de remessa.\r\n" +
                                            "Pedido Remessa Nº " + obj.ToString().Trim());
                }
                //Deletar Lote X Servicos
                val.lOs.ForEach(p =>
                    {
                        TCN_Lote_X_Servicos.DeletarLote_X_Servicos(new TRegistro_Lote_X_Servicos()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_lote = val.Id_lote,
                            Id_os = p.Id_os
                        }, qtb_lote.Banco_Dados);
                    });
                val.lOsDel.ForEach(p =>
                    {
                        TCN_Lote_X_Servicos.DeletarLote_X_Servicos(new TRegistro_Lote_X_Servicos()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_lote = val.Id_lote,
                            Id_os = p.Id_os
                        }, qtb_lote.Banco_Dados);
                    });
                //Deletar Lote
                qtb_lote.DeletarLoteOS(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
}

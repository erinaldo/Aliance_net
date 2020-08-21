using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Servicos;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanServicoPecas
    {
        public static TList_LanServicosPecas Buscar(string vId_os,
                                                    string vCd_empresa,
                                                    string vId_peca,
                                                    string vCd_produto,
                                                    string vCd_local,
                                                    decimal vQuantidade,
                                                    decimal vVl_unitario,
                                                    decimal vVl_subtotal,
                                                    decimal vVl_desconto,
                                                    decimal vPc_desconto,
                                                    string vDs_observacao,
                                                    string vNm_campo,
                                                    bool vST_Registro,
                                                    int vTop,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                filtro[filtro.Length - 1].vVL_Busca = vId_os;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vId_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Peca";
                filtro[filtro.Length - 1].vVL_Busca = vId_peca;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_local.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_local.Trim() + "'";
            }
            if (vQuantidade > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Quantidade";
                filtro[filtro.Length - 1].vVL_Busca = vQuantidade.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_unitario > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Unitario";
                filtro[filtro.Length - 1].vVL_Busca = vVl_unitario.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_subtotal > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_SubTotal";
                filtro[filtro.Length - 1].vVL_Busca = vVl_subtotal.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_desconto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Desconto";
                filtro[filtro.Length - 1].vVL_Busca = vVl_desconto.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vPc_desconto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.PC_Desconto";
                filtro[filtro.Length - 1].vVL_Busca = vPc_desconto.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vDs_observacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Observacao";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_observacao.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }

            if (vST_Registro == true)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_Registro";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
            }

            TCD_LanServicosPecas qtb_pecas = new TCD_LanServicosPecas();
            qtb_pecas.Banco_Dados = banco;
            return qtb_pecas.Select(filtro, vTop, vNm_campo, string.Empty);
        }

        public static string Gravar(TRegistro_LanServicosPecas val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicosPecas qtb_pecas = new TCD_LanServicosPecas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else
                    qtb_pecas.Banco_Dados = banco;
                
                string retorno = qtb_pecas.Gravar(val);
                val.Id_pecastr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_PECA");
                //Excluir Ficha
                val.lFichaTecOSDel.ForEach(p=> TCN_FichaTecOS.Excluir(p, qtb_pecas.Banco_Dados));
                //Gravar Ficha
                val.lFichaTecOS.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        p.Id_peca = val.Id_peca;
                        TCN_FichaTecOS.Gravar(p, qtb_pecas.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar peças/serviços: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanServicosPecas val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicosPecas qtb_pecas = new TCD_LanServicosPecas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else
                    qtb_pecas.Banco_Dados = banco;
                //Verificar se peca teve origem orcamento venda
                CamadaDados.Faturamento.Orcamento.TList_Orcamento_X_OS lOrc =
                    new CamadaDados.Faturamento.Orcamento.TCD_Orcamento_X_OS(qtb_pecas.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = val.Id_osstr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_peca",
                            vOperador = "=",
                            vVL_Busca = val.Id_pecastr
                        }
                    }, 0, string.Empty);
                lOrc.ForEach(p =>
                    {
                        //Excluir registro
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_X_OS.Excluir(p, qtb_pecas.Banco_Dados);
                        //Verificar se o orcamento nao possui pedido
                        CamadaDados.Faturamento.Orcamento.TList_Orcamento lOrcamento =
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(p.Nr_orcamentostr,
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
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     false,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     false,
                                                                                     qtb_pecas.Banco_Dados);
                        if(lOrcamento.Count > 0)
                            if(!lOrcamento[0].Nr_pedidovenda.HasValue)
                            {
                                lOrcamento[0].St_registro = "AB";
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(lOrcamento[0], qtb_pecas.Banco_Dados);
                            }
                    });
                //Excluir Ficha Tecnica Item
                TCN_FichaTecOS.Buscar(val.Cd_empresa,
                                      val.Id_osstr,
                                      val.Id_pecastr,
                                      string.Empty,
                                      qtb_pecas.Banco_Dados).ForEach(p => TCN_FichaTecOS.Excluir(p, qtb_pecas.Banco_Dados));

                //Excluir movimentações geradas em TB_FAT_CompraItens_X_PecaOS
                Faturamento.CompraAvulsa.TCN_CompraItens_X_PecaOS.Buscar(val.Cd_empresa,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         qtb_pecas.Banco_Dados,
                                                                         val.Id_osstr,
                                                                         val.Id_pecastr)
                    .ForEach(r => Faturamento.CompraAvulsa.TCN_CompraItens_X_PecaOS.Excluir(r, qtb_pecas.Banco_Dados));

                qtb_pecas.Excluir(val);
                
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir peça/serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }

        public static TList_FichaTecOS MontarFichaTecOS(string Cd_produto,
                                                                  string Cd_empresa,
                                                                  decimal Quantidade,
                                                                  BancoDados.TObjetoBanco banco)
        {
            //Buscar ficha tecnica do produto
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(Cd_produto,
                                                                           string.Empty,
                                                                           banco);
            if (lFicha.Count > 0)
            {
                TList_FichaTecOS lFichaOrc = new TList_FichaTecOS();
                lFicha.ForEach(p =>
                {
                    lFichaOrc.Add(new TRegistro_FichaTecOS()
                    {
                        Cd_item = p.Cd_item,
                        Ds_item = p.Ds_item,
                        Quantidade = p.Quantidade * Quantidade,
                    });
                });
                return lFichaOrc;
            }
            else
                throw new Exception("Não existe ficha tecnica cadastrada para o produto " + Cd_produto.Trim());
        }
    }

    public class TCN_Pecas_X_PreVenda
    {
        public static TList_Pecas_X_PreVenda Buscar(string Id_os,
                                                    string Cd_empresa,
                                                    string Id_peca,
                                                    string Id_prevenda,
                                                    string Id_itemprevenda,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            return new TCD_Pecas_X_PreVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Pecas_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pecas_X_PreVenda qtb_peca = new TCD_Pecas_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_peca.CriarBanco_Dados(true);
                else
                    qtb_peca.Banco_Dados = banco;
                string retorno = qtb_peca.Gravar(val);
                if (st_transacao)
                    qtb_peca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_peca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_peca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pecas_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pecas_X_PreVenda qtb_peca = new TCD_Pecas_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_peca.CriarBanco_Dados(true);
                else
                    qtb_peca.Banco_Dados = banco;
                qtb_peca.Excluir(val);
                if (st_transacao)
                    qtb_peca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_peca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_peca.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Pecas_X_NFCe
    {
        public static TList_Pecas_X_NFCe Buscar(string Cd_empresa,
                                                string Id_os,
                                                string Id_peca,
                                                string Id_cupom,
                                                string Id_lancto,
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
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            return new TCD_Pecas_X_NFCe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Pecas_X_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pecas_X_NFCe qtb_pecas = new TCD_Pecas_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else qtb_pecas.Banco_Dados = banco;
                string ret = qtb_pecas.Gravar(val);
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pecas_X_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pecas_X_NFCe qtb_pecas = new TCD_Pecas_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else qtb_pecas.Banco_Dados = banco;
                qtb_pecas.Excluir(val);
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }
    }

    public class TCN_OSEEstoque
    {
        public static TList_OSEEstoque Buscar(string Cd_empresa,
                                              string Id_os,
                                              string Id_peca,
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
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            return new TCD_OSEEstoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OSEEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSEEstoque qtb_ose = new TCD_OSEEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                string retorno = qtb_ose.Gravar(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OSEEstoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSEEstoque qtb_ose = new TCD_OSEEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                qtb_ose.Excluir(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FichaTecOS
    {
        public static TList_FichaTecOS Buscar(string Cd_empresa,
                                              string Id_os,
                                              string Id_peca,
                                              string Cd_item,
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
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }
            return new TCD_FichaTecOS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTecOS val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOS qtb_ose = new TCD_FichaTecOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                string retorno = qtb_ose.Gravar(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar FICHA TÉCNICA OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTecOS val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOS qtb_ose = new TCD_FichaTecOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                qtb_ose.Excluir(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir FICHA TÉCNICA 0S: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FichaTec_X_Estoque
    {
        public static TList_FichaTec_X_Estoque Buscar(string Cd_empresa,
                                              string Id_os,
                                              string Id_peca,
                                              string Cd_item,
                                              string Cd_produto,
                                              string Id_lanctoestoque,
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
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lanctoestoque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lanctoestoque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoestoque;
            }
            return new TCD_FichaTec_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTec_X_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec_X_Estoque qtb_ose = new TCD_FichaTec_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                string retorno = qtb_ose.Gravar(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar FICHA TÉCNICA OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTec_X_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec_X_Estoque qtb_ose = new TCD_FichaTec_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ose.CriarBanco_Dados(true);
                else qtb_ose.Banco_Dados = banco;
                qtb_ose.Excluir(val);
                if (st_transacao)
                    qtb_ose.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ose.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir FICHA TÉCNICA 0S: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ose.deletarBanco_Dados();
            }
        }
    }
}

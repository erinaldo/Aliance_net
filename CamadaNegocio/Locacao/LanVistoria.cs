using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Locacao;
using Utils;

namespace CamadaNegocio.Locacao
{
    public class TCN_Vistoria
    {
        public static TList_Vistoria buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_itemloc,
                                             string Id_vistoria,
                                             string tp_mov,
                                             string vDt_ini,
                                             string vDt_fin,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_vistoria))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_vistoria";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_vistoria;
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vistoria)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datime, floor(convert(decimal(30,10), a.dt_vistoria)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(tp_mov))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_mov";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + tp_mov.Trim() + ")";
            }
            return new TCD_Vistoria(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vistoria val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vistoria qtb_locacao = new TCD_Vistoria();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.Id_vistoriastr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_VISTORIA");
                //Excluir Imagens
                val.lImagensDel.ForEach(p => TCN_ImagensVistoria.Excluir(p, qtb_locacao.Banco_Dados));
                //Gravar Imagens
                val.lImagens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_locacao = val.Id_locacao;
                        p.Id_itemloc = val.Id_itemloc;
                        p.Id_vistoria = p.Id_vistoria;
                        TCN_ImagensVistoria.Gravar(p, qtb_locacao.Banco_Dados);
                    });
                //Gravar Vistoria_X_ColEnt
                TCN_Vistoria_X_ColEnt.Gravar(
                    new TRegistro_Vistoria_X_ColEnt()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_coletastr = val.Id_coleta,
                        Id_locacao = val.Id_locacao,
                        Id_itemloc = val.Id_itemloc,
                        Id_vistoria = val.Id_vistoria
                    }, qtb_locacao.Banco_Dados);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_vistoriastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vistoria: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vistoria val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vistoria qtb_loc = new TCD_Vistoria();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir vistoria: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ImagensVistoria
    {
        public static TList_ImagensVistoria buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_itemloc,
                                             string Id_vistoria,
                                             string Id_imagem,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_vistoria))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_vistoria";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_vistoria;
            }
            if (!string.IsNullOrEmpty(Id_imagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_imagem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_imagem;
            }
            return new TCD_ImagensVistoria(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ImagensVistoria val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImagensVistoria qtb_locacao = new TCD_ImagensVistoria();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                string retorno = qtb_locacao.Grava(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar imagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ImagensVistoria val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImagensVistoria qtb_loc = new TCD_ImagensVistoria();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                qtb_loc.Deleta(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir imagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Vistoria_X_ColEnt
    {
        public static TList_Vistoria_X_ColEnt buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_itemloc,
                                             string Id_vistoria,
                                             string Id_coleta,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_vistoria))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_vistoria";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_vistoria;
            }
            if (!string.IsNullOrEmpty(Id_coleta))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_coleta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_coleta;
            }
            return new TCD_Vistoria_X_ColEnt(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vistoria_X_ColEnt val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vistoria_X_ColEnt qtb_locacao = new TCD_Vistoria_X_ColEnt();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                string retorno = qtb_locacao.Gravar(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vistoria: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vistoria_X_ColEnt val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vistoria_X_ColEnt qtb_loc = new TCD_Vistoria_X_ColEnt();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir vistoria: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ColetaEntrega
    {
        public static TList_ColetaEntrega buscar(string Cd_empresa,
                                             string Id_coleta,
                                             string Id_veiculo,
                                             string Cd_motorista,
                                             string tp_mov,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_coleta))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_coleta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_coleta;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_motorista";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(tp_mov))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_mov";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + tp_mov.Trim() + ")";
            }
            return new TCD_ColetaEntrega(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ColetaEntrega val, TRegistro_Locacao rLoc, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ColetaEntrega qtb_locacao = new TCD_ColetaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.Id_coletastr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_COLETA");
                //Gravar Vistoria
                val.lVistoria.ForEach(p =>
                    {
                        p.Id_coleta = val.Id_coletastr;
                        TCN_Vistoria.Gravar(p, qtb_locacao.Banco_Dados);
                    });
                //Gravar Itens Locação
                if (rLoc.lItens != null)
                {
                    if (rLoc.lItens.Count > 0)
                        rLoc.lItens.FindAll(p => p.St_processar).ForEach(p =>
                        {
                            if (val.Tp_mov.ToUpper().Equals("E"))
                                p.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                            else
                            {
                                p.Dt_devolucao = string.IsNullOrEmpty(p.Dt_devolucaostr) ? CamadaDados.UtilData.Data_Servidor() : p.Dt_devolucao;
                                //Gravar devolução de patrimonio
                                TCN_DevItensLocacao.Gravar(new TRegistro_DevItensLocacao()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Id_locacao = p.Id_locacao,
                                    Id_itemloc = p.Id_itemloc,
                                    Qtd_baixada = p.St_baixa ? p.SaldoDevolver : decimal.Zero,
                                    Qtd_devolvida = p.Qtd_devolver > 0 ? p.Qtd_devolver : p.QTDItem
                                }, qtb_locacao.Banco_Dados);
                                //Verificar se Patrimonio é quantidade 1 para cancelar senão pular processo
                                if (p.St_baixa)
                                {
                                    System.Collections.Hashtable hs = new System.Collections.Hashtable();
                                    hs.Add("@SALDO", p.SaldoDevolver);
                                    hs.Add("@PRODUTO", p.Cd_produto);
                                    qtb_locacao.executarSql(p.Qtd_Patrimonio > 1 ? "update TB_EST_Patrimonio set Quantidade = Quantidade - @SALDO " +
                                                            "where cd_patrimonio = @PRODUTO " +
                                                            "and quantidade > 1 " :
                                                            "update TB_EST_Produto set St_registro = 'C' " +
                                                            "where cd_produto = @PRODUTO ", hs);
                                }
                            }
                            //Gravar Itens
                            TCN_ItensLocacao.Gravar(p, qtb_locacao.Banco_Dados);
                        });
                    //Gravar Locação
                    if (val.Tp_mov.Trim().ToUpper().Equals("E"))
                    {
                        rLoc.St_registro = "2";
                        //Mudar Status para ENTREGUE
                        qtb_locacao.executarSql("update TB_LOC_Locacao set st_registro = '" + rLoc.St_registro + "', dt_alt = getdate() " +
                                                "where isnull(ST_Registro, '0') = '0' " +
                                                "and ID_Locacao = " + rLoc.Id_locacaostr, null);
                    }
                    else
                    {
                        //Verificar se tem item com data de devolucao null
                        if (new TCD_ItensLocacao(qtb_locacao.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rLoc.Cd_empresa.Trim() + "'"},
                                new TpBusca{vNM_Campo = "a.id_locacao", vOperador = "=", vVL_Busca = rLoc.Id_locacaostr},
                                new TpBusca{vNM_Campo = "a.dt_devolucao", vOperador = "is",vVL_Busca = "null"}
                            }, "1") != null)
                        {
                            if (rLoc.St_registro.Trim().Equals("2"))
                            {
                                rLoc.St_registro = "10";
                                //Trocar status para devolucao parcial
                                qtb_locacao.executarSql("update TB_LOC_Locacao set st_registro = '" + rLoc.St_registro + "', dt_alt = getdate() " +
                                                        "where ID_Locacao = " + rLoc.Id_locacaostr, null);
                            }
                            else if (rLoc.St_registro.Trim().Equals("3") || rLoc.St_registro.Trim().Equals("4"))
                            {
                                rLoc.St_registro = "6";
                                //Trocar status para devolucao parcial
                                qtb_locacao.executarSql("update TB_LOC_Locacao set st_registro = '" + rLoc.St_registro + "', dt_alt = getdate() " +
                                                        "where ID_Locacao = " + rLoc.Id_locacaostr, null);
                            }
                        }
                        else
                        {
                            if (rLoc.St_registro.Trim().Equals("2") || rLoc.St_registro.Trim().Equals("10"))
                            {
                                rLoc.St_registro = "9";
                                //Trocar status para aguardando faturamento
                                qtb_locacao.executarSql("update TB_LOC_Locacao set st_registro = '" + rLoc.St_registro + "', dt_alt = getdate() " +
                                                        "where ID_Locacao = " + rLoc.Id_locacaostr, null);
                            }
                            else if (rLoc.St_registro.Trim().Equals("4") || rLoc.St_registro.Trim().Equals("6"))
                            {
                                rLoc.St_registro = "7";
                                //Trocar status para devolvido
                                qtb_locacao.executarSql("update TB_LOC_Locacao set st_registro = '" + rLoc.St_registro + "', dt_alt = getdate() " +
                                                        "where ID_Locacao = " + rLoc.Id_locacaostr, null);
                            }
                        }
                    }
                }
                if (val.Tp_mov.ToUpper().Equals("C"))
                {
                    //Devolver Acessórios
                    TCN_Locacao.DevolverAcessorios(rLoc, qtb_locacao.Banco_Dados);
                    //Faturar Locação
                    if (rLoc.St_registro != "9")
                        TCN_Locacao.Faturar(rLoc, qtb_locacao.Banco_Dados);
                }
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_coletastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar coleta/entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string GravarColEnt(TRegistro_ColetaEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ColetaEntrega qtb_locacao = new TCD_ColetaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.Id_coletastr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_COLETA");
                //Gravar Vistoria
                val.lVistoria.ForEach(p =>
                {
                    p.Id_coleta = val.Id_coletastr;
                    TCN_Vistoria.Gravar(p, qtb_locacao.Banco_Dados);
                });
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_coletastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar coleta/entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ColetaEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ColetaEntrega qtb_loc = new TCD_ColetaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir coleta/entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }
}

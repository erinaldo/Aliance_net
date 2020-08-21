using System;
using CamadaDados.Frota.Cadastros;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_LanPneu
    {
        public static TList_LanPneu Buscar(string Cd_empresa,
                                           string Id_pneu,
                                           string Nr_serie,
                                           string Id_rodado,
                                           string St_registro,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pneu))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_pneu";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pneu;
            }
            if (!string.IsNullOrEmpty(Nr_serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_serie.Trim();
            }
            if (!string.IsNullOrEmpty(Id_rodado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FRT_MovPneu x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_pneu = a.id_pneu " +
                                                      "and x.st_rodando = 'S' " +
                                                      "and x.id_rodado = " + Id_rodado + ") ";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'C')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_LanPneu(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPneu qtb_pneu = new TCD_LanPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;
                val.Id_pneustr = CamadaDados.TDataQuery.getPubVariavel(qtb_pneu.Gravar(val), "@P_ID_PNEU");
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return val.Id_pneustr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPneu qtb_pneu = new TCD_LanPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;

                //Buscar Movimentação Almoxarifado x Movimentação do pneu
                CamadaDados.Almoxarifado.TList_Movimentacao lMov =
                    new CamadaDados.Almoxarifado.TCD_Movimentacao(qtb_pneu.Banco_Dados).Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FRT_MovPneu x " +
                                            "where x.id_movalmox = a.id_movimento " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.id_pneu = " + val.Id_pneustr + ") "
                            }
                        }, 0, string.Empty);
                if (lMov.Count > 0)
                {
                    //Cancelar Almoxarifado
                    lMov.ForEach(p => CamadaNegocio.Almoxarifado.TCN_Movimentacao.Cancelar(p, qtb_pneu.Banco_Dados));
                    
                    //Desativar pneu
                    Desativacao(val, qtb_pneu.Banco_Dados);
                }
                else
                    qtb_pneu.Excluir(val);

                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return val.Id_pneustr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string Desativacao(TRegistro_LanPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPneu qtb_pneu = new TCD_LanPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;

                //Verificar se o pneu esta rodando
                if (new CamadaDados.Frota.TCD_MovPneu(qtb_pneu.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "a.id_pneu",
                                vOperador = "=",
                                vVL_Busca = val.Id_pneustr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_rodando, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") != null)
                {
                    qtb_pneu.executarSql("update tb_frt_movpneu set st_rodando = 'N',  HodometroFinal = " + val.HodometroDesativacao.ToString() + ", Dt_Alt = getdate() " +
                                         "where cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                         "and id_pneu = " + val.Id_pneustr + " " +
                                         "and st_rodando = 'S' ", null);
                }

                //Se Pneu estiver no almoxarifado dar saida
                if (new TCD_LanPneu(qtb_pneu.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_pneu",
                            vOperador = "=",
                            vVL_Busca = val.Id_pneustr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, "1") != null)
                {
                    CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                    rMov.Ds_observacao = "SAÍDA REALIZADA PELA DESATIVAÇÃO DE PNEUS";
                    rMov.Cd_empresa = val.Cd_empresa;
                    rMov.Id_almoxstr = val.Id_almoxstr;
                    rMov.Cd_produto = val.Cd_produto;
                    rMov.Quantidade = 1;
                    rMov.Vl_unitario = Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa, val.Id_almoxstr, val.Cd_produto, qtb_pneu.Banco_Dados); ;
                    rMov.Tp_movimento = "S";
                    rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                    rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                    rMov.St_registro = "A";
                    Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_pneu.Banco_Dados);
                }

                //Registrar desativação no pneu
                val.St_registro = "D";
                string retorno = qtb_pneu.Gravar(val);

                //Gravar Movimentação Pneu Desativação
                CamadaDados.Frota.TRegistro_MovPneu rMovPneu = new TRegistro_MovPneu();
                rMovPneu.Cd_empresa = val.Cd_empresa;
                rMovPneu.Id_pneu = val.Id_pneu;
                rMovPneu.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                rMovPneu.Obs = val.MotivoDesativacao;
                rMovPneu.Tp_movimentacao = "3";
                rMovPneu.St_rodando = "N";
                TCN_MovPneu.Gravar(rMovPneu, qtb_pneu.Banco_Dados);
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desativação pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string RetornoManutencao(TRegistro_LanPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPneu qtb_pneu = new TCD_LanPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;
                
                //Criar registro movimentação
                CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov =
                    new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                rMov.Ds_observacao = "ENTRADA REALIZADA PELA RETORNO DA MOVIMENTAÇÃO DE PNEUS";
                rMov.Cd_empresa = val.Cd_empresa;
                rMov.Id_almoxstr = val.Id_almoxstr;
                rMov.Cd_produto = val.Cd_produto;
                rMov.Quantidade = 1;
                rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa, val.Id_almoxstr, val.Cd_produto, qtb_pneu.Banco_Dados); ;
                rMov.Tp_movimento = "E";
                rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                rMov.St_registro = "A";
                //Gravar Movimentação
                CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_pneu.Banco_Dados);
                //Mudar Status Pneu
                val.St_registro = "A";
                string retorno = qtb_pneu.Gravar(val);
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar  manutenção pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string EnvioAlmoxarifado(TRegistro_LanPneu val, int Hodometro, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPneu qtb_pneu = new TCD_LanPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;

                CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                rMov.Ds_observacao = "ENTRADA REALIZADA PELO RETORNO DA MOVIMENTAÇÃO DE PNEUS";
                rMov.Cd_empresa = val.Cd_empresa;
                rMov.Id_almoxstr = val.Id_almoxstr;
                rMov.Cd_produto = val.Cd_produto;
                rMov.Quantidade = 1;
                rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa, val.Id_almoxstr, val.Cd_produto, qtb_pneu.Banco_Dados); ;
                rMov.Tp_movimento = "E";
                rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                rMov.St_registro = "A";
                CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_pneu.Banco_Dados);

                val.St_registro = "A";
                string retorno = qtb_pneu.Gravar(val);

                qtb_pneu.executarSql("update tb_frt_movpneu set st_rodando = 'N',  HodometroFinal = " + Hodometro.ToString() + ", Dt_Alt = getdate() " +
                                     "where cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                     "and id_pneu = " + val.Id_pneustr + " " +
                                     "and isnull(st_rodando, 'N') = 'S' ", null);
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar  manutenção pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }
    }
}

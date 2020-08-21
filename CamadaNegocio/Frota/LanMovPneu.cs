using CamadaDados.Frota;
using CamadaDados.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Frota
{
    public class TCN_MovPneu
    {
        public static TList_MovPneu Buscar(string Cd_empresa,
                                           string Id_pneu,
                                           string Id_veiculo,
                                           string Id_rodado,
                                           BancoDados.TObjetoBanco banco,
                                           string St_registro = "")
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
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Id_rodado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_rodado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rodado;
            }

            if (!string.IsNullOrEmpty(St_registro.Trim()))
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_rodando, 'N')", "'" + St_registro.Trim() + "'");

            return new TCD_MovPneu(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static int BuscarUltimoHodometroVeiculo(string Id_veiculo,
                                                        BancoDados.TObjetoBanco banco)
        {
            return Convert.ToInt32(new CamadaDados.Frota.TCD_MovPneu(banco).BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_veiculo",
                        vOperador = "=",
                        vVL_Busca = Id_veiculo
                    }
                }, "case when a.HodometroFinal > 0 then a.HodometroFinal else a.Hodometro end", "a.dt_alt desc"));
        }

        public static string Gravar(TRegistro_MovPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovPneu qtb_pneu = new TCD_MovPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;
                val.Id_movstr = CamadaDados.TDataQuery.getPubVariavel(qtb_pneu.Gravar(val), "@P_ID_MOV");
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return val.Id_movstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string GravarTrocaPneu(TRegistro_LanPneu _LanPneuOrigem,
                                             TRegistro_Rodado _RodadoDestino,
                                             string Id_veiculoOrigem,
                                             string Id_veiculoDestino,
                                             BancoDados.TObjetoBanco banco,
                                             int HodometroOrigem = 0,
                                             int HodometroDestino = 0,
                                             decimal ProfundidadeOrigem = 0,
                                             decimal ProfundidadeDestino = 0)
        {
            bool st_transacao = false;
            TCD_MovPneu qtb_pneu = new TCD_MovPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;

                if (_LanPneuOrigem.Status.Equals("ALMOXARIFADO") && HodometroDestino < 1)
                    throw new Exception("Pneu de origem não possui hodometro inicial");
                else if (!string.IsNullOrEmpty(_RodadoDestino.Id_pneu) && HodometroDestino < 1)
                    throw new Exception("Para rodado com pneu em movimentação é obrigatório informar hodometro destino.");
                else if (!string.IsNullOrEmpty(_RodadoDestino.Id_pneu))
                {
                    //Para rodados com pneu deve-se finalizar está movimentação e dar entrada no almoxarifado
                    TRegistro_LanPneu _LanPneu = new TRegistro_LanPneu();
                    _LanPneu = new TCD_LanPneu().Select(new TpBusca[]
                                                       {
                                                           new TpBusca()
                                                           {
                                                               vNM_Campo = "a.id_pneu",
                                                               vOperador = "=",
                                                               vVL_Busca = _RodadoDestino.Id_pneu
                                                           }
                                                       }, 1, string.Empty)[0];
                    CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                    rMov.Ds_observacao = "ENTRADA REALIZADA POR MOVIMENTAÇÃO";
                    rMov.Cd_empresa = _LanPneu.Cd_empresa;
                    rMov.Id_almoxstr = _LanPneu.Id_almoxstr;
                    rMov.Cd_produto = _LanPneu.Cd_produto;
                    rMov.Quantidade = 1;
                    rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(_LanPneu.Cd_empresa, _LanPneu.Id_almoxstr, _LanPneu.Cd_produto, null);
                    rMov.Tp_movimento = "E";
                    rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                    rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                    rMov.St_registro = "A";
                    CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, banco);
                    TRegistro_MovPneu _MovPneu = new TCD_MovPneu().Select(new TpBusca[]
                                                                         {
                                                                             new TpBusca()
                                                                             {
                                                                                 vNM_Campo = "a.cd_empresa",
                                                                                 vOperador = "=",
                                                                                 vVL_Busca = _LanPneu.Cd_empresa
                                                                             },
                                                                             new TpBusca()
                                                                             {
                                                                                 vNM_Campo = "a.id_pneu",
                                                                                 vOperador = "=",
                                                                                 vVL_Busca = _LanPneu.Id_pneustr
                                                                             },
                                                                             new TpBusca()
                                                                             {
                                                                                 vNM_Campo = "a.id_veiculo",
                                                                                 vOperador = "=",
                                                                                 vVL_Busca = _LanPneu.Id_veiculo
                                                                             },
                                                                             new TpBusca()
                                                                             {
                                                                                 vNM_Campo = "a.id_rodado",
                                                                                 vOperador = "=",
                                                                                 vVL_Busca = _RodadoDestino.Id_rodadostr
                                                                             },
                                                                             new TpBusca()
                                                                             {
                                                                                 vNM_Campo = "a.st_rodando",
                                                                                 vOperador = "=",
                                                                                 vVL_Busca = "'S'"
                                                                             }
                                                                         }, 1)[0];

                    //Atualizar movimentação/pneu para almoxarifado
                    qtb_pneu.executarSql("update tb_frt_movpneu " +
                                         "   set st_rodando = 'N',  HodometroFinal = " + HodometroDestino + ", Dt_Alt = getdate(), EspessuraBorracha = convert(decimal(15,3), replace('" + ProfundidadeDestino + "', ',','.')) " +
                                         " where id_mov = " + _MovPneu.Id_movstr + " " +
                                         "   and cd_empresa = " + _MovPneu.Cd_empresa + " " +
                                         "   and id_pneu = " + _LanPneu.Id_pneustr + " " +
                                         "   and id_veiculo = " + _LanPneu.Id_veiculo + " " +
                                         "   and id_rodado = " + _RodadoDestino.Id_rodadostr + " " +
                                         "   and st_rodando = 'S'", null);
                    qtb_pneu.executarSql("update tb_frt_pneus set st_registro = 'A', Dt_Alt = getdate() " +
                                         " where cd_empresa = '" + _MovPneu.Cd_empresa.Trim() + "' " +
                                         "   and id_pneu = " + _MovPneu.Id_pneustr, null);
                }

                TRegistro_MovPneu rMovPneu = new TRegistro_MovPneu();
                if (_LanPneuOrigem.Status.Equals("RODANDO"))
                {
                    //Finalizar movimentação do pneu origem
                    if (HodometroOrigem < 1)
                        throw new Exception("Para evoluir a movimentação é obrigatório informar hodometro no pneu origem.");
                    qtb_pneu.executarSql("update tb_frt_movpneu " +
                                         "   set st_rodando = 'N',  HodometroFinal = " + HodometroOrigem + ", Dt_Alt = getdate() " +
                                         " where cd_empresa = " + _LanPneuOrigem.Cd_empresa + " " +
                                         "   and id_pneu = " + _LanPneuOrigem.Id_pneustr + " " +
                                         "   and id_veiculo = " + _LanPneuOrigem.Id_veiculo + " " +
                                         "   and id_rodado = " + _LanPneuOrigem.Id_rodado + " " +
                                         "   and st_rodando = 'S'", null);
                    if (HodometroDestino < 1)
                        throw new Exception("Para evoluir a movimentação é obrigatório informar hodometro no pneu destino.");
                    rMovPneu.HodometroInicial = HodometroDestino;
                }
                else
                {
                    //Saída do almoxarifado para pneu origem
                    CamadaDados.Almoxarifado.TRegistro_Movimentacao _Movimentacao = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                    _Movimentacao.Cd_empresa = _LanPneuOrigem.Cd_empresa;
                    _Movimentacao.Cd_produto = _LanPneuOrigem.Cd_produto;
                    _Movimentacao.Id_almox = _LanPneuOrigem.Id_almox;
                    _Movimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                    _Movimentacao.Tp_movimento = "S";
                    _Movimentacao.Quantidade = 1;
                    object obj = new CamadaDados.Almoxarifado.TCD_SaldoAlmoxarifado().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneuOrigem.Cd_empresa + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneuOrigem.Cd_produto.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.id_almox",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneuOrigem.Id_almoxstr + "'"
                                            }
                                        }, "isnull(a.vl_custo, 0)");
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                        _Movimentacao.Vl_unitario = Convert.ToDecimal(obj.ToString());
                    _Movimentacao.St_registro = "A";
                    _Movimentacao.Ds_observacao = "SAIDA POR MOVIMENTACAO NA GESTAO DE PNEUS";
                    rMovPneu.Id_movalmoxstr = CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(_Movimentacao, banco);

                    if (HodometroDestino < 1)
                        throw new Exception("Para pneu com status ALMOXARIFADO deve ser informado hodometro destino.");
                    rMovPneu.HodometroInicial = HodometroDestino;
                }

                //Nova movimentação
                rMovPneu.Cd_empresa = _LanPneuOrigem.Cd_empresa;
                rMovPneu.Id_pneu = _LanPneuOrigem.Id_pneu;
                rMovPneu.Id_veiculostr = Id_veiculoDestino;
                rMovPneu.Id_rodado = _RodadoDestino.Id_rodado;
                rMovPneu.St_rodando = "S";
                rMovPneu.Tp_movimentacao = "1";
                rMovPneu.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                rMovPneu.Cd_produto = _LanPneuOrigem.Cd_produto;
                rMovPneu.EspessuraBorracha = ProfundidadeOrigem;
                rMovPneu.Id_movstr = CamadaDados.TDataQuery.getPubVariavel(qtb_pneu.Gravar(rMovPneu), "@P_ID_MOV");

                //Atualizar pneus movimentados para St. Rodando
                _LanPneuOrigem.St_registro = "R";
                Cadastros.TCN_LanPneu.Gravar(_LanPneuOrigem, banco);

                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return rMovPneu.Id_movstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string GravarManutencao(TRegistro_MovPneu _MovPneu, TRegistro_LanPneu _LanPneu, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovPneu qtb_pneu = new TCD_MovPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;

                //Gravar Duplicata
                if (_MovPneu.rDup != null)
                    _MovPneu.Nr_lancto = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(_MovPneu.rDup, false, qtb_pneu.Banco_Dados), "@P_NR_LANCTO"));

                //Saida do almoxarifado
                CamadaDados.Almoxarifado.TRegistro_Movimentacao _Movimentacao = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                _Movimentacao.Cd_empresa = _LanPneu.Cd_empresa;
                _Movimentacao.Cd_produto = _LanPneu.Cd_produto;
                _Movimentacao.Id_almox = _LanPneu.Id_almox;
                _Movimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                _Movimentacao.Tp_movimento = "S";
                _Movimentacao.Quantidade = 1;

                object obj = new CamadaDados.Almoxarifado.TCD_SaldoAlmoxarifado().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneu.Cd_empresa + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneu.Cd_produto.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.id_almox",
                                                vOperador = "=",
                                                vVL_Busca = "'" + _LanPneu.Id_almoxstr + "'"
                                            }
                                    }, "isnull(a.vl_custo, 0)");

                if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    _Movimentacao.Vl_unitario = Convert.ToDecimal(obj.ToString());
                _Movimentacao.St_registro = "A";
                _Movimentacao.Ds_observacao = "SAIDA PARA MANUTENÇÃO POR GESTAO DE PNEUS";

                _MovPneu.Id_movalmoxstr = CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(_Movimentacao, banco);
                _MovPneu.Id_movstr = CamadaDados.TDataQuery.getPubVariavel(qtb_pneu.Gravar(_MovPneu), "@P_ID_MOV");

                //Atualizar pneu para manutenção
                qtb_pneu.executarSql("update tb_frt_pneus set st_registro = 'M', Dt_Alt = getdate() " +
                                     "where cd_empresa = '" + _LanPneu.Cd_empresa.Trim() + "'" +
                                     "and id_pneu = " + _LanPneu.Id_pneustr, null);

                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return _MovPneu.Id_movstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovPneu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovPneu qtb_pneu = new TCD_MovPneu();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pneu.CriarBanco_Dados(true);
                else
                    qtb_pneu.Banco_Dados = banco;
                qtb_pneu.Excluir(val);
                if (st_transacao)
                    qtb_pneu.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pneu.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimentação pneu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pneu.deletarBanco_Dados();
            }
        }

        private static void saidaAlmoxarifado(TRegistro_LanPneu _LanPneu,
                                              BancoDados.TObjetoBanco banco)
        {
            CamadaDados.Almoxarifado.TList_CadAlmox_X_Empresa lAlmox =
                   new CamadaDados.Almoxarifado.TCD_CadAlmox_X_Empresa(banco).Select(
                       new Utils.TpBusca[]
                       {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = _LanPneu.Cd_empresa
                            }
                       }, 0, string.Empty);
            if (lAlmox.Count.Equals(0))
                throw new Exception("Obrigatório cadastrar almoxarifado para empresa: " + _LanPneu.Cd_empresa);
            CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
            rMov.Ds_observacao = "SAÍDA REALIZADA PELO CADASTRO DE PNEUS";
            rMov.Cd_empresa = _LanPneu.Cd_empresa;
            rMov.Id_almoxstr = lAlmox[0].Id_almoxstr;
            rMov.Cd_produto = _LanPneu.Cd_produto;
            rMov.Quantidade = 1;
            rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(_LanPneu.Cd_empresa, lAlmox[0].Id_almoxstr, _LanPneu.Cd_produto, banco); ;
            rMov.Tp_movimento = "S";
            rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
            rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
            rMov.St_registro = "A";
            //Gravar Movimentação
            CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, banco);
        }

    }
}

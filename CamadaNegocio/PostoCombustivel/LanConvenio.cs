using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    #region Convenio
    public class TCN_Convenio
    {
        public static TList_Convenio Buscar(string Id_convenio,
                                            string Cd_empresa,
                                            string Cd_condpgto,
                                            string Tp_duplicata,
                                            string Tp_docto,
                                            string Cd_portador,
                                            string Cd_clifor,
                                            string Cd_produto,
                                            string Dt_ini,
                                            string Dt_fin,
                                            string St_registro,
                                            bool St_valorFixo,
                                            string DS_convenio,
                                            string Cd_vendedor,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(DS_convenio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_convenio";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + DS_convenio.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Id_convenio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_convenio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_convenio;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_condpgto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Tp_docto;
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_convenio_x_clifor x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_convenio = a.id_convenio " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and x.cd_clifor = '" + Cd_clifor.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_convenio_x_clifor x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_convenio = a.id_convenio " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_convenio";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_convenio";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_valorFixo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_convenio_x_clifor x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_convenio = a.id_convenio " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and isnull(x.vl_unitario, 0) > 0)";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_convenio_x_clifor x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_convenio = a.id_convenio " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            }
            return new TCD_Convenio(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Convenio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio qtb_convenio = new TCD_Convenio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_convenio.CriarBanco_Dados(true);
                else
                    qtb_convenio.Banco_Dados = banco;
                val.Id_conveniostr = CamadaDados.TDataQuery.getPubVariavel(qtb_convenio.Gravar(val), "@P_ID_CONVENIO");
                val.lCliforDel.ForEach(p => TCN_Convenio_Clifor.Excluir(p, qtb_convenio.Banco_Dados));
                val.lClifor.ForEach(p =>
                    {
                        p.Id_convenio = val.Id_convenio;
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_Convenio_Clifor.Gravar(p, qtb_convenio.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_convenio.Banco_Dados.Commit_Tran();
                return val.Id_conveniostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_convenio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar convenio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_convenio.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Convenio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio qtb_convenio = new TCD_Convenio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_convenio.CriarBanco_Dados(true);
                else
                    qtb_convenio.Banco_Dados = banco;
                //Excluir clifor
                val.lClifor.ForEach(p => TCN_Convenio_Clifor.Excluir(p, qtb_convenio.Banco_Dados));
                val.lCliforDel.ForEach(p => TCN_Convenio_Clifor.Excluir(p, qtb_convenio.Banco_Dados));
                //Verificar se o convenio possui movimentacao
                if (new TCD_VendaCombustivel(qtb_convenio.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_convenio",
                            vOperador = "=",
                            vVL_Busca = val.Id_conveniostr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim( ) + "'"
                        }
                    }, "1") != null)
                {
                    val.St_registro = "E";//Encerrado
                    Gravar(val, qtb_convenio.Banco_Dados);
                }
                else
                    qtb_convenio.Excluir(val);
                if (st_transacao)
                    qtb_convenio.Banco_Dados.Commit_Tran();
                return val.Id_conveniostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_convenio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir convenio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_convenio.deletarBanco_Dados();
            }
        }

        public static void Alterar(TRegistro_Convenio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio qtb_conv = new TCD_Convenio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                qtb_conv.Gravar(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar convenio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Clifor Convenio
    public class TCN_Convenio_Clifor
    {
        public static TList_Convenio_Clifor Buscar(string Id_convenio,
                                                   string Cd_empresa,
                                                   string Cd_clifor,
                                                   string Cd_endereco,
                                                   string Cd_produto,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_convenio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_convenio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_convenio;
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
            if (!string.IsNullOrEmpty(Cd_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endereco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_Convenio_Clifor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Convenio_Clifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Clifor qtb_conv = new TCD_Convenio_Clifor();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                if (!val.St_registro.Trim().ToUpper().Equals("C"))
                {
                    //Verificar se nao e permitido ter mais de um convenio por cliente
                    if (!CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CLIFOR_MULTIPLOS_CONV", qtb_conv.Banco_Dados))
                    {
                        //Verificar se o clifor ja possui convenio amarrado
                        TList_Convenio_Clifor lConvCli =
                            new TCD_Convenio_Clifor(qtb_conv.Banco_Dados).Select(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_convenio",
                                vOperador = "<>",
                                vVL_Busca = val.Id_conveniostr
                            }
                        }, 0, string.Empty);
                        lConvCli.ForEach(p =>
                            {
                                p.lMotorista = TCN_Motorista_Convenio.Buscar(p.Id_conveniostr,
                                                                             p.Cd_empresa,
                                                                             p.Cd_clifor,
                                                                             p.Cd_endereco,
                                                                             p.Cd_produto,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             qtb_conv.Banco_Dados);
                                p.lPlaca = TCN_Convenio_Placa.Buscar(p.Id_conveniostr,
                                                                     p.Cd_empresa,
                                                                     p.Cd_clifor,
                                                                     p.Cd_endereco,
                                                                     p.Cd_produto,
                                                                     qtb_conv.Banco_Dados);
                                Excluir(p, qtb_conv.Banco_Dados);
                            });
                    }
                }
                string retorno = qtb_conv.Gravar(val);
                //Gravar placa
                val.lPlacaDel.ForEach(p => TCN_Convenio_Placa.Excluir(p, qtb_conv.Banco_Dados));
                val.lPlaca.ForEach(p=>
                    {
                        p.Id_convenio = val.Id_convenio;
                        p.Cd_empresa = val.Cd_empresa;
                        p.Cd_clifor = val.Cd_clifor;
                        p.Cd_endereco = val.Cd_endereco;
                        p.Cd_produto = val.Cd_produto;
                        TCN_Convenio_Placa.Gravar(p, qtb_conv.Banco_Dados);
                    });
                //Gravar motorista
                val.lMotDel.ForEach(p => TCN_Motorista_Convenio.Excluir(p, qtb_conv.Banco_Dados));
                val.lMotorista.ForEach(p =>
                    {
                        p.Id_convenio = val.Id_convenio;
                        p.Cd_empresa = val.Cd_empresa;
                        p.Cd_clifor = val.Cd_clifor;
                        p.Cd_endereco = val.Cd_endereco;
                        p.Cd_produto = val.Cd_produto;
                        TCN_Motorista_Convenio.Gravar(p, qtb_conv.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<TRegistro_Convenio_Clifor> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Clifor qtb_conv = new TCD_Convenio_Clifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                val.ForEach(p => Gravar(p, qtb_conv.Banco_Dados));
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lista cliente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Convenio_Clifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Clifor qtb_conv = new TCD_Convenio_Clifor();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                //Excluir placa
                val.lPlaca.ForEach(p => TCN_Convenio_Placa.Excluir(p, qtb_conv.Banco_Dados));
                val.lPlacaDel.ForEach(p => TCN_Convenio_Placa.Excluir(p, qtb_conv.Banco_Dados));
                //Excluir motorista
                val.lMotorista.ForEach(p => TCN_Motorista_Convenio.Excluir(p, qtb_conv.Banco_Dados));
                val.lMotDel.ForEach(p => TCN_Motorista_Convenio.Excluir(p, qtb_conv.Banco_Dados));
                //Verificar se o convenio possui movimentacao
                if (new TCD_VendaCombustivel(qtb_conv.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_convenio",
                            vOperador = "=",
                            vVL_Busca = val.Id_conveniostr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim( ) + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                        }
                    }, "1") != null)
                {
                    val.St_registro = "C";
                    Gravar(val, qtb_conv.Banco_Dados);
                }
                else
                    qtb_conv.Excluir(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static void ProcessarPontosFid(TRegistro_Convenio_Clifor rConv,
                                              TRegistro_VendaCombustivel rVenda,
                                              string Placa,
                                              string Cpf_motorista,
                                              BancoDados.TObjetoBanco banco)
        {
            if((rConv.Base_calc_fid > decimal.Zero) &&
                (!string.IsNullOrEmpty(rConv.Tp_qt_vl)) &&
                (rConv.Qt_pontos_fid > decimal.Zero) &&
                !string.IsNullOrWhiteSpace(Placa))
            {
                rVenda.rPontosFid = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                rVenda.rPontosFid.Cd_empresa = rVenda.Cd_empresa;
                if(rConv.Tp_pontos_fid.Trim().ToUpper().Equals("M"))
                    rVenda.rPontosFid.Cpf_cliente = Cpf_motorista;
                else if(rConv.Tp_pontos_fid.Trim().ToUpper().Equals("P"))
                    rVenda.rPontosFid.Placa = Placa;
                else rVenda.rPontosFid.Cd_clifor = rConv.Cd_clifor;
                rVenda.rPontosFid.Dt_registro = CamadaDados.UtilData.Data_Servidor(banco);
                if(rConv.Nr_diasvalidade_fid > decimal.Zero)
                    rVenda.rPontosFid.Dt_validade = rVenda.rPontosFid.Dt_registro.Value.AddDays(Convert.ToDouble(rConv.Nr_diasvalidade_fid));
                if(rConv.Tp_qt_vl.Trim().Equals("Q"))//Quantidade
                {
                    int resto = 0;
                    rVenda.rPontosFid.Qt_pontos = Math.DivRem(Convert.ToInt32(rVenda.Volumeabastecido), Convert.ToInt32(rConv.Base_calc_fid), out resto) * rConv.Qt_pontos_fid;
                }
                else//Valor
                {
                    int resto = 0;
                    rVenda.rPontosFid.Qt_pontos = Math.DivRem(Convert.ToInt32(rVenda.Vl_subtotal), Convert.ToInt32(rConv.Base_calc_fid), out resto) * rConv.Base_calc_fid;
                }

                //buscar se placa é bloqueada
                if (new TCD_PlacaBloqPontos().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.placa",
                                        vOperador = "=",
                                        vVL_Busca = "'"+rVenda.Placaveiculo+"'"
                                    }
                    }, "a.placa") != null)
                    rVenda.rPontosFid.St_registro = "C";


            }
        }

        public static CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate ResgatarPontosFid(CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lPontos,
                                                                                                             decimal pontos_resgatar,
                                                                                                             string LoginPDV,
                                                                                                             string LoginAutoriza,
                                                                                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Clifor qtb_conv = new TCD_Convenio_Clifor();
            CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate vale = new CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else qtb_conv.Banco_Dados = banco;
                decimal pontos = decimal.Zero;
                DateTime? dt_atual = CamadaDados.UtilData.Data_Servidor(qtb_conv.Banco_Dados);

                foreach (CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto in lPontos.OrderBy(p => p.Dt_registro).ToList())
                {
                    if (pontos_resgatar > decimal.Zero)
                    {
                        pontos = (pontos_resgatar < rPonto.SD_Pontos ? pontos_resgatar : rPonto.SD_Pontos);
                        CamadaDados.Faturamento.Fidelizacao.TRegistro_ResgatePontos rResgate = new CamadaDados.Faturamento.Fidelizacao.TRegistro_ResgatePontos();
                        rResgate.Cd_empresa = rPonto.Cd_empresa;
                        rResgate.Id_ponto = rPonto.Id_ponto;
                        rResgate.Login = LoginPDV;
                        rResgate.Qt_pontos = pontos;
                        rResgate.Dt_resgate = dt_atual;
                        rResgate.St_registro = "A";
                        vale.lResgate.Add(rResgate);

                        pontos_resgatar -= pontos;
                        rPonto.Pontos_res += pontos;
                    }
                    else break;
                }
                //Gravar vale
                vale.Cd_empresa = vale.lResgate[0].Cd_empresa;
                vale.Loginautoriza = LoginAutoriza;
                CamadaNegocio.Faturamento.Fidelizacao.TCN_ValeResgate.Gravar(vale, qtb_conv.Banco_Dados);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return vale;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar resgate pontos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Placa Convenio
    public class TCN_Convenio_Placa
    {
        public static TList_Convenio_Placa Buscar(string Id_convenio,
                                                  string Cd_empresa,
                                                  string Cd_clifor,
                                                  string Cd_endereco,
                                                  string Cd_produto,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_convenio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_convenio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_convenio;
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
            if (!string.IsNullOrEmpty(Cd_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endereco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_Convenio_Placa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Convenio_Placa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Placa qtb_conv = new TCD_Convenio_Placa();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                string retorno = qtb_conv.Gravar(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<TRegistro_Convenio_Placa> lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Placa qtb_conv = new TCD_Convenio_Placa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else qtb_conv.Banco_Dados = banco;
                lista.ForEach(p => Gravar(p, qtb_conv.Banco_Dados));
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Convenio_Placa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Placa qtb_conv = new TCD_Convenio_Placa();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                qtb_conv.Excluir(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Motorista Convenio
    public class TCN_Motorista_Convenio
    {
        public static TList_convenio_Motorista Buscar(string Id_convenio,
                                                      string Cd_empresa,
                                                      string Cd_clifor,
                                                      string Cd_endereco,
                                                      string Cd_produto,
                                                      string Id_motorista,
                                                      string Nm_motorista,
                                                      string Cpf_motorista,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_convenio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_convenio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_convenio;
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
            if (!string.IsNullOrEmpty(Cd_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endereco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_motorista;
            }
            if (!string.IsNullOrEmpty(Nm_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_motorista";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_motorista.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Cpf_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cpf_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cpf_motorista.Trim() + "'";
            }

            return new TCD_Convenio_Motorista(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Convenio_Motorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Motorista qtb_conv = new TCD_Convenio_Motorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                val.Id_motoristastr = CamadaDados.TDataQuery.getPubVariavel(qtb_conv.Gravar(val), "@P_ID_MOTORISTA");
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return val.Id_motoristastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar motorista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Convenio_Motorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Convenio_Motorista qtb_conv = new TCD_Convenio_Motorista();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                qtb_conv.Excluir(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir motorista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }
    }
    #endregion


    #region Placas Bloqueadas Gerar Pontos
    public class TCN_PlacaBloqPontos
    {
        public static TList_PlacaBloqPontos Buscar( 
                                                  string placa,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(placa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = placa;
            } 
            return new TCD_PlacaBloqPontos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PlacaBloqPontos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlacaBloqPontos qtb_conv = new TCD_PlacaBloqPontos();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                string retorno = qtb_conv.Gravar(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<TRegistro_PlacaBloqPontos> lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlacaBloqPontos qtb_conv = new TCD_PlacaBloqPontos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else qtb_conv.Banco_Dados = banco;
                lista.ForEach(p => Gravar(p, qtb_conv.Banco_Dados));
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PlacaBloqPontos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlacaBloqPontos qtb_conv = new TCD_PlacaBloqPontos();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_conv.CriarBanco_Dados(true);
                else
                    qtb_conv.Banco_Dados = banco;
                qtb_conv.Excluir(val);
                if (st_transacao)
                    qtb_conv.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_conv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Placa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_conv.deletarBanco_Dados();
            }
        }
    }
    #endregion


}

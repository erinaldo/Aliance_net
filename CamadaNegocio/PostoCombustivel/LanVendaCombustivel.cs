using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    #region Venda Combustivel
    public class TCN_VendaCombustivel
    {
        public static TList_VendaCombustivel Buscar(string Id_venda,
                                                    string Cd_empresa,
                                                    string Cd_produto,
                                                    string Id_bico,
                                                    string Cd_clifor,
                                                    string Cd_frentista,
                                                    string Dt_ini,
                                                    string Dt_fin,
                                                    string St_registro,
                                                    string St_afericao,
                                                    bool St_convenio,
                                                    string Loginespera,
                                                    string Placa,
                                                    string vOrder,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_venda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_venda;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_bico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bico;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_frentista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_frentista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_frentista.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /") && (Dt_ini.Trim() != "/  /       :"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_abastecimento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /") && Dt_fin.Trim() != "/  /       :")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_abastecimento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_afericao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_afericao, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_afericao.Trim().ToUpper() + "'";
            }
            if (St_convenio)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.id_convenio is not null";
            }
            if (!string.IsNullOrEmpty(Loginespera))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.loginespera";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Loginespera.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(PlacaVeiculo, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }

            return new TCD_VendaCombustivel(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static decimal BuscarAfericaoBico(string Cd_empresa,
                                                 string Id_bico,
                                                 DateTime Dt_abastecimento,
                                                 string Tp_encerrante,
                                                 BancoDados.TObjetoBanco banco)
        {
            object obj = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel(banco).BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_bico",
                                    vOperador = "=",
                                    vVL_Busca = Id_bico
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), DT_Abastecimento)))",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Dt_abastecimento.ToString("yyyyMMdd") + "'"
                                }
                            }, 
                            Tp_encerrante.Trim().ToUpper().Equals("F") ? "a.encerrantebico" : "a.encerrantebico - a.volumeabastecido", 
                            string.Empty,
                            Tp_encerrante.Trim().ToUpper().Equals("F") ? "a.dt_abastecimento desc" : "a.dt_abastecimento asc",
                            null);
            return obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
        }

        public static string Gravar(TRegistro_VendaCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                if ((val.Id_bico == null) && (!string.IsNullOrEmpty(val.Enderecofisicobico)) && (val.Id_venda == null))
                {
                    object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(qtb_venda.Banco_Dados).BuscarEscalar(
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
                                            vNM_Campo = "a.EnderecoFisicoBico",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Enderecofisicobico.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, "a.id_bico");
                    if(obj != null)
                        val.Id_bico = decimal.Parse(obj.ToString());
                }
                val.Id_vendastr = CamadaDados.TDataQuery.getPubVariavel(qtb_venda.Gravar(val), "@P_ID_VENDA");
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return val.Id_vendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar venda combustivel: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_venda.Gravar(val);
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return val.Id_vendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir venda combustivel: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }

        public static void RetirarVendaEspera(List<TRegistro_VendaCombustivel> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        p.St_registro = "A";
                        p.Login_espera = string.Empty;
                        Gravar(p, qtb_venda.Banco_Dados);
                    });
                if(st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro retirar venda espera: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }
        
        public static void ReceberVendaCombustivel(TRegistro_VendaCombustivel val,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.St_registro = "F";
                qtb_venda.Gravar(val);
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro receber venda combustivel: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }
        
        public static void AfericaoBomba(List<TRegistro_VendaCombustivel> val,
                                         decimal? Id_caixa,
                                         BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        p.St_afericao = "S";
                        p.St_registro = "F";
                        p.Id_caixa = Id_caixa;
                        Gravar(p, qtb_venda.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar aferição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }

        public static void DesdobrarAbastecidas(List<TRegistro_VendaCombustivel> lVenda,
                                                TList_VendaCombustivel lDesdobro,
                                                BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaCombustivel qtb_venda = new TCD_VendaCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                //Cancelar Venda de Origem
                lVenda.ForEach(p =>
                    {
                        p.St_registro = "C";//Cancelado
                        Gravar(p, qtb_venda.Banco_Dados);
                    });
                //Gravar Venda de Desdobros
                lDesdobro.ForEach(p => Gravar(p, qtb_venda.Banco_Dados));
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro desdobrar abastecidas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }
    }
    #endregion
}

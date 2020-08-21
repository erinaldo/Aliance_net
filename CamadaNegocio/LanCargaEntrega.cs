using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Entrega;

namespace CamadaNegocio.Faturamento.Entrega
{
    public class TCN_CargaEntrega
    {
        public static TList_CargaEntrega Buscar(string Cd_empresa,
                                                string Id_carga,
                                                string Cd_motorista,
                                                string Placa,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string St_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(a.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Romaneio)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Romaneio)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_CargaEntrega(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CargaEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargaEntrega qtb_carga = new TCD_CargaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                val.Id_cargastr = CamadaDados.TDataQuery.getPubVariavel(qtb_carga.Gravar(val), "@P_ID_CARGA");
                //Item Carga
                val.lItensDel.ForEach(p => TCN_ItensCarga.Excluir(p, qtb_carga.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    if (p.St_processar)
                    {
                        p.Id_carga = val.Id_carga;
                        TCN_ItensCarga.Gravar(p, qtb_carga.Banco_Dados);
                    }
                });
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CargaEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargaEntrega qtb_carga = new TCD_CargaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;

                val.lItens.ForEach(p => 
                    {
                        p.St_registro = "C";
                        p.Quantidade = decimal.Zero;
                        TCN_ItensCarga.Gravar(p, qtb_carga.Banco_Dados);
                    });
                val.St_registro = "C";
                qtb_carga.Gravar(val);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string ProcessarEntrega(TRegistro_CargaEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargaEntrega qtb_carga = new TCD_CargaEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                

                //Processar estoque dos itens Entrega
                val.lItens.ForEach(p =>
                {
                    if (p.St_processar)
                    {
                        //Buscar Local de Armazenagem
                        object cd_local = new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio(qtb_carga.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.CD_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.ID_Romaneio",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Id_romaneiostr + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.ID_ItemRomaneio",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Id_itemromaneiostr + "'"
                                    }
                                }, "a.cd_local");

                        //Buscar VL.Médio
                        decimal vl_medio = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, qtb_carga.Banco_Dados);
                        //Criar objeto estoque
                        CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = p.Cd_empresa;
                        rEstoque.Cd_produto = p.Cd_produto;
                        rEstoque.Cd_local = cd_local.ToString();
                        rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                        rEstoque.Tp_movimento = "S";
                        rEstoque.Qtd_entrada = decimal.Zero;
                        rEstoque.Qtd_saida = p.QTD_Saida;
                        rEstoque.Vl_unitario = vl_medio;
                        rEstoque.Vl_subtotal = p.QTD_Saida * vl_medio;
                        rEstoque.Tp_lancto = "N";
                        rEstoque.St_registro = "A";

                        //Gravar Estoque
                        CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_carga.Banco_Dados);
                        p.Id_lanctoEstoque = rEstoque.Id_lanctoestoque;
                        TCN_ItensCarga.Gravar(p, qtb_carga.Banco_Dados);
                    }
                });
                val.St_registro = "E";
                qtb_carga.Gravar(val);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Entregar Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCarga
    {
        public static TList_ItensCarga Buscar(string Cd_empresa,
                                                string Id_carga,
                                                string Id_romaneio,
                                                string Id_itemromaneio,
                                                string Cd_produto,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Id_romaneio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_romaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_romaneio;
            }
            if (!string.IsNullOrEmpty(Id_itemromaneio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_itemromaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemromaneio;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            TList_ItensCarga lItem = new TCD_ItensCarga(banco).Select(filtro, 0, string.Empty);
            return lItem;
        }

        public static string Gravar(TRegistro_ItensCarga val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCarga qtb_carga = new TCD_ItensCarga();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                val.Id_itemcargastr = CamadaDados.TDataQuery.getPubVariavel(qtb_carga.Gravar(val), "@P_ID_ITEMCARGA");
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_itemcargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCarga val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCarga qtb_carga = new TCD_ItensCarga();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                qtb_carga.Excluir(val);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }
    }
}

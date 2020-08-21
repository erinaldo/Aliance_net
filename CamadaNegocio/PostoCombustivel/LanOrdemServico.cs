using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_OrdemServico
    {
        public static TList_OrdemServico Buscar(string Cd_empresa,
                                                string Id_ordem,
                                                string Cd_clifor,
                                                string Cd_vendedor,
                                                string Ds_veiculo,
                                                string Marca_veiculo,
                                                string Placa,
                                                string Ano,
                                                string Modelo,
                                                string Dt_ini,
                                                string Dt_fin,
                                                bool St_Aberta,
                                                bool St_faturada,
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
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_veiculo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_veiculo.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Marca_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.marca_veiculo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Marca_veiculo.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "replace(a.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", "").Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ano))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Modelo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.modelo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Modelo.Trim() + "%'";
            }
            if((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_ordem)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_ordem)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (St_Aberta && (!St_faturada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qtd_faturar";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (St_faturada && (!St_Aberta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qtd_faturar";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            return new TCD_OrdemServico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemServico qtb_os = new TCD_OrdemServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                //Data Ordem
                val.Dt_ordem = CamadaDados.UtilData.Data_Servidor(qtb_os.Banco_Dados);
                //Gravar Ordem
                val.Id_ordemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_os.Gravar(val), "@P_ID_ORDEM");
                //Excluir item ordem servico
                val.lItensDel.ForEach(p => TCN_ItensOrdemServico.Excluir(p, qtb_os.Banco_Dados));
                //Gravar item ordem servico
                val.lItens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_ordem = val.Id_ordem;
                        TCN_ItensOrdemServico.Gravar(p, qtb_os.Banco_Dados);
                    });
                if(st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return val.Id_ordemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemServico qtb_os = new TCD_OrdemServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                //Excluir itens da ordem
                val.lItens.ForEach(p => TCN_ItensOrdemServico.Excluir(p, qtb_os.Banco_Dados));
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return val.Id_ordemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensOrdemServico
    {
        public static TList_ItensOrdemServico Buscar(string Cd_empresa,
                                                     string Id_ordem,
                                                     string Id_item,
                                                     string Cd_produto,
                                                     string Cd_clifor,
                                                     bool St_itemsaldo,
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
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (St_itemsaldo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(a.Quantidade - a.Qtd_faturada)";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_ItensOrdemServico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensOrdemServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensOrdemServico qtb_itens = new TCD_ItensOrdemServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Item OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensOrdemServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensOrdemServico qtb_itens = new TCD_ItensOrdemServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                //Verificar se existe faturamento para o item ordem servico
                if (new CamadaDados.PostoCombustivel.TCD_Ordem_X_VendaRapida(qtb_itens.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_ordem",
                            vOperador = "=",
                            vVL_Busca = val.Id_ordemstr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_item",
                            vOperador = "=",
                            vVL_Busca = val.Id_itemstr
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir item faturado.");
                
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Ordem_X_VendaRapida
    {
        public static TList_Ordem_X_VendaRapida Buscar(string Cd_empresa,
                                                       string Id_ordem,
                                                       string Id_item,
                                                       string Id_cupom,
                                                       string Id_lancto,
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
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
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

            return new TCD_Ordem_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.PDV.TList_VendaRapida_Item BuscarItemVenda(string Cd_empresa,
                                                                                         string Id_ordem,
                                                                                         string Id_item,
                                                                                         BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdc_ordem_x_vendarapida x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_cupom = a.id_vendarapida " +
                                    "and x.id_lancto = a.id_lanctovenda " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_ordem = " + Id_ordem + " " +
                                    "and x.id_item = " + Id_item + ")"
                    }
                }, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Ordem_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_X_VendaRapida qtb_os = new TCD_Ordem_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar OS X Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Ordem_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_X_VendaRapida qtb_os = new TCD_Ordem_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir OS X Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }
}

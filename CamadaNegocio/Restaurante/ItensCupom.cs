using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante;
using Utils;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Restaurante
{
    public class TCN_ItensCupom
    {

        public static void GravarCupom(TList_PreVenda_Item val,TRegistro_Cartao cartao )
        {
            TRegistro_VendaRapida rVenda = new TRegistro_VendaRapida();
            val.ForEach(p =>
            {
                rVenda.lItem.Add(new TRegistro_VendaRapida_Item
                {
                    Cd_produto = p.cd_produto,
                    Quantidade = p.quantidade_agregar,
                    Vl_unitario = p.vl_unitario,
                    Vl_subtotal = p.vl_subtotal
                });
            });
            rVenda.rCliente = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = cartao.Cd_Clifor
                    }
                },1,string.Empty)[0];
            rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = cartao.Cd_Clifor
                    }
                }, 1, string.Empty)[0];

            Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda,
                                                              null,
                                                              null,
                                                              null);

        }


        public static TList_ItensCupom Buscar(string Cd_empresa,
                                          string id_preventa,
                                          string id_lancto,
                                          string id_cupom,
                                          string id_item,
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
            if (!string.IsNullOrEmpty(id_preventa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_preventa;
            }
            if (!string.IsNullOrEmpty(id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_item;
            }
            if (!string.IsNullOrEmpty(id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_lancto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_cupom.Trim() + "'";
            }
            return new TCD_ItensCupom(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCupom val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCupom qtb_orc = new TCD_ItensCupom();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                val.id_prevenda = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_PREVENDA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_prevenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCupom val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCupom qtb_orc = new TCD_ItensCupom();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static void CancelarCF(TRegistro_NFCe val, TRegistro_VendaRapida venda, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe qtb_cupom = new TCD_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                if (val.Cd_modelo.Trim().Equals("65") &&
                    !val.Nr_protocolo.HasValue &&
                    !val.Id_contingencia.HasValue)
                    qtb_cupom.ExcluirNFCe(val);
                else
                {
                    TList_ItensCupom itens = new TList_ItensCupom();
                    itens = Buscar(val.Cd_empresa, string.Empty, string.Empty, venda.Id_vendarapidastr, string.Empty, qtb_cupom.Banco_Dados);
                    itens.ForEach(p => Excluir(p, qtb_cupom.Banco_Dados));
                    Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(new List<TRegistro_VendaRapida> { venda }, qtb_cupom.Banco_Dados);
                    //Cancelar cupom
                    qtb_cupom.executarSql("update tb_pdv_nfce set st_registro = 'C', dt_alt = getdate() where cd_empresa = '" + val.Cd_empresa.Trim() + "' and id_nfce = " + val.Id_nfcestr, null);
                    //Cancelar Itens do Cupom
                    Faturamento.PDV.TCN_NFCe_Item.Buscar(val.Id_nfcestr,
                                                         val.Cd_empresa,
                                                         string.Empty,
                                                         qtb_cupom.Banco_Dados)
                                                         .ForEach(p => Faturamento.PDV.TCN_NFCe_Item.CancelarItemCF(p, qtb_cupom.Banco_Dados));
                    //Excluir Venda Rapida de Origem somente se o caixa estiver aberto
                    if (val.Cd_modelo.Trim().Equals("65"))
                        Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(new TCD_VendaRapida(qtb_cupom.Banco_Dados).Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_Cupom_X_VendaRapida x " +
                                                                        "inner join tb_pdv_cupom_x_movcaixa y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_vendarapida = y.id_cupom " +
                                                                        "inner join VTB_PDV_Caixa k " +
                                                                        "on y.id_caixa = k.id_caixa " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.id_vendarapida = a.id_cupom " +
                                                                        "and isnull(k.st_registro, 'A') in ('A', 'F') " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_nfcestr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty), qtb_cupom.Banco_Dados);
                }
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar CF/NFCe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }
    }
}

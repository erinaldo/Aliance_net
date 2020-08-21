using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_AbastVeiculo
    {
        public static TList_AbastVeiculo Buscar(string Id_abastecimento,
                                                string Cd_empresa,
                                                string Id_viagem,
                                                string Id_veiculo,
                                                string Placa,
                                                string Id_despesa,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string Tp_abastecimento,
                                                string Tp_registro,
                                                int vTop,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecimento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(d.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().Equals("R") ? "a.dt_requisicao" : "a.dt_abastecimento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().Equals("R") ? "a.dt_requisicao" : "a.dt_abastecimento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Tp_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_abastecimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_abastecimento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_registro.Trim() + ")";
            }
            return new TCD_AbastVeiculo(banco).Select(filtro, vTop, string.Empty);
        }

        public static string Gravar(TRegistro_AbastVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                if (val.Tp_abastecimento.Trim().ToUpper().Equals("P") &&
                    val.Tp_registro.Trim().ToUpper().Equals("A") &&
                    (!val.Id_lanctoestoque.HasValue))
                {
                    //Buscar local armazenagem
                    object obj = new CamadaDados.Frota.Cadastros.TCD_CfgFrota(qtb_abast.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.cd_local");
                    if (obj == null)
                        throw new Exception("Não existe local armazenagem configurado para empresa " + val.Cd_empresa.Trim());
                    //Baixar estoque
                    string ret_est =
                    CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Cd_local = obj.ToString(),
                            Dt_lancto = val.Dt_abastecimento,
                            Tp_movimento = "S",
                            Qtd_entrada = decimal.Zero,
                            Qtd_saida = val.Volume,
                            Vl_unitario = val.Vl_unitario,
                            Vl_subtotal = val.Vl_subtotal,
                            Tp_lancto = "N",
                            St_registro = "A",
                            Ds_observacao = "BAIXA ABASTECIMENTO INTERNO"
                        }, qtb_abast.Banco_Dados);
                    //baixa estoque no abastecimento
                    val.Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE"));
                }
                val.Id_abastecimentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_abast.Gravar(val), "@P_ID_ABASTECIMENTO");
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar abastecimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AbastVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                qtb_abast.Excluir(val);
                //Cancelar estoque abastecimento proprio
                if (val.Id_lanctoestoque.HasValue)
                    CamadaNegocio.Estoque.TCN_LanEstoque.DeletarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Id_lanctoestoque = val.Id_lanctoestoque.Value
                        }, qtb_abast.Banco_Dados);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir abastecimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }
    }
}

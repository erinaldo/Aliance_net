using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Lancamento;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using CamadaDados.Almoxarifado;
using System.Data;
using CamadaNegocio.Estoque;

namespace CamadaNegocio.Fazenda.Lancamento
{
    public class TCN_LanInsumos
    {
        public static TList_LanInsumos Busca(decimal vid_lancto,
                                             decimal vid_lanctoativ,
                                             decimal vid_requisicao,
                                             string vcd_produto)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (vid_lancto > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vid_lancto.ToString();
            }
            if (vid_lanctoativ > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lanctoativ";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vid_lanctoativ.ToString();
            }
            if (vid_requisicao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_requisicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vid_requisicao.ToString();
            }
            if (!(vcd_produto.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vcd_produto + "'";
            }

            TCD_LanInsumos cd = new TCD_LanInsumos();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaLanInsumos(TRegistro_LanInsumos val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanInsumos lanInsumo = new TCD_LanInsumos();
            try
            {
                if (banco == null)
                {
                    lanInsumo.CriarBanco_Dados(true);
                    pode_liberar = true;
                    banco = lanInsumo.Banco_Dados;
                }
                else
                    lanInsumo.Banco_Dados = banco;

                string retorno = "";
                TRegistro_LanInsumos_X_Estoque InsumoEstoque = new TRegistro_LanInsumos_X_Estoque();

                if (val.ID_Requisicao <= 0 || val.ID_Requisicao == null)
                {
                    decimal saldo = 0;
                    TCN_LanEstoque.SaldoEstoqueLocal(val.CD_Empresa, val.CD_Produto, val.CD_Local, ref saldo, banco);

                    if (val.Quantidade > saldo)
                        throw new Exception("Atenção, não há SALDO suficiente desse PRODUTO no LOCAL DE ARMAZENAGEM!");

                    //GRAVA O LANÇAMENTO EM ESTOQUE
                    TRegistro_LanEstoque reg_estoque = new TRegistro_LanEstoque();
              
                    reg_estoque.Cd_produto = val.CD_Produto;
                    reg_estoque.Cd_local = val.CD_Local;
                    reg_estoque.Qtd_entrada = 0;
                    reg_estoque.Qtd_saida = val.Quantidade;
                    reg_estoque.Cd_empresa = val.CD_Empresa;
                    reg_estoque.St_registro = "A";
                    reg_estoque.Vl_unitario = val.VL_Unitario;
                    reg_estoque.Vl_subtotal = val.VL_Total;
                    reg_estoque.Tp_movimento = "S";
                    reg_estoque.Ds_observacao = "LANÇAMENTO DE INSUMO CÓDIGO DO INSUMO - "+val.CD_Produto;
                    reg_estoque.Tp_lancto = "N";

                    TCD_LanEstoque TCD_Estoque = new TCD_LanEstoque();
                    TCD_Estoque.Banco_Dados = banco;
                    string ret_estoque = TCD_Estoque.GravaEstoque(reg_estoque);
                    InsumoEstoque.Id_LanctoEstoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_estoque, "@@P_ID_LANCTOESTOQUE"));
                }
                else
                {
                    TpBusca[] filtro = new TpBusca[0];

                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[0].vNM_Campo = "d.cd_EMPRESA";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.CD_Empresa + "'";

                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[1].vNM_Campo = "a.cd_produto";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.CD_Produto + "'";

                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[2].vNM_Campo = "E.ST_REGISTRO";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'A'";

                    DataTable TB_Local_Amx = null;//new TCD_Movimentacao().BuscarSaldo(filtro);
                    if ((TB_Local_Amx == null) || (TB_Local_Amx.Rows.Count == 0))
                    {
                        throw new Exception("O Almoxarifado não possui SALDO suficiente!");
                    }
                    else
                    {
                        if (val.Quantidade > Convert.ToDecimal(TB_Local_Amx.Rows[0]["Tot_Saldo"].ToString()))
                        {
                            throw new Exception("O Almoxarifado não possui SALDO suficiente!");
                        }
                    }

                    //BUSCA OS DADOS DE ENTREGA
                    TpBusca[] vBusca = new TpBusca[0];

                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Requisicao";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = val.ID_Requisicao.ToString();

                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "b.cd_produto";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + val.CD_Produto + "'";

                    //InsumoEstoque.Id_LanctoEstoque = Convert.ToDecimal(new TCD_LanEntregaRequisicao().BuscarEscalar(vBusca, "b.Id_LanctoEstoque").ToString());
                    //InsumoEstoque.Id_Entrega = Convert.ToDecimal(new TCD_LanEntregaRequisicao().BuscarEscalar(vBusca, "a.Id_Entrega").ToString());
                }

                if (InsumoEstoque.Id_LanctoEstoque > 0)
                {
                    //MANDA GRAVAR A INSUMO
                    val.ID_Lancto = 0;
                    retorno = lanInsumo.GravaLanInsumos(val);
                    InsumoEstoque.Id_Lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LANCTO"));
                    InsumoEstoque.ID_LanctoAtiv = Convert.ToDecimal(val.ID_LanctoAtiv);
                    //GRAVA O LANÇAMENTO INSUMO X ESTOQUE
                    InsumoEstoque.Cd_Produto = val.CD_Produto;
                    InsumoEstoque.Cd_Empresa = val.CD_Empresa;

                    TCD_LanInsumos_X_Estoque TCD_InsumoEstoque = new TCD_LanInsumos_X_Estoque();
                    TCD_InsumoEstoque.Banco_Dados = banco;
                    TCD_InsumoEstoque.GravaLanInsumos_X_Estoque(InsumoEstoque);
                }
                else
                {
                    throw new Exception("Não foi possível lançar o estoque, por favor tente novamente!");
                }

                if (pode_liberar)
                    lanInsumo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception erro)
            {
                if (pode_liberar)
                    lanInsumo.Banco_Dados.RollBack_Tran();

                throw new Exception(erro.Message);
            }
            finally
            {
                if (pode_liberar)
                    lanInsumo.deletarBanco_Dados();
            }
        }

        public static string DeletaLanInsumos(TRegistro_LanInsumos val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanInsumos lanInsumo = new TCD_LanInsumos();
            try
            {
                if (banco == null)
                {
                    lanInsumo.CriarBanco_Dados(true);
                    pode_liberar = true;
                    banco = lanInsumo.Banco_Dados;
                }
                else
                    lanInsumo.Banco_Dados = banco;

                string retorno = "";

                TlistLanInsumos_X_Estoque listaEstoque = TCN_LanInsumos_X_Estoque.Busca(val.CD_Empresa, val.CD_Produto, 0, Convert.ToDecimal(val.ID_Lancto), 0, Convert.ToDecimal(val.ID_LanctoAtiv));

                if (listaEstoque != null && listaEstoque.Count > 0)
                {
                    if (val.ID_Requisicao <= 0 || val.ID_Requisicao == null)
                    {
                        //GRAVA O LANÇAMENTO EM ESTOQUE
                        TRegistro_LanEstoque reg_estoque = new TRegistro_LanEstoque();

                        reg_estoque.Cd_produto = val.CD_Produto;
                        reg_estoque.Cd_local = val.CD_Local;
                        reg_estoque.Id_lanctoestoque = listaEstoque[0].Id_LanctoEstoque;
                        reg_estoque.Qtd_saida = val.Quantidade;
                        reg_estoque.Cd_empresa = val.CD_Empresa;
                        reg_estoque.St_registro = "C";
                        reg_estoque.Tp_movimento = "S";

                        TCD_LanEstoque TCD_Estoque = new TCD_LanEstoque();
                        TCD_Estoque.Banco_Dados = banco;
                        string ret_estoque = TCD_Estoque.DeletaEstoque(reg_estoque);
                    }


                    //MANDA GRAVAR A INSUMO
                    TRegistro_LanInsumos_X_Estoque InsumoEstoque = new TRegistro_LanInsumos_X_Estoque();
                    InsumoEstoque.Id_Lancto = Convert.ToDecimal(val.ID_Lancto);
                    InsumoEstoque.ID_LanctoAtiv = Convert.ToDecimal(val.ID_LanctoAtiv);
                    //GRAVA O LANÇAMENTO INSUMO X ESTOQUE
                    InsumoEstoque.Cd_Produto = val.CD_Produto;
                    InsumoEstoque.Cd_Empresa = val.CD_Empresa;
                    InsumoEstoque.Id_LanctoEstoque = listaEstoque[0].Id_LanctoEstoque;

                    TCD_LanInsumos_X_Estoque TCD_InsumoEstoque = new TCD_LanInsumos_X_Estoque();
                    TCD_InsumoEstoque.Banco_Dados = banco;
                    TCD_InsumoEstoque.DeletaLanInsumos_X_Estoque(InsumoEstoque);

                    retorno = lanInsumo.DeletaLanInsumos(val);
                }
                else
                {
                    throw new Exception("Não foi possível remover o insumo, por favor tente novamente!");
                }

                if (pode_liberar)
                    lanInsumo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception erro)
            {
                if (pode_liberar)
                    lanInsumo.Banco_Dados.RollBack_Tran();

                throw new Exception(erro.Message);
            }
            finally
            {
                if (pode_liberar)
                    lanInsumo.deletarBanco_Dados();
            }
            
        }
    }

       


}

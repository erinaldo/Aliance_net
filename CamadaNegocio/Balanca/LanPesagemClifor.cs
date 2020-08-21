using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_LanPesagemClifor
    {
        public static TList_RegLanPesagemClifor Busca(string vCD_Empresa,
                                                      string vID_Ticket,
                                                      string vTP_Pesagem,
                                                      string vID_Desdobro,
                                                      string vNR_Pedido,
                                                      string vCD_CliforPedido,
                                                      string vNM_CliforPedido,
                                                      string vCD_Clifor,
                                                      string vNM_Clifor,
                                                      bool St_buscarItem,
                                                      Int32 vTop,
                                                      string vNM_Campo,
                                                      TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.ST_Registro";
            vBusca[0].vVL_Busca = "'A'";
            vBusca[0].vOperador = "=";
            if (!string.IsNullOrEmpty(vCD_Empresa.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vID_Ticket.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Pesagem.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vID_Desdobro.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Desdobro";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Desdobro;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Pedido.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_CliforPedido.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CliforPedido";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CliforPedido.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNM_CliforPedido.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_CliforPedido";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNM_CliforPedido.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNM_Clifor.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNM_Clifor + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (St_buscarItem)
            {
                TList_RegLanPesagemClifor lClifor = new TCD_LanPesagemClifor(banco).Select(vBusca, vTop, vNM_Campo);
                lClifor.ForEach(p=> p.Desdobroprodutos = TCN_LanPesagemProduto.Busca(p.Cd_empresa,
                                                                                     p.Id_ticket.ToString(),
                                                                                     p.Tp_pesagem,
                                                                                     string.Empty,
                                                                                     p.Id_desdobro.ToString(),
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     0,
                                                                                     string.Empty,
                                                                                     banco));
                return lClifor;
            }
            else
                return new TCD_LanPesagemClifor(banco).Select(vBusca, vTop, vNM_Campo);
        }
        
        public static string GravarPesagemClifor(TList_RegLanPesagemClifor val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = string.Empty;
                val.ForEach(p => retorno += GravarPesagemClifor(p, banco));
                return retorno;
            }
            else
                return string.Empty;
        }

        public static string GravarPesagemClifor(TRegistro_LanPesagemClifor val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPesagemClifor qtb_psclifor = new TCD_LanPesagemClifor();
            try
            {
                if (banco == null)
                {
                    qtb_psclifor.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psclifor.Banco_Dados = banco;
                //Gravar Desdobro Clifor
                string retorno = qtb_psclifor.GravarPesagemClifor(val);
                val.Id_desdobro = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_DESDOBRO"));
                //Gravar Desdobro Produtos
                val.Desdobroprodutos.ForEach(p =>
                    {
                        p.Id_ticket = val.Id_ticket;
                        p.Cd_empresa = val.Cd_empresa;
                        p.Tp_pesagem = val.Tp_pesagem;
                        p.Id_desdobro = val.Id_desdobro;
                        TCN_LanPesagemProduto.GravarPesagemProduto(p, qtb_psclifor.Banco_Dados);
                    });
                val.DesdProdExcluir.ForEach(p => TCN_LanPesagemProduto.DeletarPesagemProduto(p, qtb_psclifor.Banco_Dados));
                
                if (pode_liberar)
                    qtb_psclifor.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_psclifor.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);                
            }
            finally
            {
                if (pode_liberar)
                    qtb_psclifor.deletarBanco_Dados();
            }
        }

        public static string DeletarPesagemClifor(TList_RegLanPesagemClifor val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = string.Empty;
                for (int i = 0; i < val.Count; i++)
                    retorno = retorno + "|" + DeletarPesagemClifor(val[i], banco);
                return retorno;
            }
            else
                return string.Empty;
        }

        public static string DeletarPesagemClifor(TRegistro_LanPesagemClifor val, TObjetoBanco banco)
        {
            TCD_LanPesagemClifor qtb_psclifor = new TCD_LanPesagemClifor();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_psclifor.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psclifor.Banco_Dados = banco;
                //Deletar todos os registros da tabela <TB_BAL_Produto>
                TCN_LanPesagemProduto.DeletarPesagemProduto(val.Desdobroprodutos, qtb_psclifor.Banco_Dados);

                qtb_psclifor.DeletarPesagemClifor(val);
                if (pode_liberar)
                    qtb_psclifor.Banco_Dados.Commit_Tran();
                return "OK"; 
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_psclifor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir desdobro clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_psclifor.deletarBanco_Dados();
            }
        }

        public static void recalculaNota(TRegistro_LanPesagem val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPesagemClifor qtb_psclifor = new TCD_LanPesagemClifor();
            try
            {
                if (banco == null)
                {
                    qtb_psclifor.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psclifor.Banco_Dados = banco;
                //Recalcular Notas do Desdobro
                qtb_psclifor.recalculaNotas(val);
                if (pode_liberar)
                    qtb_psclifor.Banco_Dados.Commit_Tran();
            }
            finally
            {
                if (pode_liberar)
                    qtb_psclifor.deletarBanco_Dados();
            }
        }
    }
}

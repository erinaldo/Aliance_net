using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_EmprestimoConcedido
    {
        public static TList_EmprestimoConcedido Buscar(string Id_emprestimo,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       string Id_retirada,
                                                       string Id_caixa,
                                                       string Placa,
                                                       string Nm_motorista,
                                                       string St_registro,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_emprestimo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_emprestimo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_emprestimo;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Id_retirada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_retirada";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_retirada;
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", string.Empty)))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(a.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nm_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_motorista";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_motorista.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_EmprestimoConcedido(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EmprestimoConcedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EmprestimoConcedido qtb_emp = new TCD_EmprestimoConcedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else qtb_emp.Banco_Dados = banco;
                val.Id_emprestimostr = CamadaDados.TDataQuery.getPubVariavel(qtb_emp.Gravar(val), "@P_ID_EMPRESTIMO");
                if (val.rDup != null)
                {
                    val.rDup.Nr_docto = "EMP" + val.Id_emprestimostr;
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_emp.Banco_Dados);
                    val.Cd_empresa = val.rDup.Cd_empresa;
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                if (val.rRetirada != null)
                {
                    //Gravar retirada
                    TCN_RetiradaCaixa.Gravar(val.rRetirada, qtb_emp.Banco_Dados);
                    //Processar retirada
                    TCN_RetiradaCaixa.ProcessarRetirada(val.rRetirada, qtb_emp.Banco_Dados);
                    val.Id_retirada = val.rRetirada.Id_retirada;
                }
                //Alterar emprestimo concedido
                qtb_emp.Gravar(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return val.Id_emprestimostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EmprestimoConcedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EmprestimoConcedido qtb_emp = new TCD_EmprestimoConcedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else qtb_emp.Banco_Dados = banco;
                //Estornar duplicata
                if (val.Nr_lancto.HasValue)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                                  val.Nr_lanctostr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  qtb_emp.Banco_Dados)[0], qtb_emp.Banco_Dados);
                //Estornar Retirada Caixa
                if (val.Id_retirada.HasValue)
                {
                    val.rRetirada = TCN_RetiradaCaixa.Buscar(val.Id_retiradastr,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             qtb_emp.Banco_Dados)[0];
                    if (val.rRetirada.Id_transf.HasValue)
                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(
                            new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_emp.Banco_Dados).Select(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FIN_TransfCaixa x " +
                                            "where x.cd_conta_ent = a.cd_contager " +
                                            "and x.cd_lanctocaixa_ent = a.cd_lanctocaixa " +
                                            "and x.id_transf = " + val.rRetirada.Id_transfstr + ")"
                            }
                        }, 1, string.Empty)[0], null, qtb_emp.Banco_Dados);
                    //Verificar cheque
                    CamadaNegocio.Faturamento.PDV.TCN_Retirada_X_Cheque.Buscar(val.Id_retiradastr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               qtb_emp.Banco_Dados).ForEach(p =>
                                                                               {
                                                                                   CamadaNegocio.Financeiro.Titulo.TCN_TransfTitulo.Buscar(p.Cd_empresa,
                                                                                                                                           string.Empty,
                                                                                                                                           string.Empty,
                                                                                                                                           decimal.Zero,
                                                                                                                                           decimal.Zero,
                                                                                                                                           p.Nr_lanctocheque.Value,
                                                                                                                                           p.Cd_banco,
                                                                                                                                           0,
                                                                                                                                           string.Empty,
                                                                                                                                           qtb_emp.Banco_Dados).ForEach(v =>
                                                                                                                                           {
                                                                                                                                               //Estornar caixa origem
                                                                                                                                               CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                                                                                                                                                   CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(v.Cd_conta_orig,
                                                                                                                                                                                                     v.Cd_lanctocaixa_orig.ToString(),
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     false,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     false,
                                                                                                                                                                                                     qtb_emp.Banco_Dados)[0], qtb_emp.Banco_Dados);
                                                                                                                                               CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.DeletarTituloCaixa(
                                                                                                                                                   new CamadaDados.Financeiro.Titulo.TRegistro_LanTituloXCaixa()
                                                                                                                                                   {
                                                                                                                                                       Cd_banco = p.Cd_banco,
                                                                                                                                                       Cd_contager = v.Cd_conta_orig,
                                                                                                                                                       Cd_empresa = p.Cd_empresa,
                                                                                                                                                       Cd_lanctocaixa = v.Cd_lanctocaixa_orig,
                                                                                                                                                       Nr_lanctocheque = p.Nr_lanctocheque.Value
                                                                                                                                                   }, qtb_emp.Banco_Dados);
                                                                                                                                               //Estornar caixa destino
                                                                                                                                               CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                                                                                                                                                   CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(v.Cd_conta_dest,
                                                                                                                                                                                                     v.Cd_lanctocaixa_dest.ToString(),
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     false,
                                                                                                                                                                                                     string.Empty,
                                                                                                                                                                                                     decimal.Zero,
                                                                                                                                                                                                     false,
                                                                                                                                                                                                     qtb_emp.Banco_Dados)[0], qtb_emp.Banco_Dados);
                                                                                                                                               CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.DeletarTituloCaixa(
                                                                                                                                                   new CamadaDados.Financeiro.Titulo.TRegistro_LanTituloXCaixa()
                                                                                                                                                   {
                                                                                                                                                       Cd_banco = p.Cd_banco,
                                                                                                                                                       Cd_contager = v.Cd_conta_dest,
                                                                                                                                                       Cd_empresa = p.Cd_empresa,
                                                                                                                                                       Cd_lanctocaixa = v.Cd_lanctocaixa_dest,
                                                                                                                                                       Nr_lanctocheque = p.Nr_lanctocheque.Value
                                                                                                                                                   }, qtb_emp.Banco_Dados);
                                                                                                                                               CamadaNegocio.Financeiro.Titulo.TCN_TransfTitulo.ExcluirTransfTitulo(v, qtb_emp.Banco_Dados);
                                                                                                                                           });
                                                                                   CamadaNegocio.Faturamento.PDV.TCN_Retirada_X_Cheque.Excluir(p, qtb_emp.Banco_Dados);
                                                                               });
                    //Cancelar retirada
                    TCN_RetiradaCaixa.Cancelar(val.rRetirada, qtb_emp.Banco_Dados);
                }
                //Cancelar emprestimo
                val.St_registro = "C";
                qtb_emp.Gravar(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
}

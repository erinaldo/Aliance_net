using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Balanca;
using System.IO;
using System.Windows.Forms;

namespace CamadaNegocio.Balanca
{
    public class TCN_PesagemDiversa
    {
        public static TList_PesagemDiversas Buscar(string Cd_empresa,
                                                 string Tp_pesagem,
                                                 string Id_ticket,
                                                 string Placacarreta,
                                                 string Cd_tpveiculo,
                                                 string Ds_observacao,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 string St_registro,
                                                 short vTop,
                                                 string vNm_campo,
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
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Placacarreta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placacarreta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placacarreta.Trim() + "'";
            }
            //if (!string.IsNullOrEmpty(Nr_pedido))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
            //    filtro[filtro.Length - 1].vOperador = "=";
            //    filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            //}
            //if (!string.IsNullOrEmpty(Nr_lanctoFiscal))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
            //    filtro[filtro.Length - 1].vOperador = "=";
            //    filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoFiscal;
            //}
            //if (!string.IsNullOrEmpty(Cd_produto))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
            //    filtro[filtro.Length - 1].vOperador = "=";
            //    filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            //}
            if (!string.IsNullOrEmpty(Cd_tpveiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tpveiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tpveiculo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_observacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_bruto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_bruto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

           return new  TCD_PesagemDiversas(banco).Select(filtro, vTop, vNm_campo);
            
        }

        public static string Gravar(TRegistro_PesagemDiversas val,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemDiversas qtb_pesagem = new TCD_PesagemDiversas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                if ((val.Ps_bruto > 0) && (val.Ps_tara > 0))
                    val.St_registro = "F";//Finalizar pesagem
                val.Id_ticketstr = CamadaDados.TDataQuery.getPubVariavel(qtb_pesagem.Gravar(val), "@P_ID_TICKET");
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
                return val.Id_ticketstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public static void AplicarPSDiversas(List<TRegistro_PesagemDiversas> val,
                                             CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemDiversas qtb_pesagem = new TCD_PesagemDiversas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                //Gravar Nota Fiscal em Pesagem Diversas
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_pesagem.Banco_Dados);
                val.ForEach(p =>
                    {
                        p.Nr_lanctoFiscal = rNf.Nr_lanctofiscal;
                        p.Id_NFItem = rNf.ItensNota[0].Id_nfitem;
                        qtb_pesagem.Gravar(p);
                    });
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro aplicar pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PesagemDiversas val, BancoDados.TObjetoBanco banco)
        {
            //Verificar se pesagem não tem aplicação 
            TList_LanAplicacaoPedido lAplicacao = TCN_LanAplicacaoPedido.Buscar(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                val.Cd_empresa,
                                                                                string.Empty,
                                                                                val.Id_ticket.ToString(),
                                                                                val.Tp_pesagem, banco);
            if (lAplicacao.Count > 0)
            {
                string msg = "";
                for (int i = 0; i < lAplicacao.Count; i++)
                    msg += "Aplicação...: " + lAplicacao[i].Id_aplicacao.ToString() + "\r\n" +
                           "Pedido......: " + lAplicacao[i].Nr_pedido.ToString() + "\r\n" +
                           "Nota Fiscal.: " + lAplicacao[i].Nr_notafiscalaplic.ToString() + "\r\n" +
                           "Serie NF....: " + lAplicacao[i].Nr_serieaplic.ToString() + "\r\n" +
                           "--------------------------------------\r\n";



                throw new Exception("Não é possivel excluir pesagem porque existe aplicação.\r\n\r\n" +
                                "-------Dados da Pesagem-------\r\n" +
                                "Empresa.....: " + val.Cd_empresa + "\r\n" +
                                "Ticket......: " + val.Id_ticket.ToString() + "\r\n" +
                                "TP. Pesagem.: " + val.Tp_pesagem + "\r\n\r\n" +
                                "--------Dados Aplicação---------\r\n" + msg);
            }
            bool st_transacao = false;
            TCD_PesagemDiversas qtb_pesagem = new TCD_PesagemDiversas();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                //Setar ST_Registro para C, pois a exclusão é somente lógica.
                val.St_registro = "C";
                qtb_pesagem.Gravar(val);
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar pesagem avulsa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public static void ImprimirTicket(TRegistro_PesagemDiversas val)
        {
            //Buscar configuracao impressao ticket do terminal

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
                CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Utils.Parametros.pubTerminal,
                                                             string.Empty,
                                                             null);
            if (lTerminal.Count.Equals(decimal.Zero))
                throw new Exception("Obrigatorio informar terminal para imprimir ticket pesagem.");
            if (lTerminal[0].Tp_imptick.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                throw new Exception("Obrigatorio configurar porta de impressão para utilizar tipo de impressão texto.");
            
             FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Ticket.txt");
            w = f.CreateText();
            try
            {
                //Buscar dados empresa
                CamadaDados.Diversos.TRegistro_CadEmpresa rEmp = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             null)[0];
                w.WriteLine("EMPRESA:  " + val.Nm_empresa.Trim().ToUpper().FormatStringDireita(60, ' ') + "CNPJ: " + rEmp.rClifor.Nr_cgc.Trim());
                w.WriteLine("ENDEREÇO: " + rEmp.rEndereco.Ds_endereco.Trim() +
                                            ", " + rEmp.rEndereco.Numero.Trim() +
                                            " - " + rEmp.rEndereco.Bairro.Trim() +
                                            " - " + rEmp.rEndereco.DS_Cidade.Trim() +
                                            ", " + rEmp.rEndereco.UF.Trim());
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("".FormatStringDireita(80, '-'));
                w.WriteLine("*********************************PESAGEM DIVERSA*********************************");
                w.WriteLine("".FormatStringDireita(80, '-'));
                w.WriteLine();
                w.WriteLine("  ROMANEIO: " + val.Id_ticket.ToString().FormatStringDireita(50, ' ') + "Data Ticket: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"));
                w.WriteLine("  PLACA:    " + val.Placacarreta.Trim().FormatStringDireita(10, ' '));
                w.WriteLine("  PRODUTO:  " + val.Ds_produto.Trim());
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("  PESO BRUTO:                              " + val.Ps_bruto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' ') +
                    "     " + (val.Dt_bruto.HasValue ? val.Dt_bruto.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty) + "  " + val.Tp_captura_bruto.Trim().ToUpper());
                w.WriteLine("  PESO TARA:                               " + val.Ps_tara.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' ') +
                    "     " + (val.Dt_tara.HasValue ? val.Dt_tara.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty) + "  " + val.Tp_captura_tara.Trim().ToUpper());
                w.WriteLine("  PESO LIQUIDO:                            " + val.Ps_liquido.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("  OBSERVACAO: " + val.Ds_observacao.Trim() + "\r\n  Atencao: Esta pesagem nao tem nenhuma relacao com o movimento interno.");
                w.WriteLine();
                w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                w.Write(Convert.ToChar(12));
                w.Write(Convert.ToChar(27));
                w.Write(Convert.ToChar(109));
                w.Flush();
                f.CopyTo(lTerminal[0].Porta_imptick);
            }
            catch (Exception ex)
            { MessageBox.Show("Erro impressão Ticket: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                w.Dispose();
                f = null;
            }
            
            
           
        }
    }
}

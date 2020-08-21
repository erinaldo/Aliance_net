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
    public class TCN_PesagemAvulsa
    {
        public static TList_PesagemAvulsa Buscar(string Cd_empresa,
                                                 string Tp_pesagem,
                                                 string Id_ticket,
                                                 string Placacarreta,
                                                 string Ds_carga,
                                                 string Nm_clifor,
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
            if (!string.IsNullOrEmpty(Ds_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_carga";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_carga.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_clifor.Trim() + "%')";
            }
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

            return new TCD_PesagemAvulsa(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_PesagemAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemAvulsa qtb_pesagem = new TCD_PesagemAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                if ((val.Ps_bruto > 0) && (val.Ps_tara > 0))
                    val.St_registro = "F";//Finalizar pesagem
                //Gravar pesagem avulsa
                string retorno = qtb_pesagem.Gravar(val as TRegistro_PesagemAvulsa);
                val.Id_ticketstr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_TICKET");
                //Gravar financeiro
                (val as TRegistro_PesagemAvulsa).lDup.ForEach(p =>
                    {
                        p.Nr_docto = val.Id_ticket.ToString();
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(p, false, qtb_pesagem.Banco_Dados);
                        //Gravar pesagem avulsa X duplicata
                        TCN_PsAvulsa_X_Duplicata.GravarPsAvulsa_X_Duplicata(
                            new TRegistro_PsAvulsa_X_Duplicata()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Id_ticket = val.Id_ticket,
                                Tp_pesagem = val.Tp_pesagem,
                                Nr_lancto = p.Nr_lancto
                            }, qtb_pesagem.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pesagem avulsa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PesagemAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemAvulsa qtb_pesagem = new TCD_PesagemAvulsa();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                //Verificar se a pesagem possui financeiro
                if (val.Nr_lancto != null)
                {
                    //Verificar se a pesagem nao possui financeiro aberto
                    object objfin = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_pesagem.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lancto.Value.ToString()
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                        }, "1");
                    if (objfin != null)
                        if (objfin.ToString().Trim().Equals("1"))
                            throw new Exception("Pesagem possui financeiro em aberto.\r\n" +
                                                "Para cancelar pesagem necessario antes cancelar o financeiro.\r\n" +
                                                "Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Nº Lancto: " + val.Nr_lancto.Value.ToString());
                }
                qtb_pesagem.Excluir(val);
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

        public static void ImprimirTicket(TRegistro_PesagemAvulsa val)
        {
            //Buscar configuracao impressao ticket do terminal

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
                CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Utils.Parametros.pubTerminal,
                                                             string.Empty,
                                                             null);
            int i = 0;
            if (lTerminal.Count.Equals(decimal.Zero))
                throw new Exception("Obrigatorio informar terminal para imprimir ticket pesagem.");
            if (lTerminal[0].Tp_imptick.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                throw new Exception("Obrigatorio configurar porta de impressão para utilizar tipo de impressão texto.");

                FileInfo f = null;
                StreamWriter w = null;
                try
                {
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Ticket.txt");
                    w = f.CreateText();
                    for (i = 0; i < 2; i++)
                    {
                        if (i == 1)
                            for (int j = 0; j < 10; j++) 
                                w.WriteLine();                
                        w.WriteLine("EMPRESA:  " + val.Nm_empresa.Trim().ToUpper().FormatStringDireita(46, ' ') + "CNPJ: " + val.Cnpjempresa.Trim());
                        w.WriteLine("ENDEREÇO: " + val.Ds_enderecoempresa.Trim() +
                                                ", " + val.Numeroempresa.Trim() +
                                                " - " + val.Bairroempresa.Trim() +
                                                " - " + val.Ds_cidadeempresa.Trim() +
                                                ", " + val.Ufempresa.Trim());
                        w.WriteLine();
                        w.WriteLine();
                        w.WriteLine("".FormatStringDireita(80, '-'));
                        w.WriteLine("*********************************PESAGEM AVULSA*********************************");
                        w.WriteLine("".FormatStringDireita(80, '-'));
                        w.WriteLine();
                        w.WriteLine("  ROMANEIO: " + val.Id_ticket.ToString().FormatStringDireita(40, ' ') + "Data Ticket: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"));
                        w.WriteLine("  PLACA:    " + val.Placacarreta.Trim().FormatStringDireita(10, ' ') + "Cliente: " + val.Nm_clifor.Trim());
                        w.WriteLine("  PRODUTO:  " + val.Ds_carga.Trim());
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
                        w.WriteLine("  TAXA PESAGEM: " + val.Vl_taxa.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        w.WriteLine("  OBSERVACAO: " + val.Ds_observacao.Trim() + "\r\n  Atencao: Esta pesagem nao tem nenhuma relacao com o movimento interno.");
                        w.WriteLine();
                        w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");
                    }
                    //Copiar para a porta
                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(lTerminal[0].Porta_imptick);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Erro impressão Ticket: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
    }
}

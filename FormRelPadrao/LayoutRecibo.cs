using System;
using Utils;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;
using System.IO;

namespace FormRelPadrao
{
    public class TCN_LayoutRecibo
    {
        public static void Imprime_Recibo(bool Altera_relatorio, 
                                          string referente,
                                          TRegistro_LanLiquidacao rLiquidacao,
                                          TList_RegLanDuplicata lDuplicata)
        {
            string Valor_Extenso = string.Empty;
            decimal valorLiquidado = 0;
            string Observacao = rLiquidacao.ComplHistorico;
           
            
            BindingSource BS_Duplicata = new BindingSource();
            BS_Duplicata.DataSource = lDuplicata;
            //Preencher dados clifor da duplicata
            BindingSource BinClifor = new BindingSource();
            if (BS_Duplicata.Current != null)
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
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
                                                                  1,
                                                                  null);
            BindingSource BinFIN = new BindingSource();

            //Preencher dados endereco clifor da duplicata
            BindingSource End = new BindingSource();
            End.DataSource = TCN_CadEndereco.Buscar((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    1, 
                                                    null);
            //Preencher dados empresa da duplicata
            BindingSource Empresa = new BindingSource();
            Empresa.DataSource = TCN_CadEmpresa.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa, string.Empty, string.Empty, null);
            if (Empresa.Count.Equals(0))
                return;
            //Preencher dados clifor empresa
            BindingSource cliforEmpresa = new BindingSource();
            cliforEmpresa.DataSource = TCN_CadClifor.Busca_Clifor((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
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
                                                                  1,
                                                                  null);
            //Preencher dados endereco empresa da duplicata
            BindingSource endEmpresa = new BindingSource();
            endEmpresa.DataSource = TCN_CadEndereco.Buscar((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                            (Empresa.DataSource as TList_CadEmpresa)[0].Cd_endereco,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            1,
                                                            null);

            valorLiquidado = rLiquidacao.Cvl_aliquidar_padrao > 0 ? (rLiquidacao.Cvl_aliquidar_padrao - rLiquidacao.cVl_descontoconcedido) :
                            (rLiquidacao.Vl_liquidado_padrao + rLiquidacao.Vl_JuroAcrescimo - rLiquidacao.cVl_descontoconcedido);
            Relatorio rel = new Relatorio();
            rel.Altera_Relatorio = Altera_relatorio;
            //Buscar Moeda da Conta Gerencial
            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                    "where x.cd_moeda = a.cd_moeda "+
                                    "and x.cd_contager = '" + rLiquidacao.Cd_contager.Trim() + "')"
                    }
                }, 0, string.Empty);
            if (lMoeda.Count > 0)
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
            else
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, "Real", "Reais");

            //Buscar valor devolucao adiantamento
            object obj = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca() 
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FIN_Liquidacao_X_Adto_Caixa x "+
			                                    "where x.CD_ContaGer = a.CD_ContaGer " +
			                                    "and x.CD_LanctoCaixa = a.CD_LanctoCaixa " +
			                                    "and x.CD_Empresa = '" + rLiquidacao.Cd_empresa + "'" +
			                                    "and x.Nr_Lancto = " + rLiquidacao.Nr_lancto + 
			                                    "and x.CD_Parcela = " + rLiquidacao.Cd_parcela + ")" 
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_estorno, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                }
                            }, lDuplicata[0].Tp_mov.ToUpper().Equals("R") ? 
                              "isnull(sum(a.vl_pagar), 0)" :
                              "isnull(sum(a.vl_receber), 0)");
            
            rel.Nome_Relatorio = "TFLanContas_Recibo";
            rel.NM_Classe = "TFLanContas_Recibo";
            rel.Modulo = "FIN";
            rel.Parametros_Relatorio.Add("VL_DESCONTO", rLiquidacao.cVl_descontoconcedido);
            rel.Parametros_Relatorio.Add("VL_JUROACRESCIMO", rLiquidacao.Vl_JuroAcrescimo);
            rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso.Trim());
            rel.Parametros_Relatorio.Add("VALORLIQUIDADO", valorLiquidado);
            rel.Parametros_Relatorio.Add("OBSERVACAO", Observacao);
            rel.Parametros_Relatorio.Add("REFERENTE", referente);
            rel.Parametros_Relatorio.Add("DT_LIQUIDACAO", rLiquidacao.Dt_Liquidacao.Value);
            rel.Parametros_Relatorio.Add("VL_DEVADTO", obj != null ? Convert.ToDecimal(obj.ToString()) : decimal.Zero);
            if (Empresa.Count > 0)
                if((Empresa.List[0] as TRegistro_CadEmpresa).Img != null)
                    rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as TRegistro_CadEmpresa).Img);
            rel.Adiciona_DataSource("CLIFOR", BinClifor);
            rel.Adiciona_DataSource("ENDERECO", End);
            rel.Adiciona_DataSource("EMPRESA", Empresa);
            rel.Adiciona_DataSource("CLIFOREMPRESA", cliforEmpresa);
            rel.Adiciona_DataSource("ENDEMPRESA", endEmpresa);
            rel.DTS_Relatorio = BS_Duplicata;
            if (!Altera_relatorio)
            {
                //Chamar tela de impressao relatorio
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RECIBO QUITAÇÃO DUPLICATA " + rLiquidacao.Nr_lancto.ToString() +
                                     "/" + rLiquidacao.Cd_parcela.ToString();
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        rel.Gera_Relatorio("RECIBO QUITAÇÃO",
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RECIBO QUITAÇÃO DUPLICATA " + rLiquidacao.Nr_lancto.ToString() +
                                                 "/" + rLiquidacao.Cd_parcela.ToString(),
                                                 fImp.pDs_mensagem);
                }
            }
            else
                rel.Gera_Relatorio();
        }

        
        
        
        //impressao da tela de lancto avulso de recibos
        public static void Imprime_Recibo(bool Altera_relatorio,
                                            string cd_clifor,
                                            string nm_clifor,
                                            string referente,
                                            string cd_empresa,
                                            string nm_empresa,
                                            string cd_endereco,
                                            string ds_endereco,
                                            string nr_dup,
                                            string cd_parcela,
                                            decimal val_Recibo,
                                            DateTime data_Liq,
                                            string tp_mov,
                                            string observacao)
        {
            string Valor_Extenso = "";
            decimal valorLiquidado = 0;
            string Observacao = referente +"/" +cd_parcela + "   "+ observacao;

            BindingSource BS_Duplicata = new BindingSource();
            TRegistro_LanDuplicata ldup = new TRegistro_LanDuplicata();
            ldup.Cd_clifor = cd_clifor;
            ldup.Cd_empresa = cd_empresa;
            ldup.Cd_endereco = cd_endereco;
            ldup.Tp_mov = tp_mov;
            ldup.Cd_empresa = cd_empresa;
            ldup.Nm_empresa = nm_empresa;
            ldup.Nm_clifor = nm_clifor;
            BS_Duplicata.DataSource = ldup;
            //Preencher dados clifor da duplicata
            BindingSource BinClifor = new BindingSource();
            if (BS_Duplicata.Current != null)
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor(cd_clifor,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
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
                                                                  1,
                                                                  null);
            //Preencher dados endereco clifor da duplicata
            BindingSource End = new BindingSource();
            End.DataSource = TCN_CadEndereco.Buscar(cd_clifor, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    string.Empty, 
                                                    1, 
                                                    null);
            //Preencher dados empresa da duplicata
            BindingSource Empresa = new BindingSource();
            Empresa.DataSource = TCN_CadEmpresa.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa, string.Empty, string.Empty, null);
            //Preencher dados clifor empresa
            BindingSource cliforEmpresa = new BindingSource();
            cliforEmpresa.DataSource = TCN_CadClifor.Busca_Clifor((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
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
                                                                    1,
                                                                    null);
            //Preencher dados endereco empresa da duplicata
            BindingSource endEmpresa = new BindingSource();
            endEmpresa.DataSource = TCN_CadEndereco.Buscar((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                            (Empresa.DataSource as TList_CadEmpresa)[0].Cd_endereco,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            1,
                                                            null);

            valorLiquidado = val_Recibo;
            Relatorio rel = new Relatorio();
            rel.Altera_Relatorio = Altera_relatorio;
            Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, "Real", "Reais");
            rel.Nome_Relatorio = "TFLanContas_Recibo";
            rel.NM_Classe = "TFLanContas_Recibo";
            rel.Modulo = "FIN";
            rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso.ToString());
            rel.Parametros_Relatorio.Add("VALORLIQUIDADO", valorLiquidado);
            rel.Parametros_Relatorio.Add("OBSERVACAO", Observacao);
            rel.Parametros_Relatorio.Add("REFERENTE", Observacao);
            rel.Parametros_Relatorio.Add("DT_LIQUIDACAO", data_Liq);
            rel.Adiciona_DataSource("CLIFOR", BinClifor);
            rel.Adiciona_DataSource("ENDERECO", End);
            rel.Adiciona_DataSource("EMPRESA", Empresa);
            rel.Adiciona_DataSource("CLIFOREMPRESA", cliforEmpresa);
            rel.Adiciona_DataSource("ENDEMPRESA", endEmpresa);
            rel.DTS_Relatorio = BS_Duplicata;
            if (!Altera_relatorio)
            {
                //Chamar tela de impressao relatorio
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RECIBO QUITAÇÃO DUPLICATA " + nr_dup +
                                     "/" + cd_parcela;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        rel.Gera_Relatorio("RECIBO QUITAÇÃO",
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RECIBO QUITAÇÃO DUPLICATA " + nr_dup +
                                                 "/" + cd_parcela,
                                                 fImp.pDs_mensagem);
                }
            }
            else
                rel.Gera_Relatorio();
        }


        public static void Imprime_ReciboTexto(string referente,
                                               TRegistro_LanLiquidacao rLiquidacao)
        {
            //Buscar Dados Empresa
            TList_CadEmpresa lEmpresa =
                TCN_CadEmpresa.Busca(rLiquidacao.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);

            //Dados clifor duplicata
            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                TCN_CadClifor.Busca_Clifor_Codigo(rLiquidacao.Cd_clifor, null);
            //Buscar Endereço Duplicata
            object obj = new TCD_LanDuplicata().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rLiquidacao.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_lancto",
                        vOperador = "=",
                        vVL_Busca = rLiquidacao.Nr_lancto.ToString()
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + rLiquidacao.Cd_clifor.Trim() + "'"
                    }
                }, "a.cd_endereco");
            //Endereco clifor duplicata
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndClifor =
                TCN_CadEndereco.Buscar(rLiquidacao.Cd_clifor,
                                                                          obj != null ? obj.ToString() : string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          1,
                                                                          null);

            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Recibo.txt");
            w = f.CreateText();
            string Valor_Extenso = string.Empty;
            decimal valorLiquidado = 0;           
            

            valorLiquidado = rLiquidacao.Cvl_aliquidar_padrao > 0 ? (rLiquidacao.Cvl_aliquidar_padrao - rLiquidacao.cVl_descontoconcedido) :
                            (rLiquidacao.Vl_liquidado_padrao + rLiquidacao.Vl_JuroAcrescimo - rLiquidacao.Vl_DescontoBonus);

            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                    "where x.cd_moeda = a.cd_moeda "+
                                    "and x.cd_contager = '" + rLiquidacao.Cd_contager.Trim() + "')"
                    }
                }, 0, string.Empty);
            if (lMoeda.Count > 0)
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
            else
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, "Real", "Reais");
                        
            try
            {
                w.WriteLine("                " + lEmpresa[0].Nm_empresa);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("                                RECIBO                                          ");
                if (rLiquidacao.Tp_mov.Trim().Equals("P"))
                w.WriteLine("                                                    DATA PAGAMENTO: " + rLiquidacao.Dt_liquidacaostring);
                else
                    w.WriteLine("                                                  DATA RECEBIMENTO: " + rLiquidacao.Dt_liquidacaostring);
                w.WriteLine("                                                            VALOR : " + lMoeda[0].Sigla + rLiquidacao.Vl_Liquidado);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("--------------------------------------------------------------------------------");
                
                if (rLiquidacao.Tp_mov.Trim().Equals("P"))
                {
                    w.WriteLine("RECEBI DE: " + rClifor.Nm_empresa.Trim().ToUpper().FormatStringDireita(48, ' ')+
                                "- CNPJ: " + rClifor.Nr_cpf);
                    w.WriteLine("LOCALIZADA  NO ENDERECO: " + lEmpresa[0].rEndereco.Ds_endereco.Trim() + ", " + lEmpresa[0].rEndereco.Numero);
                    w.WriteLine("PORTADOR CPF/CNPJ: " + lEmpresa[0].rClifor.Nr_cgc.FormatStringDireita(32, ' ') + " INSC. ESTADUAL: " + lEmpresa[0].rEndereco.Insc_estadual);
                    w.WriteLine(); 
                    
                }
                else 
                {
                    w.WriteLine("RECEBI DE: " + rClifor.Nm_clifor.Trim().ToUpper().FormatStringDireita(48, ' ') + 
                                "- CNPJ: " + rClifor.Nr_cpf);
                    w.WriteLine("LOCALIZADA  NO ENDERECO: " + lEndClifor[0].Ds_endereco.Trim().ToUpper() + ", "+ lEndClifor[0].Numero);
                    w.WriteLine("PORTADOR CPF/CNPJ: " + (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? rClifor.Nr_cgc : rClifor.Nr_cpf).FormatStringDireita(32, ' ') + 
                                "INSC. ESTADUAL: " + lEndClifor[0].Insc_estadual);
                    w.WriteLine();                
                }
                w.WriteLine("--------------------------------------------------------------------------------");
                w.WriteLine("A IMPORTANCIA DE (" + Valor_Extenso + ")");
                w.WriteLine("--------------------------------------------------------------------------------");
                w.WriteLine("REFERENTE AO PAGAMENTO DA(S) DUPLICATA(S): ");
                w.WriteLine(referente);
                w.WriteLine("--------------------------------------------------------------------------------");
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("                -------------------------------------------------               ");
                w.WriteLine("                NOME: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? rClifor.Nm_clifor.ToUpper() : lEmpresa[0].Nm_empresa.ToUpper()));
                w.WriteLine("                CPF/CNPJ: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? rClifor.Nr_cgc : rClifor.Nr_cpf) : lEmpresa[0].rClifor.Nr_cgc));
                w.WriteLine();
                w.WriteLine("--------------------------------------------------------------------------------");

                w.Write("CIDADE: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.DS_Cidade.Trim().ToUpper().FormatStringDireita(20, ' ') : lEndClifor[0].DS_Cidade.Trim().ToUpper().FormatStringDireita(20, ' ')));
                w.Write("CEP: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.Cep : lEndClifor[0].Cep).FormatStringDireita(20, ' '));
                w.Write("FONE: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.Fone : lEndClifor[0].Fone).FormatStringDireita(15, ' '));
                w.WriteLine();
                w.WriteLine("--------------------------------------------------------------------------------");
                w.Write(Convert.ToChar(12));
                w.Flush();

                f.CopyTo("LPT1");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na impressao: " + ex.Message.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }

        }


        public static void Imprime_ReciboReduzido(string referente,
                                              TRegistro_LanLiquidacao rLiquidacao)
        {
            //Buscar porta impressão
            object porta = new TCD_CadTerminal().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Parametros.pubTerminal + "'"
                                                    }
                                                }, "porta_imptick");
            if (porta == null)
                throw new Exception("Não existe porta de impressão configurada para o terminal " + Parametros.pubTerminal.Trim());

            //Buscar Dados Empresa
            TList_CadEmpresa lEmpresa =
                TCN_CadEmpresa.Busca(rLiquidacao.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);

            //Dados clifor duplicata
            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                TCN_CadClifor.Busca_Clifor_Codigo(rLiquidacao.Cd_clifor, null);

            //Buscar Endereço Duplicata
            object obj = new TCD_LanDuplicata().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rLiquidacao.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_lancto",
                        vOperador = "=",
                        vVL_Busca = rLiquidacao.Nr_lancto.ToString()
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + rLiquidacao.Cd_clifor.Trim() + "'"
                    }
                }, "a.cd_endereco");
            //Endereco clifor duplicata
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndClifor =
                TCN_CadEndereco.Buscar(rLiquidacao.Cd_clifor,
                                                                          obj != null ? obj.ToString() : string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          1,
                                                                          null);


            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Recibo.txt");
            w = f.CreateText();
            string Valor_Extenso = string.Empty;
            decimal valorLiquidado = 0;


            valorLiquidado = rLiquidacao.Cvl_aliquidar_padrao > 0 ? (rLiquidacao.Cvl_aliquidar_padrao - rLiquidacao.Vl_DescontoBonus) :
                            (rLiquidacao.Vl_liquidado_padrao + rLiquidacao.Vl_JuroAcrescimo - rLiquidacao.Vl_DescontoBonus);

            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                    "where x.cd_moeda = a.cd_moeda "+
                                    "and x.cd_contager = '" + rLiquidacao.Cd_contager.Trim() + "')"
                    }
                }, 0, string.Empty);
            if (lMoeda.Count > 0)
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
            else
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, "Real", "Reais");

            try
            {
                w.WriteLine(" " + lEmpresa[0].Nm_empresa  );
                w.WriteLine("------------------------------------------");
                w.WriteLine("                RECIBO                    ");
                if (rLiquidacao.Tp_mov.Trim().Equals("P"))
                    w.WriteLine(" DATA PAGAMENTO: " + rLiquidacao.Dt_liquidacaostring);
                else
                    w.WriteLine(" DATA RECEBIMENTO: " + rLiquidacao.Dt_liquidacaostring);
                w.WriteLine(" VALOR : " + lMoeda[0].Sigla + valorLiquidado);
                w.WriteLine("------------------------------------------");

                if (rLiquidacao.Tp_mov.Trim().Equals("P"))
                {
                    w.WriteLine(" RECEBI DE: " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                    w.WriteLine(" LOCALIZADA  NO ENDERECO: " + lEmpresa[0].rEndereco.Ds_endereco.Trim() + ", " + lEmpresa[0].rEndereco.Numero);
                    w.WriteLine(" PORTADOR CPF/CNPJ: " + lEmpresa[0].rClifor.Nr_cgc.Trim());
                    w.WriteLine(" INSC. ESTADUAL: " + lEmpresa[0].rEndereco.Insc_estadual);
                    w.WriteLine();

                }
                else
                {
                    w.WriteLine(" RECEBI DE: " + rClifor.Nm_clifor.Trim().ToUpper());
                    w.WriteLine(" END: " + lEndClifor[0].Ds_endereco.Trim().ToUpper() + ", " + lEndClifor[0].Numero);
                    w.WriteLine(" PORTADOR CPF/CNPJ: " + (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? rClifor.Nr_cgc : rClifor.Nr_cpf).Trim());
                    w.WriteLine(" INSC. ESTADUAL: " + lEndClifor[0].Insc_estadual);
                    w.WriteLine();
                }
                w.WriteLine(" A IMPORTANCIA DE: " + lMoeda[0].Sigla + valorLiquidado);
                w.WriteLine("------------------------------------------");
                w.WriteLine(" REF. AO PAGAMENTO DA(S) DUPLICATA(S):"    );
                w.WriteLine(" " + referente);
                w.WriteLine("------------------------------------------");
                w.WriteLine();
                w.WriteLine("    ----------------------------------    ");
                w.WriteLine("                Assinatura                ");
                w.WriteLine("------------------------------------------");
                w.WriteLine(" " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.DS_Cidade.Trim().ToUpper() + "-" + lEmpresa[0].rEndereco.UF.Trim().ToUpper() : 
                    lEndClifor[0].DS_Cidade.Trim().ToUpper() + "-" + lEndClifor[0].UF.Trim().ToUpper()));
                w.WriteLine(" CEP: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.Cep : lEndClifor[0].Cep));
                w.WriteLine(" FONE: " + (rLiquidacao.Tp_mov.Trim().Equals("P") ? lEmpresa[0].rEndereco.Fone : lEndClifor[0].Fone));
                w.WriteLine("------------------------------------------");
                w.Write(Convert.ToChar(12)); 
                w.Flush();

                f.CopyTo(porta.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na impressao: " + ex.Message.Trim());
            }
            finally
            {
                w.Dispose();
                f = null;
            }

        }

        public static void Imprime_ReciboGraficoReduzido(bool Altera_relatorio,
                                          string referente,
                                          TRegistro_LanLiquidacao rLiquidacao,
                                          TList_RegLanDuplicata lDuplicata)
        {
            string Valor_Extenso = string.Empty;
            decimal valorLiquidado = 0;
            string Observacao = rLiquidacao.ComplHistorico;


            BindingSource BS_Duplicata = new BindingSource();
            BS_Duplicata.DataSource = lDuplicata;
            //Preencher dados clifor da duplicata
            BindingSource BinClifor = new BindingSource();
            if (BS_Duplicata.Current != null)
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
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
                                                        1,
                                                        null);
            BindingSource BinFIN = new BindingSource();

            //Preencher dados endereco clifor da duplicata
            BindingSource End = new BindingSource();
            End.DataSource = TCN_CadEndereco.Buscar((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    1,
                                                    null);
            //Preencher dados empresa da duplicata
            BindingSource Empresa = new BindingSource();
            Empresa.DataSource = TCN_CadEmpresa.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa, string.Empty, string.Empty, null);
            //Preencher dados clifor empresa
            BindingSource cliforEmpresa = new BindingSource();
            cliforEmpresa.DataSource = TCN_CadClifor.Busca_Clifor((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
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
                                                                    1,
                                                                    null);
            //Preencher dados endereco empresa da duplicata
            BindingSource endEmpresa = new BindingSource();
            endEmpresa.DataSource = TCN_CadEndereco.Buscar((Empresa.DataSource as TList_CadEmpresa)[0].Cd_clifor,
                                                            (Empresa.DataSource as TList_CadEmpresa)[0].Cd_endereco,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            1,
                                                            null);

            valorLiquidado = rLiquidacao.Cvl_aliquidar_padrao > 0 ? (rLiquidacao.Cvl_aliquidar_padrao - rLiquidacao.Vl_DescontoBonus) :
                            (rLiquidacao.Vl_liquidado_padrao + rLiquidacao.Vl_JuroAcrescimo - rLiquidacao.Vl_DescontoBonus);
            Relatorio rel = new Relatorio();
            rel.Altera_Relatorio = Altera_relatorio;
            //Buscar Moeda da Conta Gerencial
            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                    "where x.cd_moeda = a.cd_moeda "+
                                    "and x.cd_contager = '" + rLiquidacao.Cd_contager.Trim() + "')"
                    }
                }, 0, string.Empty);
            if (lMoeda.Count > 0)
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
            else
                Valor_Extenso = new Extenso().ValorExtenso(valorLiquidado, "Real", "Reais");

            //Buscar valor devolucao adiantamento
            object obj = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca() 
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FIN_Liquidacao_X_Adto_Caixa x "+
			                                    "where x.CD_ContaGer = a.CD_ContaGer " +
			                                    "and x.CD_LanctoCaixa = a.CD_LanctoCaixa " +
			                                    "and x.CD_Empresa = '" + rLiquidacao.Cd_empresa + "'" +
			                                    "and x.Nr_Lancto = " + rLiquidacao.Nr_lancto + 
			                                    "and x.CD_Parcela = " + rLiquidacao.Cd_parcela +
			                                    "and x.ID_Liquid = " + rLiquidacao.Id_liquid + ")" 
                                }
                            }, lDuplicata[0].Tp_mov.ToUpper().Equals("R") ?
                              "isnull(sum(a.vl_pagar), 0)" :
                              "isnull(sum(a.vl_receber), 0)");

            rel.Nome_Relatorio = "TFLanContas_ReciboGraficoReduzido";
            rel.NM_Classe = "TFLanContas_ReciboGraficoReduzido";
            rel.Modulo = "FIN";
            rel.Parametros_Relatorio.Add("VL_DESCONTO", rLiquidacao.Vl_DescontoBonus);
            rel.Parametros_Relatorio.Add("VL_JUROACRESCIMO", rLiquidacao.Vl_JuroAcrescimo);
            rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso.Trim());
            rel.Parametros_Relatorio.Add("VALORLIQUIDADO", valorLiquidado);
            rel.Parametros_Relatorio.Add("OBSERVACAO", Observacao);
            rel.Parametros_Relatorio.Add("REFERENTE", referente);
            rel.Parametros_Relatorio.Add("DT_LIQUIDACAO", rLiquidacao.Dt_Liquidacao.Value);
            rel.Parametros_Relatorio.Add("VL_DEVADTO", obj != null ? Convert.ToDecimal(obj.ToString()) : decimal.Zero);
            if (Empresa.Count > 0)
                if ((Empresa.List[0] as TRegistro_CadEmpresa).Img != null)
                    rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as TRegistro_CadEmpresa).Img);
            rel.Adiciona_DataSource("CLIFOR", BinClifor);
            rel.Adiciona_DataSource("ENDERECO", End);
            rel.Adiciona_DataSource("EMPRESA", Empresa);
            rel.Adiciona_DataSource("CLIFOREMPRESA", cliforEmpresa);
            rel.Adiciona_DataSource("ENDEMPRESA", endEmpresa);
            rel.DTS_Relatorio = BS_Duplicata;
            if (!Altera_relatorio)
            {
                //Chamar tela de impressao relatorio
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RECIBO QUITAÇÃO DUPLICATA " + rLiquidacao.Nr_lancto.ToString() +
                                     "/" + rLiquidacao.Cd_parcela.ToString();
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        rel.Gera_Relatorio("RECIBO QUITAÇÃO",
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RECIBO QUITAÇÃO DUPLICATA " + rLiquidacao.Nr_lancto.ToString() +
                                                 "/" + rLiquidacao.Cd_parcela.ToString(),
                                                 fImp.pDs_mensagem);
                }
            }
            else
                rel.Gera_Relatorio();
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
using Utils;

namespace Faturamento
{
    public partial class TFConsultaPreVenda : Form
    {
        private bool Altera_Relatorio = false;
        public TRegistro_PreVenda rVenda
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg
        { get; set; }

        public TFConsultaPreVenda()
        {
            InitializeComponent();
            rVenda = null;
        }

        private void TFConsultaPreVenda_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dgPreVenda);
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void LimpaFiltros()
        {
            Id_prevenda.Clear();
            cd_empresa.Clear();
            nm_clifor.Clear();
            cd_vendedor.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            cbAberto.Checked = false;
            cbCancelado.Checked = false;
        }

        private void afterAltera()
        {
            if (BsPreVenda.Current != null)
            {
                if ((BsPreVenda.Current as TRegistro_PreVenda).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar venda CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se pre venda esta faturada
                if((BsPreVenda.Current as TRegistro_PreVenda).St_faturada)
                {
                    MessageBox.Show("Não é permitido alterar venda FATURADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                rVenda = BsPreVenda.Current as TRegistro_PreVenda;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Obrigatorio selecionar venda para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbCancelado.Checked)
                status += virg + "'C'";
            BsPreVenda.DataSource = TCN_PreVenda.Buscar(cd_empresa.Text,
                                                        Id_prevenda.Text,
                                                        string.Empty,
                                                        nm_clifor.Text,
                                                        cd_vendedor.Text,
                                                        dt_ini.Text,
                                                        dt_fin.Text,
                                                        status,
                                                        cbSaldoFaturar.Checked,
                                                        "a.id_prevenda desc",
                                                        null);
            BsPreVenda_PositionChanged(this, new EventArgs());
        }

        private void print()
        {
            if (BsPreVenda.Current != null)
            {
                if (!(BsPreVenda.Current as TRegistro_PreVenda).St_registro.Trim().ToUpper().Equals("C"))
                {
                    CamadaDados.Diversos.TList_CadTerminal lTerminal =
                     new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                }
                                            }, 1, string.Empty);
                    if (lTerminal.Count.Equals(0) ? false : lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                    {
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lTerminal[0].Cd_Terminal.Trim() + "'"
                                            }
                                        }, "a.tp_impnaofiscal");
                        if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                            throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                        //Imprimir
                        ImprimirReduzido(BsPreVenda.Current as TRegistro_PreVenda, lTerminal[0].Porta_imptick, obj == null ? string.Empty : obj.ToString());
                    }
                    else if (lTerminal.Count.Equals(0) ? false : lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLanPreVendaGraficoReduzido";
                        Relatorio.NM_Classe = "TFLanPreVendaGraficoReduzido";
                        Relatorio.Modulo = string.Empty;


                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     (BsPreVenda.Current as TRegistro_PreVenda).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((BsPreVenda.Current as TRegistro_PreVenda).Cd_clifor,
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


                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = new TList_PreVenda() { BsPreVenda.Current as TRegistro_PreVenda };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = "FLanPreVendaGraficoReduzido";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        //Verificar se existe Impressora padrão para o PDV
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                            new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
                        string print = string.Empty;
                        print = obj == null ? string.Empty : obj.ToString();
                        if (string.IsNullOrEmpty(print))
                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                            {
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                        print = fLista.Impressora;

                            }
                        //Imprimir
                        if(!string.IsNullOrEmpty(print))
                            Relatorio.ImprimiGraficoReduzida(print,
                                                             true,
                                                             false,
                                                             null,
                                                             string.Empty,
                                                             string.Empty,
							                                 1);
                        Altera_Relatorio = false;
                    }
                    else
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLanPreVenda";
                        Relatorio.NM_Classe = "TFLanPreVenda";
                        Relatorio.Modulo = string.Empty;

                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     (BsPreVenda.Current as TRegistro_PreVenda).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((BsPreVenda.Current as TRegistro_PreVenda).Cd_clifor,
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


                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = new TList_PreVenda() { BsPreVenda.Current as TRegistro_PreVenda };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = "FLanPreVenda";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (BsPreVenda.Current as TRegistro_PreVenda).Cd_clifor;
                                fImp.pMensagem = "ORÇAMENTO Nº " + (BsPreVenda.Current as TRegistro_PreVenda).Id_prevendastr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((BsPreVenda.Current as TRegistro_PreVenda).Id_prevendastr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "ORÇAMENTO Nº " + (BsPreVenda.Current as TRegistro_PreVenda).Id_prevendastr,
                                                             fImp.pDs_mensagem);
                            }
                        }
                        else
                        {
                            Relatorio.Gera_Relatorio();
                            Altera_Relatorio = false;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Obrigatório buscar Pré-Venda para imprimir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ImprimirReduzido(TRegistro_PreVenda val, string porta, string Tp_impressora)
        {
            //Buscar dados da empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
            if (lEmpresa.Count < 1)
                throw new Exception("Não foi possivel localizar empresa " + val.Cd_empresa);
            if (!string.IsNullOrEmpty(Tp_impressora))
            {
                PDV.TGerenciarImpNaoFiscal.IniciarPorta(porta);
                try
                {
                    StringBuilder imp = new StringBuilder();
                    imp.AppendLine("  PRÉ-VENDA  N: " + val.Id_prevendastr + "  " + val.Dt_emissaostr);
                    imp.AppendLine(" =========================================");
                    imp.AppendLine("               DADOS EMPRESA              ");
                    imp.AppendLine(" =========================================");
                    imp.AppendLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                    imp.AppendLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                    imp.AppendLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("               DADOS CLIENTE              ");
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("  " + val.Cd_clifor.Trim() + "-" + val.Nm_clifor.Trim().ToUpper());
                    //Buscar clifor config
                    object obj_clifor = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.cd_clifor");
                    if ((obj_clifor == null ? false : obj_clifor.ToString() != val.Cd_clifor) && (!string.IsNullOrEmpty(val.Cd_clifor)))
                    {
                        //Buscar dados cliente
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, null);
                        if (!string.IsNullOrEmpty(rCliente.Nm_fantasia))
                            imp.Append("  " + rCliente.Nm_fantasia.Trim().ToUpper());
                        if (rCfg.St_impcpfcnpjbool)
                        {
                            if ((!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero())) ||
                                (!string.IsNullOrEmpty(rCliente.Nr_cpf.SoNumero())))
                                imp.AppendLine("  CNPJ/CPF: " + (!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero()) ? rCliente.Nr_cgc : rCliente.Nr_cpf));
                        }
                    }
                    imp.Append("  " + val.Ds_endereco.Trim().ToUpper());
                    if ((obj_clifor == null ? false : obj_clifor.ToString() != val.Cd_clifor) && (!string.IsNullOrEmpty(val.Cd_clifor)))
                    {
                        //Buscar Endereco do cliente
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                            }
                        }, 0, string.Empty);
                        if (lEndereco.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(lEndereco[0].Numero))
                                imp.AppendLine(", " + lEndereco[0].Numero.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].Bairro))
                                imp.AppendLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].DS_Cidade))
                                imp.AppendLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                            if (!string.IsNullOrEmpty(lEndereco[0].Fone.SoNumero()))
                            {
                                imp.AppendLine("  " + lEndereco[0].Fone.Trim().ToUpper() +
                                    (!string.IsNullOrEmpty(lEndereco[0].Celular.SoNumero()) ? "/" + lEndereco[0].Celular.Trim().ToUpper() : string.Empty));
                            }
                            if (!string.IsNullOrEmpty(lEndereco[0].Cep.SoNumero()))
                                imp.AppendLine("  CEP: " + lEndereco[0].Cep);
                            if (!string.IsNullOrEmpty(lEndereco[0].Proximo))
                                imp.AppendLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                        }
                    }
                    else
                    {
                        imp.AppendLine();
                        imp.AppendLine();
                    }
                    if (!string.IsNullOrEmpty(val.Nm_vendedor))
                        imp.AppendLine(("  VENDEDOR: " + val.Nm_vendedor.Trim()).FormatStringDireita(42, ' '));
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("  PRODUTO  QTD      VAL.UNIT  SUBTOTAL");
                    imp.AppendLine(" -----------------------------------------");

                    val.lItens.ForEach(p =>
                    {
                        imp.AppendLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                        imp.Append(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(13, ' ') + "x");
                        imp.Append(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' '));
                        imp.Append(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                        imp.AppendLine();
                        if (p.Vl_desconto > decimal.Zero)
                            imp.AppendLine(" DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_acrescimo > decimal.Zero)
                            imp.AppendLine(" ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_juro_fin > decimal.Zero)
                            imp.AppendLine(" JURO FIN.: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    });

                    imp.Append(" -----------------------------------------------");
                    imp.Append("  ACRESCIMOS JUROS FIN.  FRETE DESCONTO  LIQUIDO");
                    imp.Append(val.lItens.Sum(p => p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_juro_fin).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_frete).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(7, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    imp.AppendLine(val.lItens.Sum(p => p.Vl_liquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    imp.AppendLine(" -------------------------------------------");
                    if (!string.IsNullOrEmpty(val.Cd_portador))
                        imp.AppendLine("  FORMA PGTO : " + val.Cd_portador.Trim() + "-" + val.Ds_portador.Trim());
                    //Buscar Parcelas
                    TList_PreVenda_DT_Vencto lParc =
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda_DT_Vencto.Buscar(val.Id_prevendastr,
                                                                                    val.Cd_empresa,
                                                                                    null);
                    if (lParc.Count > 0)
                    {
                        imp.AppendLine("  COND.PGTO  : " + val.Cd_condPgto.Trim() + "-" + val.Ds_condPgto.Trim());
                        imp.AppendLine("  VENCIMENTO          VALOR ");
                        lParc.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                            imp.AppendLine("  " + p.Dt_vencto.ToString("dd/MM/yyyy").FormatStringDireita(20, ' ') + p.Vl_parcela.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))));
                        imp.AppendLine();
                        imp.AppendLine();
                    }
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("                Cliente               ");
                    imp.AppendLine();
                    imp.AppendLine();
                    //Imprimir observacao cupom
                    if (!string.IsNullOrEmpty(val.Ds_observacao))
                    {
                        string obs = val.Ds_observacao.Trim();
                        imp.AppendLine(" -----------------------------------------");
                        imp.AppendLine("              OBSERVAÇÕES                 ");
                        imp.AppendLine(" -----------------------------------------");
                        while (true)
                        {
                            if (obs.Length <= 40)
                            {
                                imp.AppendLine("  " + obs);
                                break;
                            }
                            else
                            {
                                imp.AppendLine("  " + obs.Substring(0, 40));
                                obs = obs.Remove(0, 40);
                            }
                        }
                    }
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("      Este recibo nao tem valor Fiscal    ");
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();

                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                finally
                { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
            }
            else
            {
                System.IO.FileInfo f = null;
                System.IO.StreamWriter w = null;
                f = new System.IO.FileInfo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + "Orcamento.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine("  PRÉ-VENDA  N: " + val.Id_prevendastr + "  " + val.Dt_emissaostr);
                    w.WriteLine(" =========================================");
                    w.WriteLine("               DADOS EMPRESA              ");
                    w.WriteLine(" =========================================");
                    w.WriteLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                    w.WriteLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                    w.WriteLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("               DADOS CLIENTE              ");
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  " + val.Cd_clifor.Trim() + "-" + val.Nm_clifor.Trim().ToUpper());
                    object obj_clifor = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.cd_clifor");
                    if ((obj_clifor == null ? false : obj_clifor.ToString() != val.Cd_clifor) && (!string.IsNullOrEmpty(val.Cd_clifor)))
                    {
                        //Buscar dados cliente
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, null);
                        if (!string.IsNullOrEmpty(rCliente.Nm_fantasia))
                            w.WriteLine("  " + rCliente.Nm_fantasia.Trim().ToUpper());
                        if (rCfg.St_impcpfcnpjbool)
                        {
                            if ((!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero())) ||
                                (!string.IsNullOrEmpty(rCliente.Nr_cpf.SoNumero())))
                                w.WriteLine("  CNPJ/CPF: " + (!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero()) ? rCliente.Nr_cgc : rCliente.Nr_cpf));
                        }
                    }
                    w.Write("  " + val.Ds_endereco.Trim().ToUpper());
                    if ((obj_clifor == null ? false : obj_clifor.ToString() != val.Cd_clifor) && (!string.IsNullOrEmpty(val.Cd_clifor)))
                    {
                        //Buscar Endereco do cliente
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                            }
                        }, 0, string.Empty);
                        if (lEndereco.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(lEndereco[0].Numero))
                                w.WriteLine(", " + lEndereco[0].Numero.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].Bairro))
                                w.WriteLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].DS_Cidade))
                                w.WriteLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                            if (!string.IsNullOrEmpty(lEndereco[0].Fone.SoNumero()))
                            {
                                w.WriteLine("  " + lEndereco[0].Fone.Trim().ToUpper() +
                                    (!string.IsNullOrEmpty(lEndereco[0].Celular.SoNumero()) ? "/" + lEndereco[0].Celular.Trim().ToUpper() : string.Empty));
                            }
                            if (!string.IsNullOrEmpty(lEndereco[0].Cep.SoNumero()))
                                w.WriteLine("  CEP: " + lEndereco[0].Cep);
                            if (!string.IsNullOrEmpty(lEndereco[0].Proximo))
                                w.WriteLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                        }
                    }
                    else
                    {
                        w.WriteLine();
                        w.WriteLine();
                    }
                    if (!string.IsNullOrEmpty(val.Nm_vendedor))
                        w.WriteLine(("  VENDEDOR: " + val.Nm_vendedor.Trim()).FormatStringDireita(42, ' '));
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  PRODUTO  QTD      VAL.UNIT  SUBTOTAL");
                    w.WriteLine(" -----------------------------------------");

                    val.lItens.ForEach(p =>
                    {
                        w.WriteLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                        w.Write(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(13, ' ') + "x");
                        w.Write(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' '));
                        w.Write(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                        w.WriteLine();
                        if (p.Vl_desconto > decimal.Zero)
                            w.WriteLine(" DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_acrescimo > decimal.Zero)
                            w.WriteLine(" ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_juro_fin > decimal.Zero)
                            w.WriteLine(" JURO FIN.: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    });

                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  ACRESCIMOS JUROS FIN. DESCONTO  LIQUIDO ");
                    w.Write(val.lItens.Sum(p => p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.Write(val.lItens.Sum(p => p.Vl_juro_fin).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    w.Write(val.lItens.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    w.WriteLine(val.lItens.Sum(p => p.Vl_liquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    w.WriteLine(" -----------------------------------------");
                    if (!string.IsNullOrEmpty(val.Cd_portador))
                        w.WriteLine("  FORMA PGTO : " + val.Cd_portador.Trim() + "-" + val.Ds_portador.Trim());
                    //Buscar Parcelas
                    TList_PreVenda_DT_Vencto lParc =
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda_DT_Vencto.Buscar(val.Id_prevendastr,
                                                                                    val.Cd_empresa,
                                                                                    null);
                    if (lParc.Count > 0)
                    {
                        w.WriteLine("  COND.PGTO  : " + val.Cd_condPgto.Trim() + "-" + val.Ds_condPgto.Trim());
                        w.WriteLine("  VENCIMENTO          VALOR ");
                        lParc.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                            w.WriteLine("  " + p.Dt_vencto.ToString("dd/MM/yyyy").FormatStringDireita(20, ' ') + p.Vl_parcela.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))));
                        w.WriteLine();
                        w.WriteLine();
                    }
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("                Cliente               ");
                    w.WriteLine();
                    w.WriteLine();
                    //Imprimir observacao cupom
                    if (!string.IsNullOrEmpty(val.Ds_observacao))
                    {
                        string obs = val.Ds_observacao.Trim();
                        w.WriteLine("Observacoes".FormatStringDireita(42, '-'));
                        while (true)
                        {
                            if (obs.Length <= 40)
                            {
                                w.WriteLine("  " + obs);
                                break;
                            }
                            else
                            {
                                w.WriteLine("  " + obs.Substring(0, 40));
                                obs = obs.Remove(0, 40);
                            }
                        }
                    }
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("      Este recibo nao tem valor Fiscal    ");

                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();

                    decimal copias = CamadaNegocio.ConfigGer.TCN_CadParamGer.VlNumericoEmpresa("QTD_VIA_REC_ECF", val.Cd_empresa, null);
                    if (copias.Equals(decimal.Zero))
                        copias = 1;
                    for (int i = 0; i < copias; i++)
                        f.CopyTo(porta);
                }

                catch (Exception ex)
                { throw new Exception("Erro na impressao: " + ex.Message.Trim()); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
        }

        private void BsPreVenda_PositionChanged(object sender, EventArgs e)
        {
            if (BsPreVenda.Current != null)
            {
                (BsPreVenda.Current as TRegistro_PreVenda).lItens =
                    TCN_ItensPreVenda.Buscar((BsPreVenda.Current as TRegistro_PreVenda).Cd_empresa,
                                            (BsPreVenda.Current as TRegistro_PreVenda).Id_prevendastr,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       false,
                                                                                       null);
                (BsPreVenda.Current as TRegistro_PreVenda).DT_Vencto =
                    TCN_PreVenda_DT_Vencto.Buscar((BsPreVenda.Current as TRegistro_PreVenda).Id_prevendastr,
                                                  (BsPreVenda.Current as TRegistro_PreVenda).Cd_empresa,
                                                  null);
                
                BsPreVenda.ResetCurrentItem();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                           "isnull(a.st_vendedor, 'N')|=|'S';" +
                           "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor},
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_limpar_Click(object sender, EventArgs e)
        {
            LimpaFiltros();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            print();
        }

        private void TFConsultaPreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F2))
                LimpaFiltros();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F8))
                print();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void dgPreVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                        dgPreVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("FATURADA"))
                        dgPreVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        dgPreVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void TFConsultaPreVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dgPreVenda);
            ShapeGrid.SaveShape(this, gItens);
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }
    }
}

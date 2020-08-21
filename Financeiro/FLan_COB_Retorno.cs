using System;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.VendasExterna;
using CamadaDados.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaNegocio.Financeiro.Bloqueto;
using Utils;

namespace Financeiro
{
    public partial class TFLan_COB_Retorno : Form
    {
        private Token _token;
        private bool Altera_Relatorio = false;

        public TFLan_COB_Retorno()
        {
            InitializeComponent();
        }

        private bool ValidarToken(string Login,
                                  string Senha,
                                  string Licenca,
                                  string Integracao)
        {
            if (string.IsNullOrWhiteSpace(Login) ||
                string.IsNullOrWhiteSpace(Senha) ||
                string.IsNullOrWhiteSpace(Licenca) ||
                string.IsNullOrWhiteSpace(Integracao))
                return false;
            if (_token == null ? true : !_token.St_valido)
            {
                _token = ServiceRest.DataService.GerarToken(Login,
                                                            Senha,
                                                            Licenca,
                                                            Integracao);
                return _token != null;
            }
            else return true;
        }

        private void MontarListaArqRet()
        {
            lArquivos.Items.Clear();
            if (System.IO.Directory.Exists(path_retorno.Text))
            {
                //Buscar lista de arquivos no path
                string[] arquivos = System.IO.Directory.GetFiles(path_retorno.Text);
                for (int i = 0; i < arquivos.Length; i++)
                    lArquivos.Items.Add(arquivos[i].Trim().Substring(arquivos[i].Trim().LastIndexOf("\\") + 1, arquivos[i].Trim().Length - arquivos[i].Trim().LastIndexOf("\\") - 1));
            }
        }

        private void afterPrint()
        {
            if (bsBloqueto.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    System.Text.StringBuilder str = new System.Text.StringBuilder();
                    (bsBloqueto.DataSource as blListaTitulo).ForEach(p =>
                    {
                        blListaTitulo lista =
                        new TCD_Titulo().Select(
                          new TpBusca[]
                          {
                              new TpBusca()
                              {
                                  vNM_Campo = "a.cd_empresa",
                                  vOperador = "=",
                                  vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                              },
                              new TpBusca()
                              {
                                  vNM_Campo = "a.NossoNumero",
                                  vOperador = "=",
                                  vVL_Busca = "'" + p.Nosso_numero.Trim() + "'"
                              }
                          }, 0, string.Empty);
                        if (lista.Count > 0)
                        {
                            p.NumeroDocumento = lista[0].NumeroDocumento;
                            p.Cd_sacado = lista[0].Cd_sacado;
                            p.Sacado = lista[0].Sacado;
                            p.Vl_documento = lista[0].Vl_documento;
                            p.Carteira = lista[0].Carteira;
                            p.Cedente = lista[0].Cedente;
                            p.Nome_banco = lista[0].Nome_banco;
                            p.Ds_contager = lista[0].Ds_contager;
                            p.Vl_nominal = lista[0].Vl_nominal;
                        }
                    });
                    bsBloqueto.ResetBindings(true);
                    Rel.DTS_Relatorio = bsBloqueto;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "FIN";
                    Rel.Ident = Name;
                    string arquivo = string.Empty;
                    for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                        arquivo += (!string.IsNullOrEmpty(arquivo) ? ";" : string.Empty) + lArquivos.CheckedItems[i].ToString().Trim();
                    Rel.Parametros_Relatorio.Add("ARQUIVOS", arquivo);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO DE RETORNO DE COBRANÇA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO DE RETORNO DE COBRANÇA",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO DE RETORNO DE COBRANÇA",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void TFLan_COB_Retorno_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, blListaTituloDataGridDefault);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbCfgBoleto.DataSource = new TCD_CadCFGBanco().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                            "where x.cd_contager = a.cd_contager " +
                                                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
            cbCfgBoleto.DisplayMember = "ds_config";
            cbCfgBoleto.ValueMember = "id_config";
            path_retorno.Text = SettingsUtils.Default.PATH_RETORNO;
            MontarListaArqRet();

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Retorno_Click(object sender, EventArgs e)
        {
            if (lArquivos.CheckedItems != null)
            {
                if (cbCfgBoleto.SelectedItem == null)
                {
                    MessageBox.Show("Obrigatorio informar configuração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCfgBoleto.Focus();
                    return;
                }
                string[] files = new string[lArquivos.CheckedItems.Count];
                for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                    files[i] = lArquivos.CheckedItems[i].ToString().Trim();
                if (files.Length > 0)
                {
                    try
                    {
                        blListaTitulo lTitulos =
                            TCN_Titulo.LerRetorno((cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Empresa.Cd_empresa,
                                                  (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Banco.Cd_banco,
                                                  path_retorno.Text,
                                                  (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Cd_bancocorrespondente,
                                                  files);

                        if (lTitulos == null ? true : lTitulos.Count.Equals(0))
                        {
                            MessageBox.Show("Lote retorno não possui titulos para serem processados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Mover arquivos processados para pasta backup
                            if (!System.IO.Directory.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                                System.IO.Directory.CreateDirectory(path_retorno.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                            for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                            {
                                if (!System.IO.File.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim()))
                                    System.IO.File.Move(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim(),
                                                        path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                                else System.IO.File.Delete(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                            }
                            bsBloqueto.Clear();
                            MontarListaArqRet();
                        }
                        else
                        {
                            //Buscar Cd.Sacado e Nm.Sacado dos titulos
                            lTitulos.ForEach(x =>
                            {
                                blListaTitulo lTitulo = new TCD_Titulo().Select(
                                    new TpBusca[] {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Empresa.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_config",
                                            vOperador = "=",
                                            vVL_Busca = (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Id_configstr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.NossoNumero",
                                            vOperador = "=",
                                            vVL_Busca = "'" +  x.Nosso_numero.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                                if (lTitulo.Count > 0)
                                {
                                    x.Cd_sacado = lTitulo[0].Cd_sacado;
                                    x.Sacado.Nome = lTitulo[0].Nm_sacado;
                                }
                            });
                            bsBloqueto.DataSource = lTitulos;
                            tot_documento.Text = (bsBloqueto.List as blListaTitulo).Sum(p => p.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            bsBloqueto_PositionChanged(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Mover arquivos processados para pasta backup
                        if (!System.IO.Directory.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                            System.IO.Directory.CreateDirectory(path_retorno.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                        for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                        {
                            if (!System.IO.File.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim()))
                                System.IO.File.Move(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim(),
                                                    path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                            else System.IO.File.Delete(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                        }
                        bsBloqueto.Clear();
                        MontarListaArqRet();
                    }
                }
            }
        }

        private void BB_Conciliar_Click(object sender, EventArgs e)
        {
            if (bsBloqueto.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    string msg = string.Empty;
                    if (TCN_Titulo.ConciliarRetorno(bsBloqueto.List as blListaTitulo, cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco, null, ref msg).Trim() != string.Empty)
                    {
                        MessageBox.Show("Conciliação de bloquetos realizada com sucesso." + (msg.Trim() != string.Empty ? "\r\n\r\nBloqueto que não foram compensados:\r\n" + msg.Trim() : string.Empty), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Gravar tarifa de cobranca
                        if (((bsBloqueto.List as blListaTitulo).Sum(p => p.Vl_despesa_cobranca) > decimal.Zero ||
                            (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Vl_taxa > decimal.Zero) &&
                            (!string.IsNullOrEmpty((cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Cd_historico_taxacob)))
                            try
                            {
                                TCN_Titulo.GravarTarifas(bsBloqueto.List as blListaTitulo,
                                                         cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco,
                                                         null);
                                MessageBox.Show("Tarifa(s) gravada(s) com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro gravar tarifa: " + ex.Message);
                            }
                        //Verificar se empresa integra Vendas Externa
                        TList_CFGVendasExterna lCfg = TCN_CFGVendasExterna.Buscar((cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Empresa.Cd_empresa, null);
                        if (lCfg.Count > 0)
                            if (ValidarToken(lCfg[0].Login,
                                            lCfg[0].Senha,
                                            lCfg[0].Licenca,
                                            lCfg[0].Integracao))
                            {
                                string mensagem = string.Empty;
                                (bsBloqueto.List as blListaTitulo)
                                    .Where(x => x.Vl_recebido > decimal.Zero)
                                    .ToList()
                                    .ForEach(x =>
                                    {
                                        try
                                        {
                                            if (ServiceRest.DataService.BaixarBoletos(
                                              new BaixarBoleto
                                              {
                                                  CODIGO = x.Cd_integracao,
                                                  DATA_PAGAMENTO = x.Dt_credito.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                  VALOR_PAGO = x.Vl_recebido.ToString("N2", new System.Globalization.CultureInfo("en-US", true))
                                              }, _token))
                                            {
                                                x.St_baixadointegracao = "S";
                                                TCN_Titulo.Gravar(x, null);
                                            }
                                            else
                                                mensagem += "Boleto Nº" + x.Nosso_numero + " não foi integrada\r\n";
                                        }
                                        catch { mensagem += "Boleto Nº" + x.Nosso_numero + " não foi integrada\r\n"; }
                                    });
                                if (string.IsNullOrWhiteSpace(mensagem))
                                    MessageBox.Show("Relação de boletos não integrados com Vendas Externas.\r\n" + mensagem,
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        //Mover arquivos processados para pasta backup
                        if (!System.IO.Directory.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                            System.IO.Directory.CreateDirectory(path_retorno.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                        for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                        {
                            if (!System.IO.File.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim()))
                                System.IO.File.Move(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim(),
                                                    path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                            else System.IO.File.Delete(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                        }

                        bsBloqueto.Clear();
                        MontarListaArqRet();
                    }
                    else
                    {
                        MessageBox.Show("Não existe bloqueto em aberto para compensar neste arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Mover arquivos processados para pasta backup
                        if (!System.IO.Directory.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                            System.IO.Directory.CreateDirectory(path_retorno.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                        for (int i = 0; i < lArquivos.CheckedItems.Count; i++)
                        {
                            if (!System.IO.File.Exists(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim()))
                                System.IO.File.Move(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim(),
                                                    path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                            else System.IO.File.Delete(path_retorno.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" + System.IO.Path.DirectorySeparatorChar.ToString() + lArquivos.CheckedItems[i].ToString().Trim());
                        }

                        bsBloqueto.Clear();
                        MontarListaArqRet();
                    }

                    //Cobrança
                    //gerarCobrancaPorEmail();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                { Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Não existe titulos para ser conciliado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gerarCobrancaPorEmail()
        {
            if (bsBloqueto.Count.Equals(0))
                return;
            else if (!existeBloquetoVencido())
                return;
            else if (MessageBox.Show("Existem bloquetos vencidos para ontem pela configuração selecionada, deseja enviar cobrança por e-mail?",
                "Pergunta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            using (TFCobrancaEmail fCobrancaEmail = new TFCobrancaEmail())
            {
                fCobrancaEmail.rCfgBoleto = (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco);
                fCobrancaEmail.ShowDialog();
            }
        }

        private bool existeBloquetoVencido()
        {
            //Validar existencia de bloquetos vencidos no dia anterior
            bool retur = false;
            TpBusca[] tpBuscas = new TpBusca[0];
            Estruturas.CriarParametro(ref tpBuscas, "a.id_config", "'" + (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Id_configstr + "'");
            Estruturas.CriarParametro(ref tpBuscas, "b.st_registro", "('A', 'P')", "in");
            Estruturas.CriarParametro(ref tpBuscas, "cast(b.dt_vencto as date)", "cast(dateadd(day, -1, GETDATE())as date)");

            if (new TCD_Titulo().Select(tpBuscas, 0, "1") != null)
                return true;

            return retur;
        }

        private void TFLan_COB_Retorno_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, blListaTituloDataGridDefault);
        }

        private void TFLan_COB_Retorno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F10))
                BB_Retorno_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F4))
                BB_Conciliar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Localizar Arquivo Remessa";
                fbd.ShowNewFolderButton = true;
                if (!string.IsNullOrEmpty(SettingsUtils.Default.PATH_RETORNO))
                    fbd.SelectedPath = SettingsUtils.Default.PATH_RETORNO;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path_retorno.Text = fbd.SelectedPath;
                    MontarListaArqRet();
                    SettingsUtils.Default.PATH_RETORNO = fbd.SelectedPath;
                    SettingsUtils.Default.Save();
                }
            }
        }

        private void path_retorno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(path_retorno.Text))
                if (System.IO.Directory.Exists(path_retorno.Text))
                {
                    MontarListaArqRet();
                    SettingsUtils.Default.PATH_RETORNO = path_retorno.Text;
                    SettingsUtils.Default.Save();
                }
                else
                {
                    MessageBox.Show("Path Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    path_retorno.Clear();
                }
        }

        private void bb_arquivos_Click(object sender, EventArgs e)
        {
            MontarListaArqRet();
        }

        private void bsBloqueto_PositionChanged(object sender, EventArgs e)
        {
            if (bsBloqueto.Current != null)
            {
                dsDetalhe.DataSource =
                    new TCD_Titulo().Select(
                          new TpBusca[]
                          {
                              new TpBusca()
                              {
                                  vNM_Campo = "a.cd_empresa",
                                  vOperador = "=",
                                  vVL_Busca = "'" + (bsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "'"
                              },
                              new TpBusca()
                              {
                                  vNM_Campo = "a.id_config",
                                  vOperador = "=",
                                  vVL_Busca = (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco).Id_configstr
                              },
                              new TpBusca()
                              {
                                  vNM_Campo = "a.NossoNumero",
                                  vOperador = "=",
                                  vVL_Busca = "'" + (bsBloqueto.Current as blTitulo).Nosso_numero.Trim() + "'"
                              }
                          }, 0, string.Empty);
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!existeBloquetoVencido())
                return;
            else if (MessageBox.Show("Existem bloquetos vencidos para ontem pela configuração selecionada, deseja enviar cobrança por e-mail?",
                "Pergunta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            using (TFCobrancaEmail fCobrancaEmail = new TFCobrancaEmail())
            {
                fCobrancaEmail.rCfgBoleto = (cbCfgBoleto.SelectedItem as TRegistro_CadCFGBanco);
                fCobrancaEmail.ShowDialog();
            }
        }
    }
}

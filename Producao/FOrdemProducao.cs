using CamadaDados.Producao.Producao;
using CamadaNegocio.Estoque;
using CamadaNegocio.Estoque.Cadastros;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFOrdemProducao : Form
    {
        private decimal qtd_formula { get; set; } = 1;
        private TRegistro_OrdemProducao rordem;
        public TRegistro_OrdemProducao rOrdem
        {
            get
            {
                if (bsOrdemProducao.Current != null)
                    return bsOrdemProducao.Current as TRegistro_OrdemProducao;
                else
                    return null;
            }
            set { rordem = value; }
        }

        public string pCd_empresa { get; set; }
        public string pNm_empresa { get; set; }
        public string pCd_produto { get; set; }
        public string pDs_produto { get; set; }
        public decimal pQtd_batch { get; set; }

        public TFOrdemProducao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                gFicha.EndEdit();
                if (dt_prevfinprod.Focused)
                    dt_prevfinprod_Leave(this, new EventArgs());
                DialogResult = DialogResult.OK;
            }
        }

        private void PreencherFicha()
        {
            //Buscar Ficha do Cadastro de Produto
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                TCN_FichaTecProduto.Buscar(cd_produto.Text,
                                           string.Empty,
                                           null);
            if (lFicha.Count > 0)
            {
                if (lFicha.Exists(p => string.IsNullOrEmpty(p.Cd_local)))
                {
                    string vColunas = "a.ds_local|Local Armazenagem|150;" +
                                 "a.cd_local|Código|50";
                    string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                    "           where x.cd_local = a.cd_local and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
                    try
                    {
                        if (linha != null)
                        {
                            lFicha.ForEach(p =>
                            {
                                p.Cd_local = string.IsNullOrEmpty(p.Cd_local) ? linha["cd_local"].ToString() : p.Cd_local;
                                TCN_FichaTecProduto.Gravar(p, null);
                            });
                        }
                        else
                            PreencherFicha();
                    }
                    catch { }
                }
                lFicha.ForEach(p =>
                {
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Add(
                            new TRegistro_Ordem_MPrima
                            {
                                Cd_produto = p.Cd_item,
                                Ds_produto = p.Ds_item,
                                Cd_unidade = p.Cd_unditem,
                                Ds_unidade = p.Ds_unditem,
                                Sigla_unidade = p.Sg_unditem,
                                Cd_local = p.Cd_local,
                                Ds_local = p.Ds_local,
                                Qtd_produto = p.Quantidade,
                                Qtd_produto_calc = p.Quantidade,
                                SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, p.Cd_item, p.Cd_local, null)
                            });
                });
            }
            else
            {
                //Verificar ficha tecnica produção
                TList_FormulaApontamento lFormula =
                    CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar(CD_Empresa.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  cd_produto.Text,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  null);
                TRegistro_FormulaApontamento rFormula = null;
                if (lFormula.Count > 1)
                    using (TFListFormula fList = new TFListFormula())
                    {
                        fList.lFormula = lFormula;
                        if (fList.ShowDialog() == DialogResult.OK)
                        {
                            rFormula = fList.rFormula;
                            (bsOrdemProducao.Current as TRegistro_OrdemProducao).Qt_produto = rFormula.Qt_produto;
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório selecionar formula.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                else if (lFormula.Count.Equals(1))
                    rFormula = lFormula[0];
                if (rFormula != null)
                {
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).Qt_produto = rFormula.Qt_produto;
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_local = rFormula.Cd_local;
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).Ds_local = rFormula.Ds_local;
                    //Buscar ficha tecnica da formula selecionada
                    TList_FichaTec_MPrima lFichaP =
                    CamadaNegocio.Producao.Producao.TCN_FichaTec_MPrima.Buscar(rFormula.Cd_empresa,
                                                                               rFormula.Id_formulacaostr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               0,
                                                                               string.Empty,
                                                                               null);
                    lFichaP.ForEach(p =>
                    {
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Add(
                                new TRegistro_Ordem_MPrima
                                {
                                    CD_Empresa = p.Cd_empresa,
                                    ID_Formulacao_MPrima = p.Id_formulacao_mprima,
                                    Cd_produto = p.Cd_produto,
                                    Ds_produto = p.Ds_produto,
                                    Cd_unidade = p.Cd_unidade,
                                    Ds_unidade = p.Ds_unidade,
                                    Sigla_unidade = p.Sigla_unidade,
                                    Cd_local = p.Cd_local,
                                    Ds_local = p.Ds_local,
                                    Qtd_produto = p.Qtd_produto,
                                    Qtd_produto_calc = p.Qtd_produto,
                                    SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, p.Cd_produto, p.Cd_local, null)
                                });
                    });
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_formulacao = rFormula.Id_formulacao;
                }
            }
            bsOrdemMP.ResetCurrentItem();
            bsOrdemProducao.ResetCurrentItem();
        }

        private void TFOrdemProducao_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            if (rordem != null)
            {
                rordem.lOrdem_MPrima = CamadaNegocio.Producao.Producao.TCN_Ordem_MPrima.Buscar(rordem.Id_ordem.Value.ToString(), null);
                bsOrdemProducao.DataSource = new TList_OrdemProducao() { rordem };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                cd_unidade.Enabled = false;
                bb_unidade.Enabled = false;
                dt_prevproducao.Enabled = rordem.St_registro.Trim().ToUpper().Equals("A");
                qtd_programada.Enabled = rordem.St_registro.Trim().ToUpper().Equals("A");
                //Verificar se a ordem teve origem no pedido
                object obj = new TCD_OrdemProducao_X_PedItem().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_ordem",
                                        vOperador = "=",
                                        vVL_Busca = rordem.Id_ordem.Value.ToString()
                                    }
                                }, "1");
                qtd_programada.Enabled = obj == null;
                qtd_produzir.Value = (bsOrdemProducao.Current as TRegistro_OrdemProducao).QT_Produzir;
                bsOrdemProducao.ResetCurrentItem();
                dt_prevproducao.Focus();
            }
            else
            {
                bsOrdemProducao.AddNew();
                CD_Empresa.Text = pCd_empresa;
                NM_Empresa.Text = pNm_empresa;
                cd_produto.Text = pCd_produto;
                ds_produto.Text = pDs_produto;
                CD_Empresa.Enabled = string.IsNullOrWhiteSpace(pCd_empresa);
                BB_Empresa.Enabled = string.IsNullOrWhiteSpace(pCd_empresa);
                cd_produto.Enabled = string.IsNullOrWhiteSpace(pCd_produto);
                bb_produto.Enabled = string.IsNullOrWhiteSpace(pCd_produto);
                ds_produto.Enabled = string.IsNullOrWhiteSpace(pCd_produto);

                if (!cd_produto.Enabled)
                    cd_produto_Leave(this, new EventArgs());
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                            "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "        where y.logingrp = x.login " +
                            "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_industrializado, 'N')|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, vParam);

            if (linha != null)
            {
                cd_unidade.Text = linha["cd_unidade"].ToString();
                ds_unidade.Text = linha["ds_unidade"].ToString();
                sigla_unidade.Text = linha["sigla_unidade"].ToString();
                sg_unidade.Text = linha["sigla_unidade"].ToString();
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Count > 0)
                {
                    if (MessageBox.Show("Se a fórmula for modificada você pode perder as alterações na ficha,\r\n" +
                                        "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                    {
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.ForEach(x =>
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrimaDel.Add(x));
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Clear();
                        PreencherFicha();
                    }
                }
                else
                    PreencherFicha();
            }
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                            "isnull(e.st_industrializado, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam,
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());

            if (linha != null)
            {
                cd_unidade.Text = linha["cd_unidade"].ToString();
                ds_unidade.Text = linha["ds_unidade"].ToString();
                sigla_unidade.Text = linha["sigla_unidade"].ToString();
                sg_unidade.Text = linha["sigla_unidade"].ToString();
                if (!string.IsNullOrEmpty(cd_unidade.Text))
                {
                    cd_unidade.Enabled = false;
                    bb_unidade.Enabled = false;
                }
            }
            
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Count > 0)
                {
                    if (MessageBox.Show("Se a fórmula for modificada você pode perder as alterações na ficha,\r\n" +
                                        "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                    {
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.ForEach(x =>
                            (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrimaDel.Add(x));
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Clear();
                        PreencherFicha();
                    }
                }
                else
                    PreencherFicha();
            }
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|100;" +
                              "a.cd_unidade|Cd. Unidade|80;" +
                              "a.sigla_unidade|Sigla|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidade, sg_unidade },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidade, sg_unidade },
                                                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFOrdemProducao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void dt_prevfinprod_Leave(object sender, EventArgs e)
        {
            if (!dt_prevfinprod.IsDateTime() ? false : Convert.ToDateTime(dt_prevfinprod.Text) < Convert.ToDateTime(dt_prevproducao.Text))
            {
                MessageBox.Show("DT.Prevista p/ Finalização não pode ser menor que data prevista de ínicio");
                dt_prevfinprod.Clear();
                dt_prevfinprod.Focus();
            }
        }

        private void bbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFOrdem_MPrima fOrdem = new TFOrdem_MPrima())
            {
                fOrdem.pCd_empresa = CD_Empresa.Text;
                if (fOrdem.ShowDialog() == DialogResult.OK)
                    if (fOrdem.ROrdem_MPrima != null)
                    {
                        fOrdem.ROrdem_MPrima.SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, fOrdem.ROrdem_MPrima.Cd_produto, fOrdem.ROrdem_MPrima.Cd_local, null);
                        fOrdem.ROrdem_MPrima.Qtd_produto_calc = fOrdem.ROrdem_MPrima.Qtd_produto;
                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.Add(fOrdem.ROrdem_MPrima);
                        bsOrdemProducao.ResetCurrentItem();
                    }
            }
        }

        private void bbAlterar_Click(object sender, EventArgs e)
        {
            if (bsOrdemMP.Current != null)
                using (TFOrdem_MPrima fOrdem = new TFOrdem_MPrima())
                {
                    //Copia
                    TRegistro_Ordem_MPrima copia = new TRegistro_Ordem_MPrima();
                    copia.Cd_unidade = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Cd_unidade;
                    copia.Ds_unidade = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Ds_unidade;
                    copia.Sigla_unidade = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Sigla_unidade;
                    copia.Cd_local = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Cd_local;
                    copia.Ds_local = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Ds_local;
                    copia.Qtd_produto = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Qtd_produto;
                    copia.Pc_quebratec = (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Pc_quebratec;
                    fOrdem.pCd_empresa = CD_Empresa.Text;
                    fOrdem.ROrdem_MPrima = bsOrdemMP.Current as TRegistro_Ordem_MPrima;
                    if (fOrdem.ShowDialog() != DialogResult.OK)
                    {
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Cd_unidade = copia.Cd_unidade;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Ds_unidade = copia.Ds_unidade;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Sigla_unidade = copia.Sigla_unidade;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Cd_local = copia.Cd_local;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Ds_local = copia.Ds_local;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Qtd_produto = copia.Qtd_produto;
                        (bsOrdemMP.Current as TRegistro_Ordem_MPrima).Pc_quebratec = copia.Pc_quebratec;
                    }
                    bsOrdemMP.ResetCurrentItem();
                }
            else MessageBox.Show("Obrigatório selecionar matéria prima para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if (bsOrdemMP.Current != null)
                if (MessageBox.Show("Confirma exclusão matéria prima selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    bsOrdemMP.RemoveCurrent();
        }

        private void dt_prevproducao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_prevproducao.Text.SoNumero()))
            {
                if(string.IsNullOrEmpty(dt_prevfinprod.Text.SoNumero()) &&
                    (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_formulacao.HasValue)
                {
                    //Buscar parametro dias para produzir
                    object obj = new TCD_FormulaApontamento().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_empresa.Trim() + "'" },
                                        new TpBusca{vNM_Campo = "a.id_formulacao", vOperador = "=", vVL_Busca = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_formulacaostr }
                                    }, "isnull(a.DiasProduzir, 0)");
                    decimal DiasProduzir = Convert.ToInt32(obj);
                    if (DiasProduzir > 0)
                    {
                        DateTime dt_ini = DateTime.Parse(dt_prevproducao.Text);
                        for (int i = 0; i < DiasProduzir; i++)
                        {
                            if (dt_ini.AddDays(i + 1).DayOfWeek == DayOfWeek.Saturday ||
                                dt_ini.AddDays(i + 1).DayOfWeek == DayOfWeek.Sunday)
                                DiasProduzir++;
                        }
                        dt_prevfinprod.Text = dt_ini.AddDays(Convert.ToDouble(DiasProduzir - 1)).ToString("dd/MM/yyyy");
                    }
                }
                if (string.IsNullOrEmpty(dt_prevfinprod.Text.SoNumero()) ? false : Convert.ToDateTime(dt_prevfinprod.Text) < Convert.ToDateTime(dt_prevproducao.Text))
                {
                    MessageBox.Show("DT.Prevista p/ Finalização não pode ser menor que data prevista de ínicio");
                    dt_prevfinprod.Clear();
                    dt_prevfinprod.Focus();
                }
            }
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|150;" +
                             "a.cd_local|Código|50";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void Qt_particao_Leave(object sender, EventArgs e)
        {
            PreencherFicha();
        }

        private void Qt_particao_KeyDown(object sender, KeyEventArgs e)
        {
            PreencherFicha();
        }

        private void gFicha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void gFicha_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gFicha[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gFicha.EndEdit();
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != (char)44)
                e.Handled = true;
            else if (e.KeyChar == ',')
                if (((TextBox)sender).Text.Contains(","))
                    e.Handled = true;
        }

        private void gFicha_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsOrdemMP[e.RowIndex] as TRegistro_Ordem_MPrima).Qtd_produto >
                        (bsOrdemMP[e.RowIndex] as TRegistro_Ordem_MPrima).SaldoEstoque)
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
                    else
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
            }
        }

        private void qtd_programada_Leave(object sender, EventArgs e)
        {
            (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima.ForEach(p =>
            {
                p.Qtd_produto = p.Qtd_produto_calc * qtd_programada.Value;
            });
            qtd_produzir.Value = (bsOrdemProducao.Current as TRegistro_OrdemProducao).QT_Produzir;
            bsOrdemProducao.ResetCurrentItem();
        }

        private void bb_produto_Leave(object sender, EventArgs e)
        {
            if (bsOrdemProducao.Current != null)
                qtd_produzir.Value = (bsOrdemProducao.Current as TRegistro_OrdemProducao).QT_Produzir;
        }
    }
}

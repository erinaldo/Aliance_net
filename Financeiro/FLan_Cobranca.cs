using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFLan_Cobranca : Form
    {
        private Utils.TTpModo modo;
        public List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParc
        { get; set; }

        public TFLan_Cobranca()
        {
            InitializeComponent();
        }

        private void controlarPages()
        {
            if (modo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (tcCentral.TabPages.Contains(tpCobranca))
                    tcCentral.TabPages.Remove(tpCobranca);
                if (!tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Add(tpNavegador);
            }
            else if (modo.Equals(Utils.TTpModo.tm_Insert) || modo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                if (!tcCentral.TabPages.Contains(tpCobranca))
                    tcCentral.TabPages.Add(tpCobranca);
            }
        }

        private void limparCampos()
        {
            nm_contato.Clear();
            fone_contato.Clear();
            login.Clear();
            email.Clear();
            dt_agendamento.Clear();
            ds_historico.Clear();
        }

        private void afterNovo()
        {
            modo = Utils.TTpModo.tm_Insert;

            controlarPages();
            modoBotoes();
            nm_contato.Focus();
            bsContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                   lParc[0].Cd_clifor,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   false,
                                                                                                   false,
                                                                                                   false,
                                                                                                   string.Empty,
                                                                                                   0,
                                                                                                   null);
            bsCobranca.AddNew();
            limparCampos();
            (bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).Login = Utils.Parametros.pubLogin.Trim();
            bsCobranca.ResetCurrentItem();
        }

        private void afterAltera()
        {
            if (bsCobranca.Current != null)
            {
                bsContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                      lParc[0].Cd_clifor,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      false,
                                                                                                      false,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      0,
                                                                                                      null);
                if ((bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).Login.Trim().ToUpper() !=
                    Utils.Parametros.pubLogin.Trim().ToUpper())
                {
                    MessageBox.Show("Não é permitido a um usuario alterar registro de cobrança gravado por outro usuario.\r\n" +
                                    "Usuario gravou cobrança: " + (bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).Login.Trim().ToUpper() + "\r\n" +
                                    "Usuario logado sistema: " + Utils.Parametros.pubLogin.Trim().ToUpper() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                modo = Utils.TTpModo.tm_Edit;
                controlarPages();
                modoBotoes();
                nm_contato.Focus();
            }
        }

        private void afterCancela()
        {
            if (modo.Equals(Utils.TTpModo.tm_Insert))
                bsCobranca.RemoveCurrent();
            modo = Utils.TTpModo.tm_Standby;
            controlarPages();
            modoBotoes();
        }

        private void afterGravar()
        {
            if (bsCobranca.Current != null)
            {
                if (ds_historico.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar histórico da cobrança", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds_historico.Focus();
                    return;
                }
                try
                {
                    if (modo.Equals(Utils.TTpModo.tm_Insert))
                    {
                        lParc.ForEach(p =>
                            {
                                (bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).lParcelas.Add(
                                    new CamadaDados.Financeiro.Cobranca.TRegistro_Cobranca_X_Parcelas()
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Nr_lancto = p.Nr_lancto,
                                        Cd_parcela = p.Cd_parcela
                                    });
                            });
                    }

                    CamadaNegocio.Financeiro.Cobranca.TCN_Cobranca.GravarCobranca((bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor), null);
                    string msg = string.Empty;
                    if (lParc.Count > 0)
                    {
                        msg = lParc[0].Nm_empresa;
                    }

                    //Validar se foi informado e-mail corretamente para enviar cobrança
                    if (!string.IsNullOrEmpty(email.Text.Trim()))
                    {
                        FormRelPadrao.Email email = new FormRelPadrao.Email()
                        {
                            Destinatario = new List<string>() { (bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).Email.Trim() },
                            Titulo = "Cobrança " + msg,
                            Mensagem = (bsCobranca.Current as CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor).Ds_historico
                        };
                        email.EnviarEmail();
                    }

                    MessageBox.Show("Cobrança gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsParcelas_PositionChanged(this, new EventArgs());
                    modo = Utils.TTpModo.tm_Standby;
                    modoBotoes();
                    controlarPages();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private void modoBotoes()
        {
            if (modo.Equals(Utils.TTpModo.tm_Standby))
            {
                BB_Novo.Visible = true;
                BB_Alterar.Visible = true;
                BB_Gravar.Visible = false;
                BB_Cancelar.Visible = false;
            }
            else if (modo.Equals(Utils.TTpModo.tm_Insert) ||
                     modo.Equals(Utils.TTpModo.tm_Edit))
            {
                BB_Novo.Visible = false;
                BB_Alterar.Visible = false;
                BB_Gravar.Visible = true;
                BB_Cancelar.Visible = true;
            }
        }

        private decimal TotalAtualCobrado()
        {
            decimal total = 0;
            if (bsParcelas.Count > 0)
                for (int i = 0; i < bsParcelas.Count; i++)
                    if ((bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_cobrar)
                        total += (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Vl_atual;
            return total;
        }

        private void TFLan_Cobranca_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            Utils.ShapeGrid.RestoreShape(this, gCobranca);
            Utils.ShapeGrid.RestoreShape(this, tList_CadContatoCliForDataGridDefault);
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            label1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            bsParcelas.DataSource = lParc;
            bsParcelas_PositionChanged(this, new EventArgs());
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            modo = Utils.TTpModo.tm_Standby;
            controlarPages();
            modoBotoes();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void bsParcelas_PositionChanged(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                //Buscar as cobrancas da parcela selecionada
                bsCobranca.DataSource = CamadaNegocio.Financeiro.Cobranca.TCN_Cobranca.Buscar(0,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              new Utils.Parcelas[]
                                                                                              {
                                                                                                  new Utils.Parcelas()
                                                                                                  {
                                                                                                      vCd_empresa = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_empresa,
                                                                                                      vNr_lancto = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Nr_lancto,
                                                                                                      vCd_parcela = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_parcela
                                                                                                  }
                                                                                              },
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
                edtTotalAtual.Value = TotalAtualCobrado();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tList_RegLanParcelaDataGridDefault_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modo.Equals(Utils.TTpModo.tm_Insert))
                if (bsParcelas.Current != null)
                    if (e.ColumnIndex.Equals(0))
                    {
                        (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_cobrar =
                            !(bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_cobrar;
                        bsParcelas.ResetBindings(true);
                    }
            edtTotalAtual.Value = TotalAtualCobrado();
        }

        private void tList_CadContatoCliForDataGridDefault_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsContatos.Current != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if ((bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato)
                    {
                        (bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato = false;
                        nm_contato.Clear();
                        fone_contato.Clear();
                        email.Clear();
                        nm_contato.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < bsContatos.Count; i++)
                            (bsContatos[i] as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato = false;
                        (bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato = true;
                        nm_contato.Text = (bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).Nm_Contato.Trim();
                        fone_contato.Text = (bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).Fone.Trim();
                        email.Text = (bsContatos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).Email.Trim();
                        ds_historico.Focus();
                    }
                    bsContatos.ResetBindings(true);
                }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGravar();
        }

        private void TFLan_Cobranca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGravar();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
        }

        private void dt_agendamento_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime data = Convert.ToDateTime(dt_agendamento.Text);
                if (data <= DateTime.Now)
                {
                    MessageBox.Show("Data do agendamento deve ser maior que a data atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_agendamento.Clear();
                    dt_agendamento.Focus();
                }
            }
            catch
            { }
        }

        private void gCobranca_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCobranca.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCobranca.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cobranca.TRegistro_CobrancaClifor());
            CamadaDados.Financeiro.Cobranca.TList_CobrancaClifor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCobranca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCobranca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cobranca.TList_CobrancaClifor(lP.Find(gCobranca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCobranca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cobranca.TList_CobrancaClifor(lP.Find(gCobranca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCobranca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCobranca.List as CamadaDados.Financeiro.Cobranca.TList_CobrancaClifor).Sort(lComparer);
            bsCobranca.ResetBindings(false);
            gCobranca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLan_Cobranca_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
            Utils.ShapeGrid.SaveShape(this, gCobranca);
            Utils.ShapeGrid.SaveShape(this, tList_CadContatoCliForDataGridDefault);
        }
    }
}

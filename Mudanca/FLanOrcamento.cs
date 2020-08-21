using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mudanca
{
    public partial class TFLanOrcamento : Form
    {
        public TFLanOrcamento()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxOrcamento.Checked)
            {
                status += virg + "0";
                virg = ",";
            }
            if (cbxAprovada.Checked)
            {
                status = "1";
                virg = ",";
            }
            if (cbxReprovada.Checked)
                status += virg + "2";
            bsOrcamento.DataSource =
                CamadaNegocio.Mudanca.TCN_Orcamento.Buscar(string.Empty,
                                                           id_orcamento.Text,
                                                           string.Empty,
                                                           nm_cliente.Text,
                                                           rbColeta.Checked ? "C" : rbEntrega.Checked ? "E" : "O",
                                                           dt_ini.Text,
                                                           dt_fin.Text,
                                                           string.Empty,
                                                           string.Empty,
                                                           status,
                                                           null);
            bsOrcamento.ResetCurrentItem();
        }

        private void AprovarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).St_registro.Equals("1"))
                {
                    MessageBox.Show("Orçamento já está APROVADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).St_registro.Equals("2"))
                {
                    MessageBox.Show("Não é permitido aprovar orçamento REPROVADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFMudanca fAprovar = new TFMudanca())
                {
                    fAprovar.rOrcamento = bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento;
                    if (fAprovar.ShowDialog() == DialogResult.OK)
                    {
                        if (fAprovar.rMudanca != null)
                            try
                            {
                                //Aprovar Orçamento
                                fAprovar.rMudanca.lOrcamento.Add(bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento);
                                fAprovar.rMudanca.St_registro = "1";
                                CamadaNegocio.Mudanca.TCN_LanMudanca.Gravar(fAprovar.rMudanca, null);
                                MessageBox.Show("Orçamento Aprovado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else if (fAprovar.DialogResult == DialogResult.No)
                        this.ReprovarOrcamento();
                }
            }
        }

        private void ReprovarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).St_registro.Equals("1"))
                {
                    MessageBox.Show("Não é possivel reprovar o orçamento!\r\nEle está aprovado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).St_registro.Equals("2"))
                {
                    MessageBox.Show("Não é possivel reprovar o orçamento!\r\nEle já está reprovado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Tem certeza que deseja reprovar o Orçamento Nº " +
                                    (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Id_orcamentostr.Trim() + "?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                {
                    Utils.InputBox ibp = new Utils.InputBox();
                    ibp.Text = "Motivo";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatório informar Motivo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Ds_motivoreprovado = ds;
                        CamadaNegocio.Mudanca.TCN_Orcamento.Reprovar(bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento reprovado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanOrcamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_Aprovar_Click(object sender, EventArgs e)
        {
            this.AprovarOrcamento();
        }

        private void BB_Reprovar_Click(object sender, EventArgs e)
        {
            this.ReprovarOrcamento();
        }

        private void TFLanOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.AprovarOrcamento();
            else if (e.KeyCode.Equals(Keys.F5))
                this.ReprovarOrcamento();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                //Buscar Itens
                (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).lItens =
                    CamadaNegocio.Mudanca.TCN_Orcamento_X_Itens.Buscar((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Cd_empresa,
                                                                       (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Id_orcamentostr,
                                                                       null);

                //Buscar Encaixotamento
                (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).lEnc =
                    CamadaNegocio.Mudanca.TCN_Encaixotamento.Buscar((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Cd_empresa,
                                                                    (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Id_orcamentostr,
                                                                    null);
                //Buscar servico
                (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).lSer =
                    CamadaNegocio.Mudanca.TCN_ServicoOrc.Buscar((bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Cd_empresa,
                                                                    (bsOrcamento.Current as CamadaDados.Mudanca.TRegistro_Orcamento).Id_orcamentostr,
                                                                    null);


                bsOrcamento.ResetCurrentItem();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gOrcamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}

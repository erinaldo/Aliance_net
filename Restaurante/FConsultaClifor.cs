using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using System.Windows.Forms;
using Restaurante.Cadastro;
using CamadaNegocio.Financeiro.Cadastros;

namespace Restaurante
{
    public partial class TFConsultaClifor : Form
    {
        public string nome { get; set; } = string.Empty;
        private TRegistro_Clifor cClifor { get; set; } = new TRegistro_Clifor();
        public TRegistro_Clifor rClifor
        {
            get
            {
                return bsClifor.Current as TRegistro_Clifor;
            }
            set
            {
                cClifor = value;
            }
        }

        public TFConsultaClifor()
        {
            InitializeComponent();
        }

        #region Métodos

        private void afterbusca()
        {
            if (!string.IsNullOrEmpty(nm_clifor.Text))
            {
                TpBusca[] filtro = new TpBusca[0];

                if (!string.IsNullOrEmpty(nm_clifor.Text.Trim().SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.celular";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'%" + nm_clifor.Text.Trim().SoNumero() + "%'";
                }
                else
                if (!string.IsNullOrEmpty(nm_clifor.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'%" + nm_clifor.Text + "%'";
                }

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'A'";

                bsClifor.DataSource = new TCD_Clifor().Select(filtro, 0, string.Empty);
                bsClifor.ResetCurrentItem();
            }
        }

        #endregion

        #region Eventos

        private void FConsultaClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterbusca();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
                DialogResult = DialogResult.OK;
        }

        private void FConsultaClifor_Load(object sender, EventArgs e)
        {
            nm_clifor.Text = nome;
        }

        private void nm_clifor_TextChanged(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void dataGridDefault1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DialogResult = DialogResult.OK;
        }

        private void nm_clifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                dataGridDefault1.Focus();
            }
        }

        private void btn_InserirCliente_Click(object sender, EventArgs e)
        {
            using (TFCliforDetalhado fClifor = new TFCliforDetalhado())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            TCN_CliFor.Gravar(fClifor.rClifor, null);
                            MessageBox.Show("Cliente gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsClifor.DataSource = new TList_Clifor() { fClifor.rClifor };
                            DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_ExcluirCliente_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (MessageBox.Show("Confirma a exclusão do cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_CliFor.Excluir(bsClifor.Current as TRegistro_Clifor, null);
                        MessageBox.Show("Cliente cancelado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsClifor.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void dataGridDefault1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                using (TFCliforDetalhado fClifor = new TFCliforDetalhado())
                {
                    fClifor.rClifor = (bsClifor.Current as TRegistro_Clifor);
                    if (fClifor.ShowDialog() == DialogResult.OK)
                    {
                        TCN_CliFor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente selecionado, alterado com sucesso.");
                    }
                }
            }
        }

        #endregion
    }
}

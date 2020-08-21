using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFListPessoasAut : Form
    {
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }

        public CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas rPessoa
        {
            get
            {
                if (bsPessoas.Count > 0)
                    return (bsPessoas.List as CamadaDados.Financeiro.Cadastros.TList_PessoasAutorizadas).Find(p => p.St_processar);
                else return null;
            }
        }

        public TFListPessoasAut()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsPessoas.Count > 0)
            {
                if (!(bsPessoas.List as CamadaDados.Financeiro.Cadastros.TList_PessoasAutorizadas).Exists(p => p.St_processar))
                {
                    MessageBox.Show("Obrigatório selecionar pessoa autorizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("Cliente não possui pessoas autorizadas a comprar em seu cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gPessoas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).St_processar)
                {
                    (bsPessoas.List as CamadaDados.Financeiro.Cadastros.TList_PessoasAutorizadas).ForEach(p => p.St_processar = false);
                    (bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).St_processar = true;
                }
                else (bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).St_processar = false;
                bsPessoas.ResetBindings(true);
            }
        }

        private void TFListPessoasAut_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_clifor.Text = pCd_clifor;
            nm_clifor.Text = pNm_clifor;
            //Buscar Lista de Pessoas Autorizadas pelo cliente
            bsPessoas.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_PessoasAutorizadas.Buscar(pCd_clifor,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    "'A'",
                                                                                                    null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFListPessoasAut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

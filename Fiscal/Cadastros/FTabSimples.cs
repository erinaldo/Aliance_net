using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFTabSimples : Form
    {
        private CamadaDados.Fiscal.TRegistro_TabSimples rtab;
        public CamadaDados.Fiscal.TRegistro_TabSimples rTab
        {
            get
            {
                if (bsTabSimples.Current != null)
                    return bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples;
                else return null;
            }
            set { rtab = value; }
        }

        public TFTabSimples()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_tabela.Text))
            {
                MessageBox.Show("Obrigatório informar descrição tabela.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_tabela.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            using (TFAliquotaSimples fAliq = new TFAliquotaSimples())
            {
                if (fAliq.ShowDialog() == DialogResult.OK)
                    if (fAliq.rAliq != null)
                    {
                        (bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples).lAliq.Add(fAliq.rAliq);
                        bsTabSimples.ResetCurrentItem();
                    }
            }
        }

        private void AlterarItem()
        {
            if(bsAliq.Current != null)
                using (TFAliquotaSimples fAliq = new TFAliquotaSimples())
                {
                    CamadaDados.Fiscal.TRegistro_AliquotaSimples rAux = new CamadaDados.Fiscal.TRegistro_AliquotaSimples();
                    rAux.Id_aliquota = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Id_aliquota;
                    rAux.Ds_aliquota = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Ds_aliquota;
                    rAux.Pc_aliquota = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_aliquota;
                    rAux.Pc_irpj = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_irpj;
                    rAux.Pc_csll = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_csll;
                    rAux.Pc_cofins = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_cofins;
                    rAux.Pc_pis = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_pis;
                    rAux.Pc_cpp = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_cpp;
                    rAux.Pc_icms = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_icms;
                    rAux.Pc_ipi = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_ipi;
                    rAux.Pc_iss = (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_iss;
                    fAliq.rAliq = bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples;
                    if (fAliq.ShowDialog() != DialogResult.OK)
                    {
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Id_aliquota = rAux.Id_aliquota;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Ds_aliquota = rAux.Ds_aliquota;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_aliquota = rAux.Pc_aliquota;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_irpj = rAux.Pc_irpj;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_csll = rAux.Pc_csll;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_cofins = rAux.Pc_cofins;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_pis = rAux.Pc_pis;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_cpp = rAux.Pc_cpp;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_icms = rAux.Pc_icms;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_ipi = rAux.Pc_ipi;
                        (bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples).Pc_iss = rAux.Pc_iss;
                        bsAliq.ResetCurrentItem();
                    }
                }
        }

        private void ExcluirItem()
        {
            if(bsAliq.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro corrente?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples).lAliqDel.Add(
                        bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples);
                    bsAliq.RemoveCurrent();
                }
        }

        private void TFTabSimples_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rtab != null)
                bsTabSimples.DataSource = new CamadaDados.Fiscal.TList_TabSimples() { rtab };
            else bsTabSimples.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFTabSimples_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }
    }
}

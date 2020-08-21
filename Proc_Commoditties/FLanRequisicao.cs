using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFLanRequisicao : Form
    {
        private List<CamadaDados.Compra.Lancamento.TRegistro_Requisicao> lrequisicao;
        public List<CamadaDados.Compra.Lancamento.TRegistro_Requisicao> lRequisicao
        {
            get
            {
                if (bsRequisicao.Count > 0)
                    return (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao);
                else
                    return null;
            }
            set {lrequisicao = value;}
        }
        public TFLanRequisicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p=> p.St_integrar))
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanRequisicao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsRequisicao.DataSource = lrequisicao;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
                gRequisicao_DoubleClick(this, new EventArgs());
        }

        private void gRequisicao_DoubleClick(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
            {
                //Informar Quantidade
                decimal valor = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade;
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Text = "Quantidade Item";
                    fQtde.Vl_default = valor;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                        if (fQtde.Quantidade > decimal.Zero)
                            (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade = fQtde.Quantidade;
                        else
                        {
                            MessageBox.Show("Quantidade não pode ser igual a zero!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade = valor;
                            return;
                        }
                }
                bsRequisicao.ResetCurrentItem();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFIntervencaoTecnica : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica rintervencao;
        public CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica rIntervencao
        {
            get
            {
                if (bsIntervencao.Current != null)
                    return bsIntervencao.Current as CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica;
                else
                    return null;
            }
            set { rintervencao = value; }
        }

        public TFIntervencaoTecnica()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(bsBico.Count > 0)
                    if ((bsIntervencao.Current as CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica).lBico.Exists(p => p.Qtd_encerrante.Equals(decimal.Zero)))
                    {
                        MessageBox.Show("Obrigatorio informar encerrante para todos os bicos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        encerrante.Focus();
                        return;
                    }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(id_bomba.Text))
                vParam = "|exists|(select 1 from tb_pdc_bombaabastecimento x " +
                         "          where x.cd_empresa = a.cd_empresa " +
                         "          and x.id_bomba = " + id_bomba.Text + ")";
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(id_bomba.Text))
                vParam += ";|exists|(select 1 from tb_pdc_bombaabastecimento x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.id_bomba = " + id_bomba.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_bomba_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bomba|Id. Bomba|80;" +
                              "a.ds_modelo|Modelo|200;" +
                              "a.nr_serie|Nº Serie|80";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, 
                                             new Componentes.EditDefault[] { id_bomba }, 
                                             new CamadaDados.PostoCombustivel.Cadastros.TCD_BombaAbastecimento(), 
                                             vParam);
        }

        private void id_bomba_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bomba|=|" + id_bomba.Text;
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam,
                                              new Componentes.EditDefault[] { id_bomba },
                                              new CamadaDados.PostoCombustivel.Cadastros.TCD_BombaAbastecimento());
        }

        private void bb_cliforintervencao_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforintervencao, nm_cliforintervencao, nr_cnpjintervencao },
                                                   "a.tp_pessoa|=|'J'");
        }

        private void cd_cliforintervencao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforintervencao.Text.Trim() + "';a.tp_pessoa|=|'J'",
                                                    new Componentes.EditDefault[] { cd_cliforintervencao, nm_cliforintervencao, nr_cnpjintervencao },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFIntervencaoTecnica_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rintervencao != null)
                bsIntervencao.DataSource = new CamadaDados.PostoCombustivel.TList_IntervencaoTecnica() { rintervencao };
            else
                bsIntervencao.AddNew();
            cd_empresa.Focus();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFIntervencaoTecnica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsBico.MovePrevious();
            encerrante.Focus();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsBico.MoveNext();
            encerrante.Focus();
        }

        private void TFIntervencaoTecnica_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}

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
    public partial class TFFinConvenio : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_FinConvenio rfin;
        public CamadaDados.PostoCombustivel.TRegistro_FinConvenio rFin
        {
            get
            {
                if (bsFinConvenio.Current != null)
                    return bsFinConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_FinConvenio;
                else
                    return null;
            }
            set { rfin = value; }
        }

        public TFFinConvenio()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx.Add(new Utils.TDataCombo("VALOR", "V"));

            tp_desconto.DataSource = cbx;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFFinConvenio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rfin != null)
            {
                bsFinConvenio.DataSource = new CamadaDados.PostoCombustivel.TList_FinConvenio() { rfin };
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                cd_portador.Focus();
            }
            else
            {
                bsFinConvenio.AddNew();
                cd_produto.Focus();
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                            "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vparam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vparam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFFinConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            string vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpdocto|Tipo Documento|200;" +
                            "a.tp_docto|TP. Docto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. Condição|80";
            string vParam = "a.qt_parcelas|=|1";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "';" +
                            "a.qt_parcelas|=|1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }
    }
}

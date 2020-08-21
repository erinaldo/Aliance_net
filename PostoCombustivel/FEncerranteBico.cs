using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.PostoCombustivel;

namespace PostoCombustivel
{
    public partial class TFEncerranteBico : Form
    {
        public string Id_bico
        { get; set; }
        public string Id_tanque
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public DateTime? Dt_encerrante
        { get; set; }

        private TRegistro_EncerranteBico rencerrante;
        public TRegistro_EncerranteBico rEncerrante
        {
            get
            {
                if (bsEncerrante.Current != null)
                    return bsEncerrante.Current as TRegistro_EncerranteBico;
                else
                    return null;
            }
            set { rencerrante = value; }
        }

        public TFEncerranteBico()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ABERTURA", "A"));
            cbx.Add(new Utils.TDataCombo("FECHAMENTO", "F"));
            cbx.Add(new Utils.TDataCombo("INTERVENÇÃO", "I"));

            tp_encerrante.DataSource = cbx;
            tp_encerrante.DisplayMember = "Display";
            tp_encerrante.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (qtd_encerrante.Focused)
                    (bsEncerrante.Current as TRegistro_EncerranteBico).Qtd_encerrante = qtd_encerrante.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFEncerranteBico_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rencerrante != null)
            {
                bsEncerrante.DataSource = new TList_EncerranteBico() { rencerrante };
                id_bico.Enabled = false;
                bb_bico.Enabled = false;
            }
            else
            {
                bsEncerrante.AddNew();
                id_bico.Text = Id_bico;
                id_bico_Leave(this, new EventArgs());
                id_bico.Enabled = string.IsNullOrEmpty(Id_bico);
                bb_bico.Enabled = string.IsNullOrEmpty(Id_bico);
                dt_encerrante.Text = Dt_encerrante.HasValue ? Dt_encerrante.Value.ToString() : string.Empty;
            }
        }

        private void bb_bico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|Id. Bico|60;" +
                              "a.ds_label|Label Bico|80;" +
                              "c.ds_produto|Combustivel|200;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "d.nm_empresa|Empresa|200";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(f.st_lubrificante, 'N')|<>|'S'";
            if (!string.IsNullOrEmpty(Id_tanque))
                vParam = ";a.cd_empresa|=|'" + Cd_empresa.Trim() + "';" +
                          "a.id_tanque|=|" + Id_tanque;
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bico, ds_label, cd_empresa, nm_empresa, ds_produto },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(), vParam);
        }

        private void id_bico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|=|" + id_bico.Text + ";" +
                              "isnull(a.st_registro, 'A')|<>|'C';" +
                              "isnull(f.st_lubrificante, 'N')|<>|'S'";
            if (!string.IsNullOrEmpty(Id_tanque))
                vColunas += ";a.cd_empresa|=|'" + Cd_empresa.Trim() + "'" +
                            ";a.id_tanque|=|" + Id_tanque;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_bico, ds_label, cd_empresa, nm_empresa, ds_produto },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEncerranteBico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_encerrante_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /") &&
                (tp_encerrante.SelectedValue != null))
                qtd_encerrante.Value =
                    CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.BuscarAfericaoBico(cd_empresa.Text,
                                                                                           id_bico.Text,
                                                                                           DateTime.Parse(dt_encerrante.Text),
                                                                                           tp_encerrante.SelectedValue.ToString(),
                                                                                           null);
        }
    }
}

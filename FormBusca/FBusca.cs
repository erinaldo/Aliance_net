using System;
using System.Data;
using System.Windows.Forms;
using Utils;
using CamadaDados;

namespace FormBusca
{
    public partial class TFBusca : Form
    {
        //
        //Atributos
        //
        private DataTable vtb_configGrid;
        private string vcampoChave;
        private string vcampoBusca;
        private string vLogin;
        public TpBusca[] confBusca;
        public TpBusca[] aParamBusca;
        public TDataQuery NM_DatClass; 
        //
        //Propriedades
        //
        public string campoChave { get { if (vcampoChave != null)return vcampoChave; else return string.Empty; } set { vcampoChave = value; } }
        public string campoBusca { get { if (vcampoBusca != null)return vcampoBusca; else return string.Empty; } set { vcampoBusca = value; } }
        public string login { get { if (vLogin != null)return vLogin; else return string.Empty; } set { vLogin = value; } }
        public DataTable tb_configGrid { get { return vtb_configGrid; } set { vtb_configGrid = value; } }
        public string pParametroBusca
        { get; set; }
        //
        //Metodos
        //
        public TFBusca()
        {
            InitializeComponent();
            vcampoBusca = string.Empty;
        }

        private void preencherCbCampos()
        {
            for (Int16 i = 0; i < confBusca.Length; i++)
            {
                if (confBusca[i].vNM_Campo.Trim().Substring(0, 1) != "#")
                    cbCampos.Items.Add(confBusca[i].vNM_Caption);
                gBusca.Columns.Add("f" + confBusca[i].vNM_Campo.Remove(0, confBusca[i].vNM_Campo.IndexOf('.') + 1), confBusca[i].vNM_Caption);
                gBusca.Columns[i].DataPropertyName = confBusca[i].vNM_Campo.Trim().Substring(0, 1) != "#" ? confBusca[i].vNM_Campo.Remove(0, confBusca[i].vNM_Campo.IndexOf('.') + 1) : confBusca[i].vNM_Campo.Trim().Remove(0, 1);
                gBusca.Columns[i].ReadOnly = true;
                gBusca.Columns[i].Width = confBusca[i].vWidth;
            }
            cbCampos.SelectedIndex = 0;
        }

        private void configColumGrid()
        {
            if (!(vcampoBusca.Trim().Equals("")))
                cbCampos.Text = vcampoBusca.Trim();
            if (tb_configGrid == null ? false : tb_configGrid.Rows.Count > 0)
            {
                int cont = gBusca.Columns.Count;
                for (int i = 0; i < cont; i++)
                {
                    object[] chave = new object[] { vLogin, vcampoChave, gBusca.Columns[i].Name.Trim() };
                    DataRow linha = tb_configGrid.Rows.Find(chave);
                    if (linha != null)
                    {
                        try
                        {
                            gBusca.Columns[i].DisplayIndex = Convert.ToInt32(linha["index"].ToString().Trim());
                            gBusca.Columns[i].Width = Convert.ToInt32(linha["tamanho"].ToString().Trim());
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void buscarRegistros()
        {
            if (NM_DatClass != null)
            {
                if (confBusca[cbCampos.Items.IndexOf(cbCampos.Text)].vOperador.ToUpper().Equals("LIKE"))
                    confBusca[cbCampos.Items.IndexOf(cbCampos.Text)].vVL_Busca = (Parametros.ST_UtilizarCoringaEsq ? "'%" : "'%") + txtBusca.Text + "%' COLLATE Latin1_General_CI_AI ";
                else
                    confBusca[cbCampos.Items.IndexOf(cbCampos.Text)].vVL_Busca = txtBusca.Text;
                TpBusca[] aux;
                if (aParamBusca != null)
                {
                    aux = aParamBusca;
                    Array.Resize(ref aux, aux.Length + 1);
                }
                else
                    aux = new TpBusca[1];
                aux[aux.Length - 1] = confBusca[cbCampos.Items.IndexOf(cbCampos.Text)];
                bSource.DataSource = NM_DatClass.Buscar(aux, Convert.ToInt16(nLinhas.Value));
                gBusca.DataSource = bSource;
            }
            else
                MessageBox.Show("Classe de busca não instanciada!", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FBusca_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(pParametroBusca))
                txtBusca.Text = pParametroBusca;
            preencherCbCampos();
            configColumGrid();
            nLinhas.Value = nLinhas.Value.Equals(decimal.Zero) ? Parametros.pubTopMax > 0 ? Parametros.pubTopMax : 15 : nLinhas.Value;
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            buscarRegistros();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            tempo.Enabled = true;
        }

        private void cbCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempo_Tick(this, new EventArgs());
        }

        private void gBusca_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void nLinhas_ValueChanged(object sender, EventArgs e)
        {
            tempo.Enabled = true;
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
                gBusca.Focus();
        }
    }
}
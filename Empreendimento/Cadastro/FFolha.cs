using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;
using FormBusca;

namespace Empreendimento.Cadastro
{
    public partial class FFolha : Form
    {

        private List<TRegistro_CadEncargosFolha> cLfolha;
        public List<TRegistro_CadEncargosFolha> rLfolha
        {
            get { return bsFolha.List as List<TRegistro_CadEncargosFolha>; }
            set
            {
                cLfolha = value;
            }
        }


        public FFolha()
        {
            InitializeComponent();
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                (bsFolha.Current as TRegistro_CadEncargosFolha).st_agregar 
                    = !(bsFolha.Current as TRegistro_CadEncargosFolha).st_agregar;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FFolha_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            TpBusca[] filtro = new TpBusca[0];

            if(cLfolha != null)
            if (cLfolha.Count > 0)
            {
                cLfolha.ForEach(p => {

                    if (!string.IsNullOrEmpty(p.Ds_encargo))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.ds_encargo";
                        filtro[filtro.Length - 1].vOperador = "<>";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + p.Ds_encargo.Trim() + "'";
                    }
                });
            }
            
            bsFolha.DataSource = new TCD_CadEncargosFolha().Select(filtro, 100, string.Empty);
            
            bsFolha.ResetCurrentItem();

        }

        private void FFolha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            if (e.KeyCode.Equals(Keys.F6))
            {
                bb_cancelar_Click(this, new EventArgs());
            }

        }
    }
}

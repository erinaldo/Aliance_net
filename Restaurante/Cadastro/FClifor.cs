using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using System.Windows.Forms;

namespace Restaurante.Cadastro
{
    public partial class FClifor : Form
    {
        public FClifor()
        {
            InitializeComponent();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {

            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(fone.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.celular";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + fone.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(editDefault1.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + editDefault1.Text.Trim() + "%'";
            } 
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'A'";
             

            bsClifor.DataSource = new CamadaDados.Restaurante.Cadastro.TCD_Clifor().Select(filtro, 0,string.Empty);
            bsClifor.ResetCurrentItem();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using(TFCliforDetalhado cd = new TFCliforDetalhado())
            {
                if(cd.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar(cd.rClifor, null);
                    bbBuscar_Click(this, new EventArgs());
                } 
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if(bsClifor.Current != null)
            using (TFCliforDetalhado cd = new TFCliforDetalhado())
            {
                cd.rClifor = (bsClifor.Current as CamadaDados.Restaurante.Cadastro.TRegistro_Clifor);
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar(cd.rClifor, null);
                    bbBuscar_Click(this, new EventArgs());
                }
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (MessageBox.Show("Deseja excluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as CamadaDados.Restaurante.Cadastro.TRegistro_Clifor).St_registro = "C";
                    CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar((bsClifor.Current as CamadaDados.Restaurante.Cadastro.TRegistro_Clifor), null);
                    bbBuscar_Click(this, new EventArgs());
                }

        }

        private void FClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
            {
                BB_Novo_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F3))
            {
                BB_Alterar_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F7))
            {
                bbBuscar_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F5))
            {
                BB_Excluir_Click(this, new EventArgs());
            }
        }

        private void FClifor_Load(object sender, EventArgs e)
        {

            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

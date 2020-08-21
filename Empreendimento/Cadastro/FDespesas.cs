using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento.Cadastro;
using Utils;
using CamadaNegocio.Empreendimento.Cadastro;

namespace Empreendimento.Cadastro
{
    public partial class FDespesas : Form
    {
      
        private TList_CadDespesa cLDespesa
        {
            get;set;
        }
        public TList_CadDespesa rLDespesa
        {
            get
            {
                return bsDespesas.DataSource as TList_CadDespesa;
            }
            set
            {
                cLDespesa = value;
            }

        }


        public FDespesas()
        {
            InitializeComponent();
        }

        private void FDespesas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            TpBusca[] filtro = new TpBusca[0];

            //if (cLDespesa.Count > 0)
            //{
            //    cLDespesa.ForEach(p => {

            //        if (!string.IsNullOrEmpty(p.Id_despesastr))
            //        {
            //            Array.Resize(ref filtro, filtro.Length + 1);
            //            filtro[filtro.Length - 1].vNM_Campo = "a.Id_despesa";
            //            filtro[filtro.Length - 1].vOperador = "<>";
            //            filtro[filtro.Length - 1].vVL_Busca = "'" + p.Id_despesastr.Trim() + "'";
            //        }
            //    });

            //}

            bsDespesas.DataSource = new CamadaDados.Empreendimento.Cadastro.TCD_CadDespesa().Select(filtro, 100, string.Empty);
            bsDespesas.ResetCurrentItem();
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            (bsDespesas.Current as TRegistro_CadDespesa).st_agregar = !(bsDespesas.Current as TRegistro_CadDespesa).st_agregar;
        }
    }
}

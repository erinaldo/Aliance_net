using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class FRequisitos : Form
    {
        private CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos cLRequisito;
        public CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos rLRequisito
        {
            set { cLRequisito = value; }
            get
            {
                if (bsRequisito.Current != null)
                {
                    return bsRequisito.DataSource as CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos;
                }
                else return null;

            }

        }
        public FRequisitos()
        {
            InitializeComponent();
        }

        private void FRequisitos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos list = new CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos();
            if (cLRequisito.Count > 0)
            {
                list = cLRequisito;
                string vparam = string.Empty;
                int i = 0;
                list.ForEach(p =>
                {
                    vparam += "( id_requisito <> " + p.id_requisito + ")";
                    if (i < list.Count - 1)
                        vparam += " and ";
                    i++;
                });

                bsRequisito.DataSource = new CamadaDados.Empreendimento.Cadastro.TCD_CadRequisitos().Select(new Utils.TpBusca[]
                {
                new Utils.TpBusca()
                {
                    vNM_Campo = vparam
                }
                }, 0,"");
                bsRequisito.ResetCurrentItem();
            }
            else
            {
                bsRequisito.DataSource = CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Buscar(string.Empty, string.Empty, null);
                bsRequisito.ResetCurrentItem();
            }

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
            if (e.ColumnIndex.Equals(0))
            {
                if(bsRequisito.Current != null)
                (bsRequisito.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos).st_agregar =
                    !(bsRequisito.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos).st_agregar;
            }
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        {
            (bsRequisito.List as CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos).ForEach(p =>
            {
                p.st_agregar = checkBoxDefault1.Checked;
            });
            bsRequisito.ResetCurrentItem();
        }
    }
}

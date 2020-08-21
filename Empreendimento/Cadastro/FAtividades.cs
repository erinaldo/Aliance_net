using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class FAtividades : Form
    {
        private CamadaDados.Empreendimento.Cadastro.TList_CadAtividade cLAtividade;
        public CamadaDados.Empreendimento.Cadastro.TList_CadAtividade rLAtividade
        {
            set { cLAtividade = value; }
            get
            {
                if (bsAtividade.Current != null)
                {
                    return bsAtividade.DataSource as CamadaDados.Empreendimento.Cadastro.TList_CadAtividade;
                }
                else return null;

            }

        }


        public FAtividades()
        {
            InitializeComponent();
        }

        private void FAtividades_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            TpBusca[] filtro = new TpBusca[0];
            
            //if (cLAtividade.Count > 0)
            //{
            //    cLAtividade.ForEach(p => {

            //        if (!string.IsNullOrEmpty(p.Ds_atividade))
            //        {
            //            Array.Resize(ref filtro, filtro.Length + 1);
            //            filtro[filtro.Length - 1].vNM_Campo = "a.ds_atividade";
            //            filtro[filtro.Length - 1].vOperador = "<>";
            //            filtro[filtro.Length - 1].vVL_Busca = "'" + p.Ds_atividade.Trim() + "'";
            //        }
            //    });

            //}


            List<CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade> lAtvid = new CamadaDados.Empreendimento.Cadastro.TCD_CadAtividade().Select(filtro, 100, string.Empty);
            

            bsAtividade.DataSource = lAtvid;

        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar =
                    !(bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar;

                //(bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).lRequisitos.ForEach(p => 
                //p.st_agregar = (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar);
                bsAtividade.ResetCurrentItem();
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

        private void FAtividades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                this.DialogResult = DialogResult.OK;
            }
            if (e.KeyCode.Equals(Keys.F6))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {
            if(bsAtividade.Current != null)
            {
                //(bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).lRequisitos =
                //    CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Buscar(
                //        (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).Id_atividadestr,
                //        string.Empty, null);
            }
            bsAtividade.ResetCurrentItem();
        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 0)
            //{
            //    bool flag = false;
            //    (bsRequisitos.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos).st_agregar =
            //        !(bsRequisitos.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos).st_agregar;
            //    if (!(bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar) 
            //        (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar = true;
            //    if ((bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar)
            //    {
            //        (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).lRequisitos.ForEach(p =>
            //        {
            //            if (p.st_agregar)
            //                flag = true;
            //        });
            //        (bsAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).st_agregar = flag;
            //    }

            //    bsAtividade.ResetCurrentItem();
            //}
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        {
            (bsAtividade.List as CamadaDados.Empreendimento.Cadastro.TList_CadAtividade).ForEach(p =>
            {
                p.st_agregar = checkBoxDefault1.Checked;
            });
            bsAtividade.ResetCurrentItem();
        }
        
    }
}

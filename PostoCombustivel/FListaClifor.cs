using FormBusca;
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
    public partial class TFListaClifor : Form
    {
        public bool St_produtounicio { get; set; } = false;
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor> lClifor { get; set; }

        public TFListaClifor()
        {
            InitializeComponent();
        }

        private void TFListaClifor_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            cbTodos.Checked = false;
            bsClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(cd_clifo.Text,
                                                                                                 string.Empty,
                                                                                                 NM_Fantasia.Text,
                                                                                                 NR_CGC.Text,
                                                                                                 NR_CPF.Text,
                                                                                                 string.Empty,
                                                                                                 ID_CategoriaClifor.Text,
                                                                                                 Cd_CondFiscal_Clifor.Text,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 false,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 "'A'",
                                                                                                 0,
                                                                                                 null);

            (bsClifor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).ForEach(p => p.St_processar = false);

            cbTodos.Visible = !St_produtounicio;
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifo.Text.Trim() + "' ",
                                          new Componentes.EditDefault[] { cd_clifo },
                                          new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifo }, string.Empty);
        }

        private void ID_CategoriaClifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + ID_CategoriaClifor.Text.Trim() + "'",
              new Componentes.EditDefault[] { ID_CategoriaClifor },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void BB_CategoriaClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CategoriaClifor|Categoria Clifor|200;a.ID_CategoriaClifor|Cód. Categoria Clifor|100",
                new Componentes.EditDefault[] { ID_CategoriaClifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void Cd_CondFiscal_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondFiscal_Clifor|=|'" + Cd_CondFiscal_Clifor.Text.Trim() + "'"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void bb_FiscalClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_CondFiscal|Descrição|200;CD_CondFiscal_Clifor|Cód. Fiscal|100"
              , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor },
              new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsClifor.Count > 0)
            {
                (bsClifor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).ForEach(p => p.St_processar = cbTodos.Checked);
                bsClifor.ResetBindings(true);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (bsClifor.Count > 0)
            {
                lClifor = (bsClifor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).FindAll(p => p.St_processar.Equals(true));
                this.DialogResult = DialogResult.OK;
            }
        }

        private void gClifor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (St_produtounicio && !(bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_processar)
                {
                    (bsClifor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).ForEach(p => p.St_processar = false);
                    bsClifor.ResetBindings(true);
                }
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_processar =
                    !(bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_processar;
                bsClifor.ResetCurrentItem();
            }
        }
    }
}

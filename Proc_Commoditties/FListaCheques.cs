using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFListaCheques : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Tp_mov
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lCheque
        {
            get
            {
                if (bsCheque.Count > 0)
                    return (bsCheque.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaCheques()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsCheque.DataSource = CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca(cd_empresa.Text,
                                                                                      0, 
                                                                                      CD_Banco.Text,
                                                                                      NR_Cheque.Text,
                                                                                      string.Empty,
                                                                                      TP_Titulo.NM_Valor,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      DT_Inic.Text,
                                                                                      DT_Final.Text,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      NM_Clifor.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      false,
                                                                                      false,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
            tot_cheque.Value = (bsCheque.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Sum(p => p.Vl_titulo);
        }   

        private void TFListaCheques_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                cd_empresa.Text = Cd_empresa;
                cd_empresa.Enabled = false;
                BB_Empresa.Enabled = false;
            }
            if (Tp_mov.Trim().ToUpper().Equals("P") || Tp_mov.Trim().ToUpper().Equals("R"))
            {
                RB_TpTitulo_Emitidos.Checked = Tp_mov.Trim().ToUpper().Equals("P");
                RB_TpTitulo_Recebidos.Checked = Tp_mov.Trim().ToUpper().Equals("R");
                RB_TpTitulo_Recebidos.Enabled = false;
                RB_TpTitulo_Emitidos.Enabled = false;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaCheques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("ds_banco|Descrição|150;CD_banco|Código|80|nr_agencia|Agencia|80", 
                                            new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void CD_Banco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("CD_banco|=|'" + CD_Banco.Text + "'", 
                                                new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { NM_Clifor }, String.Empty); 
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void gcheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCheque.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_processar =
                    !(bsCheque.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_processar;
                bsCheque.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsCheque.Count > 0)
            {
                (bsCheque.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).ForEach(p => p.St_processar = cbTodos.Checked);
                bsCheque.ResetBindings(true);
            }
        }
    }
}

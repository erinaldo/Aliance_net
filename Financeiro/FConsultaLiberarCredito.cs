using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFConsultaLiberarCredito : Form
    {
        public TFConsultaLiberarCredito()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_solicitacao.Clear();
            CD_Empresa.Clear();
            cd_clifor.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            vl_ini.Value = vl_ini.Minimum;
            vl_fin.Value = vl_fin.Minimum;
        }

        private void afterBusca()
        {
            bsLiberarCredito.DataSource = CamadaNegocio.Financeiro.Duplicata.TCN_LiberarCredito.Buscar(id_solicitacao.Text,
                                                                                                       CD_Empresa.Text,
                                                                                                       cd_clifor.Text,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       rbSolicitacao.Checked ? "S" : "L",
                                                                                                       DT_Inicial.Text,
                                                                                                       DT_Final.Text,
                                                                                                       vl_ini.Value,
                                                                                                       vl_fin.Value,
                                                                                                       null);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void TFConsultaLiberarCredito_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFConsultaLiberarCredito_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

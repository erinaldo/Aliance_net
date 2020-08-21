using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFVendedorGrupoProd : Form
    {
        public string pCd_vendedor
        { get; set;  }

        private CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd rvend;
        public CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd rVend
        {
            get
            {
                if (bsVendGrupoProd.Current != null)
                    return bsVendGrupoProd.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd;
                else
                    return null;
            }
            set { rvend = value; }
        }
        public TFVendedorGrupoProd()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pVendGrupoProd.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFVendedorGrupoProd_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pVendGrupoProd.set_FormatZero();
            if (rvend != null)
            {
                bsVendGrupoProd.DataSource = new CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_GrupoProd() { rvend };
                CD_Grupo.Enabled = false;
                BB_GrupoProduto.Enabled = false;
                pc_comissao.Focus();
            }
            else
            {
                bsVendGrupoProd.AddNew();
                (bsVendGrupoProd.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd).Cd_vendedor = pCd_vendedor;
            }
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void TFVendedorGrupoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFRotaFrete : Form
    {
        public CamadaDados.Frota.TRegistro_RotaFrete rRotaFrete
        { get { return bsRotaFrete.Current as CamadaDados.Frota.TRegistro_RotaFrete; } }
        public TFRotaFrete()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("CANCELADO", "C"));

            St_registro.DataSource = cbx;
            St_registro.ValueMember = "Value";
            St_registro.DisplayMember = "Display";
        }

        private void TFRotaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pRota.set_FormatZero();
            bsRotaFrete.AddNew();
        }

        public void afterGrava()
        {
            if (pRota.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void cd_cidadeOrigem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadeOrigem.Text.Trim() + "';" +
                                "isnull(a.st_cidade, 'N')|=|'S';" +
                                 "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadeOrigem, ds_cidadeOrigem },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_Origem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadeOrigem, ds_cidadeOrigem },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
               string.Empty);
        }

        private void Cd_cidadeDestino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + Cd_cidadeDestino.Text.Trim() + "';" +
                                "isnull(a.st_cidade, 'N')|=|'S';" +
                                 "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_cidadeDestino, ds_cidadeDestino },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_Destino_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                             "a.cd_cidade|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_cidadeDestino, ds_cidadeDestino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
               string.Empty);
        }

        private void cd_unidFrete_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidFrete.Text.Trim() + "';" +
                                "isnull(a.st_unidade, 'N')|=|'S';" +
                                 "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidFrete, ds_unidFrete },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void bb_unidFrete_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|200;" +
                             "a.cd_unidade|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidFrete, ds_unidFrete },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
               string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

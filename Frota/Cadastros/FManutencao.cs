using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFManutencao : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo rmanutencao;
        public CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo rManutencao
        {
            get
            {
                if (bsManutencao.Count > 0)
                    return bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo;
                else
                    return null;
            }
            set
            { rmanutencao = value; }
        }
        public TFManutencao()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PROGRAMADA", "P"));
            cbx.Add(new Utils.TDataCombo("REALIZADA", "R"));

            st_manutencao.DataSource = cbx;
            st_manutencao.DisplayMember = "Display";
            st_manutencao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pManutencao.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFManutencao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pManutencao.set_FormatZero();
            if (rmanutencao != null)
            {
                bsManutencao.DataSource = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo() { rmanutencao };
            }
            else
            {
                bsManutencao.AddNew();
            }
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|'" + id_despesa.Text.Trim() + "';";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                new CamadaDados.Frota.Cadastros.TCD_Despesa());
                            
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                new CamadaDados.Frota.Cadastros.TCD_Despesa(), string.Empty);
        }
        
        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void bb_Responsavel_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Responsavel|200;" +
                               "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                string.Empty);
        }

        private void cd_cliforResponsavel_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforResponsavel.Text.Trim() + "';" +
                               "isnull(a.st_clifor, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel},
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_Oficina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Oficina|200;" +
                               "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                string.Empty);
        }

        private void cd_cliforOficina_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforOficina.Text.Trim() + "';" +
                               "isnull(a.st_clifor, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFManutencao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

    }
}

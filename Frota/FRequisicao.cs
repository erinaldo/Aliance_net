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
    public partial class TFRequisicao : Form
    {
        private CamadaDados.Frota.TRegistro_AbastVeiculo rabast;
        public CamadaDados.Frota.TRegistro_AbastVeiculo rAbast
        {
            get
            {
                if (bsAbastecimento.Current != null)
                    return bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                else
                    return null;
            }
            set { rabast = value; }
        }

        public CamadaDados.Frota.TRegistro_Viagem rViagem
        {get;set;}

        public TFRequisicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFRequisicao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rabast != null)
                bsAbastecimento.DataSource = new CamadaDados.Frota.TList_AbastVeiculo() { rabast };
            else
            {
                bsAbastecimento.AddNew();
                if (rViagem != null)
                {
                    cd_empresa.Text = rViagem.Cd_empresa;
                    cd_empresa_Leave(this, new EventArgs());
                    id_viagem.Text = rViagem.Id_viagemstr;
                    id_viagem_Leave(this, new EventArgs());
                    cd_empresa.Enabled = false;
                    bb_empresa.Enabled = false;
                    id_viagem.Enabled = false;
                    bb_viagem.Enabled = false;
                    bsAbastecimento.ResetCurrentItem();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null);
                if (lCfg.Count > 0)
                {
                    cd_combustivel.Text = lCfg[0].Cd_combustivel;
                    ds_combustivel.Text = lCfg[0].Ds_combustivel;
                    id_despesa.Text = lCfg[0].Id_despesacombustivelstr;
                    ds_despesa.Text = lCfg[0].Ds_despesacombustivel;
                }
                else
                {
                    MessageBox.Show("Não existe combustivel configurado para a empresa " + cd_empresa.Text.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresa.Clear();
                    cd_empresa.Focus();
                    return;
                }
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null);
                if (lCfg.Count > 0)
                {
                    cd_combustivel.Text = lCfg[0].Cd_combustivel;
                    ds_combustivel.Text = lCfg[0].Ds_combustivel;
                    id_despesa.Text = lCfg[0].Id_despesacombustivelstr;
                    ds_despesa.Text = lCfg[0].Ds_despesacombustivel;
                }
                else
                {
                    MessageBox.Show("Não existe combustivel configurado para a empresa " + cd_empresa.Text.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresa.Clear();
                    cd_empresa.Focus();
                    return;
                }
            }
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Descrição Veiculo|200;" +
                              "a.placa|Placa|80;" +
                              "a.id_veiculo|Codigo|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Descrição Viagem|200;" +
                              "a.id_viagem|Codigo|80;" +
                              "c.ds_veiculo|Veiculo|150;" +
                              "c.placa|Placa|80;" +
                              "a.id_veiculo|Id. Veiculo|80";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.TCD_Viagem(), vParam);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|" + id_viagem.Text + ";" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.TCD_Viagem());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Descrição Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void id_viagem_TextChanged(object sender, EventArgs e)
        {
            id_veiculo.Enabled = string.IsNullOrEmpty(id_viagem.Text);
            bb_veiculo.Enabled = string.IsNullOrEmpty(id_viagem.Text);
        }

        private void TFRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

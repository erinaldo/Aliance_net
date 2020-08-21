using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Frota
{
    public partial class TFOutrasReceitas : Form
    {
        public decimal vl_docto = decimal.Zero;
                       
        public string pCd_motorista
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pId_Veiculo
        { get; set; }
        private CamadaDados.Frota.TRegistro_OutrasReceitas rreceita;
        public CamadaDados.Frota.TRegistro_OutrasReceitas rReceita
        {
            get
            {
                if (bsReceita.Current != null)
                    return bsReceita.Current as CamadaDados.Frota.TRegistro_OutrasReceitas;
                else
                    return null;
            }
            set { rreceita = value; }
        }
        public TFOutrasReceitas()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(dt_receita.Text) || dt_receita.Text.Trim().Equals("/  /"))
                {
                    MessageBox.Show("Obrigatório informar Dt.Receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (vl_receita.Value == decimal.Zero)
                {
                    MessageBox.Show("Obrigatório informar Vl.Receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rReceita.Vl_receita >= rReceita.Vl_adtoViagem)
                {
                    vl_docto = rReceita.Vl_receita - rReceita.Vl_adtoViagem;
                }
                else
                {
                    MessageBox.Show("Valor da receita deve ser maior que do adiantamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFOutrasReceitas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rreceita != null)
            {
                bsReceita.DataSource = new CamadaDados.Frota.TList_OutrasReceitas() { rreceita };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                cd_motorista.Enabled = false;
                bb_motorista.Enabled = false;
                id_veiculo.Enabled = false;
                bb_veiculo.Enabled = false;
                dt_receita.Enabled = false;
                vl_receita.Enabled = false;
            }
            else
            {
                bsReceita.AddNew();
                CD_Empresa.Text = pCd_empresa;
                cd_motorista.Text = pCd_motorista;
                id_veiculo.Text = pId_Veiculo;
                CD_Empresa.Enabled = string.IsNullOrEmpty(CD_Empresa.Text);
                BB_Empresa.Enabled = string.IsNullOrEmpty(CD_Empresa.Text);
                cd_motorista.Enabled = string.IsNullOrEmpty(cd_motorista.Text);
                bb_motorista.Enabled = string.IsNullOrEmpty(cd_motorista.Text);
                id_veiculo.Enabled = string.IsNullOrEmpty(id_veiculo.Text);
                bb_veiculo.Enabled = string.IsNullOrEmpty(id_veiculo.Text);
                if (!CD_Empresa.Enabled)
                    CD_Clifor.Focus();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFOutrasReceitas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_motorista, ds_motorista },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (linha != null)
            {
                id_veiculo.Text = linha["id_veiculo"].ToString();
                ds_veiculo.Text = linha["ds_veiculo"].ToString();
            }
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                             "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, ds_motorista }, vParam);
            if (linha != null)
            {
                id_veiculo.Text = linha["id_veiculo"].ToString();
                ds_veiculo.Text = linha["ds_veiculo"].ToString();
            }
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}

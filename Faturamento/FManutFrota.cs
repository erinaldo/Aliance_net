using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFManutFrota : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo _manutencao;
            
        public CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo Manutencao
        {
            get
            {
                if (bsManutencao.Current != null)
                    return bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo;
                else return null;
            }
            set { _manutencao = value; }
        }


        public TFManutFrota()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(id_veiculo.Text))
            {
                MessageBox.Show("Obrigatório informar veiculo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_veiculo.Focus();
                return;
            }
            if(string.IsNullOrEmpty(id_despesa.Text))
            {
                MessageBox.Show("Obrigatório informar despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_despesa.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }


        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
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

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'MI'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                 new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|'" + id_despesa.Text.Trim() + "';" +
                            "a.tp_despesa|=|'MI'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                 new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_Responsavel_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Responsavel|200;" +
                               "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_funcionarios, 'N')|=|'S';" +
                             "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
        }

        private void bbAddResponsavel_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cliforResponsavel.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforResponsavel.Text = fClifor.rClifor.Nm_clifor;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cd_cliforResponsavel_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforResponsavel.Text.Trim() + "';" +
                               "isnull(a.st_funcionarios, 'N')|=|'S';" +
                               "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFManutFrota_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsManutencao.AddNew();
            dt_realizada.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
        }

        private void TFManutFrota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}

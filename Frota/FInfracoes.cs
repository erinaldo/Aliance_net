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
    public partial class TFInfracoes : Form
    {
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vId_veiculo = string.Empty;
        public string vDs_veiculo = string.Empty;
        private CamadaDados.Frota.Cadastros.TRegistro_Infracoes rinfracoes;
        public CamadaDados.Frota.Cadastros.TRegistro_Infracoes rInfracoes
        {
            get
            {
                if (bsInfracoes.Count > 0)
                    return bsInfracoes.Current as CamadaDados.Frota.Cadastros.TRegistro_Infracoes;
                else
                    return null;
            }
            set
            { rinfracoes = value; }
        }
        public TFInfracoes()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("LEVE", "L"));
            cbx.Add(new Utils.TDataCombo("MEDIA", "M"));
            cbx.Add(new Utils.TDataCombo("GRAVE", "G"));
            cbx.Add(new Utils.TDataCombo("GRAVISSIMA", "V"));

            tp_gravidade.DataSource = cbx;
            tp_gravidade.DisplayMember = "Display";
            tp_gravidade.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pInfracoes.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFInfracoes_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pInfracoes.set_FormatZero();
            if (rinfracoes != null)
            {
                bsInfracoes.DataSource = new CamadaDados.Frota.Cadastros.TList_Infracoes() { rinfracoes };
                id_veiculo.Enabled = false;
                bb_veiculo.Enabled = false;
                cd_empresa.Enabled = !rinfracoes.Nr_lancto.HasValue;
                bb_empresa.Enabled = !rinfracoes.Nr_lancto.HasValue;
                cd_infracao.Enabled = !rinfracoes.Nr_lancto.HasValue;
                dt_infracao.Enabled = !rinfracoes.Nr_lancto.HasValue;
                vl_infracao.Enabled = !rinfracoes.Nr_lancto.HasValue;

            }
            else
            {
                bsInfracoes.AddNew();
                cd_empresa.Text = vCd_empresa;
                nm_empresa.Text = vNm_empresa;
                id_veiculo.Text = vId_veiculo;
                ds_veiculo.Text = vDs_veiculo;
            }
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

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|'" + id_viagem.Text.Trim() + "';" +
                               "isnull(a.st_viagem, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(id_veiculo.Text))
                vParam += ";a.id_veiculo|=|" + id_veiculo.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem, ds_viagem, cd_motorista, ds_motorista, id_veiculo, ds_veiculo },
                                            new CamadaDados.Frota.TCD_Viagem());
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Viagem|200;" +
                              "a.id_viagem|Codigo|80;" +
                              "a.cd_motorista|Cd. Motorista|80;" +
                              "d.nm_clifor|Nome Motorista|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "c.ds_veiculo|Veiculo|200";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(id_veiculo.Text))
                vParam = "a.id_veiculo|=|" + id_veiculo.Text;
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem, ds_viagem, cd_motorista, ds_motorista, id_veiculo, ds_veiculo },
                new CamadaDados.Frota.TCD_Viagem(),
               vParam);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(id_viagem.Text))
                vParam += ";|exists|(select 1 from tb_frt_viagem x " +
                          "         where x.cd_motorista = a.cd_clifor " +
                          "         and x.id_viagem = " + id_viagem.Text + ")";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_motorista, ds_motorista },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (linha != null)
            {
                id_veiculo.Text = linha["id_veiculo"].ToString();
                id_veiculo_Leave(this, new EventArgs());
            }
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(id_viagem.Text))
                vParam += ";|exists|(select 1 from tb_frt_viagem x " +
                          "         where x.cd_motorista = a.cd_clifor " +
                          "         and x.id_viagem = " + id_viagem.Text + ")";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, ds_motorista }, vParam);
            if (linha != null)
            {
                id_veiculo.Text = linha["id_veiculo"].ToString();
                id_veiculo_Leave(this, new EventArgs());
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

        private void TFInfracoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            if (!string.IsNullOrEmpty(id_viagem.Text))
                vParam += ";|exists|(select 1 from tb_frt_viagem x " +
                          "         where x.id_veiculo = a.id_veiculo " +
                          "         and x.id_viagem = " + id_viagem.Text + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            if (!string.IsNullOrEmpty(id_viagem.Text))
                vParam += ";|exists|(select 1 from tb_frt_viagem x " +
                          "         where x.id_veiculo = a.id_veiculo " +
                          "         and x.id_viagem = " + id_viagem.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Id. Despesa|80";
            string vParam = "a.tp_despesa|=|'IF'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                        new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'IF'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                        new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bbAddDespesa_Click(object sender, EventArgs e)
        {
            Utils.InputBox ibp = new Utils.InputBox();
            ibp.Text = "Descrição Despesa";
            string despesa = ibp.ShowDialog();
            if (!string.IsNullOrEmpty(despesa))
                try
                {
                    CamadaDados.Frota.Cadastros.TRegistro_Despesa rDesp = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
                    rDesp.Ds_despesa = despesa;
                    rDesp.Tp_despesa = "IF";
                    CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(rDesp, null);
                    id_despesa.Text = rDesp.Id_despesastr;
                    ds_despesa.Text = rDesp.Ds_despesa;
                    cd_infracao.Focus();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else MessageBox.Show("Obrigatório informar descrição despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

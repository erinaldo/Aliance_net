using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Commoditties
{
    public partial class TFCustoHeadge : Form
    {
        private CamadaDados.Graos.TRegistro_CadContrato_Headge rheadge;
        public CamadaDados.Graos.TRegistro_CadContrato_Headge rHeadge
        {
            get
            {
                if (bsHeadge.Current != null)
                    return bsHeadge.Current as CamadaDados.Graos.TRegistro_CadContrato_Headge;
                else
                    return null;
            }
            set
            {
                rheadge = value;
            }
        }

        public TFCustoHeadge()
        {
            InitializeComponent();
            rheadge = null;
            ArrayList cbxTPValor = new ArrayList();
            cbxTPValor.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbxTPValor.Add(new Utils.TDataCombo("VALOR UNITÁRIO", "U"));
            cbxTPValor.Add(new Utils.TDataCombo("VALOR FIXO", "L"));
            Tp_Valor.DataSource = cbxTPValor;
            Tp_Valor.DisplayMember = "Display";
            Tp_Valor.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCustoHeadge_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            pDadosClifor.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (rheadge != null)
            {
                bsHeadge.DataSource = new CamadaDados.Graos.TList_CadContrato_Headge() { rheadge };
                Id_Headge.Enabled = false;
                bb_Headge.Enabled = false;
                bsHeadge.ResetCurrentItem();
            }
            else
                bsHeadge.AddNew();
        }

        private void bb_Headge_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Headge|Descrição Headge|250;a.ID_Headge|Cód. Headge|100",
                                       new Componentes.EditDefault[] { Id_Headge, DS_Headge },
                                       new CamadaDados.Graos.TCD_CadHeadge(), string.Empty);
            if (Id_Headge.Text != "")
            {
                Tp_Valor.SelectedIndex = 0;
                Tp_Valor_SelectedIndexChanged(this, e);
            }
            else
            {
                Tp_Valor.SelectedIndex = -1;
                Vl_Headge.Value = 0;
                Pc_Headge.Value = 0;
            }
        }

        private void Id_Headge_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.ID_Headge|=|" + Id_Headge.Text,
                                        new Componentes.EditDefault[] { Id_Headge, DS_Headge },
                                        new CamadaDados.Graos.TCD_CadHeadge());

            if (linha != null)
            {
                Tp_Valor.SelectedIndex = 0;
                Tp_Valor_SelectedIndexChanged(this, e);
            }
            else
            {
                Tp_Valor.SelectedIndex = -1;
                Vl_Headge.Value = 0;
                Pc_Headge.Value = 0;
            }
        }

        private void Tp_Valor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tp_Valor.SelectedValue != null)
            {
                if (Tp_Valor.SelectedValue.ToString().Equals("P"))
                {
                    CD_Unidade.Enabled = false;
                    CD_Unidade.Text = "";
                    SG_Unid.Text = "";
                    DS_Unidade.Text = "";
                    BB_Unid.Enabled = false;
                    Vl_Headge.Enabled = false;
                    Vl_Headge.Value = 0;
                    Pc_Headge.Enabled = true;
                    pDadosClifor.HabilitarControls(false, Utils.TTpModo.tm_Edit);
                }
                else if (Tp_Valor.SelectedValue.ToString().Equals("U"))
                {
                    CD_Unidade.Enabled = true;
                    BB_Unid.Enabled = true;
                    Vl_Headge.Enabled = true;
                    Pc_Headge.Enabled = false;
                    Pc_Headge.Value = 0;
                    pDadosClifor.HabilitarControls(false, Utils.TTpModo.tm_Edit);
                }
                else
                {
                    CD_Unidade.Enabled = false;
                    BB_Unid.Enabled = false;
                    CD_Unidade.Text = "";
                    SG_Unid.Text = "";
                    DS_Unidade.Text = "";
                    Vl_Headge.Enabled = true;
                    Pc_Headge.Enabled = false;
                    Pc_Headge.Value = 0;
                    pDadosClifor.HabilitarControls(true, Utils.TTpModo.tm_Edit);
                }
            }
        }

        private void BB_Unid_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Unidade|Descrição Unidade|250;a.CD_Unidade|Cód. Unidade|100;a.Sigla_Unidade|Sigla|100",
                                       new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_Unid }, 
                                       new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), null);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Unidade|=|'" + CD_Unidade.Text + "'",
                                        new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_Unid }, 
                                        new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Clifor_Headge_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                    "tp_pessoa|Tipo Pessoa|80;" +
                    "nr_cgc|C.N.P.J|80;" +
                    "nr_cpf|C.P.F|80;" +
                    "nr_rg|R.G|80;" +
                    "nm_razaosocial|Razão Social|100;" +
                    "nm_fantasia|Fantasia|100;" +
                    "EMAILPF|E-Mail P.F|100;" +
                    "EMAILPJ|E-Mail P.J|100;" +
                    "a.cd_transportador|Cd. Tranportadora|80;" +
                    "transp.nm_clifor|Transportadora|200;" +
                    "a.cd_endereco_transp|Cd. Transportadora|80;" +
                    "endTransp.ds_endereco|Endereco Transportadora|200",
                    new Componentes.EditDefault[] { CD_Clifor_Headge, NM_Clifor_Headge },
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), null);
        }

        private void CD_Clifor_Headge_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Headge.Text + "'",
                                    new Componentes.EditDefault[] { CD_Clifor_Headge, NM_Clifor_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Endereco_Headge_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80",
                                   new Componentes.EditDefault[] { CD_Endereco_Headge, DS_Endereco_Headge },
                                   new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor_Headge.Text + "'");
        }

        private void CD_Endereco_Headge_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco_Headge.Text + "';a.cd_clifor|=|'" + CD_Clifor_Headge.Text + "'",
                                    new Componentes.EditDefault[] { CD_Endereco_Headge, DS_Endereco_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Finan_Headge_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_TpDuplicata|Tipo Duplicata|350;" +
                                  "a.TP_Duplicata|TP. Duplicata|100;" +
                                  "a.TP_Mov|Tipo Movimento|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Tp_Finan_Headge, DS_Finan_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), string.Empty);
        }

        private void Tp_Finan_Headge_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Duplicata|=|'" + Tp_Finan_Headge.Text + "'";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Tp_Finan_Headge, DS_Finan_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void BB_CondPgto_Headge_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondPgto_Headge, DS_CondPgto_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void CD_CondPgto_Headge_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CondPgto|=|'" + CD_CondPgto_Headge.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas,
                                    new Componentes.EditDefault[] { CD_CondPgto_Headge, DS_CondPgto_Headge },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCustoHeadge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

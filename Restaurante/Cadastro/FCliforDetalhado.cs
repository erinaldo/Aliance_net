using System;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Restaurante.Cadastro;
using CamadaDados.Financeiro.Cadastros;
using Componentes;

namespace Restaurante.Cadastro
{
    public partial class TFCliforDetalhado : Form
    {
        private TRegistro_Clifor _Clifor = null;
        public TRegistro_Clifor rClifor
        {
            get
            {
                return bsClifor.Current as TRegistro_Clifor;
            }
            set
            {
                _Clifor = value;
            }
        }
        private TList_CFG lcfg = new TList_CFG();

        public TFCliforDetalhado()
        {
            InitializeComponent();
        }

        private void afterGravar()
        {
            if (pnDadosClifor.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty(edtCartaoFidelidade.Text.Trim()))
                {
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.ident_frentista", "'" + edtCartaoFidelidade.Text + "'");
                    Estruturas.CriarParametro(ref tpBuscas, "a.st_registro", "'A'");
                    TList_CadClifor _CadClifors = new TCD_CadClifor().Select(tpBuscas, 1, string.Empty);
                    if (_CadClifors.Count > 0)
                    {
                        edtCartaoFidelidade.Focus();
                        MessageBox.Show("Cartão fidelidade informado já é cadastrado!", "mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                (bsClifor.Current as TRegistro_Clifor).Tp_pessoa = "F";
                DialogResult = DialogResult.OK;
            }
        }

        private void afterLimpar()
        {
            bsClifor.Clear();
            bsClifor.AddNew();
        }

        private void afterCancelar()
        {
            if (MessageBox.Show("Deseja Cancelar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void edtDs_cidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && edtDs_cidade.Text.Trim().Length.Equals(0))
            {
                EditDefault cd_cidade = new EditDefault();
                cd_cidade.NM_Campo = "CD_CIDADE";
                cd_cidade.NM_CampoBusca = "CD_CIDADE";
                cd_cidade.NM_Param = "@P_CD_CIDADE";

                string vColunas = "DS_Cidade|Nome Cidade|250;" +
                                  "CD_Cidade|Cód. Cidade|100;" +
                                  "Distrito|Distrito|200;" +
                                  "a.UF|Sigla|60;" +
                                  "b.DS_UF|Estado|100";
                UtilPesquisa.BTN_BUSCA(vColunas,
                                       new Componentes.EditDefault[] { cd_cidade, edtDs_cidade },
                                       new TCD_CadCidade(),
                                       string.Empty);
                (bsClifor.Current as TRegistro_Clifor).cd_cidade = cd_cidade.Text;
            }
        }

        private void FCliforDetalhado_Load(object sender, EventArgs e)
        {
            //Buscar configuração Restaurante
            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Não existe CFG. Restaurante cadastrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (_Clifor != null)
                bsClifor.Add(_Clifor);
            else
            {
                bsClifor.AddNew();
                edtFone.Focus();
            }

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("", ""));
            cbx.Add(new TDataCombo("MASCULINO", "M"));
            cbx.Add(new TDataCombo("FEMININO", "N"));
            cbGenero.DataSource = cbx;
            cbGenero.DisplayMember = "Display";
            cbGenero.ValueMember = "Value";
            cbGenero.SelectedIndex = 0;


            bsClifor.ResetBindings(true);
        }

        private void edtCep_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtCep.Text.SoNumero()) && bsClifor.Current != null)
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(edtCep.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            (bsClifor.Current as TRegistro_Clifor).endereco = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                        {
                            (bsClifor.Current as TRegistro_Clifor).cd_cidade = valida.ibge;
                            (bsClifor.Current as TRegistro_Clifor).ds_cidade = new TCD_CadCidade().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_cidade",
                                        vOperador = "=",
                                        vVL_Busca = valida.ibge
                                    }
                                }, "ds_cidade").ToString();
                        }
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            (bsClifor.Current as TRegistro_Clifor).bairro = valida.bairro;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void FCliforDetalhado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                afterLimpar();
            else if (e.KeyCode.Equals(Keys.F4))
                afterGravar();
            else if (e.KeyCode.Equals(Keys.F6) || e.KeyCode.Equals(Keys.Escape))
                afterCancelar();
        }

        private void edtFone_TextChanged(object sender, EventArgs e)
        {
            if (edtFone.Text.SoNumero().Length.Equals(10))
            {
                edtFone.Text = "(" + edtFone.Text.SoNumero().Substring(0, 2) + ")" + edtFone.Text.SoNumero().Substring(2, 4) + "-" + edtFone.Text.SoNumero().Substring(6, 4);
                edtFone.SelectionStart = edtFone.Text.Length;
            }
            else if (edtFone.Text.SoNumero().Length.Equals(11))
                if (edtFone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    edtFone.Text = "(" + edtFone.Text.SoNumero().Substring(0, 3) + ")" + edtFone.Text.SoNumero().Substring(3, 4) + "-" + edtFone.Text.SoNumero().Substring(7, 4);
                    edtFone.SelectionStart = edtFone.Text.Length;
                }
                else
                {
                    edtFone.Text = "(" + edtFone.Text.SoNumero().Substring(0, 2) + ")" + edtFone.Text.SoNumero().Substring(2, 5) + "-" + edtFone.Text.SoNumero().Substring(7, 4);
                    edtFone.SelectionStart = edtFone.Text.Length;
                }
            else if (edtFone.Text.SoNumero().Length.Equals(12))
            {
                edtFone.Text = "(" + edtFone.Text.SoNumero().Substring(0, 3) + ")" + edtFone.Text.SoNumero().Substring(3, 5) + "-" + edtFone.Text.SoNumero().Substring(8, 4);
                edtFone.SelectionStart = edtFone.Text.Length;
            }
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void edtFone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtFone.Text.SoNumero()))
            {
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.celular", "'%" + edtFone.Text.SoNumero() + "%'", Operador: "like");
                Estruturas.CriarParametro(ref tpBuscas, "a.st_registro", "'A'");
                TList_Clifor _Clifors = new CamadaDados.Restaurante.Cadastro.TCD_Clifor().Select(tpBuscas, 1, string.Empty);

                if (_Clifors.Count > 0)
                {
                    bsClifor.DataSource = _Clifors;
                    bsClifor.ResetBindings(true);
                }
            }
        }

        private void lblGravar_Click(object sender, EventArgs e)
        {
            afterGravar();
        }

        private void lblLimpar_Click(object sender, EventArgs e)
        {
            afterLimpar();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            afterCancelar();
        }

        private void edtCep_TextChanged(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                edtDs_cidade.Text = "";
            }
        }

        private void event_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.FixedSingle;
            (sender as Label).Cursor = Cursors.Hand;
            (sender as Label).ForeColor = Color.Blue;
        }

        private void event_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.None;
            (sender as Label).Cursor = Cursors.Default;
            (sender as Label).ForeColor = Color.Green;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFCartaFrete : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public DateTime? Dt_vencimento
        { get; set; }

        public CamadaDados.PostoCombustivel.TRegistro_CartaFrete rCF
        { get { return bsCartaFrete.Current as CamadaDados.PostoCombustivel.TRegistro_CartaFrete; } }

        public TFCartaFrete()
        {
            InitializeComponent();
        }

        private bool ValidarCartaFrete()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_transportadora.Text)) &&
                (!string.IsNullOrEmpty(nr_cartafrete.Text)))
                if (new CamadaDados.PostoCombustivel.TCD_CartaFrete().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_transportadora",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_transportadora.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_cartafrete",
                            vOperador = "=",
                            vVL_Busca = "'" + nr_cartafrete.Text.Trim() + "'"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Carta frete ja existe para a transportadora.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_cartafrete.Clear();
                    nr_cartafrete.Focus();
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private string BuscarEndereco(string Cd_clifor)
        {
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_clifor.Trim() + "'"
                    }
                }, "a.cd_endereco");
            return obj == null ? string.Empty : obj.ToString();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (nr_cartafrete.Focused)
                    if (!this.ValidarCartaFrete())
                        return;
                if (string.IsNullOrEmpty(cd_transportadora.Text) &&
                    string.IsNullOrEmpty(cd_unidpagadora.Text))
                {
                    MessageBox.Show("Obrigatorio informar TRANSPORTADORA ou UNIDADE PAGADORA para gravar carta frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_transportadora.Focus();
                    return;
                }
                if ((!string.IsNullOrEmpty(cd_unidpagadora.Text)) &&
                    string.IsNullOrEmpty(cd_endunidpagadora.Text))
                {
                    MessageBox.Show("Obrigatorio informar endereço para unidade pagadora.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_endunidpagadora.Focus();
                    return;
                }
                if (dt_emissao.Data.Date > dt_vencimento.Data.Date)
                {
                    MessageBox.Show("Data de vencimento não pode ser menor que data de emissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Validar CNPJ/CPF do Cliente/Fornecedor
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_FIN_CLIFOR_VALIDO", Cd_empresa, null).Trim().ToUpper().Equals("S"))
                {
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(string.IsNullOrEmpty(cd_transportadora.Text) ? cd_unidpagadora.Text : cd_transportadora.Text, null);
                    if (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        Utils.CNPJ_Valido.nr_CNPJ = rClifor.Nr_cgc;
                        if (string.IsNullOrEmpty(Utils.CNPJ_Valido.nr_CNPJ))
                        {
                            MessageBox.Show("Não é permitido gravar CARTA FRETE para " + (string.IsNullOrEmpty(cd_transportadora.Text) ? "UNIDADE PAGADORA" : "TRANSPORTADORA") + " com CNPJ invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if(rClifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        Utils.CPF_Valido.nr_CPF = rClifor.Nr_cpf;
                        if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                        {
                            MessageBox.Show("Não é permitido gravar CARTA FRETE para " + (string.IsNullOrEmpty(cd_transportadora.Text) ? "UNIDADE PAGADORA" : "TRANSPORTADORA") + " com CPF invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscarUnidPag(string cd_transp)
        {
            if (!string.IsNullOrEmpty(cd_transp))
            {
                var UnidPag =
                new CamadaDados.PostoCombustivel.Cadastros.TCD_Trans_X_UnidPag().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_transportadora",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_transp.Trim() + "'"
                            }
                        }, 1, string.Empty, string.Empty);
                if (UnidPag.Count > decimal.Zero)
                {
                    cd_unidpagadora.Text = UnidPag[0].CD_UnidPagadora;
                    nm_unidpagadora.Text = UnidPag[0].NM_UnidPagadora;
                    cd_endunidpagadora.Text = BuscarEndereco(cd_unidpagadora.Text);
                    cd_endunidpagadora_Leave(this, new EventArgs());
                    nr_cartafrete.Focus();
                }
                else
                    cd_unidpagadora.Focus();
                
            }
        }

        private void TFCartaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsCartaFrete.AddNew();
            cd_empresa.Text = Cd_empresa;
            nm_empresa.Text = Nm_empresa;
            if (Dt_vencimento.HasValue)
            {
                dt_vencimento.Text = Dt_vencimento.Value.ToString("dd/MM/yyyy");
                dt_vencimento.Enabled = false;
            }
            cd_empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);
            bb_empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);

        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_transportadora, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(cd_unidpagadora.Text))
            {
                if (new CamadaDados.PostoCombustivel.Cadastros.TCD_Trans_X_UnidPag().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_unidpagadora",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_unidpagadora.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_pdc_transp_x_unidpag x " +
                              "             where x.cd_transportadora = a.cd_clifor " +
                              "             and x.cd_unidpagadora = '" + cd_unidpagadora.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora, nm_transportadora }, vParam);
            nm_transportadora.Enabled = string.IsNullOrEmpty(cd_transportadora.Text);
            cd_enderecotransp.Text = this.BuscarEndereco(cd_transportadora.Text);
            cd_enderecotransp_Leave(this, new EventArgs());
            this.BuscarUnidPag(cd_transportadora.Text);
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "isnull(a.st_transportadora, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(cd_unidpagadora.Text))
            {
                if (new CamadaDados.PostoCombustivel.Cadastros.TCD_Trans_X_UnidPag().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_unidpagadora",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_unidpagadora.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_pdc_transp_x_unidpag x " +
                              "             where x.cd_transportadora = a.cd_clifor " +
                              "             and x.cd_unidpagadora = '" + cd_unidpagadora.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            nm_transportadora.Enabled = string.IsNullOrEmpty(cd_transportadora.Text);
            cd_enderecotransp.Text = this.BuscarEndereco(cd_transportadora.Text);
            cd_enderecotransp_Leave(this, new EventArgs());
            this.BuscarUnidPag(cd_transportadora.Text);
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;"+
                              "a.cd_endereco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'");
        }

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_unidpagadora_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_transportadora.Text))
            {
                if (new CamadaDados.PostoCombustivel.Cadastros.TCD_Trans_X_UnidPag().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_transportadora",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_transportadora.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_pdc_transp_x_unidpag x " +
                              "             where x.cd_unidpagadora = a.cd_clifor " +
                              "             and x.cd_transportadora = '" + cd_transportadora.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_unidpagadora, nm_unidpagadora }, vParam);
            cd_endunidpagadora.Text = this.BuscarEndereco(cd_unidpagadora.Text);
            cd_endunidpagadora_Leave(this, new EventArgs());
        }

        private void cd_unidpagadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_unidpagadora.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_transportadora.Text))
            {
                if (new CamadaDados.PostoCombustivel.Cadastros.TCD_Trans_X_UnidPag().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_transportadora",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_transportadora.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_pdc_transp_x_unidpag x " +
                              "             where x.cd_unidpagadora = a.cd_clifor " +
                              "             and x.cd_transportadora = '" + cd_transportadora.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam,
                new Componentes.EditDefault[] { cd_unidpagadora, nm_unidpagadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            cd_endunidpagadora.Text = this.BuscarEndereco(cd_unidpagadora.Text);
            cd_endunidpagadora_Leave(this, new EventArgs());
        }

        private void bb_endunidpagadora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endunidpagadora, ds_endunidpagadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_unidpagadora.Text.Trim() + "'");
        }

        private void cd_endunidpagadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_unidpagadora.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endunidpagadora.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endunidpagadora, ds_endunidpagadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void nr_cartafrete_Leave(object sender, EventArgs e)
        {
            this.ValidarCartaFrete();
        }

        private void TFCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

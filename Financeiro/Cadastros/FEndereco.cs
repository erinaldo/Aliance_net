using System;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFEndereco : Form
    {
        public string Tp_pessoa { get; set; } = string.Empty;

        private TRegistro_CadEndereco rend;
        public TRegistro_CadEndereco rEnd
        {
            get
            {
                if (bsEndereco.Current != null)
                    return bsEndereco.Current as TRegistro_CadEndereco;
                else
                    return null;
            }
            set
            { rend = value; }
        }

        public TFEndereco()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pnl_Endereco.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFEndereco_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Endereco.set_FormatZero();
            if (rend != null)
                bsEndereco.DataSource = new TList_CadEndereco() { rend };
            else
                bsEndereco.AddNew();
            if (Tp_pessoa.Trim().ToUpper().Equals("E"))
            {
                //Buscar cidade
                TList_CadCidade lCidade =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Buscar("9999999",
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            1,
                                                                            null);
                if (lCidade.Count > 0)
                {
                    CD_Cidade.Text = lCidade[0].Cd_cidade;
                    Ds_Cidade.Text = lCidade[0].Ds_cidade;
                    UF.Text = lCidade[0].rUf.Uf;
                    CD_Cidade.Enabled = false;
                    BB_Cidade.Enabled = false;
                }
                else
                {
                    if (new TCD_CadUf().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_uf",
                                vOperador = "=",
                                vVL_Busca = "'99'"
                            }
                        }, "1") == null)
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.GravarUf(
                            new TRegistro_CadUf()
                            {
                                Cd_uf = "99",
                                Ds_uf = "EXTERIOR",
                                Uf = "EX"
                            }, null);
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Gravar(
                        new TRegistro_CadCidade()
                        {
                            Cd_cidade = "9999999",
                            Ds_cidade = "EXTERIOR",
                            Cd_uf = "99"
                        }, null);
                    CD_Cidade.Text = "9999999";
                    Ds_Cidade.Text = "EXTERIOR";
                    UF.Text = "EX";
                    CD_Cidade.Enabled = false;
                    BB_Cidade.Enabled = false;
                }
            }
            else
            {
                CD_PAIS.Text = "1058";
                NM_Pais.Text = "BRASIL";
            }
            Cep.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade(), string.Empty);
        }

        private void CD_Cidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_Cidade.Text + "'",
                    new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade());
        }

        private void BB_Pais_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (Tp_pessoa.Trim().ToUpper().Equals("E"))
                vParam = "cd_pais|<>|'1058'";
            UtilPesquisa.BTN_BUSCA("NM_Pais|Nome do País|200;CD_Pais|Cód. País|100",
                              new Componentes.EditDefault[] { CD_PAIS, NM_Pais }, new TCD_CadPais(), vParam);
        }

        private void CD_PAIS_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_pais|=|'" + CD_PAIS.Text.Trim() + "'";
            if (Tp_pessoa.Trim().ToUpper().Equals("E"))
                vParam += ";cd_pais|<>|'1058'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_PAIS, NM_Pais }, new TCD_CadPais());
        }

        private void TFEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void Insc_Estadual_Leave(object sender, EventArgs e)
        {
            Insc_Estadual.Text = Insc_Estadual.Text.SoNumero();
            if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
            {
                if (!string.IsNullOrEmpty(Insc_Estadual.Text.SoNumero()))
                {
                    if (UF.Text.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Obrigatório informar cidade para validar a inscrição estadual.", "Mensagem", MessageBoxButtons.OK);
                        CD_Cidade.Focus();
                        return;
                    }
                    try
                    {
                        if (CamadaNegocio.Diversos.TValidaInscEstadual.ValidaInscEstadual(Insc_Estadual.Text.Trim(), UF.Text.Trim()) == 1)
                        {
                            MessageBox.Show("Inscrição estadual incorreta para o estado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Insc_Estadual.Clear();
                            Insc_Estadual.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }

        private void Cep_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Cep.Text.SoNumero()))
                && (bsEndereco.Current != null))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(Cep.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            DS_Endereco.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            CD_Cidade.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            Bairro.Text = valida.bairro;
                        CD_Cidade_Leave(this, new EventArgs());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }

        private void bsEndereco_PositionChanged(object sender, EventArgs e)
        {
            if(bsEndereco.Current != null)
                cd_endereco.Text = (bsEndereco.Current as TRegistro_CadEndereco).Cd_endereco;
        }

        private void Insc_Estadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
               char.IsSymbol(e.KeyChar) || //Símbolos
               char.IsWhiteSpace(e.KeyChar) || //Espaço
               char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void Fone_comercial_TextChanged(object sender, EventArgs e)
        {
            if (Fone_comercial.Text.SoNumero().Length.Equals(10))
            {
                Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 2) + ")" + Fone_comercial.Text.SoNumero().Substring(2, 4) + "-" + Fone_comercial.Text.SoNumero().Substring(6, 4);
                Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
            }
            else if (Fone_comercial.Text.SoNumero().Length.Equals(11))
                if (Fone_comercial.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 3) + ")" + Fone_comercial.Text.SoNumero().Substring(3, 4) + "-" + Fone_comercial.Text.SoNumero().Substring(7, 4);
                    Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
                }
                else
                {
                    Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 2) + ")" + Fone_comercial.Text.SoNumero().Substring(2, 5) + "-" + Fone_comercial.Text.SoNumero().Substring(7, 4);
                    Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
                }
            else if (Fone_comercial.Text.SoNumero().Length.Equals(12))
            {
                Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 3) + ")" + Fone_comercial.Text.SoNumero().Substring(3, 5) + "-" + Fone_comercial.Text.SoNumero().Substring(8, 4);
                Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
            }
        }

        private void celular_TextChanged(object sender, EventArgs e)
        {
            if (celular.Text.SoNumero().Length.Equals(10))
            {
                celular.Text = "(" + celular.Text.SoNumero().Substring(0, 2) + ")" + celular.Text.SoNumero().Substring(2, 4) + "-" + celular.Text.SoNumero().Substring(6, 4);
                celular.SelectionStart = celular.Text.Length;
            }
            else if (celular.Text.SoNumero().Length.Equals(11))
                if (celular.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    celular.Text = "(" + celular.Text.SoNumero().Substring(0, 3) + ")" + celular.Text.SoNumero().Substring(3, 4) + "-" + celular.Text.SoNumero().Substring(7, 4);
                    celular.SelectionStart = celular.Text.Length;
                }
                else
                {
                    celular.Text = "(" + celular.Text.SoNumero().Substring(0, 2) + ")" + celular.Text.SoNumero().Substring(2, 5) + "-" + celular.Text.SoNumero().Substring(7, 4);
                    celular.SelectionStart = celular.Text.Length;
                }
            else if (celular.Text.SoNumero().Length.Equals(12))
            {
                celular.Text = "(" + celular.Text.SoNumero().Substring(0, 3) + ")" + celular.Text.SoNumero().Substring(3, 5) + "-" + celular.Text.SoNumero().Substring(8, 4);
                celular.SelectionStart = celular.Text.Length;
            }
        }
    }
}

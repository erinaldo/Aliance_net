using System;
using System.Windows.Forms;
using Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFCadVeiculo : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo rveiculo;
        public CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo rVeiculo
        {
            get
            {
                if (bsCadVeiculo.Count > 0)
                    return bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo;
                else
                    return null;
            }
            set
            { rveiculo = value; }
        }

        private bool St_alterar
        { get; set; }

        public TFCadVeiculo()
        {
            InitializeComponent();
            this.St_alterar = false;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("INATIVO", "I"));
            St_registro.DataSource = cbx;
            St_registro.ValueMember = "Value";
            St_registro.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new Utils.TDataCombo("ETANOL", "ET"));
            cbx1.Add(new Utils.TDataCombo("GASOLINA", "GC"));
            cbx1.Add(new Utils.TDataCombo("OLEO DIESEL", "OD"));
            cbx1.Add(new Utils.TDataCombo("FLEX-BICOMBUSTIVEL", "FL"));
            tp_combustivel.DataSource = cbx1;
            tp_combustivel.DisplayMember = "Display";
            tp_combustivel.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("NÃO APLICAVEL", "00"));
            cbx2.Add(new Utils.TDataCombo("ABERTA", "01"));
            cbx2.Add(new Utils.TDataCombo("FECHADA/BAU", "02"));
            cbx2.Add(new Utils.TDataCombo("GRANELERA", "03"));
            cbx2.Add(new Utils.TDataCombo("PORTA CONTAINER", "04"));
            cbx2.Add(new Utils.TDataCombo("SIDER", "05"));
            tp_carroceria.DataSource = cbx2;
            tp_carroceria.DisplayMember = "Display";
            tp_carroceria.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new Utils.TDataCombo("PRÓPRIO", "P"));
            cbx3.Add(new Utils.TDataCombo("TERCEIRO", "T"));
            tp_propriedade.DataSource = cbx3;
            tp_propriedade.DisplayMember = "Display";
            tp_propriedade.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("TAC-AGREGADO", "0"));
            cbx4.Add(new Utils.TDataCombo("TAC-INDEPENDENTE", "1"));
            cbx4.Add(new Utils.TDataCombo("OUTROS", "2"));
            tp_proprietario.DataSource = cbx4;
            tp_proprietario.DisplayMember = "Display";
            tp_proprietario.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (tp_propriedade.SelectedValue.ToString().Equals("T"))
                {
                    if (string.IsNullOrEmpty(cd_proprietario.Text))
                    {
                        MessageBox.Show("Obrigatório informar proprietario quando veiculo terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_proprietario.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(rntrc_prop.Text))
                    {
                        MessageBox.Show("Obrigatório informar RNTRC Proprietario quando veiculo terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rntrc_prop.Focus();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFCadVeiculo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rveiculo != null)
            {
                bsCadVeiculo.DataSource = new CamadaDados.Frota.Cadastros.TList_CadVeiculo() { rveiculo };
                this.St_alterar = true;
            }
            else
                bsCadVeiculo.AddNew();

            //Buscar Imagem
            object obj_foto = new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().BuscarEscalar(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_VEICULO",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Id_veiculo+ "'"
                            }
                        }, null);
            if (obj_foto != null )
            {
                try
                {
                    (bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Img = (byte[])obj_foto;
                    bsCadVeiculo.ResetCurrentItem();

                }catch {
                }
            }
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tpveiculo|=|'" + cd_tpveiculo.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tpveiculo, Ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpveiculo|Tipo Veiculo|200;" +
                              "a.cd_tpveiculo|Codigo|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tpveiculo, Ds_tpveiculo },
                                            new CamadaDados.Diversos.TCD_CadTpVeiculo(),
                                            vParam);
        }

        private void Cd_cidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + Cd_cidade.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";             
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_cidade, ds_cidade },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "b.uf|UF|60;" +
                             "a.cd_cidade|Codigo|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_cidade, ds_cidade },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
                                            vParam);
        }

        private void Id_veiculo_principal_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + Id_veiculo_principal.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_veiculo_principal, ds_veiculo_principal },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculoPrincipal_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                             "a.id_veiculo|Codigo|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_veiculo_principal, ds_veiculo_principal },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
                                            vParam);
        }

        private void id_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_marca|=|'" + id_marca.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_marca, ds_marca },
                                    new CamadaDados.Frota.Cadastros.TCD_CadMarcaVeiculo());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_marca|Marca|200;" +
                              "a.id_marca|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { id_marca, ds_marca },
                new CamadaDados.Frota.Cadastros.TCD_CadMarcaVeiculo(),
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

        private void TFCadVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void chassi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void placa_Leave(object sender, EventArgs e)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "REPLACE(a.placa, '-', '')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + placa.Text.Replace("-", string.Empty).Trim() + "'";
            if ((bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Id_veiculo.HasValue)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = (bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Id_veiculostr;
            }
            if (new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().BuscarEscalar(filtro, "1") != null)
            {
                MessageBox.Show("Já existe um veiculo cadastrado com esta placa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                placa.Focus();
            }
        }

        private void bb_proprietario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_proprietario, nm_proprietario }, string.Empty);
        }

        private void cd_proprietario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_proprietario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_proprietario, nm_proprietario },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_endproprietario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { cd_endproprietario, ds_endproprietario }, "a.cd_clifor|=|'" + cd_proprietario.Text.Trim() + "'");
        }

        private void cd_endproprietario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEndereco("a.cd_clifor|=|'" + cd_proprietario.Text.Trim() + "';a.cd_endereco|=|'" + cd_endproprietario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_endproprietario, ds_endproprietario });
        }

        private void bb_Capturar_Click(object sender, EventArgs e)
        {
            using (WebCamLibrary.TFVisualizarCaptura fImagem = new WebCamLibrary.TFVisualizarCaptura())
            {
                fImagem.Img = (bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Img;
                if (fImagem.ShowDialog() == DialogResult.OK)
                    if (fImagem.Img != null)
                        try
                        {
                            (bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).Img = fImagem.Img;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void bb_novoProprietario_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                cd_proprietario.Text = fClifor.rClifor.Cd_clifor;
                                nm_proprietario.Text = fClifor.rClifor.Nm_clifor;
                                cd_endproprietario_Leave(sender, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (TFClifor fClifor = new TFClifor())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                cd_proprietario.Text = fClifor.rClifor.Cd_clifor;
                                nm_proprietario.Text = fClifor.rClifor.Nm_clifor;
                                cd_endproprietario_Leave(sender, new EventArgs());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void placa_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}

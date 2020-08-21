using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFEvoluirOSOficina : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get; set; }

        public TFEvoluirOSOficina()
        {
            InitializeComponent();
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    CD_Endereco.Text = lEnd[0].Cd_endereco;
                    DS_Endereco.Text = lEnd[0].Ds_endereco;
                    DS_Cidade.Text = lEnd[0].DS_Cidade;
                    UF.Text = lEnd[0].UF;
                }
            }
        }
                
        private void TFEvoluirOSOficina_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            pOS.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsOrdemServico.DataSource = new CamadaDados.Servicos.TList_LanServico() { rOS };
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFEvoluirOSOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            //Buscar endereco
            this.BuscarEndereco();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            //Buscar endereco
            this.BuscarEndereco();
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
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        DS_Cidade.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        UF.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "UF|Estado|150";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void TFEvoluirOSOficina_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }

        private void placaveiculo_Leave(object sender, EventArgs e)
        {
            CamadaDados.Servicos.Cadastros.TList_VeiculoCliente
             placa = new CamadaDados.Servicos.Cadastros.TCD_VeiculoCliente().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.PlacaVeiculo",
                        vOperador = "=",
                        vVL_Busca = "'" + placaveiculo.Text.Trim() + "'"
                    }
                }, 1, string.Empty);
            if (placa.Count > 0)
            {
                placaveiculo.Text = placa[0].Placaveiculo;
                ds_veiculo.Text = placa[0].Ds_veiculo;
                ds_obsveiculo.Text = placa[0].Ds_observacao;
                if (placa.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_Clifor.Text))
                        if ((CD_Clifor.Text != placa[0].Cd_clifor) && (!string.IsNullOrEmpty(placa[0].Cd_clifor)))
                            if (MessageBox.Show("O Cliente da placa é diferente da cliente da OS! \r\nDeseja alterar o Cliente da OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                CD_Clifor.Text = placa[0].Cd_clifor;
                                NM_Clifor.Text = placa[0].Nm_clifor;
                                BuscarEndereco();
                            }
                    placaveiculo.Enabled = false;
                    ds_veiculo.Enabled = false;
                    ds_obsveiculo.Enabled = false;
                }
            }
        }

        private void bb_placa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.placaveiculo|Placa|80;" +
                              "a.ds_veiculo|Veiculo|200;" +
                              "a.ds_marca|Marca|200;" +
                              "a.ds_observacao|OBS|200";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaveiculo, ds_veiculo, ds_obsveiculo },
                new CamadaDados.Servicos.Cadastros.TCD_VeiculoCliente(),
               vParam);
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                    if ((CD_Clifor.Text != linha["cd_clifor"].ToString()) && (!string.IsNullOrEmpty(linha["cd_clifor"].ToString())))
                        if (MessageBox.Show("O Cliente da placa é diferente da cliente da OS! \r\nDeseja alterar o Cliente da OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            CD_Clifor.Text = linha["cd_clifor"].ToString();
                            NM_Clifor.Text = linha["nm_clifor"].ToString();
                            BuscarEndereco();
                        }
                placaveiculo.Enabled = false;
                ds_veiculo.Enabled = false;
                ds_obsveiculo.Enabled = false;
            }
        }

        private void bb_addveiculo_Click(object sender, EventArgs e)
        {
            placaveiculo.Enabled = true;
            placaveiculo.Clear();
            ds_veiculo.Enabled = true;
            ds_veiculo.Clear();
            ds_obsveiculo.Enabled = true;
            ds_obsveiculo.Clear();

            placaveiculo.Focus();
        }
    }
}

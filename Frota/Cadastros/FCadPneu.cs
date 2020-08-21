using CamadaDados.Diversos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Frota.Cadastros;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFCadPneu : Form
    {
        private TRegistro_LanPneu rpneu;
        public TRegistro_LanPneu rPneu
        {
            get
            {
                if (bsPneu.Current != null)
                    return bsPneu.Current as TRegistro_LanPneu;
                else
                    return null;
            }
            set { rpneu = value; }
        }
        public string pTitle
        { get; set; }
        public string pStatus
        { get; set; } = string.Empty;

        public TFCadPneu()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("NOVO", "0"));
            cbx.Add(new TDataCombo("USADO", "1"));
            cbx.Add(new TDataCombo("RECAPADO NOVO", "2"));
            cbx.Add(new TDataCombo("RECAPADO USADO", "3"));
            tp_estado.DataSource = cbx;
            tp_estado.ValueMember = "Value";
            tp_estado.DisplayMember = "Display";
        }

        private void saldoAlmoxarifado()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()) && !string.IsNullOrEmpty(id_almox.Text.Trim()) && !string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
                edt_saldodisponivel.Text = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Buscar(cbEmpresa.SelectedValue.ToString(), id_almox.Text.Trim(), cd_produto.Text.Trim(), true, null).Count.ToString();
        }

        private void gerarCbxDesenho()
        {
            try
            {
                cbxDesenho.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CadDesenhoPneu.Buscar(string.Empty, string.Empty, null);
                cbxDesenho.ValueMember = "Id_desenho";
                cbxDesenho.DisplayMember = "Ds_desenho";
            }
            catch { }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                //Validar existencia de num. Fogo
                if (pStatus.Equals("N"))
                {
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.nr_serie", "'" + Nr_serie.Text.Trim() + "'");
                    Estruturas.CriarParametro(ref tpBuscas, "isnull(a.ST_Registro, 'A')", "'D'", "<>");
                    if (new CamadaDados.Frota.Cadastros.TCD_LanPneu().BuscarEscalar(tpBuscas, "a.nr_serie") != null)
                    {
                        MessageBox.Show("Número de fogo informado já existe. Não será possível finalizar o cadastro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFPneu_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pTitle))
                Text = pTitle;
            if (pStatus.Equals("M"))
                cbGerarAlmoxarifado.Enabled = false;

            gerarCbxDesenho();
            if (rpneu != null)
            {
                bsPneu.DataSource = new TList_LanPneu() { rpneu };
                cbEmpresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                Nr_serie.Enabled = false;
                id_almox.Enabled = false;
                bb_almox.Enabled = false;
            }
            else
                bsPneu.AddNew();
            //Buscar Empresa
            cbEmpresa.DataSource = new TCD_CadEmpresa().Select(
                                   new TpBusca[]
                                   {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                   }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            //Buscar Produto Pneu
            TList_CadProduto lProduto = new TCD_CadProduto().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(e.ST_Pneu, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);

            if (lProduto.Count.Equals(1))
            {
                cd_produto.Text = lProduto[0].CD_Produto;
                ds_produto.Text = lProduto[0].DS_Produto;
            }
            else if (lProduto.Count.Equals(0))
            {
                MessageBox.Show("Não existe nenhum produto cadastrado com o Tipo de Produto Pneu!\r\n" +
                                "Por favor verifique o tipo de produto, e atualize o cadastro de produto. ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }

            pDados.set_FormatZero();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.ST_Pneu, 'N')|=|'S'");

            saldoAlmoxarifado();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=| '" + cd_produto.Text.Trim() + "' ; isnull(e.ST_Pneu, 'N')|=|'S'",
                                                   new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                   new TCD_CadProduto());

            saldoAlmoxarifado();
        }

        private void BB_Novo_Desenho_Click(object sender, EventArgs e)
        {
            using (Cadastros.TFCadDesenho fCadDesenho = new Cadastros.TFCadDesenho())
            {
                if (fCadDesenho.ShowDialog() == DialogResult.OK) { }
            }
            gerarCbxDesenho();
        }

        private void cbGerarAlmoxarifado_CheckedChanged(object sender, EventArgs e)
        {
            edtCusto.Enabled = cbGerarAlmoxarifado.Checked;
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());

            saldoAlmoxarifado();
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), string.Empty);

            saldoAlmoxarifado();
        }

        private void cbEmpresa_Leave(object sender, EventArgs e)
        {
            saldoAlmoxarifado();
        }
    }
}

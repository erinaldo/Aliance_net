using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Locacao;
using FormBusca;
using System;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFLocTerceiro : Form
    {
        private TRegistro_LocTerceiro rloc;
        public TRegistro_LocTerceiro rLoc
        {
            get
            {
                if (bsLocTerceiro.Current != null)
                    return bsLocTerceiro.Current as TRegistro_LocTerceiro;
                else return null;
            }
            set { rloc = value; }
        }
        public TFLocTerceiro()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;

            //Modalidade
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("MES", "0"));
            cbx.Add(new TDataCombo("TRIMESTRE", "1"));
            cbx.Add(new TDataCombo("SEMESTRE", "2"));
            cbx.Add(new TDataCombo("ANO", "3"));

            tp_modalidade.DataSource = cbx;
            tp_modalidade.ValueMember = "Value";
            tp_modalidade.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsItens.Count == 0)
                {
                    MessageBox.Show("Obrigatório inserir itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void BuscarProduto()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório informar empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TpBusca[] filtro = new TpBusca[3];
            //Buscar somente produto que possuem Patrimônio cadastrado
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                  "where a.cd_produto = x.cd_patrimonio " +
                                  "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "') ";
            //Descartar produtos que já estão cadastrados
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "not exists";
            filtro[1].vVL_Busca = "(select 1 from TB_LOC_ItensLocTerceiro x " +
                                  "inner join TB_LOC_LocTerceiro y " +
                                  "on x.CD_Empresa = y.CD_Empresa " +
                                  "and x.ID_Loc = y.ID_Loc " +
                                  "and isnull(y.ST_Registro, 'A') = 'A' " +
                                  "and isnull(x.st_registro, 'A') <> 'C' " +
                                  "and x.cd_patrimonio = a.cd_produto)";
            //Descartar produtos cancelados
            filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'C'";
            //Descartar itens correntes já lançados na tela atual. 
            for (int i = 0; (bsLocTerceiro.Current as TRegistro_LocTerceiro).lItens.Count > i; i++)
                Estruturas.CriarParametro(ref filtro, 
                                         "a.cd_produto", 
                                         "'" + (bsLocTerceiro.Current as TRegistro_LocTerceiro).lItens[i].Cd_patrimonio.Trim() + "'", 
                                         "<>");
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   cbEmpresa.SelectedValue.ToString(),
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   filtro);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                   cbEmpresa.SelectedValue.ToString(),
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   filtro);
            else
            {
                //Buscar Produto
                Estruturas.CriarParametro(ref filtro, 
                                          string.Empty,
                                          "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                               "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                               "(exists(select 1 from tb_est_codbarra x " +
                                               "           where x.cd_produto = a.cd_produto " +
                                               "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))", string.Empty);
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                bsItens.AddNew();
                (bsItens.Current as TRegistro_ItensLocTerceiro).Cd_patrimonio = rProd.CD_Produto;
                (bsItens.Current as TRegistro_ItensLocTerceiro).Ds_patrimonio = rProd.DS_Produto;
                (bsItens.Current as TRegistro_ItensLocTerceiro).Dt_ini = CamadaDados.UtilData.Data_Servidor();
                (bsItens.Current as TRegistro_ItensLocTerceiro).Obs = ObsItem.Text;
                if (new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.CD_Patrimonio", vOperador = "=", vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"},
                        new TpBusca { vNM_Campo = "isnull(a.st_controlehora, 'N')", vOperador = "=", vVL_Busca = "'S'"}
                    }, "1") != null)
                    using (TFListaProdutoItem fLista = new TFListaProdutoItem())
                    {
                        if (fLista.ShowDialog() == DialogResult.OK)
                        {
                            if (fLista.lProd != null)
                                fLista.lProd.ForEach(x => (bsItens.Current as TRegistro_ItensLocTerceiro).ProdutoItens.Add(x));
                            fLista.lProdDel.ForEach(x => (bsItens.Current as TRegistro_ItensLocTerceiro).ProdutoItensDel.Add(x));
                        }
                    }
                bsItens_PositionChanged(this, new EventArgs());
            }
            cd_produto.Clear();
            cd_produto.Focus();
            bsItens.ResetCurrentItem();
        }

        public void ExcluirItem()
        {
            if (MessageBox.Show("Confirma a exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                bsItens.RemoveCurrent();
                bsItens.ResetCurrentItem();
            }
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Busca Endereço 
                TList_CadEndereco List_Endereco =
                    new TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, 0, string.Empty);
                if (List_Endereco.Count == 1)
                {
                    CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                    DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                }
            }
        }

        private void TFLocTerceiro_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rloc != null)
            {
                bsLocTerceiro.DataSource = new TList_LocTerceiro() { rloc };
                cbEmpresa.Enabled = false;
                CD_Clifor.Enabled = false;
                BB_Clifor.Enabled = false;
                TS_Itens.Enabled = false;
            }
            else
                bsLocTerceiro.AddNew();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
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
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFLocTerceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()))
                BuscarProduto();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TCD_CadClifor());
            Busca_Endereco_Clifor();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            Busca_Endereco_Clifor();
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
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                                    , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                           , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
        }

        private void dt_iniItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dt_iniItem_Leave(this, new EventArgs());
        }

        private void dt_iniItem_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensLocTerceiro).Dt_inistr = dt_iniItem.Text;
                ObsItem.Focus();
                bsItens.ResetCurrentItem();
            }
        }

        private void ObsItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ObsItem_Leave(this, new EventArgs());
        }

        private void ObsItem_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensLocTerceiro).Obs = ObsItem.Text;
                cd_produto.Focus();
                bsItens.ResetCurrentItem();
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            dt_iniItem.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_ItensLocTerceiro).Dt_inistr;
            ObsItem.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_ItensLocTerceiro).Obs;
        }
    }
}

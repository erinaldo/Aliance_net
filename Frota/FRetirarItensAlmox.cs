using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Frota
{
    public partial class TFRetirarItensAlmox : Form
    {
        private CamadaDados.Almoxarifado.TRegistro_Movimentacao rmovimentacao;
        public  CamadaDados.Almoxarifado.TRegistro_Movimentacao rMovimentacao
        {
            get
            {
                if (bsMovimentacao.Current != null)
                    return bsMovimentacao.Current as CamadaDados.Almoxarifado.TRegistro_Movimentacao;
                else
                    return null;
            }
            set { rmovimentacao = value; }
        }
        public string Cd_empresa
        { get; set; }

        public TFRetirarItensAlmox()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(id_almox.Text))
            {
                MessageBox.Show("Informe o Almoxarifado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_almox.Focus();
                return;
            }
            if (quantidade.Value == decimal.Zero)
            {
                MessageBox.Show("Informe a Quantidade a Retirar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if (Saldo_Almox.Value == decimal.Zero)
            {
                MessageBox.Show("Não existe Saldo para retirar produto no Almoxarifado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void ConsultaSaldo_CustoAlmox()
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text) && (!string.IsNullOrEmpty(Cd_empresa) && (!string.IsNullOrEmpty(id_almox.Text))))
            {
                //Buscar Vl.Custo Almoxarifado
                vl_unitario.Value = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(Cd_empresa,
                                                                                                         id_almox.Text,
                                                                                                         CD_Produto.Text,
                                                                                                         null);
                //Buscar Saldo Almoxarifado
                Saldo_Almox.Value = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(Cd_empresa,
                                                                                                        id_almox.Text,
                                                                                                        CD_Produto.Text,
                                                                                                        null);
                
            }
        }

        private void BuscarProduto()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(e.ST_ConsumoInterno, 'N')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'S'";

            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;

            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vOperador = "<>";
                filtro[filtro.Length - 2].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "')";
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }

            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                sigla_unidade.Text = rProd.Sigla_unidade;
            }
            this.ConsultaSaldo_CustoAlmox();
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            string vParam = "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + Cd_empresa.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almox },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), vParam);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text + ";" +
                            "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + Cd_empresa.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almox },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());

        }

        private void TFRetirarItensAlmox_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pAlmox.set_FormatZero();
            if (rmovimentacao != null)
            {
                bsMovimentacao.DataSource = new CamadaDados.Almoxarifado.TList_Movimentacao() { rmovimentacao };
                CD_Produto.Enabled = false;
                id_almox.Enabled = false;
                this.ConsultaSaldo_CustoAlmox();
            }
            else
                bsMovimentacao.AddNew();
            //Buscar Almoxarifado
            CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox = 
                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                    "where x.id_almox = a.id_almox " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "')"
                    }
                },0, string.Empty);
            if (lAlmox.Count == 1)
            {
                id_almox.Text = lAlmox[0].Id_almoxString;
                ds_almox.Text = lAlmox[0].Ds_almoxarifado;
            }
            CD_Produto.Focus();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFRetirarItensAlmox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_almox.Text))
            {
                string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
                    "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                  "(exists(select 1 from tb_est_codbarra x " +
                                  "         where x.cd_produto = a.cd_produto " +
                                  "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                                  "isnull(a.st_registro, 'A')|<>|'C'" +
                                  "         and e.ST_consumointerno = 'S'";
                DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, sigla_unidade },
                                                                new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
                this.ConsultaSaldo_CustoAlmox();
            }
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.BuscarProduto();
                quantidade.Focus();
            }
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            if (quantidade.Value > Saldo_Almox.Value)
            {
                MessageBox.Show("Não existe saldo suficiente para QTD informada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Value = decimal.Zero;
                quantidade.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(CD_Produto.Text) && (vl_unitario.Value > decimal.Zero))
                Sub_Total.Value = vl_unitario.Value * quantidade.Value;
        }
    }
}

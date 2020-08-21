using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;

namespace Almoxarifado
{
    public partial class TFMovAvulso : Form
    {
        private TRegistro_Movimentacao _rMov = null;
        public TRegistro_Movimentacao rMov
        {
            get
            {
                if (bsMovimentacao.Current != null)
                    return bsMovimentacao.Current as TRegistro_Movimentacao;
                else
                    return null;
            }
            set { _rMov = value; }
        }
        public bool BloquearCampos = false;

        public TFMovAvulso()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ENTRADA", "E"));
            cbx.Add(new Utils.TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void bloquearCampos()
        {
            cd_produto.Enabled = false;
            bb_produto.Enabled = false;
            quantidade.Value = 1;
            quantidade.Enabled = false;
            vl_unitario.Enabled = false;
            tp_movimento.Enabled = false;
            dt_movimento.Enabled = false;
            BB_NovoProduto.Enabled = false;
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void NovoProduto()
        {
            using (Proc_Commoditties.TFAtualizaCadProduto fAtualiza = new Proc_Commoditties.TFAtualizaCadProduto())
            {
                fAtualiza.Text = "Novo Cadastro Produto";
                fAtualiza.Cd_empresa = cd_empresa.Text;
                if (fAtualiza.ShowDialog() == DialogResult.OK)
                    if (fAtualiza.rProd != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                            MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cd_produto.Text = fAtualiza.rProd.CD_Produto;
                            cd_produto_Leave(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BuscarCustoUnitario()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(id_almox.Text)))
            {
                //Buscar custo produto almoxarifado
                object obj = new CamadaDados.Almoxarifado.TCD_SaldoAlmoxarifado().BuscarEscalar(
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
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_almox",
                                            vOperador = "=",
                                            vVL_Busca = id_almox.Text
                                        }
                                    }, "isnull(a.vl_custo, 0)");
                if (obj != null)
                {
                    if (vl_unitario.Value.Equals(0) && vl_subtotal.Value.Equals(0))
                    {
                        vl_unitario.Value = decimal.Parse(obj.ToString());
                        vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
                    }
                }
            }
        }

        private void TFMovAvulso_Load(object sender, EventArgs e)
        {
            if (_rMov == null)
                bsMovimentacao.AddNew();
            else
            {
                bsMovimentacao.DataSource = _rMov;
                bloquearCampos();
            }
            pDados.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            this.BuscarCustoUnitario();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                        new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            this.BuscarCustoUnitario();
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            string vParam = "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), vParam);
            this.BuscarCustoUnitario();
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text + ";" +
                            "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
            this.BuscarCustoUnitario();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto, sigla_unidade },
                                                    "isnull(e.st_consumointerno, 'N')|=|'S'");
            this.BuscarCustoUnitario();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_consumointerno, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto, sigla_unidade },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            this.BuscarCustoUnitario();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFMovAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
                this.NovoProduto();
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void BB_NovoProduto_Click(object sender, EventArgs e)
        {
            this.NovoProduto();
        }
    }
}

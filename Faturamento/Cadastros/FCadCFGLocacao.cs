using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGLocacao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGLocacao()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DIARIA", "D"));
            cbx.Add(new Utils.TDataCombo("FIXA", "F"));
            cb_tp_multa.DataSource = cbx;
            cb_tp_multa.DisplayMember = "Display";
            cb_tp_multa.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.Gravar(
                    bsCFGLocacao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGLocacao, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CFGLocacao lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar(cd_empresa.Text,
                                                                          cd_tabelapreco.Text,
                                                                          cd_produto.Text,
                                                                          cd_local.Text,
                                                                          null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGLocacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCFGLocacao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCFGLocacao.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCFGLocacao.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cd_empresa.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.Excluir(
                        bsCFGLocacao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGLocacao, null);
                    bsCFGLocacao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
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

        private void bb_produto_Click(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
                                            
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Cd. Local|80";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void TFCadCFGLocacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.pDados.set_FormatZero();
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tab Preco|200;" +
                              "a.cd_tabelapreco|Cd.tabelapreco|80";
            
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {

            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void TFCadCFGLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }

}

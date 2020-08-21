using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using System;
using System.Windows.Forms;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCad_CfgECommerce : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_CfgECommerce()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CfgECommerce.Gravar(bsCfgECommerce.Current as TRegistro_CfgECommerce, null);
            else return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CfgECommerce lista = TCN_CfgECommerce.Buscar(cd_empresa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    Lista = lista;
                    bsCfgECommerce.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                    bsCfgECommerce.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_empresa.Enabled = false;
                cfg_pedido.Focus();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsCfgECommerce.AddNew();
            base.afterNovo();
            cd_empresa.Focus();

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCfgECommerce.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
                {
                    TCN_CfgECommerce.Excluir(bsCfgECommerce.Current as TRegistro_CfgECommerce, null);
                    bsCfgECommerce.RemoveCurrent();
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

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S'");
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "';a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Moeda|200;a.cd_moeda|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda },
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), string.Empty);
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda },
                new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Estoque|200;a.cd_local|Código|50";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "where x.cd_local = a.cd_local " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "where x.cd_local = a.cd_local " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_categoriaclifor|Categoria Cliente|200;" +
                              "a.id_categoriaclifor|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_categoriaclifor, ds_categoriaclifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void id_categoriaclifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_categoriaclifor|=|" + id_categoriaclifor.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_categoriaclifor, ds_categoriaclifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void bb_condfiscal_clifor_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_condfiscal|Condição Fiscal|200;" +
                              "cd_condfiscal_clifor|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condfiscal_clifor, ds_condfiscal_clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void cd_condfiscal_clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_condfiscal_clifor|=|'" + cd_condfiscal_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condfiscal_clifor, ds_condfiscal_clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void bbCondFiscal_CliforCF_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_condfiscal|Condição Fiscal|200;" +
                              "cd_condfiscal_clifor|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condfiscal_cliforCF, ds_condfiscalCF },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void cd_condfiscal_cliforCF_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_condfiscal_clifor|=|'" + cd_condfiscal_cliforCF.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condfiscal_cliforCF, ds_condfiscalCF },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }
    }
}

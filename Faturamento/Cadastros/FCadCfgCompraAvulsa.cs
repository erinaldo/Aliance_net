using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFCadCfgCompraAvulsa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgCompraAvulsa()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Faturamento.Cadastros.TCN_CfgCompraAvulsa.Gravar(
                    bsCompraAvulsa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgCompraAvulsa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CfgCompraAvulsa lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_CfgCompraAvulsa.Buscar(cd_empresa.Text,
                                                                              null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCompraAvulsa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCompraAvulsa.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCompraAvulsa.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCompraAvulsa.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cfg_pedido.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgCompraAvulsa.Excluir(
                        bsCompraAvulsa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgCompraAvulsa, null);
                    bsCompraAvulsa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadCfgCompraAvulsa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.pDados.set_FormatZero();
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
            string vParam = "a.tp_movimento|=|'E'";
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50;A.st_ValoresFixos|Permitir valores fixos|50;a.st_fecharpedidoauto|Fechar Pedido Automaticamente|50",
                            new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedido.Text.Trim() + "';" +
                            "a.tp_movimento|=|'E'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
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

        private void TFCadCfgCompraAvulsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text + ";" +
                            "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
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
        }
    }
}

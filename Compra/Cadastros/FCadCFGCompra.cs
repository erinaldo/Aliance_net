using System;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using Utils;

namespace Compra.Cadastros
{
    public partial class TFCadCFGCompra : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGCompra()
        {
            InitializeComponent();
            this.DTS = bsCFGCompra;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ULTIMA COMPRA", "UC"));
            cbx.Add(new TDataCombo("ULTIMA VENDA", "UV"));
            cbx.Add(new TDataCombo("MEDIA VENDAS", "MV"));
            cbx.Add(new TDataCombo("ACERTAR MINIMO", "AM"));

            tp_qtdreqauto.DataSource = cbx;
            tp_qtdreqauto.DisplayMember = "Display";
            tp_qtdreqauto.ValueMember = "Value";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsCFGCompra.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCFGCompra.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                cd_clifor_requisitante.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsCFGCompra.Current != null)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.TCN_CFGCompra.DeletarCFGCompra(bsCFGCompra.Current as CamadaDados.Compra.TRegistro_CFGCompra, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return CamadaNegocio.Compra.TCN_CFGCompra.GravarCFGCompra(bsCFGCompra.Current as CamadaDados.Compra.TRegistro_CFGCompra, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Compra.TList_CFGCompra lista = CamadaNegocio.Compra.TCN_CFGCompra.Buscar(cd_empresa.Text,
                                                                                                 cd_clifor_requisitante.Text,
                                                                                                 cd_moeda.Text,
                                                                                                 cfg_pedido.Text,
                                                                                                 cd_local.Text,
                                                                                                 0,
                                                                                                 string.Empty,
                                                                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGCompra.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCFGCompra.Clear();
                return lista.Count;
            }
            else return 0;

        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new TCD_CadEmpresa());
        }

        private void bb_clifor_requisitante_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                            ((!Utils.Parametros.pubLogin.Trim().Equals("MASTER")) && (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")) ?
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "'" : string.Empty) + ")";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_requisitante, nm_clifor_requisitante }, vParam);
        }

        private void cd_clifor_requisitante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor_requisitante.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                             ((!Utils.Parametros.pubLogin.Trim().Equals("MASTER")) && (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")) ?
                             "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "'" : string.Empty) + ")";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_clifor_requisitante, nm_clifor_requisitante },
                                    new TCD_CadClifor());
        }

        private void bb_ccusto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Moeda|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new TCD_Moeda(), string.Empty);
        }

        private void cd_ccusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new TCD_Moeda());
        }

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vParam = "TP_Movimento|=|'E';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50;A.st_ValoresFixos|Permitir valores fixos|50",
                            new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                            new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedido.Text.Trim() + "';" +
                            "a.tp_movimento|=|'E';"+
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Local Armazenagem|200;" +
                              "CD_Local|Cd. Local|80";
            string vParam = "|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void TFCadCFGCompra_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCFGCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                               "a.ds_tpduplicata|local|150;" +
                               "a.tp_duplicata|Código|50",
                               new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                               new TCD_CadTpDuplicata(),
                               string.Empty);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                               "a.ds_TPDocto|local|150;" +
                               "a.TP_Docto|Código|50",
                               new Componentes.EditDefault[] { TP_Docto, editDefault5 },
                               new TCD_CadTpDoctoDup(),
                               string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(
              "a.tp_duplicata|=|" + tp_duplicata.Text + "",
              new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
              new TCD_CadTpDuplicata());
        }

        private void TP_Docto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(
                 "a.TP_Docto|=|" + TP_Docto.Text + "",
                 new Componentes.EditDefault[] { TP_Docto, editDefault5 },
                 new TCD_CadTpDoctoDup());
        }
    }
}

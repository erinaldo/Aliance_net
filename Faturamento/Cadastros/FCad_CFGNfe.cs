using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento.Cadastros
{
    public partial class TFCad_CFGNfe : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_CFGNfe()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new Utils.TDataCombo("HOMOLOGACAO", "H"));
            cbx.Add(new Utils.TDataCombo("PRODUCAO", "P"));
            tp_ambiente.DataSource = cbx;
            tp_ambiente.DisplayMember = "Display";
            tp_ambiente.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new Utils.TDataCombo("HOMOLOGACAO", "H"));
            cbx1.Add(new Utils.TDataCombo("PRODUCAO", "P"));
            tp_ambiente_nfse.DataSource = cbx1;
            tp_ambiente_nfse.DisplayMember = "Display";
            tp_ambiente_nfse.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("NACIONAL", "N"));
            cbx2.Add(new Utils.TDataCombo("RIO GRANDE DO SUL", "R"));
            tp_ambientecont.DataSource = cbx2;
            tp_ambientecont.DisplayMember = "Display";
            tp_ambientecont.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx3.Add(new Utils.TDataCombo("PRODUCAO", "1"));
            cbx3.Add(new Utils.TDataCombo("HOMOLOGACAO", "2"));
            tp_ambiente_nfce.DataSource = cbx3;
            tp_ambiente_nfce.DisplayMember = "Display";
            tp_ambiente_nfce.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx4.Add(new Utils.TDataCombo("PRODUÇÃO", "1"));
            cbx4.Add(new Utils.TDataCombo("HOMOLOGAÇÃO", "2"));
            tp_ambiente_lmc.DataSource = cbx4;
            tp_ambiente_lmc.DisplayMember = "Display";
            tp_ambiente_lmc.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (horascancnfe.Focused)
                    (bsCfgfNfe.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe).Horascancnfe =
                        horascancnfe.Value;
                if (id_entidadenfse.Focused)
                    (bsCfgfNfe.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe).Id_entidadenfes =
                        id_entidadenfse.Value;
                if (nr_diasexpirarcert.Focused)
                    (bsCfgfNfe.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe).Nr_diasexpirarcert =
                        nr_diasexpirarcert.Value;
                return CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Gravar(
                    bsCfgfNfe.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cd_empresa.Text,
                                                                      path_nfe_schemas.Text,
                                                                      nr_certificado.Text,
                                                                      null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgfNfe.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgfNfe.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCfgfNfe.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgfNfe.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                path_nfe_schemas.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Excluir(
                        bsCfgfNfe.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe, null);
                    bsCfgfNfe.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_pathschemas_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    path_nfe_schemas.Text = fbdPath.SelectedPath.Trim();
            }
        }

        private void TFCad_CFGNfe_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.pDados.set_FormatZero();
            sd_condusoCCe.CharacterCasing = CharacterCasing.Normal;
            url_nfce.CharacterCasing = CharacterCasing.Normal;
            url_chavenfce.CharacterCasing = CharacterCasing.Normal;
        }

        private void TFCad_CFGNfe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}

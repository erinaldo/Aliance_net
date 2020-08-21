using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Graos;
using Utils;
using CamadaDados.Graos;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;

namespace Commoditties.Cadastros
{
    public partial class TFCad_ParamoGMO : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_ParamoGMO()
        {
            InitializeComponent();
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_ParamGMO.GravaParamGMO(Bs_ParamGMO.Current as TRegistro_Cad_ParamGMO,null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Cad_ParamGMO lista = TCN_Cad_ParamGMO.Buscar(cd_Empresa.Text,cd_Contager.Text,histPgto.Text,histRetencao.Text,  null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_ParamGMO.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_ParamGMO.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                Bs_ParamGMO.AddNew();
                base.afterNovo();
                cd_Empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (this.vTP_Modo == TTpModo.tm_Edit)
                cd_Contager.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_Cad_ParamGMO.DeletaParamGMO(Bs_ParamGMO.Current as TRegistro_Cad_ParamGMO,null);
                    Bs_ParamGMO.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa |350;" +
                                  "pGmo.CD_Empresa|Cd. Empresa|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Empresa, nm_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void bb_Contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|ContaGer |350;" +
                                  "pGmo.CD_contager|Cd. ContaGer|100";
            
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Contager, ds_ContaGer },
                                    new TCD_CadContaGer(), "");
        }

        private void bb_Portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Cód.Portador |350;" +
                                 "pGmo.CD_Portador|Cd.Portador|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Portador, ds_Portador},
                                    new TCD_CadPortador(), "");
        }

        private void bb_HistPgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|ContaGer |350;" +
                                 "pGmo.cd_historico|Cd. ContaGer|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { histPgto, ds_HistPgto},
                                    new TCD_CadHistorico(), "");
        }

        private void bb_HistRetencao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|ContaGer |350;" +
                                "pGmo.cd_historico|Cd. ContaGer|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { histRetencao, ds_HistRetencao },
                                    new TCD_CadHistorico(), "");
        }

        private void cd_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_Empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                                  "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_Empresa, nm_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void cd_Contager_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + cd_Contager.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_Contager, ds_ContaGer},
                                    new TCD_CadContaGer());
        }

        private void cd_Portador_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_portador|=|'" + cd_Portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_Portador, ds_Portador},
                                    new TCD_CadPortador());
        }

        private void histPgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + histPgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { histPgto, ds_HistPgto },
                                    new TCD_CadHistorico());
        }

        private void histRetencao_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + histRetencao.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { histRetencao, ds_HistRetencao },
                                    new TCD_CadHistorico());
        }

        private void TFCad_ParamoGMO_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParametros);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_ParamoGMO_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParametros);
        }
        
    }
}

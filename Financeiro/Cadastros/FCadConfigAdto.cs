using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Diversos;

namespace Financeiro.Cadastros
{
    public partial class TFCadConfigAdto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadConfigAdto()
        {
            InitializeComponent();
            DTS = bsConfigAdto;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override string gravarRegistro()
        {
            return TCN_CadConfigAdto.Gravar((bsConfigAdto.Current as TRegistro_CadConfigAdto), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
            {
            TList_ConfigAdto lista = TCN_CadConfigAdto.Buscar(cd_empresa.Text,
                                                              cd_historico_ADTO_C.Text,
                                                              cd_historico_ADTO_R.Text,
                                                              cd_historico_DEVADTO_C.Text,
                                                              cd_historico_DEVADTO_R.Text,
                                                              0, "", null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsConfigAdto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsConfigAdto.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsConfigAdto.AddNew();
                base.afterNovo();
                cd_empresa.Focus();

            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsConfigAdto.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    TCN_CadConfigAdto.Excluir((bsConfigAdto.Current as TRegistro_CadConfigAdto), null);
                    pDados.LimparRegistro();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|200;" +
                              "a.CD_Empresa|Cd. Empresa|80";
            string vParamFixo = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);          
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
            new TCD_CadEmpresa());
        }

        private void bb_historico_adto_c_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_ADTO_C, ds_historico_ADTO_C, tp_mov_ADTO_C },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_ADTO_C_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_ADTO_C.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_ADTO_C, ds_historico_ADTO_C, tp_mov_ADTO_C },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_devadto_c_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_DEVADTO_C, ds_historico_DEVADTO_C, tp_mov_DEVADTO_C },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_DEVADTO_C_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_DEVADTO_C.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_DEVADTO_C, ds_historico_DEVADTO_C, tp_mov_DEVADTO_C },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_adto_r_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_ADTO_R, ds_historico_ADTO_R, tp_mov_ADTO_R },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_ADTO_R_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_ADTO_R.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_ADTO_R, ds_historico_ADTO_R, tp_mov_ADTO_R },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_devadto_r_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_DEVADTO_R, ds_historico_DEVADTO_R, tp_mov_DEVADTO_R },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_DEVADTO_R_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_DEVADTO_R.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_DEVADTO_R, ds_historico_DEVADTO_R, tp_mov_DEVADTO_R },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_Portador_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(st_controletitulo, 'N')|<>|'S';" +
                            "isnull(st_tituloterceiro, 'N')|<>|'S'";
            UtilPesquisa.BTN_BUSCA("ds_portador|Nome Portador|150;a.cd_portador|Código Portador|80"
               , new Componentes.EditDefault[] { Cd_Portador, Nm_Portador}, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void Cd_Portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + Cd_Portador.Text.Trim() + "';" +
                            "isnull(st_controletitulo, 'N')|<>|'S';" +
                            "isnull(st_tituloterceiro, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam
                , new Componentes.EditDefault[] { Cd_Portador, Nm_Portador }, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void TFCadConfigAdto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gConfigAdto);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadConfigAdto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gConfigAdto);
        }

        private void bb_centroresult_adto_c_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_adto_c.Text = fBusca.Cd_centro;
                        ds_centroresult_adto_c.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_adto_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_adto_c.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_adto_c, ds_centroresult_adto_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_devadto_c_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_devadto_c.Text = fBusca.Cd_centro;
                        ds_centroresult_devadto_c.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_devadto_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_devadto_c.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_devadto_c, ds_centroresult_devadto_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_adto_r_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_adto_r.Text = fBusca.Cd_centro;
                        ds_centroresult_adto_r.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_adto_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_adto_r.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_adto_r, ds_centroresult_adto_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_devadto_r_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_devadto_r.Text = fBusca.Cd_centro;
                        ds_centroresult_devadto_r.Text = fBusca.Cd_centro;
                    }
            }
        }

        private void cd_centroresult_devadto_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_devadto_r.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_devadto_r, ds_centroresult_devadto_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_historicoDEV_Compra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoDEV_Compra, ds_historicoDEV_Compra },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoDEV_Compra_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historicoDEV_Compra.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoDEV_Compra, ds_historicoDEV_Compra },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historicoDEV_Venda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoDEV_Venda, ds_historicoDEV_Venda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoDEV_Venda_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historicoDEV_Venda.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoDEV_Venda, ds_historicoDEV_Venda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contagerDEV_CV_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaContaGer(new Componentes.EditDefault[] { cd_contagerDEV_CV, ds_contagerDEV_CV },
                "|exists|(select 1 from tb_fin_contager_x_empresa x where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')");
        }

        private void cd_contagerDEV_CV_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveContaGer("a.cd_contager|=|'" + cd_contagerDEV_CV.Text.Trim() +
            "';|exists|(select 1 from tb_fin_contager_x_empresa x where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')",
            new Componentes.EditDefault[] { cd_contagerDEV_CV, ds_contagerDEV_CV });
        }

        private void bb_HistoricoVgFin_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.TP_Mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_HistoricoVgFin, DS_HistoricoVgFin },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void CD_HistoricoVgFin_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + CD_HistoricoVgFin.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_HistoricoVgFin, DS_HistoricoVgFin },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }
    }
}

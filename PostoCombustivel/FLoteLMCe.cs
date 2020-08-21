using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFLoteLMCe : Form
    {
        private CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfg
        { get; set; }

        public TFLoteLMCe()
        {
            InitializeComponent();
        }

        private void enviarLMC()
        {
            if (bsLMC.Current != null)
            {
                if (rCfg == null)
                {
                    MessageBox.Show("Não existe configuração parar emitir LMC-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    string msg = string.Empty;
                    if (!LMC.TLMC.GerarXMLLMC(bsLMC.Current as CamadaDados.PostoCombustivel.TRegistro_LMC, rCfg, ref msg))
                        MessageBox.Show("Erro enviar LMC-e: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Obrigatório selecionar LMC-e para enviar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsLMC.DataSource = CamadaNegocio.PostoCombustivel.TCN_LMC.Buscar(cd_empresa.Text,
                                                                             cd_produto.Text,
                                                                             string.Empty,
                                                                             dt_inicial.Text,
                                                                             dt_final.Text,
                                                                             string.Empty,
                                                                             null);
        }

        private void TFLoteLMCe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "EXISTS",
                                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_cfgnfe x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.tp_ambiente_lmc is not null)"
                                }
                            }, "a.cd_empresa");
            if (obj != null)
            {
                cd_empresa.Text = obj.ToString();
                cd_empresa_Leave(this, new EventArgs());
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_pdc_cfgposto x " +
                            "           where x.cd_empresa = a.cd_empresa)";
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, vParam);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cd_empresa.Text,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    lblAmbiente.Text = rCfg.Tipo_ambiente_lmc.Trim().ToUpper();
                }
                else
                {
                    rCfg = null;
                    lblAmbiente.Text = "SEM CONFIGURAÇÃO";
                }
            }
            else
            {
                rCfg = null;
                lblAmbiente.Text = "SEM CONFIGURAÇÃO";
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';|exists|(select 1 from tb_pdc_cfgposto x " +
                            "where x.cd_empresa = a.cd_empresa)";
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { cd_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cd_empresa.Text,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    lblAmbiente.Text = rCfg.Tipo_ambiente_lmc.Trim().ToUpper();
                }
                else
                {
                    rCfg = null;
                    lblAmbiente.Text = "SEM CONFIGURAÇÃO";
                }
            }
            else
            {
                rCfg = null;
                lblAmbiente.Text = "SEM CONFIGURAÇÃO";
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.enviarLMC();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLoteLMCe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.enviarLMC();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpDetalhe) && bsLMC.Current != null)
            {
                //Buscar Mov. LMC
                bsMovLMC.DataSource = CamadaNegocio.PostoCombustivel.TCN_MovLMC.Buscar((bsLMC.Current as CamadaDados.PostoCombustivel.TRegistro_LMC).Cd_empresa,
                                                                                       (bsLMC.Current as CamadaDados.PostoCombustivel.TRegistro_LMC).Id_lmcstr,
                                                                                       string.Empty,
                                                                                       null);
                if (bsMovLMC.Count > 0)
                {
                    (bsMovLMC.List as CamadaDados.PostoCombustivel.TList_MovLMC).ForEach(p =>
                        {
                            p.lRec = CamadaNegocio.PostoCombustivel.TCN_MovRec.Buscar(p.Cd_empresa,
                                                                                      p.Id_lmcstr,
                                                                                      p.Id_movtostr,
                                                                                      null);
                            p.lVend = CamadaNegocio.PostoCombustivel.TCN_MovVend.Buscar(p.Cd_empresa,
                                                                                        p.Id_lmcstr,
                                                                                        p.Id_movtostr,
                                                                                        null);
                        });
                    bsMovLMC.ResetBindings(true);
                }
            }
        }

        private void gLMC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().Equals("100") ||
                        e.Value.ToString().Trim().Equals("101") ||
                        e.Value.ToString().Trim().Equals("1001"))
                        gLMC.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gLMC.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}

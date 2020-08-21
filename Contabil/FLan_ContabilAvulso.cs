using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Contabil
{
    public partial class TFLan_ContabilAvulso : Form
    {
        public TFLan_ContabilAvulso()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_lan.Clear();
            id_lote.Clear();
            cd_emp.Clear();
            nr_docto.Clear();
            DT_Inic.Clear();
            DT_Final.Clear();
            st_aberto.Checked = false;
            st_processado.Checked = false;
        }

        private void afterNovo()
        {
            //using (TFContabilAvulso fContabil = new TFContabilAvulso())
            //{
            //    if(fContabil.ShowDialog() == DialogResult.OK)
            //        if (fContabil.rLancto != null)
            //        {
            //            try
            //            {
            //                CamadaNegocio.Contabil.TCN_LanMultiplo.Gravar(fContabil.rLancto, false, null);
            //                if (MessageBox.Show("Lote contabil avulso gravado com sucesso.\r\nDeseja processar o mesmo?", "Pergunta",
            //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //                    try
            //                    {
            //                        CamadaNegocio.Contabil.TCN_LanMultiplo.ProcessarContabilAvulso(fContabil.rLancto, null);
            //                    }
            //                    catch (Exception ex)
            //                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //                this.LimparFiltros();
            //                id_lan.Text = fContabil.rLancto.Id_lanstr;
            //                this.afterBusca();
            //            }
            //            catch (Exception ex)
            //            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //        }
            //}
        }

        private void afterAltera()
        {
            //if (bsLanctoMultiplo.Current != null)
            //{
            //    if ((bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).St_registro.Trim().ToUpper().Equals("P"))
            //    {
            //        MessageBox.Show("Não é permitido processar lote avulso processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    using (TFContabilAvulso fContabil = new TFContabilAvulso())
            //    {
            //        fContabil.St_alterar = true;
            //        fContabil.rLancto = bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo;
            //        if (fContabil.ShowDialog() == DialogResult.OK)
            //        {
            //            if (fContabil.rLancto != null)
            //            {
            //                try
            //                {
            //                    CamadaNegocio.Contabil.TCN_LanMultiplo.Gravar(fContabil.rLancto, false, null);
            //                    if (MessageBox.Show("Lote contabil avulso alterado com sucesso.\r\nDeseja processar o mesmo?", "Pergunta",
            //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //                        CamadaNegocio.Contabil.TCN_LanMultiplo.ProcessarContabilAvulso(fContabil.rLancto, null);
            //                    this.LimparFiltros();
            //                    id_lan.Text = fContabil.rLancto.Id_lanstr;
            //                    this.afterBusca();
            //                }
            //                catch (Exception ex)
            //                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //            }
            //        }
            //        else
            //        {
            //            this.LimparFiltros();
            //            id_lan.Text = fContabil.rLancto.Id_lanstr;
            //            this.afterBusca();
            //        }
            //    }
            //}
        }

        private void afterExclui()
        {
            if (bsLanctoMultiplo.Current != null)
            {
                if ((bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir lançamento avulso processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Contabil.TCN_LanMultiplo.Excluir(bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo, null);
                        MessageBox.Show("Lançamento avulso excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void afterBusca()
        {
            string vStatus = string.Empty;
            string virg = string.Empty;
            if (st_aberto.Checked)
            {
                vStatus += virg + "'A'";
                virg = ",";
            }
            if (st_processado.Checked)
            {
                vStatus += virg + "'P'";
                virg = ",";
            }
            bsLanctoMultiplo.DataSource = CamadaNegocio.Contabil.TCN_LanMultiplo.Buscar(id_lan.Text,
                                                                                        id_lote.Text,
                                                                                        cd_emp.Text,
                                                                                        nr_docto.Text,
                                                                                        DT_Inic.Text,
                                                                                        DT_Final.Text,
                                                                                        vStatus,
                                                                                        null);
            bsLanctoMultiplo_PositionChanged(this, new EventArgs());
        }

        private void Processar()
        {
            if (bsLanctoMultiplo.Current != null)
            {
                if ((bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Lote contabil avulso ja se encontra processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma processamento do lote contabil avulso?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Contabil.TCN_LanMultiplo.ProcessarContabilAvulso(bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo, null);
                        MessageBox.Show("Lote contabil avulso processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_lan.Text = (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).Id_lanstr;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TFLan_ContabilAvulso_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gDebito);
            Utils.ShapeGrid.RestoreShape(this, gLanctoMultiplo);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            pStatus.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label2.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { cd_emp }
              , new CamadaDados.Diversos.TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void cd_emp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_emp.Text.Trim() + "';" +
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
             , new Componentes.EditDefault[] { cd_emp }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLan_ContabilAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.Processar();
        }

        private void bsLanctoMultiplo_PositionChanged(object sender, EventArgs e)
        {
            if (bsLanctoMultiplo.Current != null)
            {
                //Buscar lanctos avulsos
                (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulso =
                    CamadaNegocio.Contabil.TCN_LanctoAvulso.Buscar((bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).Id_lanstr,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   null);
                if ((bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).Id_lotectb != null)
                    (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoCTB =
                        new CamadaDados.Contabil.TCD_LanctosCTB().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_LoteCTB",
                                vOperador = "=",
                                vVL_Busca = (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).Id_lotectbstr
                            }
                        }, 0, string.Empty);
                bsLanctoMultiplo.ResetCurrentItem();
            }
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.Processar();
        }

        private void gLanctoMultiplo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gLanctoMultiplo.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gLanctoMultiplo.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLan_ContabilAvulso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gDebito);
            Utils.ShapeGrid.SaveShape(this, gLanctoMultiplo);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}

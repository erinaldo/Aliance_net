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
    public partial class TFContabilAvulso : Form
    {
        public string pCd_empresa
        { get; set; }
        
        public TFContabilAvulso()
        {
            InitializeComponent();
        }
        
        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsLanctoDebito.Count > 0)
                {
                    if (tot_credito.Value != tot_debito.Value)
                    {
                        MessageBox.Show("Total de DEBITO diferente de Total de CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Contabil.TCN_LanMultiplo.Gravar(bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo, true, null);
                        MessageBox.Show("Lançamento contabil AVULSO gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLanctoMultiplo.Clear();
                        bsLanctoMultiplo.AddNew();
                        cd_empresa.SelectedValue = pCd_empresa;
                        DT_Inic.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar lançamentos a DEBITO/CREDITO para gravar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterInserirItem(string D_C)
        {
            if (bsLanctoMultiplo.Current != null)
            {
                using (TFLanctoAvulso fLancto = new TFLanctoAvulso())
                {
                    fLancto.D_C = D_C;
                    if(fLancto.ShowDialog() == DialogResult.OK)
                        if (fLancto.rLancto != null)
                        {
                            (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulso.Add(fLancto.rLancto);
                            bsLanctoMultiplo.ResetCurrentItem();
                            this.SomarValores(D_C);
                        }
                }
            }
        }

        private void afterAlterarItem(string D_C)
        {
            if (D_C.Trim().ToUpper().Equals("D"))
            {
                if (bsLanctoDebito.Current != null)
                {
                    using (TFLanctoAvulso fLancto = new TFLanctoAvulso())
                    {
                        decimal vl_old = (bsLanctoDebito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto;
                        fLancto.rLancto = bsLanctoDebito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso;
                        fLancto.D_C = D_C;
                        fLancto.St_alterar = true;
                        if (fLancto.ShowDialog() == DialogResult.OK)
                        {
                            bsLanctoDebito.ResetCurrentItem();
                            this.SomarValores(D_C);
                        }
                        else
                        {
                            (bsLanctoDebito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto = vl_old;
                            bsLanctoDebito.ResetCurrentItem();
                        }
                    }
                }
            }
            else
            {
                if (bsLanctoCredito.Current != null)
                {
                    using (TFLanctoAvulso fLancto = new TFLanctoAvulso())
                    {
                        decimal vl_old = (bsLanctoCredito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto;
                        fLancto.rLancto = bsLanctoCredito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso;
                        fLancto.D_C = D_C;
                        fLancto.St_alterar = true;
                        if (fLancto.ShowDialog() == DialogResult.OK)
                        {
                            bsLanctoCredito.ResetCurrentItem();
                            this.SomarValores(D_C);
                        }
                        else
                        {
                            (bsLanctoCredito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto = vl_old;
                            bsLanctoCredito.ResetCurrentItem();
                        }
                    }
                }
            }
        }

        private void afterExcluirItem(string D_C)
        {
            if (D_C.Trim().ToUpper().Equals("D"))
            {
                if (bsLanctoDebito.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão do lançamento a DEBITO selecionado?",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulsoDel.Add(
                            bsLanctoDebito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso);
                        (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulso.Remove(
                            bsLanctoDebito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso);
                        bsLanctoMultiplo.ResetCurrentItem();
                        this.SomarValores(D_C);
                    }
                }
            }
            else
            {
                if (bsLanctoCredito.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão do lançamento a CREDITO selecionado?",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulsoDel.Add(
                            bsLanctoCredito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso);
                        (bsLanctoMultiplo.Current as CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo).lLanctoAvulso.Remove(
                            bsLanctoCredito.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso);
                        bsLanctoMultiplo.ResetCurrentItem();
                        this.SomarValores(D_C);
                    }
                }
            }
        }

        private void SomarValores(string D_C)
        {
            if (D_C.Trim().ToUpper().Equals("D"))
            {
                decimal tot = decimal.Zero;
                for (int i = 0; i < bsLanctoDebito.Count; i++)
                    tot += (bsLanctoDebito[i] as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto;
                tot_debito.Value = tot;
            }
            else
            {
                decimal tot = decimal.Zero;
                for (int i = 0; i < bsLanctoCredito.Count; i++)
                    tot += (bsLanctoCredito[i] as CamadaDados.Contabil.TRegistro_LanctoAvulso).Vl_lancto;
                tot_credito.Value = tot;
            }
        }
        
        private void TFContabilAvulso_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar Empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmp = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                                            new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = string.Empty,
                                                                    vVL_Busca = "exists(select 1 from tb_div_usuario_x_empresa x " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                "exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))"
                                                                }
                                                            }, 0, string.Empty);
            cd_empresa.DataSource = lEmp;
            cd_empresa.DisplayMember = "NM_Empresa";
            cd_empresa.ValueMember = "CD_Empresa";
            bsLanctoMultiplo.AddNew();
            cd_empresa.SelectedValue = pCd_empresa;
            DT_Inic.Focus();
        }

        private void bb_inserir_debito_Click(object sender, EventArgs e)
        {
            this.afterInserirItem("D");
        }

        private void bb_alterar_debito_Click(object sender, EventArgs e)
        {
            this.afterAlterarItem("D");
        }

        private void bb_deletar_debito_Click(object sender, EventArgs e)
        {
            this.afterExcluirItem("D");
        }

        private void bb_inserir_credito_Click(object sender, EventArgs e)
        {
            this.afterInserirItem("C");
        }

        private void bb_alterar_credito_Click(object sender, EventArgs e)
        {
            this.afterAlterarItem("C");
        }

        private void bb_excluir_credito_Click(object sender, EventArgs e)
        {
            this.afterExcluirItem("C");
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFContabilAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F7))
                this.afterInserirItem("D");
            else if (e.Control && e.KeyCode.Equals(Keys.F8))
                this.afterAlterarItem("D");
            else if (e.Control && e.KeyCode.Equals(Keys.F9))
                this.afterExcluirItem("D");
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirItem("C");
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarItem("C");
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirItem("C");
        }

        private void TFContabilAvulso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}

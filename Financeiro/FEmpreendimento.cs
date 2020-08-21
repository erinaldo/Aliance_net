using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFEmpreendimento : Form
    {
        public Utils.TTpModo vModo
        { get; set; }

        private CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento remp;
        public CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento rEmp
        {
            set { remp = value; }
            get
            {
                return (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento);
            }
        }

        public TFEmpreendimento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirCCusto()
        {
            using (TFLanCCustoEmpreendimento fCCusto = new TFLanCCustoEmpreendimento())
            {
                if (fCCusto.ShowDialog() == DialogResult.OK)
                    if (fCCusto.lCResultado != null)
                    {
                        if (bsGrupoCF.Count > 0)
                            fCCusto.lCResultado.ForEach(p =>
                                {
                                    if (!(bsGrupoCF.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF).Exists(v => v.Cd_grupocf.Trim().Equals(p.Cd_grupocf.Trim())))
                                        (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).lCResultado.Add(p);
                                });
                        else
                            fCCusto.lCResultado.ForEach(p => (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).lCResultado.Add(p));
                        bsEmpreendimento.ResetCurrentItem();
                    }
            }
        }

        private void DeletarCCusto()
        {
            if (bsGrupoCF.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do centro resultado selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes)
                {
                    //Inserir centro de custo na lista a ser excluida
                    (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).lCResultadoDel.Add(
                        bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF);
                    //Excluir centro de custo do grid
                    bsGrupoCF.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Não existe centro resultado selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFEmpreendimento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (vModo.Equals(Utils.TTpModo.tm_Insert))
                bsEmpreendimento.AddNew();
            else
            {
                bsEmpreendimento.Add(remp);
                bsEmpreendimento.ResetCurrentItem();
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                ds_empreendimento.Focus();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirCCusto();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.DeletarCCusto();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F11))
                this.InserirCCusto();
            else if (e.KeyCode.Equals(Keys.F12))
                this.DeletarCCusto();
        }

        private void TFEmpreendimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

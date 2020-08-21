using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using CamadaDados.Financeiro.Cadastros;

namespace Fiscal.Cadastros
{
    public partial class FCadCmiSimples : Form
    {

        public string cd_cmi, ds_cmi, tp;
        private CamadaDados.Fiscal.TRegistro_CadCMI rcmi;
        public CamadaDados.Fiscal.TRegistro_CadCMI rCmi
        {
            get
            {
                if (bs_cmi.Current != null)
                    return bs_cmi.Current as TRegistro_CadCMI;
                else return null;
            }
            set { rcmi = value; }
        }

        public FCadCmiSimples()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void FCadCmiSimples_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (!(cd_cmii.Focus()))
                ds_cmii.Focus();
            bs_cmi.AddNew();
            if (!string.IsNullOrEmpty(tp))
                tp_movimento.SelectedValue = tp;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (pDados.validarCampoObrigatorio())
            {
                cd_cmi = cd_cmii.Text;
                ds_cmi = ds_cmii.Text;
                tp = tp_movimento.SelectedValue.ToString();

                TCN_CadCMI.Gravar(bs_cmi.Current as TRegistro_CadCMI, null);
                object cdcmi = new TCD_CadCMI().BuscarEscalar(
                    new TpBusca[]{
                        new TpBusca(){
                            vNM_Campo = "a.ds_cmi",
                            vOperador = "=",
                            vVL_Busca = "'"+ds_cmi+"'"
                        }
                    },"a.cd_cmi"
                );
                if (!string.IsNullOrEmpty(cdcmi.ToString()))
                {
                    cd_cmii.Text = cdcmi.ToString();
                    cd_cmi = cdcmi.ToString();
                }


                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_duplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_TpDuplicata|Tipo Duplicata|350;" +
                              "a.TP_Duplicata|TP. Duplicata|100";
            string vParamFixo = "a.TP_Mov|=|";
            if (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") : false)
                vParamFixo += "'P'";
            else
                vParamFixo += "'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Duplicata, ds_tpduplicata },
                                    new TCD_CadTpDuplicata(), vParamFixo);
        }

        private void TP_Duplicata_Leave(object sender, EventArgs e)
        {
            if (TP_Duplicata.Text.Trim() != "")
            {
                string vColunas = "a.tp_duplicata|=|'" + TP_Duplicata.Text.Trim() + "';" +
                                  "a.TP_Mov|=|";
                if (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") : false)
                    vColunas += "'P'";
                else
                    vColunas += "'R'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Duplicata, ds_tpduplicata },
                                        new TCD_CadTpDuplicata());
            }
            else
                ds_tpduplicata.Clear();
        }

        private void bbDocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                              "TP_Docto|TP. Docto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Tp_Docto, ds_tpDocto },
                                    new TCD_CadTpDoctoDup(), "");
        }

        private void Tp_Docto_Leave(object sender, EventArgs e)
        {
            if (Tp_Docto.Text.Trim() != "")
            {
                string vColunas = "tp_docto|=|'" + Tp_Docto.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Tp_Docto, ds_tpDocto },
                                        new TCD_CadTpDoctoDup());
            }
            else
                ds_tpDocto.Clear();
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondPGTO, ds_condpgto },
                                    new TCD_CadCondPgto(), "");
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            if (CD_CondPGTO.Text.Trim() != "")
            {
                string vColunas = "a.cd_condpgto|=|'" + CD_CondPGTO.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CondPGTO, ds_condpgto },
                                        new TCD_CadCondPgto());
            }
            else
                ds_condpgto.Clear();
        }

        private void ST_Mestra_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !ST_Mestra.Checked;
            ST_Complementar.Enabled = !ST_Mestra.Checked;
            ST_SimplesRemessa.Enabled = !ST_Mestra.Checked;
            ST_GeraEstoque.Enabled = !ST_Mestra.Checked;
            st_compdevimposto.Enabled = !ST_Mestra.Checked;
            if (ST_Mestra.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Complementar.Checked = false;
                ST_SimplesRemessa.Checked = false;
                ST_GeraEstoque.Checked = false;
                st_compdevimposto.Checked = false;
            }
        }

        private void ST_Devolucao_CheckedChanged(object sender, EventArgs e)
        {
            ST_Complementar.Enabled = !ST_Devolucao.Checked;
            ST_Mestra.Enabled = !ST_Devolucao.Checked;
            ST_SimplesRemessa.Enabled = !ST_Devolucao.Checked;
            st_retorno.Enabled = !ST_Devolucao.Checked;
            st_compdevimposto.Enabled = !ST_Devolucao.Checked;
            Tp_Docto.Enabled = !ST_Devolucao.Checked;
            bbDocto.Enabled = !ST_Devolucao.Checked;
            TP_Duplicata.Enabled = !ST_Devolucao.Checked;
            bb_duplicata.Enabled = !ST_Devolucao.Checked;
            CD_CondPGTO.Enabled = !ST_Devolucao.Checked;
            bb_condpgto.Enabled = !ST_Devolucao.Checked;
            if (ST_Devolucao.Checked)
            {
                ST_Complementar.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
                st_compdevimposto.Checked = false;
                Tp_Docto.Text = string.Empty;
                TP_Duplicata.Text = string.Empty;
                CD_CondPGTO.Text = string.Empty;
            }
        }

        private void ST_Complementar_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !ST_Complementar.Checked;
            ST_Mestra.Enabled = !ST_Complementar.Checked;
            ST_SimplesRemessa.Enabled = !ST_Complementar.Checked;
            st_retorno.Enabled = !ST_Complementar.Checked;
            st_compdevimposto.Enabled = !ST_Complementar.Checked;
            if (ST_Complementar.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
                st_compdevimposto.Checked = false;
            }
        }

        private void ST_SimplesRemessa_CheckedChanged(object sender, EventArgs e)
        {
            st_retorno.Enabled = !ST_SimplesRemessa.Checked;
            ST_Devolucao.Enabled = !ST_SimplesRemessa.Checked;
            ST_Mestra.Enabled = !ST_SimplesRemessa.Checked;
            ST_Complementar.Enabled = !ST_SimplesRemessa.Checked;
            st_compdevimposto.Enabled = !ST_SimplesRemessa.Checked;
            TP_Duplicata.Enabled = !ST_SimplesRemessa.Checked;
            bb_duplicata.Enabled = !ST_SimplesRemessa.Checked;
            CD_CondPGTO.Enabled = !ST_SimplesRemessa.Checked;
            bb_condpgto.Enabled = !ST_SimplesRemessa.Checked;
            if (ST_SimplesRemessa.Checked)
            {
                st_retorno.Checked = false;
                ST_Devolucao.Checked = false;
                ST_Mestra.Checked = false;
                ST_Complementar.Checked = false;
                st_compdevimposto.Checked = false;
                ST_GeraEstoque.Enabled = true;
                TP_Duplicata.Clear();
                ds_tpduplicata.Clear();
                CD_CondPGTO.Clear();
                ds_condpgto.Clear();
        }
    }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
                TP_Duplicata.Clear();
                ds_tpduplicata.Clear();
            
        }

        private void st_retorno_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !st_retorno.Checked;
            ST_Complementar.Enabled = !st_retorno.Checked;
            ST_Mestra.Enabled = !st_retorno.Checked;
            ST_SimplesRemessa.Enabled = !st_retorno.Checked;

        }

        private void st_compdevimposto_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !st_compdevimposto.Checked;
            ST_Complementar.Enabled = !st_compdevimposto.Checked;
            ST_Mestra.Enabled = !st_compdevimposto.Checked;
            ST_SimplesRemessa.Enabled = !st_compdevimposto.Checked;
            st_retorno.Enabled = !st_compdevimposto.Checked;
            if (st_compdevimposto.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Complementar.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
            }
        }
       }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Fiscal;

namespace Fiscal
{
    public partial class TFLan_Impostos : Form
    {
        private bool St_iss = false;

        private TRegistro_ImpostosNF rimp;
        public TRegistro_ImpostosNF rImp
        {
            get
            {
                if (bsImpostosNf.Current != null)
                    return bsImpostosNf.Current as TRegistro_ImpostosNF;
                else return null;
            }
            set { rimp = value; }
        }
        public decimal Vl_TotalNota
        { get; set; }


        public TFLan_Impostos()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("IGNORAR", string.Empty));
            cbx.Add(new TDataCombo("SOMAR", "S"));
            cbx.Add(new TDataCombo("DIMINUIR", "D"));
            st_totalnota.DataSource = cbx;
            st_totalnota.DisplayMember = "Display";
            st_totalnota.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new TDataCombo("TRIBUTAÇÃO MUNICIPIO", "1"));
            cbx1.Add(new TDataCombo("TRIBUTAÇÃO FORA MUNICIPIO", "2"));
            cbx1.Add(new TDataCombo("ISENTO", "3"));
            cbx1.Add(new TDataCombo("IMUNE", "4"));
            cbx1.Add(new TDataCombo("EXIGIBILIDADE SUSPENSA DECISÃO JUDICIAL", "5"));
            cbx1.Add(new TDataCombo("EXIGIBILIDADE SUSPENSA DECISÃO ADIMINISTRATIVA", "6"));
            tp_naturezaoperacaoiss.DataSource = cbx1;
            tp_naturezaoperacaoiss.DisplayMember = "Display";
            tp_naturezaoperacaoiss.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("NORMAL", "N"));
            cbx3.Add(new TDataCombo("RETIDA", "R"));
            cbx3.Add(new TDataCombo("SUBSTITUTA", "S"));
            cbx3.Add(new TDataCombo("ISENTA", "I"));
            tp_tributiss.DataSource = cbx3;
            tp_tributiss.DisplayMember = "Display";
            tp_tributiss.ValueMember = "Value";
        }
        
        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (St_iss)
                {
                    if (tp_tributiss.SelectedValue == null)
                    {
                        MessageBox.Show("Obrigatorio informar tipo tributação para imposto ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tp_tributiss.Focus();
                        return;
                    }
                    if (tp_naturezaoperacaoiss.SelectedValue == null)
                    {
                        MessageBox.Show("Obrigatorio informar natureza para imposto ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tp_naturezaoperacaoiss.Focus();
                        return;
                    }
                    if (pc_retencao.Value > decimal.Zero && string.IsNullOrEmpty(ds_deducao.Text))
                    {
                        MessageBox.Show("Obrigatório informar justificativa de retenção para ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds_deducao.Focus();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(cd_imposto.Text))
                {
                    object st_issqn = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_imposto",
                            vOperador = "=",
                            vVL_Busca =  cd_imposto.Text
                        },new TpBusca()
                        {
                            vNM_Campo = "a.st_issqn",
                            vOperador = "=",
                            vVL_Busca =  "1"
                        }
                    }, "a.st_issqn");
                    if (st_issqn != null)
                    {
                        if (tp_naturezaoperacaoiss.SelectedValue.Equals(string.Empty))
                        { 
                            MessageBox.Show("Obrigatório selecionar a natureza do ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                (bsImpostosNf.Current as TRegistro_ImpostosNF).Tp_registro = "M";//Registro Manual
                this.DialogResult = DialogResult.OK;
            }
        }
        
        private void TFLan_Impostos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gImpostos);
            ds_deducao.CharacterCasing = CharacterCasing.Normal;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rimp != null)
            {
                //Verificar se imposto e issqn
                St_iss = new TCD_CadImposto().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_imposto",
                                    vOperador = "=",
                                    vVL_Busca = rimp.Cd_impostostr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_issqn",
                                    vOperador = "=",
                                    vVL_Busca = "1"
                                }
                            }, "1") != null;
                tp_tributiss.Enabled = St_iss;
                tp_naturezaoperacaoiss.Enabled = St_iss;
                ds_deducao.Enabled = St_iss;
                bsImpostosNf.DataSource = new TList_ImpostosNF() { rimp };
                cd_imposto.Enabled = false;
                bb_imposto.Enabled = false;
                cd_st.Focus();
            }
            else bsImpostosNf.AddNew();
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Imposto|Descrição Imposto|200;" +
                               "CD_Imposto|Cd. Imposto|80;" +
                               "a.st_issqn|ISSQN|30";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_st.Text))
                vParam = "|exists|(select 1 from TB_FIS_SitTribut x " +
                         "          where x.cd_imposto = a.cd_imposto " +
                         "          and x.cd_st = '" + cd_st.Text.Trim() + "')";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                                        new CamadaDados.Fiscal.TCD_CadImposto(), vParam);
            if (linha != null)
            {
                St_iss = Convert.ToBoolean(linha["st_issqn"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ISSQN = St_iss;
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.Cd_imposto = Convert.ToDecimal(linha["cd_imposto"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.ds_imposto = linha["ds_imposto"].ToString();
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_PIS = Convert.ToBoolean(linha["st_pis"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Cofins = Convert.ToBoolean(linha["st_cofins"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ICMS = Convert.ToBoolean(linha["st_icms"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_IPI = Convert.ToBoolean(linha["st_ipi"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_CSLL = Convert.ToBoolean(linha["st_csll"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_IRRF = Convert.ToBoolean(linha["st_irrf"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_INSS = Convert.ToBoolean(linha["st_inss"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_II = Convert.ToBoolean(linha["st_ii"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Funrural = Convert.ToBoolean(linha["st_funrural"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Senar = Convert.ToBoolean(linha["st_senar"]);
            }
            else St_iss = false;
            tp_tributiss.Enabled = St_iss;
            tp_naturezaoperacaoiss.Enabled = St_iss;
            ds_deducao.Enabled = St_iss;
            (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ISSQN = St_iss;
        }
                
        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Imposto|=|" + cd_imposto.Text;
            if (!string.IsNullOrEmpty(cd_st.Text))
                vColunas += ";|exists|(select 1 from TB_FIS_SitTribut x " +
                            "           where x.cd_imposto = a.cd_imposto " +
                            "           and x.cd_st = '" + cd_st.Text.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto }, new CamadaDados.Fiscal.TCD_CadImposto());
            if (linha != null)
            {
                St_iss = Convert.ToBoolean(linha["st_issqn"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ISSQN = St_iss;
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.Cd_imposto = Convert.ToDecimal(linha["cd_imposto"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.ds_imposto = linha["ds_imposto"].ToString();
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_PIS = Convert.ToBoolean(linha["st_pis"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Cofins = Convert.ToBoolean(linha["st_cofins"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ICMS = Convert.ToBoolean(linha["st_icms"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_IPI = Convert.ToBoolean(linha["st_ipi"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_CSLL = Convert.ToBoolean(linha["st_csll"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_IRRF = Convert.ToBoolean(linha["st_irrf"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_INSS = Convert.ToBoolean(linha["st_inss"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_II = Convert.ToBoolean(linha["st_ii"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Funrural = Convert.ToBoolean(linha["st_funrural"]);
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_Senar = Convert.ToBoolean(linha["st_senar"]);
            }
            else St_iss = false;
            tp_tributiss.Enabled = St_iss;
            tp_naturezaoperacaoiss.Enabled = St_iss;
            ds_deducao.Enabled = St_iss;
            (bsImpostosNf.Current as TRegistro_ImpostosNF).Imposto.St_ISSQN = St_iss;
        }
       
        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLan_Impostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
       
        private void BB_SitTrib_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_situacao|Situação Tributária|350;" +
                              "a.CD_St|Cd.Sit.|100;" +
                              "a.tp_situacao|TP. Situação|30";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_imposto.Text))
                vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_st, DS_SitTrib, tp_situacao },
                                    new TCD_CadSitTribut(), vParam);
            if (!string.IsNullOrEmpty(cd_st.Text))
            {
                object obj = new CamadaDados.Fiscal.TCD_CadTpImposto_x_SitTrib().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_imposto",
                                        vOperador = "=",
                                        vVL_Busca = cd_imposto.Text
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_st",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_st.Text.Trim() + "'"
                                    }
                                }, "a.tp_imposto");
                if (obj != null)
                    tp_imposto.Text = obj.ToString();
            }
        }

        private void cd_st_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ST|=|'" + cd_st.Text + "'";
            if (!string.IsNullOrEmpty(cd_imposto.Text))
                vColunas += ";a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_st, DS_SitTrib, tp_situacao },
                                    new TCD_CadSitTribut());
            if (!string.IsNullOrEmpty(cd_st.Text))
            {
                object obj = new CamadaDados.Fiscal.TCD_CadTpImposto_x_SitTrib().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_imposto",
                                        vOperador = "=",
                                        vVL_Busca = cd_imposto.Text
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_st",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_st.Text.Trim() + "'"
                                    }
                                }, "a.tp_imposto");
                if (obj != null)
                    tp_imposto.Text = obj.ToString();
            }
        }

        private void pc_retencao_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_retencao = pc_retencao.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void vl_basecalc_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Vl_basecalc = vl_basecalc.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void pc_reducaobasecalc_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_reducaobasecalc = pc_reducaobasecalc.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void pc_aliquota_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_aliquota = pc_aliquota.Value;
                if (tp_tributiss.SelectedIndex.Equals(1))
                    (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_retencao = pc_aliquota.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void pc_reducaoaliquota_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_reducaoaliquota = pc_reducaoaliquota.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void vl_impostocalc_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Vl_basecalc = vl_basecalc.Value;
                TCN_ImpostosNF.CalcValorImposto((bsImpostosNf.Current as TRegistro_ImpostosNF), Vl_TotalNota > decimal.Zero ? Vl_TotalNota : vl_basecalc.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void vl_basecalcsubsttrib_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Vl_basecalcsubsttrib = vl_basecalcsubsttrib.Value;
                TCN_ImpostosNF.CalcValorImpostoSubst((bsImpostosNf.Current as TRegistro_ImpostosNF), vl_basecalcsubsttrib.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void pc_reducaobasecalcsubstrib_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_reducaobasecalcsubsttrib = pc_reducaobasecalcsubstrib.Value;
                TCN_ImpostosNF.CalcValorImpostoSubst((bsImpostosNf.Current as TRegistro_ImpostosNF), vl_basecalcsubsttrib.Value, true);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void pc_aliquotasubst_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_aliquotasubst = pc_aliquotasubst.Value;
                TCN_ImpostosNF.CalcValorImpostoSubst((bsImpostosNf.Current as TRegistro_ImpostosNF), vl_basecalcsubsttrib.Value, false);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void vl_impostosubsttrib_Leave(object sender, EventArgs e)
        {
            if (bsImpostosNf.Current != null)
            {
                (bsImpostosNf.Current as TRegistro_ImpostosNF).Pc_reducaobasecalcsubsttrib = pc_reducaobasecalcsubstrib.Value;
                TCN_ImpostosNF.CalcValorImpostoSubst((bsImpostosNf.Current as TRegistro_ImpostosNF), vl_basecalcsubsttrib.Value, true);
                bsImpostosNf.ResetCurrentItem();
            }
        }

        private void id_basecredito_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_basecredito|=|" + id_basecredito.Text,
                                    new Componentes.EditDefault[] { id_basecredito },
                                    new CamadaDados.Fiscal.TCD_TpBaseCalcCredito());
        }

        private void bb_basecredito_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_basecredito|Base Credito|200;" +
                              "a.id_basecredito|Id. Base|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_basecredito },
                                    new CamadaDados.Fiscal.TCD_TpBaseCalcCredito(), string.Empty);
        }

        private void id_tpcred_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpcred|=|" + id_tpcred.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpcred },
                                    new CamadaDados.Fiscal.TCD_TpCreditoPisCofins());
        }

        private void bb_tpcred_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpcred|Tipo Credito|350;" +
                              "a.id_tpcred|TP. Credito|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpcred },
                                    new CamadaDados.Fiscal.TCD_TpCreditoPisCofins(), string.Empty);
        }

        private void pc_compaliquota_Leave(object sender, EventArgs e)
        {
            if (vl_basecalc.Value > decimal.Zero && pc_compaliquota.Value > decimal.Zero)
                vl_compaliquota.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_basecalc.Value, pc_compaliquota.Value), 100), 2, MidpointRounding.AwayFromZero);
        }

        private void vl_compaliquota_Leave(object sender, EventArgs e)
        {
            if (vl_basecalc.Value > decimal.Zero && vl_compaliquota.Value > decimal.Zero)
                pc_compaliquota.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_compaliquota.Value, 100), vl_basecalc.Value), 2, MidpointRounding.AwayFromZero);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click_1(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void tp_tributiss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_tributiss.SelectedIndex.Equals(1))
            {
                st_totalnota.SelectedIndex = 2;
                pc_aliquota_Leave(this, new EventArgs());
            }
        }
    }
}

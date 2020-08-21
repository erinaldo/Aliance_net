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
    public partial class TFLoteRemessa : Form
    {
        public CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa rLote
        {
            get
            {
                if (bsLoteRemessa.Current != null)
                    return bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa;
                else
                    return null;
            }
        }

        public TFLoteRemessa()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("REGISTRAR TITULO", "RT"));
            cbx.Add(new Utils.TDataCombo("PEDIDO BAIXA", "PB"));
            cbx.Add(new Utils.TDataCombo("ALTERAR VENCIMENTO", "AV"));
            cbInstrucao.DataSource = cbx;
            cbInstrucao.DisplayMember = "Display";
            cbInstrucao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (dsBloqueto.Count < 1)
                {
                    MessageBox.Show("Obrigatorio informar titulo para gerar lote de remessa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirTitulo()
        {
            if (cbConfig.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar configuração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbConfig.Focus();
                return;
            }
            if (cbInstrucao.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar instrução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbInstrucao.Focus();
                return;
            }
            using (TFLocalizarBloquetos fLocalizar = new TFLocalizarBloquetos())
            {
                fLocalizar.Text = "Localizar Bloquetos Gerar Remessa";
                fLocalizar.pCd_empresa = cd_empresa.Text;
                fLocalizar.pNm_empresa = nm_empresa.Text;
                fLocalizar.pId_Config = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Id_configstr;
                fLocalizar.pDs_config = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Ds_config;
                fLocalizar.St_remessa = true;
                fLocalizar.pId_Config = cbConfig.SelectedValue.ToString();
                fLocalizar.Tp_instrucao = cbInstrucao.SelectedValue.ToString();
                if(fLocalizar.ShowDialog() == DialogResult.OK)
                    if (fLocalizar.lBloquetos != null)
                    {
                        fLocalizar.lBloquetos.ForEach(p =>
                            {
                                if (!(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Exists(v => v.Nosso_numero.Trim().Equals(p.Nosso_numero.Trim())))
                                    (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Add(p);
                            });
                        cbInstrucao.Enabled = false;
                        bsLoteRemessa.ResetCurrentItem();
                        vl_total_bloqueto.Value = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Sum(p => p.Vl_atual);
                    }
            }
        }

        private void ExcluirTitulo()
        {
            if (dsBloqueto.Current != null)
                if(MessageBox.Show("Confirma exclusão do titulo selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulosDel.Add(
                        dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo);
                    dsBloqueto.RemoveCurrent();
                    cbInstrucao.Enabled = dsBloqueto.Count.Equals(0);
                    vl_total_bloqueto.Value = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Sum(p => p.Vl_atual);
                }
        }

        private void TFLoteRemessa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBloqueto);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cbConfig.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_cobranca",
                                            vOperador = "=",
                                            vVL_Busca = "'CR'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
            cbConfig.DisplayMember = "ds_config";
            cbConfig.ValueMember = "id_config";
            bsLoteRemessa.AddNew();
            if (!string.IsNullOrEmpty(Utils.SettingsUtils.Default.PATH_REMESSA))
                (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Path_remessa = Utils.SettingsUtils.Default.PATH_REMESSA;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirTitulo();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirTitulo();
        }

        private void TFLoteRemessa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTitulo();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTitulo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLoteRemessa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBloqueto);
        }

        private void cbConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbConfig.SelectedItem != null)
            {
                cd_empresa.Text = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Empresa.Cd_empresa;
                nm_empresa.Text = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Empresa.Nm_empresa;
                cd_contager.Text = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Cd_contager;
                ds_contager.Text = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Ds_contager;
            }
        }
    }
}

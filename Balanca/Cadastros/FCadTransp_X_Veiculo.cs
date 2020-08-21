using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaNegocio.Balanca.Cadastros;
using CamadaDados.Balanca.Cadastros;

namespace Balanca.Cadastros
{
    public partial class TFCadTransp_X_Veiculo : FormPadrao.FFormPadrao
    {
        public TFCadTransp_X_Veiculo()
        {
            InitializeComponent();
            DTS = DSTransp_X_Veiculo;
            
        }

        private void BB_Transportadora_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Transp, NM_Clifor }, "isNull(a.ST_Transportadora,'N')|=|'S'");
            string vColunas = "a.Nm_Clifor|Transportadora|350;" +
                  "a.CD_Clifor|Cód. Transportadora|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Transp, NM_Clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isNull(a.ST_Transportadora,'N')|=|'S'");
        }

        private void BB_TpVeiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veículo|350;" +
                              "CD_TpVeiculo|Cód. Tipo Veículo|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TpVeiculo, DS_TpVeiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo(), "");
        }

        private void CD_Transp_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Transp.Text + "';" + "isNull(a.ST_Transportadora,'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Transp, NM_Clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void CD_TpVeiculo_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_TpVeiculo|=|'" + CD_TpVeiculo.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TpVeiculo, DS_TpVeiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        public override void formatZero()
        {
            pCadTransp_x_Veiculo.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pCadTransp_x_Veiculo.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pCadTransp_x_Veiculo.validarCampoObrigatorio())
              return TCN_CadTransp_X_Veiculo.GravaTransp_X_Veiculo((DSTransp_X_Veiculo.Current as TRegistro_CadTransp_X_Veiculo));
            else
                return "";
        }
       
        public override int buscarRegistros()
        {

            TList_CadTransp_X_Veiculo lista = TCN_CadTransp_X_Veiculo.Busca(CD_Transp.Text,
                                                 Nr_Veiculo.Text,
                                                 Placa.Text,
                                                 CD_TpVeiculo.Text,
                                                 DS_TpVeiculo.Text,
                                                 NM_Clifor.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    DSTransp_X_Veiculo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        DSTransp_X_Veiculo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                base.afterNovo();
                DSTransp_X_Veiculo.AddNew();
                CD_Transp.Focus();
            }
            
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                DSTransp_X_Veiculo.RemoveCurrent();
            base.afterCancela();
        }

        public override void afterAltera()
            {
            base.afterAltera();
            CD_TpVeiculo.Focus();
        }

        public override void afterExclui()
        {
            if (DSTransp_X_Veiculo.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTransp_X_Veiculo.DeletaTransp_X_Veiculo(DSTransp_X_Veiculo.Current as TRegistro_CadTransp_X_Veiculo);
                        DSTransp_X_Veiculo.RemoveCurrent();
                        pCadTransp_x_Veiculo.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        public override void afterGrava()
        {
            base.afterGrava();
            CD_TpVeiculo.Focus();
        }

        private void Nr_Veiculo_Leave(object sender, EventArgs e)
        {
           // Placa.Focus();
        }

        private void QTD_Caixas_ValueChanged(object sender, EventArgs e)
        {
            CD_TpVeiculo.Focus();
        }

        private void TFCadTransp_X_Veiculo_Load(object sender, EventArgs e)
        {
            panelDados4.BackColor = Utils.SettingsUtils.Default.COLOR_1;

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
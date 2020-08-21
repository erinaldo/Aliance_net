using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFCad_TpProduto : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TpProduto()
        {
            InitializeComponent();
            DTS = BS_CadTpProduto;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTpProduto.Grava_CadTpProduto(BS_CadTpProduto.Current as TRegistro_CadTpProduto, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTpProduto lista = TCN_CadTpProduto.Busca(TP_Produto.Text,
                                                              DS_TpProduto.Text,
                                                              string.Empty,
                                                              st_servico.Checked ? "S" : string.Empty,
                                                              st_composto.Checked ? "S" : string.Empty,
                                                              st_mprima.Checked ? "S" : string.Empty,
                                                              st_semente.Checked ? "S" : string.Empty,
                                                              st_mprimasemente.Checked ? "S" : string.Empty,
                                                              st_consumoInterno.Checked? "S" : string.Empty,
                                                              st_industrializado.Checked ? "S" : string.Empty,
                                                              st_patrimonio.Checked ? "S" : string.Empty,
                                                              null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadTpProduto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadTpProduto.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadTpProduto.AddNew();
                base.afterNovo();
                if (!TP_Produto.Focus())
                    DS_TpProduto.Focus();                         
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadTpProduto.RemoveCurrent();
        }
     
        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_TpProduto.Focus();
        }
      
        public override void excluirRegistro()
        {
            if (g_CadTpProduto.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTpProduto.Deleta_CadTpProduto(BS_CadTpProduto.Current as TRegistro_CadTpProduto, null);
                        BS_CadTpProduto.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void TFCad_TpProduto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_CadTpProduto);
            pDetalhes.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_TpProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_CadTpProduto);
        }

    }
}

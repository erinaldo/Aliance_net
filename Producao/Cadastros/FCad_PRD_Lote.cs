using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Producao.Cadastros;
using Utils;
using CamadaDados.Producao.Cadastros;

namespace Producao.Cadastros
{
    public partial class TFCad_PRD_Lote : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_PRD_Lote()
        {
            InitializeComponent();
            DTS = BS_Lote;
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
            return TCN_CadLote.Gravar(BS_Lote.Current as TRegistro_CadLote, null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(DateTime.Parse(dt_inivigencia.Text).Date > DateTime.Parse(dt_finvigencia.Text).Date)
                {
                    MessageBox.Show("Data final da vigencia não pode ser maior que data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                base.afterGrava();
            }
        }

        public override int buscarRegistros()
        {

            TList_CadLote lista = TCN_CadLote.Busca(Nr_loteproducao.Text, 
                                                    Ds_loteproducao.Text, 
                                                    0, 
                                                    Cd_loteID.Text, 
                                                    string.Empty,
                                                    null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Lote.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Lote.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            
                BS_Lote.AddNew();
                base.afterNovo();
                if (!Nr_loteproducao.Focus())
                    Ds_loteproducao.Focus();
            
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_Lote.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            Ds_loteproducao.Focus();

        }

        public override void excluirRegistro()
        {
            if (BS_Lote.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    DialogResult.Yes)
                    {
                        TCN_CadLote.Excluir(BS_Lote.Current as TRegistro_CadLote, null);
                        BS_Lote.RemoveCurrent();
                        pDados.LimparRegistro();

                    }
                }
            }
        }

        private void TFCad_PRD_Lote_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gLote_Producao);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_PRD_Lote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gLote_Producao);
        }
    }
}

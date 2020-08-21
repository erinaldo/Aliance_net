using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Utils;
using CamadaNegocio.Producao.Cadastros;
using CamadaDados.Producao.Cadastros;

namespace Producao.Cadastros
{
    public partial class TFCad_PRD_Custos : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_PRD_Custos()
        {
            InitializeComponent();
            DTS = bsCustos;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override string gravarRegistro()
        {
            return TCN_Cad_PRD_Custos.Gravar((bsCustos.Current as TRegistro_Cad_PRD_Custos), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }
 
        public override int buscarRegistros()
        {
            TList_Cad_PRD_Custos lista = TCN_Cad_PRD_Custos.Buscar(id_custo.Text, 
                                                                   ds_custoEditDefault.Text, 
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCustos.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCustos.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsCustos.AddNew();
                base.afterNovo();
                if (!id_custo.Focus())
                    ds_custoEditDefault.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCustos.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_custoEditDefault.Focus();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                TCN_Cad_PRD_Custos.Excluir((bsCustos.Current as TRegistro_Cad_PRD_Custos), null);
                pDados.LimparRegistro();
            }
        }

        private void TFCad_PRD_Custos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, tList_Cad_PRD_CustosDataGridDefault);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_PRD_Custos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, tList_Cad_PRD_CustosDataGridDefault);
        }
    }
}

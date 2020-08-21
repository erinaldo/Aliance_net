using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Estoque.Cadastros;
using Utils;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCad_TipoServico : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TipoServico()
        {
            InitializeComponent();
            DTS = BS_TipoServico;
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
                return TCN_CadTipoServico.Gravar(BS_TipoServico.Current as TRegistro_CadTipoServico, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTipoServico lista = TCN_CadTipoServico.Busca(id_tpservico.Text, DS_TPSERVICO.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TipoServico.DataSource = lista;

                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TipoServico.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_TipoServico.Clear();
                BS_TipoServico.AddNew();
                base.afterNovo();
                if(!id_tpservico.Focus())
                    DS_TPSERVICO.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_TipoServico.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo.Equals(TTpModo.tm_Edit))
                DS_TPSERVICO.Focus();
        }

        public override void excluirRegistro()
        {
            if (BS_TipoServico.Current != null)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTipoServico.Excluir(BS_TipoServico.Current as TRegistro_CadTipoServico, null);
                        BS_TipoServico.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void TFCad_TipoServico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Tipo_Servico);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_TipoServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Tipo_Servico);
        }
    }
}

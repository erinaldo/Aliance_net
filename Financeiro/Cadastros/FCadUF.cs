using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadUF : FormCadPadrao.FFormCadPadrao
    {
        public TFCadUF()
        {
            InitializeComponent();            
            DTS = BS_CadUf;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return  TCN_CadUf.GravarUf(BS_CadUf.Current as TRegistro_CadUf,null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadUf lista = TCN_CadUf.Buscar(uf.Text, cd_uf.Text, ds_uf.Text,"",0,null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadUf.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadUf.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                BS_CadUf.AddNew();
            base.afterNovo();
            uf.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            cd_uf.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadUf.RemoveCurrent();

        }

        private void TFCadUF_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadUF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}


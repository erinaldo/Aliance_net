using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadCategoriaCliFor : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCategoriaCliFor()
        {
            InitializeComponent();
            DTS = BS_CategoriaCliFor;
        }


        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCategoriaCliFor.Gravar((BS_CategoriaCliFor.Current as TRegistro_CadCategoriaCliFor), null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadCategoriaCliFor lista = TCN_CadCategoriaCliFor.Buscar(Id_CategoriaCliFor.Text, Ds_CategoriaCliFor.Text, "", 0, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CategoriaCliFor.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CategoriaCliFor.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CategoriaCliFor.AddNew();
                base.afterNovo();
                if (!Id_CategoriaCliFor.Focus())
                {
                    Ds_CategoriaCliFor.Focus();
                }

            }

        }

        public override void afterCancela()
        {
            base.afterCancela();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                Ds_CategoriaCliFor.Focus();
            }

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadCategoriaCliFor.Excluir(BS_CategoriaCliFor.Current as TRegistro_CadCategoriaCliFor, null);
                        BS_CategoriaCliFor.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        private void TFCadCategoriaCliFor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Pais);
            pFlag.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCategoriaCliFor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pais);
        }
    }
}

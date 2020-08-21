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
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using System.Collections;
using BancoDados;

namespace Commoditties.Cadastros
{
    public partial class TFCadTaxaDeposito : FormCadPadrao.FFormCadPadrao
    {
        
        public TFCadTaxaDeposito()
        {
            InitializeComponent();
            DTS = BS_TaxaDeposito;
        }


        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTaxaDeposito.GravarTaxaDeposito((BS_TaxaDeposito.Current as TRegistro_CadTaxaDeposito), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadTaxaDeposito lista;
            if (Tp_Taxa2.SelectedIndex > -1)
            {
                lista = TCN_CadTaxaDeposito.Buscar(id_taxa.Text, Ds_Taxa.Text, Tp_Taxa2.SelectedValue.ToString().Trim(), "", 0, null);
            }
            else {
                lista = TCN_CadTaxaDeposito.Buscar(id_taxa.Text, Ds_Taxa.Text, "", "", 0, null);
            }

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TaxaDeposito.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TaxaDeposito.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_TaxaDeposito.AddNew();
                base.afterNovo();

                Tp_Taxa2.Enabled = true;
                Ds_Taxa.Enabled = true;
                if (!(id_taxa.Focus()))
                    Ds_Taxa.Focus();
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
                Ds_Taxa.Focus();
                Tp_Taxa2.Enabled = true;
                Ds_Taxa.Enabled = true;
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
                    TCN_CadTaxaDeposito.DeletarTaxaDeposito(BS_TaxaDeposito.Current as TRegistro_CadTaxaDeposito, null);
                    if (BS_TaxaDeposito.Count>0)
                        BS_TaxaDeposito.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }


   
        private void TFCadTaxaDeposito_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox = new ArrayList();
            CBox.Add(new Utils.TDataCombo("Valor Monetário", "V"));
            CBox.Add(new Utils.TDataCombo("Percentual Sobre o Saldo de Produto", "P"));


            Tp_Taxa2.DataSource = CBox;
            Tp_Taxa2.DisplayMember = "Display";
            Tp_Taxa2.ValueMember = "Value";
            Tp_Taxa2.SelectedIndex = -1;
        }
    }
}

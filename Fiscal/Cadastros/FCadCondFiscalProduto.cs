using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadCondFiscalProduto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCondFiscalProduto()
        {
            InitializeComponent();
            DTS = bs_CondFiscalProduto;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadCondFiscalProduto lista = TCN_CadCondFiscalProduto.Busca(cd_condfiscal_produto.Text, ds_condfiscal_produto.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CondFiscalProduto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CondFiscalProduto.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bs_CondFiscalProduto.AddNew();
                base.afterNovo();
                if (!(cd_condfiscal_produto.Focus()))
                    ds_condfiscal_produto.Focus();
            }    
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_condfiscal_produto.Focus();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadCondFiscalProduto.DeletarCondFisProduto(bs_CondFiscalProduto.Current as TRegistro_CadCondFiscalProduto);
                    bs_CondFiscalProduto.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCondFiscalProduto.GravarCondFisProduto(bs_CondFiscalProduto.Current as TRegistro_CadCondFiscalProduto);
            else
                return "";
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bs_CondFiscalProduto.RemoveCurrent();
        }

        private void TFCadCondFiscalProduto_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.pDados.set_FormatZero();
        }
    }
}


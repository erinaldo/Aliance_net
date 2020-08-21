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
    public partial class TFCadObsFiscal : FormCadPadrao.FFormCadPadrao
    {
        public TFCadObsFiscal()
        {
            InitializeComponent();
            DTS = bs_cadObFiscal;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadObservacaoFiscal lista = TCN_CadObservacaoFiscal.Busca(cd_observacao.Text, ds_observacao.Text, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_cadObFiscal.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_cadObFiscal.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadObservacaoFiscal.gravarObFiscal(bs_cadObFiscal.Current as TRegistro_CadObservacaoFiscal);
            else
                return "";
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bs_cadObFiscal.AddNew();
                base.afterNovo();
                if (!(cd_observacao.Focus()))
                    DS_Sobre.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            DS_Sobre.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bs_cadObFiscal.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadObservacaoFiscal.deletarObFiscal(bs_cadObFiscal.Current as TRegistro_CadObservacaoFiscal);
                    bs_cadObFiscal.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadObsFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            this.pDados.set_FormatZero();
        }

        private void TFCadObsFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

    }
}


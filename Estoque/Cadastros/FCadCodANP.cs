using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFCadCodANP : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCodANP()
        {
            InitializeComponent();
            DTS = bsCodANP;
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
                return CamadaNegocio.Estoque.Cadastros.TCN_CodANP.Gravar(bsCodANP.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodANP, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Estoque.Cadastros.TList_CodANP lista =
                CamadaNegocio.Estoque.Cadastros.TCN_CodANP.Buscar(cd_anp.Text,
                                                                  ds_anp.Text,
                                                                  null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCodANP.DataSource = lista;

                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCodANP.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCodANP.AddNew();
                base.afterNovo();
                if (!cd_anp.Focus())
                    ds_anp.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCodANP.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_anp.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsCodANP.Current != null)
            {
                if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_CodANP.Excluir(bsCodANP.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodANP, null);
                        bsCodANP.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }
    }
}

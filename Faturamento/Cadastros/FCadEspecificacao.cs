using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFCadEspecificacao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadEspecificacao()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return CamadaNegocio.Faturamento.Cadastros.TCN_Especificacao.Gravar(
                    bsEspecificacao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Especificacao, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_Especificacao lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_Especificacao.Buscar(id_especificacao.Text,
                                                                             ds_especificacao.Text,
                                                                             null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEspecificacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsEspecificacao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsEspecificacao.AddNew();
                base.afterNovo();
                if (!id_especificacao.Focus())
                    ds_especificacao.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsEspecificacao.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_especificacao.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_Especificacao.Excluir(
                        bsEspecificacao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Especificacao, null);
                    bsEspecificacao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}

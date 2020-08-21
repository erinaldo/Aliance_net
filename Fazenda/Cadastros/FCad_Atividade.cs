using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class TFCad_Atividade : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Atividade()
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
                return CamadaNegocio.Fazenda.Cadastros.TCN_Atividade.Gravar(bsAtividade.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Atividade, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Atividade lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Atividade.Buscar(id_atividade.Text,
                                                                     ds_atividade.Text,
                                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsAtividade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsAtividade.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsAtividade.AddNew();
                base.afterNovo();
                if (!id_atividade.Focus())
                    ds_atividade.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsAtividade.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_atividade.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Atividade.Excluir(
                        bsAtividade.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Atividade, null);
                    bsAtividade.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_Atividade_Load(object sender, EventArgs e)
        {
            this.pDados.set_FormatZero();
        }
    }
}

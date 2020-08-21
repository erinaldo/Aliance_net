using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFCadRodado : FormCadPadrao.FFormCadPadrao
    {
        public TFCadRodado()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Rodado.Gravar(bsRodado.Current as TRegistro_Rodado, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Rodado lista = TCN_Rodado.Buscar(id_rodado.Text,
                                                     ds_rodado.Text,
                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsRodado.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                    bsRodado.Clear();
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
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsRodado.AddNew();
            base.afterNovo();
            if (!id_rodado.Focus())
                ds_rodado.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_rodado.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsRodado.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_Rodado.Excluir(bsRodado.Current as TRegistro_Rodado, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}

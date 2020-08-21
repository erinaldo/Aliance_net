using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Mudanca.Cadastros;
using CamadaNegocio.Mudanca.Cadastros;
using Utils;
using FormBusca;

namespace Mudanca.Cadastros
{
    public partial class TFCadServicos : FormCadPadrao.FFormCadPadrao
    {
        public TFCadServicos()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadServico.Gravar(bsCadServico.Current as TRegistro_CadServico, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadServico lista = TCN_CadServico.Buscar(id_servico.Text,
                                                           ds_servico.Text,
                                                           null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadServico.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCadServico.Clear();
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
                bsCadServico.AddNew();
            base.afterNovo();
            if (!id_servico.Focus())
                ds_servico.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_servico.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadServico.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadServico.Excluir(bsCadServico.Current as TRegistro_CadServico, null);
                    bsCadServico.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}

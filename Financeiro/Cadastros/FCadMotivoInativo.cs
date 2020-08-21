using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFCadMotivoInativo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMotivoInativo()
        {
            InitializeComponent();
        }

        public override int buscarRegistros()
        {
            TList_CadMotivoInativo lista = TCN_CadMotivoInativo.Buscar(ID_Motivo.Text, DS_Motivo.Text, 0, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMotivoInativo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        bsMotivoInativo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            base.afterNovo();
            bsMotivoInativo.AddNew();
            ID_Motivo.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsMotivoInativo.RemoveCurrent();
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
                        TCN_CadMotivoInativo.Deletar(bsMotivoInativo.Current as TRegistro_CadMotivoInativo, null);
                        bsMotivoInativo.RemoveCurrent();
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

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadMotivoInativo.Gravar(bsMotivoInativo.Current as TRegistro_CadMotivoInativo, null);
            else
                return string.Empty;
        }
    }
}

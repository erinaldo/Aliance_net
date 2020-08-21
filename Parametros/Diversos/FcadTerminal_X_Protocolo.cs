using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadTerminal_X_Protocolo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTerminal_X_Protocolo()
        {
            InitializeComponent();
            DTS = bsTerminal_X_Protocolo;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Terminal_X_Protocolo.Gravar(bsTerminal_X_Protocolo.Current as TRegistro_Terminal_X_Protocolo, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Terminal_X_Protocolo lista = TCN_Terminal_X_Protocolo.Buscar(CD_Terminal.Text,
                                                                               CD_Protocolo.Text,
                                                                               0,
                                                                               string.Empty,
                                                                               null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTerminal_X_Protocolo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTerminal_X_Protocolo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if (bsTerminal_X_Protocolo.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Terminal_X_Protocolo.Excluir(bsTerminal_X_Protocolo.Current as TRegistro_Terminal_X_Protocolo, null);
                        bsTerminal_X_Protocolo.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
            }
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                bsTerminal_X_Protocolo.AddNew();
            base.afterNovo();
            CD_Terminal.Focus();
        }

        public override void afterAltera()
        {
            if(this.vTP_Modo != TTpModo.tm_Insert)
                MessageBox.Show("Não existe campos para ser alterado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTerminal_X_Protocolo.RemoveCurrent();
        }

        private void CD_Terminal_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_terminal|=|'"+CD_Terminal.Text+"'",
                new Componentes.EditDefault[] {CD_Terminal,DS_Terminal}, new TCD_CadTerminal());
        }  

        private void CD_Protocolo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_protocolo|=|'"+CD_Protocolo.Text+"'",
                new Componentes.EditDefault[] {CD_Protocolo,DS_Protocolo},new TCD_CadProtocolo());        }

        private void BB_terminal_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("cd_terminal|Cód. Terminal|100;ds_terminal|Descrição Terminal|350",
                new Componentes.EditDefault[] { CD_Terminal, DS_Terminal }, new TCD_CadTerminal(), null);
        }   

        private void BB_protocolo_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("cd_protocolo|Cód. Protocolo|100;ds_protocolo|Descrição Protocolo|350",
                new Componentes.EditDefault[] {CD_Protocolo,DS_Protocolo},new TCD_CadProtocolo(), null);
        }
    }
}


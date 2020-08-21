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
    public partial class TFCadCartaoCredito : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCartaoCredito()
        {
            InitializeComponent();
        }

        public override int buscarRegistros()
        {
            TList_CadCartaoCredito lista = TCN_CadCartaoCredito.Buscar(ID_Cartao.Text, ID_Bandeira.Text, NR_Cartao.Text, NomeUsuario.Text, 0,"");
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCartaoCredito.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        bsCartaoCredito.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                base.afterNovo();
            bsCartaoCredito.AddNew();
            if (!ID_Cartao.Focus())
                ds_cartao.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_cartao.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCartaoCredito.RemoveCurrent();
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
                        TCN_CadCartaoCredito.Deletar(bsCartaoCredito.Current as TRegistro_CadCartaoCredito, null);
                        bsCartaoCredito.RemoveCurrent();
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
                return TCN_CadCartaoCredito.Gravar(bsCartaoCredito.Current as TRegistro_CadCartaoCredito, null);
            else
                return string.Empty;
        }

        private void bb_bandeira_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Bandeira|Descrição Bandeira|350;" +
                             "ID_Bandeira|Cód. Bandeira|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Bandeira, DS_Bandeira },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao(), "");
        }

        private void ID_Bandeira_Leave(object sender, EventArgs e)
        {
            string vParam = "id_bandeira|=|" + ID_Bandeira.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { ID_Bandeira, DS_Bandeira },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao());
        }

        private void bb_Usuario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Clifor|400";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NomeUsuario },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "");
        }

        private void TFCadCartaoCredito_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void TFCadCartaoCredito_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
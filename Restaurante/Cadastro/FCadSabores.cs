using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using Utils;
using CamadaNegocio.Restaurante.Cadastro;
using FormBusca;

namespace Restaurante.Cadastro
{
    public partial class FCadSabores : FormCadPadrao.FFormCadPadrao
    {
        public FCadSabores()
        {
            InitializeComponent();
        }
         
        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {

            if (pDados.validarCampoObrigatorio())
            {

                return TCN_Sabores.Gravar(bsSabores.Current as TRegistro_Sabores, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsSabores.AddNew();
            BB_GrupoProduto.Enabled = true;
            base.afterNovo();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_GrupoProduto.Enabled = false; 
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsSabores.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_Sabores lista = TCN_Sabores.Buscar(editDefault1.Text, editDefault2.Text ,CD_Grupo.Text,null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsSabores.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsSabores.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_Sabores.Excluir(bsSabores.Current as TRegistro_Sabores, null);
                    bsSabores.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void TFCadCFGEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F4))
                gravarRegistro();
        }

        private void pDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FCadSabores_Load(object sender, EventArgs e)
        {

        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }
    }
}

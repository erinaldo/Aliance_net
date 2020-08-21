using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using System.Windows.Forms;

namespace Restaurante.Cadastro
{
    public partial class FCadAdicional : FormCadPadrao.FFormCadPadrao
    {
        public FCadAdicional()
        {
            InitializeComponent();
        }

        private void FCadAdicional_Load(object sender, EventArgs e)
        {

        }

        public override string gravarRegistro()
        {

            if (pDados.validarCampoObrigatorio())
            {

                return TCN_Adicionais.Gravar(bsAdicionais.Current as TRegistro_Adicionais, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsAdicionais.AddNew();
            base.afterNovo();

        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsAdicionais.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_Adicionais lista = TCN_Adicionais.Buscar(editDefault5.Text, editDefault1.Text, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsAdicionais.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsAdicionais.Clear();
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
                    TCN_Adicionais.Excluir(bsAdicionais.Current as TRegistro_Adicionais, null);
                    bsAdicionais.RemoveCurrent();
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
        }

        private void pDados_Paint(object sender, PaintEventArgs e)
        {

        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            //string vparam = "a.st_motorista|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_grupo|Grupo|150;" +
                               "a.cd_grupo|Código|50",
                               new Componentes.EditDefault[] { editDefault5, editDefault6 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(),
                                string.Empty);
        }
         
        private void editDefault5_Leave_1(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_grupo|=|" + editDefault5.Text,
               new Componentes.EditDefault[] { editDefault5, editDefault6 },
              new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string vparam = "a.st_motorista|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_produto|Produto|150;" +
                               "a.cd_produto|Código|50",
                               new Componentes.EditDefault[] { editDefault1, editDefault2 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadProduto(),
                                string.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_grupo|=|" + editDefault5.Text,
               new Componentes.EditDefault[] { editDefault1, editDefault2 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string vparam = "a.st_motorista|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_grupo|Grupo|150;" +
                               "a.cd_grupo|Código|50",
                               new Componentes.EditDefault[] { editDefault3, editDefault4 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(),
                                string.Empty);
        }

        private void editDefault3_Leave(object sender, EventArgs e)
        {


            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_grupo|=|" + editDefault3.Text,
               new Componentes.EditDefault[] { editDefault3, editDefault4 },
              new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }
    }
}

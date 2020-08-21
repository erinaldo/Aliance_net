using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Estoque.Cadastros;

namespace Servicos.Cadastros
{
    public partial class TFCad_OSE_SerialClifor : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_OSE_SerialClifor()
        {
            InitializeComponent();
            DTS= BS_SerialClifor;
           

        }

        private void bb_Clifor_Click(object sender, EventArgs e)
        {
            if ((CD_Produto.Text != null)&&(CD_Produto.Text.Length>1)) {
 
            }
            string vParm = ""; 
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParm);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        public override string gravarRegistro()
        {
           if (pDados.validarCampoObrigatorio())
                return TCN_OSE_SerialClifor.Gravar_SerialClifor((BS_SerialClifor.Current as TRegistro_OSE_SerialClifor), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_OSE_SerialClifor lista = TCN_OSE_SerialClifor.Buscar("", NR_Serial.Text, CD_Clifor.Text,CD_Produto.Text, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_SerialClifor.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_SerialClifor.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_SerialClifor.AddNew();
                base.afterNovo();
                NR_Serial.Focus();

            }

        }

        public override void afterCancela()
        {
            base.afterCancela();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                NR_Serial.Focus();
            }
            else
            {
                CD_Produto.Focus();
            }
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_OSE_SerialClifor.Deletar_SerialClifor(BS_SerialClifor.Current as TRegistro_OSE_SerialClifor, null);
                    BS_SerialClifor.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_PRODUTO|Descrição PRODUTO|350;" +
                        "a.CD_PRODUTO|Cód. PRODUTO|100";

            string vParm = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto},
                                    new TCD_CadProduto (), vParm);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {

            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                    new TCD_CadProduto());


        }

        private void g_SerialClifor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TFCad_OSE_SerialClifor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_SerialClifor);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_OSE_SerialClifor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_SerialClifor);
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fazenda.Lancamento;
using CamadaNegocio.Fazenda.Lancamento;
using Utils;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Compra.Lancamento;
using CamadaDados.Diversos;

namespace Fazenda
{
    public partial class TFLanInsumos : FormPadrao.FFormPadrao
    {
        public TRegistro_LanInsumos reg_Insumo = new TRegistro_LanInsumos();
        private bool fechaNormal = false;

        public TFLanInsumos()
        {
            InitializeComponent();
            habilitarControls(true);
            pDados.set_FormatZero();
            BB_Gravar.Visible = true;
            BB_Cancelar.Visible = true;
            BB_Buscar.Visible = false;
            BS_Insumos.AddNew();
            Dt_Custo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ID_Requisicao.Focus();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
            ID_Requisicao.Focus();
            BS_Insumos.RemoveCurrent();
            BS_Insumos.AddNew();
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                fechaNormal = true;
                reg_Insumo = BS_Insumos.Current as TRegistro_LanInsumos;
                this.Dispose();
            }
        }

        public override void afterCancela()
        {
            fechaNormal = false;
            TFLanInsumos_FormClosing(this, null);
        }

        private void TFLanInsumos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fechaNormal)
            {
                reg_Insumo = null;
                if (MessageBox.Show("Deseja realmente cancelar a adição do insumo?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    fechaNormal = true;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        #region "FILTROS CAMPO DE BUSCA"

            private void bb_Requisicao_Click(object sender, EventArgs e)
            {/*
                string vColunas = "ID_Requisicao|Código Requisição|80;" +
                                  "a.cd_produto|Produto|350;" +
                                  "b.ds_produto|Produto|350;" +
                                  "f.cd_unidade|Cód. Unidade|80;" +
                                  "f.ds_unidade|Ds. Unidade|350;" +
                                  "Dt_Requisicao|Data Requisição|50;" +
                                  "gru.CD_Grupo|Cód. Grupo Produto|80;" +
                                  "gru.DS_Grupo|Grupo Produto|350";

                string vParam = "a.ST_Requisicao|=|'AP'";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Requisicao, Cd_Produto, CD_Unidade  },
                                        new TCD_LanCMP_Requisicao(), vParam);
                if (ID_Requisicao.Text != "")
                {
                    Cd_Produto.Enabled = false;
                    CD_Unidade.Enabled = false;
                    BB_Unidade.Enabled = false;
                    bbProduto.Enabled = false;
                    CD_Produto_Leave(this, e);
                    CD_Unidade_Leave(this, e);
                }
                else
                {
                    Cd_Produto.Enabled = true;
                    CD_Unidade.Enabled = true; 
                    BB_Unidade.Enabled = true;
                    bbProduto.Enabled = true;
                }*/
            }

            private void ID_Requisicao_Leave(object sender, EventArgs e)
            {/*
                string vColunas = "ID_Requisicao|=|'" + ID_Requisicao.Text + "';" +
                                  "a.ST_Requisicao|=|'AP'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Requisicao, CD_Unidade, Cd_Produto },
                                        new TCD_LanCMP_Requisicao());
                if (ID_Requisicao.Text != "")
                {
                    Cd_Produto.Enabled = false;
                    CD_Unidade.Enabled = false;
                    BB_Unidade.Enabled = false;
                    bbProduto.Enabled = false;
                    CD_Produto_Leave(this, e);
                    CD_Unidade_Leave(this, e);
                }
                else
                {
                    Cd_Produto.Enabled = true;
                    CD_Unidade.Enabled = true;
                    BB_Unidade.Enabled = true;
                    bbProduto.Enabled = true;
                }*/
            }

            private void BB_Produto_Click(object sender, EventArgs e)
            {
                string vParam = "e.st_servico|=|'N'; |EXISTS|(Select 1 from vtb_est_vlestoque s " +
                                 "where s.cd_produto = a.cd_produto)";
                UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_Produto, NM_Produto },vParam);
            }

            private void CD_Produto_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Produto|=|'" + Cd_Produto.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Cd_Produto, NM_Produto },
                                        new TCD_CadProduto());
            }

            private void BB_Unidade_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.DS_Unidade|Descrição Unidade|250;a.CD_Unidade|Cód. Unidade|100",
                                       new Componentes.EditDefault[] { CD_Unidade, DS_Unidade }, new TCD_CadUnidade(), null);
            }

            private void CD_Unidade_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Unidade|=|'" + CD_Unidade.Text + "'",
                                        new Componentes.EditDefault[] { CD_Unidade, DS_Unidade }, new TCD_CadUnidade());
            }

            private void bb_local_Click(object sender, EventArgs e)
            {
                string vColunas = "c.DS_Local|Local Armazenagem|350;" +
                                  "a.CD_Local|Cód. Local|80";
                
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, NM_Local },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(), "");
            }

            private void CD_Local_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.cd_local|=|'" + CD_Local.Text.Trim() + "'";

                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, NM_Local },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa());
            }

        #endregion

            private void TFLanInsumos_Load(object sender, EventArgs e)
            {
                panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }

    }
}

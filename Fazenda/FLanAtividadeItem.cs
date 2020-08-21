using System;
using CamadaDados.Fazenda.Lancamento;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Fazenda.Lancamento;
using Utils;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace Fazenda
{
    public partial class TFLanAtividadeItem : FormPadrao.FFormPadrao
    {
        public TRegistro_LanAtividade reg_Atividade = new TRegistro_LanAtividade();
        public TRegistro_LanAtividade_Item reg_Atividade_Item = new TRegistro_LanAtividade_Item();
        private bool fechaNormal = false;

        public TFLanAtividadeItem()
        {
            InitializeComponent();
            habilitarControls(true);
            pDados.set_FormatZero();
            BB_Gravar.Visible = true;
            BB_Cancelar.Visible = true;
            BB_Buscar.Visible = false;
            BS_Item.AddNew();
            Dt_Custo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ID_Atividade.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
            ID_Atividade.Focus();
            BS_Item.RemoveCurrent();
            BS_Item.AddNew();
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                fechaNormal = true;
                reg_Atividade_Item = BS_Item.Current as TRegistro_LanAtividade_Item;
                this.Dispose();
            }
        }

        public override void afterCancela()
        {
            fechaNormal = false;
            TFLanAtividadeItem_FormClosing(this, null);
        }

        private void BB_Equipamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Equipamento|Descrição Equipamento|250;a.ID_Equip|Cód. Equipamento|100";
            string vParam = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Equip, DS_Equipamento }, new TCD_CadEquipamento(), vParam);
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Unidade|Descrição Unidade|250;a.CD_Unidade|Cód. Unidade|100",
                                   new Componentes.EditDefault[] { CD_Unidade, DS_Unidade }, new TCD_CadUnidade(), null);
        }

        private void ID_Atividade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_atividade|=|'" + ID_Atividade.Text + "'",
                                    new Componentes.EditDefault[] { ID_Atividade, DS_Atividade }, new TCD_CadAtividade());
        }

        private void ID_Equip_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_Equip|=|'" + ID_Equip.Text + "'",
                                    new Componentes.EditDefault[] { ID_Equip, DS_Equipamento }, new TCD_CadEquipamento());
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Unidade|=|'" + CD_Unidade.Text + "'",
                                    new Componentes.EditDefault[] { CD_Unidade, DS_Unidade }, new TCD_CadUnidade());
        }

        private void CD_CCusto_Leave(object sender, EventArgs e)
        {
            if (CD_CCusto.Text.Trim() != "" && reg_Atividade.CD_CCusto != "")
            {
                string vColunas = CD_CCusto.NM_Alias + "." + CD_CCusto.NM_CampoBusca + "|=|" + CD_CCusto.Text + ";";
                vColunas += "a.CD_CCusto_Pai|=|'" + reg_Atividade.CD_CCusto + "'"; ;

                if (ID_Atividade.Text != "")
                    vColunas += ") OR (EXISTS (SELECT * FROM TB_FAZ_Ativ_X_CCusto x " +
                                  "INNER JOIN TB_FIN_CentroCusto w ON x.CD_CCusto = w.CD_CCusto " +
                                  "WHERE x.ID_Atividade = '" + ID_Atividade.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas,
                                    new Componentes.EditDefault[] { CD_CCusto, Ds_CCusto },
                                    new TCD_CadCentroCusto("SqlCodeBuscaRecursiva"));
            }
            else
                CD_CCusto.Clear();

        }

        private void BB_CCusto_Click(object sender, EventArgs e)
        {
            if (reg_Atividade.CD_CCusto != "")
            {
                string vColunas = "a.DS_CCusto|Centro de Custo|350;" +
                               "a.CD_CCusto|Cód. CCusto|100;" +
                               "a.Tp_CCusto|Tp. Custo|80";

                string vParamFixo = "a.CD_CCusto_Pai|=|'" + reg_Atividade.CD_CCusto + "'";

                if (ID_Atividade.Text != "")
                    vParamFixo += ") OR (EXISTS (SELECT * FROM TB_FAZ_Ativ_X_CCusto x " +
                                  "INNER JOIN TB_FIN_CentroCusto w ON x.CD_CCusto = w.CD_CCusto " +
                                  "WHERE x.ID_Atividade = '" + ID_Atividade.Text + "')";

                UtilPesquisa.BTN_BUSCA(vColunas,
                                    new Componentes.EditDefault[] { CD_CCusto, Ds_CCusto },
                                    new TCD_CadCentroCusto("SqlCodeBuscaRecursiva"), vParamFixo);
            }
        }

        private void BB_Atividade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Atividade|Atividade|250;a.ID_Atividade|Cód. Atividade|100";
            string vParam = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Atividade, DS_Atividade }, new TCD_CadAtividade(), vParam);
        }

        private void TFLanAtividadeItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //reg_item = null;
        }

        private void TFLanAtividadeItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fechaNormal)
            {
                reg_Atividade_Item = null;
                if (MessageBox.Show("Deseja realmente cancelar a adição do item da atividade?", "Mensagem",
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
    }
}

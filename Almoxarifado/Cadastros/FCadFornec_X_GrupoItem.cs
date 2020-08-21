using System;
using Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using FormBusca;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Estoque.Cadastros;

namespace Almoxarifado.Cadastros
{
    public partial class FCadFornec_X_GrupoItem : FormCadPadrao.FFormCadPadrao
    {
        public FCadFornec_X_GrupoItem()
        {
            InitializeComponent();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("cd_clifor|Código Clifor|100;nm_clifor|Nome Clifor|350"
                , new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new TCD_CadClifor(), null);
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.cd_grupo|Código Grupo|100;a.ds_grupo|Descrição Grupo|350"
                , new Componentes.EditDefault[] { cd_grupo, ds_grupo }, new TCD_CadGrupoProduto(), null);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_clifor|=|'" + cd_clifor.Text + "'", new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new TCD_CadClifor());
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_grupo|=|'" + cd_grupo.Text + "'", new Componentes.EditDefault[] { cd_grupo, ds_grupo }, new TCD_CadGrupoProduto());
        }

        //validação para que os campos recebam apenas numeros
        private void cd_clifor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //validação para que os campos recebam apenas numeros
        private void cd_grupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bs_cliforGrupo.AddNew();
                base.afterNovo();
                cd_clifor.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                cd_clifor.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bs_cliforGrupo.RemoveCurrent();
            cd_clifor.Focus();
        }

        public override int buscarRegistros()
        {
            TList_CadFornec_X_GrupoItem lista = TCN_CadFornec_X_GrupoItem.Busca(cd_clifor.Text.Trim(), cd_grupo.Text.Trim());
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_cliforGrupo.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_cliforGrupo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadFornec_X_GrupoItem.gravarGrupoItem(bs_cliforGrupo.Current as TRegistro_CadFornec_X_GrupoItem);
            else
                return "";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void excluirRegistro()
        {
            if (bs_cliforGrupo.DataSource != null)
            {
                try
                {
                    if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    {
                        if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            TCN_CadFornec_X_GrupoItem.deletarGrupoItem(bs_cliforGrupo.Current as TRegistro_CadFornec_X_GrupoItem);
                            bs_cliforGrupo.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Não existem itens cadastrados", "Mensagem");
                }
            }
        }

        private void FCadFornec_X_GrupoItem_Load(object sender, EventArgs e)
        {
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

    }
}

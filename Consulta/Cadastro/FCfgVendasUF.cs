using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consulta.Cadastro
{
    public partial class TFCfgVendasUF : FormCadPadrao.FFormCadPadrao
    {
        public TFCfgVendasUF()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("TANQUE", "T"));
            cbx.Add(new Utils.TDataCombo("PERIFERICOS", "P"));
            cbxTp_Visao.DataSource = cbx;
            cbxTp_Visao.DisplayMember = "Display";
            cbxTp_Visao.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Consulta.Cadastro.TCN_CfgVendasUF.Grava(
                    bsCfgVendasUF.Current as CamadaDados.Consulta.Cadastro.TRegistro_CfgVendasUF, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Consulta.Cadastro.TList_CfgVendasUF lista =
                CamadaNegocio.Consulta.Cadastro.TCN_CfgVendasUF.Busca(CD_Grupo.Text,
                                                                          DS_Grupo.Text,
                                                                          string.Empty,
                                                                          null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgVendasUF.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                    bsCfgVendasUF.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCfgVendasUF.AddNew();
                base.afterNovo();
                CD_Grupo.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgVendasUF.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_GrupoProduto.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                CD_Grupo.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Consulta.Cadastro.TCN_CfgVendasUF.Deleta(
                        bsCfgVendasUF.Current as CamadaDados.Consulta.Cadastro.TRegistro_CfgVendasUF, null);
                    bsCfgVendasUF.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                             "a.CD_Grupo|Cód. Grupo|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }
    }
}

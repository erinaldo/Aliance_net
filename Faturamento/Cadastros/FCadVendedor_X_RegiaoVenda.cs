using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Diversos;

namespace Faturamento.Cadastros
{
    public partial class TFCadVendedor_X_RegiaoVenda : FormCadPadrao.FFormCadPadrao
    {
        public TFCadVendedor_X_RegiaoVenda()
        {
            InitializeComponent();
            DTS = BS_CadVendedor_X_RegiaoVenda;
        }
      
        public override void formatZero()
        {
            pDados.set_FormatZero();           
        }
        
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadVendedor_X_RegiaVenda.GravaVendedor_X_RegiaoVenda(BS_CadVendedor_X_RegiaoVenda.Current as TRegistro_CadVendedor_X_RegiaoVenda);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            BB_Alterar.Visible = false;
            TList_CadVendedor_X_RegiaoVenda lista = TCN_CadVendedor_X_RegiaVenda.Busca(ID_Regiao.Text, CD_Vendedor.Text, cd_tabelapreco_padrao.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                    BS_CadVendedor_X_RegiaoVenda.DataSource = lista;
                return lista.Count;
            }
            return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadVendedor_X_RegiaoVenda.AddNew();
                base.afterNovo();
                CD_Vendedor.Focus();
                
            }
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_CadVendedor_X_RegiaoVenda.RemoveCurrent();
            base.afterCancela();
        }

        public override void afterAltera()
        {

            base.afterAltera();
            cd_tabelapreco_padrao.Enabled=true;
            BB_Regiao.Enabled = false;
            BB_Vendedor.Enabled = false;
            cd_tabelapreco_padrao.Focus();
        }

        public override void excluirRegistro()
        {
            if (BS_CadVendedor_X_RegiaoVenda.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadVendedor_X_RegiaVenda.DeletaVendedor_X_RegiaoVenda((BS_CadVendedor_X_RegiaoVenda.Current as TRegistro_CadVendedor_X_RegiaoVenda));
                        BS_CadVendedor_X_RegiaoVenda.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_Vendedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.cd_vendedor|Código Vendedor|60;b.nomevendedor|Nome|120"
                , new Componentes.EditDefault[] { CD_Vendedor, nomevendedor }, new TCD_CadVendedor(), null);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Vendedor|=|'" + CD_Vendedor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Vendedor, nomevendedor },
                                    new TCD_CadVendedor());

        }
        
        private void BB_Regiao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("id_regiao|Código Região|60;c.nm_regiao|Nome Região|120"
                , new Componentes.EditDefault[] { ID_Regiao, nm_regiao }, new TCD_CadRegiaoVenda(), null);
        }

       
        
        private void bb_cd_tabelaPreco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("cd_tabelapreco|Código Tabela de Preço|60;d.ds_tabelapreco|Descrição da Tabela|120"
                , new Componentes.EditDefault[] { cd_tabelapreco_padrao, ds_tabelapreco }, new TCD_CadTbPreco(), null);
        }

        private void cd_tabelapreco_padrao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_TabelaPreco|=|'" + cd_tabelapreco_padrao.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_tabelapreco_padrao, ds_tabelapreco }, new TCD_CadTbPreco());
        }

        private void id_regiao_Leave(object sender, EventArgs e)
        {
            string vColunas = "Id_Regiao|=|'" + ID_Regiao.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Regiao, nm_regiao },
                                    new TCD_CadRegiaoVenda());
        }

        private void TFCadVendedor_X_RegiaoVenda_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        
        
    }

}
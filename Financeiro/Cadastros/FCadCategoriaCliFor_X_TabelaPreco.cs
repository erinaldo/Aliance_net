using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Diversos;


namespace Financeiro.Cadastros
{
    public partial class TFCadCategoriaCliFor_X_TabelaPreco : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCategoriaCliFor_X_TabelaPreco()
        {
            InitializeComponent();
            DTS = bsCategoriaCliFor_X_TabelaPreco;
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
                if(Utils.Parametros.ST_BANCO_DataCenter)
                {
                    try
                    {
                        CamadaServico.IService servico = CamadaServico.TCanal.CriarCanal();
                        return servico.GravaCategoriaCliFor_X_TabelaPreco(bsCategoriaCliFor_X_TabelaPreco.Current as TRegistro_CategoriaCliFor_X_TabelaPreco,
                            new CFGBanco()
                            {
                                Nm_bancoDados = Utils.Parametros.pubNM_BancoDados,
                                Nm_servidor = Utils.Parametros.pubNM_Servidor,
                                Nm_login = Utils.Parametros.pubLogin
                            });
                    }
                    finally
                    {
                        CamadaServico.TCanal.FecharCanal();
                    }
                }
                else
                    return TCN_CadCategoriaCliFor_X_TabelaPreco.GravaCategoriaCliFor_X_TabelaPreco((bsCategoriaCliFor_X_TabelaPreco.Current as TRegistro_CategoriaCliFor_X_TabelaPreco), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_RegCategoriaCliFor_X_TabelaPreco lista = TCN_CadCategoriaCliFor_X_TabelaPreco.Busca(Cd_TabelaPreco.Text, Id_CategoriaCliFor.Text, 0, "", null);
            if (lista != null)
            {
                if (lista.Count > 0)
                    bsCategoriaCliFor_X_TabelaPreco.DataSource = lista;
                this.Lista = lista;
                return lista.Count;

            }
            else
            {
                bsCategoriaCliFor_X_TabelaPreco.Clear();
            }
            return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsCategoriaCliFor_X_TabelaPreco.AddNew();
                base.afterNovo();
                Cd_TabelaPreco.Focus();
            }
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsCategoriaCliFor_X_TabelaPreco.RemoveCurrent();
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_tabela_preco.Enabled = false;
                bb_categoriaclifor.Enabled = false;
            }
        }


        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (Utils.Parametros.ST_BANCO_DataCenter)
                        {
                            try
                            {
                                CamadaServico.IService servico = CamadaServico.TCanal.CriarCanal();
                                servico.DeletaCategoriaCliFor_X_TabelaPreco((bsCategoriaCliFor_X_TabelaPreco.Current as TRegistro_CategoriaCliFor_X_TabelaPreco),
                                    new CFGBanco()
                                    {
                                        Nm_bancoDados = Utils.Parametros.pubNM_BancoDados,
                                        Nm_servidor = Utils.Parametros.pubNM_Servidor,
                                        Nm_login = Utils.Parametros.pubLogin
                                    });
                            }
                            finally
                            {
                                CamadaServico.TCanal.FecharCanal();
                            }
                        }
                        else
                            TCN_CadCategoriaCliFor_X_TabelaPreco.DeletaCategoriaCliFor_X_TabelaPreco((bsCategoriaCliFor_X_TabelaPreco.Current as TRegistro_CategoriaCliFor_X_TabelaPreco), null);
                        bsCategoriaCliFor_X_TabelaPreco.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void bb_tabela_preco_Click(object sender, EventArgs e)
        {

            string vColunas =
                  "a.Ds_TabelaPreco|Tabela Preço|350;"
                  +
                  "a.Cd_TabelaPreco|Cód. Preço|100";

            string vParamFixo = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_TabelaPreco, Ds_TabelaPreco },
             new TCD_CadTbPreco(), vParamFixo);


        }
        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas =
                  "a.Ds_CategoriaCliFor|Categoria|350;"
                  +
                  "a.Id_CategoriaCliFor|Cód. Categoria|100";

            string vParamFixo = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_CategoriaCliFor, Ds_CategoriaCliFor },
             new TCD_CadCategoriaCliFor(), vParamFixo);

        }

        private void Cd_Tabela_Preco_Leave(object sender, EventArgs e)
        {
            string vColunas = "Cd_TabelaPreco|=|" + Cd_TabelaPreco.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Cd_TabelaPreco, Ds_TabelaPreco },
                                    new TCD_CadTbPreco());
        }

        private void Id_CategoriaCliFor_Leave(object sender, EventArgs e)
        {
            string vColunas = "Id_CategoriaCliFor|=|" + Id_CategoriaCliFor.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Id_CategoriaCliFor, Ds_CategoriaCliFor },
                                    new TCD_CadCategoriaCliFor());
        }



        private void FCadCategoriaCliFor_X_TabelaPreco_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void tList_RegCadCategoriaCliFor_X_TabelaPrecoDataGridDefault_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cd_Tabela_Preco_TextChanged(object sender, EventArgs e)
        {

        }


      

    }
}

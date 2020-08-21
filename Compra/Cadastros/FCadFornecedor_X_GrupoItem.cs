using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Compra;
using CamadaNegocio.Compra;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;
using FormBusca;

namespace Compra.Cadastros
{
    public partial class TFCadFornecedor_X_GrupoItem : FormCadPadrao.FFormCadPadrao
    {
        public TFCadFornecedor_X_GrupoItem()
        {
            InitializeComponent();
            DTS = Bs_FornecedorXGrupoItem;
        }

        public override int buscarRegistros()
        {
            TList_Cad_Fornecedor_X_GrupoItem lista = TCN_Cad_Fornecedor_X_GrupoItem.Busca(cd_Clifor.Text,
                                                                                          cd_grupo.Text,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_FornecedorXGrupoItem.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_FornecedorXGrupoItem.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                Bs_FornecedorXGrupoItem.AddNew();
                base.afterNovo();
                cd_Clifor.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_Clifor.Enabled = false;
                bb_grupo.Enabled = false;
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                Bs_FornecedorXGrupoItem.RemoveCurrent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return TCN_Cad_Fornecedor_X_GrupoItem.GravaFornecedor_X_GrupoItem(Bs_FornecedorXGrupoItem.Current as TRegistro_Cad_Fornecedor_X_GrupoItem, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            else
                return string.Empty;
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
                        TCN_Cad_Fornecedor_X_GrupoItem.DeletaFornecedor_X_GrupoItem(Bs_FornecedorXGrupoItem.Current as TRegistro_Cad_Fornecedor_X_GrupoItem, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    Bs_FornecedorXGrupoItem.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_Clifor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            if(cd_grupo.Text.Trim() != string.Empty)
                vParam += ";|not exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                          "where x.cd_clifor = a.cd_clifor " +
                          "and x.cd_grupo = '" + cd_grupo.Text.Trim() + "')";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_Clifor, Nm_Clifor }, vParam);
        }

        private void cd_Clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_Clifor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            if(cd_grupo.Text.Trim() != string.Empty)
                vParam += ";|not exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                          "where x.cd_clifor = a.cd_clifor " +
                          "and x.cd_grupo = '" + cd_grupo.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_Clifor, Nm_Clifor }, new TCD_CadClifor());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80;" +
                              "a.tp_grupo|TP. Grupo|80";
            string vParam = "a.tp_grupo|=|'A'";
            if (cd_Clifor.Text.Trim() != string.Empty)
                vParam += ";|not exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                          "where x.cd_grupo = a.cd_grupo " +
                          "and x.cd_clifor = '" + cd_Clifor.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                new TCD_CadGrupoProduto(), vParam);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "a.tp_grupo|=|'A'";
            if(cd_Clifor.Text.Trim() != string.Empty)
                vParam += ";|not exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                          "where x.cd_grupo = a.cd_grupo " +
                          "and x.cd_clifor = '" + cd_Clifor.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                            new TCD_CadGrupoProduto());
        }

        private void TFCadFornecedor_X_GrupoItem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
        }

        private void TFCadFornecedor_X_GrupoItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}

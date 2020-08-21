using System;
using System.ComponentModel;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFCad_TaxaBandeira : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TaxaBandeira()
        {
            InitializeComponent();
        }

        public override int buscarRegistros()
        {
            TList_Cad_TaxaBandeiraCartao lista = TCN_Cad_TaxaBandeiraCartao.Buscar(ID_Bandeira.Text, 
                                                                                   cd_empresa.Text, 
                                                                                   id_maquina.Text,
                                                                                   CD_ContaGer.Text, 
                                                                                   0, 
                                                                                   string.Empty, 
                                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    Lista = lista;
                    bsTaxaBandeira.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        bsTaxaBandeira.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsTaxaBandeira.AddNew();
                base.afterNovo();
                if (!cd_empresa.Focus())
                    ID_Bandeira.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTaxaBandeira.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
                {
                    try
                    {
                        TCN_Cad_TaxaBandeiraCartao.Deletar(bsTaxaBandeira.Current as TRegistro_Cad_TaxaBandeiraCartao, null);
                        bsTaxaBandeira.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_taxa.Focused)
                    (bsTaxaBandeira.Current as TRegistro_Cad_TaxaBandeiraCartao).Pc_taxa = pc_taxa.Value;
                return TCN_Cad_TaxaBandeiraCartao.Gravar(bsTaxaBandeira.Current as TRegistro_Cad_TaxaBandeiraCartao, null);
            }
            else
                return string.Empty;
        }

        private void TFCad_TaxaBandeira_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTaxaBandeira);
            pDados.set_FormatZero();
        }

        private void TFCad_TaxaBandeira_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTaxaBandeira);
        }

        private void gTaxaBandeira_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTaxaBandeira.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTaxaBandeira.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Cad_TaxaBandeiraCartao());
            TList_Cad_TaxaBandeiraCartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTaxaBandeira.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTaxaBandeira.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Cad_TaxaBandeiraCartao(lP.Find(gTaxaBandeira.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTaxaBandeira.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Cad_TaxaBandeiraCartao(lP.Find(gTaxaBandeira.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTaxaBandeira.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTaxaBandeira.DataSource as TList_Cad_TaxaBandeiraCartao).Sort(lComparer);
            bsTaxaBandeira.ResetBindings(false);
            gTaxaBandeira.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_bandeira_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Bandeira|Descrição Bandeira|350;" +
                             "a.ID_Bandeira|Cód. Bandeira|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Bandeira, DS_Bandeira },
                                    new TCD_Cad_BandeiraCartao(), "");
        }

        private void ID_Bandeira_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bandeira|=|" + ID_Bandeira.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { ID_Bandeira, DS_Bandeira },
                                    new TCD_Cad_BandeiraCartao());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text + "';" +
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_ContaGer_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "isnull(a.cd_banco, '')|<>|'';" +
                            "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                            "a.st_contacartao|=|1;" +
                            "a.st_contacf|=|1";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new TCD_CadContaGer(), vParam);
        }

        private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + CD_ContaGer.Text.Trim() + "';" +
                            "isnull(a.cd_banco, '')|<>|'';" +
                            "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                            "a.st_contacartao|=|1;" +
                            "a.st_contacf|=|1";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new TCD_CadContaGer());
        }

        private void bbmaquina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_maquina|Maquina|200;" +
                              "a.id_maquina|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_maquina, ds_maquina }, new TCD_CadMaquinaCartao(), string.Empty);
        }

        private void id_maquina_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_maquina|=|" + id_maquina.Text, new Componentes.EditDefault[] { id_maquina, ds_maquina }, new TCD_CadMaquinaCartao());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;

namespace Balanca.Classificacao
{
    public partial class TFProdutoDerivado : Form
    {
        Utils.TTpModo vModo;

        public TFProdutoDerivado()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert))
                if (MessageBox.Show("Quantidade de bolsas do ticket Nº" + id_ticket.Text + " não foi salva.\r\n" +
                                   "Deseja salvar as informações?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.afterGrava();
                    return;
                }
            bs_PesagemGraos.Clear();
            Placa.Focus();
            this.vModo = Utils.TTpModo.tm_Insert;
        }

        private void afterGrava()
        {
            if (bs_PesagemGraos.Current != null)
            {
                TCN_ProdutoDerivado.Gravar(bs_PesagemGraos.Current as TRegistro_LanPesagemGraos, null);
                MessageBox.Show("Produtos Derivados gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.vModo = Utils.TTpModo.tm_Standby;
                this.afterNovo();
            }
        }

        private void BuscarProdDeriv()
        {
            if (bs_PesagemGraos.Current != null)
            {
                (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).lProdutoDerivado =
                    new CamadaDados.Balanca.TCD_ProdutoDerivado().SelectProdDeriv(
                    (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr,
                    (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                    (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                    (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString());
                bs_PesagemGraos.ResetCurrentItem();
                qtd_bolsas.Focus();
            }
        }

        private void TFProdutoDerivado_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            vModo = Utils.TTpModo.tm_Standby;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProdutoDerivado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
        }

        private void BB_Avancar_Click(object sender, EventArgs e)
        {
            (bsProdutoDerivado.Current as CamadaDados.Balanca.TRegistro_ProdutoDerivado).Qtd_embalagem = qtd_bolsas.Value;
            bsProdutoDerivado.MoveNext();
        }

        private void BB_Voltar_Click(object sender, EventArgs e)
        {
            (bsProdutoDerivado.Current as CamadaDados.Balanca.TRegistro_ProdutoDerivado).Qtd_embalagem = qtd_bolsas.Value;
            bsProdutoDerivado.MovePrevious();
        }

        private void BB_Placa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.placaCarreta|Placa|80;" +
                      "a.NM_TPPesagem|TP. Pesagem|150;" +
                      "l.DS_TabelaDesconto|Tab. Desconto|150;" +
                      "a.ID_Ticket|Id. Ticket|80;" +
                      "a.NM_Empresa|Cód. Empresa|150;" +
                      "b.DS_Moega|Cód. Moega|150";
            string vParamFixo = "isnull(a.ST_Registro, 'A')|in|('A', 'R');" +//Pesagem Aberta ou Refugada
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Placa }, new TCD_LanPesagemGraos(),
                                    vParamFixo);
            Placa_Leave(this, new EventArgs());
        }

        private void Placa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Placa.Text))
            {
                TList_RegLanPesagemGraos ListaPlaca = TCN_LanPesagemGraos.Busca(string.Empty, 
                                                                                string.Empty, 
                                                                                string.Empty, 
                                                                                Placa.Text, 
                                                                                "'A', 'R'",//Aberto ou Refugado 
                                                                                string.Empty, 
                                                                                Utils.Parametros.pubLogin, 
                                                                                string.Empty, 
                                                                                0,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1, 
                                                                                string.Empty, null);

                if (ListaPlaca.Count > 0)
                {
                    bs_PesagemGraos.DataSource = ListaPlaca;
                    this.BuscarProdDeriv();
                }
            }
        }

        private void qtd_bolsas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                (bsProdutoDerivado.Current as CamadaDados.Balanca.TRegistro_ProdutoDerivado).Qtd_embalagem = qtd_bolsas.Value;
                bsProdutoDerivado.MoveNext();
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                (bsProdutoDerivado.Current as CamadaDados.Balanca.TRegistro_ProdutoDerivado).Qtd_embalagem = qtd_bolsas.Value;
                bsProdutoDerivado.MovePrevious();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFProdutoDerivado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.vModo.Equals(Utils.TTpModo.tm_Insert))
                if (MessageBox.Show("Quantidade de bolsas do ticket Nº" + id_ticket.Text + " não foi salva.\r\n" +
                                   "Deseja salvar as informações?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    this.afterGrava();
        }

        private void label20_TextChanged(object sender, EventArgs e)
        {
            if (label20.Text.Trim().ToUpper().Equals("ABERTO"))
                label20.ForeColor = Color.Blue;
            else if (label20.Text.Trim().ToUpper().Equals("REFUGADO"))
                label20.ForeColor = Color.Red;
        }

        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProdutoDerivado.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_ProdutoDerivado());
            TList_ProdutoDerivado lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_ProdutoDerivado(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_ProdutoDerivado(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProdutoDerivado.List as TList_ProdutoDerivado).Sort(lComparer);
            bsProdutoDerivado.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}

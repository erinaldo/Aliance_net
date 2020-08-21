using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using Querys.Faturamento;
using Querys.LanPesagem;

namespace Balanca
{
    public partial class TFLanNotasPesagem : Form
    {
        #region "Atributos"

        private DataTable vTabela;
        private DataTable vTabAux;
        private bool vST_ControlarDesdobro;
        private string vCD_Empresa;
        private decimal vID_Ticket;
        private string vTP_Pesagem;
        private decimal vID_Desdobro;
        private int vQTD_Desdobro;
        #endregion

        #region "Propriedades"

        public DataTable tabela { get { return vTabAux; } }
        public bool ST_ControlarDesdobro { get { return vST_ControlarDesdobro; } set { vST_ControlarDesdobro = value; } }
        public string CD_Empresa { get { if (vCD_Empresa == null)return ""; else return vCD_Empresa; } set { vCD_Empresa = value; } }
        public decimal ID_Ticket { get { return vID_Ticket; } set { vID_Ticket = value; } }
        public string TP_Pesagem { get { if (vTP_Pesagem == null)return ""; else return vTP_Pesagem; } set { vTP_Pesagem = value; } }
        public decimal ID_Desdobro { get { return vID_Desdobro; } set { vID_Desdobro = value; } }
        public int QTD_Desdobro { get { return vQTD_Desdobro; } set { vQTD_Desdobro = value; } }
        #endregion
        //
        //Construtor
        //
        public TFLanNotasPesagem()
        {
            InitializeComponent();
            vQTD_Desdobro = 0;
        }
        //
        //Metodos
        //
        private void afterNovo()
        {
            if (vQTD_Desdobro < Convert.ToInt32(qtd_desdobro.Text))
            {
                pDados.LimparRegistro();
                nr_notafiscal.Focus();
            }
            else
                MessageBox.Show("Numero máximo de desdobro ja informado.",
                                "Mensagem", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        private void afterGrava()
        {
            if (nr_notafiscal.Text == "")
            {
                MessageBox.Show("Campo Obrigatório.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_notafiscal.Focus();
                return;
            }
            if (nr_serie.Text == "")
            {
                MessageBox.Show("Campo Obrigatório.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_serie.Focus();
                return;
            }
            try
            {
                object[] chave = new object[] { nr_notafiscal.Text, nr_serie.Text };
                if (vTabela.Rows.Contains(chave))
                {
                    DataRow linha = vTabela.Rows.Find(chave);
                    string vID_Desdobro = linha["ID_Desdobro"].ToString();
                    string vID_Item = linha["ID_Item"].ToString();
                    vTabela.Rows.Remove(linha);
                    linha["NR_Notafiscal"] = nr_notafiscal.Text;
                    linha["NR_Serie"] = nr_serie.Text;
                    linha["ID_Desdobro"] = vID_Desdobro;
                    linha["ID_Item"] = vID_Item;
                    linha["PC_Desdobro"] = pc_desdobro.Value.ToString();
                    linha["DT_Emissao"] = dt_emissao.Text;
                    linha["QTD_Nota"] = qtd_nota.Value.ToString();
                    linha["Vl_Unitario"] = vl_unitario.Value.ToString();
                    linha["Vl_SubTotal"] = vl_subtotal.Value.ToString();
                    linha["Vl_BaseCalc"] = vl_basecalc.Value.ToString();
                    linha["Vl_ICMS"] = vl_icms.Value.ToString();
                    linha["ST_Registro"] = "A";
                    vTabela.Rows.Add(linha);
                }
                else
                {
                    DataRow linha = vTabela.NewRow();
                    linha["NR_Notafiscal"] = nr_notafiscal.Text;
                    linha["NR_Serie"] = nr_serie.Text;
                    linha["PC_Desdobro"] = pc_desdobro.Value.ToString();
                    linha["DT_Emissao"] = dt_emissao.Text;
                    linha["QTD_Nota"] = qtd_nota.Value.ToString();
                    linha["Vl_Unitario"] = vl_unitario.Value.ToString();
                    linha["Vl_SubTotal"] = vl_subtotal.Value.ToString();
                    linha["Vl_BaseCalc"] = vl_basecalc.Value.ToString();
                    linha["Vl_ICMS"] = vl_icms.Value.ToString();
                    linha["ST_Registro"] = "A";
                    vTabela.Rows.Add(linha);
                    vQTD_Desdobro += 1;
                }
                vTabAux = vTabela.Copy();
                gNotasDesdobro.DataSource = vTabela;
                if (vQTD_Desdobro == Convert.ToInt32(qtd_desdobro.Text))
                {
                    if (MessageBox.Show("Numero máximo de desdobro informado.\n Deseja fechar tela?",
                                        "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                        System.Windows.Forms.DialogResult.Yes)
                        Close();
                }
            }
            catch
            {
                MessageBox.Show("ERRO: Nota Fiscal: " + nr_notafiscal.Text + " ,Série: " + nr_serie.Text + " já existe!",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void afterExclui()
        {
            if (gNotasDesdobro.DataSource is DataTable)
            {
                if ((gNotasDesdobro.DataSource as DataTable).Rows.Count > 0)
                {
                    if ((gNotasDesdobro.DataSource as DataTable).Rows[gNotasDesdobro.CurrentRow.Index]["ID_Item"].ToString() != "")
                    {
                        (gNotasDesdobro.DataSource as DataTable).Rows[gNotasDesdobro.CurrentRow.Index]["ST_Registro"] = "C";
                        vTabAux.Merge((gNotasDesdobro.DataSource as DataTable));
                    }
                    (gNotasDesdobro.DataSource as DataTable).Rows.RemoveAt(gNotasDesdobro.CurrentRow.Index);
                    vQTD_Desdobro -= 1;
                }
            }
        }

        private void carregarRegistros(DataRow vLinha)
        {
            if (vLinha != null)
            {
                nr_notafiscal.Text = vLinha["NR_NotaFiscal"].ToString();
                nr_serie.Text = vLinha["NR_Serie"].ToString();
                pc_desdobro.Text = vLinha["PC_Desdobro"].ToString();
                dt_emissao.Text = vLinha["DT_Emissao"].ToString();
                qtd_nota.Text = vLinha["QTD_Nota"].ToString();
                vl_unitario.Text = vLinha["Vl_Unitario"].ToString();
                vl_subtotal.Text = vLinha["Vl_SubTotal"].ToString();
                vl_basecalc.Text = vLinha["Vl_BaseCalc"].ToString();
                vl_icms.Text = vLinha["Vl_ICMS"].ToString();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            if ((vST_ControlarDesdobro) && (vTabela.Rows.Count != Convert.ToInt32(qtd_desdobro.Text)))
                MessageBox.Show("Obrigatório informar quantidade total de desdobro.\n " +
                                "Quantidade de desdobro : " + qtd_desdobro.Text + "\n" +
                                "Quantidade Informada : " + vTabela.Rows.Count.ToString() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Close();
        }

        private void nr_notafiscal_Leave(object sender, EventArgs e)
        {
            object[] chave = new object[] { nr_notafiscal.Text, nr_serie.Text };
            DataRow linha = vTabela.Rows.Find(chave);
            if (linha != null)
                carregarRegistros(linha);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a." + nr_serie.NM_CampoBusca + "|=|'" + nr_serie.Text + "'", new Componentes.EditDefault[] { nr_serie, ds_serie}, new TDatSerieNF());
            object[] chave = new object[] { nr_notafiscal.Text, nr_serie.Text };
            DataRow linha = vTabela.Rows.Find(chave);
            if (linha != null)
                carregarRegistros(linha);
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_SerieNF|Descrição Série|350;a.NR_Serie|Cód. Série|100", new Componentes.EditDefault[] { nr_serie, ds_serie}, new TDatSerieNF(), "");
        }

        private void qtd_nota_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = qtd_nota.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = qtd_nota.Value * vl_unitario.Value;
        }

        private void gNotasDesdobro_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((gNotasDesdobro.DataSource is DataTable)&&(gNotasDesdobro.CurrentRow != null))
            {
                carregarRegistros((gNotasDesdobro.DataSource as DataTable).Rows[gNotasDesdobro.CurrentRow.Index]);
            }
        }

        private void TFLanNotasPesagem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case(Keys.F2):
                    {
                        afterNovo();
                        break;
                    }
                case (Keys.F4):
                    {
                        afterGrava();
                        break;
                    }
                case(Keys.F5):
                    {
                        afterExclui();
                        break;
                    }
            }
        }

        private void TFLanNotasPesagem_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            //Procurar desdobros ja cadastrados
        }

     }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;

namespace Empreendimento
{
    public partial class TFMateriais : Form
    {
        private TList_FichaTec vFicha = new TList_FichaTec();
        public TList_FichaTec lFicha { get; set; } = new TList_FichaTec();

        public TFMateriais()
        {
            InitializeComponent();
        }

        private void TFMateriais_Load(object sender, EventArgs e)
        {
            vFicha = lFicha;
            TList_CadCFGEmpreendimento registro_CadCFG = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);
            if (registro_CadCFG.Count.Equals(0))
            {
                MessageBox.Show("Necessário ter pré-cadastrado configuração empreendimento", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
            else if (registro_CadCFG[0].Cd_tabelapreco == null || string.IsNullOrEmpty(registro_CadCFG[0].Cd_tabelapreco))
            {
                MessageBox.Show("Necessário ter pré-cadastrado tabela de preço na configuração do empreendimento", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }

            vFicha.ForEach(r =>
            {
                object d = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarPrecoVenda(registro_CadCFG[0].cd_empresa, r.Cd_produto, registro_CadCFG[0].Cd_tabelapreco);
                r.Vl_unitarioAtual = d == null ? 0 : Convert.ToDecimal(d);
            });
            bsMateriais.DataSource = vFicha;
            bsMateriais.ResetBindings(true);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_trocaValor_Click(object sender, EventArgs e)
        {
            if (bsMateriais.Current == null)
                return;
            (bsMateriais.DataSource as IEnumerable<TRegistro_FichaTec>).ToList().FindAll(p => p.st_agregar).ForEach(r =>
            {
                r.Vl_unitario = r.Vl_unitarioAtual;
                r.Vl_subtotal = r.Vl_unitario * r.Quantidade;
            });
            bsMateriais.ResetBindings(true);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            (bsMateriais.DataSource as IEnumerable<TRegistro_FichaTec>)
                .ToList()
                    .FindAll(r => r.st_agregar)
                        .ForEach(p =>
                        {
                            TCN_FichaTec.Gravar(p, null);
                        });
            bsMateriais.ResetBindings(true);
            DialogResult = DialogResult.OK;
        }

        private void cbxTodos_Click(object sender, EventArgs e)
        {
            //(bsMateriais.DataSource as IEnumerable<TRegistro_FichaTec>).ToList().ForEach(r =>
            //{
            //    r.Vl_unitario = r.Vl_unitarioAtual;
            //});
        }

        private void gMateriais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.ColumnIndex.Equals(0))
                return;
            else if (bsMateriais.Current == null)
                return;

            (bsMateriais.Current as TRegistro_FichaTec).st_agregar = !(bsMateriais.Current as TRegistro_FichaTec).st_agregar;
            bsMateriais.ResetCurrentItem();
        }

        private void gMateriais_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if ((((sender as Componentes.DataGridDefault).DataSource as BindingSource).List[e.RowIndex] as CamadaDados.Empreendimento.TRegistro_FichaTec).Vl_unitario <
                    (((sender as Componentes.DataGridDefault).DataSource as BindingSource).List[e.RowIndex] as CamadaDados.Empreendimento.TRegistro_FichaTec).Vl_unitarioAtual)
                    gMateriais.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
    }
}

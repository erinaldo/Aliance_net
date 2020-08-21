using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFAlterarTabPreco : Form
    {
        public CamadaDados.Locacao.TRegistro_Locacao rLoc
        { get; set; }
        public string pId_tabelaPreco
        { get { return (bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).Find(p => p.St_processar).Id_tabelastr; } }
        public TFAlterarTabPreco()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsItens.Count > 0 && bsPrecoItem.Count > 0)
            {
                if ((bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).Exists(p => p.St_processar))
                {
                    if (MessageBox.Show("Deseja alterar tabela de preço para " + 
                        (bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).Find(p => p.St_processar).Ds_tabela.Trim() + " na locação corrente?", "Pergunta", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade = decimal.Zero;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("Obrigatório selecionar uma tabela de preço para alterar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SimularValores()
        {
            if (bsItens.Count > 0 && bsPrecoItem.Count > 0)
            {
                TimeSpan result = new TimeSpan();
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdev > CamadaDados.UtilData.Data_Servidor())
                    result = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdev.Value.Subtract((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada.Value);
                   
                else
                    result = CamadaDados.UtilData.Data_Servidor().Subtract((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada.Value);
                lbTempo.Text =  "Tempo estimado de Locação: " + (result.Days >= 1 ? Math.Round(double.Parse(result.Days.ToString()), 1).ToString() + " dia(s), " : string.Empty) +
                        (result.Hours >= 1 ? Math.Round(double.Parse(result.Hours.ToString()), 1) + " hora(s), " : string.Empty) +
                        (result.Minutes >= 1 ? Math.Round(double.Parse(result.Minutes.ToString()), 1).ToString() + " minuto(s)." : string.Empty);
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade = Math.Round((bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Tp_tabela.Equals("2") ?
                Math.Round(decimal.Parse(result.TotalHours.ToString()), 2) : (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Tp_tabela.Equals("3") ?
                Math.Round(decimal.Parse(result.TotalDays.ToString()), 2) : (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Tp_tabela.Equals("4") ?
                Math.Round(decimal.Parse(result.TotalDays.ToString()), 2) / 30 : (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Tp_tabela.Equals("5") ?
                Math.Round(decimal.Parse(result.TotalDays.ToString()), 2) / 7 : (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Tp_tabela.Equals("6") ?
                Math.Round(decimal.Parse(result.TotalDays.ToString()), 2) / 15 : 0, 2);
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade > 0)
                {
                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).BaseCalc = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade;
                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_unitario = (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).Vl_preco;
                }

                bsItens.ResetCurrentItem();
            }
        }

        private void TFAlterarTabPreco_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsLocacao.DataSource = new CamadaDados.Locacao.TList_Locacao() { rLoc };
            bsItens_PositionChanged(this, new EventArgs());
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            //Buscar preços itens
            bsPrecoItem.DataSource =
                CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Buscar(string.Empty,
                                                                         (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa,
                                                                         (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
            this.SimularValores();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFAlterarTabPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bsPrecoItem_PositionChanged(object sender, EventArgs e)
        {
            this.SimularValores();
        }

        private void gAtualiza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).ForEach(p => p.St_processar = false);
                (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).St_processar = true;
                bsPrecoItem.ResetBindings(true);
            }
        }
    }
}

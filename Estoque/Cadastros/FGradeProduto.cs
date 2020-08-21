using System;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace Estoque.Cadastros
{
    public partial class TFGradeProduto : Form
    {
        public TFGradeProduto()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsCaracteristica.DataSource = TCN_Caracteristica.Buscar(string.Empty, string.Empty, 0, string.Empty, null);
            bsCaracteristica_PositionChanged(this, new EventArgs());
        }

        private void TFGradeProduto_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bsCaracteristica_PositionChanged(object sender, EventArgs e)
        {
            if (bsCaracteristica.Current != null)
                bsValor.DataSource = TCN_ValorCaracteristica.Buscar((bsCaracteristica.Current as TRegistro_Caracteristica).Id_caracteristicastr,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    0,
                                                                    string.Empty,
                                                                    null);
            else bsValor.Clear();
        }

        private void TFGradeProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bbAddCarac_Click(object sender, EventArgs e)
        {
            Utils.InputBox ibp = new Utils.InputBox();
            ibp.Text = "Caracteristica Produto";
            string ret = ibp.ShowDialog();
            if (!string.IsNullOrEmpty(ret))
                try
                {
                    TCN_Caracteristica.GravarCaracteristica(new TRegistro_Caracteristica { Ds_caracteristica = ret.ToUpper() }, null);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro gravar registro: " + ex.Message.Trim()); }
            else MessageBox.Show("Obrigatório informar caracteristica para gravar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbAltCarac_Click(object sender, EventArgs e)
        {
            if (bsCaracteristica.Current != null)
            {
                Utils.InputBox ibp = new Utils.InputBox(string.Empty, (bsCaracteristica.Current as TRegistro_Caracteristica).Ds_caracteristica);
                ibp.Text = "Alterar Caracteristica Produto";
                string ret = ibp.ShowDialog();
                if(!string.IsNullOrEmpty(ret))
                    try
                    {
                        TCN_Caracteristica.GravarCaracteristica(new TRegistro_Caracteristica { Id_caracteristica = (bsCaracteristica.Current as TRegistro_Caracteristica).Id_caracteristica, Ds_caracteristica = ret.ToUpper() }, null);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro alterar registro: " + ex.Message.Trim()); }
            }
        }

        private void bbDelCarac_Click(object sender, EventArgs e)
        {
            if(bsCaracteristica.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Caracteristica.ExcluirCaracteristica(bsCaracteristica.Current as TRegistro_Caracteristica, null);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro excluir registro: " + ex.Message.Trim()); }
        }

        private void bbAddValor_Click(object sender, EventArgs e)
        {
            if (bsCaracteristica.Current != null)
            {
                Utils.InputBox ibp = new Utils.InputBox();
                ibp.Text = "Valor Caracteristica";
                string ret = ibp.ShowDialog();
                if (!string.IsNullOrEmpty(ret))
                    try
                    {
                        TCN_ValorCaracteristica.Gravar(new TRegistro_ValorCaracteristica { Id_caracteristica = (bsCaracteristica.Current as TRegistro_Caracteristica).Id_caracteristica, Valor = ret.ToUpper() }, null);
                        bsCaracteristica_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro gravar registro: " + ex.Message.Trim()); }
                else MessageBox.Show("Obrigatório informar valor para gravar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbAltValor_Click(object sender, EventArgs e)
        {
            if (bsValor.Current != null)
            {
                Utils.InputBox ibp = new Utils.InputBox(string.Empty, (bsValor.Current as TRegistro_ValorCaracteristica).Valor);
                ibp.Text = "Alterar Valor Caracteristica Produto";
                string ret = ibp.ShowDialog();
                if (!string.IsNullOrEmpty(ret))
                    try
                    {
                        TCN_ValorCaracteristica.Gravar(new TRegistro_ValorCaracteristica { Id_caracteristica = (bsValor.Current as TRegistro_ValorCaracteristica).Id_caracteristica,
                                                                                           Id_item = (bsValor.Current as TRegistro_ValorCaracteristica).Id_item, Valor = ret.ToUpper() }, null);
                        bsCaracteristica_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro alterar registro: " + ex.Message.Trim()); }
            }
        }

        private void bbDelValor_Click(object sender, EventArgs e)
        {
            if (bsValor.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_ValorCaracteristica.Excluir(bsValor.Current as TRegistro_ValorCaracteristica, null);
                        bsCaracteristica_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro excluir registro: " + ex.Message.Trim()); }
        }
    }
}

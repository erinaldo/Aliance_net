using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Restaurante.Cadastro
{
    public partial class TFCadChopeira : Form
    {
        public TFCadChopeira()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("<TODOS>", string.Empty));
            cbx.Add(new TDataCombo("110", "0"));
            cbx.Add(new TDataCombo("220", "1"));
            voltagem.DataSource = cbx;
            voltagem.DisplayMember = "Display";
            voltagem.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("<TODOS>", string.Empty));
            cbx1.Add(new TDataCombo("1", "1"));
            cbx1.Add(new TDataCombo("2", "2"));
            qtd_torneiras.DataSource = cbx1;
            qtd_torneiras.DisplayMember = "Display";
            qtd_torneiras.ValueMember = "Value";
        }

        private void TFCadChopeira_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void bbBuscarChopeira_Click(object sender, EventArgs e)
        {
            bsChopeira.DataSource = TCN_Chopeira.Buscar(string.Empty,
                                                        string.Empty,
                                                        nr_chopeira.Text,
                                                        voltagem.SelectedIndex > 0 ? voltagem.SelectedValue.ToString() : string.Empty,
                                                        qtd_torneiras.SelectedIndex > 0 ? qtd_torneiras.SelectedValue.ToString() : string.Empty,
                                                        null);
        }

        private void bbAddChopeira_Click(object sender, EventArgs e)
        {
            using (TFChopeira fCad = new TFChopeira())
            {
                if(fCad.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_Chopeira.Gravar(fCad.rChopeira, null);
                        MessageBox.Show("Chopeira gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarChopeira_Click(this, new EventArgs());
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAltChopeira_Click(object sender, EventArgs e)
        {
            if(bsChopeira.Current != null)
                using (TFChopeira fCad = new TFChopeira())
                {
                    fCad.rChopeira = bsChopeira.Current as TRegistro_Chopeira;
                    if (fCad.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_Chopeira.Gravar(fCad.rChopeira, null);
                            MessageBox.Show("Chopeira alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bbBuscarChopeira_Click(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bbDelChopeira_Click(object sender, EventArgs e)
        {
            if(bsChopeira.Current != null)
                if(MessageBox.Show("Confirma exclusão da chopeira selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_Chopeira.Excluir(bsChopeira.Current as TRegistro_Chopeira, null);
                        MessageBox.Show("Chopeira excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarChopeira_Click(this, new EventArgs());
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbBuscarKit_Click(object sender, EventArgs e)
        {
            bsKitExtrator.DataSource = TCN_KitExtrator.Buscar(string.Empty,
                                                              nr_kit.Text,
                                                              null);
        }

        private void bbAddKit_Click(object sender, EventArgs e)
        {
            InputBox ibp = new InputBox();
            ibp.Text = "Nº KIT";
            string nr_kit = ibp.ShowDialog();
            if (string.IsNullOrEmpty(nr_kit))
            {
                MessageBox.Show("Obrigatório informar Nº KIT.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                TCN_KitExtrator.Gravar(new TRegistro_KitExtrator { Nr_kit = nr_kit }, null);
                MessageBox.Show("Kit gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbBuscarKit_Click(this, new EventArgs());
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbAltKit_Click(object sender, EventArgs e)
        {
            if(bsKitExtrator.Current != null)
            {
                InputBox ibp = new InputBox(string.Empty, (bsKitExtrator.Current as TRegistro_KitExtrator).Nr_kit);
                ibp.Text = "Nº KIT";
                string nr_kit = ibp.ShowDialog();
                if (string.IsNullOrEmpty(nr_kit))
                {
                    MessageBox.Show("Obrigatório informar Nº KIT.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    (bsKitExtrator.Current as TRegistro_KitExtrator).Nr_kit = nr_kit;
                    TCN_KitExtrator.Gravar(bsKitExtrator.Current as TRegistro_KitExtrator, null);
                    MessageBox.Show("Kit alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bbBuscarKit_Click(this, new EventArgs());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbDelKit_Click(object sender, EventArgs e)
        {
            if(bsKitExtrator.Current != null)
                if(MessageBox.Show("Confirma exclusão do KIT selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_KitExtrator.Excluir(bsKitExtrator.Current as TRegistro_KitExtrator, null);
                        MessageBox.Show("Kit excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarKit_Click(this, new EventArgs());
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

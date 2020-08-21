using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;

namespace Parametros.Diversos
{
    public partial class TFTrigger : Form
    {
        public TFTrigger()
        {
            InitializeComponent();
        }
        private void afterbusca()
        {

            bsTabelas.DataSource = TCN_CadTabela.Busca(tabela.Text, Trigger.Text, st_trigger.Checked, null);
            bsTabelas.ResetCurrentItem();
            bsColunas.DataSource = TCN_Colunas.Busca(string.Empty,
                                                    (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela,
                                                    null);
            bsColunas.ResetCurrentItem();
            bsTrigger.DataSource = TCN_Triggers.Busca(string.Empty,
                                                      (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela, null);
            bsTrigger.ResetCurrentItem();

        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bsTabelas_PositionChanged(object sender, EventArgs e)
        {
            bsColunas.DataSource = TCN_Colunas.Busca(string.Empty,
                                                     (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela,
                                                     null);
            bsColunas.ResetCurrentItem();
            bsTrigger.DataSource = TCN_Triggers.Busca(string.Empty,
                                                      (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela, null);
            bsTrigger.ResetCurrentItem();


        }

        private void dataGridDefault2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 1)// chave
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals(""))
                    {
                        DataGridViewRow linha = dataGridDefault2.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }else if (e.Value.ToString().Trim().ToUpper().Equals("PFK"))
                    {
                        DataGridViewRow linha = dataGridDefault2.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Magenta;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PK"))
                    {
                        DataGridViewRow linha = dataGridDefault2.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("FK"))
                    {
                        DataGridViewRow linha = dataGridDefault2.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Purple;
                    }
                }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            using (FCadTrigger trigger = new FCadTrigger())
            {
                trigger.tb_name = (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela;
                CamadaDados.Diversos.TRegistro_Triggers triggers = new CamadaDados.Diversos.TRegistro_Triggers();
                triggers.lColunas = (bsColunas.List as TList_Colunasbd);
                trigger.rCol = triggers;
                //triggers.trigger_script = (bsTrigger.Current as TRegistro_Triggers).trigger_script;
                //trigger.rcoluna = 
                if (trigger.ShowDialog() == DialogResult.OK)
                {
                    afterbusca();
                }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bbalterar_Click(object sender, EventArgs e)
        {
            using (FCadTrigger trigger = new FCadTrigger())
            {
                trigger.tb_name = (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela;
                CamadaDados.Diversos.TRegistro_Triggers triggers = new CamadaDados.Diversos.TRegistro_Triggers();
                triggers.lColunas = (bsColunas.List as TList_Colunasbd);
                triggers.trigger_nome = (bsTrigger.Current as TRegistro_Triggers).trigger_nome;
                trigger.rCol = triggers;
                triggers.trigger_script = (bsTrigger.Current as TRegistro_Triggers).trigger_script;
                if (trigger.ShowDialog() == DialogResult.OK)
                {
                    bsTabelas_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void TFTrigger_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (bsTrigger.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Deseja excluir esta trigger.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        StringBuilder str2 = new StringBuilder();
                        str2.AppendLine("if exists (select 1 from sysobjects  ");
                        str2.AppendLine("where id = object_id('" + (bsTrigger.Current as TRegistro_Triggers).trigger_nome + "') ");
                        str2.AppendLine("and type = 'TR') drop trigger  " + (bsTrigger.Current as TRegistro_Triggers).trigger_nome);

                        new CamadaDados.Diversos.TCD_Triggers().Deleta(str2.ToString());
                        bsTabelas_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar trigger para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            string Display = "";
            if ((bsTrigger.Current as TRegistro_Triggers).st_ativo)
            {
                (bsTrigger.Current as TRegistro_Triggers).ativo = " disable ";
                Display = " Desabilitar ";
            }
            else
            {
                (bsTrigger.Current as TRegistro_Triggers).ativo = " enable ";
                Display = " Habilitar ";
            }

            if (bsTrigger.Current != null)
            {
                if (MessageBox.Show("Deseja "+Display+" o registro?\r\n" +
                                   "Deseja " + Display + " esta trigger.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        (bsTrigger.Current as TRegistro_Triggers).table_nome = (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela;
                        new CamadaDados.Diversos.TCD_Triggers().Desativar((bsTrigger.Current as TRegistro_Triggers));
                        bsTabelas_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar trigger para desativar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TFTrigger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterbusca();
            if (e.KeyCode.Equals(Keys.F8))
                toolStripButton2_Click(this, new EventArgs());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (FCadColunas colun = new FCadColunas())
            {

                colun.rColun = (bsColunas.DataSource as TList_Colunasbd);
                colun.rColun.ForEach(p => p.nome_tabela = (bsTabelas.Current as TRegistro_Tabelasbd).nome_tabela);
                if(colun.ShowDialog() == DialogResult.OK)
                {
                    if (colun.rColunas.Count > 0)
                    {
                        (colun.rColunas).ForEach(p =>
                        {
                            if(!string.IsNullOrEmpty(p.ds_coluna))
                                CamadaNegocio.Diversos.TCN_Coluna.Gravar(p, null);
                        });

                    }
                }
            } 
        }
    }
}

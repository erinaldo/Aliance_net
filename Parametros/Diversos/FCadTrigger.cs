using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class FCadTrigger : Form
    {
        public string tb_name { get; set; }
        public string script { get; set; }
        public string script2 { get; set; }

        public CamadaDados.Diversos.TList_Colunasbd rcoluna { get; set; }

        private CamadaDados.Diversos.TRegistro_Triggers rcol;
        public CamadaDados.Diversos.TRegistro_Triggers rCol
        {
            get
            {
                if (bsTrigger.Current != null)
                    return (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Triggers);
                else
                    return null;
            }
            set { rcol = value; }
        }
        public FCadTrigger()
        {
            InitializeComponent();
        }

        private void FCadTrigger_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("UPDATE", "U"));
            cbx.Add(new Utils.TDataCombo("DELETE", "D"));
            cbTrigger.DataSource = cbx;
            cbTrigger.DisplayMember = "Display";
            cbTrigger.ValueMember = "Value";

            //rcol.lColunas = rcoluna; 
            if (rcol != null)
            {
                
                scriptText.Text = rcol.trigger_script;
                bsColunas.DataSource = rcol.lColunas;
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PK") || (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PFK"))
                    {
                        (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar = !(bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar;
                    }
                } 
                if (!string.IsNullOrEmpty(rcol.trigger_nome))
                {
                    string a = rcol.trigger_nome.Substring(rcol.trigger_nome.Length - 1, 1);
                    cbTrigger.SelectedValue = a;
                }

            }
            else
            {
                rcol = new CamadaDados.Diversos.TRegistro_Triggers();

            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.scriptgenerator();
        }

        private void dataGridDefault1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 2)// chave
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PFK"))
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Magenta;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PK"))
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("FK"))
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Purple;
                    }
                    else
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }


        }

        private void cbTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {

            scriptgenerator();
            //scripttrigger.Items.Add(" ");
            //scripttrigger.Items.Add("");
            //scripttrigger.Items.Add("where id = object_id('TR_FIN_BANCO_D') ");
            //scripttrigger.Items.Add("and type = 'TR') ");
            //scripttrigger.Items.Add(" drop trigger  ");
            //string[] ve;
            //ve = tb_name.Split('_');
            //scripttrigger.Items.Add("TR_" + ve[1] + "_" + ve[2]);
            //scripttrigger.Items.Add(" go ");
        }

        private void scriptgenerator()
        {
            string trigger_nome = string.Empty;
            int j = 0;
            string id_chave = string.Empty;


            // Construtor do nome da trigger

            trigger_nome = "TR_" + tb_name;

            StringBuilder str = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            str2.AppendLine("if exists (select 1 from sysobjects  ");
            str2.AppendLine("where id = object_id('" + trigger_nome + "') ");
            str2.AppendLine("and type = 'TR') drop trigger  " + trigger_nome);
            str2.AppendLine(" --go ");
            str.AppendLine("");
            str.AppendLine("create trigger " + trigger_nome + " on " + tb_name + " after " + (cbTrigger.SelectedValue == "U" ? "UPDATE" : "DELETE") );
            str.AppendLine(" as begin ");
            str.AppendLine("  ");
            str.AppendLine("declare @v_id_auditoria decimal(15); ");
            str.AppendLine("declare @v_id_registro decimal(5); ");
            j = 0;
            for (int i = 0; i < bsColunas.Count; i++)
            {
                string t = string.Empty;
                if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                {
                    t = (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo;
                    if (!(bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("datetime") && !(bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("bit"))
                        t += (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho;
                    str.AppendLine(" declare @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " " + t + "; ");
                    if (cbTrigger.SelectedValue.Equals("U"))
                        str.AppendLine(" declare @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old " + t + "; ");
                }
                
            //construtor de chaves primarias
                if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PK") || (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PFK"))
                {
                    if (j != 0 && bsColunas.Count - 1 >= i)
                            id_chave += "+ '|'+ ";
                    j++;
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("datetime"))
                        id_chave += "'" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ":'+ convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ") ";
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("decimal"))
                        id_chave += "'" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ":'+ convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ") ";
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("numeric"))
                        id_chave += "'" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ":'+ convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ") ";
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("int"))
                        id_chave += "'" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ":'+ convert(varchar(12),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ") ";
                    else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("varchar"))
                        id_chave += "'" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ":'+ @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " ";
                        
                }
            }
            if (cbTrigger.SelectedValue.Equals("U"))
            {
                str.AppendLine(" select ");
                j = 0;
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                    {
                        if (j != 0 && bsColunas.Count - 1 >= i)
                            str.Append(", ");
                        str.AppendLine(" @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " = " + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " ");
                        j++;
                    }
                }
                str.AppendLine(" from inserted; ");
                str.AppendLine(" select ");
                j = 0;
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                    {
                        if(j != 0 && bsColunas.Count - 1 >= i)
                            str.Append(", ");
                        j++;
                        str.AppendLine(" @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old = " + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " ");
                       
                    }
                    
                }
                str.AppendLine(" from deleted; ");
                str.AppendLine(" if( ");
                j = 0;
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                    {
                        if (j != 0 && bsColunas.Count - 1 >= i)
                            str.AppendLine(" or ");
                        j++;
                        str.AppendLine(" @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " ");
                        str.Append(" <> @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old ");

                    }
                }
                    str.AppendLine(" ) begin ");
                    str.AppendLine(" select @v_id_auditoria = isnull(id_auditoria, 0) + 1 from tb_div_auditoria; ");
                    str.AppendLine(" if(isnull(@v_id_auditoria, 0) = 0) ");
                    str.AppendLine("    set @v_id_auditoria = 1; ");
                    str.AppendLine(" insert into TB_DIV_Auditoria(ID_Auditoria, Login, dt_evento, NM_Tabela, TP_Evento, DT_Cad, dt_alt, id_chave) ");
                    str.AppendLine(" values(@v_id_auditoria, SUSER_SNAME(), getdate(), '"+tb_name+"', 'U', getdate(),GETDATE(), "+id_chave+"); ");
                    for (int i = 0; i < bsColunas.Count; i++)
                    {
                        if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                        {
                            str.AppendLine(" if( @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "  <>  @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old ) ");
                            str.AppendLine(" begin ");
                            str.AppendLine("    select @v_id_registro = isnull(id_registro, 0) + 1 from tb_div_colunasaudit where id_auditoria = @v_id_auditoria; ");
                            str.AppendLine("    if(isnull(@v_id_registro, 0) = 0) ");
                            str.AppendLine("        set @v_id_registro = 1; ");
                            str.AppendLine("    insert into TB_DIV_ColunasAudit(ID_Auditoria, ID_Registro, nm_coluna, vl_old, vl_atual, dt_cad, dt_alt) ");
                            if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("datetime"))
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old,20), convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ",20), getdate(), getdate()); ");
                            else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("int"))
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old), convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                            else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("bit"))
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', convert(varchar("+(bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho+"),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old), convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                            else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("decimal"))
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old), convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                            else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("numeric"))
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old), convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                            else
                                str.AppendLine("    values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "', @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "_old, @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ", getdate(), getdate()); ");
                                
                                
                            str.AppendLine(" end ");

                        }
                    }
                    str.AppendLine(" end ");
                str.AppendLine(" end ");
            }
            else
            {
                str.AppendLine(" select ");
                j = 0;
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                    {
                        if (j != 0 && bsColunas.Count - 1 >= i)
                            str.Append(", ");
                        j++;
                        str.AppendLine(" @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " = " + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + " ");

                    }
                }
                str.AppendLine(" from deleted; ");
                str.AppendLine(" select @v_id_auditoria = isnull(id_auditoria, 0) + 1 from tb_div_auditoria; ");
                str.AppendLine(" if(isnull(@v_id_registro, 0) = 0) ");
                str.AppendLine(" set @v_id_registro = 1; ");
                str.AppendLine(" insert into TB_DIV_Auditoria(ID_Auditoria, Login, dt_evento, NM_Tabela, TP_Evento, DT_Cad, dt_alt) ");
                str.AppendLine(" values(@v_id_auditoria, SUSER_SNAME(), getdate(), '"+tb_name+"', 'D', getdate(),GETDATE()); ");
                for (int i = 0; i < bsColunas.Count; i++)
                {
                    if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar)
                    {
                        str.AppendLine(" select @v_id_registro = isnull(id_registro, 0) + 1 from tb_div_colunasaudit where id_auditoria = @v_id_auditoria; ");
                        str.AppendLine(" if(isnull(@v_id_registro, 0) = 0) ");
                        str.AppendLine(" set @v_id_registro = 1; ");
                        str.AppendLine(" insert into TB_DIV_ColunasAudit(ID_Auditoria, ID_Registro, nm_coluna, vl_atual, dt_cad, dt_alt) ");

                        if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("datetime"))
                            str.AppendLine(" values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna +
                             "',  convert(varchar(25),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                        else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("bit"))
                            str.AppendLine(" values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna +
                            "',  convert(varchar(" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho + "),@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                        else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("decimal"))
                            str.AppendLine(" values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna +
                            "',  convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                        else if ((bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tipo.Equals("numeric"))
                            str.AppendLine(" values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna +
                            "',  convert(varchar" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).tamanho.Replace(",", "") + ",@v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + "), getdate(), getdate()); ");
                        else  
                            str.AppendLine(" values(@v_id_auditoria, @v_id_registro, '" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna +
                            "',  @v_" + (bsColunas[i] as CamadaDados.Diversos.TRegistro_Columnsbd).nome_coluna + ", getdate(), getdate()); ");


                    }
                }
                str.AppendLine(" end  ");

            }
            scriptText.Text =  str.ToString().ToUpper();
            script = str2.ToString().ToUpper();
            
        }

        private void gerarscript_Click(object sender, EventArgs e)
        {
            this.scriptgenerator();
        }

        private void st_marcamov_Click(object sender, EventArgs e)
        {
            if (bsColunas.Count > 0)
            {
                (bsColunas.List as CamadaDados.Diversos.TList_Colunasbd).ForEach(p => p.st_agregar = st_marcamov.Checked);
                bsColunas.ResetBindings(true);
                scriptgenerator();
            }
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsColunas.Current != null)
            {
                if (!(bsColunas.Current as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PK") && !(bsColunas.Current as CamadaDados.Diversos.TRegistro_Columnsbd).chave.Equals("PFK"))
                {
                    (bsColunas.Current as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar =
                         !(bsColunas.Current as CamadaDados.Diversos.TRegistro_Columnsbd).st_agregar;
                    scriptgenerator();
                }
            }
        }

        private void bbExecutar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(scriptText.Text)) 
            {
                bool gravar = false;
                try
                {
                    using (FCadColunas a = new FCadColunas())
                    {
                        CamadaDados.Diversos.TList_Colunasbd ae = new CamadaDados.Diversos.TList_Colunasbd();

                       (bsColunas.DataSource as CamadaDados.Diversos.TList_Colunasbd).Where(p => p.st_agregar).ToList().ForEach(p => 
                        { 
                            p.nome_tabela = tb_name;
                            ae.Add(p);
                        });
                        a.rColun = ae;
                        if(a.ShowDialog() == DialogResult.OK) 
                        {
                            if (a.rColunas.Count > 0)
                                (a.rColunas).ForEach(p =>
                                {
                                    if (!string.IsNullOrEmpty(p.ds_coluna))
                                        CamadaNegocio.Diversos.TCN_Coluna.Gravar(p, null);
                                    gravar = true;
                                });
                        } 

                    }
                    if (gravar)
                    {
                        new CamadaDados.Diversos.TCD_Triggers().ExecutarTrigger(script);
                        new CamadaDados.Diversos.TCD_Triggers().ExecutarTrigger(scriptText.Text);
                        MessageBox.Show("Executado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro Trigger: " + ex.Message.Trim());
                }
            }
            else
                MessageBox.Show("Obrigatorio gerar script para executar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FCadTrigger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                scriptgenerator();
            else if (e.KeyCode.Equals(Keys.F5))
                bbExecutar_Click(this, new EventArgs());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }
    }
}

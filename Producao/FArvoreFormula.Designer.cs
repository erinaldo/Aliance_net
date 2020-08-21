namespace Producao
{
    partial class TFArvoreFormula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pAcabado = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.trvArvore = new System.Windows.Forms.TreeView();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.bsFormulaApontamento = new System.Windows.Forms.BindingSource(this.components);
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_formula = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.tlpCentral.SuspendLayout();
            this.pAcabado.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormulaApontamento)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pAcabado, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Size = new System.Drawing.Size(781, 558);
            this.tlpCentral.TabIndex = 1;
            // 
            // pAcabado
            // 
            this.pAcabado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAcabado.Controls.Add(this.editDefault1);
            this.pAcabado.Controls.Add(this.label4);
            this.pAcabado.Controls.Add(this.editDefault2);
            this.pAcabado.Controls.Add(this.label3);
            this.pAcabado.Controls.Add(this.ds_formula);
            this.pAcabado.Controls.Add(this.NM_Empresa);
            this.pAcabado.Controls.Add(this.label1);
            this.pAcabado.Controls.Add(this.CD_Empresa);
            this.pAcabado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAcabado.Location = new System.Drawing.Point(5, 5);
            this.pAcabado.Name = "pAcabado";
            this.pAcabado.NM_ProcDeletar = "";
            this.pAcabado.NM_ProcGravar = "";
            this.pAcabado.Size = new System.Drawing.Size(771, 86);
            this.pAcabado.TabIndex = 1;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.trvArvore);
            this.panelDados1.Controls.Add(this.lblConciliacao);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 99);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(771, 454);
            this.panelDados1.TabIndex = 2;
            // 
            // trvArvore
            // 
            this.trvArvore.AllowDrop = true;
            this.trvArvore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvArvore.FullRowSelect = true;
            this.trvArvore.HideSelection = false;
            this.trvArvore.Location = new System.Drawing.Point(0, 18);
            this.trvArvore.Name = "trvArvore";
            this.trvArvore.Size = new System.Drawing.Size(769, 434);
            this.trvArvore.TabIndex = 2;
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.BackColor = System.Drawing.Color.Silver;
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConciliacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConciliacao.Location = new System.Drawing.Point(0, 0);
            this.lblConciliacao.Name = "lblConciliacao";
            this.lblConciliacao.Size = new System.Drawing.Size(769, 18);
            this.lblConciliacao.TabIndex = 65;
            this.lblConciliacao.Text = "FICHA TECNICA";
            this.lblConciliacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsFormulaApontamento
            // 
            this.bsFormulaApontamento.DataSource = typeof(CamadaDados.Producao.Producao.TList_FormulaApontamento);
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdprodutoDataGridViewTextBoxColumn
            // 
            this.qtdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Qtd_produto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = "0";
            this.qtdprodutoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtdprodutoDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.qtdprodutoDataGridViewTextBoxColumn.Name = "qtdprodutoDataGridViewTextBoxColumn";
            this.qtdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.HeaderText = "UND";
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormulaApontamento, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault1.Location = new System.Drawing.Point(141, 58);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "NM_Empresa";
            this.editDefault1.NM_CampoBusca = "NM_Empresa";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ReadOnly = true;
            this.editDefault1.Size = new System.Drawing.Size(484, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 58;
            this.editDefault1.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Produto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormulaApontamento, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault2.Location = new System.Drawing.Point(65, 58);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "CD_Empresa";
            this.editDefault2.NM_CampoBusca = "CD_Empresa";
            this.editDefault2.NM_Param = "@P_CD_EMPRESA";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(75, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = true;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = true;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 56;
            this.editDefault2.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Formula:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_formula
            // 
            this.ds_formula.BackColor = System.Drawing.SystemColors.Window;
            this.ds_formula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_formula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_formula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormulaApontamento, "Ds_formula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_formula.Enabled = false;
            this.ds_formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_formula.Location = new System.Drawing.Point(65, 32);
            this.ds_formula.Name = "ds_formula";
            this.ds_formula.NM_Alias = "";
            this.ds_formula.NM_Campo = "ds_formula";
            this.ds_formula.NM_CampoBusca = "ds_formula";
            this.ds_formula.NM_Param = "@P_CD_EMPRESA";
            this.ds_formula.QTD_Zero = 0;
            this.ds_formula.Size = new System.Drawing.Size(560, 20);
            this.ds_formula.ST_AutoInc = false;
            this.ds_formula.ST_DisableAuto = false;
            this.ds_formula.ST_Float = false;
            this.ds_formula.ST_Gravar = false;
            this.ds_formula.ST_Int = false;
            this.ds_formula.ST_LimpaCampo = true;
            this.ds_formula.ST_NotNull = true;
            this.ds_formula.ST_PrimaryKey = false;
            this.ds_formula.TabIndex = 52;
            this.ds_formula.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormulaApontamento, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(141, 6);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(484, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 54;
            this.NM_Empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormulaApontamento, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(65, 6);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(75, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = false;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 51;
            this.CD_Empresa.TextOld = null;
            // 
            // TFArvoreFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 558);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFArvoreFormula";
            this.ShowInTaskbar = false;
            this.Text = "Arvore Formula Produção";
            this.Load += new System.EventHandler(this.TFArvoreFormula_Load);
            this.tlpCentral.ResumeLayout(false);
            this.pAcabado.ResumeLayout(false);
            this.pAcabado.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsFormulaApontamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pAcabado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsFormulaApontamento;
        private System.Windows.Forms.TreeView trvArvore;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblConciliacao;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_formula;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
    }
}
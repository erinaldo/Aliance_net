namespace Financeiro.Cadastros
{
    partial class TFCadJuro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadJuro));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdjuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsjuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipojuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diascarenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsJuro = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Juro = new System.Windows.Forms.Label();
            this.LB_DS_Juro = new System.Windows.Forms.Label();
            this.LB_PC_JuroDiario_Atrazo = new System.Windows.Forms.Label();
            this.LB_DiasCarencia = new System.Windows.Forms.Label();
            this.CD_Juro = new Componentes.EditDefault(this.components);
            this.DS_Juro = new Componentes.EditDefault(this.components);
            this.PC_JuroDiario_Atrazo = new Componentes.EditFloat(this.components);
            this.TP_Juro = new Componentes.RadioGroup(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.rbSimples = new Componentes.RadioButtonDefault(this.components);
            this.rbComposto = new Componentes.RadioButtonDefault(this.components);
            this.DiasCarencia = new Componentes.EditFloat(this.components);
            this.bnJuro = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsJuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroDiario_Atrazo)).BeginInit();
            this.TP_Juro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiasCarencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnJuro)).BeginInit();
            this.bnJuro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.DiasCarencia);
            this.pDados.Controls.Add(this.TP_Juro);
            this.pDados.Controls.Add(this.PC_JuroDiario_Atrazo);
            this.pDados.Controls.Add(this.LB_CD_Juro);
            this.pDados.Controls.Add(this.LB_DS_Juro);
            this.pDados.Controls.Add(this.LB_PC_JuroDiario_Atrazo);
            this.pDados.Controls.Add(this.LB_DiasCarencia);
            this.pDados.Controls.Add(this.CD_Juro);
            this.pDados.Controls.Add(this.DS_Juro);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_JURO";
            this.pDados.NM_ProcGravar = "IA_FIN_JURO";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bnJuro);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bnJuro, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdjuroDataGridViewTextBoxColumn,
            this.dsjuroDataGridViewTextBoxColumn,
            this.tipojuroDataGridViewTextBoxColumn,
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn,
            this.diascarenciaDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bsJuro;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gCadastro.TabStop = false;
            // 
            // cdjuroDataGridViewTextBoxColumn
            // 
            this.cdjuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdjuroDataGridViewTextBoxColumn.DataPropertyName = "Cd_juro";
            resources.ApplyResources(this.cdjuroDataGridViewTextBoxColumn, "cdjuroDataGridViewTextBoxColumn");
            this.cdjuroDataGridViewTextBoxColumn.Name = "cdjuroDataGridViewTextBoxColumn";
            this.cdjuroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsjuroDataGridViewTextBoxColumn
            // 
            this.dsjuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsjuroDataGridViewTextBoxColumn.DataPropertyName = "Ds_juro";
            resources.ApplyResources(this.dsjuroDataGridViewTextBoxColumn, "dsjuroDataGridViewTextBoxColumn");
            this.dsjuroDataGridViewTextBoxColumn.Name = "dsjuroDataGridViewTextBoxColumn";
            this.dsjuroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipojuroDataGridViewTextBoxColumn
            // 
            this.tipojuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipojuroDataGridViewTextBoxColumn.DataPropertyName = "Tipo_juro";
            resources.ApplyResources(this.tipojuroDataGridViewTextBoxColumn, "tipojuroDataGridViewTextBoxColumn");
            this.tipojuroDataGridViewTextBoxColumn.Name = "tipojuroDataGridViewTextBoxColumn";
            this.tipojuroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pcjurodiarioatrazoDataGridViewTextBoxColumn
            // 
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn.DataPropertyName = "Pc_jurodiario_atrazo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N6";
            dataGridViewCellStyle3.NullValue = "0";
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.pcjurodiarioatrazoDataGridViewTextBoxColumn, "pcjurodiarioatrazoDataGridViewTextBoxColumn");
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn.Name = "pcjurodiarioatrazoDataGridViewTextBoxColumn";
            this.pcjurodiarioatrazoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diascarenciaDataGridViewTextBoxColumn
            // 
            this.diascarenciaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.diascarenciaDataGridViewTextBoxColumn.DataPropertyName = "Diascarencia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.diascarenciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.diascarenciaDataGridViewTextBoxColumn, "diascarenciaDataGridViewTextBoxColumn");
            this.diascarenciaDataGridViewTextBoxColumn.Name = "diascarenciaDataGridViewTextBoxColumn";
            this.diascarenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsJuro
            // 
            this.bsJuro.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TRegistro_CadJuro);
            // 
            // LB_CD_Juro
            // 
            resources.ApplyResources(this.LB_CD_Juro, "LB_CD_Juro");
            this.LB_CD_Juro.Name = "LB_CD_Juro";
            // 
            // LB_DS_Juro
            // 
            resources.ApplyResources(this.LB_DS_Juro, "LB_DS_Juro");
            this.LB_DS_Juro.Name = "LB_DS_Juro";
            // 
            // LB_PC_JuroDiario_Atrazo
            // 
            resources.ApplyResources(this.LB_PC_JuroDiario_Atrazo, "LB_PC_JuroDiario_Atrazo");
            this.LB_PC_JuroDiario_Atrazo.Name = "LB_PC_JuroDiario_Atrazo";
            // 
            // LB_DiasCarencia
            // 
            resources.ApplyResources(this.LB_DiasCarencia, "LB_DiasCarencia");
            this.LB_DiasCarencia.Name = "LB_DiasCarencia";
            // 
            // CD_Juro
            // 
            this.CD_Juro.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsJuro, "Cd_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Juro, "CD_Juro");
            this.CD_Juro.Name = "CD_Juro";
            this.CD_Juro.NM_Alias = "";
            this.CD_Juro.NM_Campo = "CD_Juro";
            this.CD_Juro.NM_CampoBusca = "CD_Juro";
            this.CD_Juro.NM_Param = "@P_CD_JURO";
            this.CD_Juro.QTD_Zero = 0;
            this.CD_Juro.ST_AutoInc = false;
            this.CD_Juro.ST_DisableAuto = true;
            this.CD_Juro.ST_Float = false;
            this.CD_Juro.ST_Gravar = true;
            this.CD_Juro.ST_Int = true;
            this.CD_Juro.ST_LimpaCampo = true;
            this.CD_Juro.ST_NotNull = true;
            this.CD_Juro.ST_PrimaryKey = true;
            // 
            // DS_Juro
            // 
            this.DS_Juro.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsJuro, "Ds_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Juro, "DS_Juro");
            this.DS_Juro.Name = "DS_Juro";
            this.DS_Juro.NM_Alias = "";
            this.DS_Juro.NM_Campo = "DS_Juro";
            this.DS_Juro.NM_CampoBusca = "DS_Juro";
            this.DS_Juro.NM_Param = "@P_DS_JURO";
            this.DS_Juro.QTD_Zero = 0;
            this.DS_Juro.ST_AutoInc = false;
            this.DS_Juro.ST_DisableAuto = false;
            this.DS_Juro.ST_Float = false;
            this.DS_Juro.ST_Gravar = true;
            this.DS_Juro.ST_Int = false;
            this.DS_Juro.ST_LimpaCampo = true;
            this.DS_Juro.ST_NotNull = true;
            this.DS_Juro.ST_PrimaryKey = false;
            // 
            // PC_JuroDiario_Atrazo
            // 
            this.PC_JuroDiario_Atrazo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsJuro, "Pc_jurodiario_atrazo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_JuroDiario_Atrazo.DecimalPlaces = 7;
            resources.ApplyResources(this.PC_JuroDiario_Atrazo, "PC_JuroDiario_Atrazo");
            this.PC_JuroDiario_Atrazo.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.PC_JuroDiario_Atrazo.Name = "PC_JuroDiario_Atrazo";
            this.PC_JuroDiario_Atrazo.NM_Alias = "";
            this.PC_JuroDiario_Atrazo.NM_Campo = "PC_JuroDiario_Atrazo";
            this.PC_JuroDiario_Atrazo.NM_Param = "@P_PC_JURODIARIO_ATRAZO";
            this.PC_JuroDiario_Atrazo.Operador = "";
            this.PC_JuroDiario_Atrazo.ST_AutoInc = false;
            this.PC_JuroDiario_Atrazo.ST_DisableAuto = false;
            this.PC_JuroDiario_Atrazo.ST_Gravar = true;
            this.PC_JuroDiario_Atrazo.ST_LimparCampo = true;
            this.PC_JuroDiario_Atrazo.ST_NotNull = false;
            this.PC_JuroDiario_Atrazo.ST_PrimaryKey = false;
            // 
            // TP_Juro
            // 
            this.TP_Juro.Controls.Add(this.panelDados1);
            this.TP_Juro.DataBindings.Add(new System.Windows.Forms.Binding("NM_Valor", this.bsJuro, "Tp_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.TP_Juro, "TP_Juro");
            this.TP_Juro.Name = "TP_Juro";
            this.TP_Juro.NM_Alias = "";
            this.TP_Juro.NM_Campo = "TP_Juro";
            this.TP_Juro.NM_Param = "@P_TP_JURO";
            this.TP_Juro.NM_Valor = "";
            this.TP_Juro.ST_Gravar = true;
            this.TP_Juro.ST_NotNull = false;
            this.TP_Juro.TabStop = false;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.rbSimples);
            this.panelDados1.Controls.Add(this.rbComposto);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.TabStop = true;
            // 
            // rbSimples
            // 
            resources.ApplyResources(this.rbSimples, "rbSimples");
            this.rbSimples.Name = "rbSimples";
            this.rbSimples.TabStop = true;
            this.rbSimples.UseVisualStyleBackColor = true;
            this.rbSimples.Valor = "S";
            // 
            // rbComposto
            // 
            resources.ApplyResources(this.rbComposto, "rbComposto");
            this.rbComposto.Name = "rbComposto";
            this.rbComposto.TabStop = true;
            this.rbComposto.UseVisualStyleBackColor = true;
            this.rbComposto.Valor = "C";
            // 
            // DiasCarencia
            // 
            this.DiasCarencia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsJuro, "Diascarencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DiasCarencia, "DiasCarencia");
            this.DiasCarencia.Name = "DiasCarencia";
            this.DiasCarencia.NM_Alias = "";
            this.DiasCarencia.NM_Campo = "DiasCarencia";
            this.DiasCarencia.NM_Param = "@P_DIASCARENCIA";
            this.DiasCarencia.Operador = "";
            this.DiasCarencia.ST_AutoInc = false;
            this.DiasCarencia.ST_DisableAuto = false;
            this.DiasCarencia.ST_Gravar = true;
            this.DiasCarencia.ST_LimparCampo = true;
            this.DiasCarencia.ST_NotNull = false;
            this.DiasCarencia.ST_PrimaryKey = false;
            // 
            // bnJuro
            // 
            this.bnJuro.AddNewItem = null;
            this.bnJuro.BindingSource = this.bsJuro;
            this.bnJuro.CountItem = this.bindingNavigatorCountItem;
            this.bnJuro.DeleteItem = null;
            resources.ApplyResources(this.bnJuro, "bnJuro");
            this.bnJuro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnJuro.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnJuro.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnJuro.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnJuro.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnJuro.Name = "bnJuro";
            this.bnJuro.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TFCadJuro
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadJuro";
            this.Load += new System.EventHandler(this.TFCadJuro_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadJuro_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsJuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroDiario_Atrazo)).EndInit();
            this.TP_Juro.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiasCarencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnJuro)).EndInit();
            this.bnJuro.ResumeLayout(false);
            this.bnJuro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_Juro;
        private System.Windows.Forms.Label LB_DS_Juro;
        private System.Windows.Forms.Label LB_PC_JuroDiario_Atrazo;
        private System.Windows.Forms.Label LB_DiasCarencia;
        private Componentes.EditDefault CD_Juro;
        private Componentes.EditDefault DS_Juro;
        private Componentes.EditFloat PC_JuroDiario_Atrazo;
        private Componentes.RadioGroup TP_Juro;
        private Componentes.RadioButtonDefault rbSimples;
        private Componentes.RadioButtonDefault rbComposto;
        private Componentes.EditFloat DiasCarencia;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsJuro;
        private System.Windows.Forms.BindingNavigator bnJuro;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdjuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsjuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipojuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcjurodiarioatrazoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diascarenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stcalcularvlatualboolDataGridViewCheckBoxColumn;
    }
}

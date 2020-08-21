namespace Consulta.Cadastro
{
    partial class TFCad_TipoAmarracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TipoAmarracao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Sigla_amarracao = new Componentes.EditDefault(this.components);
            this.Bs_amaracao = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.id_amarracao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NM_amarracao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.grid_UsuarioConsulta = new Componentes.DataGridDefault(this.components);
            this.iDTipoAmarracaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmTipoAmarracaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaAmarracaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_ConsultaUsuario = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_amaracao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UsuarioConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_ConsultaUsuario)).BeginInit();
            this.BN_ConsultaUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.NM_amarracao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.Sigla_amarracao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.id_amarracao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Font = null;
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.BN_ConsultaUsuario);
            this.tpPadrao.Controls.Add(this.grid_UsuarioConsulta);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.grid_UsuarioConsulta, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_ConsultaUsuario, 0);
            // 
            // Sigla_amarracao
            // 
            this.Sigla_amarracao.AccessibleDescription = null;
            this.Sigla_amarracao.AccessibleName = null;
            resources.ApplyResources(this.Sigla_amarracao, "Sigla_amarracao");
            this.Sigla_amarracao.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla_amarracao.BackgroundImage = null;
            this.Sigla_amarracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla_amarracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_amaracao, "Sigla_Amarracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sigla_amarracao.Font = null;
            this.Sigla_amarracao.Name = "Sigla_amarracao";
            this.Sigla_amarracao.NM_Alias = "a";
            this.Sigla_amarracao.NM_Campo = "Sigla_amarracao";
            this.Sigla_amarracao.NM_CampoBusca = "Sigla_amarracao";
            this.Sigla_amarracao.NM_Param = "@P_SIGLA_AMARRACAO";
            this.Sigla_amarracao.QTD_Zero = 0;
            this.Sigla_amarracao.ST_AutoInc = false;
            this.Sigla_amarracao.ST_DisableAuto = false;
            this.Sigla_amarracao.ST_Float = false;
            this.Sigla_amarracao.ST_Gravar = true;
            this.Sigla_amarracao.ST_Int = false;
            this.Sigla_amarracao.ST_LimpaCampo = true;
            this.Sigla_amarracao.ST_NotNull = true;
            this.Sigla_amarracao.ST_PrimaryKey = false;
            // 
            // Bs_amaracao
            // 
            this.Bs_amaracao.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_TipoAmarracao);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // id_amarracao
            // 
            this.id_amarracao.AccessibleDescription = null;
            this.id_amarracao.AccessibleName = null;
            resources.ApplyResources(this.id_amarracao, "id_amarracao");
            this.id_amarracao.BackColor = System.Drawing.SystemColors.Window;
            this.id_amarracao.BackgroundImage = null;
            this.id_amarracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_amarracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_amaracao, "ID_Tipo_Amarracao_STR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_amarracao.Font = null;
            this.id_amarracao.Name = "id_amarracao";
            this.id_amarracao.NM_Alias = "a";
            this.id_amarracao.NM_Campo = "id_amarracao";
            this.id_amarracao.NM_CampoBusca = "id_amarracao";
            this.id_amarracao.NM_Param = "@P_ID_AMARRACAO";
            this.id_amarracao.QTD_Zero = 0;
            this.id_amarracao.ST_AutoInc = false;
            this.id_amarracao.ST_DisableAuto = false;
            this.id_amarracao.ST_Float = false;
            this.id_amarracao.ST_Gravar = true;
            this.id_amarracao.ST_Int = true;
            this.id_amarracao.ST_LimpaCampo = true;
            this.id_amarracao.ST_NotNull = true;
            this.id_amarracao.ST_PrimaryKey = true;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NM_amarracao
            // 
            this.NM_amarracao.AccessibleDescription = null;
            this.NM_amarracao.AccessibleName = null;
            resources.ApplyResources(this.NM_amarracao, "NM_amarracao");
            this.NM_amarracao.BackColor = System.Drawing.SystemColors.Window;
            this.NM_amarracao.BackgroundImage = null;
            this.NM_amarracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_amarracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_amaracao, "Nm_Tipo_Amarracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_amarracao.Font = null;
            this.NM_amarracao.Name = "NM_amarracao";
            this.NM_amarracao.NM_Alias = "a";
            this.NM_amarracao.NM_Campo = "NM_amarracao";
            this.NM_amarracao.NM_CampoBusca = "NM_amarracao";
            this.NM_amarracao.NM_Param = "@P_NM_AMARRACAO";
            this.NM_amarracao.QTD_Zero = 0;
            this.NM_amarracao.ST_AutoInc = false;
            this.NM_amarracao.ST_DisableAuto = false;
            this.NM_amarracao.ST_Float = false;
            this.NM_amarracao.ST_Gravar = true;
            this.NM_amarracao.ST_Int = false;
            this.NM_amarracao.ST_LimpaCampo = true;
            this.NM_amarracao.ST_NotNull = true;
            this.NM_amarracao.ST_PrimaryKey = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // grid_UsuarioConsulta
            // 
            this.grid_UsuarioConsulta.AccessibleDescription = null;
            this.grid_UsuarioConsulta.AccessibleName = null;
            this.grid_UsuarioConsulta.AllowUserToAddRows = false;
            this.grid_UsuarioConsulta.AllowUserToDeleteRows = false;
            this.grid_UsuarioConsulta.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_UsuarioConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.grid_UsuarioConsulta, "grid_UsuarioConsulta");
            this.grid_UsuarioConsulta.AutoGenerateColumns = false;
            this.grid_UsuarioConsulta.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_UsuarioConsulta.BackgroundImage = null;
            this.grid_UsuarioConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_UsuarioConsulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_UsuarioConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_UsuarioConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_UsuarioConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDTipoAmarracaoDataGridViewTextBoxColumn,
            this.nmTipoAmarracaoDataGridViewTextBoxColumn,
            this.siglaAmarracaoDataGridViewTextBoxColumn});
            this.grid_UsuarioConsulta.DataSource = this.Bs_amaracao;
            this.grid_UsuarioConsulta.Font = null;
            this.grid_UsuarioConsulta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_UsuarioConsulta.Name = "grid_UsuarioConsulta";
            this.grid_UsuarioConsulta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_UsuarioConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // iDTipoAmarracaoDataGridViewTextBoxColumn
            // 
            this.iDTipoAmarracaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDTipoAmarracaoDataGridViewTextBoxColumn.DataPropertyName = "ID_Tipo_Amarracao";
            resources.ApplyResources(this.iDTipoAmarracaoDataGridViewTextBoxColumn, "iDTipoAmarracaoDataGridViewTextBoxColumn");
            this.iDTipoAmarracaoDataGridViewTextBoxColumn.Name = "iDTipoAmarracaoDataGridViewTextBoxColumn";
            this.iDTipoAmarracaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmTipoAmarracaoDataGridViewTextBoxColumn
            // 
            this.nmTipoAmarracaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmTipoAmarracaoDataGridViewTextBoxColumn.DataPropertyName = "Nm_Tipo_Amarracao";
            resources.ApplyResources(this.nmTipoAmarracaoDataGridViewTextBoxColumn, "nmTipoAmarracaoDataGridViewTextBoxColumn");
            this.nmTipoAmarracaoDataGridViewTextBoxColumn.Name = "nmTipoAmarracaoDataGridViewTextBoxColumn";
            this.nmTipoAmarracaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaAmarracaoDataGridViewTextBoxColumn
            // 
            this.siglaAmarracaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaAmarracaoDataGridViewTextBoxColumn.DataPropertyName = "Sigla_Amarracao";
            resources.ApplyResources(this.siglaAmarracaoDataGridViewTextBoxColumn, "siglaAmarracaoDataGridViewTextBoxColumn");
            this.siglaAmarracaoDataGridViewTextBoxColumn.Name = "siglaAmarracaoDataGridViewTextBoxColumn";
            this.siglaAmarracaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BN_ConsultaUsuario
            // 
            this.BN_ConsultaUsuario.AccessibleDescription = null;
            this.BN_ConsultaUsuario.AccessibleName = null;
            this.BN_ConsultaUsuario.AddNewItem = null;
            resources.ApplyResources(this.BN_ConsultaUsuario, "BN_ConsultaUsuario");
            this.BN_ConsultaUsuario.BackgroundImage = null;
            this.BN_ConsultaUsuario.BindingSource = this.Bs_amaracao;
            this.BN_ConsultaUsuario.CountItem = this.bindingNavigatorCountItem;
            this.BN_ConsultaUsuario.DeleteItem = null;
            this.BN_ConsultaUsuario.Font = null;
            this.BN_ConsultaUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.BN_ConsultaUsuario.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_ConsultaUsuario.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_ConsultaUsuario.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_ConsultaUsuario.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_ConsultaUsuario.Name = "BN_ConsultaUsuario";
            this.BN_ConsultaUsuario.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.AccessibleDescription = null;
            this.bindingNavigatorSeparator2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            // 
            // TFCad_TipoAmarracao
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_TipoAmarracao";
            this.Load += new System.EventHandler(this.TFCad_TipoAmarracao_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_amaracao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UsuarioConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_ConsultaUsuario)).EndInit();
            this.BN_ConsultaUsuario.ResumeLayout(false);
            this.BN_ConsultaUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault Sigla_amarracao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault id_amarracao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NM_amarracao;
        private System.Windows.Forms.Label label2;
        private Componentes.DataGridDefault grid_UsuarioConsulta;
        private System.Windows.Forms.BindingNavigator BN_ConsultaUsuario;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource Bs_amaracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTipoAmarracaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmTipoAmarracaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaAmarracaoDataGridViewTextBoxColumn;
    }
}
namespace FormBusca
{
    partial class TFBuscaCentroResultado
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBuscaCentroResultado));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.pCResultado = new Componentes.PanelDados(this.components);
            this.trvCResultado = new System.Windows.Forms.TreeView();
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cbxExpandir = new System.Windows.Forms.ToolStripComboBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bsCentroResult = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbResultado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbSequencia = new System.Windows.Forms.ToolStripLabel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.ds_centro = new Componentes.EditDefault(this.components);
            this.St_deducaobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.pCResultado.SuspendLayout();
            this.TS_ItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).BeginInit();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(23, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 13);
            label2.TabIndex = 63;
            label2.Text = "Centro Resultado:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 581);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.pCResultado);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 42);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(969, 536);
            this.panelDados1.TabIndex = 0;
            // 
            // pCResultado
            // 
            this.pCResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCResultado.Controls.Add(this.trvCResultado);
            this.pCResultado.Controls.Add(this.TS_ItensPedido);
            this.pCResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCResultado.Location = new System.Drawing.Point(0, 0);
            this.pCResultado.Name = "pCResultado";
            this.pCResultado.NM_ProcDeletar = "";
            this.pCResultado.NM_ProcGravar = "";
            this.pCResultado.Size = new System.Drawing.Size(967, 509);
            this.pCResultado.TabIndex = 4;
            // 
            // trvCResultado
            // 
            this.trvCResultado.AllowDrop = true;
            this.trvCResultado.BackColor = System.Drawing.Color.Silver;
            this.trvCResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvCResultado.FullRowSelect = true;
            this.trvCResultado.HideSelection = false;
            this.trvCResultado.Location = new System.Drawing.Point(0, 25);
            this.trvCResultado.Name = "trvCResultado";
            this.trvCResultado.Size = new System.Drawing.Size(965, 482);
            this.trvCResultado.TabIndex = 1;
            this.trvCResultado.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvCResultado_NodeMouseDoubleClick);
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.cbxExpandir});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(965, 25);
            this.TS_ItensPedido.TabIndex = 4;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton1.Text = "EXPANDIR";
            // 
            // cbxExpandir
            // 
            this.cbxExpandir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExpandir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cbxExpandir.Items.AddRange(new object[] {
            "TUDO",
            "NIVEL 2",
            "NENHUM"});
            this.cbxExpandir.Name = "cbxExpandir";
            this.cbxExpandir.Size = new System.Drawing.Size(121, 25);
            this.cbxExpandir.SelectedIndexChanged += new System.EventHandler(this.cbxExpandir_SelectedIndexChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCentroResult;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.lbResultado,
            this.toolStripSeparator2,
            this.lbSequencia});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 509);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(967, 25);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bsCentroResult
            // 
            this.bsCentroResult.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CentroResultado);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbResultado
            // 
            this.lbResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbResultado.ForeColor = System.Drawing.Color.Blue;
            this.lbResultado.Name = "lbResultado";
            this.lbResultado.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbSequencia
            // 
            this.lbSequencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbSequencia.ForeColor = System.Drawing.Color.Blue;
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(0, 22);
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(label2);
            this.panelDados2.Controls.Add(this.ds_centro);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(969, 33);
            this.panelDados2.TabIndex = 1;
            // 
            // ds_centro
            // 
            this.ds_centro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centro.Location = new System.Drawing.Point(121, 6);
            this.ds_centro.Name = "ds_centro";
            this.ds_centro.NM_Alias = "";
            this.ds_centro.NM_Campo = "";
            this.ds_centro.NM_CampoBusca = "";
            this.ds_centro.NM_Param = "";
            this.ds_centro.QTD_Zero = 0;
            this.ds_centro.Size = new System.Drawing.Size(673, 20);
            this.ds_centro.ST_AutoInc = false;
            this.ds_centro.ST_DisableAuto = false;
            this.ds_centro.ST_Float = false;
            this.ds_centro.ST_Gravar = false;
            this.ds_centro.ST_Int = false;
            this.ds_centro.ST_LimpaCampo = true;
            this.ds_centro.ST_NotNull = false;
            this.ds_centro.ST_PrimaryKey = false;
            this.ds_centro.TabIndex = 0;
            this.ds_centro.TextOld = null;
            this.ds_centro.TextChanged += new System.EventHandler(this.ds_centro_TextChanged);
            // 
            // St_deducaobool
            // 
            this.St_deducaobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_deducaobool.DataPropertyName = "St_deducaobool";
            this.St_deducaobool.HeaderText = "Conta Dedução";
            this.St_deducaobool.Name = "St_deducaobool";
            this.St_deducaobool.ReadOnly = true;
            // 
            // TFBuscaCentroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 581);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TFBuscaCentroResultado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca Centro Resultado";
            this.Load += new System.EventHandler(this.TFBuscaCentroResultado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBuscaCentroResultado_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.pCResultado.ResumeLayout(false);
            this.pCResultado.PerformLayout();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbResultado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbSequencia;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault ds_centro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_deducaobool;
        private Componentes.PanelDados pCResultado;
        private System.Windows.Forms.TreeView trvCResultado;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox cbxExpandir;
        private System.Windows.Forms.BindingSource bsCentroResult;
    }
}
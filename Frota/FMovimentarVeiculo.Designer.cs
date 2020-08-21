namespace Frota
{
    partial class TFMovimentarVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMovimentarVeiculo));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnEntradaDados = new Componentes.PanelDados(this.components);
            this.Ed_HodometroInicial = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.Ed_CarretaOrigem = new Componentes.EditMask(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.id_veiculoDestino = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.Ed_NrPlacaDestino = new Componentes.EditMask(this.components);
            this.Ed_NrPlacaOrigem = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BB_VeiculoDestino = new System.Windows.Forms.Button();
            this.Ed_HodometroFinal = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BB_Veiculo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnEntradaDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_HodometroInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_HodometroFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnEntradaDados, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 116);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Inutilizar NF-e";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Procedimento";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pnEntradaDados
            // 
            this.pnEntradaDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnEntradaDados.Controls.Add(this.Ed_HodometroInicial);
            this.pnEntradaDados.Controls.Add(this.label7);
            this.pnEntradaDados.Controls.Add(this.Ed_CarretaOrigem);
            this.pnEntradaDados.Controls.Add(this.label6);
            this.pnEntradaDados.Controls.Add(this.label5);
            this.pnEntradaDados.Controls.Add(this.id_veiculoDestino);
            this.pnEntradaDados.Controls.Add(this.label4);
            this.pnEntradaDados.Controls.Add(this.id_veiculo);
            this.pnEntradaDados.Controls.Add(this.Ed_NrPlacaDestino);
            this.pnEntradaDados.Controls.Add(this.Ed_NrPlacaOrigem);
            this.pnEntradaDados.Controls.Add(this.label2);
            this.pnEntradaDados.Controls.Add(this.BB_VeiculoDestino);
            this.pnEntradaDados.Controls.Add(this.Ed_HodometroFinal);
            this.pnEntradaDados.Controls.Add(this.label1);
            this.pnEntradaDados.Controls.Add(this.label3);
            this.pnEntradaDados.Controls.Add(this.BB_Veiculo);
            this.pnEntradaDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEntradaDados.Location = new System.Drawing.Point(3, 46);
            this.pnEntradaDados.Name = "pnEntradaDados";
            this.pnEntradaDados.NM_ProcDeletar = "";
            this.pnEntradaDados.NM_ProcGravar = "";
            this.pnEntradaDados.Size = new System.Drawing.Size(794, 67);
            this.pnEntradaDados.TabIndex = 1;
            // 
            // Ed_HodometroInicial
            // 
            this.Ed_HodometroInicial.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Ed_HodometroInicial.Location = new System.Drawing.Point(464, 29);
            this.Ed_HodometroInicial.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Ed_HodometroInicial.Name = "Ed_HodometroInicial";
            this.Ed_HodometroInicial.NM_Alias = "";
            this.Ed_HodometroInicial.NM_Campo = "";
            this.Ed_HodometroInicial.NM_Param = "";
            this.Ed_HodometroInicial.Operador = "";
            this.Ed_HodometroInicial.Size = new System.Drawing.Size(101, 20);
            this.Ed_HodometroInicial.ST_AutoInc = false;
            this.Ed_HodometroInicial.ST_DisableAuto = false;
            this.Ed_HodometroInicial.ST_Gravar = true;
            this.Ed_HodometroInicial.ST_LimparCampo = true;
            this.Ed_HodometroInicial.ST_NotNull = false;
            this.Ed_HodometroInicial.ST_PrimaryKey = false;
            this.Ed_HodometroInicial.TabIndex = 78;
            this.Ed_HodometroInicial.ThousandsSeparator = true;
            this.Ed_HodometroInicial.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Hodometro Inicial:";
            // 
            // Ed_CarretaOrigem
            // 
            this.Ed_CarretaOrigem.Enabled = false;
            this.Ed_CarretaOrigem.Location = new System.Drawing.Point(656, 3);
            this.Ed_CarretaOrigem.Mask = "AAA-AAAA";
            this.Ed_CarretaOrigem.Name = "Ed_CarretaOrigem";
            this.Ed_CarretaOrigem.NM_Alias = "";
            this.Ed_CarretaOrigem.NM_Campo = "placa de origem da carroceria";
            this.Ed_CarretaOrigem.NM_CampoBusca = "placaOrigem";
            this.Ed_CarretaOrigem.NM_Param = "@P_PLACA DE ORIGEM DA CARROCERIA";
            this.Ed_CarretaOrigem.Size = new System.Drawing.Size(60, 20);
            this.Ed_CarretaOrigem.ST_Gravar = true;
            this.Ed_CarretaOrigem.ST_LimpaCampo = true;
            this.Ed_CarretaOrigem.ST_NotNull = true;
            this.Ed_CarretaOrigem.ST_PrimaryKey = false;
            this.Ed_CarretaOrigem.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(571, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Carreta Origem:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "D. Veículo:";
            // 
            // id_veiculoDestino
            // 
            this.id_veiculoDestino.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculoDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculoDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculoDestino.Location = new System.Drawing.Point(258, 29);
            this.id_veiculoDestino.Name = "id_veiculoDestino";
            this.id_veiculoDestino.NM_Alias = "";
            this.id_veiculoDestino.NM_Campo = "id_veiculo";
            this.id_veiculoDestino.NM_CampoBusca = "id_veiculo";
            this.id_veiculoDestino.NM_Param = "@P_ID_VEICULO";
            this.id_veiculoDestino.QTD_Zero = 0;
            this.id_veiculoDestino.Size = new System.Drawing.Size(72, 20);
            this.id_veiculoDestino.ST_AutoInc = false;
            this.id_veiculoDestino.ST_DisableAuto = false;
            this.id_veiculoDestino.ST_Float = false;
            this.id_veiculoDestino.ST_Gravar = false;
            this.id_veiculoDestino.ST_Int = true;
            this.id_veiculoDestino.ST_LimpaCampo = true;
            this.id_veiculoDestino.ST_NotNull = false;
            this.id_veiculoDestino.ST_PrimaryKey = false;
            this.id_veiculoDestino.TabIndex = 73;
            this.id_veiculoDestino.TextOld = null;
            this.id_veiculoDestino.Leave += new System.EventHandler(this.id_veiculoDestino_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "O. Veículo:";
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.Location = new System.Drawing.Point(258, 4);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_ID_VEICULO";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = false;
            this.id_veiculo.ST_Int = true;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = false;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 70;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // Ed_NrPlacaDestino
            // 
            this.Ed_NrPlacaDestino.Location = new System.Drawing.Point(125, 29);
            this.Ed_NrPlacaDestino.Mask = "AAA-AAAA";
            this.Ed_NrPlacaDestino.Name = "Ed_NrPlacaDestino";
            this.Ed_NrPlacaDestino.NM_Alias = "";
            this.Ed_NrPlacaDestino.NM_Campo = "placa de destino da carroceria";
            this.Ed_NrPlacaDestino.NM_CampoBusca = "placaDestino";
            this.Ed_NrPlacaDestino.NM_Param = "@P_PLACA DE DESTINO DA CARROCERIA";
            this.Ed_NrPlacaDestino.Size = new System.Drawing.Size(60, 20);
            this.Ed_NrPlacaDestino.ST_Gravar = true;
            this.Ed_NrPlacaDestino.ST_LimpaCampo = true;
            this.Ed_NrPlacaDestino.ST_NotNull = true;
            this.Ed_NrPlacaDestino.ST_PrimaryKey = false;
            this.Ed_NrPlacaDestino.TabIndex = 69;
            this.Ed_NrPlacaDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ed_NrPlacaOrigem_KeyPress);
            // 
            // Ed_NrPlacaOrigem
            // 
            this.Ed_NrPlacaOrigem.Location = new System.Drawing.Point(125, 3);
            this.Ed_NrPlacaOrigem.Mask = "AAA-AAAA";
            this.Ed_NrPlacaOrigem.Name = "Ed_NrPlacaOrigem";
            this.Ed_NrPlacaOrigem.NM_Alias = "";
            this.Ed_NrPlacaOrigem.NM_Campo = "placa de origem da carroceria";
            this.Ed_NrPlacaOrigem.NM_CampoBusca = "placaOrigem";
            this.Ed_NrPlacaOrigem.NM_Param = "@P_PLACA DE ORIGEM DA CARROCERIA";
            this.Ed_NrPlacaOrigem.Size = new System.Drawing.Size(60, 20);
            this.Ed_NrPlacaOrigem.ST_Gravar = true;
            this.Ed_NrPlacaOrigem.ST_LimpaCampo = true;
            this.Ed_NrPlacaOrigem.ST_NotNull = true;
            this.Ed_NrPlacaOrigem.ST_PrimaryKey = false;
            this.Ed_NrPlacaOrigem.TabIndex = 68;
            this.Ed_NrPlacaOrigem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ed_NrPlacaOrigem_KeyPress);
            this.Ed_NrPlacaOrigem.Leave += new System.EventHandler(this.Ed_NrPlacaOrigem_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Destino Placa Cavalo:";
            // 
            // BB_VeiculoDestino
            // 
            this.BB_VeiculoDestino.Image = ((System.Drawing.Image)(resources.GetObject("BB_VeiculoDestino.Image")));
            this.BB_VeiculoDestino.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_VeiculoDestino.Location = new System.Drawing.Point(336, 29);
            this.BB_VeiculoDestino.Name = "BB_VeiculoDestino";
            this.BB_VeiculoDestino.Size = new System.Drawing.Size(29, 20);
            this.BB_VeiculoDestino.TabIndex = 66;
            this.BB_VeiculoDestino.UseVisualStyleBackColor = true;
            this.BB_VeiculoDestino.Click += new System.EventHandler(this.BB_VeiculoDestino_Click);
            // 
            // Ed_HodometroFinal
            // 
            this.Ed_HodometroFinal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Ed_HodometroFinal.Location = new System.Drawing.Point(464, 3);
            this.Ed_HodometroFinal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Ed_HodometroFinal.Name = "Ed_HodometroFinal";
            this.Ed_HodometroFinal.NM_Alias = "";
            this.Ed_HodometroFinal.NM_Campo = "";
            this.Ed_HodometroFinal.NM_Param = "";
            this.Ed_HodometroFinal.Operador = "";
            this.Ed_HodometroFinal.Size = new System.Drawing.Size(101, 20);
            this.Ed_HodometroFinal.ST_AutoInc = false;
            this.Ed_HodometroFinal.ST_DisableAuto = false;
            this.Ed_HodometroFinal.ST_Gravar = true;
            this.Ed_HodometroFinal.ST_LimparCampo = true;
            this.Ed_HodometroFinal.ST_NotNull = false;
            this.Ed_HodometroFinal.ST_PrimaryKey = false;
            this.Ed_HodometroFinal.TabIndex = 64;
            this.Ed_HodometroFinal.ThousandsSeparator = true;
            this.Ed_HodometroFinal.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Hodometro Final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Origem Placa Cavalo:";
            // 
            // BB_Veiculo
            // 
            this.BB_Veiculo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Veiculo.Image")));
            this.BB_Veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Veiculo.Location = new System.Drawing.Point(336, 4);
            this.BB_Veiculo.Name = "BB_Veiculo";
            this.BB_Veiculo.Size = new System.Drawing.Size(29, 20);
            this.BB_Veiculo.TabIndex = 53;
            this.BB_Veiculo.UseVisualStyleBackColor = true;
            this.BB_Veiculo.Click += new System.EventHandler(this.BB_Veiculo_Click);
            // 
            // TFMovimentarVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 116);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFMovimentarVeiculo";
            this.Text = "Movimentar Veículo";
            this.Load += new System.EventHandler(this.FMovimentarVeiculo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMovimentarVeiculo_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnEntradaDados.ResumeLayout(false);
            this.pnEntradaDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_HodometroInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_HodometroFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnEntradaDados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BB_Veiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BB_VeiculoDestino;
        private Componentes.EditFloat Ed_HodometroFinal;
        private System.Windows.Forms.Label label1;
        private Componentes.EditMask Ed_NrPlacaDestino;
        private Componentes.EditMask Ed_NrPlacaOrigem;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault id_veiculoDestino;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault id_veiculo;
        private Componentes.EditMask Ed_CarretaOrigem;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat Ed_HodometroInicial;
        private System.Windows.Forms.Label label7;
    }
}
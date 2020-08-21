namespace Parametros.Diversos
{
    partial class TFCadProtocolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadProtocolo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LB_CD_Protocolo = new System.Windows.Forms.Label();
            this.LB_DS_Protocolo = new System.Windows.Forms.Label();
            this.LB_DS_Porta = new System.Windows.Forms.Label();
            this.LB_BaudRate = new System.Windows.Forms.Label();
            this.LB_DataBits = new System.Windows.Forms.Label();
            this.LB_Tam_Pacote = new System.Windows.Forms.Label();
            this.CD_Protocolo = new Componentes.EditDefault(this.components);
            this.bSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Protocolo = new Componentes.EditDefault(this.components);
            this.DS_Porta = new Componentes.EditDefault(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelDados5 = new Componentes.PanelDados(this.components);
            this.tam_bufferread = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.rtsenabled = new Componentes.CheckBoxDefault(this.components);
            this.databits = new Componentes.EditDefault(this.components);
            this.dtrenabled = new Componentes.CheckBoxDefault(this.components);
            this.baudrate = new Componentes.EditDefault(this.components);
            this.handshake = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.parity = new Componentes.ComboBoxDefault(this.components);
            this.stopbits = new Componentes.ComboBoxDefault(this.components);
            this.st_discartarnull = new Componentes.CheckBoxDefault(this.components);
            this.LB_Parity = new System.Windows.Forms.Label();
            this.LB_StopBits = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelDados4 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.receivedbytes = new Componentes.EditDefault(this.components);
            this.tam_pacote = new Componentes.EditDefault(this.components);
            this.Char_psestavel_str = new Componentes.EditDefault(this.components);
            this.Char_eol_str = new Componentes.EditDefault(this.components);
            this.LB_Char_EOL = new System.Windows.Forms.Label();
            this.LB_Char_PsEstavel = new System.Windows.Forms.Label();
            this.LB_Pos_Ini = new System.Windows.Forms.Label();
            this.LB_Size_Word = new System.Windows.Forms.Label();
            this.Size_Word = new Componentes.EditDefault(this.components);
            this.Char_EOL = new Componentes.EditDefault(this.components);
            this.Pos_Ini = new Componentes.EditDefault(this.components);
            this.Char_PsEstavel = new Componentes.EditDefault(this.components);
            this.bNavegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tList_RegCadProtocoloDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.cdprotocoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprotocoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baudrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopbitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paritydisplayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chareolstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charpsestavelstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posiniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizewordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tampacoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdiscartarnullboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtrenabledboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.handshakedisplayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedBytesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rTSEnabledboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pCadastro = new Componentes.PanelDados(this.components);
            this.nm_dll = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.st_utilizardll = new Componentes.CheckBoxDefault(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelDados5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelDados4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNavegador)).BeginInit();
            this.bNavegador.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegCadProtocoloDataGridDefault)).BeginInit();
            this.pCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tableLayoutPanel1);
            this.pDados.Controls.Add(this.bNavegador);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_DIV_PROTOCOLO";
            this.pDados.NM_ProcGravar = "IA_DIV_PROTOCOLO";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            // 
            // LB_CD_Protocolo
            // 
            resources.ApplyResources(this.LB_CD_Protocolo, "LB_CD_Protocolo");
            this.LB_CD_Protocolo.Name = "LB_CD_Protocolo";
            // 
            // LB_DS_Protocolo
            // 
            resources.ApplyResources(this.LB_DS_Protocolo, "LB_DS_Protocolo");
            this.LB_DS_Protocolo.Name = "LB_DS_Protocolo";
            // 
            // LB_DS_Porta
            // 
            resources.ApplyResources(this.LB_DS_Porta, "LB_DS_Porta");
            this.LB_DS_Porta.Name = "LB_DS_Porta";
            // 
            // LB_BaudRate
            // 
            resources.ApplyResources(this.LB_BaudRate, "LB_BaudRate");
            this.LB_BaudRate.Name = "LB_BaudRate";
            // 
            // LB_DataBits
            // 
            resources.ApplyResources(this.LB_DataBits, "LB_DataBits");
            this.LB_DataBits.Name = "LB_DataBits";
            // 
            // LB_Tam_Pacote
            // 
            resources.ApplyResources(this.LB_Tam_Pacote, "LB_Tam_Pacote");
            this.LB_Tam_Pacote.Name = "LB_Tam_Pacote";
            // 
            // CD_Protocolo
            // 
            this.CD_Protocolo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Protocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Protocolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Protocolo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Cd_protocolo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Protocolo, "CD_Protocolo");
            this.CD_Protocolo.Name = "CD_Protocolo";
            this.CD_Protocolo.NM_Alias = "";
            this.CD_Protocolo.NM_Campo = "CD_Protocolo";
            this.CD_Protocolo.NM_CampoBusca = "CD_Protocolo";
            this.CD_Protocolo.NM_Param = "@P_CD_PROTOCOLO";
            this.CD_Protocolo.QTD_Zero = 0;
            this.CD_Protocolo.ST_AutoInc = true;
            this.CD_Protocolo.ST_DisableAuto = true;
            this.CD_Protocolo.ST_Float = false;
            this.CD_Protocolo.ST_Gravar = true;
            this.CD_Protocolo.ST_Int = true;
            this.CD_Protocolo.ST_LimpaCampo = true;
            this.CD_Protocolo.ST_NotNull = true;
            this.CD_Protocolo.ST_PrimaryKey = true;
            this.CD_Protocolo.TextOld = null;
            // 
            // bSource
            // 
            this.bSource.DataSource = typeof(CamadaDados.Diversos.TList_RegCadProtocolo);
            // 
            // DS_Protocolo
            // 
            this.DS_Protocolo.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Protocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Protocolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Protocolo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Ds_protocolo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Protocolo, "DS_Protocolo");
            this.DS_Protocolo.Name = "DS_Protocolo";
            this.DS_Protocolo.NM_Alias = "";
            this.DS_Protocolo.NM_Campo = "DS_Protocolo";
            this.DS_Protocolo.NM_CampoBusca = "DS_Protocolo";
            this.DS_Protocolo.NM_Param = "@P_DS_PROTOCOLO";
            this.DS_Protocolo.QTD_Zero = 0;
            this.DS_Protocolo.ST_AutoInc = false;
            this.DS_Protocolo.ST_DisableAuto = false;
            this.DS_Protocolo.ST_Float = false;
            this.DS_Protocolo.ST_Gravar = true;
            this.DS_Protocolo.ST_Int = false;
            this.DS_Protocolo.ST_LimpaCampo = true;
            this.DS_Protocolo.ST_NotNull = true;
            this.DS_Protocolo.ST_PrimaryKey = false;
            this.DS_Protocolo.TextOld = null;
            // 
            // DS_Porta
            // 
            this.DS_Porta.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Porta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Porta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Porta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Ds_porta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Porta, "DS_Porta");
            this.DS_Porta.Name = "DS_Porta";
            this.DS_Porta.NM_Alias = "";
            this.DS_Porta.NM_Campo = "DS_Porta";
            this.DS_Porta.NM_CampoBusca = "DS_Porta";
            this.DS_Porta.NM_Param = "@P_DS_PORTA";
            this.DS_Porta.QTD_Zero = 0;
            this.DS_Porta.ST_AutoInc = false;
            this.DS_Porta.ST_DisableAuto = false;
            this.DS_Porta.ST_Float = false;
            this.DS_Porta.ST_Gravar = true;
            this.DS_Porta.ST_Int = false;
            this.DS_Porta.ST_LimpaCampo = true;
            this.DS_Porta.ST_NotNull = false;
            this.DS_Porta.ST_PrimaryKey = false;
            this.DS_Porta.TextOld = null;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panelDados5);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // panelDados5
            // 
            this.panelDados5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(182)))), ((int)(((byte)(181)))));
            this.panelDados5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados5.Controls.Add(this.tam_bufferread);
            this.panelDados5.Controls.Add(this.label3);
            this.panelDados5.Controls.Add(this.rtsenabled);
            this.panelDados5.Controls.Add(this.databits);
            this.panelDados5.Controls.Add(this.dtrenabled);
            this.panelDados5.Controls.Add(this.baudrate);
            this.panelDados5.Controls.Add(this.handshake);
            this.panelDados5.Controls.Add(this.label2);
            this.panelDados5.Controls.Add(this.parity);
            this.panelDados5.Controls.Add(this.stopbits);
            this.panelDados5.Controls.Add(this.DS_Porta);
            this.panelDados5.Controls.Add(this.st_discartarnull);
            this.panelDados5.Controls.Add(this.LB_Parity);
            this.panelDados5.Controls.Add(this.LB_DS_Porta);
            this.panelDados5.Controls.Add(this.LB_DataBits);
            this.panelDados5.Controls.Add(this.LB_StopBits);
            this.panelDados5.Controls.Add(this.LB_BaudRate);
            resources.ApplyResources(this.panelDados5, "panelDados5");
            this.panelDados5.Name = "panelDados5";
            this.panelDados5.NM_ProcDeletar = "";
            this.panelDados5.NM_ProcGravar = "";
            // 
            // tam_bufferread
            // 
            this.tam_bufferread.BackColor = System.Drawing.SystemColors.Window;
            this.tam_bufferread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tam_bufferread.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tam_bufferread.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Tam_bufferread", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tam_bufferread, "tam_bufferread");
            this.tam_bufferread.Name = "tam_bufferread";
            this.tam_bufferread.NM_Alias = "";
            this.tam_bufferread.NM_Campo = "DS_Porta";
            this.tam_bufferread.NM_CampoBusca = "DS_Porta";
            this.tam_bufferread.NM_Param = "@P_DS_PORTA";
            this.tam_bufferread.QTD_Zero = 0;
            this.tam_bufferread.ST_AutoInc = false;
            this.tam_bufferread.ST_DisableAuto = false;
            this.tam_bufferread.ST_Float = false;
            this.tam_bufferread.ST_Gravar = true;
            this.tam_bufferread.ST_Int = true;
            this.tam_bufferread.ST_LimpaCampo = true;
            this.tam_bufferread.ST_NotNull = false;
            this.tam_bufferread.ST_PrimaryKey = false;
            this.tam_bufferread.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // rtsenabled
            // 
            resources.ApplyResources(this.rtsenabled, "rtsenabled");
            this.rtsenabled.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bSource, "RTSEnabledbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rtsenabled.Name = "rtsenabled";
            this.rtsenabled.NM_Alias = "";
            this.rtsenabled.NM_Campo = "";
            this.rtsenabled.NM_Param = "";
            this.rtsenabled.ST_Gravar = true;
            this.rtsenabled.ST_LimparCampo = true;
            this.rtsenabled.ST_NotNull = false;
            this.rtsenabled.UseVisualStyleBackColor = true;
            this.rtsenabled.Vl_False = "";
            this.rtsenabled.Vl_True = "";
            // 
            // databits
            // 
            this.databits.BackColor = System.Drawing.SystemColors.Window;
            this.databits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.databits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.databits.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Databits", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.databits, "databits");
            this.databits.Name = "databits";
            this.databits.NM_Alias = "";
            this.databits.NM_Campo = "DS_Porta";
            this.databits.NM_CampoBusca = "DS_Porta";
            this.databits.NM_Param = "@P_DS_PORTA";
            this.databits.QTD_Zero = 0;
            this.databits.ST_AutoInc = false;
            this.databits.ST_DisableAuto = false;
            this.databits.ST_Float = false;
            this.databits.ST_Gravar = true;
            this.databits.ST_Int = true;
            this.databits.ST_LimpaCampo = true;
            this.databits.ST_NotNull = false;
            this.databits.ST_PrimaryKey = false;
            this.databits.TextOld = null;
            // 
            // dtrenabled
            // 
            resources.ApplyResources(this.dtrenabled, "dtrenabled");
            this.dtrenabled.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bSource, "Dtrenabledbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtrenabled.Name = "dtrenabled";
            this.dtrenabled.NM_Alias = "";
            this.dtrenabled.NM_Campo = "";
            this.dtrenabled.NM_Param = "";
            this.dtrenabled.ST_Gravar = true;
            this.dtrenabled.ST_LimparCampo = true;
            this.dtrenabled.ST_NotNull = false;
            this.dtrenabled.UseVisualStyleBackColor = true;
            this.dtrenabled.Vl_False = "";
            this.dtrenabled.Vl_True = "";
            // 
            // baudrate
            // 
            this.baudrate.BackColor = System.Drawing.SystemColors.Window;
            this.baudrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baudrate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baudrate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Baudrate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.baudrate, "baudrate");
            this.baudrate.Name = "baudrate";
            this.baudrate.NM_Alias = "";
            this.baudrate.NM_Campo = "DS_Porta";
            this.baudrate.NM_CampoBusca = "DS_Porta";
            this.baudrate.NM_Param = "@P_DS_PORTA";
            this.baudrate.QTD_Zero = 0;
            this.baudrate.ST_AutoInc = false;
            this.baudrate.ST_DisableAuto = false;
            this.baudrate.ST_Float = false;
            this.baudrate.ST_Gravar = true;
            this.baudrate.ST_Int = true;
            this.baudrate.ST_LimpaCampo = true;
            this.baudrate.ST_NotNull = false;
            this.baudrate.ST_PrimaryKey = false;
            this.baudrate.TextOld = null;
            // 
            // handshake
            // 
            this.handshake.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bSource, "Handshake", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.handshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.handshake, "handshake");
            this.handshake.FormattingEnabled = true;
            this.handshake.Items.AddRange(new object[] {
            resources.GetString("handshake.Items"),
            resources.GetString("handshake.Items1"),
            resources.GetString("handshake.Items2")});
            this.handshake.Name = "handshake";
            this.handshake.NM_Alias = "";
            this.handshake.NM_Campo = "";
            this.handshake.NM_Param = "";
            this.handshake.ST_Gravar = true;
            this.handshake.ST_LimparCampo = true;
            this.handshake.ST_NotNull = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // parity
            // 
            this.parity.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bSource, "Parity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.parity, "parity");
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            resources.GetString("parity.Items"),
            resources.GetString("parity.Items1"),
            resources.GetString("parity.Items2")});
            this.parity.Name = "parity";
            this.parity.NM_Alias = "";
            this.parity.NM_Campo = "";
            this.parity.NM_Param = "";
            this.parity.ST_Gravar = true;
            this.parity.ST_LimparCampo = true;
            this.parity.ST_NotNull = false;
            // 
            // stopbits
            // 
            this.stopbits.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Stopbits", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.stopbits, "stopbits");
            this.stopbits.FormattingEnabled = true;
            this.stopbits.Items.AddRange(new object[] {
            resources.GetString("stopbits.Items"),
            resources.GetString("stopbits.Items1"),
            resources.GetString("stopbits.Items2")});
            this.stopbits.Name = "stopbits";
            this.stopbits.NM_Alias = "";
            this.stopbits.NM_Campo = "";
            this.stopbits.NM_Param = "";
            this.stopbits.ST_Gravar = true;
            this.stopbits.ST_LimparCampo = true;
            this.stopbits.ST_NotNull = false;
            // 
            // st_discartarnull
            // 
            resources.ApplyResources(this.st_discartarnull, "st_discartarnull");
            this.st_discartarnull.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bSource, "St_discartarnullbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_discartarnull.Name = "st_discartarnull";
            this.st_discartarnull.NM_Alias = "";
            this.st_discartarnull.NM_Campo = "";
            this.st_discartarnull.NM_Param = "";
            this.st_discartarnull.ST_Gravar = true;
            this.st_discartarnull.ST_LimparCampo = true;
            this.st_discartarnull.ST_NotNull = false;
            this.st_discartarnull.UseVisualStyleBackColor = true;
            this.st_discartarnull.Vl_False = "";
            this.st_discartarnull.Vl_True = "";
            // 
            // LB_Parity
            // 
            resources.ApplyResources(this.LB_Parity, "LB_Parity");
            this.LB_Parity.Name = "LB_Parity";
            // 
            // LB_StopBits
            // 
            resources.ApplyResources(this.LB_StopBits, "LB_StopBits");
            this.LB_StopBits.Name = "LB_StopBits";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelDados4);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // panelDados4
            // 
            this.panelDados4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(182)))), ((int)(((byte)(181)))));
            this.panelDados4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados4.Controls.Add(this.label1);
            this.panelDados4.Controls.Add(this.receivedbytes);
            this.panelDados4.Controls.Add(this.tam_pacote);
            this.panelDados4.Controls.Add(this.Char_psestavel_str);
            this.panelDados4.Controls.Add(this.Char_eol_str);
            this.panelDados4.Controls.Add(this.LB_Char_EOL);
            this.panelDados4.Controls.Add(this.LB_Char_PsEstavel);
            this.panelDados4.Controls.Add(this.LB_Tam_Pacote);
            this.panelDados4.Controls.Add(this.LB_Pos_Ini);
            this.panelDados4.Controls.Add(this.LB_Size_Word);
            this.panelDados4.Controls.Add(this.Size_Word);
            this.panelDados4.Controls.Add(this.Char_EOL);
            this.panelDados4.Controls.Add(this.Pos_Ini);
            this.panelDados4.Controls.Add(this.Char_PsEstavel);
            resources.ApplyResources(this.panelDados4, "panelDados4");
            this.panelDados4.Name = "panelDados4";
            this.panelDados4.NM_ProcDeletar = "";
            this.panelDados4.NM_ProcGravar = "";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // receivedbytes
            // 
            this.receivedbytes.BackColor = System.Drawing.SystemColors.Window;
            this.receivedbytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.receivedbytes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.receivedbytes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "ReceivedBytes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.receivedbytes, "receivedbytes");
            this.receivedbytes.Name = "receivedbytes";
            this.receivedbytes.NM_Alias = "";
            this.receivedbytes.NM_Campo = "Pos_Ini";
            this.receivedbytes.NM_CampoBusca = "Pos_Ini";
            this.receivedbytes.NM_Param = "@P_POS_INI";
            this.receivedbytes.QTD_Zero = 0;
            this.receivedbytes.ST_AutoInc = false;
            this.receivedbytes.ST_DisableAuto = false;
            this.receivedbytes.ST_Float = false;
            this.receivedbytes.ST_Gravar = true;
            this.receivedbytes.ST_Int = true;
            this.receivedbytes.ST_LimpaCampo = true;
            this.receivedbytes.ST_NotNull = false;
            this.receivedbytes.ST_PrimaryKey = false;
            this.receivedbytes.TextOld = null;
            // 
            // tam_pacote
            // 
            this.tam_pacote.BackColor = System.Drawing.SystemColors.Window;
            this.tam_pacote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tam_pacote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tam_pacote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Tam_pacote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tam_pacote, "tam_pacote");
            this.tam_pacote.Name = "tam_pacote";
            this.tam_pacote.NM_Alias = "";
            this.tam_pacote.NM_Campo = "Size_Word";
            this.tam_pacote.NM_CampoBusca = "Size_Word";
            this.tam_pacote.NM_Param = "@P_SIZE_WORD";
            this.tam_pacote.QTD_Zero = 0;
            this.tam_pacote.ST_AutoInc = false;
            this.tam_pacote.ST_DisableAuto = false;
            this.tam_pacote.ST_Float = false;
            this.tam_pacote.ST_Gravar = true;
            this.tam_pacote.ST_Int = true;
            this.tam_pacote.ST_LimpaCampo = true;
            this.tam_pacote.ST_NotNull = false;
            this.tam_pacote.ST_PrimaryKey = false;
            this.tam_pacote.TextOld = null;
            // 
            // Char_psestavel_str
            // 
            this.Char_psestavel_str.BackColor = System.Drawing.SystemColors.Window;
            this.Char_psestavel_str.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Char_psestavel_str.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Char_psestavel_str.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Char_psestavel_str", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Char_psestavel_str, "Char_psestavel_str");
            this.Char_psestavel_str.Name = "Char_psestavel_str";
            this.Char_psestavel_str.NM_Alias = "";
            this.Char_psestavel_str.NM_Campo = "Char_PsEstavel";
            this.Char_psestavel_str.NM_CampoBusca = "Char_PsEstavel";
            this.Char_psestavel_str.NM_Param = "@P_CHAR_PSESTAVEL";
            this.Char_psestavel_str.QTD_Zero = 0;
            this.Char_psestavel_str.ST_AutoInc = false;
            this.Char_psestavel_str.ST_DisableAuto = false;
            this.Char_psestavel_str.ST_Float = false;
            this.Char_psestavel_str.ST_Gravar = true;
            this.Char_psestavel_str.ST_Int = false;
            this.Char_psestavel_str.ST_LimpaCampo = true;
            this.Char_psestavel_str.ST_NotNull = false;
            this.Char_psestavel_str.ST_PrimaryKey = false;
            this.Char_psestavel_str.TextOld = null;
            // 
            // Char_eol_str
            // 
            this.Char_eol_str.BackColor = System.Drawing.SystemColors.Window;
            this.Char_eol_str.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Char_eol_str.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Char_eol_str.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Char_eol_str", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Char_eol_str, "Char_eol_str");
            this.Char_eol_str.Name = "Char_eol_str";
            this.Char_eol_str.NM_Alias = "";
            this.Char_eol_str.NM_Campo = "Char_EOL";
            this.Char_eol_str.NM_CampoBusca = "Char_EOL";
            this.Char_eol_str.NM_Param = "@P_CHAR_EOL";
            this.Char_eol_str.QTD_Zero = 0;
            this.Char_eol_str.ST_AutoInc = false;
            this.Char_eol_str.ST_DisableAuto = false;
            this.Char_eol_str.ST_Float = false;
            this.Char_eol_str.ST_Gravar = true;
            this.Char_eol_str.ST_Int = false;
            this.Char_eol_str.ST_LimpaCampo = true;
            this.Char_eol_str.ST_NotNull = false;
            this.Char_eol_str.ST_PrimaryKey = false;
            this.Char_eol_str.TextOld = null;
            // 
            // LB_Char_EOL
            // 
            resources.ApplyResources(this.LB_Char_EOL, "LB_Char_EOL");
            this.LB_Char_EOL.Name = "LB_Char_EOL";
            // 
            // LB_Char_PsEstavel
            // 
            resources.ApplyResources(this.LB_Char_PsEstavel, "LB_Char_PsEstavel");
            this.LB_Char_PsEstavel.Name = "LB_Char_PsEstavel";
            // 
            // LB_Pos_Ini
            // 
            resources.ApplyResources(this.LB_Pos_Ini, "LB_Pos_Ini");
            this.LB_Pos_Ini.Name = "LB_Pos_Ini";
            // 
            // LB_Size_Word
            // 
            resources.ApplyResources(this.LB_Size_Word, "LB_Size_Word");
            this.LB_Size_Word.Name = "LB_Size_Word";
            // 
            // Size_Word
            // 
            this.Size_Word.BackColor = System.Drawing.SystemColors.Window;
            this.Size_Word.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size_Word.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Size_Word.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Size_word", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Size_Word, "Size_Word");
            this.Size_Word.Name = "Size_Word";
            this.Size_Word.NM_Alias = "";
            this.Size_Word.NM_Campo = "Size_Word";
            this.Size_Word.NM_CampoBusca = "Size_Word";
            this.Size_Word.NM_Param = "@P_SIZE_WORD";
            this.Size_Word.QTD_Zero = 0;
            this.Size_Word.ST_AutoInc = false;
            this.Size_Word.ST_DisableAuto = false;
            this.Size_Word.ST_Float = false;
            this.Size_Word.ST_Gravar = true;
            this.Size_Word.ST_Int = true;
            this.Size_Word.ST_LimpaCampo = true;
            this.Size_Word.ST_NotNull = false;
            this.Size_Word.ST_PrimaryKey = false;
            this.Size_Word.TextOld = null;
            // 
            // Char_EOL
            // 
            this.Char_EOL.BackColor = System.Drawing.SystemColors.Window;
            this.Char_EOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Char_EOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Char_EOL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Char_eol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Char_EOL, "Char_EOL");
            this.Char_EOL.Name = "Char_EOL";
            this.Char_EOL.NM_Alias = "";
            this.Char_EOL.NM_Campo = "Char_EOL";
            this.Char_EOL.NM_CampoBusca = "Char_EOL";
            this.Char_EOL.NM_Param = "@P_CHAR_EOL";
            this.Char_EOL.QTD_Zero = 0;
            this.Char_EOL.ST_AutoInc = false;
            this.Char_EOL.ST_DisableAuto = false;
            this.Char_EOL.ST_Float = false;
            this.Char_EOL.ST_Gravar = true;
            this.Char_EOL.ST_Int = false;
            this.Char_EOL.ST_LimpaCampo = true;
            this.Char_EOL.ST_NotNull = false;
            this.Char_EOL.ST_PrimaryKey = false;
            this.Char_EOL.TextOld = null;
            // 
            // Pos_Ini
            // 
            this.Pos_Ini.BackColor = System.Drawing.SystemColors.Window;
            this.Pos_Ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pos_Ini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Pos_Ini.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Pos_ini", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Pos_Ini, "Pos_Ini");
            this.Pos_Ini.Name = "Pos_Ini";
            this.Pos_Ini.NM_Alias = "";
            this.Pos_Ini.NM_Campo = "Pos_Ini";
            this.Pos_Ini.NM_CampoBusca = "Pos_Ini";
            this.Pos_Ini.NM_Param = "@P_POS_INI";
            this.Pos_Ini.QTD_Zero = 0;
            this.Pos_Ini.ST_AutoInc = false;
            this.Pos_Ini.ST_DisableAuto = false;
            this.Pos_Ini.ST_Float = false;
            this.Pos_Ini.ST_Gravar = true;
            this.Pos_Ini.ST_Int = true;
            this.Pos_Ini.ST_LimpaCampo = true;
            this.Pos_Ini.ST_NotNull = false;
            this.Pos_Ini.ST_PrimaryKey = false;
            this.Pos_Ini.TextOld = null;
            // 
            // Char_PsEstavel
            // 
            this.Char_PsEstavel.BackColor = System.Drawing.SystemColors.Window;
            this.Char_PsEstavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Char_PsEstavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Char_PsEstavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Char_psestavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Char_PsEstavel, "Char_PsEstavel");
            this.Char_PsEstavel.Name = "Char_PsEstavel";
            this.Char_PsEstavel.NM_Alias = "";
            this.Char_PsEstavel.NM_Campo = "Char_PsEstavel";
            this.Char_PsEstavel.NM_CampoBusca = "Char_PsEstavel";
            this.Char_PsEstavel.NM_Param = "@P_CHAR_PSESTAVEL";
            this.Char_PsEstavel.QTD_Zero = 0;
            this.Char_PsEstavel.ST_AutoInc = false;
            this.Char_PsEstavel.ST_DisableAuto = false;
            this.Char_PsEstavel.ST_Float = false;
            this.Char_PsEstavel.ST_Gravar = true;
            this.Char_PsEstavel.ST_Int = false;
            this.Char_PsEstavel.ST_LimpaCampo = true;
            this.Char_PsEstavel.ST_NotNull = false;
            this.Char_PsEstavel.ST_PrimaryKey = false;
            this.Char_PsEstavel.TextOld = null;
            // 
            // bNavegador
            // 
            this.bNavegador.AddNewItem = null;
            this.bNavegador.BindingSource = this.bSource;
            this.bNavegador.CountItem = this.bindingNavigatorCountItem;
            this.bNavegador.CountItemFormat = "de {0}";
            this.bNavegador.DeleteItem = null;
            resources.ApplyResources(this.bNavegador, "bNavegador");
            this.bNavegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bNavegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNavegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNavegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNavegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNavegador.Name = "bNavegador";
            this.bNavegador.PositionItem = this.bindingNavigatorPositionItem;
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tList_RegCadProtocoloDataGridDefault, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pCadastro, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tList_RegCadProtocoloDataGridDefault
            // 
            this.tList_RegCadProtocoloDataGridDefault.AllowUserToAddRows = false;
            this.tList_RegCadProtocoloDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_RegCadProtocoloDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.tList_RegCadProtocoloDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tList_RegCadProtocoloDataGridDefault.AutoGenerateColumns = false;
            this.tList_RegCadProtocoloDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_RegCadProtocoloDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_RegCadProtocoloDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegCadProtocoloDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.tList_RegCadProtocoloDataGridDefault, "tList_RegCadProtocoloDataGridDefault");
            this.tList_RegCadProtocoloDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprotocoloDataGridViewTextBoxColumn,
            this.dsprotocoloDataGridViewTextBoxColumn,
            this.dsportaDataGridViewTextBoxColumn,
            this.baudrateDataGridViewTextBoxColumn,
            this.databitsDataGridViewTextBoxColumn,
            this.stopbitsDataGridViewTextBoxColumn,
            this.paritydisplayDataGridViewTextBoxColumn,
            this.chareolstrDataGridViewTextBoxColumn,
            this.charpsestavelstrDataGridViewTextBoxColumn,
            this.posiniDataGridViewTextBoxColumn,
            this.sizewordDataGridViewTextBoxColumn,
            this.tampacoteDataGridViewTextBoxColumn,
            this.stdiscartarnullboolDataGridViewCheckBoxColumn,
            this.dtrenabledboolDataGridViewCheckBoxColumn,
            this.handshakedisplayDataGridViewTextBoxColumn,
            this.receivedBytesDataGridViewTextBoxColumn,
            this.rTSEnabledboolDataGridViewCheckBoxColumn});
            this.tList_RegCadProtocoloDataGridDefault.DataSource = this.bSource;
            this.tList_RegCadProtocoloDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_RegCadProtocoloDataGridDefault.Name = "tList_RegCadProtocoloDataGridDefault";
            this.tList_RegCadProtocoloDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegCadProtocoloDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // cdprotocoloDataGridViewTextBoxColumn
            // 
            this.cdprotocoloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprotocoloDataGridViewTextBoxColumn.DataPropertyName = "Cd_protocolo";
            resources.ApplyResources(this.cdprotocoloDataGridViewTextBoxColumn, "cdprotocoloDataGridViewTextBoxColumn");
            this.cdprotocoloDataGridViewTextBoxColumn.Name = "cdprotocoloDataGridViewTextBoxColumn";
            this.cdprotocoloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprotocoloDataGridViewTextBoxColumn
            // 
            this.dsprotocoloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprotocoloDataGridViewTextBoxColumn.DataPropertyName = "Ds_protocolo";
            resources.ApplyResources(this.dsprotocoloDataGridViewTextBoxColumn, "dsprotocoloDataGridViewTextBoxColumn");
            this.dsprotocoloDataGridViewTextBoxColumn.Name = "dsprotocoloDataGridViewTextBoxColumn";
            this.dsprotocoloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsportaDataGridViewTextBoxColumn
            // 
            this.dsportaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportaDataGridViewTextBoxColumn.DataPropertyName = "Ds_porta";
            resources.ApplyResources(this.dsportaDataGridViewTextBoxColumn, "dsportaDataGridViewTextBoxColumn");
            this.dsportaDataGridViewTextBoxColumn.Name = "dsportaDataGridViewTextBoxColumn";
            this.dsportaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baudrateDataGridViewTextBoxColumn
            // 
            this.baudrateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.baudrateDataGridViewTextBoxColumn.DataPropertyName = "Baudrate";
            resources.ApplyResources(this.baudrateDataGridViewTextBoxColumn, "baudrateDataGridViewTextBoxColumn");
            this.baudrateDataGridViewTextBoxColumn.Name = "baudrateDataGridViewTextBoxColumn";
            this.baudrateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // databitsDataGridViewTextBoxColumn
            // 
            this.databitsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.databitsDataGridViewTextBoxColumn.DataPropertyName = "Databits";
            resources.ApplyResources(this.databitsDataGridViewTextBoxColumn, "databitsDataGridViewTextBoxColumn");
            this.databitsDataGridViewTextBoxColumn.Name = "databitsDataGridViewTextBoxColumn";
            this.databitsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stopbitsDataGridViewTextBoxColumn
            // 
            this.stopbitsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stopbitsDataGridViewTextBoxColumn.DataPropertyName = "Stopbits";
            resources.ApplyResources(this.stopbitsDataGridViewTextBoxColumn, "stopbitsDataGridViewTextBoxColumn");
            this.stopbitsDataGridViewTextBoxColumn.Name = "stopbitsDataGridViewTextBoxColumn";
            this.stopbitsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paritydisplayDataGridViewTextBoxColumn
            // 
            this.paritydisplayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.paritydisplayDataGridViewTextBoxColumn.DataPropertyName = "Paritydisplay";
            resources.ApplyResources(this.paritydisplayDataGridViewTextBoxColumn, "paritydisplayDataGridViewTextBoxColumn");
            this.paritydisplayDataGridViewTextBoxColumn.Name = "paritydisplayDataGridViewTextBoxColumn";
            this.paritydisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chareolstrDataGridViewTextBoxColumn
            // 
            this.chareolstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.chareolstrDataGridViewTextBoxColumn.DataPropertyName = "Char_eol_str";
            resources.ApplyResources(this.chareolstrDataGridViewTextBoxColumn, "chareolstrDataGridViewTextBoxColumn");
            this.chareolstrDataGridViewTextBoxColumn.Name = "chareolstrDataGridViewTextBoxColumn";
            this.chareolstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // charpsestavelstrDataGridViewTextBoxColumn
            // 
            this.charpsestavelstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.charpsestavelstrDataGridViewTextBoxColumn.DataPropertyName = "Char_psestavel_str";
            resources.ApplyResources(this.charpsestavelstrDataGridViewTextBoxColumn, "charpsestavelstrDataGridViewTextBoxColumn");
            this.charpsestavelstrDataGridViewTextBoxColumn.Name = "charpsestavelstrDataGridViewTextBoxColumn";
            this.charpsestavelstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // posiniDataGridViewTextBoxColumn
            // 
            this.posiniDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.posiniDataGridViewTextBoxColumn.DataPropertyName = "Pos_ini";
            resources.ApplyResources(this.posiniDataGridViewTextBoxColumn, "posiniDataGridViewTextBoxColumn");
            this.posiniDataGridViewTextBoxColumn.Name = "posiniDataGridViewTextBoxColumn";
            this.posiniDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizewordDataGridViewTextBoxColumn
            // 
            this.sizewordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sizewordDataGridViewTextBoxColumn.DataPropertyName = "Size_word";
            resources.ApplyResources(this.sizewordDataGridViewTextBoxColumn, "sizewordDataGridViewTextBoxColumn");
            this.sizewordDataGridViewTextBoxColumn.Name = "sizewordDataGridViewTextBoxColumn";
            this.sizewordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tampacoteDataGridViewTextBoxColumn
            // 
            this.tampacoteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tampacoteDataGridViewTextBoxColumn.DataPropertyName = "Tam_pacote";
            resources.ApplyResources(this.tampacoteDataGridViewTextBoxColumn, "tampacoteDataGridViewTextBoxColumn");
            this.tampacoteDataGridViewTextBoxColumn.Name = "tampacoteDataGridViewTextBoxColumn";
            this.tampacoteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stdiscartarnullboolDataGridViewCheckBoxColumn
            // 
            this.stdiscartarnullboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdiscartarnullboolDataGridViewCheckBoxColumn.DataPropertyName = "St_discartarnullbool";
            resources.ApplyResources(this.stdiscartarnullboolDataGridViewCheckBoxColumn, "stdiscartarnullboolDataGridViewCheckBoxColumn");
            this.stdiscartarnullboolDataGridViewCheckBoxColumn.Name = "stdiscartarnullboolDataGridViewCheckBoxColumn";
            this.stdiscartarnullboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dtrenabledboolDataGridViewCheckBoxColumn
            // 
            this.dtrenabledboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtrenabledboolDataGridViewCheckBoxColumn.DataPropertyName = "Dtrenabledbool";
            resources.ApplyResources(this.dtrenabledboolDataGridViewCheckBoxColumn, "dtrenabledboolDataGridViewCheckBoxColumn");
            this.dtrenabledboolDataGridViewCheckBoxColumn.Name = "dtrenabledboolDataGridViewCheckBoxColumn";
            this.dtrenabledboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // handshakedisplayDataGridViewTextBoxColumn
            // 
            this.handshakedisplayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.handshakedisplayDataGridViewTextBoxColumn.DataPropertyName = "Handshakedisplay";
            resources.ApplyResources(this.handshakedisplayDataGridViewTextBoxColumn, "handshakedisplayDataGridViewTextBoxColumn");
            this.handshakedisplayDataGridViewTextBoxColumn.Name = "handshakedisplayDataGridViewTextBoxColumn";
            this.handshakedisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receivedBytesDataGridViewTextBoxColumn
            // 
            this.receivedBytesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.receivedBytesDataGridViewTextBoxColumn.DataPropertyName = "ReceivedBytes";
            resources.ApplyResources(this.receivedBytesDataGridViewTextBoxColumn, "receivedBytesDataGridViewTextBoxColumn");
            this.receivedBytesDataGridViewTextBoxColumn.Name = "receivedBytesDataGridViewTextBoxColumn";
            this.receivedBytesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rTSEnabledboolDataGridViewCheckBoxColumn
            // 
            this.rTSEnabledboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rTSEnabledboolDataGridViewCheckBoxColumn.DataPropertyName = "RTSEnabledbool";
            resources.ApplyResources(this.rTSEnabledboolDataGridViewCheckBoxColumn, "rTSEnabledboolDataGridViewCheckBoxColumn");
            this.rTSEnabledboolDataGridViewCheckBoxColumn.Name = "rTSEnabledboolDataGridViewCheckBoxColumn";
            this.rTSEnabledboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // pCadastro
            // 
            this.pCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCadastro.Controls.Add(this.nm_dll);
            this.pCadastro.Controls.Add(this.label4);
            this.pCadastro.Controls.Add(this.st_utilizardll);
            this.pCadastro.Controls.Add(this.button1);
            this.pCadastro.Controls.Add(this.DS_Protocolo);
            this.pCadastro.Controls.Add(this.groupBox3);
            this.pCadastro.Controls.Add(this.groupBox2);
            this.pCadastro.Controls.Add(this.CD_Protocolo);
            this.pCadastro.Controls.Add(this.LB_DS_Protocolo);
            this.pCadastro.Controls.Add(this.LB_CD_Protocolo);
            resources.ApplyResources(this.pCadastro, "pCadastro");
            this.pCadastro.Name = "pCadastro";
            this.pCadastro.NM_ProcDeletar = "";
            this.pCadastro.NM_ProcGravar = "";
            // 
            // nm_dll
            // 
            this.nm_dll.BackColor = System.Drawing.SystemColors.Window;
            this.nm_dll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_dll.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_dll.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bSource, "Nm_dll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_dll, "nm_dll");
            this.nm_dll.Name = "nm_dll";
            this.nm_dll.NM_Alias = "";
            this.nm_dll.NM_Campo = "DS_Porta";
            this.nm_dll.NM_CampoBusca = "DS_Porta";
            this.nm_dll.NM_Param = "@P_DS_PORTA";
            this.nm_dll.QTD_Zero = 0;
            this.nm_dll.ST_AutoInc = false;
            this.nm_dll.ST_DisableAuto = false;
            this.nm_dll.ST_Float = false;
            this.nm_dll.ST_Gravar = true;
            this.nm_dll.ST_Int = false;
            this.nm_dll.ST_LimpaCampo = true;
            this.nm_dll.ST_NotNull = false;
            this.nm_dll.ST_PrimaryKey = false;
            this.nm_dll.TextOld = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // st_utilizardll
            // 
            resources.ApplyResources(this.st_utilizardll, "st_utilizardll");
            this.st_utilizardll.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bSource, "St_utilizardllbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_utilizardll.Name = "st_utilizardll";
            this.st_utilizardll.NM_Alias = "";
            this.st_utilizardll.NM_Campo = "";
            this.st_utilizardll.NM_Param = "";
            this.st_utilizardll.ST_Gravar = true;
            this.st_utilizardll.ST_LimparCampo = true;
            this.st_utilizardll.ST_NotNull = false;
            this.st_utilizardll.UseVisualStyleBackColor = true;
            this.st_utilizardll.Vl_False = "";
            this.st_utilizardll.Vl_True = "";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TFCadProtocolo
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadProtocolo";
            this.Load += new System.EventHandler(this.TFCadProtocolo_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelDados5.ResumeLayout(false);
            this.panelDados5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panelDados4.ResumeLayout(false);
            this.panelDados4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNavegador)).EndInit();
            this.bNavegador.ResumeLayout(false);
            this.bNavegador.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegCadProtocoloDataGridDefault)).EndInit();
            this.pCadastro.ResumeLayout(false);
            this.pCadastro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //--------------------------------------------------------------- 
        private System.Windows.Forms.Label LB_CD_Protocolo;
        private System.Windows.Forms.Label LB_DS_Protocolo;
        private System.Windows.Forms.Label LB_DS_Porta;
        private System.Windows.Forms.Label LB_BaudRate;
        private System.Windows.Forms.Label LB_DataBits;
        private System.Windows.Forms.Label LB_Tam_Pacote;




        //--------------------------------------------------------- 
        private Componentes.EditDefault CD_Protocolo;
        private Componentes.EditDefault DS_Protocolo;
        private Componentes.EditDefault DS_Porta;
        private System.Windows.Forms.GroupBox groupBox2;
        private Componentes.PanelDados panelDados5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingNavigator bNavegador;
        private System.Windows.Forms.BindingSource bSource;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados panelDados4;
        private System.Windows.Forms.Label LB_Char_EOL;
        private System.Windows.Forms.Label LB_Char_PsEstavel;
        private System.Windows.Forms.Label LB_Pos_Ini;
        private System.Windows.Forms.Label LB_Size_Word;
        private Componentes.EditDefault Size_Word;
        private Componentes.EditDefault Char_EOL;
        private Componentes.EditDefault Pos_Ini;
        private Componentes.EditDefault Char_PsEstavel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.DataGridDefault tList_RegCadProtocoloDataGridDefault;
        private Componentes.PanelDados pCadastro;
        private Componentes.EditDefault Char_eol_str;
        private Componentes.EditDefault Char_psestavel_str;
        private System.Windows.Forms.Label LB_Parity;
        private System.Windows.Forms.Label LB_StopBits;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private Componentes.ComboBoxDefault stopbits;
        private Componentes.ComboBoxDefault parity;
        private Componentes.CheckBoxDefault st_discartarnull;
        private Componentes.EditDefault tam_pacote;
        private Componentes.ComboBoxDefault handshake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault receivedbytes;
        private Componentes.CheckBoxDefault dtrenabled;
        private Componentes.CheckBoxDefault rtsenabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprotocoloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprotocoloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baudrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopbitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paritydisplayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chareolstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charpsestavelstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posiniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizewordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tampacoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdiscartarnullboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtrenabledboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handshakedisplayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedBytesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rTSEnabledboolDataGridViewCheckBoxColumn;
        private Componentes.EditDefault databits;
        private Componentes.EditDefault baudrate;
        private Componentes.EditDefault tam_bufferread;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_dll;
        private System.Windows.Forms.Label label4;
        private Componentes.CheckBoxDefault st_utilizardll;
    }
}

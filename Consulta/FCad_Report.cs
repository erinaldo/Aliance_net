using System;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;

namespace Consulta
{
    public partial class TFCad_Report : Form
    {
        private TRegistro_Cad_Report rreport;
        public TRegistro_Cad_Report rReport
        {
            get
            {
                if (BS_Relatorio.Current != null)
                    return BS_Relatorio.Current as TRegistro_Cad_Report;
                else
                    return null;
            }
            set { rreport = value; }
        }

        private ImageList il = new ImageList();
        private TList_Cad_Consulta lConsulta = new TList_Cad_Consulta();
        public bool BIntelegence = false;
        public string URLWebService = string.Empty;

        public TFCad_Report()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("Almoxarifado", "AMX"));
            cbx.Add(new Utils.TDataCombo("Balança", "BAL"));
            cbx.Add(new Utils.TDataCombo("Compras", "CMP"));
            cbx.Add(new Utils.TDataCombo("Consulta", "CON"));
            cbx.Add(new Utils.TDataCombo("Contabilidade", "CTB"));
            cbx.Add(new Utils.TDataCombo("Parametros", "DIV"));
            cbx.Add(new Utils.TDataCombo("Estoque", "EST"));
            cbx.Add(new Utils.TDataCombo("Empreendimento", "EMP"));
            cbx.Add(new Utils.TDataCombo("Produção", "PRD"));
            cbx.Add(new Utils.TDataCombo("Faturamento", "FAT"));
            cbx.Add(new Utils.TDataCombo("Fazenda", "FAZ"));
            cbx.Add(new Utils.TDataCombo("Financeiro", "FIN"));
            cbx.Add(new Utils.TDataCombo("Fiscal", "FIS"));
            cbx.Add(new Utils.TDataCombo("Frente Caixa", "PDV"));
            cbx.Add(new Utils.TDataCombo("Frota", "FRT"));
            cbx.Add(new Utils.TDataCombo("Grãos", "GRO"));
            cbx.Add(new Utils.TDataCombo("Mudança", "MUD"));
            cbx.Add(new Utils.TDataCombo("Locação", "LOC"));
            cbx.Add(new Utils.TDataCombo("Ordem Serviço", "OSE"));
            cbx.Add(new Utils.TDataCombo("Posto Combustivel", "POC"));
            cbx.Add(new Utils.TDataCombo("Sementes", " SEM"));

            cbModulo.DataSource = cbx;
            cbModulo.DisplayMember = "Display";
            cbModulo.ValueMember = "Value";

            //POPULA AS CONSULTAS DE MENUS
            PopulaConsultas();

            il.Images.Add(Consulta.Properties.Resources.ico_3);
            treeConsultaBusca.ImageList = il;
            treeConsulta.ImageList = il;
        }

        public void PopulaConsultas()
        {
            lConsulta = TCN_Cad_Consulta.Busca(decimal.Zero, 
                                               string.Empty, 
                                               string.Empty, 
                                               decimal.Zero);
            lConsulta.ForEach(p =>
            {
                TreeNode noMenu = new TreeNode(p.DS_Consulta.Trim());
                noMenu.Name = p.ID_Consulta.ToString().Trim();
                noMenu.ImageIndex = 0;

                treeConsultaBusca.Nodes.AddRange(new TreeNode[] { noMenu });
            });
        }

        public TRegistro_Cad_Consulta BuscaConsulta(string IDConsulta)
        {
            TRegistro_Cad_Consulta reg_Consulta = null;
            foreach (TRegistro_Cad_Consulta RegConsulta in lConsulta)
            {
                if (RegConsulta.ID_Consulta == IDConsulta)
                {
                    reg_Consulta = RegConsulta;
                    break;
                }
            }

            return reg_Consulta;
        }

        public void AtualizaTreeConsulta()
        {
            treeConsultaBusca.Nodes.Clear();
            lConsulta.ForEach(p =>
            {
                TreeNode noMenu = new TreeNode(p.DS_Consulta.Trim());
                noMenu.Name = p.ID_Consulta.ToString().Trim();
                noMenu.ImageIndex = 0;

                if (!treeConsulta.Nodes.ContainsKey(noMenu.Name.Trim()))
                    treeConsultaBusca.Nodes.AddRange(new TreeNode[] { noMenu });
            });
        }

        private void afterGrava()
        {
            if (cbModulo.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar MODULO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbModulo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DS_Report.Text))
            {
                MessageBox.Show("Obrigatorio informar nome Relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DS_Report.Focus();
                return;
            }
            if ((BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Count.Equals(0))
            {
                MessageBox.Show("Obrigatorio selecionar consulta para gravar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFCad_Report_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rreport != null)
            {
                BS_Relatorio.DataSource = new TList_Cad_Report() { rreport };
                rreport.lConsulta.ForEach(p =>
                    {
                        TreeNode noMenu = new TreeNode(p.DS_Consulta.Trim());
                        noMenu.Name = p.ID_Consulta.ToString().Trim();
                        noMenu.ImageIndex = 0;

                        treeConsulta.Nodes.AddRange(new TreeNode[] { noMenu });
                    });
                this.AtualizaTreeConsulta();
            }
            else
            {
                bb_Menu.Visible = false;
                bbEditReport.Visible = false;
                BS_Relatorio.AddNew();
            }
        }

        private void bbEditReport_Click(object sender, EventArgs e)
        {
            Type t = null;
            if (BIntelegence)
            {
                t = Application.OpenForms["TFBInteligence"].GetType();
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "N" });
            }

            Query_Report relatorio = new Query_Report();
            relatorio.Homologacao = true;
            relatorio.vEditor = true;
            if (BIntelegence)
                relatorio.vBIntelligence = true;
            relatorio.vURLWebService = URLWebService;
            relatorio.vSistema = "AL";
            relatorio.MontaFormRelatorio((BS_Relatorio.Current as TRegistro_Cad_Report), null);

            (BS_Relatorio.Current as TRegistro_Cad_Report).Code_Report = relatorio.Cad_Report.Code_Report;
            (BS_Relatorio.Current as TRegistro_Cad_Report).Code_Chart = relatorio.Cad_Report.Code_Chart;
            (BS_Relatorio.Current as TRegistro_Cad_Report).Code_DataCube = relatorio.Cad_Report.Code_DataCube;
            BS_Relatorio.ResetBindings(true);
            if (BIntelegence)
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "C" });
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os relatórios selecionados?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                (BS_Relatorio.Current as TRegistro_Cad_Report).Code_Report = null;
        }

        private void bb_Menu_Click(object sender, EventArgs e)
        {
            if (BS_Relatorio.Current != null)
            {
                //GRAVA O MENU
                TFEscolha_Menu fMenu = new TFEscolha_Menu();
                fMenu.Cad_Report = (BS_Relatorio.Current as TRegistro_Cad_Report);

                if (fMenu.ShowDialog() == DialogResult.OK)
                {
                    string retornomenu = TCN_Cad_Report.GravarReportXMenu((BS_Relatorio.Current as TRegistro_Cad_Report), fMenu.Reg_CadMenu, null);

                    if (!BIntelegence)
                    {
                        //CARREGA NOVAMENTE O MENU
                        Type t = Application.OpenForms["FMenuPrin"].GetType();
                        t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { "MASTER", true });
                    }
                    else
                    {
                        //CARREGA NOVAMENTE O MENU
                        Type t = Application.OpenForms["TFBInteligence"].GetType();
                        t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "C" });
                        t.GetMethod("PopulaMenus").Invoke(Application.OpenForms["TFBInteligence"], null);
                    }
                }
            }
        }

        private void tsBB_AddConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                TFCad_SQL fSQL = new TFCad_SQL(new TRegistro_Cad_Consulta(), true);
                fSQL.Homologacao = true;
                fSQL.pNMConsulta.Visible = true;
                fSQL.ShowDialog();

                if (!string.IsNullOrEmpty(fSQL.Cad_Consulta.DS_SQL))
                {
                    //ADD OS DADOS QUE FALTA
                    fSQL.Cad_Consulta.DS_Consulta = fSQL.NM_Consulta.Text;
                    fSQL.Cad_Consulta.ID_Consulta = System.Guid.NewGuid().ToString();
                    fSQL.Cad_Consulta.Login = Utils.Parametros.pubLogin;

                    //ADD AO BIND
                    lConsulta.Add(fSQL.Cad_Consulta);
                    (BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Add(fSQL.Cad_Consulta);
                    BS_Relatorio.ResetBindings(true);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
            }
        }

        private void tsBB_EditarConsulta_Click(object sender, EventArgs e)
        {
            TRegistro_Cad_Consulta Reg_Consulta = null;

            if (treeConsulta.Focused && treeConsulta.SelectedNode != null)
                Reg_Consulta = BuscaConsulta(treeConsulta.SelectedNode.Name);
            else if (treeConsultaBusca.Focused && treeConsultaBusca.SelectedNode != null)
                Reg_Consulta = BuscaConsulta(treeConsultaBusca.SelectedNode.Name);

            if (Reg_Consulta != null)
            {
                try
                {
                    TFCad_SQL fSQL = new TFCad_SQL(Reg_Consulta, true);
                    fSQL.Homologacao = true;
                    fSQL.pNMConsulta.Visible = true;
                    fSQL.NM_Consulta.Text = Reg_Consulta.DS_Consulta;
                    fSQL.ShowDialog();

                    if (fSQL.Cad_Consulta.DS_SQL != "")
                    {
                        //ADD OS DADOS QUE FALTA
                        Reg_Consulta.DS_Consulta = fSQL.NM_Consulta.Text;
                        Reg_Consulta.DS_SQL = fSQL.DS_SQL.Text;

                        //ADD AO BIND
                        if (lConsulta.Exists(p => p.ID_Consulta == Reg_Consulta.ID_Consulta))
                        {
                            lConsulta.Remove(Reg_Consulta);
                            lConsulta.Add(Reg_Consulta);

                            TCN_Cad_Consulta.GravaConsulta(Reg_Consulta, null);
                        }
                        else
                        {
                            (BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Remove(Reg_Consulta);
                            (BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Add(Reg_Consulta);
                            BS_Relatorio.ResetBindings(true);
                        }

                        AtualizaTreeConsulta();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
                }
            }
        }

        private void BB_Add_Click(object sender, EventArgs e)
        {
            if (treeConsultaBusca.SelectedNode != null)
            {
                try
                {
                    TreeNode no = treeConsultaBusca.SelectedNode;

                    if (((BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Exists(p => p.ID_Consulta == no.Name.Trim())))
                        throw new Exception("Já existe esta consulta adicionado no relatório!");
                    else
                    {
                        TRegistro_Cad_Consulta RegConsulta = BuscaConsulta(no.Name.Trim());
                        TreeNode noMenu = new TreeNode(RegConsulta.DS_Consulta.Trim());
                        noMenu.Name = RegConsulta.ID_Consulta.ToString().Trim();
                        noMenu.ImageIndex = 0;

                        treeConsulta.Nodes.AddRange(new TreeNode[] { noMenu });

                        (BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Add(RegConsulta);
                        BS_Relatorio.ResetBindings(true);

                        AtualizaTreeConsulta();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
                }
            }
        }

        private void BB_Remover_Click(object sender, EventArgs e)
        {
            if (treeConsulta.SelectedNode != null)
            {
                try
                {
                    TreeNode no = treeConsulta.SelectedNode;

                    if (!((BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Exists(p => p.ID_Consulta == no.Name.Trim())))
                        throw new Exception("Não existe esta consulta adicionado no relatório!");
                    else
                    {
                        TRegistro_Cad_Consulta RegConsulta = BuscaConsulta(no.Name.Trim());
                        TreeNode noMenu = new TreeNode(RegConsulta.DS_Consulta.Trim());
                        noMenu.Name = RegConsulta.ID_Consulta.ToString().Trim();
                        noMenu.ImageIndex = 0;

                        treeConsulta.Nodes.RemoveByKey(noMenu.Name);

                        (BS_Relatorio.Current as TRegistro_Cad_Report).lConsulta.Remove(RegConsulta);
                        BS_Relatorio.ResetBindings(true);

                        AtualizaTreeConsulta();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
                }
            }
        }

        private void treeConsultaBusca_DoubleClick(object sender, EventArgs e)
        {
            BB_Add_Click(this, new EventArgs());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCad_Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.R))
                bbEditReport_Click(this, new EventArgs());
            else if (bb_Menu.Visible && e.Control && e.KeyCode.Equals(Keys.M))
                bb_Menu_Click(this, new EventArgs());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}

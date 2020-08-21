using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Componentes;
using Utils;
using CamadaNegocio.ConfigGer;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace FormPadrao
{
    public partial class FFormPadrao : Form
    {
        private System.Collections.IEnumerable lista;
        public System.Collections.IEnumerable Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        private DataTable tb_relatorio;
        public DataTable Tb_relatorio
        {
            get { return tb_relatorio; }
            set { tb_relatorio = value; }
        }

        //
        //Atributos
        //
        public TabPage[] vPageOld = new TabPage[1];
        private bool vControlarPage;
        private string vCD_Modulo;
        private string vNM_Modulo;
        private string vDS_Menu;        
        public BindingSource DTS;
        public TTpModo vTP_Modo;
        public TpBusca[] vTP_Busca;

        //
        //Propriedades
        //
        public string CD_Modulo 
        { 
            get { return vCD_Modulo; } 
            set { vCD_Modulo = value; } 
        }
        public string NM_Modulo 
        { 
            get { return vNM_Modulo; } 
            set { vNM_Modulo = value; } 
        }
        public string DS_Menu 
        { 
            get { return vDS_Menu; } 
            set { vDS_Menu = value; } 
        }
        public bool ControlarPage
        {
            get { return vControlarPage; }
            set { vControlarPage = value; }
        }
        public bool St_janelaNormal
        { get; set; }

        public bool Altera_Relatorio = false;
        //
        //Metodos Privados
        //
        private void FFormPadrao_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 113) && (BB_Novo.Visible))
                this.afterNovo();
            else if ((e.KeyValue == 114) && (BB_Alterar.Visible))
                this.afterAltera();
            else if ((e.KeyValue == 115) && (BB_Gravar.Visible))
                this.afterGrava();
            else if ((e.KeyValue == 116) && (BB_Excluir.Visible))
                this.afterExclui();
            else if ((e.KeyValue == 117) && (BB_Cancelar.Visible))
                this.afterCancela();
            else if ((e.KeyValue == 118) && (BB_Buscar.Visible))
                this.afterBusca();
            else if ((e.KeyValue == 119) && (BB_Imprimir.Visible))
                this.afterPrint();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }
        
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }
        //
        //Metodos Publicos
        //
        public FFormPadrao()
        {
            InitializeComponent();
            vPageOld[0] = tcCentral.SelectedTab;
            vControlarPage = false;
        }

        public void modoBotoes(TTpModo vTP_Modo, bool vNovo, bool vAlterar, bool vGravar, bool vExcluir,
                                bool vCancelar, bool vBuscar, bool vImprimir)
        {
            if (vTP_Modo == TTpModo.tm_Standby)
            {
                BB_Novo.Checked     = false;
                BB_Alterar.Checked  = false;
                BB_Buscar.Checked   = false;
                BB_Cancelar.Checked = false;
                BB_Excluir.Checked  = false;
                BB_Fechar.Checked   = false;
                BB_Gravar.Checked   = false;
                BB_Imprimir.Checked = false;
            }
            else if (vTP_Modo == TTpModo.tm_Insert)
            {
                BB_Novo.Checked = true;
                BB_Alterar.Checked = false;
                BB_Buscar.Checked = false;
                BB_Cancelar.Checked = false;
                BB_Excluir.Checked = false;
                BB_Fechar.Checked = false;
                BB_Gravar.Checked = false;
                BB_Imprimir.Checked = false;
            }
            else if (vTP_Modo == TTpModo.tm_Edit)
            {
                BB_Novo.Checked = false;
                BB_Alterar.Checked = true;
                BB_Buscar.Checked = false;
                BB_Cancelar.Checked = false;
                BB_Excluir.Checked = false;
                BB_Fechar.Checked = false;
                BB_Gravar.Checked = false;
                BB_Imprimir.Checked = false;
            }
            else if (vTP_Modo == TTpModo.tm_busca)
            {
                BB_Novo.Checked = false;
                BB_Alterar.Checked = false;
                BB_Buscar.Checked = false;
                BB_Cancelar.Checked = false;
                BB_Excluir.Checked = false;
                BB_Fechar.Checked = false;
                BB_Gravar.Checked = false;
                BB_Imprimir.Checked = false;
            }
            BB_Novo.Visible = vNovo;
            BB_Alterar.Visible = vAlterar;
            BB_Buscar.Visible = vBuscar;
            BB_Cancelar.Visible = vCancelar;
            BB_Excluir.Visible = vExcluir;
            BB_Fechar.Visible = true;
            BB_Gravar.Visible = vGravar;
            BB_Imprimir.Visible = vImprimir;
        }
                
        public virtual string gravarRegistro()
        {
            return "";
        }

        public virtual void excluirRegistro()
        {
        }

        public virtual void habilitarControls(bool value)
        {
        }

        public virtual void limparControls()
        {
        }

        public virtual int buscarRegistros()
        {
            return -1;
        }

        public virtual void formatZero()
        {
        }

        public virtual void afterNovo()
        {
            this.vPageOld[0] = tcCentral.SelectedTab;
            this.vTP_Modo = TTpModo.tm_Insert;
            this.habilitarControls(true);
            this.limparControls();
            this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
        }

        public virtual void afterBusca()
        {
            this.vTP_Modo = TTpModo.tm_busca;
            this.habilitarControls(false);
            vTP_Busca = null;
            this.buscarRegistros();
            this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
        }

        public virtual void afterExclui()
        {
            this.vTP_Modo = TTpModo.tm_busca;
            this.excluirRegistro();
            this.limparControls();
            this.buscarRegistros();
            this.modoBotoes(this.vTP_Modo, true, true, false, true, true, true, true);
        }

        public virtual void afterGrava()
        {
            if (this.gravarRegistro() != "")
            {
                this.vTP_Modo = TTpModo.tm_busca;
                this.habilitarControls(false);
                this.buscarRegistros();
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
               
            }
            else
            {
                this.vTP_Modo = TTpModo.tm_Insert;
                this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
            }
        }

        public virtual void afterCancela()
        {
            this.vTP_Modo = TTpModo.tm_Standby;
            this.habilitarControls(false);
            this.limparControls();
            vTP_Busca = null;
            this.buscarRegistros();
            this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
        }

        public virtual void afterAltera()
        {
            if (this.buscarRegistros() > 0)
            {
                this.vPageOld[0] = tcCentral.SelectedTab;
                this.vTP_Modo = TTpModo.tm_Edit;
                this.habilitarControls(true);
                this.modoBotoes(this.vTP_Modo, false, false, true, false, true, false, false);
            }
        }
        
        public virtual void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = DTS;
                Rel.Nome_Relatorio = this.Name;
                Rel.NM_Classe = this.Name;
                Rel.Modulo = (this.Tag == null ? string.Empty : this.Tag.ToString().Substring(0,3));
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "RELATORIO " + this.Text.Trim(),
                                                fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           null,
                                           fImp.pDestinatarios,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
            }
        }

        public virtual void DetalhesAcesso()
        {
            
        }

        private void FFormPadrao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.formatZero();
            if (this.St_janelaNormal)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
           // this.DetalhesAcesso();

            //ATUALIZAçÃO DE RELATÓRIOS
            /*if (this.Tag != null && this.Name != null)
            {
                CamadaDados.Consulta.Cadastro.TList_Cad_Report lista = CamadaNegocio.Consulta.Cadastro.TCN_Cad_Report.Buscar(0, "", this.Tag.ToString().Substring(0, 3), this.Name, "", 0, false, false, false);

                if (lista.Count > 0)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        new FormRelPadrao.AtualizarRDC(false).VerificarVersaoRDC(lista[i], false);
                    }
                }
            }*/
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tb_relatorio = null;
            if ((vControlarPage) && ((this.vTP_Modo.Equals(TTpModo.tm_Insert)) || (this.vTP_Modo.Equals(TTpModo.tm_Edit))) && (!(tcCentral.SelectedTab.Equals(vPageOld[0]))))
                tcCentral.SelectedTab = vPageOld[0];
            else
                vPageOld[0] = tcCentral.SelectedTab;
        }
    }
}
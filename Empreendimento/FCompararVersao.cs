using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;


namespace Empreendimento
{
    public partial class FCompararVersao : Form
    {
        bool retorno = false;
        public decimal total_comi { get; set; } = decimal.Zero;
        TList_CadCFGEmpreendimento lcfg = new TList_CadCFGEmpreendimento();
        public FCompararVersao()
        {
            InitializeComponent();
        }
        private TRegistro_Orcamento cOrc { get; set; } = new TRegistro_Orcamento();
        public TRegistro_Orcamento rOrc
        {
            get
            {
                return cOrc;
            }
            set
            {
                cOrc = value;
            }
        }
        public string vId_Orcamento { get; set; } = string.Empty;
        public string vCd_Empresa { get; set; } = string.Empty;

        private void afterbusca()
        {
            bsOrcamento.DataSource = TCN_Orcamento.Buscar(vCd_Empresa, vId_Orcamento, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();
        }

        private void FCompararVersao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (cOrc != null)
            {
                bsOrcamento.Add(cOrc);
            }
            lcfg = TCN_CadCFGEmpreendimento.Busca(vCd_Empresa, string.Empty, null);
            afterbusca();

        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar(vCd_Empresa, vId_Orcamento, (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, string.Empty, string.Empty, null);
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas =
                    TCN_Despesas.Buscar(vCd_Empresa, vId_Orcamento, (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, string.Empty, string.Empty, null);
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra =
                    TCN_CadMaoObra.Busca(vId_Orcamento, (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, vCd_Empresa, string.Empty, null);
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                    TCN_OrcamentoEncargo.Buscar(string.Empty, vCd_Empresa, (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,vId_Orcamento, null);
                bsOrcamento.ResetCurrentItem();
                bsAtividade.ResetCurrentItem();
                bsAtividade_PositionChanged(this, new EventArgs());
                bsAtividade.ResetCurrentItem();
                edit_tot_orcamento_cont.Value = decimal.Add(edit_custo_orcamento.Value, decimal.Multiply(edit_custo_orcamento.Value, decimal.Divide((bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont, 100)));
                tot_comissao.Value = decimal.Multiply((bsOrcamento.Current as TRegistro_Orcamento).total_orcamento ,decimal.Divide((bsOrcamento.Current as TRegistro_Orcamento).Pc_comissao,100));
                total_comi = tot_comissao.Value;
            }
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {

            if (bsAtividade.Current != null)
            {
                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha =
                    TCN_FichaTec.Buscar(vCd_Empresa, vId_Orcamento, (bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr, (bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr, (bsAtividade.Current as TRegistro_OrcProjeto).Id_registrostr, string.Empty, null);
                bsAtividade.ResetCurrentItem();
                bsFicha.ResetCurrentItem();
            }
        }

        private void FCompararVersao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F6))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            if (e.KeyCode.Equals(Keys.F9))
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.DataSource as TList_Orcamento).ForEach(p =>
                {
                    if (p.st_aprovar)
                    {
                        cOrc = (bsOrcamento.Current as TRegistro_Orcamento);
                        retorno = true;
                    }
                });

                if (retorno)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Selecione um orçamento!", "Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);

            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.ColumnIndex == 0 && (bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                (bsOrcamento.List as TList_Orcamento).ForEach(p => p.st_aprovar = false ); 
                (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar = !(bsOrcamento.Current as TRegistro_Orcamento).st_aprovar;
                bsOrcamento.ResetBindings(true); 
            }
        }

        private void bsOrcamento_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dejesa reprovar todas as versões?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Abort;
        }
    }
}

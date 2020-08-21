using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class TFConsultaEmpreendimento : Form
    {
        public TFConsultaEmpreendimento()
        {
            InitializeComponent();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {

            string vColunas = "a.id_orcamento|Cd. Orcamento|80;" + "a.ds_empreendimento|Ds. Orcamento|200";
            string vParam = "isnull(a.ST_REGISTRO, 'A')|=|'E'";
                
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_orcamento }, new CamadaDados.Empreendimento.TCD_Orcamento(), vParam);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.id_orcamento|=|'" + id_orcamento.Text.Trim() + "'",
                new Componentes.EditDefault[] { id_orcamento }, new CamadaDados.Empreendimento.TCD_Orcamento());
        }

        private void afterbusca()
        {
            bsOrcProjeto.DataSource = CamadaNegocio.Empreendimento.TCN_OrcProjeto.Buscar(cd_empresa.Text, id_orcamento.Text, string.Empty, string.Empty, string.Empty,"S", null);
            bsOrcProjeto.ResetCurrentItem();
            bsOrcProjeto_PositionChanged(this, new EventArgs());
            bsOrcamento.DataSource = CamadaNegocio.Empreendimento.TCN_Orcamento.Buscar(cd_empresa.Text, id_orcamento.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "E", null);
            bsOrcamento.ResetCurrentItem();
            
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bsOrcProjeto_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcProjeto.Current != null)
                bsFicha.DataSource = CamadaNegocio.Empreendimento.TCN_FichaTec.Buscar((bsOrcProjeto.Current as CamadaDados.Empreendimento.TRegistro_OrcProjeto).Cd_empresa,
                                                                                  (bsOrcProjeto.Current as CamadaDados.Empreendimento.TRegistro_OrcProjeto).Id_orcamentostr,
                                                                                   string.Empty,
                                                                                   (bsOrcProjeto.Current as CamadaDados.Empreendimento.TRegistro_OrcProjeto).Id_projetostr,
                                                                                   (bsOrcProjeto.Current as CamadaDados.Empreendimento.TRegistro_OrcProjeto).Id_registrostr,
                                                                                   string.Empty,
                                                                                   null);
            bsFicha.ResetCurrentItem();
            calculatotais();

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculatotais()
        {
            decimal servico = decimal.Zero;
            decimal material = decimal.Zero;
            //(bsFicha.DataSource as CamadaDados.Empreendimento.TList_FichaTec).ForEach(p => servico += p.vl_servico_pc);
            //(bsFicha.DataSource as CamadaDados.Empreendimento.TList_FichaTec).ForEach(p => material += p.vl_material_pc);
            tot_servico.Value = servico;
            tot_material.Value = material;

        }

        private void TFConsultaEmpreendimento_Load(object sender, EventArgs e)
        {

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Empreendimento
{
    public partial class TFRequisitarCompra : Form
    {
        public TFRequisitarCompra()
        {
            InitializeComponent();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            bsOrcamento.DataSource = CamadaNegocio.Empreendimento.TCN_Orcamento.Buscar(cd_empresa.Text,
                                                                                       id_orcamento.Text,
                                                                                       nr_versao.Text,
                                                                                       cd_clifor.Text,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "E",
                                                                                       null);
            bsOrcamento.ResetBindings(true);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);

        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });

        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);

        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
                return;

            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.id_orcamento", (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Id_orcamentostr);
            Estruturas.CriarParametro(ref tps, "a.cd_empresa", (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Cd_empresa);
            Estruturas.CriarParametro(ref tps, "a.nr_versao", (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Nr_versaostr);

            //Buscar produtos que não possuem requisição em aberto
            Estruturas.CriarParametro(ref tps, "", "(select 1 " +
                                                   "from TB_EMP_CompraEmpreendimento xxz " +
                                                   "where a.id_orcamento = xxz.id_orcamento " +
                                                   "and a.nr_versao = xxz.nr_versao " +
                                                   "and a.ID_Atividade = xxz.ID_Atividade " +
                                                   "and a.ID_Ficha = xxz.ID_Ficha " +
                                                   "and a.ID_Registro = xxz.ID_Registro " +
                                                   "and a.cd_empresa = xxz.cd_empresa) ", "not exists");
            
            bsFicha.DataSource = new CamadaDados.Empreendimento.TCD_FichaTec().Select(tps, 0, string.Empty);
        }

        private void bbOtimizar_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
                return;
            else if (bsFicha.Current == null)
                return;

            CamadaDados.Empreendimento.TList_FichaTec lficha2 = new CamadaDados.Empreendimento.TList_FichaTec();
            lficha2.Add(bsFicha.Current as CamadaDados.Empreendimento.TRegistro_FichaTec);

            try
            {
                CamadaNegocio.Empreendimento.TCN_Orcamento.GravarOrcReq((bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento), lficha2, null);
                MessageBox.Show("Gerado requisição de compra para o item selecionado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsFicha.RemoveCurrent();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}

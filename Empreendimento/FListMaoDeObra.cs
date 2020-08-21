using System;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class FListMaoDeObra : Form
    {

        private CamadaDados.Empreendimento.TRegistro_Orcamento cOrc { get; set; }
        public CamadaDados.Empreendimento.TRegistro_Orcamento rOrc { get
            {
                return bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento;
            }
        set
            {
                cOrc = value;
            }
        }
        public FListMaoDeObra()
        {
            InitializeComponent();
        }

        private void FListMaoDeObra_Load(object sender, EventArgs e)
        {
            if (cOrc != null)
            {
                bsOrcamento.Add(cOrc);
                bsOrcamento_PositionChanged(this, new EventArgs());
            }
        }

        private void dataGridDefault1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (FExecMaoDeObra exe = new FExecMaoDeObra())
            {
                exe.rMao = (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra);
                if (exe.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Empreendimento.Cadastro.TCN_ExecCadMaoObra.Gravar(exe.rexecMao, null);

                    bsOrcamento_PositionChanged(this, new EventArgs());

                }
            }
        }
        
        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            { 

                Utils.TpBusca[] vBusca = new Utils.TpBusca[0];


                if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Cd_empresa))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Cd_empresa.Trim() + "'";
                }
                if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Id_orcamentostr))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.id_orcamento";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Id_orcamentostr.Trim() + "'";
                }
                if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Nr_versaostr))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_versao";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).Nr_versaostr.Trim() + "'";
                }

                (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).lMaoObra = new CamadaDados.Empreendimento.Cadastro.TCD_CadMaoObra().Select(vBusca, 0, string.Empty);
                (bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento).lMaoObra.ForEach(p =>
                {
                    p.qtd_adNoturno = decimal.Multiply(p.qtd_pessoas, p.qtd_adNoturno);
                    p.Qtd_horas150 = decimal.Multiply(p.qtd_pessoas, p.Qtd_horas150);
                    p.qtd_horascen = decimal.Multiply(p.qtd_pessoas, p.qtd_horascen);
                    p.qtd_horascinco = decimal.Multiply(p.qtd_pessoas, p.qtd_horascinco);
                    p.Quantidade = decimal.Multiply(p.qtd_pessoas, p.Quantidade);
                });


                bsOrcamento.ResetCurrentItem();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FListMaoDeObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void dataGridDefault1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

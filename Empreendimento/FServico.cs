using System;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using Utils;

namespace Empreendimento
{
    public partial class FServico : Form
    {
        public decimal vVl_Execucao { get; set; } = decimal.Zero;
        decimal total_calculado = decimal.Zero;
        private CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF cLImposto = new CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF();
        private TRegistro_Orcamento cOrc = new TRegistro_Orcamento();
        public TRegistro_Orcamento rOrc
        {
            get
            {
                return bsOrcamento.Current as TRegistro_Orcamento;
            }
            set
            {
                cOrc = value;
            }
        }
        public decimal vSaldo_faturar { get; set; } = decimal.Zero;
        public decimal vSaldo_faturado { get; set; } = decimal.Zero;
        public decimal vValorOrc { get; set; } = decimal.Zero;
        public decimal vValor_Nota { get; set; } = decimal.Zero;
        public string vCd_cidade { get; set; } = string.Empty;
        private TRegistro_FichaTec cFicha = new TRegistro_FichaTec();
        public TRegistro_FichaTec rFicha
        {
            get
            {
                return bsFichaTec.Current as TRegistro_FichaTec;
            }
            set
            {
                cFicha = value;
            }
        }


        public FServico()
        {
            InitializeComponent();
        }

        private void FServico_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();
            if (cFicha != null)
            {
                bsFichaTec.Add(cFicha);
            }
            if (cOrc != null)
                bsOrcamento.Add(cOrc);
            cd_cidade.Text = vCd_cidade;
            calculavalor();


            if (vValorOrc > decimal.Zero)
                tot_orc.Value = vValorOrc;

            Saldo_Faturar_i.Value = total_calculado - vSaldo_faturado;
            total_orc_i.Value = total_calculado;

            if (vSaldo_faturar > decimal.Zero)
            {
                decimal b = decimal.Multiply(vSaldo_faturado, 100);
                if (b != decimal.Zero)
                {
                    decimal a = decimal.Divide(total_calculado, b);
                    saldo_faturar.Value = decimal.Subtract(vValorOrc, decimal.Multiply(vValorOrc, a));
                }
                else
                    saldo_faturar.Value = vValorOrc;
            }
        }
        private void calculavalor()
        {
            decimal valor_reducao = decimal.Zero;
            rFicha.lImpostos.ForEach(p =>
            {
                p.Vl_basecalc = vSaldo_faturar;
                CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.CalcValorImposto(p, p.Vl_basecalc, false);
                valor_reducao += p.Vl_impostoretido;
            });
            total_calculado = vValorOrc - valor_reducao;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                if (MessageBox.Show("Deseja confirmar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    vValor_Nota = valor_nota.Value;
                    vVl_Execucao = valor_execucao.Value;
                    vCd_cidade = cd_cidade.Text;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void valor_nota_ValueChanged(object sender, EventArgs e)
        {
            if (valor_nota.Value > saldo_faturar.Value)
            {
                valor_nota.Value = saldo_faturar.Value;
            }

            vl_execucao_pc.Value = decimal.Divide(decimal.Multiply(valor_nota.Value, 100), tot_orc.Value);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar o orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes) this.DialogResult = DialogResult.Cancel;
        }

        private void FServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                toolStripButton1_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }
        
        private void vl_execucao_pc_ValueChanged(object sender, EventArgs e)
        {
            valor_execucao.Value = decimal.Divide(decimal.Multiply(total_calculado, vl_execucao_pc.Value), 100);
        }

        private void valor_execucao_ValueChanged(object sender, EventArgs e)
        {
            if (valor_execucao.Value > Saldo_Faturar_i.Value)
            {
                valor_execucao.Value = Saldo_Faturar_i.Value;
            }

            vl_execucao_pc.Value = decimal.Divide(decimal.Multiply(valor_execucao.Value, 100), total_calculado);
            valor_nota.Value = decimal.Divide(decimal.Multiply(tot_orc.Value, vl_execucao_pc.Value), 100);
        }

        private void bbCidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|50;" +
                              "b.uf|UF|20";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidade, dsCidade },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_cidade_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_cidade|=|'" + cd_cidade.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cidade, dsCidade }, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }
    }
}

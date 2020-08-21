using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Bloqueto;
using Utils;
using FormRelPadrao;

namespace Financeiro
{
    public partial class TFCobrancaEmail : Form
    {
        public TRegistro_CadCFGBanco rCfgBoleto { get; set; }

        public TFCobrancaEmail()
        {
            InitializeComponent();
        }

        private void bb_enviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ds_assunto.Text.Trim()) || string.IsNullOrEmpty(ds_corpo.Text.Trim()))
            {
                MessageBox.Show("Obrigatório informar assunto e corpo para enviar e-mail.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bsBloqueto.List as blListaTitulo).Where(p => p.St_processar).ToList().Count.Equals(0))
            {
                MessageBox.Show("Obrigatório selecionar algum bloqueto pela opção de enviar para finalizar o processo.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            (bsBloqueto.List as blListaTitulo).Where(p => p.St_processar).ToList().ForEach(r => 
            {
                if (cbxAnexarBloqueto.Checked)
                {
                    reprocessarBloqueto(r);
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.Nr_Lancto", "'" + r.Nr_lancto + "'");
                    Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", "'" + r.Cd_empresa + "'");
                    Estruturas.CriarParametro(ref tpBuscas, "a.cd_parcela", "'" + r.Cd_parcela + "'");
                    blTitulo p = new TCD_Titulo().Select(tpBuscas, 1, string.Empty)[0];
                    TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                        new List<blTitulo>() { p },
                                                        false,
                                                        false,
                                                        true,
                                                        false,
                                                        string.Empty,
                                                        new List<string>() { r.Email },
                                                        ds_assunto.Text.Trim(),
                                                        ds_corpo.Text.Trim(),
                                                        false);
                }
                else
                {
                    new Email(new List<string>() { r.Email }, ds_assunto.Text.Trim(), ds_corpo.Text.Trim(), new List<string>()).EnviarEmail();
                }
            });

            MessageBox.Show("Processo finalizado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            (bsBloqueto.List as blListaTitulo).RemoveAll(r => r.St_processar);
            bsBloqueto.ResetBindings(true);
        }

        private void reprocessarBloqueto(blTitulo r)
        {
            //Gerar atualização do bloqueto
            //Calcular Multa
            if (r.Pc_multa > decimal.Zero)
                if (r.Dt_vencimento.Value.AddDays(Convert.ToDouble(r.Nr_diasmulta)).Date < CamadaDados.UtilData.Data_Servidor().Date)
                    r.Vl_multacalc = Math.Round(r.Tp_multa.Trim().ToUpper().Equals("P") ? ((r.Vl_documento * r.Pc_multa) / 100) : r.Pc_multa, 2);
            //Calcular Juro
            if ((r.Pc_jurodia > decimal.Zero) && (r.Dt_vencimento.Value.Date < CamadaDados.UtilData.Data_Servidor().Date))
                r.Vl_jurocalc += Math.Round((r.Tp_jurodia.Trim().ToUpper().Equals("P") ? ((r.Vl_documento * r.Pc_jurodia) / 100) : r.Pc_jurodia), 2) *
                                        CamadaDados.UtilData.Data_Servidor().Subtract(r.Dt_vencimento.Value).Days;
            TCN_Titulo.AtualizarBoleto(r, CamadaDados.UtilData.Data_Servidor(), null);
        }

        private bool validarExisteEmail()
        {
            bool retu = false;
            TpBusca[] tpBusca = new TpBusca[0];
            Estruturas.CriarParametro(ref tpBusca, "a.CD_Clifor", "'" + (bsBloqueto.Current as blTitulo).Cd_sacado + "'");
            object obj = new TCD_CadContatoCliFor().BuscarEscalar(tpBusca, "email");

            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                (bsBloqueto.Current as blTitulo).Email = obj.ToString();
                return true;
            }
            else
                MessageBox.Show("Cliente do bloqueto selecionado não possui e-mail pré-cadastrado, não será possível finalizar operação.",
                                "Informativo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            return retu;
        }

        private void TFCobrancaEmail_Load(object sender, EventArgs e)
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            Estruturas.CriarParametro(ref tpBuscas, "a.id_config", "'" + rCfgBoleto.Id_config + "'");
            Estruturas.CriarParametro(ref tpBuscas, "b.st_registro", "('A', 'P')", "in");
            Estruturas.CriarParametro(ref tpBuscas, "cast(b.dt_vencto as date)", "cast(dateadd(day, -1, GETDATE())as date)");

            bsBloqueto.DataSource = new TCD_Titulo().Select(tpBuscas, 0, string.Empty);
            bsBloqueto.ResetBindings(true);
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.ColumnIndex.Equals(0) || bsBloqueto.Current == null)
                return;

            (bsBloqueto.Current as blTitulo).St_processar = !(bsBloqueto.Current as blTitulo).St_processar;
            if ((bsBloqueto.Current as blTitulo).St_processar)
                if (!validarExisteEmail())
                    (bsBloqueto.Current as blTitulo).St_processar = false;
        }
    }
}

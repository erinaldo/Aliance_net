using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using Utils;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Diversos;



namespace Financeiro
{
    public partial class TFLan_FechamentoCaixa : Form
    {
        private bool Altera_Relatorio = false;
        public string pCd_contager
        { get; set; }

        public TFLan_FechamentoCaixa()
        {
            InitializeComponent();
        }
        
        private void Print()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                BindingSource bin = new BindingSource();
                bin.Add((bsListaFechamentos.Current as TRegistro_LanFechamentoCaixa));
                Rel.DTS_Relatorio = bin;
                Rel.Nome_Relatorio = "TFLan_FechamentoCaixa";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = string.Empty;
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
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
            }
        }

        private void afterGrava()
        {
            if (dt_fechamento.Focused)
                dt_fechamento_Leave(this, new EventArgs());
            if (bsFechamentoCaixa.Current != null)
            {
                try
                {
                    TCN_LanFechamentoCaixa.GravarFechamentoCaixa((bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa), null).Trim();
                    MessageBox.Show("Fechamento  de caixa concluido com êxito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if (bsListaFechamentos.Current != null)
            {
                if (MessageBox.Show("Confirma estorno do fechamento de caixa do dia " +
                                    (bsListaFechamentos.Current as TRegistro_LanFechamentoCaixa).Dt_fechamentostring+"?\r\n"+
                                    "Se existir fechamento de caixa com data posterior a data do fechamento a ser estornado,\r\n"+
                                    "os mesmos tambem serão estornados.",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    TCN_LanFechamentoCaixa.DeletarFechamentoCaixa(bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa, null);
                    MessageBox.Show("Operação concluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
            }
        }

        public void afterBusca()
        {
            //Buscar fechamentos de caixa da conta gerencial
            bsListaFechamentos.DataSource = TCN_LanFechamentoCaixa.Buscar(decimal.Zero, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          pCd_contager.Trim(), 
                                                                          0, 
                                                                          string.Empty, 
                                                                          "b.dt_fechamento desc",
                                                                          null);
        }

        private void TFLan_FechamentoCaixa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            bsFechamentoCaixa.AddNew();
            if (bsFechamentoCaixa.Current != null)
            {
                (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Cd_contager = pCd_contager;
                //Buscar Descricao Conta
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_contager",
                                        vOperador = "=",
                                        vVL_Busca = "'" + pCd_contager.Trim() + "'"
                                    }
                                }, "a.ds_contager");
                (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Ds_contager = obj != null ? obj.ToString() : string.Empty;
                (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Dt_fechamento = DateTime.Now;
                //Buscar dados do ultimo fechamento caixa da conta gerencial
                TList_LanFechamentoCaixa lFechamentoCaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanFechamentoCaixa.Buscar(decimal.Zero, 
                                                                                                                         string.Empty, 
                                                                                                                         string.Empty, 
                                                                                                                         string.Empty, 
                                                                                                                         pCd_contager.Trim(), 
                                                                                                                         1, 
                                                                                                                         string.Empty, 
                                                                                                                         "dt_fechamento desc",
                                                                                                                         null);
                if (lFechamentoCaixa.Count > 0)
                {
                    (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Dt_ultimofechamento = lFechamentoCaixa[0].Dt_fechamento;
                    (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_anterior = lFechamentoCaixa[0].Vl_atual;
                }
                bsFechamentoCaixa.ResetCurrentItem();
            }
            afterBusca();
        }

        private void dt_fechamento_Leave(object sender, EventArgs e)
        {
            if((dt_fechamento.Text.Trim().Equals(string.Empty))||(dt_fechamento.Text.Trim().Equals("/  /")))
                return;
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(dt_fechamento.Text);
                if (dt > DateTime.Now)
                {
                    MessageBox.Show("Data de fechamento não pode ser maior que data atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_fechamento.Focus();
                    return;
                }
                if ((bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Dt_ultimofechamento != null)
                    if (dt <= (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Dt_ultimofechamento.Value)
                    {
                        MessageBox.Show("Data de fechamento não pode ser menor ou igual a data do ultimo fechamento.\r\n" +
                                        "Data Ultimo Fechamento: " + (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Dt_ultimofechamento.Value.ToString("dd/MM/yyyy"),
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_fechamento.Focus();
                        return;
                    }
            }
            catch
            {
                MessageBox.Show("Data de fechamento invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Buscar valor atual da conta
            (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_atual = TCN_LanCaixa.BuscarSaldoCaixaData(CD_ContaGer.Text, dt_fechamento.Data, null);
            object obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.status_compensado, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'N'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_titulo",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                "inner join tb_fin_caixa y " +
                                                "on x.cd_contager = y.cd_contager " +
                                                "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_banco = a.cd_banco " +
                                                "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                "and y.cd_contager = '" + CD_ContaGer.Text.Trim() + "' " +
                                                "and isnull(y.st_estorno, 'N') <> 'S' " +
                                                "and CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), y.DT_Lancto))) <= '" + dt_fechamento.Data.ToString("yyyyMMdd") + "')"
                                }
                            }, "isnull(sum(a.vl_titulo), 0)");
            (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_ch_rec_compensar = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.status_compensado, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_titulo",
                            vOperador = "=",
                            vVL_Busca = "'R'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                        "inner join tb_fin_caixa y " +
                                        "on x.cd_contager = y.cd_contager " +
                                        "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                        "inner join tb_fin_contager z " +
                                        "on y.cd_contager = c.cd_contager_compensacao " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_banco = a.cd_banco " +
                                        "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                        "and z.cd_contager = '" + CD_ContaGer.Text.Trim() + "' " +
                                        "and isnull(y.st_estorno, 'N') <> 'S' " +
                                        "and CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), y.DT_Lancto))) <= '" + dt_fechamento.Data.ToString("yyyyMMdd") + "')"
                        }
                    }, "isnull(sum(a.vl_titulo), 0)");
            (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_ch_emit_compensar = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            //Verificar se a conta e de compensacao
            object obj_conta = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_contager",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_ContaGer.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, "1");
            (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_saldofuturo = 
                (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_atual -
                (obj_conta == null ? (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_ch_emit_compensar :
                (bsFechamentoCaixa.Current as TRegistro_LanFechamentoCaixa).Vl_ch_emit_compensar * -1);
            bsFechamentoCaixa.ResetCurrentItem();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if ((dt_fechamento.Text.Trim() != string.Empty) && (dt_fechamento.Text.Trim() != "/  /"))
                afterGrava();
            else
            {
                MessageBox.Show("Obrigatorio Informar Data de Vencimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_fechamento.Focus();
            }
        }

        private void TFLan_FechamentoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
            {
                bsFechamentoCaixa.CancelEdit();
                this.DialogResult = DialogResult.Cancel;
            }
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                Print();    
            }
        }
        
        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            if (bsListaFechamentos.Current != null)
                Print();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();    
        }

        private void TFLan_FechamentoCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}

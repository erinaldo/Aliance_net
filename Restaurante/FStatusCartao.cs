using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaNegocio.Restaurante;
using Utils;

namespace Restaurante
{
    public partial class TFStatusCartao : Form
    {

        private static TList_CFG lcfg { get; set; } = new TList_CFG();

        public TFStatusCartao()
        {
            InitializeComponent();
        }

        private void atualizaListagemCartao()
        {
            TpBusca[] filtro = new TpBusca[0];
            Estruturas.CriarParametro(ref filtro, "a.cd_empresa", lcfg[0].cd_empresa);
            Estruturas.CriarParametro(ref filtro, "a.nr_cartao", nr_cartao.Text);
            if (!string.IsNullOrEmpty(DT_Inicial.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30, 10), a.dt_abertura)))", "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'", "<=");
            Estruturas.CriarParametro(ref filtro, "isnull (a.st_registro, 'C')", cbAberto.Checked ? "'A'" : "'F'");
            Estruturas.CriarParametro(ref filtro, " ", "exists (select * from tb_res_prevenda p where a.id_cartao = p.id_cartao and p.ST_Registro = 'A' and p.ST_Delivery is null)", " ");
            if (!string.IsNullOrEmpty(Nm_clifor.Text.Trim()))
                Estruturas.CriarParametro(ref filtro, "a.nm_clifor", "'%" + Nm_clifor.Text.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(Nr_telefone.Text.Trim().SoNumero()))
                Estruturas.CriarParametro(ref filtro, "dbo.FVALIDA_NUMEROS(d.Celular)", "'%" + Nr_telefone.Text.Trim().SoNumero() + "%'", "like");

            bsCartoesAbertos.DataSource = new TCD_Cartao().Select(filtro, 0, "", "");

            if (bsCartoesAbertos.Count.Equals(0)) { MessageBox.Show("Nenhum registro encontrado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            afterValidacao();
        }

        private void validaCartao()
        {
            if (string.IsNullOrEmpty(nr_cartao.Text.ToString().Trim())) { nr_cartao.Clear(); nr_cartao.Focus(); return; }
            if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotini > Convert.ToDecimal(nr_cartao.Text.ToString().Trim()))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(nr_cartao.Text.ToString().Trim()))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotini > Convert.ToDecimal(nr_cartao.Text.ToString().Trim()))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(nr_cartao.Text.ToString().Trim()))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (!lcfg[0].Tp_cartao.Equals("0"))
            {
                //verifica se existe cartao cadastrado
                object cartao_nm = new TCD_Cartao().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = nr_cartao.Text.ToString().Trim()
                        }
                    }, "a.nr_cartao");
                if (cartao_nm == null)
                {
                    MessageBox.Show("Não existe cartão N° " + nr_cartao.Text.ToString().Trim() + " cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    nr_cartao.Text = string.Empty;
                }
            }
            DataTable lCartaoAberto = new TCD_Cartao().Buscar(
                new TpBusca[]
                {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = "'" + nr_cartao.Text.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                }, 1);
            if (lCartaoAberto.Rows.Count > 0)
            {
                MessageBox.Show("O cartão N° " + nr_cartao.Text.ToString().Trim() + " está ABERTO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("O cartão N° " + nr_cartao.Text.ToString().Trim() + " está LIBERADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            afterValidacao();
        }

        private void afterValidacao()
        {
            nr_cartao.Clear();
            nr_cartao.Focus();
        }

        private void fecharCartao()
        {
            if (bsCartoesAbertos.Current != null)
            {
                //Buscar movimentação boliche em aberto
                // Lembrando que movimentação boliche em aberto não gera item na prevenda
                DataTable rMov = new TCD_MovBoliche().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsCartoesAbertos.Current as TRegistro_Cartao).id_cartao + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Fechamento",
                                vOperador = "",
                                vVL_Busca = "is null"
                            }
                    }, 1);
                if (rMov.Rows.Count > 0)
                {
                    MessageBox.Show("Cartão possui movimentação de serviços em aberto, favor dirigir-se ao caixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                };
                if ((bsCartoesAbertos.Current as TRegistro_Cartao).valor_cartao.Equals(0) &&
                        (bsCartoesAbertos.Current as TRegistro_Cartao).St_registro.Equals("A"))
                {
                    if (MessageBox.Show("Confirma o fechamento do cartão?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    (bsCartoesAbertos.Current as TRegistro_Cartao).St_registro = "F";
                    TCN_Cartao.Gravar((bsCartoesAbertos.Current as TRegistro_Cartao), null);
                    atualizaListagemCartao();
                }
                else
                {
                    if ((bsCartoesAbertos.Current as TRegistro_Cartao).St_registro.Equals("F"))
                    {
                        MessageBox.Show("Cartão consta com status fechado, não possui pendência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Cartão possui saldo em aberto, favor dirigir-se ao caixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    afterValidacao();
                }
            }
        }

        private void nr_cartao_Leave(object sender, EventArgs e)
        {
            validaCartao();
        }

        private void TFStatusCartao_Load(object sender, EventArgs e)
        {
            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Não existe configuração de restaurante.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            DT_Inicial.Text = CamadaDados.UtilData.Data_Servidor().ToString();
            pFiltros.set_FormatZero();
            afterValidacao();
        }

        private void bb_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            atualizaListagemCartao();
        }

        private void nr_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!string.IsNullOrEmpty(nr_cartao.Text))
                    atualizaListagemCartao();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            fecharCartao();
        }

        private void bsCartoesAbertos_PositionChanged(object sender, EventArgs e)
        {
            if (bsCartoesAbertos.Current == null || string.IsNullOrEmpty((bsCartoesAbertos.Current as TRegistro_Cartao).id_cartao.ToString())) return;

            //Buscar prevenda
            TpBusca[] tpBuscas = new TpBusca[0];
            Estruturas.CriarParametro(ref tpBuscas, "a.id_prevenda", (bsCartoesAbertos.Current as TRegistro_Cartao).id_cartao.ToString());
            object id_prevenda = new TCD_PreVenda().BuscarEscalar(tpBuscas, "a.id_prevenda");

            //Buscar itens prevenda
            if (id_prevenda != null && !string.IsNullOrEmpty(id_prevenda.ToString()))
                BsItensPrevenda.DataSource = TCN_PreVenda_Item.Buscar((bsCartoesAbertos.Current as TRegistro_Cartao).Cd_empresa, id_prevenda.ToString(), string.Empty, string.Empty, null);
        }

        private void nr_cartao_TextChanged(object sender, EventArgs e)
        {
            nr_cartao.Text = nr_cartao.Text.Trim().SoNumero();
        }
    }
}


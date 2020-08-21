using CamadaDados.Faturamento.Entrega;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFDevCarga : Form
    {
        public string pCd_empresa
        { get; set; } = string.Empty;
        private TList_ItensCargaAvulsa litens;
        public TList_ItensCargaAvulsa lItens
        {
            get
            {
                if (bsItensCarga.Count > 0)
                    return bsItensCarga.DataSource as TList_ItensCargaAvulsa;
                else return null;
            }
            set { litens = value; }
        }
        public TFDevCarga()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsItensCarga.Count == 0)
            {
                MessageBox.Show("Obrigatório inserir itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BuscarProduto()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[3];
            //Retirar Patrimônios
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "not exists";
            filtro[0].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                  "where a.cd_produto = x.cd_patrimonio " +
                                  "and x.cd_empresa = '" + pCd_empresa + "') ";
            //Retirar Serviço
            filtro[1].vNM_Campo = "isnull(e.st_servico, 'N')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'S'";
            //Retirar Consumo Interno
            filtro[2].vNM_Campo = "isnull(e.st_consumointerno, 'N')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'S'";

            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text.Trim()))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             pCd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             filtro);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             pCd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             filtro);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca =  "(select 1 from TB_EST_Patrimonio x " +
                                             "where a.cd_produto = x.cd_patrimonio " +
                                             "and x.cd_empresa = '" + pCd_empresa.Trim() + "') "
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_servico, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_consumointerno, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                try
                {
                    DataGridViewRow linha = gItensCarga.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pCd_produto"].Value.ToString().Contains(rProd.CD_Produto)).First();
                    if (linha != null)
                    {
                        gItensCarga.Rows[linha.Index].Selected = true;
                        bsItensCarga.Position = linha.Index;
                    }
                    else
                    {
                        MessageBox.Show("Item não encontrado nos Itens presentes na carga!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Item não encontrado nos Itens presentes na carga!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Qtd_devolvida = 1;
            }
            cd_produto.Clear();
            Quantidade.Value = 1;
            Quantidade.Focus();
            bsItensCarga.ResetCurrentItem();
        }

        private void AlterarQTD()
        {
            if (bsItensCarga.Current != null)
            {
                (bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Qtd_devolvida = Quantidade.Value;
                if ((bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Quantidade <
                     (bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Qtd_devolvida)
                {
                    MessageBox.Show("QTD.Devolvida não pode ser maior que Quantidade do Item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Qtd_devolvida = decimal.Zero;
                    bsItensCarga.ResetCurrentItem();
                    Quantidade.Focus();
                    return;
                }
                bsItensCarga.ResetCurrentItem();
                cd_produto.Focus();
            }
        }

        private void TFDevCarga_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bsItensCarga.DataSource = litens;
            cd_produto.Focus();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()))
                BuscarProduto();
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                AlterarQTD();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            AlterarQTD();
        }

        private void TFDevCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                if (bsItensCarga.Current != null)
                    Quantidade.Value = (bsItensCarga.Current as TRegistro_ItensCargaAvulsa).Qtd_devolvida;
                Quantidade.Focus();
            }
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Existem dados não salvos\r\n" +
                                "Confirma o fechamento da tela?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                DialogResult = DialogResult.Cancel;
        }
    }
}

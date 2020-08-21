using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;

namespace Restaurante
{
    public partial class TFAdicionais : Form
    {
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lcfg
        { get; set; }
        private TList_CFG lCfg = new TList_CFG();
        public string vCd_Produto { get; set; } = string.Empty;
        private TList_Adicionais lassistente;
        public TList_Adicionais lAssistente { get; set; } = new TList_Adicionais();


        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsAssistente.Count > 0)
            {
                (bsAssistente.List as TList_Adicionais).ForEach(p =>
                {
                    p.St_processar = cbTodos.Checked;
                    if (p.St_processar)
                        p.Quantidade = 1;
                    else
                        p.Quantidade = decimal.Zero;
                });
                bsAssistente.ResetBindings(true);
            }
        }

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       lCfg[0].cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }
        private void gAssistente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsAssistente.Current != null))
            {
                try
                {
                    if ((bsAssistente.Current as TRegistro_Adicionais).St_processar != true)
                    {
                        //Informar Quantidade   
                                (bsAssistente.Current as TRegistro_Adicionais).St_processar = true;
                                //Verificar saldo estoque do produto
                                if (lcfg[0].St_movestoquebool)
                                {
                                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsAssistente.Current as TRegistro_Adicionais).CD_Produto)) &&
                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsAssistente.Current as TRegistro_Adicionais).CD_Produto)))
                                    {
                                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsAssistente.Current as TRegistro_Adicionais).CD_Produto) &&
                                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio((bsAssistente.Current as TRegistro_Adicionais).CD_Produto))
                                        {
                                            decimal saldo = this.BuscarSaldoLocal(lCfg[0].cd_empresa, (bsAssistente.Current as TRegistro_Adicionais).CD_Produto);
                                            if (saldo < 1)
                                            {
                                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                                "Empresa.........: " + lCfg[0].cd_empresa.Trim() + "-" + lCfg[0].ds_empresa.Trim() + "\r\n" +
                                                                "Produto.........: " + (bsAssistente.Current as TRegistro_Adicionais).CD_Produto.Trim() + "-" + (bsAssistente.Current as TRegistro_Adicionais).DS_Produto.Trim() + "\r\n" +
                                                                "Local Arm.......: " + lCfg[0].cd_local.Trim() + "-" + lCfg[0].ds_local + "\r\n" +
                                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                (bsAssistente.Current as TRegistro_Adicionais).St_processar = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //Buscar ficha tecnica produto composto
                                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsAssistente.Current as TRegistro_Adicionais).CD_Produto, string.Empty, null);
                                            lFicha.ForEach(p => p.Quantidade = p.Quantidade * 1);
                                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                            //Buscar saldo itens da ficha tecnica
                                            string msg = string.Empty;
                                            lFicha.ForEach(p =>
                                            {
                                                //Buscar saldo estoque do item
                                                decimal saldo = decimal.Zero;
                                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(lCfg[0].cd_empresa, p.Cd_item, lCfg[0].cd_local, ref saldo, null);
                                                if (saldo < p.Quantidade)
                                                    msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                            });
                                            if (!string.IsNullOrEmpty(msg))
                                            {
                                                msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                (bsAssistente.Current as TRegistro_Adicionais).St_processar = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                                (bsAssistente.Current as TRegistro_Adicionais).Quantidade = 1;
                            
                            bsAssistente.ResetCurrentItem();

                        
                    }
                    else
                    {
                        (bsAssistente.Current as TRegistro_Adicionais).St_processar = false;
                        (bsAssistente.Current as TRegistro_Adicionais).Quantidade = decimal.Zero;
                        bsAssistente.ResetCurrentItem();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFAssistenteVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAssistente);
        }

        private void TFAssistenteVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6) || e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void afterGrava()
        {
            (bsAssistente.List as TList_Adicionais).ForEach(p =>
            {
                if(p.St_processar)
                    lAssistente.Add(p);
            });



            if (lAssistente.Count > 0)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Nenhum item adicionado ao Carrinho!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public TFAdicionais()
        {
            InitializeComponent();
        }

        private void FAdicionais_Load(object sender, EventArgs e)
        {

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lCfg = TCN_CFG.Buscar(string.Empty, null);
            lcfg =
               CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lCfg[0].cd_empresa, null);

            lassistente = TCN_Adicionais.Buscar(string.Empty, string.Empty, vCd_Produto, null);
            lassistente.ForEach(p => p.vl_unitario = ConsultaPreco(p.CD_Produto));

            bsAssistente.DataSource = lassistente;

            //lassistente.ForEach(p =>
            //{
            //    bsAssistente.Add(p);
            //});

        }
        private decimal ConsultaPreco(string vCd_produto)
        {
            
            if ((!string.IsNullOrEmpty(lCfg[0].cd_empresa)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                 
                if (!string.IsNullOrEmpty(lCfg[0].cd_tabelapreco))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(lCfg[0].cd_empresa,
                                                                                                vCd_produto,
                                                                                                lCfg[0].cd_tabelapreco,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }
    }
}

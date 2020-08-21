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
    public partial class TFAssistenteVenda : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private List<CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda> lassistente;
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda> lAssistente
        {
            get
            {
                if (bsAssistente.Count > 0)
                    return (bsAssistente.List as CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda).FindAll(p => p.St_processar);
                else return null;
            }
            set { lassistente = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }

        public TFAssistenteVenda()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (lAssistente.Exists(p => p.St_processar))
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Nenhum item adicionado ao Carrinho!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void TFAssistenteVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.ShapeGrid.RestoreShape(this, gAssistente);
            bsAssistente.DataSource = lassistente;
            //Buscar CFG
            lCfg =
               CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Cd_empresa, null);
        }

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
                (bsAssistente.List as CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda).ForEach(p =>
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

        private void gAssistente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsAssistente.Current != null))
            {
                try
                {
                    if ((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).St_processar != true)
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Venda";
                            fQtde.Casas_decimais = 2;
                            fQtde.Vl_default = 1;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).St_processar = true;
                                //Verificar saldo estoque do produto
                                if (lCfg[0].St_movestoquebool)
                                {
                                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda)) &&
                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda)))
                                    {
                                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda) &&
                                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda))
                                        {
                                            decimal saldo = this.BuscarSaldoLocal(Cd_empresa, (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda);
                                            if (saldo < fQtde.Quantidade)
                                            {
                                                MessageBox.Show("Não existe saldo disponível no estoque, porém será processado na locação.\r\n" +
                                                                "Empresa.........: " + Cd_empresa.Trim() + "-" + Nm_empresa.Trim() + "\r\n" +
                                                                "Produto.........: " + (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda.Trim() + "-" + (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).DS_ProdVenda.Trim() + "\r\n" +
                                                                "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                                "Saldo Disponível: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                                "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //(bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).St_processar = false;
                                                //return;
                                            }
                                        }
                                        else
                                        {
                                            //Buscar ficha tecnica produto composto
                                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).CD_ProdVenda, string.Empty, null);
                                            lFicha.ForEach(p => p.Quantidade = p.Quantidade * fQtde.Quantidade);
                                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                            //Buscar saldo itens da ficha tecnica
                                            string msg = string.Empty;
                                            lFicha.ForEach(p =>
                                            {
                                                //Buscar saldo estoque do item
                                                decimal saldo = decimal.Zero;
                                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(Cd_empresa, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                                if (saldo < p.Quantidade)
                                                    msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                            });
                                            if (!string.IsNullOrEmpty(msg))
                                            {
                                                msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).St_processar = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                                (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).Quantidade = fQtde.Quantidade;
                            }
                            bsAssistente.ResetCurrentItem();
                        }
                    }
                    else
                    {
                        (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).St_processar = false;
                        (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).Quantidade = decimal.Zero;
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
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Desconto_Click(object sender, EventArgs e)
        {
            if (bsAssistente.Current == null)
                return;

            //Validar usuário para operação
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR DESCONTO NO ACESSORIO", null))
            {
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Login = Utils.Parametros.pubLogin;
                    fRegra.Ds_regraespecial = "PERMITIR DESCONTO NO ACESSORIO";
                    if (fRegra.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Não será possível finalizar a operação, pois o usuário não possui permissão de desconto no acessório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //Informar valor do desconto
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Ds_label = "Valor:";
                fQtde.Casas_decimais = 2;
                fQtde.Vl_default = 1;
                fQtde.Vl_Minimo = 1;
                if (fQtde.ShowDialog() == DialogResult.OK)
                {
                    (bsAssistente.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAssistenteVenda).Vl_desconto = fQtde.Quantidade;
                    bsAssistente.ResetCurrentItem();
                }
            }
        }
    }
}

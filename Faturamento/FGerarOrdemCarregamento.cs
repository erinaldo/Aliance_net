using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Faturamento
{
    public partial class TFGerarOrdemCarregamento : Form
    {
        public string pCd_endereco
        { get; set; }
        public decimal pVl_frete
        { get; set; }
        public bool St_bloqueio
        { get; set; }
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedido
        { get; set; }
        private CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento rordem;
        public CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento rOrdem
        {
            get
            {
                if (bsOrdem.Current != null)
                    return bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento;
                else
                    return null;
            }
            set { rordem = value; }
        }
        public TFGerarOrdemCarregamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (Dt_carregamento.Focused)
                Dt_carregamento_Leave(this, new EventArgs());
            if (pDados.validarCampoObrigatorio())
            {
                if (!St_bloqueio)
                    if (!this.bloqueioCredito())
                    {
                        MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                       "Ordem não poderá ser gravada.", "Mensagem", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                if ((bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).lExp.Exists(p => p.St_processar))
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Selecione uma expedição!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscaExp()
        {
            if (bsOrdem.Current != null)
            {
                //Buscar Expedições para Pedido do Carregamento
                (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).lExp =
                    new CamadaDados.Faturamento.Pedido.TCD_Expedicao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                            "inner join TB_FAT_Pedido y " +
                                            "on x.Nr_pedido = y.Nr_pedido " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and y.cd_empresa = '" + (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Cd_empresa.Trim() + "' " +
                                            "and y.nr_pedido = " + (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Nr_pedido + ") " +
                                            "and not exists (select 1 from TB_FAT_Ordem_X_Expedicao k " +
								                             "inner join TB_FAT_OrdemCarregamento y " +
								                             "on k.CD_Empresa = y.CD_Empresa " +
								                             "and k.ID_Ordem = y.ID_Ordem " +
								                             "where a.cd_empresa = k.cd_empresa " +
								                             "and y.id_ordem = k.id_ordem " +
								                             "and a.id_expedicao = k.id_expedicao) "
                            }
                        }, 0, string.Empty);

                if ((bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).lExp.Count.Equals(0))
                {
                    MessageBox.Show("Pedido não possui volumes para carregamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                }
                bsOrdem.ResetCurrentItem();
            }
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty(rPedido.CD_Clifor)))
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rPedido.CD_Clifor,
                                                               decimal.Zero,
                                                               true,
                                                               ref rDados,
                                                               null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private void Busca_Endereco_Transportadora(string CD_Transportadora)
        {
            if (CD_Transportadora != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Transportadora,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                    if (string.IsNullOrEmpty(DS_Endereco_Transp.Text))
                        DS_Endereco_Transp.Text = List_Endereco[0].Ds_endereco.Trim();
            }
        }

        private void Busca_Endereco_Clifor()
        {
            if (rPedido.CD_Clifor != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rPedido.CD_Clifor,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count > 0)
                {
                    if (List_Endereco.Exists(p => p.St_enderecoentregabool))
                    {
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Logradouroent = List_Endereco.Find(p => p.St_enderecoentregabool).Ds_endereco;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Numeroent = List_Endereco.Find(p => p.St_enderecoentregabool).Numero;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Complementoent = List_Endereco.Find(p => p.St_enderecoentregabool).Ds_complemento;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Bairroent = List_Endereco.Find(p => p.St_enderecoentregabool).Bairro;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Cd_cidadeent = List_Endereco.Find(p => p.St_enderecoentregabool).Cd_cidade;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Ds_cidadeent = List_Endereco.Find(p => p.St_enderecoentregabool).DS_Cidade;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Uf_ent = List_Endereco.Find(p => p.St_enderecoentregabool).UF;
                    }
                    else if (List_Endereco.Count == 1)
                    {
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Logradouroent = List_Endereco[0].Ds_endereco;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Numeroent = List_Endereco[0].Numero;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Complementoent = List_Endereco[0].Ds_complemento;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Bairroent = List_Endereco[0].Bairro;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Cd_cidadeent = List_Endereco[0].Cd_cidade;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Ds_cidadeent = List_Endereco[0].DS_Cidade;
                        (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Uf_ent = List_Endereco[0].UF;
                    }
                }
            }
        }

        private void TFGerarOrdemCarregamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsOrdem.AddNew();
            //Formar Ordem de Carregamento com Info do Pedido
            (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Cd_empresa = rPedido.CD_Empresa;
            (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Nm_empresa = rPedido.Nm_Empresa;
            (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Nr_pedido = rPedido.Nr_pedido;
            (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Dt_entrega = rPedido.Dt_entregapedido;
            (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).Ds_obs = rPedido.DS_Observacao;
            this.BuscaExp();
            if ((bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).lExp.Count > 0)
            {
                this.Busca_Endereco_Clifor();
                this.St_bloqueio = this.bloqueioCredito();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFGerarOrdemCarregamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Transportadora_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { NM_Transportadora }, string.Empty);
            DS_Endereco_Transp.Text = string.Empty;
            if (linha != null)
                Busca_Endereco_Transportadora(linha["cd_clifor"].ToString());
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rPedido.CD_Clifor))
                FormBusca.UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent }, "a.cd_clifor|=|'" + rPedido.CD_Clifor.Trim() + "'");
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|60;" +
                              "b.uf|UF|30";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_cidadent_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadent.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void gExpedicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsExpedicao.Current != null))
            {
                (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).St_processar = 
                    !(bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).St_processar;
                bsExpedicao.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsExpedicao.Count > 0)
            {
                (bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento).lExp.ForEach(p => p.St_processar = cbTodos.Checked);
                bsOrdem.ResetBindings(true);
            }
        }

        private void Dt_carregamento_Leave(object sender, EventArgs e)
        {
            if (rPedido.DT_Pedido.HasValue && !string.IsNullOrEmpty(Dt_carregamento.Text) ?
                Convert.ToDateTime(Dt_carregamento.Text) < Convert.ToDateTime(Convert.ToDateTime(rPedido.DT_Pedido).ToString("dd/MM/yyyy")) : false)
            {
                MessageBox.Show("Dt.Carregamento deve ser maior que a data do pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dt_carregamento.Clear();
                Dt_carregamento.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(Dt_entrega.Text.SoNumero()) && !string.IsNullOrEmpty(Dt_carregamento.Text.SoNumero()) ?
                Convert.ToDateTime(Dt_entrega.Text) < Convert.ToDateTime(Dt_carregamento.Text) : false)
            {
                MessageBox.Show("Dt.Carregamento deve ser menor que a data de entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dt_carregamento.Clear();
                Dt_carregamento.Focus();
                return;
            }
        }

        private void Dt_entrega_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Dt_entrega.Text.SoNumero()) && !string.IsNullOrEmpty(Dt_carregamento.Text.SoNumero()) ? 
                Convert.ToDateTime(Dt_entrega.Text) < Convert.ToDateTime(Dt_carregamento.Text) : false)
            {
                MessageBox.Show("Dt.Entrega deve ser maior que a data do Carregamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dt_entrega.Clear();
                Dt_entrega.Focus();
                return;
            }
            if (rPedido.DT_Pedido.HasValue && !string.IsNullOrEmpty(Dt_entrega.Text.SoNumero()) ? 
                Convert.ToDateTime(Dt_entrega.Text) < Convert.ToDateTime(Convert.ToDateTime(rPedido.DT_Pedido).ToString("dd/MM/yyyy")) : false)
            {
                MessageBox.Show("Dt.Entrega deve ser maior que a data do pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dt_entrega.Clear();
                Dt_entrega.Focus();
                return;
            }
        }
    }
}

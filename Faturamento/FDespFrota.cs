using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFDespFrota : Form
    {
        public string Nr_notafiscal { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItens { get; set; }
        public TFDespFrota()
        {
            InitializeComponent();
            lItens = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
        }

        private void Totalizar()
        {
            decimal total = decimal.Zero;
            string produto = string.Empty;
            (bsItensAlocar.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).ForEach(p =>
            {
                p.St_processar = false;
                p.Quantidade_estoque = decimal.Zero;
                produto = p.Cd_produto;
                total = decimal.Zero;
                (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).ForEach(v =>
                v.lMov.ForEach(x =>
                {
                    if (x.Cd_produto.Trim().Equals(produto))
                        total += x.Quantidade;
                }));
                p.Qtd_devolvida = total;
            });
            bsItensAlocar.ResetBindings(true);
        }

        private void afterGrava()
        {
            if(bsManutencao.Count > 0)
                try
                {
                    CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo, null);

                    MessageBox.Show("Manutenções gravadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gItensAlocar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar)
                {
                    if ((bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade -
                        (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_devolvida > decimal.Zero)
                        using (Componentes.TFQuantidade qtde = new Componentes.TFQuantidade())
                        {
                            qtde.Casas_decimais = 3;
                            qtde.Ds_label = "Qtd. Alocar";
                            qtde.Vl_saldo = (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade -
                                            (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_devolvida;
                            qtde.Vl_default = (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade -
                                            (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_devolvida;
                            if (qtde.ShowDialog() == DialogResult.OK)
                            {
                                (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade_estoque = qtde.Quantidade;
                                (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar = true;
                            }
                        }
                    else MessageBox.Show("Item sem saldo para alocar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade_estoque = decimal.Zero;
                    (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar = false;
                }
                bsItensAlocar.ResetCurrentItem();
            }
        }

        private void bbAlocar_Click(object sender, EventArgs e)
        {
            if (bsItensAlocar.Count > 0)
                if ((bsItensAlocar.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Exists(p => p.St_processar))
                {
                    using (TFManutFrota fManut = new TFManutFrota())
                    {
                        if (fManut.ShowDialog() == DialogResult.OK)
                        {
                            //Buscar Almoxarifado
                            object obj = new CamadaDados.Almoxarifado.TCD_CadAlmox_X_Empresa().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "'"
                                                }
                                            }, "a.id_almox");
                            if(obj == null)
                            {
                                MessageBox.Show("Não existe almoxarifado configurado para a empresa " + (bsItensAlocar.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa.Trim(),
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            fManut.Manutencao.Cd_empresa = (bsItensAlocar[0] as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa;
                            fManut.Manutencao.Nr_notafiscal = Nr_notafiscal;
                            (bsItensAlocar.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).FindAll(p => p.St_processar).ForEach(p =>
                             {
                                 fManut.Manutencao.lMov.Add(new CamadaDados.Almoxarifado.TRegistro_Movimentacao()
                                 {
                                     Cd_produto = p.Cd_produto,
                                     Ds_produto = p.Ds_produto,
                                     Ds_observacao = "PRODUTO RETIRADO PELA MANUTENÇÃO DE VEICULOS FROTA",
                                     Cd_empresa = p.Cd_empresa,
                                     Tp_movimento = "S",
                                     Dt_movimento = CamadaDados.UtilData.Data_Servidor(),
                                     LoginAlmoxarife = Utils.Parametros.pubLogin,
                                     St_registro = "A",
                                     Quantidade = p.Quantidade_estoque,
                                     Vl_unitario = p.Vl_unitario,
                                     Vl_subtotal = p.Vl_subtotal,
                                     Id_almoxstr = obj.ToString()
                                 });
                             });
                            fManut.Manutencao.Vl_realizada = fManut.Manutencao.lMov.Sum(p => p.Vl_subtotal);
                            if (bsManutencao.Count.Equals(0))
                                bsManutencao.DataSource = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo() { fManut.Manutencao };
                            else (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Add(fManut.Manutencao);
                            bsManutencao.ResetBindings(true);
                            Totalizar();
                        }
                    }
                }
                else MessageBox.Show("Obrigatório selecionar itens para alocar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbExcluirManut_Click(object sender, EventArgs e)
        {
            if (bsManutencao.Current != null)
            {
                if(MessageBox.Show("Confirma exclusão da manutenção selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bsManutencao.RemoveCurrent();
                    Totalizar();
                }
            }
            else MessageBox.Show("Obrigatório selecionar manutenção para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbExcluirMov_Click(object sender, EventArgs e)
        {
            if (bsMov.Current != null)
            {
                if(MessageBox.Show("Confirma exclusão do movimento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bsMov.RemoveCurrent();
                    Totalizar();
                }
            }
            else MessageBox.Show("Obrigatório selecionar movimento para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFDespFrota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFDespFrota_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItensAlocar.DataSource = lItens;
        }
    }
}

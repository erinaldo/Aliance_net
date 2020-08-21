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
    public partial class TFItensExpedicao : Form
    {
        public string Nr_pedido
        { get; set; }
        public string Ds_obs
        { get; set; }

        public CamadaDados.Faturamento.Pedido.TRegistro_Expedicao rExpedicao
        {
            get
            {
                if ((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Exists(p => p.St_processar))
                    return bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao;
                else
                    return null;
            }
        }
        public TFItensExpedicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                if ((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Exists(p => p.St_processar))
                {
                    (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).Peso = vlPeso.Value;
                    if ((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Exists(p => p.St_processar && p.St_exigirserie && string.IsNullOrEmpty(p.Nr_serie)))
                    {
                        MessageBox.Show("Existe produto selecionado com Nº Série obrigatório!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
        }

        private void InformarPeso()
        {
            if (bsItensExpedicao.Current != null)
            {
                if ((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).PS_Unitario.Equals(0))
                {
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Ds_label = "Cadastrar Peso.Unit";
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                                try
                                {
                                    System.Collections.Hashtable hs = new System.Collections.Hashtable();
                                    hs.Add("@CD_PRODUTO", (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_produto);
                                    hs.Add("@PS_UNITARIO", fQtd.Quantidade);
                                    new CamadaDados.TDataQuery().executarSql("update TB_EST_PRODUTO set PS_UNITARIO = @PS_UNITARIO, Dt_alt = GETDATE() " +
                                                                             "where CD_PRODUTO = @CD_PRODUTO ", hs);
                                    (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).PS_Unitario = fQtd.Quantidade;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                    }
                }
            }
        }

        private void TFItensExpedicao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bsExpedicao.AddNew();
            Obs_Pedido.Text = Ds_obs;
            lbNumPedido.Text = "OBSERVAÇÃO DO PEDIDO Nº " + Nr_pedido;
            //Buscar Itens Pedido
            CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItem =
                new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = Nr_pedido
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.quantidade - a.qtd_expedida + a.qtd_devolvida",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);

            lItem.ForEach(p =>
                {
                    if (!p.St_exigirserie)
                    {
                        (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Add(
                            new CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao()
                            {
                                Cd_empresa = p.Cd_Empresa,
                                Nr_pedido = p.Nr_pedido,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Id_pedidoitem = p.Id_pedidoitem,
                                PS_Unitario = p.Ps_unitario,
                                SaldoCarregar = p.SaldoCarregar,
                                St_exigirserie = p.St_exigirserie
                            });
                    }
                    else
                    {
                        for (int i = 0; p.SaldoCarregar > i; i++)
                            (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Add(
                                new CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao()
                                {
                                    Cd_empresa = p.Cd_Empresa,
                                    Nr_pedido = p.Nr_pedido,
                                    Cd_produto = p.Cd_produto,
                                    Ds_produto = p.Ds_produto,
                                    Id_pedidoitem = p.Id_pedidoitem,
                                    Quantidade = 1,
                                    PS_Unitario = p.Ps_unitario,
                                    SaldoCarregar = p.SaldoCarregar,
                                    St_exigirserie = p.St_exigirserie
                                });
                    }
                });
            //Buscar Acessórios Pedido
            CamadaDados.Faturamento.Pedido.TList_AcessoriosPed lAcessorios =
                new CamadaDados.Faturamento.Pedido.TCD_AcessoriosPed().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = Nr_pedido
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.quantidade - a.qtd_expedida",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, 0, string.Empty);

            lAcessorios.ForEach(p =>
            {
                (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Add(
                           new CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao()
                           {
                               Nr_pedido = p.Nr_pedido,
                               Id_acessorio = p.Id_acessorio,
                               Cd_produto = p.Cd_produto,
                               Ds_produto = p.Ds_produto,
                               SaldoCarregar = p.SaldoCarregar,
                               St_exigirserie = false
                           });
            });
            bsExpedicao.ResetCurrentItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFItensExpedicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
            {
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CodBarra().BuscarEscalar(
                       new TpBusca[]
                       {
                            new TpBusca()
                            {
                                vNM_Campo = "cd_codbarra",
                                vOperador = "=",
                                vVL_Busca = "'" + txtCodBarras.Text.SoNumero().Trim() + "'"
                            }
                       }, "a.cd_produto");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                {
                    if ((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Find(p => p.Cd_produto.Equals(obj.ToString()) && !p.St_exigirserie).SaldoCarregar > 0)
                    {
                        (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Find(p => p.Cd_produto.Equals(obj.ToString())).Quantidade += 1;
                        (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Find(p => p.Cd_produto.Equals(obj.ToString())).St_processar = true;
                    }
                }
                else
                    MessageBox.Show("Produto não encontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodBarras.Text = string.Empty;

            }
        }

        private void gItensExpedicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsItensExpedicao.Current != null))
            {
                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar =
                    !(bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar;

                if ((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar &&
                    (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_exigirserie)
                {
                    bb_serie_Click(this, new EventArgs());
                    InformarPeso();
                }
                else if ((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar &&
                    !(bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_exigirserie)
                {
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Ds_label = "Informar Quantidade";
                        fQtd.Vl_default = (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).SaldoCarregar;
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                            {
                                InformarPeso();
                                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Quantidade = fQtd.Quantidade;
                            }
                            else
                            {
                                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Quantidade = decimal.Zero;
                                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar = false;
                            }
                        else
                        {
                            (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Quantidade = decimal.Zero;
                            (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar = false;
                        }
                    }
                }
                if (string.IsNullOrEmpty((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Nr_serie) &&
                    (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_exigirserie)
                    (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar = false;

                if ((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).St_processar == false)
                {
                    (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Nr_serie = string.Empty;
                    //Somar Peso de todos os produtos selecionados
                    vlPeso.Value = (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao)
                        .lItens
                        .FindAll(p => p.St_processar)
                        .Sum(p => p.Quantidade * p.PS_Unitario);
                    bsItensExpedicao.ResetCurrentItem();
                    return;
                }
                else
                {
                    //Somar Peso de todos os produtos selecionados
                    vlPeso.Value = (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao)
                        .lItens
                        .FindAll(p => p.St_processar)
                        .Sum(p => p.Quantidade * p.PS_Unitario);
                    bsItensExpedicao.ResetCurrentItem();
                    return;
                }
                
            }

        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            //Não trazer Nº Série de produtos já selecionados na lista desta tela.
            string and = string.Empty;
            if ((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Exists(p =>
                !string.IsNullOrEmpty(p.Nr_serie) && p.St_processar &&
                p.Cd_produto.Equals((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_produto)))
            {
                (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Where(p =>
                    !string.IsNullOrEmpty(p.Nr_serie) && p.St_processar &&
                    p.Cd_produto.Equals((bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_produto)).ToList().ForEach(p =>
                    and += ";a.id_serie|<>|" + p.Id_serie + " ");
            }
            string vParam = "(|NOT EXISTS|(SELECT 1 FROM TB_FAT_ItensExpedicao x " +
                              "where a.id_serie = x.id_serie ) " +
                             "or exists (SELECT 1 FROM TB_FAT_ItensExpedicao x " +
                             "inner join TB_FAT_Ordem_X_Expedicao y " +
                             "on x.CD_Empresa = y.CD_Empresa " +
                             "and x.ID_Expedicao = y.id_expedicao " +
                             "inner join TB_FAT_CompDevol_NF w " +
                             "on y.CD_Empresa = w.CD_Empresa " +
                             "and y.Nr_lanctoFiscal = w.Nr_LanctoFiscal_Origem " +
                             "inner join TB_PRD_Seriedevolvida z " +
                             "on w.cd_empresa = z.cd_empresa " +
                             "and w.nr_lanctofiscal_destino = z.nr_lanctofiscal " +
                             "and w.id_nfitem_destino = z.ID_NFItem " +
                             "where a.id_serie = x.id_serie )); " +
                             "a.cd_empresa|=|'" + (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_empresa.Trim() + "';" +
                             "a.cd_produto|=|'" + (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_produto.Trim() + "';" +
                             "isnull(a.st_registro, 'P')|=|'P'" + and;

            Componentes.EditDefault id = new Componentes.EditDefault();
            id.NM_Campo = "ID_Serie";
            id.NM_CampoBusca = "ID_Serie";
            Componentes.EditDefault ds = new Componentes.EditDefault();
            ds.NM_Campo = "Nr_serie";
            ds.NM_CampoBusca = "Nr_serie";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.Nr_serie|Nº Série|200;" +
                                             "a.Id_serie|ID|50",
                                             new Componentes.EditDefault[] { id, ds },
                                             new CamadaDados.Producao.Producao.TCD_SerieProduto(),
                                             vParam);

            if (!string.IsNullOrEmpty(id.Text))
            {
                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Id_seriestr = id.Text;
                (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Nr_serie = ds.Text;
                bsItensExpedicao.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsItensExpedicao.Count > 0)
            {
                (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.Where(p => !p.St_exigirserie).ToList().ForEach(p =>
                     {
                         p.St_processar = cbTodos.Checked;
                         p.Quantidade = p.St_processar ? p.SaldoCarregar : decimal.Zero;
                     });
                vlPeso.Value = (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens.FindAll(p => p.St_processar).Sum(p => p.Quantidade * p.PS_Unitario);
                bsExpedicao.ResetBindings(true);
            }
        }

        private void TFItensExpedicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCodBarras.Text += e.KeyChar.ToString();
        }
    }
}

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
    public partial class TFMovBoliche : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa { get; set; }
        private TTpModo modo = new TTpModo();

        public TFMovBoliche()
        {
            InitializeComponent();
        }

        #region Métodos

        private void instanciaTimer()
        {
            Timer t = new Timer();
            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += eventTick;
        }

        private void fecharPista(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            modo = TTpModo.tm_Edit;

            //Busca caixa aberto
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 1, string.Empty);
            if (lCaixa.Count > 0)
                rCaixa = lCaixa[0];
            else
            {
                MessageBox.Show("Não existe caixa aberto para finalizar a movimentação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Controlar tempo minimo para fechamento
            try
            {
                string[] minTime = e.Item.Text.ToString().Split(new string[] { " \n", " Tempo: " }, 0);
                if (Convert.ToDateTime(minTime[2]).TimeOfDay <= new TimeSpan(0, 0, 5))
                {
                    MessageBox.Show("Tempo mínimo para fechamento é de 5 segundos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch { }

            //Busca Movimentação boliche pela ID
            DataRow rMov = new TCD_MovBoliche().Buscar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_pista",
                        vOperador = "=",
                        vVL_Busca = "'" + e.Item.SubItems[1].Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.DT_Fechamento",
                        vOperador = "",
                        vVL_Busca = "is null"
                    }
                }, 1).Rows[0];
            if (rMov == null) return;

            //Valida existencia de prevenda
            DataRow rPreVenda = new TCD_PreVenda().Buscar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rMov[0].ToString().Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_cartao",
                        vOperador = "=",
                        vVL_Busca = "'" + rMov[1].ToString().Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.st_registro",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 1).Rows[0];
            if (rPreVenda == null)
            {
                MessageBox.Show("Não existe lançamento de pré-venda para o cartão informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Obtém valor por hora
            rMov[7] = CamadaDados.UtilData.Data_Servidor();
            object rValorhora = null;
            TList_HoraBoliche lHora = null;

            //Buscar tipo servico pela pista
            object tp_servico = new TCD_PistaBoliche().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.id_pista", vOperador = "=", vVL_Busca = "'" + e.Item.SubItems[1].Text.Trim() + "'" } }, "a.tp_servico");
            if (tp_servico == null || string.IsNullOrEmpty(tp_servico.ToString())) { MessageBox.Show("Não foi possível obter o tipo de serviço, para o item selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            switch (tp_servico.ToString())
            {
                case "B":
                    lHora = new TCD_HoraBoliche().Select(new TpBusca[] { new TpBusca() { vNM_Campo = "a.tp_servico", vOperador = "=", vVL_Busca = "'B'" } }, 0, string.Empty, " dia, hora asc");
                    break;
                case "S":
                    lHora = new TCD_HoraBoliche().Select(new TpBusca[] { new TpBusca() { vNM_Campo = "a.tp_servico", vOperador = "=", vVL_Busca = "'S'" } }, 0, string.Empty, " dia, hora asc");
                    break;
            }

            calcularVlPorServico(ref rValorhora, lHora, Convert.ToDateTime(rMov[6].ToString()));

            if (lHora == null || lHora.Count.Equals(0))
            {
                MessageBox.Show("Não foi possível obter o valor por hora, para a pista de boliche.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rValorhora == null)
            {
                MessageBox.Show("Não foi possível obter o valor por hora, para a pista de boliche.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Lança item na prevenda
            TRegistro_PreVenda_Item rItem = new TRegistro_PreVenda_Item()
            {
                Cd_empresa = rMov[0].ToString(),
                cd_produto = tp_servico.ToString().Equals("B")
                    ? (string)new TCD_CFG().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rMov[0].ToString().Trim() + "'" } }, "a.cd_horaboliche")
                    : (string)new TCD_CFG().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rMov[0].ToString().Trim() + "'" } }, "a.cd_horasinuca"),
                id_prevenda = decimal.Parse(rPreVenda[17].ToString().Trim()),
                quantidade = (decimal)Convert.ToDateTime(rMov[7].ToString()).Subtract(Convert.ToDateTime(rMov[6].ToString())).TotalMinutes / 60,
                vl_unitario = decimal.Parse(rValorhora.ToString()),
                vl_desconto = 0,
                obsItem = "Tempo: " + (Convert.ToDateTime(rMov[7].ToString()) - Convert.ToDateTime(rMov[6].ToString())),
                st_registro = "A",
                St_impresso = "N"
            };
            TCN_PreVenda_Item.Gravar(rItem, null);

            //Atualiza prevenda e itemprevenda na movimentacao
            TCN_MovBoliche.Gravar(new TRegistro_MovBoliche()
            {
                Cd_Empresa = rItem.Cd_empresa,
                Id_Cartao = decimal.Parse(rMov[1].ToString().Trim()),
                Id_Pista = decimal.Parse(e.Item.SubItems[1].Text.Trim()),
                Id_Mov = decimal.Parse(rMov[3].ToString().Trim()),
                Id_PreVenda = rItem.id_prevenda,
                Id_Item = rItem.id_item,
                Dt_abertura = Convert.ToDateTime(rMov[6].ToString().Trim()),
                Dt_fechamento = Convert.ToDateTime(rMov[7].ToString().Trim())
            }, null);

            //Reatualiza listagem de pistas
            atualizaListagem();
        }

        private void calcularVlPorServico(ref object rValorhora, TList_HoraBoliche lHora, DateTime dateTimeAbertura)
        {
            string x = dateTimeAbertura.DayOfWeek.ToString();
            switch (x)
            {
                case "Sunday":
                    x = "1";
                    break;
                case "Monday":
                    x = "2";
                    break;
                case "Tuesday":
                    x = "3";
                    break;
                case "Wednesday":
                    x = "4";
                    break;
                case "Thursday":
                    x = "5";
                    break;
                case "Friday":
                    x = "6";
                    break;
                case "Saturday":
                    x = "7";
                    break;
            }

            if (lHora.Count.Equals(1) || Convert.ToInt16(x) < Convert.ToInt16(lHora[0].Tp_dia))
            {
                rValorhora = lHora[0].Vl_hora;
            }
            else
            {
                for (int i = 0; i < lHora.Count; i++)
                {
                    if (i < (lHora.Count - 1))
                    {
                        if (Convert.ToInt16(x) >= Convert.ToInt16(lHora[i].Tp_dia) &&
                            Convert.ToInt16(x) <= Convert.ToInt16(lHora[i + 1].Tp_dia))
                        {
                            if (Convert.ToInt16(x) == Convert.ToInt16(lHora[i + 1].Tp_dia))
                            {
                                if (dateTimeAbertura.TimeOfDay.TotalMilliseconds < Convert.ToDateTime(lHora[i + 1].Hora.ToString()).TimeOfDay.TotalMilliseconds)
                                {
                                    rValorhora = lHora[i].Vl_hora;
                                }
                                else
                                {
                                    rValorhora = lHora[i + 1].Vl_hora;
                                }
                            }
                            else
                            {
                                if (rValorhora == null)
                                    rValorhora = lHora[i].Vl_hora;
                            }
                        }
                    }
                    else
                    {
                        if (rValorhora == null)
                            rValorhora = lHora[i].Vl_hora;
                    }
                }
            }
        }

        private void atualizaListagem()
        {
            lvPistas.Clear();

            TList_PistaBoliche lPista = TCN_PistaBoliche.Buscar(string.Empty,
                                                                string.Empty,
                                                                "A",
                                                                null);
            if (lPista.Count > 0)
            {
                //Listo todas pistas cadastradas
                lPista.ForEach(p =>
                {
                    int img; // 0 aberto pista 1 fechado pista 2 aberto sinuca 3 fechado sinuca
                    if (p.Tp_servico.Equals("B")) img = 0; else img = 2;
                    lvPistas.Items.Add(new ListViewItem(new string[] { p.Ds_Pista, p.Id_Pista.ToString() }, img));
                });
                lvPistas.View = View.Tile;

                //Adicionar timer
                foreach (ListViewItem item in lvPistas.Items)
                {
                    object obj = new CamadaDados.Restaurante.TCD_MovBoliche().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca(){
                            vNM_Campo = "a.id_pista",
                            vOperador = "=",
                            vVL_Busca = "'" + item.SubItems[1].Text + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.dt_fechamento",
                            vOperador = "is null",
                            vVL_Busca = ""
                        }
                    }, "a.id_mov");
                    //Para pista abertura
                    if (obj != null)
                        if (!string.IsNullOrEmpty(obj.ToString()))
                        {
                            instanciaTimer();
                            //Icone vermelho
                            object tpServico = new TCD_PistaBoliche().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.id_pista", vOperador = "=", vVL_Busca = "'" + item.SubItems[1].Text + "'" } }, "a.tp_servico");
                            if (tpServico != null && !string.IsNullOrEmpty(tpServico.ToString()))
                            {
                                if (tpServico.Equals("B"))
                                    item.ImageIndex = 1; //fechado pista
                                else
                                    item.ImageIndex = 3; //fechado sinuca
                            }
                        }
                        else
                        {
                            //Icone vermelho
                            object tpServico = new TCD_PistaBoliche().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.id_pista", vOperador = "=", vVL_Busca = "'" + item.SubItems[1].Text + "'" } }, "a.tp_servico");
                            if (tpServico != null && !string.IsNullOrEmpty(tpServico.ToString()))
                            {
                                if (tpServico.Equals("B"))
                                    item.ImageIndex = 0; //fechado pista
                                else
                                    item.ImageIndex = 2; //fechado sinuca
                            }
                        }
                }
            }
            else
            {
                MessageBox.Show("Não existe pistas de boliche ou mesas de sinuca pré-cadastradas para serem listadas.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private string buscaNrCartao(string id_pista)
        {
            if (!string.IsNullOrEmpty(id_pista))
            {
                object id_cartao = new TCD_MovBoliche().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_pista",
                            vOperador = "=",
                            vVL_Busca = "'" + id_pista.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.dt_fechamento",
                            vOperador = "",
                            vVL_Busca = "is null"
                        }
                    }, "a.id_cartao");
                if (id_cartao == null) return "";

                object nr_cartao = new TCD_Cartao().BuscarEscalar(
                new TpBusca[]
                {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cartao",
                            vOperador = "=",
                            vVL_Busca = "'" + id_cartao.ToString().Trim() + "'"
                        }
                }, "a.nr_cartao");
                if (nr_cartao == null) return "";

                return nr_cartao.SoNumero().ToString();
            }
            else
                return "";
        }

        #endregion

        #region Eventos

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFMovBoliche_Load(object sender, EventArgs e)
        {
            atualizaListagem();
        }

        private void lvPistas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            if (modo == TTpModo.tm_Edit) { modo = TTpModo.tm_Standby; return; };

            //Valida se existe movimentação aberta para pista selecionada
            object obj = new CamadaDados.Restaurante.TCD_MovBoliche().BuscarEscalar(new TpBusca[]
            {
                new TpBusca(){
                    vNM_Campo = "a.id_pista",
                    vOperador = "=",
                    vVL_Busca = "'" + e.Item.SubItems[1].Text + "'"
                },
                new TpBusca()
                {
                    vNM_Campo = "a.dt_fechamento",
                    vOperador = "is null",
                    vVL_Busca = ""
                }
            }, "a.id_mov");
            if (obj == null)
            {
                //Buscar Tp_servico para pista selecionada
                object tpServico = new CamadaDados.Restaurante.Cadastro.TCD_PistaBoliche().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.id_pista", vOperador = "=", vVL_Busca = "'" + e.Item.SubItems[1].Text + "'" } }, "a.tp_servico");
                if (tpServico != null && !string.IsNullOrEmpty(tpServico.ToString()))
                {
                    if (!tpServico.ToString().Equals("B"))
                        if (!tpServico.ToString().Equals("S"))
                        {
                            MessageBox.Show("Tipo de serviço do item está incorreto. Não será possível finalizar o processo. Informe um tipo válido no cadastro do item.");
                            return;
                        }
                }
                else
                {
                    MessageBox.Show("Erro ao obter tipo do serviço para o item selecionado. Não será possível finalizar o processo. Informe um tipo de serviço no cadastro do item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (TFLanMovBoliche fMov = new TFLanMovBoliche())
                {
                    if (fMov.ShowDialog() == DialogResult.OK)
                    {
                        //Gera movimentação
                        TCN_MovBoliche.Gravar(new TRegistro_MovBoliche()
                        {
                            Cd_Empresa = fMov.Cd_Empresa,
                            Id_Cartao = fMov.Id_cartao,
                            Id_Pista = decimal.Parse(e.Item.SubItems[1].Text),
                            Dt_abertura = CamadaDados.UtilData.Data_Servidor(),
                        }, null);
                        modo = TTpModo.tm_Edit;
                        atualizaListagem();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Já existe movimentação para o item selecionado. Deseja finalizar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    fecharPista(sender, e);
                }
            }
        }

        private void eventTick(object sender, EventArgs e)
        {
            //Atualização do horário
            foreach (ListViewItem lvItem in lvPistas.Items)
            {
                object obj = new CamadaDados.Restaurante.TCD_MovBoliche().BuscarEscalar(
                    new TpBusca[]
                    {
                            new TpBusca(){
                                vNM_Campo = "a.id_pista",
                                vOperador = "=",
                                vVL_Busca = "'" + lvItem.SubItems[1].Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_fechamento",
                                vOperador = "is null",
                                vVL_Busca = ""
                            }
                    }, "a.dt_abertura");

                if (obj != null)
                {
                    lvItem.SubItems[0].Text =
                        " Cartão: " + buscaNrCartao(lvItem.SubItems[1].Text) + " \n"
                        + (string)new TCD_PistaBoliche().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_pista",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + lvItem.SubItems[1].Text.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.st_registro",
                                                        vOperador = "=",
                                                        vVL_Busca = "'A'"
                                                    }
                                                }, "a.ds_pista") + " \n"
                        + " Tempo: " + (CamadaDados.UtilData.Data_Servidor() - Convert.ToDateTime(obj.ToString())).ToString();
                }

            }
        }

    }

    #endregion

}


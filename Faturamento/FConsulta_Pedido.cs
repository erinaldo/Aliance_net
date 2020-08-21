using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using Utils;
using Querys;
using FormBusca;
using Querys.Diversos;
using CamadaDados.Faturamento.Cadastros;
using Querys.Financeiro;

namespace Faturamento
{
    public partial class TFConsulta_Pedido : Form
    {
        public TFConsulta_Pedido()
        {
            InitializeComponent();
        }

        private void Novo()
        {
            DT_Inicial.Text = "";
            DT_Final.Text = "";
            RG_Movimento_Busca.NM_Valor = "T";
            cck_Todos.Checked = true;
            cck_Cancelado.Checked = false;
            cck_Fechado.Checked = false;
            cck_Ativo.Checked = false;
            cck_Encerrado.Checked = false;

            CD_Empresa_Busca.Text = "";
            NM_Empresa_Busca.Text = "";
            CFG_Pedido_Busca.Text = "";
            DS_CFG_Pedido_Busca.Text = "";

            CD_Clifor_Busca.Text = "";
            NM_Clifor_Busca.Text = "";

            BS_Pedido.Clear();
        }

        private void TFConsulta_Pedido_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;

            g_Consulta_Pedido.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Consulta_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            g_Itens_Pedido.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Itens_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            pnl_Consulta.set_FormatZero();

            Novo();
            Prepara_Botoes(true, false, false, false, false, true, false, false);
            
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btn_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa_Busca, NM_Empresa_Busca }
                          , new TDatEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                       "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
                 , new Componentes.EditDefault[] { CD_Empresa_Busca, NM_Empresa_Busca }, new TDatEmpresa());
        }

        private void btn_CFG_Pedido_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;ST_PermiteCFG_Fiscal|CFG Fiscal|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new Componentes.EditDefault[] { CFG_Pedido_Busca, DS_CFG_Pedido_Busca, Movimento_CFG_Busca}, 
                            new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CFG_Pedido_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido_Busca.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido_Busca, DS_CFG_Pedido_Busca, Movimento_CFG_Busca },
                new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));

        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                , new Componentes.EditDefault[] { CD_Clifor_Busca, NM_Clifor_Busca }, new TDatClifor(), null);
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor_Busca, NM_Clifor_Busca }, new TDatClifor());
        }
        
        private void Busca_Pedidos()
        {
            Int64 NR_Pedido_Busca = 0;

            if (NR_Pedido.Text != "")
            {
                NR_Pedido_Busca = Convert.ToInt64(NR_Pedido.Text);
            }
            

             TList_Pedido List_Pedido = TCN_Pedido.Busca( CD_Empresa_Busca.Text, rb_Entrada.Checked,
                              rb_Saida.Checked, NR_Pedido_Busca, CD_Clifor_Busca.Text, "", "", "", "", CFG_Pedido_Busca.Text, cck_Cancelado.Checked, cck_Fechado.Checked, cck_Encerrado.Checked, cck_Ativo.Checked, DT_Inicial.Text, DT_Final.Text, "", 0, "");

             if ((List_Pedido != null) && (List_Pedido.Count > 0))
             {
                BS_Pedido.DataSource = List_Pedido;
                Busca_Itens_Pedido();
                Prepara_Botoes(true, false, false, false, false, true, true, true);                    
             }
             else
             {
                 BS_Itens_Pedido.Clear();
             }


                  
        }

        private void Busca_Itens_Pedido()
        {
            TCN_Pedido.Busca_Pedido_Itens(BS_Pedido.Current as TRegistro_Pedido);
            TCN_Pedido.Totaliza_Itens(BS_Pedido.Current as TRegistro_Pedido);
            TCN_Pedido.Busca_Valores_Faturamento(BS_Pedido.Current as TRegistro_Pedido);
            BS_Pedido.ResetBindings(true);
        }

        private void Prepara_Botoes(bool vBB_Novo, bool vBB_Alterar, bool vBB_Cancelar,
                                    bool vBB_Gravar, bool vBB_Excluir, bool vBB_Buscar, bool vBB_Fecha, bool vBB_Imprimir)
        {
            BB_Novo.Visible = vBB_Novo;
            BB_Alterar.Visible = vBB_Alterar;
            BB_Cancelar.Visible = vBB_Cancelar;
            BB_Gravar.Visible = vBB_Gravar;
            BB_Excluir.Visible = vBB_Excluir;
            BB_Buscar.Visible = vBB_Buscar;
            BB_Fechar_Pedido.Visible = vBB_Fecha;
            BB_Imprimir.Visible = vBB_Imprimir;
            BB_Fechar.Visible = true;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca_Pedidos();
            BS_Pedido.ResetBindings(true);
        }

        private void TFConsulta_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 113) && (BB_Novo.Visible))
                this.BB_Novo_Click(sender, e);
            //else if ((e.KeyValue == 114) && (BB_Alterar.Visible))
              //  this.Altera();
            //else if ((e.KeyValue == 115) && (BB_Gravar.Visible))
             //   this.Grava();
            //else if ((e.KeyValue == 116) && (BB_Excluir.Visible))
             //   this.Exclui();
            //else if ((e.KeyValue == 117) && (BB_Cancelar.Visible))
             //   this.Cancelar();
            else if ((e.KeyValue == 118) && (BB_Buscar.Visible))
                this.BB_Buscar_Click(sender, e);
            //else if ((e.KeyValue == 119) && (BB_Imprimir.Visible))
             //   this.Print();
            else if ((e.KeyValue == 120) && (BB_Fechar_Pedido.Visible))
                this.BB_Fechar_Pedido_Click(sender, e);
        }

        private void BB_Fechar_Pedido_Click(object sender, EventArgs e)
        {
            Fecha_Pedido();
        }

        private void Fecha_Pedido()
        {
            if ((BS_Pedido != null) && (BS_Pedido.Count > 0))
            {
                if (((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido == "F") || ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido == "C"))
                {
                    MessageBox.Show("Você não pode ENCERRRAR um PEDIDO já FECHADO ou CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (MessageBox.Show("Deseja Realmente ENCERRAR o PEDIDO :" + (BS_Pedido.Current as TRegistro_Pedido).Nr_Pedido.ToString(), "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "P";
                            (BS_Pedido.Current as TRegistro_Pedido).ST_Registro = "P";
                            TCN_Pedido.Grava_Pedido(BS_Pedido.Current as TRegistro_Pedido, null, false, false);
                            cck_Fechado.Checked = true;
                            Busca_Pedidos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERRO: Pedido não foi Encerrado! " + ex.Message);
                        }

                    }
                }
            }
        }

        private void g_Consulta_Pedido_Click(object sender, EventArgs e)
        {
            Busca_Itens_Pedido();
        }

        private void cck_Fechado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Fechado.Checked == true)
            {
                if (cck_Todos.Checked == true)
                {
                    cck_Todos.Checked = false;
                }
            }
        
        }

        private void cck_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Todos.Checked == true)
            {
                cck_Fechado.Checked = false;
                cck_Encerrado.Checked = false;
                cck_Ativo.Checked = false;
                cck_Cancelado.Checked = false;
            }
        }

        private void cck_Encerrado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Encerrado.Checked == true)
            {
                if (cck_Todos.Checked == true)
                {
                    cck_Todos.Checked = false;
                }
            }
        }

        private void cck_Cancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Cancelado.Checked == true)
            {
                if (cck_Todos.Checked == true)
                {
                    cck_Todos.Checked = false;
                }
            }
        }

        private void cck_Ativo_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Ativo.Checked == true)
            {
                if (cck_Todos.Checked == true)
                {
                    cck_Todos.Checked = false;
                }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BN_Itens_Pedido_RefreshItems(object sender, EventArgs e)
        {

        }
        
    }
}

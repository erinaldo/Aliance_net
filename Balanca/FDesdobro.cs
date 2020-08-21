using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balanca
{
    public partial class TFDesdobro : Form
    {
        public CamadaDados.Balanca.TRegistro_LanPesagemGraos rPsgraos
        { get; set; }
        private CamadaDados.Balanca.TRegistro_DesdobroEspecial rdesd;
        public CamadaDados.Balanca.TRegistro_DesdobroEspecial rDesd
        {
            get
            {
                if (bsDesdobroEspecial.Current != null)
                    return bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial;
                else
                    return null;
            }
            set { rdesd = value; }
        }

        public TFDesdobro()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pc_desdobro.Focused)
                pc_desdobro_Leave(this, new EventArgs());
            if (peso_desdobro.Focused)
                peso_desdobro_Leave(this, new EventArgs());
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFDesdobro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rdesd != null)
            {
                id_tpdesdobro.Enabled = false;
                bb_tpdesdobro.Enabled = false;
                nr_pedidodest.Enabled = false;
                bb_pedidodest.Enabled = false;
                bsDesdobroEspecial.DataSource = new CamadaDados.Balanca.TList_DesdobroEspecial() { rdesd };
                pc_desdobro.Enabled = rdesd.Tp_landesdobro.Trim().ToUpper().Equals("P");
                peso_desdobro.Enabled = rdesd.Tp_landesdobro.Trim().ToUpper().Equals("S");
                if (!pc_desdobro.Focus())
                    peso_desdobro.Focus();
            }
            else
            {
                bsDesdobroEspecial.AddNew();
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Cd_empresa = rPsgraos.Cd_empresa;
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Id_ticket = rPsgraos.Id_ticket;
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Tp_pesagem = rPsgraos.Tp_pesagem;
                id_tpdesdobro.Focus();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDesdobro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_tpdesdobro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdesdobro|Tipo Desdobro|200;" +
                              "a.id_tpdesdobro|TP. Desdobro|80;" +
                              "a.tp_calcpeso|Base Calculo|80;" +
                              "a.tp_landesdobro|Tipo Calculo|80;" +
                              "a.pc_desdobro|% Desdobro|80";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpdesdobro, ds_tpdesdobro },
                                            new CamadaDados.Balanca.Cadastros.TCD_TpDesdobroEspecial(),
                                            string.Empty);
            if ((linha != null) && (bsDesdobroEspecial.Current != null))
            {
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Tp_landesdobro = linha["tp_landesdobro"].ToString();
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Tp_calcpeso = linha["tp_calcpeso"].ToString();
                if (linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P"))
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Pc_desdobro = Convert.ToDecimal(linha["pc_desdobro"].ToString());
                pc_desdobro.Enabled = linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P");
                peso_desdobro.Enabled = linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("S");

                if (rPsgraos != null)
                {
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_basecalc = linha["tp_calcpeso"].ToString().Trim().ToUpper().Equals("B") ? rPsgraos.Ps_liquidobruto : rPsgraos.Ps_liquido;
                    if (linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P"))
                        pc_desdobro_Leave(this, new EventArgs());
                    else
                        peso_desdobro_Leave(this, new EventArgs());
                }
                bsDesdobroEspecial.ResetCurrentItem();
            }
        }

        private void id_tpdesdobro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpdesdobro|=|" + id_tpdesdobro.Text;
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpdesdobro, ds_tpdesdobro },
                                        new CamadaDados.Balanca.Cadastros.TCD_TpDesdobroEspecial());
            if ((linha != null) && (bsDesdobroEspecial.Current != null))
            {
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Tp_landesdobro = linha["tp_landesdobro"].ToString();
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Tp_calcpeso = linha["tp_calcpeso"].ToString();
                if (linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P"))
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Pc_desdobro = Convert.ToDecimal(linha["pc_desdobro"].ToString());
                pc_desdobro.Enabled = linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P");
                peso_desdobro.Enabled = linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("S");

                if (rPsgraos != null)
                {
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_basecalc = linha["tp_calcpeso"].ToString().Trim().ToUpper().Equals("B") ? rPsgraos.Ps_liquidobruto : rPsgraos.Ps_liquido;
                    if (linha["tp_landesdobro"].ToString().Trim().ToUpper().Equals("P"))
                        pc_desdobro_Leave(this, new EventArgs());
                    else
                        peso_desdobro_Leave(this, new EventArgs());
                }
            }
        }

        private void bb_pedidodest_Click(object sender, EventArgs e)
        {
            string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                              "n.CD_Empresa|Cód. Empresa|80;" +
                              "n.NM_Empresa|Empresa |100;" +
                              "a.NR_Pedido|NRº Pedido|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "clifor.NM_Clifor|Nome Clifor|150;" +
                              "a.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|150;" +
                              "a.id_pedidoitem|Id. PedidoItem|80";


            string vParamFixo =
                                "a.cd_produto|=|'" + rPsgraos.Cd_produto.Trim() + "';" +
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                                "n.st_pedido|=|'F';" + //Pedido Fechado
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)";
            //Verificar se o usuario tem acesso a transferencia entre empresas diferentes
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR TRANSF. ENTRE CONTRATOS DE EMPRESAS DIFERENTES", null))
                vParamFixo += ";n.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] 
            { nr_pedidodest,
              NR_Contrato,
              CD_Empresa,
              NM_Empresa,
              CD_Clifor,
              NM_Clifor,
              cd_produtodest,
              ds_produtodest,
              id_pedidoitemdest},
              new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item(), vParamFixo);
        }

        private void nr_pedidodest_Leave(object sender, EventArgs e)
        {
            string vParam = "a.NR_Pedido|=|" + nr_pedidodest.Text + ";" +
                                              "a.cd_produto|=|'" + rPsgraos.Cd_produto.Trim() + "';" +
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                                "n.st_pedido|=|'F';" + //Pedido Fechado
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)";
            //Verificar se o usuario tem acesso a transferencia entre empresas diferentes
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR TRANSF. ENTRE CONTRATOS DE EMPRESAS DIFERENTES", null))
                vParam += ";n.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { 
                                               nr_pedidodest,
                                               NR_Contrato,
                                               CD_Empresa,
                                               NM_Empresa,
                                               CD_Clifor,
                                               NM_Clifor,
                                               cd_produtodest,
                                               ds_produtodest,
                                               id_pedidoitemdest},
                                               new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item());
        }

        private void peso_basecalc_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tp_landesdobro.Text))
                if (tp_landesdobro.Text.Trim().ToUpper().Equals("PERCENTUAL"))
                    peso_desdobro.Value = (peso_basecalc.Value * pc_desdobro.Value) / 100;
                else if (tp_landesdobro.Text.Trim().ToUpper().Equals("PESO"))
                    pc_desdobro.Value = (peso_desdobro.Value / 100) * peso_basecalc.Value;
        }

        private void pc_desdobro_Leave(object sender, EventArgs e)
        {
            if (bsDesdobroEspecial.Current != null)
            {
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_desdobro = 
                    ((bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_basecalc * 
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Pc_desdobro) / 100;
                bsDesdobroEspecial.ResetCurrentItem();
            }
        }

        private void peso_desdobro_Leave(object sender, EventArgs e)
        {
            if (bsDesdobroEspecial.Current != null)
            {
                (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Pc_desdobro =
                    ((bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_desdobro / 100) *
                    (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Peso_basecalc;
                bsDesdobroEspecial.ResetCurrentItem();
            }
        }
    }
}

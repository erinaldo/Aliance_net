using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace Proc_Commoditties
{
    public partial class TFVincularECFNF : Form
    {
        private string pcd_empresa;
        public string pCd_empresa
        {
            get { return CD_Empresa.Text; }
            set { pcd_empresa = value; }
        }
        private string pcd_cliente;
        public string pCd_cliente
        {
            get { return cd_clifor.Text; }
            set { pcd_cliente = value; }
        }
        
        public List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lCupom
        {
            get
            {
                if (bsVenda.Count > 0)
                    return (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFVincularECFNF()
        {
            InitializeComponent();
        }
                
        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            //Cupom Fiscal Ativo
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'C'";
            //Nao ter sido vinculado a NF Ativa
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "not exists";
            filtro[2].vVL_Busca = "(select 1 from tb_fat_ecfvinculadonf x " +
                                  "inner join tb_fat_notafiscal y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                  "where x.id_cupom = a.id_nfce " +
                                  "and x.cd_empresa = a.cd_empresa " +
                                  "and isnull(y.st_registro, 'A') <> 'C')";
            //Se NFC-e, buscar somente as enviadas
            filtro[3].vNM_Campo = "lote.status";
            filtro[3].vOperador = "in";
            filtro[3].vVL_Busca = "(100, 150)";
            //Cliente Cupom
            if (!st_filtrocliente.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_clifor = '" + cd_clifor.Text.Trim() + "') or (a.cd_clifor is null) or (a.cd_clifor = cfg.CD_Clifor)";
            }
            if (vl_inicial.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_cupom";
                filtro[filtro.Length - 1].vVL_Busca = vl_inicial.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if (vl_final.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_cupom";
                filtro[filtro.Length - 1].vVL_Busca = vl_final.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(id_coo.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_coo.Text;
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + "'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_nfce = a.id_nfce " +
                                                      "and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            }
            if (st_combustivel.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                                      "inner join tb_est_produto y " +
                                                      "on x.cd_produto = y.cd_produto " +
                                                      "inner join tb_est_tpproduto z " +
                                                      "on y.tp_produto = z.tp_produto " +
                                                      "and x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_nfce = a.id_nfce " +
                                                      "and isnull(z.st_combustivel, 'N') <> 'S')";
            }
            if(emPlaca.Text.Trim() != "-")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + emPlaca.Text.Trim() + "'";
            }
            bsVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(filtro, 0, string.Empty, string.Empty);
            tot_cupom.Value = (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).Sum(p => p.Vl_cupom);
            bsVenda_PositionChanged(this, new EventArgs());
        }

        private void AgruparItens()
        {
            CamadaDados.Faturamento.PDV.TList_NFCe_Item lItem = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
            if (bsVenda.Count > 0)
                (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).FindAll(p => p.St_processar).ForEach(p =>
                    p.lItem.ForEach(v=>
                    {
                        if (lItem.Exists(z => z.Cd_produto.Trim().Equals(v.Cd_produto.Trim())))
                        {
                            lItem.Find(z => z.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Quantidade += v.Quantidade;
                            lItem.Find(z => z.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_subtotal += v.Vl_subtotal;
                            lItem.Find(z => z.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_desconto += v.Vl_desconto;
                        }
                        else
                            lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item()
                            {
                                Cd_produto = v.Cd_produto,
                                Ds_produto = v.Ds_produto,
                                Sigla_unidade = v.Sigla_unidade,
                                Quantidade = v.Quantidade,
                                Vl_unitario = v.Vl_unitario,
                                Vl_subtotal = v.Vl_subtotal,
                                Vl_desconto = v.Vl_desconto
                            });
                    }));
            bsItensFaturar.DataSource = lItem;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFVincularECFNF_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gVenda);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_clifor.Text = pcd_cliente;
            if (!string.IsNullOrEmpty(pcd_cliente))
                cd_clifor_Leave(this, new EventArgs());
            CD_Empresa.Text = pcd_empresa;
            if (!string.IsNullOrEmpty(pcd_empresa))
                CD_Empresa_Leave(this, new EventArgs());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }
                
        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
                if((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count.Equals(0))
                {
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                           (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa, 
                                                                           string.Empty,
                                                                           null);
                    bsVenda.ResetCurrentItem();
                }
        }

        private void gVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_processar =
                    !(bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_processar;
                if ((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count.Equals(0))
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                           (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                           string.Empty,
                                                                           null);
                bsVenda.ResetCurrentItem();
                if (bsVenda.Count > 0)
                    tot_cupomvincular.Value = (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).Where(p => p.St_processar).Sum(p => p.Vl_cupom);
                AgruparItens();
            }
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsVenda.Count > 0)
            {
                (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).ForEach(p =>
                    {
                        p.St_processar = cbProcessar.Checked;
                        if (p.lItem.Count.Equals(0))
                            p.lItem = CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(p.Id_nfcestr,
                                                                                         p.Cd_empresa,
                                                                                         string.Empty,
                                                                                         null);
                    });
                tot_cupomvincular.Value = (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_NFCe).Where(p => p.St_processar).Sum(p => p.Vl_cupom);
                bsVenda.ResetBindings(true);
                AgruparItens();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFVincularECFNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if(e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_combustivel, 'N')|=|'S'",
                                            new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFVincularECFNF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gVenda);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void emPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Utils;
using BancoDados;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFVendaCombustivel : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }

        public CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel rVenda
        {
            get
            {
                if (bsVendaCombustivel.Current != null)
                    return bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel;
                else
                    return null;
            }
        }

        public TFVendaCombustivel()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (!(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Id_bico.HasValue)
                {
                    MessageBox.Show("Obrigatorio selecionar bico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (volumeabastecido.Focused)
                {
                    (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido = volumeabastecido.Value;
                    volumeabastecido_Leave(this, new EventArgs());
                    
                }
                if (vl_unitario.Focused)
                    (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_unitario = vl_unitario.Value;
                if (vl_subtotal.Focused)
                {
                    (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_subtotal = vl_subtotal.Value;
                    vl_subtotal_Leave(this, new EventArgs());
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFVendaCombustivel_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsVendaCombustivel.AddNew();
            (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Tp_registro = "M";//Manual
            (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Dt_abastecimento =
                CamadaDados.UtilData.Data_Servidor();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
            //Tabela Preco
            TabelaPreco();
            //Buscar lista de bicos
            BuscarBico();
        }

        private void TabelaPreco()
        {
            if (cbEmpresa.SelectedValue != null)
            {
                //Buscar Tabela Preco
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cbEmpresa.SelectedValue + "'"
                                }
                            }, "a.cd_tabelapreco");
                if (obj != null)
                    Cd_tabelapreco = obj.ToString();
            }
        }

        private void BuscarBico()
        {
            if (cbEmpresa.SelectedValue != null )
                bsBico.DataSource = CamadaNegocio.PostoCombustivel.Cadastros.TCN_BicoBomba.Buscar(string.Empty,
                                                                                                  string.Empty,
                                                                                                  cbEmpresa.SelectedValue.ToString(),
                                                                                                  string.Empty,
                                                                                                  "'A'",
                                                                                                  null);
        }

        

        

        private void volumeabastecido_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = volumeabastecido.Value * vl_unitario.Value;
            encerranteFinal.Value = encerranteIni.Value + volumeabastecido.Value;
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {
            if(vl_unitario.Value > decimal.Zero)
                volumeabastecido.Value = vl_subtotal.Value / vl_unitario.Value;
            else if(volumeabastecido.Value > decimal.Zero)
                vl_unitario.Value = vl_subtotal.Value /  volumeabastecido.Value;
            volumeabastecido_Leave(this, new EventArgs());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFVendaCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void gBico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar)
                {
                    (bsBico.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).ForEach(p => p.St_processar = false);
                    bsBico.ResetBindings(true);

                }
                (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar =
                    !(bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar;
                bsBico.ResetCurrentItem();
                if ((bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar)
                {
                    (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Id_bico =
                        (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Id_bico;
                    sigla_unidade.Text = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Sigla_unidade;
                    if (!string.IsNullOrEmpty(Cd_tabelapreco))
                    {
                        vl_unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(cbEmpresa.SelectedValue.ToString(),
                                                                                                                 (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Cd_produto,
                                                                                                                 Cd_tabelapreco,
                                                                                                                 null);
                        vl_unitario.Enabled = vl_unitario.Equals(decimal.Zero);
                        // busca valor encerrante bico do ultimo abastecimento por bico 
                        string id_bico = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Id_bicostr;
                        object obj = 
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_bico",
                                                vOperador = "=",
                                                vVL_Busca = "'" + id_bico + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                                            }
                                        },"a.encerrantebico", string.Empty, "a.dt_abastecimento desc", null);
                        encerranteIni.Text = obj.ToString();
                        encerranteFinal.Value = encerranteIni.Value + volumeabastecido.Value;
                    
                    }
                    else vl_unitario.Enabled = true;
                    volumeabastecido.Focus();
                }
                else (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Id_bico = null;
                bsVendaCombustivel.ResetCurrentItem();
            }


        }

        private void volumeabastecido_Enter(object sender, EventArgs e)
        {
            if ((volumeabastecido.Value > decimal.Zero) && (vl_subtotal.Value > decimal.Zero))
                vl_unitario.Value = decimal.Divide(vl_subtotal.Value, volumeabastecido.Value);
        }

        private void encerranteFinal_Leave(object sender, EventArgs e)
        {
            encerranteFinal.Value = encerranteIni.Value + volumeabastecido.Value;
        }

        private void cbEmpresa_Leave(object sender, EventArgs e)
        {
            BuscarBico();
            TabelaPreco();
        }
    }
}

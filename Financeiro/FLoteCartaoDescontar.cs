using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Cartao;

namespace Financeiro
{
    public partial class FLoteCartaoDescontar : Form
    {
        public TRegistro_LanLoteCartao rLoteCartao
        {
            get
            {
                return bsLote.Current as TRegistro_LanLoteCartao;
            }
            set
            {
                cLoteCartao = value;
            }
        }

        private TRegistro_LanLoteCartao cLoteCartao
        {
            get;set;
        }



        public FLoteCartaoDescontar()
        {
            InitializeComponent();
        }

        private void FLoteCartaoDescontar_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pLote.set_FormatZero();
            //Buscar empresa

            if(cLoteCartao != null)
            {
                bsLote.Add(cLoteCartao);
            }
            else
            {
                bsLote.AddNew();
            }
            

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
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                   "a.ds_contager|Unidade|150;" +
                   "a.cd_contager|Código|50",
                   new Componentes.EditDefault[] { cd_contager, DS_CONTAGER },
                   new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(),
                   string.Empty);
        }
        
        

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pLote.validarCampoObrigatorio())
            {
                if((bsLote.Current as TRegistro_LanLoteCartao).lFatCartao.Count > 0)
                {
                    (bsLote.Current as TRegistro_LanLoteCartao).lFatCartao.ForEach(p => {

                        TRegistro_FaturaDescontar fat = new TRegistro_FaturaDescontar();
                        fat.Id_Fatura = Convert.ToDecimal(p.Id_fatura);
                        fat.Cd_Empresa = p.Cd_empresa;
                        (bsLote.Current as TRegistro_LanLoteCartao).lCartao.Add(fat);
                    });
                    (bsLote.Current as TRegistro_LanLoteCartao).lFatCartao.Clear();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lote sem títulos!", "Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
           "a.cd_contager|=|" + cd_contager.Text + "",
           new Componentes.EditDefault[] { cd_contager, DS_CONTAGER },
           new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }
        
        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            if(pLote.validarCampoObrigatorio())
            using(TFQuitarFaturaCartao cartoes = new Financeiro.TFQuitarFaturaCartao())
            {
                cartoes.pCd_Empresa = cbEmpresa.SelectedValue.ToString();
                cartoes.pCd_Contager = cd_contager.Text;
                cartoes.pDt_Processa = editData1.Text;
               // cartoes.pId_Bandeira = id_bandeira.Text;


                if(cartoes.ShowDialog() == DialogResult.OK)
                {
                    cartoes.lFat.ForEach(p =>
                    {
                            (bsLote.Current as TRegistro_LanLoteCartao).lFatCartao.Add(p);
                    });
                    bsLote.ResetCurrentItem();
                }


            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente remover?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                bsFatCartao.RemoveCurrent();
        }

        private void FLoteCartaoDescontar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                BB_Cancelar_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                btn_Inserir_Item_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                btn_Deleta_Item_Click(this, new EventArgs());
        }
    }
}

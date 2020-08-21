using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using FormBusca;
using Utils;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Diversos;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadItens : FormCadPadrao.FFormCadPadrao
    {
        private string tm;
        public TFCadItens()
        {
            InitializeComponent();
            DTS = BS_CadItens;
            tm = "";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadItens.AddNew();
                base.afterNovo();
                id_lancto.Focus();
                dt_lancto.Text = DateTime.Now.ToString();
                bloqCamp();
                
            }
        }

        public override void afterAltera()
        {   
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                cd_produto.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadItens.RemoveCurrent();
            
        }

        public override void afterBusca()
        {
            base.afterBusca();
            
        }

        public override int buscarRegistros()
        {
            TList_CadItens lista = TCN_CadItens.Buscar(cd_produto.Text, id_lancto.Text, id_almox.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadItens.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadItens.Clear(); 
                return lista.Count;
            }
            else
                return 0;
        }        

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadItens.deletarItens(BS_CadItens.Current as TRegistro_CadItens);
                    BS_CadItens.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadItens.gravarItens(BS_CadItens.Current as TRegistro_CadItens);
            else
                return "";
        }

        private void bb_id_almox_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("id_almox|ID. Almoxarifado|100;ds_almoxarifado|Descrição|450",
                new Componentes.EditDefault[] { id_almox, ds_almox }, new TCD_CadLocal(), "");
        }

        private void bb_id_rua_Click(object sender, EventArgs e)
        {
            string tm = id_rua.Text.Trim();
            string vColuna = "a.id_rua|ID. Rua|100;a.ds_rua|Nome da Rua|350";
            string vParam = "";
            UtilPesquisa.BTN_BUSCA(vColuna, new Componentes.EditDefault[] { id_rua, ds_rua }, new TCD_CadRua(), vParam);
            bloqCamp(); 
            if(id_rua.Text.Trim() != tm)
                limCamp(true);
            
        }

        private void bb_id_secao_Click(object sender, EventArgs e)
        {
            string tm = id_secao.Text.Trim();
            string vColuna = "a.id_secao|ID. Seção|100;a.ds_secao|Descrição|350";
            string vParam = "";
            if (id_rua.Text != "")
                vParam += "a.id_rua|=|'" + id_rua.Text + "'|=|(select 1 from tb_amx_rua b where b.id_rua = a.id_rua)";
            UtilPesquisa.BTN_BUSCA(vColuna, new Componentes.EditDefault[] { id_secao, ds_secao }, new TCD_CadSecao(), vParam);
            bloqCamp(); 
            if(id_secao.Text.Trim() != tm)
                limCamp(false);
        }

        private void bb_id_nivel_Click(object sender, EventArgs e)
        {
            string vColuna = "a.id_nivel|ID. Nivel|100;a.ds_nivel|Descrição|350";
            string vParam = "";
            if (id_secao.Text != "")
                vParam += "a.id_rua|=|'" + id_rua.Text + "';a.id_secao|=|'" + id_secao.Text + "'|=|(select 1 from tb_amx_secao h where h.id_secao = a.id_secao and h.id_rua = a.id_rua)";
            UtilPesquisa.BTN_BUSCA(vColuna,
            new Componentes.EditDefault[] { id_nivel, ds_nivel }, new TCD_CadAMX_CelulaArm(), vParam);
            
            
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("id_almox|=|'" + id_almox.Text + "'",
            new Componentes.EditDefault[] { id_almox, ds_almox }, new TCD_CadLocal());
        }

        private void id_rua_Leave(object sender, EventArgs e)
        {            
            UtilPesquisa.EDIT_LEAVE("a.id_rua|=|'" + id_rua.Text + "'",
            new Componentes.EditDefault[] { id_rua, ds_rua }, new TCD_CadRua());
            if((id_rua.Text.Trim() == "")||(id_rua.Text.Trim() != tm))
                limCamp(true);
            bloqCamp();
        }

        private void id_secao_Leave(object sender, EventArgs e)
        {           
            string vColuna = "id_secao|=|'" + id_secao.Text + "';a.id_rua|=|'" + id_rua.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColuna, new Componentes.EditDefault[] { id_secao, ds_secao }, new TCD_CadSecao());
            if((id_secao.Text.Trim() != tm)||(id_secao.Text.Trim() == ""))
                limCamp(false);
            bloqCamp();
        }

        private void id_nivel_Leave(object sender, EventArgs e)
        {
            string vColuna = "id_nivel|=|'" + id_nivel.Text + "';a.id_secao|=|'" + id_secao.Text + "';a.id_rua|=|'" + id_rua.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColuna, new Componentes.EditDefault[] { id_nivel, ds_nivel }, new TCD_CadAMX_CelulaArm());
        }

        private void bb_cdProduto_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(Select 1 from tb_est_produto a where e.st_Servico <> 'S')";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("A.cd_produto|=|'" + cd_produto.Text + "'", 
            new Componentes.EditDefault[] { cd_produto, ds_produto }, new TCD_CadProduto());
        }

        public void bloqCamp()
        {
            if ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit))
            {
                if (id_rua.Text.Trim().Equals(""))
                {
                    id_secao.Enabled = false; bb_id_secao.Enabled = false;
                    id_secao.Text = ""; ds_secao.Text = "";
                    id_nivel.Enabled = false; bb_id_nivel.Enabled = false;
                    id_nivel.Text = ""; ds_nivel.Text = "";
                }
                else
                {
                    id_secao.Enabled = true; bb_id_secao.Enabled = true;
                    if (id_secao.Text.Trim().Equals(""))
                    {
                        id_nivel.Enabled = false; bb_id_nivel.Enabled = false;
                        id_nivel.Text = ""; ds_nivel.Text = "";
                    }
                    else
                    {
                        id_nivel.Enabled = true; bb_id_nivel.Enabled = true;                        
                    }
                }
            }
        }

        public void limCamp(bool tp)
        {
            if ((vTP_Modo == TTpModo.tm_Edit) || (vTP_Modo == TTpModo.tm_Insert))
            {
                if (tp)
                {
                    id_secao.Text = ""; ds_secao.Text = "";
                    id_nivel.Text = ""; ds_nivel.Text = ""; 
                }
                else
                {
                    id_nivel.Text = ""; ds_nivel.Text = "";
                }
            }
        }

        private void id_rua_Enter(object sender, EventArgs e)
        {
            tm = id_rua.Text.Trim();            
        }

        private void id_secao_Enter(object sender, EventArgs e)
        {
            tm = id_secao.Text.Trim();
        }

        private void dt_lancto_Click(object sender, EventArgs e)
        {
            dt_lancto.Text = "";
        }        
    }
}

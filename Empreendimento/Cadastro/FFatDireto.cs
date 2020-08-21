using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento;
using Utils;
using System.Windows.Forms;
using CamadaDados.Empreendimento.Cadastro;

namespace Empreendimento.Cadastro
{
    public partial class FFatDireto : Form
    {

        public string vCd_Local { get; set; }
        public string vDs_Local { get; set; }
        public string vSt_fatdireto { get; set; }
        
        public string vTp_Fat { get; set; }
        public string vID_Orcamento { get; set; }
        public string vNr_Versao { get; set; }
        public string vCD_Empresa { get; set; }
        public string vCD_Clifor { get; set; }
        public FFatDireto()
        {
            InitializeComponent();
        }

        private void afterbusca()
        {
            if (!string.IsNullOrEmpty(this.vCd_Local))
            {
                this.vDs_Local = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().BuscarEscalar(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_local",
                        vOperador = "=",
                        vVL_Busca = vCd_Local
                    }
                }, "a.ds_local").ToString();

            }

            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vID_Orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vID_Orcamento;
            }
            if (!string.IsNullOrEmpty(vNr_Versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Versao;
            }
            //if (!string.IsNullOrEmpty(vId_registro))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "a.id_registro";
            //    filtro[filtro.Length - 1].vOperador = "=";
            //    filtro[filtro.Length - 1].vVL_Busca = vId_registro;
            //}

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = " isnull(a.quantidade - a.qtd_faturada,0) ";
            filtro[filtro.Length - 1].vOperador = ">";
            filtro[filtro.Length - 1].vVL_Busca = "0";
            if (!string.IsNullOrEmpty(vSt_fatdireto))
            {
                if (vSt_fatdireto.Equals("S"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_fatdireto,'N') ";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_fatdireto + "'";
                }
                else if (vSt_fatdireto.Equals("N"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_fatdireto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'S'";
                }
            }

            (bsFatDireto.Current as TRegistro_CadFatDireto).lFicha = new TCD_FichaTec(null).Select(filtro, 0, string.Empty);
            bsFatDireto.ResetCurrentItem();
        }
        private void FFatDireto_Load(object sender, EventArgs e)
        {
            if (bsFatDireto.Current != null)
            {


            }
            else 
            {
                bsFatDireto.AddNew();
            }
            (bsFatDireto.Current as TRegistro_CadFatDireto).cd_empresa = vCD_Empresa;
            (bsFatDireto.Current as TRegistro_CadFatDireto).Id_orcamentostr = vID_Orcamento;
            (bsFatDireto.Current as TRegistro_CadFatDireto).Nr_versaostr = vNr_Versao;
            (bsFatDireto.Current as TRegistro_CadFatDireto).Dt_emissaostring = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm");
            afterbusca();

        }
        
        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (FItensRemessa itensRemessa = new FItensRemessa())
            {
                ///itensRemessa.rOrcamento = (bsFatDireto.Current as TRegistro_CadFatDireto);
                itensRemessa.vNr_Versao = (bsFatDireto.Current as TRegistro_CadFatDireto).Nr_versaostr;
                itensRemessa.vCD_Empresa = (bsFatDireto.Current as TRegistro_CadFatDireto).cd_empresa;
                itensRemessa.vID_Orcamento = (bsFatDireto.Current as TRegistro_CadFatDireto).Id_orcamentostr;
                itensRemessa.vTp_Fat = "Direto";
                itensRemessa.rFatDir = (bsFatDireto.Current as TRegistro_CadFatDireto);
                itensRemessa.vCd_Local = vCd_Local;
                itensRemessa.vSt_fatdireto = vSt_fatdireto;

                if (itensRemessa.ShowDialog() == DialogResult.OK)
                {
                    itensRemessa.lFicha.ForEach(p =>
                    {
                        if(p.quantidade_agregar > decimal.Zero)
                        {
                            (bsFatDireto.Current as TRegistro_CadFatDireto).lFicha.Add(p);
                            bsFatDireto.ResetCurrentItem();
                        }

                    });
                  
                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados2.validarCampoObrigatorio())
            if (MessageBox.Show("Deseja gravar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CamadaDados.Empreendimento.TList_RemessaNf valor = CamadaNegocio.Empreendimento.TCN_RemessaNf.Buscar(vCD_Empresa, string.Empty, string.Empty, string.Empty,editFloat2.Value.ToString(), null);

                if (valor.Count <= 0)
                {
                        if ((bsFatDireto.Current as TRegistro_CadFatDireto).lFicha.Count > 0)
                        {
                            bool a = false;
                            (bsFatDireto.Current as TRegistro_CadFatDireto).lFicha.ForEach(p =>
                            {
                                if (p.quantidade_agregar > decimal.Zero)
                                    a = true;
                            });
                            if (a)
                            {
                                CamadaNegocio.Empreendimento.Cadastro.TCN_CadFatDireto.Gravar((bsFatDireto.Current as TRegistro_CadFatDireto), null);
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                            MessageBox.Show("Para gravar deve informar os itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Número da remessa já existe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FFatDireto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            if (e.KeyCode.Equals(Keys.F5))
                this.toolStripButton1_Click(this, new EventArgs());
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|150;a.cd_endereco|Código|50",
                new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(),
                "a.cd_clifor|=|'" + vCD_Clifor.ToString() + "'");
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { editDefault2, nm_clifor }, string.Empty);
        }

        private void editDefault2_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|" + editDefault2.Text.Trim() + "",
                new Componentes.EditDefault[] { editDefault2, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + vCD_Clifor.Trim() + "';" +
                                              "a.cd_endereco|=|" + cd_endereco.Text.Trim() + "",
                                              new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|" + cd_empresa.Text.Trim() + "", new Componentes.EditDefault[] { cd_empresa });
        }

        private void panelDados2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if ((bsFicha.Current as TRegistro_FichaTec).quantidade_agregar > decimal.Zero)
                {
                    (bsFicha.Current as TRegistro_FichaTec).st_agregar =
                    !(bsFicha.Current as TRegistro_FichaTec).st_agregar;
                }
                else
                {
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Text = "Quantidade";
                        //fQtd.Vl_default = (bsFicha.Current as TRegistro_FichaTec).vl_faturar;
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                            {
                                if (fQtd.Quantidade <= (bsFicha.Current as TRegistro_FichaTec).Quantidade)
                                {
                                    (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar =
                                        fQtd.Quantidade;
                                    (bsFicha.Current as TRegistro_FichaTec).Vl_subtotal = decimal.Multiply((bsFicha.Current as TRegistro_FichaTec).quantidade_agregar, (bsFicha.Current as TRegistro_FichaTec).Vl_unitario);

                                }
                                else
                                {
                                    MessageBox.Show("Quantidade informada é maior que a QTD.Item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                                return;
                            }
                        else
                        {
                            (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                            (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                        }
                    }
                }
                bsFatDireto.ResetCurrentItem();
            }
            else
            if(e.ColumnIndex == 1)
            {
                if(bsFicha.Current != null)
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Text = "Quantidade";
                    //fQtd.Vl_default = (bsFicha.Current as TRegistro_FichaTec).vl_faturar;
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > decimal.Zero)
                        {
                            if (fQtd.Quantidade <= (bsFicha.Current as TRegistro_FichaTec).Quantidade)
                            {
                                (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar =
                                    fQtd.Quantidade;
                                (bsFicha.Current as TRegistro_FichaTec).Vl_subtotal = decimal.Multiply((bsFicha.Current as TRegistro_FichaTec).quantidade_agregar, (bsFicha.Current as TRegistro_FichaTec).Vl_unitario);

                            }
                            else
                            {
                                MessageBox.Show("Quantidade informada é maior que a QTD.Item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                            return;
                        }
                    else
                    {
                        (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                        (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                    }
                    }
                bsFatDireto.ResetCurrentItem();
            }
        }
    }
}

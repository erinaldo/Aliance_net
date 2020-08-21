using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFDataAdicionais : Form
    {
        public bool St_contato = false;
        public string Cd_clifor
        { get; set; }
        public string Id_contato
        { get; set; }
        private List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor> lConjuge
        { get; set; }
        private List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor> lClifor
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor> lDataCliforDel
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_DataContato> lDataContatoDel
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TList_DataContato lDataContato
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor> lDataClifor
        {
            get
            {
                if (bsDataClifor.Count > decimal.Zero || bsDataConjuge.Count > decimal.Zero)
                {
                    List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor> lista =
                        new List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor>();
                    lClifor.ForEach(p =>
                    {
                        lista.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor()
                        {
                            Id_TpData = p.Id_TpData,
                            Ds_tpdata = p.Ds_tpdata,
                            Tp_clifor = p.Tp_clifor,
                            Data = p.Data
                        });
                    });
                    lConjuge.ForEach(p =>
                    {
                        lista.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor()
                        {
                            Id_TpData = p.Id_TpData,
                            Ds_tpdata = p.Ds_tpdata,
                            Tp_clifor = p.Tp_clifor,
                            Data = p.Data
                        });
                    });
                    return lista;
                }
                else
                    return null;
            }
        }
        public TFDataAdicionais()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsDataClifor.Count > 0 || bsDataConjuge.Count > 0 || bsDataContato.Count > 0)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Não existem datas para serem gravadas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bb_NovoDataClifor_Click(object sender, EventArgs e)
        {
             using (TFData fData = new TFData())
             {
                fData.St_cliente = true;
                if (fData.ShowDialog() == DialogResult.OK)
                    if (fData.rDataClifor != null)
                        try
                        {
                            if (lClifor.Exists(p => p.Id_TpData.Equals(fData.rDataClifor.Id_TpData)))
                            {
                                lClifor.Find(p => p.Id_TpData.Equals(fData.rDataClifor.Id_TpData)).Data = fData.rDataClifor.Data;
                                bsDataClifor.DataSource = lClifor;
                                bsDataClifor.ResetBindings(true);
                            }
                            else
                            {
                                lClifor.Add(fData.rDataClifor);
                                bsDataClifor.DataSource = lClifor;
                                bsDataClifor.ResetBindings(true);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
             }
        }

        private void bb_ExcluirDataClifor_Click(object sender, EventArgs e)
        {
            if (bsDataClifor.Current != null)
            {
                if (MessageBox.Show("Deseja excluir a Data?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    lDataCliforDel.Add(bsDataClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor);
                    bsDataClifor.Remove(bsDataClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor);
                    bsDataClifor.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe registro para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_NovoDataConjuge_Click(object sender, EventArgs e)
        {
            using (TFData fData = new TFData())
            {
                fData.St_conjuge = true;
                if (fData.ShowDialog() == DialogResult.OK)
                    if (fData.rDataClifor != null)
                        try
                        {
                            if (lConjuge.Exists(p => p.Id_TpData.Equals(fData.rDataClifor.Id_TpData)))
                            {
                                lConjuge.Find(p => p.Id_TpData.Equals(fData.rDataClifor.Id_TpData)).Data = fData.rDataClifor.Data;
                                bsDataConjuge.DataSource = lConjuge;
                                bsDataConjuge.ResetBindings(true);
                            }
                            else
                            {
                                lConjuge.Add(fData.rDataClifor);
                                bsDataConjuge.DataSource = lConjuge;
                                bsDataConjuge.ResetBindings(true);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_ExcluirDataConjuge_Click(object sender, EventArgs e)
        {
            if (bsDataConjuge.Current != null)
            {
                if (MessageBox.Show("Deseja excluir a Data?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    lDataCliforDel.Add(bsDataConjuge.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor);
                    bsDataConjuge.Remove(bsDataConjuge.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor);
                    bsDataConjuge.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe registro para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_NovoDataContato_Click(object sender, EventArgs e)
        {
            using (TFData fData = new TFData())
            {
                fData.St_contato = true;
                if (fData.ShowDialog() == DialogResult.OK)
                    if (fData.rDataContato != null)
                        try
                        {
                            if (lDataContato.Exists(p => p.Id_TpData.Equals(fData.rDataContato.Id_TpData)))
                            {
                                lDataContato.Find(p => p.Id_TpData.Equals(fData.rDataContato.Id_TpData)).Data = fData.rDataContato.Data;
                                bsDataContato.DataSource = lDataContato;
                                bsDataContato.ResetBindings(true);
                            }
                            else
                            {
                                lDataContato.Add(fData.rDataContato);
                                bsDataContato.DataSource = lDataContato;
                                bsDataContato.ResetBindings(true);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_ExcluirContatos_Click(object sender, EventArgs e)
        {
            if (bsDataContato.Current != null)
            {
                if (MessageBox.Show("Deseja excluir a Data?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    lDataContatoDel.Add(bsDataContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataContato);
                    bsDataContato.Remove(bsDataContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_DataContato);
                    bsDataContato.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe registro para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFDataAdicionais_Load(object sender, EventArgs e)
        {
            //Lista exclusão
            lDataCliforDel = new List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor>();
            lDataContatoDel = new List<CamadaDados.Financeiro.Cadastros.TRegistro_DataContato>();
            //Lista Conjuge
            lConjuge = new List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor>();
            //Lista Clifor
            lClifor = new List<CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor>();
            //Lista Contato
            lDataContato = new CamadaDados.Financeiro.Cadastros.TList_DataContato();

            //Buscar datas
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                lClifor = CamadaNegocio.Financeiro.Cadastros.TCN_DataClifor.Buscar(Cd_clifor,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   "C",
                                                                                   null);
                bsDataClifor.DataSource = lClifor;
                bsDataClifor.ResetBindings(true);

                lConjuge = CamadaNegocio.Financeiro.Cadastros.TCN_DataClifor.Buscar(Cd_clifor,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    "J",
                                                                                    null);
                bsDataConjuge.DataSource = lConjuge;
                bsDataConjuge.ResetBindings(true);
            }
            //Buscar datas Contatos
            if (!string.IsNullOrEmpty(Cd_clifor) && !string.IsNullOrEmpty(Id_contato))
            {
                lDataContato = CamadaNegocio.Financeiro.Cadastros.TCN_DataContato.Buscar(Id_contato,
                                                                                         Cd_clifor,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         null);
                bsDataContato.DataSource = lDataContato;
                bsDataContato.ResetBindings(true);
            }

            if (!St_contato)
                tcDetalhes.TabPages.Remove(tpContatos);
            else
            {
                tcDetalhes.TabPages.Remove(tpCliente);
                tcDetalhes.TabPages.Remove(tpConjuge);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDataAdicionais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

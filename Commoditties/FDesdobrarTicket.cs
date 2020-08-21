using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFDesdobrarTicket : Form
    {
        public CamadaDados.Balanca.TRegistro_LanPesagemGraos rPsGraos
        {get;set;}
        public CamadaDados.Graos.TList_Contrato_X_DesdEspecial lDesdobroEspecial
        { get; set; }
        public List<CamadaDados.Balanca.TRegistro_ItensDesdobro> lDesdobros
        { 
            get 
            {
                List<CamadaDados.Balanca.TRegistro_ItensDesdobro> lRetorno = new List<CamadaDados.Balanca.TRegistro_ItensDesdobro>();
                foreach (CamadaDados.Balanca.TRegistro_ItensDesdobro r in bsItensdesdobro.List)
                    lRetorno.Add(r);
                return lRetorno;
            }
        }

        public TFDesdobrarTicket()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsItensdesdobro.Count.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar itens desdobro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            using (TFItemDesdobro fItem = new TFItemDesdobro())
            {
                fItem.pCd_tabeladesconto = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Cd_tabeladesconto;
                fItem.pDs_tabeladesconto = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Ds_tabeladesconto;
                fItem.pTp_movimento = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Tp_movimento;
                fItem.pCd_empresa = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Cd_empresa;
                fItem.pNm_empresa = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Nm_empresa;
                fItem.pCd_produto = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Cd_produto;
                fItem.pDs_produto = (bsPsGraos.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).Ds_produto;

                if (fItem.ShowDialog() == DialogResult.OK)
                {
                    bsItensdesdobro.Add(new CamadaDados.Balanca.TRegistro_ItensDesdobro()
                    {
                        Nr_contrato_dest = fItem.Nr_contratodest,
                        Cd_contratante_dest = fItem.pCd_contratante_dest,
                        Nm_contratante_dest = fItem.pNm_contratante_dest,
                        Nr_notaprodutor = fItem.Nr_nfprodutor,
                        Dt_emissaonfprodutor = fItem.pDt_emissaonfprodutor,
                        Qt_nfprodutor = fItem.Qtd_nfprodutor,
                        Vl_nfprodutor = fItem.pVl_nfprodutor,
                        Tp_pesodesdobro = fItem.Tp_pesodesdobro,
                        Qtd_desdobro = fItem.Qtd_desdobro,
                        Tp_percvalor = fItem.Tp_percvalor
                    });
                    bsItensdesdobro.ResetBindings(true);
                }
            }
        }

        public void ExcluirItem()
        {
            if(bsItensdesdobro.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsItensdesdobro.RemoveCurrent();
        }

        private void TFDesdobrarTicket_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsPsGraos.DataSource = new CamadaDados.Balanca.TList_RegLanPesagemGraos() { rPsGraos };
            if (lDesdobroEspecial != null)
                if (lDesdobroEspecial.Count > 0)
                {
                    lDesdobroEspecial.ForEach(p =>
                        {
                            using (TFItemDesdobro fItem = new TFItemDesdobro())
                            {
                                fItem.Nr_contratodest = p.Nr_contrato_dest;
                                fItem.Tp_percvalor = p.Valor_desdobro.Equals(decimal.Zero) ? "Q" : "P";
                                fItem.Tp_pesodesdobro = p.Tp_pesodesdobro;
                                fItem.Qtd_desdobro = p.Valor_desdobro;
                                fItem.pCd_tabeladesconto = rPsGraos.Cd_tabeladesconto;
                                fItem.pTp_movimento = rPsGraos.Tp_movimento;
                                if (fItem.ShowDialog() == DialogResult.OK)
                                {
                                    bsItensdesdobro.Add(new CamadaDados.Balanca.TRegistro_ItensDesdobro()
                                    {
                                        Nr_contrato_dest = fItem.Nr_contratodest,
                                        Cd_contratante_dest = fItem.pCd_contratante_dest,
                                        Nm_contratante_dest = fItem.pNm_contratante_dest,
                                        Nr_notaprodutor = fItem.Nr_nfprodutor,
                                        Dt_emissaonfprodutor = fItem.pDt_emissaonfprodutor,
                                        Qt_nfprodutor = fItem.Qtd_nfprodutor,
                                        Vl_nfprodutor = fItem.pVl_nfprodutor,
                                        Tp_pesodesdobro = fItem.Tp_pesodesdobro,
                                        Qtd_desdobro = fItem.Qtd_desdobro,
                                        Tp_percvalor = fItem.Tp_percvalor
                                    });
                                }
                            }
                        });
                    bsItensdesdobro.ResetBindings(true);
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

        private void TFDesdobrarTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
        }

        private void bb_inseriritem_Click(object sender, EventArgs e)
        {
            InserirItem();
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }
    }
}

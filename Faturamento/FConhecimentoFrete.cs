using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using System.Xml;
using Utils;

namespace Faturamento
{
    public partial class TFConhecimentoFrete : Form
    {
        public bool St_Importar = false;
        private CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rctrc;
        public CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCtrc
        {
            get
            {
                if (bsCTRC.Current != null)
                    return bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete;
                else
                    return null;
            }
            set { rctrc = value; }
        }
        private bool St_serieexiste = true;
        private bool St_modeloexiste = true;

        private string Cd_clifor_emp;

        public TFConhecimentoFrete()
        {
            InitializeComponent();
            Cd_clifor_emp = string.Empty;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("REMETENTE", "0"));
            cbx1.Add(new TDataCombo("EXPEDIDOR", "1"));
            cbx1.Add(new TDataCombo("RECEBEDOR", "2"));
            cbx1.Add(new TDataCombo("DESTINATARIO", "3"));
            tp_tomador.DataSource = cbx1;
            tp_tomador.DisplayMember = "Display";
            tp_tomador.ValueMember = "Value";
        }

        private void TFConhecimentoFrete_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rctrc != null)
                bsCTRC.DataSource = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete() { rctrc };
            else
                bsCTRC.AddNew();
            //Importar Xml
            if (St_Importar)
                ImportarXml();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (cd_modelo.Text.Trim().Equals("57") && (chaveacesso.Text.Trim().Length < 44))
                {
                    MessageBox.Show("Obrigatorio informar chave acesso(44 caracteres) para gravar CT-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chaveacesso.Focus();
                    return;
                }
                if (!St_serieexiste)
                {
                    MessageBox.Show("Serie não cadastrada no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!St_modeloexiste)
                {
                    MessageBox.Show("Modelo documento fiscal não cadastrado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void afterInserirNf()
        {
            if (bsCTRC.Current != null)
            {
                if (cd_empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresa.Focus();
                    return;
                }
                if (tp_movimento.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatório informar tipo movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_movimento.Focus();
                    return;
                }
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") &&
                    cd_remetente.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar remetente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_remetente.Focus();
                    return;
                }
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") &&
                    cd_destinatario.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar destinatario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_destinatario.Focus();
                    return;
                }
                if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A"))
                {
                    using (TFLanNotasFrete fNota = new TFLanNotasFrete())
                    {
                        fNota.Cd_empresa = cd_empresa.Text;
                        fNota.Nm_empresa = nm_empresa.Text;
                        fNota.Tp_movimento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                        fNota.Cd_clifor = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ?
                                            cd_remetente.Text : cd_destinatario.Text;
                        fNota.Nm_clifor = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ?
                                            nm_remetente.Text : nm_destinatario.Text;
                        if (fNota.ShowDialog() == DialogResult.OK)
                            if (fNota.lNf != null)
                            {
                                //Se a nota ja nao existir inclui
                                fNota.lNf.ForEach(p =>
                                {
                                    if (!(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf.Exists(v =>
                                        v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                        v.Nr_lanctofiscal.Equals(p.Nr_lanctofiscal)))
                                    {
                                        p.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa, p.Nr_lanctofiscalstr, 0, string.Empty, null);
                                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf.Add(p);
                                    }
                                });
                                bsCTRC.ResetCurrentItem();
                            }
                    }
                }
                else
                    MessageBox.Show("Só é permitido incluir notas fiscais para conhecimento de frete com status <ABERTO>.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe registro de conhecimento de frete selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluirNf()
        {
            if (bsCTRC.Current != null)
            {
                if (!(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Não é permitido excluir nota fiscal de um conhecimento frete com status diferente de <ABERTO>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsNotaFiscal.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar nota fiscal para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Nota Fiscal selecionada: " + (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_notafiscal.ToString().Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfDel.Add(
                        bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento);
                    //Excluir item do grid
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf.Remove(
                        bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento);
                    bsCTRC.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe nota fiscal selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarCFOP()
        {
            if ((bsCTRC.Current != null) &&
                (!string.IsNullOrEmpty(cd_movimentacao.Text)))
            {
                //Buscar CFOP Movimentacao
                CamadaDados.Fiscal.TList_Mov_X_CFOP lMovCfop =
                    CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Buscar(cd_movimentacao.Text,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               null);
                if (lMovCfop.Count > 0)
                {
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cfop =
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_remetente.Trim().Equals(
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_destinatario.Trim()) ?
                        lMovCfop[0].Cd_cfop_dentroestado : lMovCfop[0].Cd_cfop_foraestado;
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cfop =
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_remetente.Trim().Equals(
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_destinatario.Trim()) ?
                        lMovCfop[0].Ds_cfop_dentroestado : lMovCfop[0].Ds_cfop_foraestado;
                    bsCTRC.ResetCurrentItem();
                }
            }
        }

        private void BuscarCMI()
        {
            if ((bsCTRC.Current != null) &&
            (!string.IsNullOrEmpty(cd_movimentacao.Text)))
            {
                //Buscar CMI Movimentação
                CamadaDados.Fiscal.TList_CadMov_x_CMI lMovCmi =
                    CamadaNegocio.Fiscal.TCN_CadMov_x_CMI.Busca(decimal.Parse(cd_movimentacao.Text),
                                                                decimal.Zero,
                                                                string.Empty);
                if (lMovCmi.Count > 0)
                {
                    cd_cmi.Text = lMovCmi[0].CD_CMIString;
                    ds_cmi.Text = lMovCmi[0].ds_cmi;
                }
            }
        }

        private void BuscarImpostosNota()
        {
            if (bsCTRC.Current != null)
            {
                (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos.RemoveAll(p => p.Tp_registro.Trim().ToUpper() != "M");
                if ((!string.IsNullOrEmpty(cd_condfiscal_transp.Text)) &&
                    (!string.IsNullOrEmpty(cd_movimentacao.Text)) &&
                    (!string.IsNullOrEmpty(cd_empresa.Text)) &&
                    (!string.IsNullOrEmpty(nr_serie.Text)) &&
                    (dt_emissao.Text.Trim() != "/  /") &&
                    (!string.IsNullOrEmpty(cd_transportadora.Text)) &&
                    (!string.IsNullOrEmpty(tp_pessoa.Text)) &&
                    ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete > 0) &&
                    (bsCTRC.Current != null))
                {
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos.Concat(
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condfiscal_transp.Text,
                                                                                                                   string.Empty,
                                                                                                                   cd_movimentacao.Text,
                                                                                                                   "E",
                                                                                                                   tp_pessoa.Text,
                                                                                                                   cd_empresa.Text,
                                                                                                                   nr_serie.Text,
                                                                                                                   cd_transportadora.Text,
                                                                                                                   string.Empty,
                                                                                                                   dt_emissao.Data,
                                                                                                                   decimal.Zero,
                                                                                                                   (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   null));
                    bsCTRC.ResetCurrentItem();
                }
                if ((!string.IsNullOrEmpty(cd_remetente.Text)) &&
                    (!string.IsNullOrEmpty(cd_transportadora.Text)) &&
                    (!string.IsNullOrEmpty(cd_destinatario.Text)) &&
                    (!string.IsNullOrEmpty(cd_movimentacao.Text)))
                {
                    string vObsFiscal = string.Empty;
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpostos =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(cd_empresa.Text,
                                                                                                          cd_uf_remetente.Text,
                                                                                                          cd_uf_destinatario.Text,
                                                                                                          cd_movimentacao.Text,
                                                                                                          "E",
                                                                                                          cd_condfiscal_transp.Text,
                                                                                                          string.Empty,
                                                                                                          (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete,
                                                                                                          decimal.Zero,
                                                                                                          ref vObsFiscal,
                                                                                                          dt_emissao.Data,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          null);
                    if (lImpostos.Count > 0)
                    {
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos.Concat(lImpostos);
                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Obsfiscal +=
                            string.IsNullOrEmpty((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Obsfiscal) ? vObsFiscal : "\r\n" + vObsFiscal;
                        bsCTRC.ResetCurrentItem();
                    }
                    else
                        if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(string.Empty, string.Empty, null))
                            MessageBox.Show("Não existe condição fiscal para: \r\n" +
                                                "Movimentação Comercial: " + cd_movimentacao.Text.Trim() + " - " + ds_movimentacao.Text.Trim() + "\r\n" +
                                                "Condição Fiscal Clifor: " + cd_condfiscal_transp.Text.Trim() + "\r\n" +
                                                "UF Origem: " + cd_uf_transportadora.Text + "\r\n" +
                                                "UF Destino: " + cd_uf_destinatario.Text, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void VerificarCTRCExiste()
        {
            if (bsCTRC.Current != null)
                if ((cd_transportadora.Text.Trim() != string.Empty) &&
                    (nr_ctrc.Text.Trim() != string.Empty))
                {
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrc =
                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar(string.Empty,
                                                                                    string.Empty,
                                                                                    nr_ctrc.Text,
                                                                                    cd_transportadora.Text,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    1,
                                                                                    string.Empty,
                                                                                    null);
                    if (lCtrc.Count > 0)
                        if (lCtrc[0].St_registro.Trim().ToUpper().Equals("C"))
                        {
                            if (MessageBox.Show("Conhecimento frete Nº" + nr_ctrc.Text.Trim() + " da transportadora " + cd_transportadora.Text.Trim() +
                                "-" + nm_transportadora.Text.Trim() + ",\r\nja existe no sistema com status <CANCELADO>.\r\n" +
                                "Deseja excluir o registro existente e reutilizar no numero?", "Pergunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                                try
                                {
                                    CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Excluir(lCtrc[0], null);
                                    MessageBox.Show("Conhecimento de frete excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro excluir conhecimento frete cancelado: " + ex.Message.Trim());
                                }
                            else
                            {
                                nr_ctrc.Clear();
                                nr_ctrc.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Conhecimento frete Nº" + nr_ctrc.Text.Trim() + " da transportadora " + cd_transportadora.Text.Trim() +
                                "-" + nm_transportadora.Text.Trim() + ",\r\nja existe no sistema com status <" + lCtrc[0].Status.Trim() + ">.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nr_ctrc.Clear();
                            nr_ctrc.Focus();
                        }
                }
        }

        private string BuscarEndereco(string Cd_clifor)
        {
            if (Cd_clifor.Trim() != string.Empty)
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_clifor,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                    return lEnd[0].Cd_endereco;
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        private void BuscarEmpresa(string Cnpj)
        {
            CamadaDados.Diversos.TList_CadEmpresa lEmp =
                           new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                               new TpBusca[]
                                       {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "b.nr_cgc",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cnpj.Trim() + "'"
                                            }
                                       }, 1, string.Empty);
            if (lEmp.Count > 0)
            {
                cd_empresa.Text = lEmp[0].Cd_empresa;
                nm_empresa.Text = lEmp[0].Nm_empresa;
            }
        }

        private void Cancelar()
        {
            pDados.LimparRegistro();
        }

        private void ImportarXml()
        {        
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Documentos XML|*.xml";
                op.InitialDirectory = "c:";
                op.Title = "Selecione XML NFe";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(op.FileName))
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(op.FileName);
                        XmlNodeList lNo = xml.GetElementsByTagName("infCte");
                        if (lNo.Count > 0)
                        {
                            chaveacesso.Text = lNo[0].Attributes.GetNamedItem("Id").Value.ToString().Remove(0, 3);
                            //Verificar se chave de acesso existe no banco
                            if (new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.ChaveAcesso",
                                        vOperador = "=",
                                        vVL_Busca = "'" + chaveacesso.Text.Trim() + "'"
                                    }
                                }, "1") != null)
                            {
                                MessageBox.Show("Chave de acesso " + chaveacesso.Text.Trim() + " ja se encontra cadastrada no sistema.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cancelar();
                                return;
                            }
                            if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_movimento.Equals("E"))
                                lNo = xml.GetElementsByTagName("dest");
                            else
                                lNo = xml.GetElementsByTagName("rem");
                        }
                        else
                        {
                            MessageBox.Show("XML Invalido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //Buscar Movimentação Comercial
                        bb_movimentacao_Click(this, new EventArgs());

                        #region Identificacao CTe
                        lNo = xml.GetElementsByTagName("ide");
                        //Identificacao da NFe
                        if (lNo.Count > 0)
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("mod"))
                                {
                                    cd_modelo.Text = no.InnerText;
                                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_modelo",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_modelo.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                                    {
                                        cd_modelo.ForeColor = Color.Red;
                                        St_modeloexiste = false;
                                    }
                                    else
                                    {
                                        cd_modelo.ForeColor = Color.Black;
                                        St_modeloexiste = true;
                                    }
                                }
                                else if (no.LocalName.Equals("serie"))
                                {
                                    nr_serie.Text = no.InnerText;
                                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_serie",
                                                vOperador = "=",
                                                vVL_Busca = "'" + nr_serie.Text.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_modelo",
                                                vOperador = "=",
                                                vVL_Busca = "'"+ cd_modelo.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                                    {
                                        try
                                        {
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(
                                                new CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF()
                                                {
                                                    Nr_Serie = nr_serie.Text.Trim(),
                                                    DS_SerieNf = "SÉRIE " + nr_serie.Text.Trim(),
                                                    CD_Modelo = cd_modelo.Text.Trim(),
                                                    ST_GeraSintegra = "S",
                                                    Tp_serie = "M",
                                                    ST_SequenciaAuto = "N"
                                                }, null);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                    else
                                    {
                                        nr_serie.ForeColor = Color.Black;
                                        St_serieexiste = true;
                                    }
                                }
                                else if (no.LocalName.Equals("nCT"))
                                    nr_ctrc.Text = no.InnerText;
                                else if (no.LocalName.Equals("dhEmi"))
                                    dt_emissao.Text = DateTime.Parse(no.InnerText).ToString("dd/MM/yyyy");
                                XmlNodeList x = xml.GetElementsByTagName("toma03");
                                if (x.Count > 0)
                                {
                                    foreach (XmlNode p in x[0].ChildNodes)
                                    {
                                        if (p.LocalName.Equals("toma"))
                                            tp_tomador.SelectedValue = p.InnerText;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Emitente
                        lNo = xml.GetElementsByTagName("emit");
                        if (lNo.Count > 0)
                        {
                            string cnpj = string.Empty;
                            string cpf = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CNPJ"))
                                    cnpj = no.FirstChild.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                                else if (no.LocalName.Equals("CPF"))
                                    cpf = no.FirstChild.InnerText.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                                else if (no.LocalName.Equals("xNome"))
                                    nm_transportadora.Text = no.InnerText;
                            }
                            //Buscar Emitente
                            CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cnpj.SoNumero()) ? string.Empty : cnpj,
                                                                                              string.IsNullOrEmpty(cpf.SoNumero()) ? string.Empty : cpf,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                            if (lFornec.Count > 0)
                            {
                                cd_transportadora.Text = lFornec[0].Cd_clifor;
                                cd_condfiscal_transp.Text = lFornec[0].Cd_condfiscal_clifor;
                                tp_pessoa.Text = lFornec[0].Tp_pessoa;
                                if (nm_transportadora.Text.Trim().ToUpper() != lFornec[0].Nm_clifor.Trim().ToUpper())
                                    nm_transportadora.ForeColor = Color.Red;
                            }
                        }
                        #endregion
                        #region Endereco Emitente
                        lNo = xml.GetElementsByTagName("enderEmit");
                        if (lNo.Count > 0)
                        {
                            string cep = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("xLgr"))
                                    ds_endtransportadora.Text = no.InnerText;
                                else if (no.LocalName.Equals("CEP"))
                                    cep = no.FirstChild.InnerText.Insert(2, ",").Insert(6, "-");
                            }
                            //Buscar endereco emitente
                            if (!string.IsNullOrEmpty(cd_transportadora.Text))
                            {
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_transportadora.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cep.SoNumero()) ? string.Empty : cep,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                                if (lEnd.Count > 0)
                                {
                                    cd_endtransportadora.Text = lEnd[0].Cd_endereco;
                                    if (ds_endtransportadora.Text.Trim().ToUpper() != lEnd[0].Ds_endereco.Trim().ToUpper())
                                        ds_endtransportadora.ForeColor = Color.Red;
                                    uf_transportadora.Text = lEnd[0].UF;
                                    cd_uf_transportadora.Text = lEnd[0].Cd_uf;
                                }
                            }
                        }
                        #endregion


                        #region Remetente
                        lNo = xml.GetElementsByTagName("rem");
                        if (lNo.Count > 0)
                        {
                            string cnpj = string.Empty;
                            string cpf = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CNPJ"))
                                    cnpj = no.FirstChild.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                                else if (no.LocalName.Equals("CPF"))
                                    cpf = no.FirstChild.InnerText.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                                else if (no.LocalName.Equals("xNome"))
                                    nm_remetente.Text = no.InnerText;
                            }
                            //Buscar Remetente
                            CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cnpj.SoNumero()) ? string.Empty : cnpj,
                                                                                              string.IsNullOrEmpty(cpf.SoNumero()) ? string.Empty : cpf,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                            if (lFornec.Count > 0)
                            {
                                cd_remetente.Text = lFornec[0].Cd_clifor;
                                if (nm_remetente.Text.Trim().ToUpper() != lFornec[0].Nm_clifor.Trim().ToUpper())
                                    nm_remetente.ForeColor = Color.Red;
                                BuscarImpostosNota();
                            }
                        }
                        #endregion
                        #region Endereco Remetente
                        lNo = xml.GetElementsByTagName("enderReme");
                        if (lNo.Count > 0)
                        {
                            string cep = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("xLgr"))
                                    ds_endremetente.Text = no.InnerText;
                                else if (no.LocalName.Equals("CEP"))
                                    cep = no.FirstChild.InnerText.Insert(2, ",").Insert(6, "-");
                            }
                            //Buscar endereco remetente
                            if (!string.IsNullOrEmpty(cd_remetente.Text))
                            {
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_remetente.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cep.SoNumero()) ? string.Empty : cep,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                                if (lEnd.Count > 0)
                                {
                                    cd_endremetente.Text = lEnd[0].Cd_endereco;
                                    if (ds_endremetente.Text.Trim().ToUpper() != lEnd[0].Ds_endereco.Trim().ToUpper())
                                        ds_endremetente.ForeColor = Color.Red;
                                    uf_remetente.Text = lEnd[0].UF;
                                    cd_uf_remetente.Text = lEnd[0].Cd_uf;
                                }
                            }
                        }
                        #endregion

                        #region Destinatário
                        lNo = xml.GetElementsByTagName("dest");
                        if (lNo.Count > 0)
                        {
                            string cnpj = string.Empty;
                            string cpf = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CNPJ"))
                                    cnpj = no.FirstChild.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                                else if (no.LocalName.Equals("CPF"))
                                    cpf = no.FirstChild.InnerText.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                                else if (no.LocalName.Equals("xNome"))
                                    nm_destinatario.Text = no.InnerText;
                            }
                            //Buscar Destinatario
                            CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cnpj.SoNumero()) ? string.Empty : cnpj,
                                                                                              string.IsNullOrEmpty(cpf.SoNumero()) ? string.Empty : cpf,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                            if (lFornec.Count > 0)
                            {
                                cd_destinatario.Text = lFornec[0].Cd_clifor;
                                if (nm_destinatario.Text.Trim().ToUpper() != lFornec[0].Nm_clifor.Trim().ToUpper())
                                    nm_destinatario.ForeColor = Color.Red;
                            }
                        }
                        #endregion
                        #region Endereco Destinatário
                        lNo = xml.GetElementsByTagName("enderDest");
                        if (lNo.Count > 0)
                        {
                            string cep = string.Empty;
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("xLgr"))
                                    ds_endtransportadora.Text = no.InnerText;
                                else if (no.LocalName.Equals("CEP"))
                                    cep = no.FirstChild.InnerText.Insert(2, ",").Insert(6, "-");
                            }
                            //Buscar endereco Destinatário
                            if (!string.IsNullOrEmpty(cd_destinatario.Text))
                            {
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_destinatario.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.IsNullOrEmpty(cep.SoNumero()) ? string.Empty : cep,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                                if (lEnd.Count > 0)
                                {
                                    cd_enddestinatario.Text = lEnd[0].Cd_endereco;
                                    if (ds_enddestinatario.Text.Trim().ToUpper() != lEnd[0].Ds_endereco.Trim().ToUpper())
                                        ds_enddestinatario.ForeColor = Color.Red;
                                    uf_destinatario.Text = lEnd[0].UF;
                                    cd_uf_destinatario.Text = lEnd[0].Cd_uf;
                                    cd_enddestinatario_Leave(this, new EventArgs());
                                }
                            }
                        }
                        #endregion


                        #region Total Frete
                        lNo = xml.GetElementsByTagName("vPrest");
                        if (lNo.Count > 0)
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("vTPrest"))
                                    vl_frete.Value = decimal.Parse(no.InnerText, new System.Globalization.CultureInfo("en-US"));
                            }
                        }
                        #endregion

                        #region Empresa
                        if (lNo.Count > 0)
                        {
                            lNo = xml.GetElementsByTagName("dest");
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CNPJ"))
                                {
                                    BuscarEmpresa(no.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-"));
                                    if (!string.IsNullOrEmpty(cd_empresa.Text))
                                    {
                                        (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_movimento = "E";
                                        tp_movimento_SelectedIndexChanged(this, new EventArgs());
                                    }
                                }
                            }
                            if (string.IsNullOrEmpty(cd_empresa.Text))
                            {
                                lNo = xml.GetElementsByTagName("rem");
                                foreach (XmlNode no in lNo[0].ChildNodes)
                                {
                                    if (no.LocalName.Equals("CNPJ"))
                                    {
                                        BuscarEmpresa(no.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-"));
                                        if (!string.IsNullOrEmpty(cd_empresa.Text))
                                        {
                                            (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_movimento = "S";
                                            tp_movimento_SelectedIndexChanged(this, new EventArgs());
                                        }
                                    }
                                }
                            }
                            if (string.IsNullOrEmpty(cd_empresa.Text))
                            {
                                MessageBox.Show("Não foi encontrado empresa cadastrada no sistema com este Cte!","Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Cancelar();
                                return;
                            }
                        }
                        #endregion

                        #region NF-e
                        lNo = xml.GetElementsByTagName("infDoc");
                        if (lNo.Count > 0)
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("infNFe"))
                                {
                                    foreach (XmlNode noF in no.ChildNodes)
                                    {
                                        if (noF.LocalName.Equals("chave"))
                                        {
                                            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                                                new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.chave_acesso_NFE",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + no.InnerText.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);

                                            if (lNf.Count > 0)
                                            {
                                                (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf.Add(lNf[0]);
                                                //Buscar Itens Faturamento
                                                (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf.ForEach(p =>
                                                    {
                                                        p.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(
                                                            p.Cd_empresa, p.Nr_lanctofiscalstr, 0, string.Empty, null);
                                                    });
                                            }
                                        }
                                    }
                                    bsCTRC.ResetCurrentItem();
                                }
                            }
                        }
                        #endregion
                    }
                    else
                        Cancelar();
                }
                else
                    Cancelar();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (linha != null)
                Cd_clifor_emp = linha["cd_clifor"].ToString();
            BuscarImpostosNota();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (linha != null)
                Cd_clifor_emp = linha["cd_clifor"].ToString();
            BuscarImpostosNota();
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                {
                    lblDtSaiEnt.Text = "Dt. Entrada";
                    if (!string.IsNullOrEmpty(Cd_clifor_emp))
                    {
                        cd_destinatario.Text = Cd_clifor_emp;
                        cd_destinatario_Leave(this, new EventArgs());
                    }
                }
                else if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                {
                    lblDtSaiEnt.Text = "Dt. Saida";
                    if (!string.IsNullOrEmpty(Cd_clifor_emp))
                    {
                        cd_remetente.Text = Cd_clifor_emp;
                        cd_remetente_Leave(this, new EventArgs());
                    }
                }
            BuscarCFOP();
            BuscarImpostosNota();
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "a.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80;" +
                              "b.DS_Modelo|Descrição Modelo|350";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serie, cd_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
            BuscarImpostosNota();
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vColunas += ";a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_serie, cd_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
            BuscarImpostosNota();
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|250;" +
                              "a.cd_movimentacao|Cd. Movimentação|80";
            string vParam = "a.tp_movimento|=|'E'";
            if(!string.IsNullOrEmpty(cd_cmi.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                            "           where x.cd_movimentacao = a.cd_movimentacao " +
                            "           and x.cd_cmi = " + cd_cmi.Text + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                                new CamadaDados.Fiscal.TCD_CadMovimentacao(), vParam);
            BuscarCFOP();
            BuscarImpostosNota();
            BuscarCMI();
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_movimentacao|=|" + cd_movimentacao.Text + ";" +
                              "a.tp_movimento|=|'E'";
            if (!string.IsNullOrEmpty(cd_cmi.Text))
                vColunas += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                            "           where x.cd_movimentacao = a.cd_movimentacao " +
                            "           and x.cd_cmi = " + cd_cmi.Text + ")";
                           
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                                new CamadaDados.Fiscal.TCD_CadMovimentacao());
            BuscarCFOP();
            BuscarImpostosNota();
            BuscarCMI();
        }

        private void bb_cmi_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CMI|Descrição CMI|200;" +
                              "a.CD_CMI|Cd. CMI|80";
            string vParam = string.Empty;
            if(!string.IsNullOrEmpty(cd_movimentacao.Text))
                vParam = "|exists|(select 1 from tb_fis_mov_x_cmi x " +
                         "           where x.cd_cmi = a.cd_cmi " +
                         "           and x.cd_movimentacao = " + cd_movimentacao.Text + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cmi, ds_cmi },
                                new CamadaDados.Fiscal.TCD_CadCMI(), vParam);
        
        }

        private void cd_cmi_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_cmi|=|" + cd_cmi.Text;
            if (!string.IsNullOrEmpty(cd_movimentacao.Text))
                vColunas += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                              "         where x.cd_cmi = a.cd_cmi " +
                              "         and x.cd_movimentacao = " + cd_movimentacao.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_cmi, ds_cmi },
                                    new CamadaDados.Fiscal.TCD_CadCMI());
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora, nm_transportadora, cd_condfiscal_transp, tp_pessoa },
                "isnull(a.ST_Transportadora, 'N')|=|'S'");
            VerificarCTRCExiste();
            BuscarImpostosNota();
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                              "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transportadora, nm_transportadora, cd_condfiscal_transp, tp_pessoa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            VerificarCTRCExiste();
            BuscarImpostosNota();
        }

        private void bb_endtransportadora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Cd. Endereço|80;" +
                              "b.ds_cidade|Cidade|150;" +
                              "a.UF|Estado|80;" +
                              "a.CD_UF|Cd. UF|80;" +
                              "a.fone|Fone|80";
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora, uf_transportadora, cd_uf_transportadora },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
            BuscarCFOP();
            VerificarCTRCExiste();
        }

        private void cd_endtransportadora_Enter(object sender, EventArgs e)
        {
            cd_endtransportadora.Text = BuscarEndereco(cd_transportadora.Text);
        }

        private void cd_endtransportadora_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                              "a.cd_endereco|=|'" + cd_endtransportadora.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora, uf_transportadora, cd_uf_transportadora },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            BuscarCFOP();
            VerificarCTRCExiste();
        }

        private void bb_remetente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100"
                , new Componentes.EditDefault[] { cd_remetente, nm_remetente },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
            BuscarImpostosNota();
        }

        private void cd_remetente_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_remetente, nm_remetente },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarImpostosNota();
        }

        private void bb_endremetente_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Cd. Endereço|80;" +
                              "b.ds_cidade|Cidade|150;" +
                              "a.UF|Estado|80;" +
                              "a.CD_UF|Cd. Estado|80;" +
                              "a.fone|Fone|80";
            string vParam = "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endremetente, ds_endremetente, uf_remetente, cd_uf_remetente },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
            BuscarCFOP();
        }

        private void cd_endremetente_Enter(object sender, EventArgs e)
        {
            cd_endremetente.Text = BuscarEndereco(cd_remetente.Text);
        }

        private void cd_endremetente_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "';" +
                              "a.cd_endereco|=|'" + cd_endremetente.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_endremetente, ds_endremetente, uf_remetente, cd_uf_remetente },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            BuscarCFOP();
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario, nm_destinatario }, string.Empty);
            BuscarImpostosNota();
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_destinatario, nm_destinatario },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarImpostosNota();
        }

        private void bb_enddestinatario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Cd. Endereço|80;" +
                              "b.ds_cidade|Cidade|150;" +
                              "a.UF|Estado|80;" +
                              "a.CD_UF|Cd. UF|80;" +
                              "a.fone|Fone|80";
            string vParam = "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, uf_destinatario, cd_uf_destinatario },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
            BuscarCFOP();
        }

        private void cd_enddestinatario_Enter(object sender, EventArgs e)
        {
            cd_enddestinatario.Text = BuscarEndereco(cd_destinatario.Text);
        }

        private void cd_enddestinatario_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "';" +
                              "a.cd_endereco|=|'" + cd_enddestinatario.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, uf_destinatario, cd_uf_destinatario },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            BuscarCFOP();
        }

        private void nr_ctrc_Leave(object sender, EventArgs e)
        {
            VerificarCTRCExiste();
        }

        private void dt_emissao_Leave(object sender, EventArgs e)
        {
            if (dt_saient.Text.Trim().Equals(string.Empty) || dt_saient.Text.Trim().Equals("/  /"))
                dt_saient.Text = dt_emissao.Text;
            BuscarImpostosNota();
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cfop, ds_cfop },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cfop|Descrição CFOP|200;" +
                              "a.cd_cfop|CFOP|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop, ds_cfop },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), string.Empty);
        }

        private void vl_frete_Leave(object sender, EventArgs e)
        {
            if (bsCTRC.Current != null)
                (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete = vl_frete.Value;
            BuscarImpostosNota();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            afterInserirNf();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            afterExcluirNf();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_impostonf_Click(object sender, EventArgs e)
        {
            //if (bsCTRC.Current != null)
            //    using(Fiscal.TFLan_Impostos fImpostos = new Fiscal.TFLan_Impostos())
            //    {
            //        fImpostos.Vl_TotalNota = (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete;
            //        fImpostos.bsImpostosNf.DataSource = (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos;
            //        fImpostos.ShowDialog();
            //        bsCTRC.ResetCurrentItem();
            //    }
        }

        private void TFConhecimentoFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                afterInserirNf();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                afterExcluirNf();
        }

        private void chaveacesso_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chaveacesso.Text))
            {
                if (chaveacesso.Text.Trim().Length != 44)
                {
                    MessageBox.Show("Chave de acesso deve conter 44 digitos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chaveacesso.Focus();
                    return;
                }
                //Modelo
                decimal modelo = decimal.Parse(chaveacesso.Text.Substring(20, 2));
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_modelo",
                            vOperador = "=",
                            vVL_Busca = "'" + modelo.ToString() + "'"
                        }
                    }, "1") == null)
                {
                    MessageBox.Show("Modelo " + modelo.ToString() + " não cadastrado no sistema.\r\n" +
                                    "Obrigatorio cadastrar modelo para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cd_modelo.Text = modelo.ToString();
                //Serie
                decimal serie = decimal.Parse(chaveacesso.Text.Substring(22, 3));
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_serie",
                            vOperador = "=",
                            vVL_Busca = "'" + serie.ToString() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_modelo",
                            vOperador = "=",
                            vVL_Busca = "'" + modelo.ToString() + "'"
                        }
                    }, "1") == null)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(
                            new CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF()
                            {
                                Nr_Serie = serie.ToString(),
                                DS_SerieNf = "SÉRIE " + serie.ToString(),
                                CD_Modelo = decimal.Parse(chaveacesso.Text.Substring(20, 2)).ToString(),
                                ST_GeraSintegra = "S",
                                Tp_serie = "M",
                                ST_SequenciaAuto = "N"
                            }, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                nr_serie.Text = serie.ToString();
                //Numero CTe
                nr_ctrc.Text = decimal.Parse(chaveacesso.Text.Substring(25, 9)).ToString();
                //Buscar Transportadora
                string cnpj = chaveacesso.Text.Substring(6, 14).Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                object transp = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_cgc",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cnpj.Trim() + "'"
                                        }
                                    }, "a.cd_clifor");
                if (transp != null)
                {
                    cd_transportadora.Text = transp.ToString();
                    cd_transportadora_Leave(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Não existe transportadora cadastrada no sistema com o CNPJ " + cnpj.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chaveacesso.Focus();
                }
            }
        }

        private void bb_addSerie_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(nr_serie.Text)) && (!St_serieexiste))
            {
                InputBox ibp = new InputBox();
                ibp.Text = "Serie Nota Fiscal";
                string ds_serie = ibp.ShowDialog();
                if (string.IsNullOrEmpty(ds_serie))
                {
                    MessageBox.Show("Obrigatorio informar descrição SERIE NOTA FISCAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF()
                        {
                            Nr_Serie = nr_serie.Text,
                            DS_SerieNf = ds_serie,
                            CD_Modelo = cd_modelo.Text,
                            ST_GeraSintegra = "S",
                            Tp_serie = "M",
                            ST_SequenciaAuto = "N"
                        }, null);
                    MessageBox.Show("Serie gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    St_serieexiste = true;
                    nr_serie.ForeColor = Color.Black;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_addTransportadora_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            //Transportadora
                            cd_transportadora.Text = fClifor.rClifor.Cd_clifor;
                            //Endereco
                            cd_endtransportadora.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;

                            MessageBox.Show("Fornecedor gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}

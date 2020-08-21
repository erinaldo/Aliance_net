using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using System.IO;

namespace Servicos
{
    public partial class TFLanAtividades : Form
    {
        public TFLanAtividades()
        {
            InitializeComponent();
        }

        private string cd_tecnico
        { get; set; }

        private void afterNovo()
        {
            using (TFAtividade fAtividade = new TFAtividade())
            {
                if (bsAtividade.Current != null)
                {
                    fAtividade.vId_os = (bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades).Id_osstr;
                    fAtividade.vId_evolucao = (bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades).Id_evolucaostr;
                    fAtividade.vCd_empresa = (bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades).Cd_empresa;
                }
                fAtividade.vCd_tecnico = cd_tecnico;
                if (fAtividade.ShowDialog() == DialogResult.OK)
                    if (fAtividade.rAtividade != null)
                        try
                        {
                            //Verificar se existe etapa 
                            fAtividade.rAtividade.Login = Utils.Parametros.pubLogin;
                            CamadaNegocio.Servicos.TCN_LanAtividades.Gravar(fAtividade.rAtividade, null);
                            if (new CamadaDados.Servicos.TCD_LanServicoEvolucao().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.ID_OS",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Id_osstr.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_evolucao",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Id_evolucaostr.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                             vNM_Campo = "a.st_evolucao",
                                            vOperador = "=",
                                            vVL_Busca = "'E'"
                                        }
                                    }, "1") != null)
                            {
                                //Buscar Evolução Projeto
                                CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Buscar(fAtividade.rAtividade.Id_osstr,
                                                                                     fAtividade.rAtividade.Cd_empresa,
                                                                                     fAtividade.rAtividade.Id_evolucaostr,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     1,
                                                                                     null).ForEach(p=> 
                                                                                         {
                                                                                            p.St_evolucao = "A";
                                                                                            p.Dt_final = null;
                                                                                            TCN_LanServicoEvolucao.Gravar(p, null);
                                                                                         });
                                //Verificar se Projeto está finalizado
                                if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.ID_OS",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Id_osstr.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                             vNM_Campo = "a.st_os",
                                            vOperador = "=",
                                            vVL_Busca = "'FE'"
                                        }
                                    }, "1") != null)
                                {
                                    new CamadaDados.Servicos.TCD_LanServico().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.ID_OS",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fAtividade.rAtividade.Id_osstr.Trim() + "'"
                                        }
                                        }, 1, string.Empty, string.Empty).ForEach(p =>
                                                                                {
                                                                                    p.St_os = "AB";
                                                                                    p.Dt_finalizada = null;
                                                                                    TCN_LanServico.Gravar(p, null);
                                                                                });
                                }

                            }
                            MessageBox.Show("Atividade gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(cd_tecnico) || Utils.Parametros.pubLogin.ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.ToUpper().Equals("DESENV"))
            {
                string status = string.Empty;
                string virg = string.Empty;
                if (ST_OS_Pendente.Checked)
                {
                    status = "'P'";
                    virg = ",";
                }
                if (ST_OS_Concluida.Checked)
                    status += virg + "'C'";
                bsAtividade.DataSource = TCN_LanAtividades.Buscar(id_projetobusca.Text,
                                                                  CD_Empresa.Text,
                                                                  string.Empty,
                                                                  id_etapa.Text,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  Utils.Parametros.pubLogin.ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.ToUpper().Equals("DESENV") ? string.Empty : cd_tecnico,
                                                                  rbAtividade.Checked ? "A" : "C",
                                                                  DT_Inic.Text,
                                                                  DT_Final.Text,
                                                                  status,
                                                                  null);
                bsAtividade_PositionChanged(this, new EventArgs());
                bsAtividade.ResetCurrentItem();
            }
        }

        private void BuscarPendentes()
        {
            //Busca Atividades Pendentes do Usuario Logado
            bsAtividade.DataSource =
                new TCD_LanAtividades().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_clifor x " +
                                          "where a.CD_Tecnico = x.CD_Clifor " +
                                          "and x.LoginVendedor = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        }
                    }, 0, string.Empty);
            //Buscar CD.Tecnico do Usuario
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.LoginVendedor",
                        vOperador = "=",
                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                    }
                }, "a.cd_clifor");
            if (obj != null)
                cd_tecnico = obj.ToString();
            else
                cd_tecnico = string.Empty;
            bsAtividade.ResetCurrentItem();
        }

        private void Finalizar()
        {
            if (bsAtividade.Current != null)
            {
                if ((bsAtividade.Current as TRegistro_LanAtividades).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido Finalizar Atividade CONCLUÍDA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja finalizar esta Atividade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        //Inserir QTD Horas Trabalhadas
                        using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
                        {
                            fQtde.Ds_label = "Horas Trabalhadas";
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(fQtde.pHoras))
                                    (bsAtividade.Current as TRegistro_LanAtividades).Horas_trabalhadas = Convert.ToDecimal(fQtde.pHoras.Replace(":", ","));
                            }
                        }
                        TCN_LanAtividades.Finalizar(bsAtividade.Current as TRegistro_LanAtividades, null);
                        MessageBox.Show("Atividade Finalizada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void AlterarAtividade()
        {
            if (bsAtividade.Current != null)
            {
                if ((bsAtividade.Current as TRegistro_LanAtividades).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido Alterar Atividade CONCLUÍDA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFTarefa fTarefa = new TFTarefa())
                {
                    fTarefa.St_Bloqueio = true;
                    fTarefa.rAtividade = (bsAtividade.Current as TRegistro_LanAtividades);
                    if (fTarefa.ShowDialog() == DialogResult.OK)
                        if (fTarefa.rAtividade != null)
                            try
                            {
                                CamadaNegocio.Servicos.TCN_LanAtividades.Gravar(fTarefa.rAtividade, null);
                                MessageBox.Show("Atividade Alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void TFLanAtividades_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.ShapeGrid.RestoreShape(this, gAtividades);
            cliente.Text = string.Empty;
            endereco.Text = string.Empty;
            cpf_cnpj.Text = string.Empty;
            fone.Text = string.Empty;
            this.BuscarPendentes();
        }

        private void TFLanAtividades_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAtividades);
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
            {
                //Buscar Etapa da Atividade
                etapa.Text =
                    new TCD_LanServicoEvolucao().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsAtividade.Current as TRegistro_LanAtividades).Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_os",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsAtividade.Current as TRegistro_LanAtividades).Id_osstr.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_evolucao",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsAtividade.Current as TRegistro_LanAtividades).Id_evolucaostr.Trim() + "'"
                            }
                        }, "a.ds_evolucao").ToString();

                //Buscar Projeto da Atividade
                TList_LanServico lProjeto =
                    new TCD_LanServico().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsAtividade.Current as TRegistro_LanAtividades).Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsAtividade.Current as TRegistro_LanAtividades).Id_osstr.Trim() + "'"
                        }
                    }, 0, string.Empty, string.Empty);
                if (lProjeto.Count > 0)
                {
                    id_projeto.Text = "Nº " + lProjeto[0].Id_osstr + (!string.IsNullOrEmpty(lProjeto[0].Ds_servico) ? " - " + lProjeto[0].Ds_servico.ToUpper().Trim() : string.Empty);
                    cliente.Text = lProjeto[0].Cd_clifor.ToUpper().Trim() + "-" + lProjeto[0].Nm_clifor.ToUpper().Trim();
                    endereco.Text = lProjeto[0].Ds_endereco.ToUpper().Trim() + "  " + lProjeto[0].Numero.ToUpper().Trim() + " - "+
                        lProjeto[0].Bairro.ToUpper().Trim() + " - " + lProjeto[0].Ds_cidade.ToUpper().Trim()
                        ;
                    cpf_cnpj.Text = lProjeto[0].Nr_cnpj_cpf.ToUpper().Trim();
                    fone.Text = lProjeto[0].Fone.ToUpper().Trim()  ;
                }
                //Alinhar Atividade
                atividade.Text = (bsAtividade.Current as TRegistro_LanAtividades).Ds_atividade.Trim();


                //Buscar Anexos
                bsAnexo.DataSource =
                    CamadaNegocio.Servicos.Cadastros.TCN_Imagens.Buscar((bsAtividade.Current as TRegistro_LanAtividades).Id_osstr,
                                                                        (bsAtividade.Current as TRegistro_LanAtividades).Cd_empresa,
                                                                         null);
                lView.Clear();
                bsAnexo_PositionChanged(this, new EventArgs());
                bsAtividade.ResetCurrentItem();
            }
            else
            {
                bsAnexo.DataSource = null;
                lView.Clear();
                atividade.Text = string.Empty;
                id_projeto.Text = string.Empty;
                cliente.Text = string.Empty;
                etapa.Text = string.Empty;
                endereco.Text = string.Empty;
                cpf_cnpj.Text = string.Empty;
                fone.Text = string.Empty;
            }
        }

        private void InserirPath()
        {
            if (bsAtividade.Current != null)
            {
                try
                {
                    using (FolderBrowserDialog fFile = new FolderBrowserDialog())
                    {
                        if (fFile.ShowDialog() == DialogResult.OK)
                            if (!string.IsNullOrEmpty(fFile.SelectedPath))
                            {
                                //Gravar Imagem
                                CamadaNegocio.Servicos.Cadastros.TCN_Imagens.Gravar(new CamadaDados.Servicos.Cadastros.TRegistro_Imagens()
                                {
                                    Id_osstr = (bsAtividade.Current as TRegistro_LanAtividades).Id_osstr,
                                    Cd_empresa = (bsAtividade.Current as TRegistro_LanAtividades).Cd_empresa,
                                    Ds_imagem = fFile.SelectedPath.Trim()
                                }, null);
                                MessageBox.Show("Path Anexo gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsAtividade_PositionChanged(this, new EventArgs());
                                bsAtividade.ResetCurrentItem();
                            }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro localizar anexo: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ExcluirAnexo()
        {
            if (bsAtividade.Current != null)
            {
                if (bsAnexo.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar Path para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Path selecionado: " + (bsAnexo.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Id_imagemstr.Trim() + "-" +
                                                                (bsAnexo.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    CamadaNegocio.Servicos.Cadastros.TCN_Imagens.Excluir(
                        bsAnexo.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens, null);
                    bsAnexo.RemoveCurrent();
                    lView.Clear();
                    bsAtividade.ResetCurrentItem();
                    MessageBox.Show("Path Anexo excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.Finalizar();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.AlterarAtividade();
        }

        private void TFLanAtividades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.AlterarAtividade();
            else if (e.KeyCode.Equals(Keys.F4))
                this.Finalizar();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (tcDetalhes.SelectedTab.Equals(tpAnexos) && e.KeyCode.Equals(Keys.Right))
                this.InserirPath();
            else if (tcDetalhes.SelectedTab.Equals(tpAnexos) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirAnexo();
        }

        private void id_etapa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_etapa|=|" + id_etapa.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_etapa },
                                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem());
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_etapa|Descrição Etapa|200;" +
                             "a.id_etapa|Id. Etapa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_etapa },
                                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void gAtividades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CONCLUÍDA"))
                        gAtividades.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gAtividades.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void gAtividades_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAtividades.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAtividade.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Servicos.TRegistro_LanAtividades());
            CamadaDados.Servicos.TList_LanAtividades lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAtividades.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAtividades.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Servicos.TList_LanAtividades(lP.Find(gAtividades.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAtividades.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Servicos.TList_LanAtividades(lP.Find(gAtividades.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAtividades.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAtividade.List as CamadaDados.Servicos.TList_LanAtividades).Sort(lComparer);
            bsAtividade.ResetBindings(false);
            gAtividades.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gAtividades_DoubleClick(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
            {
                using (TFTarefa fTarefa = new TFTarefa())
                    try
                    {
                        fTarefa.St_visualizar = true;
                        fTarefa.Size = new Size(736, 340 - 43);
                        fTarefa.rAtividade = bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades;
                        fTarefa.ShowDialog();
                    }
                    finally
                    {
                        fTarefa.Dispose();
                    }
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_inserirCaminho_Click(object sender, EventArgs e)
        {
            this.InserirPath();
        }

        private void bb_excluirCaminho_Click(object sender, EventArgs e)
        {
            this.ExcluirAnexo();
        }

        private void bsAnexo_PositionChanged(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null)
            {
                lView.Clear();
                //Marca o diretório a ser listado
                DirectoryInfo diretorio = new DirectoryInfo((bsAnexo.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim());
                //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
                FileInfo[] Arquivos = diretorio.GetFiles("*.*");

                //Começamos a listar os arquivos
                foreach (FileInfo fileinfo in Arquivos)
                {
                    lView.Items.Add(fileinfo.ToString());
                }
                bsAnexo.ResetCurrentItem();
            }
        }

        private void lView_DoubleClick(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null && lView.Items.Count > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start((bsAnexo.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() + "\\" +
                        lView.FocusedItem.Text);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void panelDados2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

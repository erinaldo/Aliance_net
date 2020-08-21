using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aliance.NET
{
    public partial class TFDetalhe : Form
    {
        private System.Timers.Timer tempo;

        private bool Altera_Relatorio = false;
        public bool St_Detalhe_fin
        { get; set; }
        public bool St_Detalhe_Fat
        { get; set; }
        public bool St_Detalhe_Est
        { get; set; }

        private decimal Tot_pedidoecommerce = decimal.Zero;

        public TFDetalhe()
        {
            InitializeComponent();
            tempo = new System.Timers.Timer();
            tempo.SynchronizingObject = this;
            tempo.Elapsed += new System.Timers.ElapsedEventHandler(tempo_Elapsed);
        }

        void tempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tempo.Enabled = false;
            try
            {
                this.DetalhesPedidoECommerce();
                if (Tot_pedidoecommerce < qtd_pedecommerce.Value)
                    toolTip1.Show("Novo(s) pedidos E-commerce sincronizados com o sistema.",
                                                          qtd_pedecommerce, 10000);
                Tot_pedidoecommerce = qtd_pedecommerce.Value;
            }
            finally
            {
                tempo.Enabled = true;
            }
        }

        private void ImprimirDetalhesCRHoje()
        {
            //Buscar parcelas
            BindingSource bsParcelas = new BindingSource();
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarParc(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "year(a.DT_Vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "year(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "month(a.dt_vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "month(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "day(a.dt_vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "day(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(b.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }
                                        });
            //Chamar tela de impressao relatorio
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if(Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsParcelas;
                Rel.Nome_Relatorio = "TFLanContas_Parcelas_Contas_Receber_Hoje";
                Rel.Ident = "TFLanContas_Parcelas_Contas_Receber_Hoje";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CONTAS À RECEBER HOJE";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS À RECEBER HOJE ",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS À RECEBER HOJE ",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesCRAtraso()
        {
            //Buscar parcelas
            BindingSource bsParcelas = new BindingSource();
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarParc(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                                                vOperador = "<",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(b.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }
                                        });


            //Chamar tela de impressao relatorio
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsParcelas;
                Rel.Nome_Relatorio = "TFLanContas_Parcelas_Contas_Receber_Em_Atrazo";
                Rel.Ident = "TFLanContas_Parcelas_Contas_Receber_Em_Atrazo";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CONTAS A RECEBER EM ATRASO";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A RECEBER EM ATRASO",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A RECEBER EM ATRASO ",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesCPHoje()
        {
            //Buscar parcelas
            BindingSource bsParcelas = new BindingSource();
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarParc(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'P'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "year(a.DT_Vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "year(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "month(a.dt_vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "month(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "day(a.dt_vencto)",
                                                vOperador = "=",
                                                vVL_Busca = "day(getdate())"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(b.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }
                                        });

            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsParcelas;
                Rel.Nome_Relatorio = "TFLanContas_Parcelas_Contas_Pagar_Hoje";
                Rel.Ident = "TFLanContas_Parcelas_Contas_Receber_Pagar_Hoje";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CONTAS A PAGAR HOJE";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A PAGAR HOJE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A PAGAR HOJE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesCPAtraso()
        {
            //Buscar parcelas
            BindingSource bsParcelas = new BindingSource();
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarParc(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'P'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                                                vOperador = "<",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(b.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }    
                                        });


            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsParcelas;
                Rel.Nome_Relatorio = "TFLanContas_Parcelas_Contas_Pagar_Em_Atrazo";
                Rel.Ident = "TFLanContas_Parcelas_Contas_Pagar_Em_Atrazo";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CONTAS A PAGAR EM ATRASO";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A PAGAR EM ATRASO",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CONTAS A PAGAR EM ATRASO ",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesCHPagar()
        {
            //Buscar parcelas
            BindingSource bsTitulo = new BindingSource();
            bsTitulo.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_titulo",
                                                vOperador = "=",
                                                vVL_Busca = "'P'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'" 
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.Status_Compensado, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'N'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }
                                        }, 0, string.Empty, string.Empty);

            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsTitulo;
                Rel.Nome_Relatorio = "TFConsultaTitulo_Cheques_Pagar_Compensar";
                Rel.Ident = "TFConsultaTitulo_Cheques_Pagar_Compensar";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CHEQUES PAGAR A COMPENSAR";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CHEQUES PAGAR A COMPENSAR",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CHEQUES PAGAR A COMPENSAR",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesCHReceber()
        {
            //Buscar parcelas
            BindingSource bsTitulo = new BindingSource();
            bsTitulo.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_titulo",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'" 
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.Status_Compensado, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'N'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            }
                                        }, 0, string.Empty, string.Empty);

            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsTitulo;
                Rel.Nome_Relatorio = "TFConsultaTitulo_Cheques_Receber_Compensar";
                Rel.Ident = "TFConsultaTitulo_Cheques_Receber_Compensar";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE CHEQUES RECEBER A COMPENSAR";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CHEQUES RECEBER A COMPENSAR",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE CHEQUES RECEBER A COMPENSAR",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void totalizarDetalhesFin()
        {
            #region "Totalizar contas receber hoje"
            tot_receberhoje.Value = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "t.tp_mov",
                    vOperador = "=",
                    vVL_Busca = "'R'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "year(a.DT_Vencto)",
                    vOperador = "=",
                    vVL_Busca = "year(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "month(a.dt_vencto)",
                    vOperador = "=",
                    vVL_Busca = "month(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "day(a.dt_vencto)",
                    vOperador = "=",
                    vVL_Busca = "day(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.st_registro, 'A')",
                    vOperador = "in",
                    vVL_Busca = "('A', 'P')"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(d.st_registro, 'A')",
                    vOperador = "=",
                    vVL_Busca = "'A'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, 0, string.Empty).Sum(p => p.Vl_atual);
            #endregion

            #region "Totalizar contas receber atraso"
            tot_rec_atraso.Value = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "t.tp_mov",
                    vOperador = "=",
                    vVL_Busca = "'R'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                    vOperador = "<",
                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd")) + "'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.st_registro, 'A')",
                    vOperador = "in",
                    vVL_Busca = "('A', 'P')"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(d.st_registro, 'A')",
                    vOperador = "=",
                    vVL_Busca = "'A'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, 0, string.Empty).Sum(p => p.Vl_atual);
            #endregion

            #region "Totalizar contas pagar hoje"
            tot_pagar_hoje.Value = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "t.tp_mov",
                    vOperador = "=",
                    vVL_Busca = "'P'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "year(a.DT_Vencto)",
                    vOperador = "=",
                    vVL_Busca = "year(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "month(a.dt_vencto)",
                    vOperador = "=",
                    vVL_Busca = "month(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "day(a.dt_vencto)",
                    vOperador = "=",
                    vVL_Busca = "day(getdate())"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.st_registro, 'A')",
                    vOperador = "in",
                    vVL_Busca = "('A', 'P')"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(d.st_registro, 'A')",
                    vOperador = "=",
                    vVL_Busca = "'A'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, 0, string.Empty).Sum(p=>p.Vl_atual);
            #endregion

            #region "Totalizar contas pagar atraso"
            tot_pagar_atraso.Value = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "t.tp_mov",
                    vOperador = "=",
                    vVL_Busca = "'P'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                    vOperador = "<",
                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.st_registro, 'A')",
                    vOperador = "in",
                    vVL_Busca = "('A', 'P')"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(d.st_registro, 'A')",
                    vOperador = "=",
                    vVL_Busca = "'A'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, 0, string.Empty).Sum(p => p.Vl_atual);
            #endregion

            #region "Totalizar cheques pagar para compensar"
            object obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.tp_titulo",
                    vOperador = "=",
                    vVL_Busca = "'P'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                    vOperador = "<=",
                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + " 23:59:59'" 
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.Status_Compensado, 'N')",
                    vOperador = "=",
                    vVL_Busca = "'N'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, "sum(isnull(a.vl_titulo, 0))");
            if (obj != null)
                try
                {
                    decimal aux = Convert.ToDecimal(obj.ToString());
                    tot_ch_emit_compensar.Value = aux;
                }
                catch { }
            #endregion

            #region "Totalizar cheques receber para compensar"
            obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.tp_titulo",
                    vOperador = "=",
                    vVL_Busca = "'R'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))",
                    vOperador = "<=",
                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.Date.ToString("yyyyMMdd")) + "'" 
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "isnull(a.Status_Compensado, 'N')",
                    vOperador = "=",
                    vVL_Busca = "'N'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                }
            }, "sum(a.vl_titulo)");
            if (obj != null)
                try
                {
                    tot_ch_rec_compensar.Value = Convert.ToDecimal(obj.ToString());
                }
                catch { }
            #endregion

            #region "Quantidade de cobrancas agendadas para data atual"
            obj = new CamadaDados.Financeiro.Cobranca.TCD_CobrancaClifor().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.dt_agendamento)))",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.ToString("yyyyMMdd")) + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.dt_agendamento)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), DateTime.Now.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }, "count(a.id_cobranca)");
            if(obj != null)
                try
                {
                    qtd_cobrancas.Value = Convert.ToDecimal(obj.ToString());
                }
                catch
                { }
            #endregion
        }

        private void DetalhesFaturamento()
        {
            //Quantide de Orcamentos
            object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_pedido, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, "count(a.nr_pedido) as qtd_orcamento");
            if (obj != null)
                try
                {
                    qtd_orcamento.Value = Convert.ToDecimal(obj.ToString());
                }
                catch { qtd_orcamento.Value = 0; }
            //Quantidade de Pedidos Fechados
            obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_pedido, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'F'"
                    }
                }, "count(a.nr_pedido) as qtd_pedido");
            if (obj != null)
                try
                {
                    qtd_ped_fechado.Value = Convert.ToDecimal(obj.ToString());
                }
                catch { qtd_orcamento.Value = 0; }
            this.DetalhesPedidoECommerce();
        }

        private void DetalhesPedidoECommerce()
        {
            //Quantidade de Pedidos ECommerce
            object obj = new CamadaDados.Faturamento.PrePedido.TCD_LanPrePedido().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, "count(a.id_prepedido)");
            if (obj != null)
                try
                {
                    qtd_pedecommerce.Value = Convert.ToDecimal(obj.ToString());
                }
                catch { qtd_pedecommerce.Value = 0; }
        }

        private void ImprimirDetalhesEstoque()
        {
            //Buscar estoque
            BindingSource bsEstoque = new BindingSource();
            bsEstoque.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Buscar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(c.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(c.st_kit, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'N'"
                                            }
                                        }, 0, "a.cd_empresa, b.nm_empresa, a.cd_produto, c.ds_produto, f.sigla_unidade, c.qt_min_estoque, " +
                             "sum(isnull(a.qtd_entrada, 0)) as qtd_entrada, sum(isnull(a.qtd_saida, 0)) as qtd_saida, " +
                             "sum(isnull(a.qtd_entrada, 0)) - sum(isnull(a.qtd_saida, 0)) as saldo ", 
                             "a.cd_empresa, b.nm_empresa, a.cd_produto, c.ds_produto, f.sigla_unidade, c.qt_min_estoque " +
                             "\r\nhaving (c.qt_min_estoque > (sum(isnull(a.qtd_entrada, 0)) - sum(isnull(a.qtd_saida, 0))))", 
                             "a.cd_empresa, a.cd_produto", null);

           

            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsEstoque;
                Rel.Nome_Relatorio = "TFConsulta_Estoque_Prod_Abaixo_Minimo";
                Rel.Ident = "TFConsulta_Estoque_Prod_Abaixo_Minimo";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "EST";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE PRODUTOS COM SALDO ABAIXO DO MINIMO";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE PRODUTOS COM SALDO ABAIXO DO MINIMO",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE PRODUTOS COM SALDO ABAIXO DO MINIMO",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void ImprimirDetalhesPedidoECommerce()
        {
            //Buscar Pedidos ECommerce
            CamadaDados.Faturamento.PrePedido.TList_RegLanPrePedido lPedECommerce = new CamadaDados.Faturamento.PrePedido.TCD_LanPrePedido().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 0, string.Empty);
            //Buscar itens do pedidos
            lPedECommerce.ForEach(p => p.List_PrePedido_Itens = new CamadaDados.Faturamento.PrePedido.TCD_LanPrePedido_Itens().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_prepedido",
                            vOperador = "=",
                            vVL_Busca = p.ID_PrePedido.ToString()
                        }
                    }, 0, string.Empty));

            BindingSource bsECommerce = new BindingSource();
            bsECommerce.DataSource = lPedECommerce;

            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                if (Ck_Altera_Rel.Checked)
                    Rel.Altera_Relatorio = true;
                else
                    Rel.Altera_Relatorio = false;
                Rel.DTS_Relatorio = bsECommerce;
                Rel.Nome_Relatorio = "TFRel_PedidoECommerce";
                Rel.Ident = "TFRel_PedidoECommerce";
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FAT";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE PEDIDOS E-COMMERCE";

                if (Rel.Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE PEDIDOS E-COMMERCE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Rel.Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO DE PEDIDOS E-COMMERCE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void DetalhesEstoque()
        {
            //Produtos com quantidade abaixo do minimo
            object obj = new CamadaDados.Estoque.TCD_LanEstoque().BuscarSaldo_EstoqueEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "b.qt_min_estoque",
                        vOperador = ">",
                        vVL_Busca = "0"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(b.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "(b.qt_min_estoque > a.tot_saldo)"
                    }
                }, "count(a.cd_produto)");
            if(obj != null)
                try
                {
                    qtd_estoque_minimo.Value = Convert.ToDecimal(obj.ToString());
                }
                catch
                { qtd_estoque_minimo.Value = 0; }
        }

        private void TFDetalhe_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void TFDetalhe_Load(object sender, EventArgs e)
        {
            pFinanceiro.Visible = St_Detalhe_fin;
            pDetalhe_Est.Visible = St_Detalhe_Est;
            pDetalhe_Fat.Visible = St_Detalhe_Fat;
            //if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
            //    Idioma.TIdioma.AjustaCultura(this);
            if(St_Detalhe_fin)
                this.totalizarDetalhesFin();
            if (St_Detalhe_Fat)
            {
                this.DetalhesFaturamento();
                Tot_pedidoecommerce = qtd_pedecommerce.Value;
                //Verificar se existe o parametro intervalo TMP_PREPEDIDO
                CamadaDados.ConfigGer.TList_RegParamGer parametros =
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscarParametros("'TMP_PREPEDIDO'", null);
                if (parametros.Count > 0)
                    tempo.Interval = Convert.ToDouble(parametros[0].Vl_numerico > 0 ? parametros[0].Vl_numerico * 60000 : 5 * 60000);
                else
                {
                    //Gravar parametro no banco
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(
                        new CamadaDados.ConfigGer.TRegistro_ParamGer()
                        {
                            Id_parametro = 0,
                            Ds_finalidade = "INTERVALO VERIFICAR EXISTENCIA NOVO PEDIDO E-COMMERCE",
                            Ds_parametro = "TMP_PREPEDIDO",
                            Tp_dado = "N",
                            Vl_numerico = 5
                        }, null);
                    tempo.Interval = Convert.ToDouble(5 * 60000);
                }
                tempo.Enabled = true;
            }
            if (St_Detalhe_Est)
                this.DetalhesEstoque();

            //mostrar check box para quando o usuario for MASTER poder alterar os relatorios do menudetalhe
            if (Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER"))
                Ck_Altera_Rel.Visible = true;
            else
                Ck_Altera_Rel.Visible = false;
        }

        private void BB_Refresh_Click(object sender, EventArgs e)
        {
            this.totalizarDetalhesFin();
        }

        private void BB_Refresh_Fat_Click(object sender, EventArgs e)
        {
            this.DetalhesFaturamento();
        }

        private void BB_Detalhe_Est_Click(object sender, EventArgs e)
        {
            this.DetalhesEstoque();
        }

        private void BB_DetalheCRHoje_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCRHoje();
        }

        private void BB_DetalheCRAtraso_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCRAtraso();
        }

        private void BB_DetalheCPHoje_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCPHoje();
        }

        private void BB_DetalheCPAtraso_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCPAtraso();
        }

        private void BB_DetalheCHPHoje_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCHPagar();
        }

        private void BB_DetalheCHRHoje_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesCHReceber();
        }

        private void BB_DetalheProdMin_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesEstoque();
        }

        private void TFDetalhe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o Relatório que deseja Alterar!", "Mensagem");
            }
        }

        private void BB_PedidoECommerce_Click(object sender, EventArgs e)
        {
            this.ImprimirDetalhesPedidoECommerce();
        }
    }
}

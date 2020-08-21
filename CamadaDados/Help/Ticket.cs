using System;
using System.Collections.Generic;

namespace CamadaDados.Help
{
    public class TList_Ticket:List<Ticket>, IComparer<Ticket>
    {
        #region IComparer<TRegistro_CfgFrota> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Ticket()
        { }

        public TList_Ticket(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(Ticket value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(Ticket x, Ticket y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }
    public class Ticket
    {
        private decimal? _id_ticket;
        public decimal? Id_ticket
        {
            get { return _id_ticket; }
            set
            {
                if (_id_ticket != value)
                    _id_ticket = value;
            }
        }
        private string _logincliente;
        public string Logincliente
        {
            get { return _logincliente; }
            set
            {
                if (_logincliente != value)
                    _logincliente = value;
            }
        }
        private decimal? _id_cliente;
        public decimal? Id_cliente
        {
            get { return _id_cliente; }
            set
            {
                if (_id_cliente != value)
                    _id_cliente = value;
            }
        }
        private string _nm_cliente;
        public string Nm_cliente
        {
            get { return _nm_cliente; }
            set
            {
                if (_nm_cliente != value)
                    _nm_cliente = value;
            }
        }
        private string _st_prioridade;
        public string St_prioridade
        {
            get { return _st_prioridade; }
            set
            {
                if (_st_prioridade != value)
                    _st_prioridade = value;
            }
        }
        public string Prioridade
        {
            get
            {
                if (_st_prioridade.Trim().Equals("0"))
                    return "BAIXA";
                else if (_st_prioridade.Trim().Equals("1"))
                    return "MÉDIA";
                else if (_st_prioridade.Trim().Equals("2"))
                    return "ALTA";
                else return string.Empty;
            }
        }
        private string _ds_assunto;
        public string Ds_assunto
        {
            get { return _ds_assunto; }
            set
            {
                if (_ds_assunto != value)
                    _ds_assunto = value;
            }
        }
        private string _ds_historico;
        public string Ds_historico
        {
            get { return _ds_historico; }
            set
            {
                if (_ds_historico != value)
                    _ds_historico = value;
            }
        }
        private DateTime? _dt_abertura = DateTime.Now;
        public DateTime? Dt_abertura
        {
            get { return _dt_abertura; }
            set
            {
                if (_dt_abertura != value)
                    _dt_abertura = value;
            }
        }
        private DateTime? _dt_concluido;
        public DateTime? Dt_concluido
        {
            get { return _dt_concluido; }
            set
            {
                if (_dt_concluido != value)
                    _dt_concluido = value;
            }
        }
        private DateTime? _dt_encerrado;
        public DateTime? Dt_encerrado
        {
            get { return _dt_encerrado; }
            set
            {
                if (_dt_encerrado != value)
                    _dt_encerrado = value;
            }
        }
        private string _st_registro = "A";
        public string St_registro
        {
            get { return _st_registro; }
            set
            {
                if (_st_registro != value)
                    _st_registro = value;
            }
        }
        public string Status
        {
            get
            {
                if (_st_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (_st_registro.Trim().ToUpper().Equals("L"))
                    return "CONCLUIDO";
                else if (_st_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADO";
                else if (_st_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        private List<Anexo> _lAnexo = new List<Anexo>();
        public List<Anexo> lAnexo
        {
            get { return _lAnexo; }
            set
            {
                if (_lAnexo != value)
                    _lAnexo = value;
            }
        }
        private List<Evolucao> _lEvolucao = new List<Evolucao>();
        public List<Evolucao> lEvolucao
        {
            get { return _lEvolucao; }
            set
            {
                if (_lEvolucao != value)
                    _lEvolucao = value;
            }
        }
        private List<HistEvolucao> _lhist;
        public List<HistEvolucao> lHist
        {
            get { return _lhist; }
            set
            {
                if (_lhist != value)
                    _lhist = value;
            }
        }
    }
}

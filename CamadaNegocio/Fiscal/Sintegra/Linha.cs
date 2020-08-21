using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class Linha
    {
        #region "Atributos"
        private string mValue;
        #endregion

        #region "Construtores"
        private Linha(string value)
        {
            this.mValue = value;
        }
        #endregion

        #region Operadores

        public static implicit operator Linha(string x)
        {
            return new Linha(x);
        }

        /// <summary>
        /// Operador de igualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(Linha x, Linha y)
        {
            return x.Equals(y);

        }

        /// <summary>
        /// Operador de atribuição
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static String operator +(Linha x, Linha y)
        {
            return x.ToString() + y.ToString();

        }
        /// <summary>
        /// Operador de desigualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(Linha x, Linha y)
        {
            return !x.Equals(y);

        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.mValue;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this.ToString().Equals(obj.ToString());

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}

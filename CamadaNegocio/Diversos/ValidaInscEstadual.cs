using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CamadaNegocio.Diversos
{
    public class TValidaInscEstadual
    {
        [DllImport("DllInscE32.dll")]
        public static extern int ConsisteInscricaoEstadual(string vInsc, string vUF);

        public static int ValidaInscEstadual(string vInsc, string vUf)
        {
            //Verificar tipo OS
            if (Utils.TVersaoOS.Is64Bit())
                return 0;
            else if (Utils.Estruturas.BaixarDll("DllInscE32.dll"))
                return ConsisteInscricaoEstadual(vInsc, vUf);
            else
                return 0;
        }
    }
}

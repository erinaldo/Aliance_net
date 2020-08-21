using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Converte
    {
        public static void Convert_Objeto(object origem, object destino)
        {
            if ((origem != null)  && (destino != null))
            {
                Type t = origem.GetType();
                System.Reflection.PropertyInfo[] field = t.GetProperties(System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public |
                                                            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty | 
                                                            System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Static);
                foreach (System.Reflection.PropertyInfo f in field)
                {
                    System.Reflection.PropertyInfo fd = destino.GetType().GetProperty(f.Name, System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public |
                                                            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Static);
                    if (fd != null)
                        if (!((f.PropertyType.Name.ToUpper().Contains("TLIST")) ||
                             (f.PropertyType.Name.ToUpper().Contains("TREGISTRO"))))
                        {
                            fd.SetValue(destino, f.GetValue(origem, null), null);
                        };                        
                }
            }
        }
    }
}

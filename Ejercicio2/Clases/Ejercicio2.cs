using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoja_de_tranajo.Clases
{
    public class Usuario
    {
        public string Nombre { get; set; }

        private string dpi;

        public string DPI
        {
            get { return dpi; }
            set
            {
                if (value.Length == 13 && long.TryParse(value, out _))
                {
                    dpi = value;
                }
                else
                {
                    throw new ArgumentException("El DPI debe tener exactamente 13 dígitos numéricos.");
                }
            }
        }

        private string contraseña;

        public void AsignarContraseña(string nuevaContraseña)
        {
            if (nuevaContraseña.Length >= 6)
            {
                contraseña = nuevaContraseña;
            }
            else
            {
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            }
        }

        public bool Autenticar(string input)
        {
            return contraseña == input;
        }
    }
}
  
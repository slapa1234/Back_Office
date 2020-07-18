using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisATU.Base.ViewModel.BackOffice
{
    public class BackOfficeLoginVM
    {
        public int UsuarioCodigo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public BackOfficeLoginVM()
        {
        }

    }
}

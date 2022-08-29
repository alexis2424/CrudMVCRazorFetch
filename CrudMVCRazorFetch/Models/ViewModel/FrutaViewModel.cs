using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CrudMVCRazorFetch.Models.ViewModel
{
    public class FrutaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        public int? Cantidad { get; set; }
        public string Origen { get; set; } 
        public int? Precio { get; set; }

    }
}
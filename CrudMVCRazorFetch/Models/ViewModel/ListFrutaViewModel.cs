using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CrudMVCRazorFetch.Models.ViewModel
{
    public class ListFrutaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cantidad { get; set; } 
        public string Origen { get; set; }  
        public int? Precio { get; set; } 


    }
}
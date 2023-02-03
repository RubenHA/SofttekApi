using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofttekApi.Models
{
    public class Venta
    {
        [Key]
        public int id { get; set; }
        public string producto { get; set; }    
        public string cliente { get; set; }    
        public string usuario { get; set; }    
        public int cantidad { get; set; }    
        public double precio { get; set; }    
        public DateTime fecha { get; set; }    
    }
}

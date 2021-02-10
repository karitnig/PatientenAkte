using PatientenAkte.Model.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientenAkte.Model
{
    public class Patient
    {
        [Key]
        public int PatientenNr { get; set; }
        [MaxLength(50)]
        public string Vorname { get; set; }
        [MaxLength(50), Required]
        public string Nachname { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime Ankunft { get; set; }
        [StringLength(500)]
        public string Memo { get; set; }

        public virtual ICollection<Tablette> Tablettes { get; set; }
    }
}

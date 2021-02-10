using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientenAkte.Model.DB_Models
{
    public class Arzt
    {
        [Key]
        public int ArztNr { get; set; }
        [MaxLength(50)]
        public string ArztTitle { get; set; }
        [MaxLength(50)]
        public string ArztVorname { get; set; }
        [MaxLength(50)]
        public string ArztNachname { get; set; }
        
        [ForeignKey("Patient")]
        public int PatientenNr { get; set; }
        public virtual Patient Patient { get; set; }
    }
}

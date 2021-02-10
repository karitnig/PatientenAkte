using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientenAkte.Model.DB_Models
{
    public class Tablette
    {
        [Key]
        public int TabletID { get; set; }
        [MaxLength(50), Required]
        public string TablettenName { get; set; }
        [Display(Name = "Stückzahl")]
        public float StueckZahl { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

    }
}

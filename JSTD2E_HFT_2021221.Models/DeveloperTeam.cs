using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSTD2E_HFT_2021221.Models
{
    public class DeveloperTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DevTeam { get; set; }

        public string HQ { get; set; }

        public int DateofFoundation { get; set; }

        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }
    }
}

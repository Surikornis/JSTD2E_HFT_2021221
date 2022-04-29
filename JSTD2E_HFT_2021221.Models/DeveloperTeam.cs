using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JSTD2E_HFT_2021221.Models
{
    public class DeveloperTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DevTeam { get; set; }

        public int DateofFoundation { get; set; }

        public string HQ { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Game> Games { get; set; }

        public DeveloperTeam()
        {
            Games = new HashSet<Game>();
        }
    }
}

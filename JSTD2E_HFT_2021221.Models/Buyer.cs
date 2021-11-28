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
    public class Buyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int DateofPurchase { get; set; }

        //[ForeignKey(nameof(Game))]
        //public string GameName { get; set; }

        public virtual List<Game> Games { get; set; } // not sure yet if needed

        [NotMapped]
        [JsonIgnore]
        public virtual Game Game { get; set; }
    }
}

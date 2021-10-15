using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSTD2E_HFT_2021221.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GameName { get; set; }
        
        [NotMapped]
        public virtual DeveloperTeam DevTeam { get; set; }

        [ForeignKey(nameof(DeveloperTeam))]
        public string DevTeamName { get; set; }

        public int Price { get; set; }

        public string Type { get; set; }
    }

    public class DeveloperTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DevTeam { get; set; }

        public string HQ { get; set; }

        public int DateofFoundation { get; set; }

        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }

        public DeveloperTeam()
        {
            Games = new HashSet<Game>();
        }
    }
    public class Buyer
    {
        public string GameName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int DateofPurchase { get; set; }
    }
}

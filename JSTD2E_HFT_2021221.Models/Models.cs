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
        public string DevTeam { get; set; }

        public string GameName { get; set; }

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

        public ICollection<Game> Games { get; set; }
    }
    public class Buyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GameName { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int DateofPurchase { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JSTD2E_HFT_2021221.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Price { get; set; }

        public string Type { get; set; }

        public string GameName { get; set; }


        [ForeignKey(nameof(DevTeam))]
        public string DevTeamName { get; set; }

        [ForeignKey(nameof(Buyer))]
        public string BuyerName { get; set; }

        [NotMapped]
        [JsonIgnore]
        //[Required]
        public virtual Buyer Buyer { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual DeveloperTeam DevTeam { get; set; }
    }
}

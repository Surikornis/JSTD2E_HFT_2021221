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


        [ForeignKey(nameof(Buyer))]
        public int BuyerId { get; set; }

        [ForeignKey(nameof(DevTeam))]
        public int DevTeamId { get; set; }

        //[JsonIgnore]
        [NotMapped]
        public virtual Buyer Buyer { get; set; }

        //[JsonIgnore]
        [NotMapped]
        public virtual DeveloperTeam DevTeam { get; set; }
    }
}

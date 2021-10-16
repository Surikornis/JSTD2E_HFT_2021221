using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSTD2E_HFT_2021221.Models
{
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

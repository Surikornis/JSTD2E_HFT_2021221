using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Repository
{
    class IdException : Exception
    {
        public IdException() : base("A BuyerId és DevTeamId mezőket kötelező kitölteni!")
        {

        }
    }
}

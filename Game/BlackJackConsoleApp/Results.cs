using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Results
    {
        Dictionary<int, decimal> winAtCount = new Dictionary<int, decimal>();
        Dictionary<int, decimal> insuranceWinAtCount = new Dictionary<int, decimal>();


        public decimal Balance
        {
            get;
            set;
        }

       public void AddWinAmountAtCount(int count, decimal amount)
       {
            if (!winAtCount.ContainsKey(count))
            {
                winAtCount.Add(count, 0);
            }
            winAtCount[count] += amount;
        }

        public decimal getWinAmountAtCount(int count)
        {
            decimal returnVal;
            if (winAtCount.TryGetValue(count, out returnVal))
            {
                return returnVal;
            }
            else
            {
                return 0;
            }
        }


        public void AddInsuranceWinAmountAtCount(int count, decimal amount)
        {
            if (!insuranceWinAtCount.ContainsKey(count))
            {
                insuranceWinAtCount.Add(count, 0);
            }
            insuranceWinAtCount[count] += amount;
        }

        public decimal getInsuranceWinAmountAtCount(int count)
        {
            decimal returnVal;
            if (insuranceWinAtCount.TryGetValue(count, out returnVal))
            {
                return returnVal;
            }
            else
            {
                return 0;
            }
        }

    }
}

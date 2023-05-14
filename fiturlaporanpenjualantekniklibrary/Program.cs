using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiturlaporanpenjualantekniklibrary
{
    public class SalesReport
    {
        private List<double> salesData;

        public SalesReport(List<double> salesData)
        {
            this.salesData = salesData;
        }

        public double TotalSales()
        {
            double totalSales = 0;

            foreach (double sale in salesData)
            {
                totalSales += sale;
            }

            return totalSales;
        }

        public double AverageSales()
        {
            double totalSales = TotalSales();

            if (salesData.Count > 0)
            {
                return totalSales / salesData.Count;
            }
            else
            {
                return 0;
            }
        }

        public double MaxSale()
        {
            double maxSale = double.MinValue;

            foreach (double sale in salesData)
            {
                if (sale > maxSale)
                {
                    maxSale = sale;
                }
            }

            return maxSale;
        }

        public double MinSale()
        {
            double minSale = double.MaxValue;

            foreach (double sale in salesData)
            {
                if (sale < minSale)
                {
                    minSale = sale;
                }
            }

            return minSale;
        }
    }
}

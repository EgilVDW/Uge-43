using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class usageRepository : IRepository
    {
        int _id;
        double _amount;
        DateTime _date;

        List<string> line = new List<string>();
        List<Usage> usages = new List<Usage>();

        public usageRepository()
        {
            using (StreamReader sr = new StreamReader(@"..\..\..\data.csv"))
            {
                int i = 0;
                while (sr.Peek() > -1)
                {
                    if (i == 0)
                    {
                        sr.ReadLine();
                    }
                    i++;
                    line.Add(sr.ReadLine());
                }
            }
            Usage tempUsage = new Usage();
            Meter tempMeter = new Meter(-1);
            string[] splittedEntry;
            foreach (string item in line)
            {
                splittedEntry = item.Split(';');
                tempMeter = new Meter(long.Parse(splittedEntry[0]));
                tempUsage = new Usage()
                {
                    Id = tempMeter,
                    Date = DateTime.ParseExact(splittedEntry[1], "yyyy-MM-dd HH,mm", CultureInfo.InvariantCulture),
                    Amount = double.Parse(splittedEntry[3])
                };
                usages.Add(tempUsage);
            }
        }

        public List<Usage> Read(Meter meterId)
        {
            List<Usage> usages = new List<Usage>();
            foreach (Usage item in usages)
	        {
                if (item.Id == meterId)
                {
                    usages.Add(item);
                }
	        }
            return usages;
        }

        public List<Usage> Read(Meter meterId, DateTime fromDate, DateTime toDate)
        {
            List<Usage> usages = new List<Usage>();
            foreach (Usage item in usages)
	        {
                if (item.Id == meterId && DateTime.Compare(fromDate,item.Date) < 0 && DateTime.Compare(toDate,item.Date) > 0)
                {
                    usages.Add(item);
                }
	        }
            return usages;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class usageRepository
    {
        int _id;
        double _amount;
        DateTime _date;

        List<string> line = new List<string>();

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
                    line.Add(i + ";" + sr.ReadLine());
                }
            }
        }

        public usageRepository(Meter _id, DateTime Date)
        {

        }

    }
}

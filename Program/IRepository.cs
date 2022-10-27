using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IRepository
    {
        public List<Usage> Read(Meter meter);
        public List<Usage> Read(Meter meter, DateTime dateTime, DateTime dateTime1);

    }
}

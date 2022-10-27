using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Meter
    {
		private long _id;

		public long Id
		{
			get { return _id; }
		}

		public Meter (long id)
		{
			_id = id;
		}
	}
}

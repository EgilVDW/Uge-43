using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Usage
    {
		private double _amount;

		public double Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		private DateTime _date;

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		private Meter _id;

		public  Meter Id
		{
			get { return _id; }
			set { _id = value; }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class SeasonalProduct : Product
    {
        private DateTime _seasonStartDate;
        private DateTime _seasonEndDate;

        public SeasonalProduct (DateTime seasonStartDate, DateTime seasonEndDate)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = seasonEndDate;
        }

        public DateTime seasonStartDate
        {
            get { return _seasonStartDate; }
            set { _seasonStartDate = value; }
        }

        public DateTime seasonEndDate
        {
            get { return _seasonEndDate; }
            set { _seasonEndDate = value; }
        }
        
        
    }
}

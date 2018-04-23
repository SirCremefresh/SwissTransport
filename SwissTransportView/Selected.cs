using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportView
{
    class Selected
    {
        private string from = "";

        public string From
        {
            get { return from;  }
            set
            {
                if (value != null && value != "")
                {
                    from = value;
                }
            }
        }

        private string to = "";

        public string To
        {
            get { return to; }
            set
            {
                if (value != null && value != "")
                {
                    to = value;
                };
            }
        }

        private string date = "";

        public string Date
        {
            get { return date; }
            set
            {
                if (value != null && value != "")
                {
                    date = value;
                };
            }
        }

        private string time = "";

        public string Time
        {
            get { return time; }
            set
            {
                if (value != null && value != "")
                {
                    time = value;
                };
            }
        }
    }
}

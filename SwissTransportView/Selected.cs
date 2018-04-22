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
    }
}

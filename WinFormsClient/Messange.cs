﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessanger
{
    [Serializable]
    class Messange
    {
        public string UserName { get; set; }
        public string MessgeText { get; set; }
        public DateTime TimeStamp { get; set; }

        public Messange(string userName, string messgeText, DateTime timeStamp)
        {
            this.UserName = userName;
            this.MessgeText = messgeText;
            this.TimeStamp = timeStamp;
        }
        public Messange()
        {
            this.UserName = "System";
            this.MessgeText = "Server is running...";
            this.TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            string output = String.Format("{0} <{2}>: {1}", UserName, MessgeText, TimeStamp);
            return output;
        }
    }
}

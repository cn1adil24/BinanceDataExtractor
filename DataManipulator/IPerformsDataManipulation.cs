using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulator
{
    interface IPerformsDataManipulation
    {
        DelimitedHandler Handler { get; set; }
        event EventHandler<string> SendFeedback;
        void Perform();
    }
}

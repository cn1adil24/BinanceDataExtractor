using System;

namespace DataManipulator
{
    interface IPerformsDataManipulation
    {
        DelimitedHandler Handler { get; set; }
        event EventHandler<string> SendFeedback;
        void Perform();
    }
}

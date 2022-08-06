using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    interface IRendersDataVariables
    {
        void StartEmbedding(string name);
        void Embed(object value);
        void StopEmbedding();
    }
}

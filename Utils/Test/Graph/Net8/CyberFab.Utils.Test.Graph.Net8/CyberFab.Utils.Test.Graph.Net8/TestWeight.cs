using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberFab.Utils.Graph.Net8;

namespace CyberFab.Utils.Test.Graph.Net8
{
    public class TestWeight(float weight) : IWeight
    {
        public float Weight { get; set; } = weight;
    }
}

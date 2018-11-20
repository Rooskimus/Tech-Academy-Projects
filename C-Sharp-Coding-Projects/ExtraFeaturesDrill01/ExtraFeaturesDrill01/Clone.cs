using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraFeaturesDrill01
{
    class Clone
    {
        public Clone (string designation, int dnaMatched, int indivIndex)
        {
            this.CloneDesignation = designation;
            this.PercentDNAMatched = dnaMatched;
            this.IndividualityIndex = indivIndex;
        }
        public Clone(string designation) : this(designation, 100, 0) { }

        public int PercentDNAMatched { get; set; }
        public string CloneDesignation { get; set; }
        public int IndividualityIndex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ThreeStepJumpCollector
    {
        public ThreeStepJumpCollector()
        {
            ThreeStepJumpValues = new List<int>();
        }

        public List<int> ThreeStepJumpValues { get; set; }

        public int HighestFirst { get; set; }
        public int HighestFirstIndex { get; set; }


        public int HighestSecond{ get; set; }
        public int HighestSecondIndex { get; set; }

        public int HighestThird { get; set; }
        public int HighestThirdIndex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.T)]
    public class TakePlaceCommandModel : BaseCommandModel
    {
        private int test;
        [DisplayNameAttribute("测试")]
        public int Test
        {
            get { return test; }
            set { test = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Test);
        }
    }
}
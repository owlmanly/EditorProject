using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.W)]
    public class WaitCommandModel : BaseCommandModel
    {
        private float waitTime;
        [DisplayNameAttribute("等待时间ms")]
        public float WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", WaitTime);
        }
    }
}

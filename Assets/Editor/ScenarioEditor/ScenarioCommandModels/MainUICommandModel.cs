using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.UI)]
    public class MainUICommandModel : BaseCommandModel
    {
        private int hide;
        [DisplayNameAttribute("隐藏[1]/不隐藏")]
        public int Hide
        {
            get { return hide; }
            set { hide = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Hide);
        }
    }
}

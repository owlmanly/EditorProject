using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.PA)]
    public class PauseCommandModel : BaseCommandModel
    {
        private int pasue;
        [DisplayNameAttribute("暂停[1]/不暂停")]
        public int Pasue
        {
            get { return pasue; }
            set { pasue = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Pasue);
        }
    }
}

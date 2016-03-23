using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.A)]
    public class AssistCommandModel : BaseCommandModel
    {
        private int id = 10000;
        [DisplayNameAttribute("武将ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int x = 0;
        [DisplayNameAttribute("x坐标")]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y = 0;
        [DisplayNameAttribute("Y坐标")]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}:{2}", Id, X, Y);
        }
    }
}

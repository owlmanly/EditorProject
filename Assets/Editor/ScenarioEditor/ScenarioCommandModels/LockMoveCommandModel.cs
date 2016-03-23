using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.LOCK)]
    public class LockMoveCommandModel : BaseCommandModel
    {
        private int _lock;
        [DisplayNameAttribute("lock[1]/unlock")]
        public int _lock1
        {
            get { return _lock; }
            set { _lock = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", _lock1);
        }
    }
}

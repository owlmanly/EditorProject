using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    //[ScenarioCommandAttribute(ScenarioCommandTypes.None)]
    public class BaseCommandModel
    {
        public virtual string ToString()
        {
            return "Test";
        }
    }
}

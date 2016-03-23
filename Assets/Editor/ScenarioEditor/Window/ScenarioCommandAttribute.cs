using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    public class ScenarioCommandAttribute : Attribute
    {
        private ScenarioCommandTypes _Type;
        public ScenarioCommandAttribute(ScenarioCommandTypes type)
        {
            _Type = type;
        }

        public ScenarioCommandTypes CommandType
        {
            get
            {
                return (ScenarioCommandTypes)Enum.Parse(typeof(ScenarioCommandTypes), _Type.ToString());
            }
        }
    }
}

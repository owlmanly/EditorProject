using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.TQ)]
    public class WeatherCommandModel : BaseCommandModel
    {
        private int control;
        [DisplayNameAttribute("开启[1]/不开启")]
        public int Control
        {
            get { return control; }
            set { control = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Control);
        }
    }
}

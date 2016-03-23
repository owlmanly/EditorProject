using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.S)]
    public class SoundCommandModel : BaseCommandModel
    {
        private string soundName = "xx.wav";
        [DisplayNameAttribute("音效名(带后缀)")]
        public string SoundName
        {
            get { return soundName; }
            set { soundName = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", SoundName);
        }
    }
}

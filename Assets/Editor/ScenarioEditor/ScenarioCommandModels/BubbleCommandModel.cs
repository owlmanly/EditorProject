using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.P)]
    public class BubbleCommandModel : BaseCommandModel
    {
        private int formationId = 0;
        [DisplayNameAttribute("阵型")]
        public int FormationId
        {
            get { return formationId; }
            set { formationId = value; }
        }
        private int npcId = 10000;
        [DisplayNameAttribute("npcId")]
        public int NpcId
        {
            get { return npcId; }
            set { npcId = value; }
        }
        private string content = "text";
        [DisplayNameAttribute("对话内容")]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", FormationId, NpcId, Content);
        }
    }
}
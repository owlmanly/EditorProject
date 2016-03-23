using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.D)]
    [MultiAttribute()]
    public class DialogCommandModel : BaseCommandModel
    {
        private int _npcId;
        private int _headAlign;
        private string _content = "text";

        [DisplayNameAttribute("npcId")]
        public int NpcId
        {
            get { return _npcId; }
            set { _npcId = value; }
        }

        [DisplayNameAttribute("头像显示位置")]
        public int HeadAlign
        {
            get { return _headAlign; }
            set { _headAlign = value; }
        }

        [DisplayNameAttribute("对白内容")]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", NpcId, HeadAlign, Content);
        }
    }
}

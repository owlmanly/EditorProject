using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.LTUI)]
    public class ChatUICommandModel : BaseCommandModel
    {
        private int isChat;
        [DisplayNameAttribute("打开[1]/关闭[0]")]
        public int IsChat
        {
            get { return isChat; }
            set { isChat = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", IsChat);
        }
    }
}
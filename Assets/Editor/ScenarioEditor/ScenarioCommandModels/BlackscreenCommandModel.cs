using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.B)]
    public class BlackscreenCommandModel : BaseCommandModel
    {
        private string content = "text";
        [DisplayNameAttribute("黑屏剧情文本")]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private float time = 1000.0f;
        [DisplayNameAttribute("停留时间ms")]
        public float Time
        {
            get { return time; }
            set { time = value; }
        }
        private int isWhite = 0;
        [DisplayNameAttribute("白屏[1]/黑屏[0]")]
        public int IsWhite
        {
            get { return isWhite; }
            set { isWhite = value; }
        }
        private int vanish = 1;
        [DisplayNameAttribute("消失[1]/不消息[0]")]
        public int Vanish
        {
            get { return vanish; }
            set { vanish = value; }
        }
        private int wait = 1;
        [DisplayNameAttribute("等待[1]/不等待[0]")]
        public int Wait
        {
            get { return wait; }
            set { wait = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}:{4}", Content, Time, IsWhite, Vanish, Wait);
        }
    }
}
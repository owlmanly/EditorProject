using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    public enum HeroSubcommandEnum
    {
        PlayAct = 2,
        TurnTo = 3,
        Move = 4,
    }

    [ScenarioCommandAttribute(ScenarioCommandTypes.HERO)]
    [RadioGroupAttribute(typeof(HeroSubcommandEnum))]
    public class HeroCommandModel : BaseCommandModel
    {
        private HeroSubcommandEnum _SubCommandEnum = HeroSubcommandEnum.PlayAct;
        [DisplayNameAttribute("NPC子命令")]
        public HeroSubcommandEnum SubCommandEnum
        {
            get { return _SubCommandEnum; }
            set { _SubCommandEnum = value; }
        }

        //PlayAct
        private string _modelName_Play = "baiwuchang";
        [DisplayNameAttribute("模型名称")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.PlayAct)]
        public string ModelName_Play
        {
            get { return _modelName_Play; }
            set { _modelName_Play = value; }
        }

        private string _act_play = "attack.act.txt";
        [DisplayNameAttribute("播放动作")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.PlayAct)]
        public string Act_play
        {
            get { return _act_play; }
            set { _act_play = value; }
        }

        //TURNTO
        private string _modelName_turnTo = "baiwuchang";
        [DisplayNameAttribute("转向的资源名称")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.TurnTo)]
        public string ModelName_turnTo
        {
            get { return _modelName_turnTo; }
            set { _modelName_turnTo = value; }
        }

        private int _zhenXingID;
        [DisplayNameAttribute("被转向的阵营ID")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.TurnTo)]
        public int ZhenXingID
        {
            get { return _zhenXingID; }
            set { _zhenXingID = value; }
        }

        private string _otherModelName = "HERO";
        [DisplayNameAttribute("被转向的资源名称")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.TurnTo)]
        public string OtherModelName
        {
            get { return _otherModelName; }
            set { _otherModelName = value; }
        }

        //Move
        public string _modelMove { get; set; }

        private int x_Walk;
        [DisplayNameAttribute("X")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.Move)]
        public int X_Walk
        {
            get { return x_Walk; }
            set { x_Walk = value; }
        }

        private int y_Walk;
        [DisplayNameAttribute("Y")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.Move)]
        public int Y_Walk
        {
            get { return y_Walk; }
            set { y_Walk = value; }
        }

        private float move_Walk;
        [DisplayNameAttribute("等待移动到达")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.Move)]
        public float Move_Walk
        {
            get { return move_Walk; }
            set { move_Walk = value; }
        }

        private float keep_Walk;
        [DisplayNameAttribute("维持当前动作（滑步移动）")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.Move)]
        public float Keep_Walk
        {
            get { return keep_Walk; }
            set { keep_Walk = value; }
        }

        private float speed;
        [DisplayNameAttribute("移动速度")]
        [RadioGroupAttribute(typeof(HeroSubcommandEnum), EnumValue = (int)HeroSubcommandEnum.Move)]
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override string ToString()
        {
            string data = "";
            switch (SubCommandEnum)
            { 
                case HeroSubcommandEnum.PlayAct:
                    data = string.Format("{0}|{1}|{2}", (int)NPCSubcommandEnum.PlayAct, ModelName_Play, Act_play);
                    break;
                case HeroSubcommandEnum.TurnTo:
                    data = string.Format("{0}|{1}|{2}:{3}", (int)NPCSubcommandEnum.TurnTo, ModelName_turnTo, ZhenXingID, OtherModelName);
                    break;
                case HeroSubcommandEnum.Move:
                    data = string.Format("{0}|{1}|{2}:{3}:{4}:{5}:{6}", (int)NPCSubcommandEnum.Move, _modelMove, X_Walk,
                            Y_Walk, Move_Walk, Keep_Walk, Speed);
                    break;
                default:
                    break;
            }

            return data;
        }
    }
}

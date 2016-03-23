using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ZEditor
{

    public enum NPCSubcommandEnum
    {
        Create,
        Remove,
        PlayAct,
        TurnTo,

        Move,
        WaitClick,
        HideStageNPC,
        ShowStageNPC,

        HideOtherPlayer,
        ShowOtherPlayer,
    }

    [ScenarioCommandAttribute(ScenarioCommandTypes.NPC)]
    [RadioGroupAttribute(typeof(NPCSubcommandEnum))]
    public class NPCCommandModel : BaseCommandModel
    {
        private NPCSubcommandEnum _SubCommandEnum = NPCSubcommandEnum.Create;
        [DisplayNameAttribute("NPC子命令")]
        public NPCSubcommandEnum SubCommandEnum
        {
            get { return _SubCommandEnum; }
            set { _SubCommandEnum = value; }
        }

        //CREATE

        private string resource = "baiwuchang";
        [DisplayNameAttribute("资源名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Create)]
        public string Resource
        {
            get { return resource; }
            set
            {
                resource = value;
                aliasName = value;
             }
        }

        private int x;
        [DisplayNameAttribute("X")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Create)]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        [DisplayNameAttribute("Y")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Create)]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private string aliasName = null;
        [DisplayNameAttribute("别名")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Create)]
        public string AliasName
        {
            get { return aliasName; }
            set { aliasName = value; }
        }

        private string appearAct = "npc_appear.act.txt";
        [DisplayNameAttribute("出现时的特效")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Create)]
        public string AppearAct
        {
            get { return appearAct; }
            set { appearAct = value; }
        }
        
        //DELETE
        private string modelName = "baiwuchang";

        [DisplayNameAttribute("模型名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Remove)]
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        //PlayAct
        private string _modelName_Play = "baiwuchang";
        [DisplayNameAttribute("模型名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.PlayAct)]
        public string ModelName_Play
        {
            get { return _modelName_Play; }
            set { _modelName_Play = value; }
        }

        private string _act_play = "attack.act.txt";
        [DisplayNameAttribute("播放动作")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.PlayAct)]
        public string Act_play
        {
            get { return _act_play; }
            set { _act_play = value; }
        }

        //TURNTO
        private string _modelName_turnTo = "baiwuchang";
        [DisplayNameAttribute("转向的资源名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.TurnTo)]
        public string ModelName_turnTo
        {
            get { return _modelName_turnTo; }
            set { _modelName_turnTo = value; }
        }

        private int _zhenXingID;
        [DisplayNameAttribute("被转向的阵营ID")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.TurnTo)]
        public int ZhenXingID
        {
            get { return _zhenXingID; }
            set { _zhenXingID = value; }
        }

        private string _otherModelName = "HERO";
        [DisplayNameAttribute("被转向的资源名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.TurnTo)]
        public string OtherModelName
        {
            get { return _otherModelName; }
            set { _otherModelName = value; }
        }

        //Move
        public string _modelMove { get; set; }

        private int x_Walk;
        [DisplayNameAttribute("X")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Move)]
        public int X_Walk
        {
            get { return x_Walk; }
            set { x_Walk = value; }
        }

        private int y_Walk;
        [DisplayNameAttribute("Y")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Move)]
        public int Y_Walk
        {
            get { return y_Walk; }
            set { y_Walk = value; }
        }

        private float move_Walk;
        [DisplayNameAttribute("等待移动到达")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Move)]
        public float Move_Walk
        {
            get { return move_Walk; }
            set { move_Walk = value; }
        }

        private float keep_Walk;
        [DisplayNameAttribute("维持当前动作（滑步移动）")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Move)]
        public float Keep_Walk
        {
            get { return keep_Walk; }
            set { keep_Walk = value; }
        }

        private float speed;
        [DisplayNameAttribute("移动速度")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.Move)]
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        //WaitClick
        private string _modelNameWaitClick = "baiwuchang";
        [DisplayNameAttribute("模型名称")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.WaitClick)]
        public string ModelNameWaitClick
        {
            get { return _modelNameWaitClick; }
            set { _modelNameWaitClick = value; }
        }

        [DisplayNameAttribute("是否显示手")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum),EnumValue = (int)NPCSubcommandEnum.WaitClick)]
        public int VisibleHand { get; set; }


        private string _textWaitClick = "文本内容";
        [DisplayNameAttribute("文本内容")]
        [RadioGroupAttribute(typeof(NPCSubcommandEnum), EnumValue = (int)NPCSubcommandEnum.WaitClick)]
        public string TextWaitClick
        {
            get { return _textWaitClick; }
            set { _textWaitClick = value; }
        }
        
        

        public override string ToString()
        {
            string data = "";
            switch (_SubCommandEnum)
            {
                case NPCSubcommandEnum.Create:
                    {
                        data = string.Format("{0}|{1}|{2}:{3}:{4}:{5}", (int)NPCSubcommandEnum.Create, Resource, X, Y, AliasName, AppearAct);
                    }
                    break;
                case NPCSubcommandEnum.Remove:
                    {
                        data = string.Format("{0}|{1}", (int)NPCSubcommandEnum.Remove, modelName);
                    }
                    break;
                case NPCSubcommandEnum.PlayAct:
                    {
                        data = string.Format("{0}|{1}|{2}", (int)NPCSubcommandEnum.PlayAct, ModelName_Play, Act_play);
                    }
                    break;
                case NPCSubcommandEnum.TurnTo:
                    {
                        data = string.Format("{0}|{1}|{2}:{3}", (int)NPCSubcommandEnum.TurnTo, ModelName_turnTo, ZhenXingID, OtherModelName);
                    }
                    break;
                case NPCSubcommandEnum.Move:
                    {
                        data = string.Format("{0}|{1}|{2}:{3}:{4}:{5}:{6}", (int)NPCSubcommandEnum.Move, _modelMove, X_Walk,
                            Y_Walk, Move_Walk, Keep_Walk, Speed);
                    }
                    break;
                case NPCSubcommandEnum.WaitClick:
                    {
                        data = string.Format("{0}|{1}|{2}:{3}", (int)NPCSubcommandEnum.WaitClick, ModelNameWaitClick,
                            VisibleHand, TextWaitClick);
                    }
                    break;
                case NPCSubcommandEnum.HideStageNPC:
                    {
                        data = string.Format("{0}", (int)NPCSubcommandEnum.HideStageNPC);
                    }
                    break;
                case NPCSubcommandEnum.ShowStageNPC:
                    {
                        data = string.Format("{0}", (int)NPCSubcommandEnum.ShowStageNPC);
                    }
                    break;
                case NPCSubcommandEnum.HideOtherPlayer:
                    {
                        data = string.Format("{0}", (int)NPCSubcommandEnum.HideOtherPlayer);
                    }
                    break;
                case NPCSubcommandEnum.ShowOtherPlayer:
                    {
                        data = string.Format("{0}", (int)NPCSubcommandEnum.ShowOtherPlayer);
                    }
                    break;
                default:
                    break;
            }

            return data;
        }
    }
}

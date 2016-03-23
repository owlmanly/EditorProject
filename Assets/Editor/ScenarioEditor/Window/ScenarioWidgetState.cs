using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ZEditor
{
    //多个Entitys的特性
    public sealed class MultiAttribute : Attribute
    {
        public MultiAttribute() { }
    }

    //多项单选命令 如NPC
    public sealed class RadioGroupAttribute : Attribute
    {
        private Type _type;

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _EnumValue;

        public int EnumValue
        {
            get { return _EnumValue; }
            set { _EnumValue = value; }
        }

        public RadioGroupAttribute(Type type) 
        {
            _type = type;
        }
    }

    public class ScenarioWidgetState
    {
        public bool FoldOut;
        //实体对应的ScenarioCommandTypes
        public ScenarioCommandTypes CommandType;

        //实体类Type
        public Type type;

        public List<BaseCommandModel> Entitys = new List<BaseCommandModel>();

    }
}

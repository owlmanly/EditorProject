using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.Q)]
    public class QuakeCommandModel : BaseCommandModel
    {
        private float _force;
        [DisplayNameAttribute("力度")]
        public float Force
        {
            get { return _force; }
            set { _force = value; }
        }
        private float _spring;
        [DisplayNameAttribute("频率")]
        public float Spring
        {
            get { return _spring; }
            set { _spring = value; }
        }
        private float _attenuation;
        [DisplayNameAttribute("衰减")]
        public float Attenuation
        {
            get { return _attenuation; }
            set { _attenuation = value; }
        }
        private float _time;
        [DisplayNameAttribute("时间")]
        public float Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}", Force, Spring, Attenuation, Time);
        }
    }
}


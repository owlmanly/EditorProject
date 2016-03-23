﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    [ScenarioCommandAttribute(ScenarioCommandTypes.JZZDJT)]
    public class IgnoreCombatFrustumOnceCommandModel : BaseCommandModel
    {
        private int test;
        [DisplayNameAttribute("测试")]
        public int Test
        {
            get { return test; }
            set { test = value; }
        }

        public override string ToString()
        {
            return "Test";
        }
    }
}

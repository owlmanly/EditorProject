using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZEditor
{
    public enum ScenarioCommandTypes
    {
        //[DisplayNameAttribute("None")]
        //None,
        [DisplayNameAttribute("剧情对白命令:D")]
        D,
        [DisplayNameAttribute("震屏命令:Q")]
        Q,
        [DisplayNameAttribute("武将助阵命令:A")]
        A,
        [DisplayNameAttribute("黑屏命令:B")]
        B,
        [DisplayNameAttribute("Leave命令:L(disabled)")]
        L,
        [DisplayNameAttribute("TakePlace命令:T(disabled)")]
        T,
        [DisplayNameAttribute("气泡对话命令:P")]
        P,
        [DisplayNameAttribute("NPC命令:NPC")]
        NPC,
        [DisplayNameAttribute("等待命令:W")]
        W,
        [DisplayNameAttribute("暂停命令:PA")]
        PA,
        [DisplayNameAttribute("命令:AC(disabled)")]
        AC,
        [DisplayNameAttribute("命令:XH(disabled)")]
        XH,
        [DisplayNameAttribute("结束战斗命令:JSZD(disabled)")]
        JSZD,
        [DisplayNameAttribute("摄像机控制命令:CAM")]
        CAM,
        [DisplayNameAttribute("主角控制命令:HERO")]
        HERO,
        [DisplayNameAttribute("锁住玩家操作命令:LOCK")]
        LOCK,
        [DisplayNameAttribute("隐藏主界面命令:UI")]
        UI,
        [DisplayNameAttribute("OpenUI操作命令:DKJM(disabled)")]
        DKJM,
        [DisplayNameAttribute("完成任务命令:WCRW(disabled)")]
        WCRW,
        [DisplayNameAttribute("音效命令:S")]
        S,
        [DisplayNameAttribute("控制天气命令:TQ")]
        TQ,
        [DisplayNameAttribute("IgnoreCombateFrustumOnce命令:JZZDJT(disabled)")]
        JZZDJT,
        [DisplayNameAttribute("聊天UI命令:LTUI")]
        LTUI,
    }
}
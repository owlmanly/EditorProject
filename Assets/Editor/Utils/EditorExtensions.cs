using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Reflection;

//////////////////////////////////////////////////////////////////////////
/*
 * public enum ActType
    {
        [DisplayName("无")]
        None = 0,
        [DisplayName("场景特效")]
        SceneEffect = 1,
        [DisplayName("角色特效")]
        ActorEffect = 2,
        [DisplayName("角色音效")]
        ActorSound = 4,
        [DisplayName("角色动画")]
        AnimationQueue = 8,
        [DisplayName("更换Shader")]
        ChangeShader = 16,
        [DisplayName("震屏")]
        CameraShake = 32,
        [DisplayName("相机曲线")]
        CameraCurve = 64,
        [DisplayName("事件")]
        Event = 128,
        [DisplayName("Attach可见性")]
        AttachVisible = 256,
        [DisplayName("ParaCurve")]
        ParaCurve = 512,
        [DisplayName("Actor可见性")]
        ActorVisible = 1024,
        [DisplayName("弹道（飞向目标角色）")]
        EffectToTarget = 2048,
        [DisplayName("弹道（飞向目标点）")]
        EffectToPos = 4096,
        [DisplayName("随机弹道（飞向角色）")]
        EffectRandomToTarget = 8192,
        [DisplayName("转向目标")]
        TurnToTarget = 16384,
        [DisplayName("ActivePos场景特效")]
        ActivePosSceneEffect = 32768,
        [DisplayName("将目标Attach到Actor")]
        AttachTarget = 65536,
        [DisplayName("将目标移动到目标点")]
        MoveTargetToPos = 131072,
        [DisplayName("角色震动")]
        ActorShake = 262144,
        [DisplayName("解除绑点下物件的绑定")]
        DetachBinding = 524288,
        [DisplayName("摄像机控制")]
        CameraControl = 1048576,
        [DisplayName("天气控制")]
        ChangeWeather = 2097152,
        [DisplayName("旋转指定角度")]
        TurnDegree = 4194304,
    }
 */
//根据Enum 生成 EditorGUILayout.Popup(idx, names);
/*
 * ActType actType = ActType.SceneEffect
 * actType = actType.EnumPopup()
 */


namespace ZEditor
{
    static class EditorExtensions
    {
        static Dictionary<Type, string[]> namesMapping = new Dictionary<Type, string[]>();
        static Dictionary<Type, Dictionary<string, int>> indexMapping = new Dictionary<Type, Dictionary<string, int>>();
        static Dictionary<Type, Dictionary<string, string>> displayMapping = new Dictionary<Type, Dictionary<string, string>>();

        public static T EnumPopup<T>(this T value)
            where T : struct
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                string[] names;
                if (!namesMapping.TryGetValue(t, out names))
                {
                    indexMapping[t] = new Dictionary<string, int>();
                    displayMapping[t] = new Dictionary<string, string>();
                    names = Enum.GetNames(t);
                    for (int i = 0; i < names.Length; i++)
                    {
                        indexMapping[t][names[i]] = i;
                    }
                    for (int i = 0; i < names.Length; i++)
                    {
                        string oldName = names[i];
                        FieldInfo fi = t.GetField(oldName);
                        if (fi != null)
                        {
                            object[] attr = fi.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                            if (attr.Length > 0)
                            {
                                names[i] = ((DisplayNameAttribute)attr[0]).DisplayName;
                                displayMapping[t][names[i]] = oldName;
                            }
                            else
                                displayMapping[t][oldName] = oldName;
                        }
                        else
                            displayMapping[t][oldName] = oldName;
                    }
                    namesMapping[t] = names;
                }
                int idx = indexMapping[t][value.ToString()];
                idx = EditorGUILayout.Popup(idx, names);
                if (!displayMapping[t].ContainsKey(names[idx]))
                {
                    string aa = names[idx];
                    aa = aa + "ff";
                }
                return (T)Enum.Parse(t, displayMapping[t][names[idx]]);
            }
            return default(T);
        }
    }
}

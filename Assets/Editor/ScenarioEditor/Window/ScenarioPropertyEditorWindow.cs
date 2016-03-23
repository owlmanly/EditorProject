using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace ZEditor
{
    class ScenarioPropertyEditorWindow : EditorWindow
    {
        private List<ScenarioWidgetState> _cmds = new List<ScenarioWidgetState>();
        private bool _FoldOut = true;

        private Vector2 m_scrollPositionSI;
        public void OnGUI()
        {
            EditorGUI.indentLevel = 0;
            m_scrollPositionSI = GUILayout.BeginScrollView(m_scrollPositionSI, false, true);

            _FoldOut = EditorGUILayout.Foldout(_FoldOut, "命令属性");

            if (_FoldOut)
            {
                EditorGUI.indentLevel += 1;
                for (int i = 0; i < _cmds.Count; i++)
                {
                    ScenarioWidgetState obj = _cmds[i];
                    if (obj.Entitys.Count <= 0)
                        return;
                    string classDisName = "";

                    FieldInfo filedInfo = typeof(ScenarioCommandTypes).GetField(obj.CommandType.ToString());

                    object[] commandTypeAttrs = filedInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                    classDisName = commandTypeAttrs.Length > 0 ? ((DisplayNameAttribute)commandTypeAttrs[0]).DisplayName : filedInfo.Name;
                    if (commandTypeAttrs.Length>0)
                    {
                        classDisName = ((DisplayNameAttribute)commandTypeAttrs[0]).DisplayName;
                    }

                    obj.FoldOut = EditorGUILayout.Foldout(obj.FoldOut, classDisName);
                    if (obj.FoldOut)
                    {
                        for (int j = 0; j < obj.Entitys.Count; j++)
                        {
                            EditorGUI.indentLevel += 1;

                            Type type = obj.Entitys[j].GetType();

                            bool flag = CreateRadioGroupView(type, obj.Entitys[j]);

                            if (!flag)
                            {
                                CreateCommonView(type, obj.Entitys[j]);
                            }
                            
                            if (j == obj.Entitys.Count - 1)
                            {
                                object[] multuiAttrs = type.GetCustomAttributes(typeof(MultiAttribute), false);
                                if (multuiAttrs.Length > 0)
                                {
                                    if (GUILayout.Button("Add"))
                                    {
                                        obj.Entitys.Add((BaseCommandModel)Activator.CreateInstance(obj.type));
                                    }
                                }
                            }
                            EditorGUI.indentLevel -= 1;
                        }
                    }
                    
                }
            }

            GUILayout.EndScrollView();
        }

        public void showPropertyView(List<ScenarioWidgetState> cmds)
        {
            this._cmds = cmds;
        }

        public bool CreateRadioGroupView(Type type, BaseCommandModel model)
        {
            bool flag = false;
            object[] radioGroupAttrs = type.GetCustomAttributes(typeof(RadioGroupAttribute), false);
            if (radioGroupAttrs.Length > 0)
            {
                RadioGroupAttribute radioGroup = radioGroupAttrs[0] as RadioGroupAttribute;
                Type typeEnum = radioGroup.Type;
                string[] options = Enum.GetNames(typeEnum);
                int enumValue = -1;
                PropertyInfo[] infos = type.GetProperties();
                foreach (PropertyInfo pd in infos)
                {
                    if (pd.PropertyType.IsEnum && pd.PropertyType == typeEnum)
                    {
                        object value = pd.GetValue(model, null);
                        int index = Array.IndexOf(options, value.ToString());
                        index = EditorGUILayout.Popup(index, options);

                        string enumName = options[index];
                        value = Enum.Parse(typeEnum, enumName);
                        pd.SetValue(model, value, null);
                        enumValue = (int)value;
                        flag = true;
                        break;
                    }
                }

                foreach (PropertyInfo pd in infos)
                {
                    object[] itemAttrs = pd.GetCustomAttributes(typeof(RadioGroupAttribute), false);
                    if (itemAttrs.Length>0)
                    {
                        RadioGroupAttribute radioGroupItem = itemAttrs[0] as RadioGroupAttribute;
                        if (radioGroupItem.EnumValue == enumValue)
                        {
                            object value = pd.GetValue(model, null);

                            string fieldDisName;
                            object[] atts = pd.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                            fieldDisName = atts.Length > 0 ? ((DisplayNameAttribute)atts[0]).DisplayName : pd.Name;

                            value = EditorGUIUitls.GUIProperty(fieldDisName, pd, value);

                            pd.SetValue(model, value, null);
                        }
                    }
                }

            }
            return flag;
        }

        public void CreateCommonView(Type type, BaseCommandModel model)
        {
            PropertyInfo[] infos = type.GetProperties();
            foreach (PropertyInfo pd in infos)
            {
                GUILayout.BeginHorizontal();
                object value = pd.GetValue(model, null);

                string fieldDisName;
                object[] atts = pd.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                fieldDisName = atts.Length > 0 ? ((DisplayNameAttribute)atts[0]).DisplayName : pd.Name;

                value = EditorGUIUitls.GUIProperty(fieldDisName, pd, value);

                pd.SetValue(model, value, null);

                GUILayout.EndHorizontal();
            }
        }
    }
}


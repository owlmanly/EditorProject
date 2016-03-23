using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;
using System.Text;

namespace ZEditor
{
    class ScenarioEditorWindow : EditorWindow
    {
        static ScenarioPropertyEditorWindow sp = null;

        private Dictionary<ScenarioCommandTypes, Type> _commandDic = new Dictionary<ScenarioCommandTypes, Type>();

        private string[] options;
        private int index = 0;
        private List<string> _cmds = new List<string>();
        private List<ScenarioWidgetState> commanList = new List<ScenarioWidgetState>();
        private Vector2 m_scrollPosition;
        string path = "";

        public ScenarioEditorWindow()
        {
            init();
        }

        public void init()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(ScenarioCommandAttribute));
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                object[] objs = type.GetCustomAttributes(typeof(ScenarioCommandAttribute), false);
                if (objs.Length>0)
                {
                    ScenarioCommandAttribute attribute = objs[0] as ScenarioCommandAttribute;
                    _commandDic.Add(attribute.CommandType, type);
                }
            }

            options = Enum.GetNames(typeof(ScenarioCommandTypes));
        }

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            //GUILayout.Label("导出路径选择");
            if (GUILayout.Button("导入", GUILayout.Width(100)))
            {
                if (ImportData())
                {
                    _cmds.Clear();
                    commanList.Clear();
                }
            }
            if (GUILayout.Button("保存", GUILayout.Width(100)))
            {
                SaveData();
            }
            if (GUILayout.Button("导出", GUILayout.Width(100)))
            {
                ExportData();
            }
            EditorGUILayout.EndHorizontal();

            m_scrollPosition = GUILayout.BeginScrollView(m_scrollPosition, false, true);
            GUILayout.BeginVertical();
            for (int i = 0; i < _cmds.Count; i++)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button(_cmds[i], GUILayout.Width(120)))
                {
                    updatePropertyWindow();
                }
                if (GUILayout.Button("删除", GUILayout.Width(80)))
                {
                    _cmds.RemoveAt(i);
                    commanList.RemoveAt(i);
                    updatePropertyWindow();
                }
                if (GUILayout.Button("插入", GUILayout.Width(80)))
                {
                    _cmds.Insert(i, options[index]);
                    ScenarioWidgetState state = matchCommand(options[index]);
                    commanList.Insert(i,state);
                    updatePropertyWindow();
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("添加命令"))
            {
                Debug.Log("添加命令" + options[index]);
                _cmds.Add(options[index]);
                ScenarioWidgetState state = matchCommand(options[index]);
                commanList.Add(state);
                updatePropertyWindow();
            }

            index = EditorGUILayout.Popup(index, options);

            EditorGUILayout.EndHorizontal();
            GUILayout.EndScrollView();
        }


        public void updatePropertyWindow()
        {
            if (sp == null)
            {
                sp = EditorWindow.GetWindow(typeof(ScenarioPropertyEditorWindow), false, "剧情动画属性") as ScenarioPropertyEditorWindow;
            }

            sp.showPropertyView(commanList);
            sp.Repaint();
        }

        private ScenarioWidgetState matchCommand(string cmd)
        {
            Type type;
            ScenarioCommandTypes commandkey = (ScenarioCommandTypes)Enum.Parse(typeof(ScenarioCommandTypes), cmd);
            type = _commandDic[commandkey];
            ScenarioWidgetState state = new ScenarioWidgetState();
            state.FoldOut = true;
            state.type = type;
            state.CommandType = commandkey;
            state.Entitys.Add((BaseCommandModel)Activator.CreateInstance(type));
            return state;
        }

        private bool ImportData()
        {
            bool flag = false;
            path = EditorUtility.OpenFilePanel("导入数据", "", "txt");
            if (path != "" && path != null)
            {
                flag = true;
                string data = FileUitls.Import(path);
                Debug.Log("导入数据:" + data);
            }
            return flag;
        }

        private void ExportData()
        {
            string data = FormatData();
            path = EditorUtility.SaveFilePanel("导出数据", "", "data", "txt");
            if (path != "" && path != null)
            {
                FileUitls.Export(data, path);
                Debug.Log("导出数据 path:" + path);
            }
        }

        private void SaveData()
        {
            string data = FormatData();
            if (path != null && path != "")
            {
                FileUitls.Export(data, path);
            }
            else
            {
                ExportData();
            }
            Debug.Log("保存数据 path:" + path);
        }

        private string FormatData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ScenarioWidgetState state in commanList)
            {
                Type type = state.type;
                sb.Append(state.CommandType.ToString());
                sb.Append("[");
                for (int i = 0; i < state.Entitys.Count;i++ )
                {
                    sb.Append(state.Entitys[i].ToString());
                    if (i!=state.Entitys.Count-1)
                    {
                        sb.Append("|");
                    }
                }
                sb.Append("]");
            }
            return sb.ToString();
        }
    }
}



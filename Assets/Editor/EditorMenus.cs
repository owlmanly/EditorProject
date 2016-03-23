using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;


namespace ZEditor
{
    class EditorMenus
    {
        [MenuItem("ZEditor/剧情动画编辑器")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(ScenarioEditorWindow), false, "剧情动画编辑器");
            EditorWindow.GetWindow(typeof(ScenarioPropertyEditorWindow), false, "剧情动画属性");
        }
    }
}

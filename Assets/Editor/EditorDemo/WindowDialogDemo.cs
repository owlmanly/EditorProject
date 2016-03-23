using UnityEngine;
using System.Collections;
using UnityEditor;

public class WindowDialogDemo : EditorWindow {

    //demo3
    private int count = 0;
    private string text = "haha";
    private bool bo = false;
    private Color color = new Color();
    private Vector3 pos = new Vector3();
    private GameObject obj;

    [MenuItem("man/demo")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(WindowDialogDemo));
    }


    public void OnGUI()
    {
        text = EditorGUILayout.TextField("文本", text);

        count = EditorGUILayout.IntField("数量", count);

        bo = EditorGUILayout.Toggle("是否选择", bo);

        color = EditorGUILayout.ColorField("颜色", color);

        pos = EditorGUILayout.Vector3Field("坐标", pos);

        obj = EditorGUILayout.ObjectField("z任意对象", obj,typeof(GameObject),true) as GameObject;

        if (GUILayout.Button("按钮"))
        {
            Debug.Log("数量 = " + count);
        }
    }

}

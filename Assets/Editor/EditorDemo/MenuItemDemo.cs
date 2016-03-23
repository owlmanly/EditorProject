using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuItemDemo{

    //demo1
    //工具栏菜单
    [MenuItem("MyMenu/记事本")]
    static void LogSelectedTransformName()
    {
        System.Diagnostics.Process.Start("notepad.exe");

    }


    //demo2
    //右键菜单 + 快捷键
    //空格后面的部分是快捷键
    //To create a hotkey you can use the following special 
    //characters: % (ctrl on Windows, cmd on OS X), # (shift), & (alt), <b>_</b> (no key modifiers).
    //For example to create a menu with hotkey shift-alt-g use "MyMenu/Do Something #&g".
    //To create a menu with hotkey g and no key modifiers pressed use "MyMenu/Do Something _g".
    [MenuItem("Assets/工具集/批量替换 %&f")]
    static void rightMenuDemo()
    {
        Debug.Log("批量替换~");
    }

    [MenuItem("Assets/工具集/记事本")]
    static void test1()
    {
        System.Diagnostics.Process.Start("notepad.exe");
    }


    //demo3
    [MenuItem("MyMenu/打开一个窗口")]
    static void menu1()
    {
        EditorWindow.GetWindow<WindowDialogDemo>(false, "标了个题");
    }

    //demo4
    [MenuItem("MyMenu/输出选中的文件名称")]
    static void menu2()
    {
        Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        foreach (Object obj in objs)
        {
            Debug.Log("选中的文件名称 = " + obj.name);
        }
    }

    //demo5
    //获取选中文件的资源路径
    [MenuItem("MyMenu/输出选中的文件路径")]
    static void menu3()
    {
        Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        foreach (Object obj in objs)
        {
            //AssetDatabase 编辑器环境才能使用，打包assetbandle也需要用到
            string path = AssetDatabase.GetAssetPath(obj);
            Debug.Log("选中的文件路径 = " + path);
            //使用EditorPrefs将路径保存到本地
            EditorPrefs.SetString(obj.name, path);
        }
    }

    //demo6
    //
}

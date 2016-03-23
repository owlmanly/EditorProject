using UnityEngine;
using System.Collections;
using UnityEditor;

//重写显示面板的显示内容：如将配置属性显示成中文
//知识点1：与组件关联 
[CustomEditor(typeof(InspectorDemo),true)]
public class InspectorDemoEidtor : Editor {

    private InspectorDemo m_inspector;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //获取所关联的对象 Eidtor.target
        m_inspector = target as InspectorDemo;
        m_inspector.obj = EditorGUILayout.ObjectField("游戏对象咯", m_inspector.gameObject, typeof(GameObject), true) as GameObject;
        m_inspector.num = EditorGUILayout.IntField("数量", m_inspector.num);
        m_inspector.color = EditorGUILayout.ColorField("颜色", m_inspector.color);
        m_inspector.pos = EditorGUILayout.Vector3Field("坐标", m_inspector.pos);

        //数组 或 集合 重绘方法
       //根据名称获取已经系列化的Property
        //InspectorDemo 中的trans 在编辑器中已经被序列化
        SerializedProperty serProperty = serializedObject.FindProperty("trans");
        //绘制系列化对象
        EditorGUILayout.PropertyField(serProperty, new GUIContent("游戏Trans"),true);
        //保存变化的SerializedProperty
        serializedObject.ApplyModifiedProperties();

        //重绘自定义 的类
        SerializedProperty test = serializedObject.FindProperty("ser");
        EditorGUILayout.PropertyField(test, new GUIContent("测试"), true);
        serializedObject.ApplyModifiedProperties();


    }
    
}

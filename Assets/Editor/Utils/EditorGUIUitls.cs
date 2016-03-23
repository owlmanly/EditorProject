using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ZEditor
{
    class EditorGUIUitls
    {
        public static object GUIProperty(string displayName, PropertyInfo pd, object value)
        {
            if (pd.PropertyType == typeof(bool))
            {
                bool v = (bool)value;
                v = EditorGUILayout.Toggle(displayName, v);
                value = v;
            }
            else if (pd.PropertyType == typeof(float))
            {
                float v = (float)value;
                v = EditorGUILayout.FloatField(displayName, v);
                value = v;
            }
            else if (pd.PropertyType == typeof(int))
            {
                int v = (int)value;
                v = EditorGUILayout.IntField(displayName, v);
                value = v;
            }
            else if (pd.PropertyType == typeof(double))
            {
                double v = (double)value;
                v = (double)EditorGUILayout.FloatField(displayName, (float)v);
                value = v;
            }
            else if (pd.PropertyType == typeof(Color))
            {
                Color color = (Color)value;
                color = EditorGUILayout.ColorField(displayName, color);
                value = color;
            }
            else if (pd.PropertyType == typeof(string))
            {
                string v = (string)value;
                v = EditorGUILayout.TextField(displayName, v);
                value = v;
            }

            return value;
        }
    }
}

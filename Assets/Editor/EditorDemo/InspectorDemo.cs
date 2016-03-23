using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class InspectorDemo : MonoBehaviour {

    public GameObject obj;
    public int num = 0;
    public Color color;
    public Vector3 pos;
    public GameObject[] gameObjs;
    public List<Transform> trans;

    public SerTest ser = new SerTest();
}

[System.Serializable]
public class SerTest
{
    public int a = 0;
    public List<Transform> trans;
}
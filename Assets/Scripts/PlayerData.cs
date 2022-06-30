using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<ObjectFields> Objects = new List<ObjectFields>();
}

[System.Serializable]
public class ObjectFields
{
    public string Type;
    public int x;
    public int y;
    public int z;
    public int size;
    public int color1;
    public int color2;
    public int color3;
    public int transparency;
    public string t_messase;
    public int param1;
    public int param2;
    public int param3;
    public int param4;
    public int param5;
    public int level;
}
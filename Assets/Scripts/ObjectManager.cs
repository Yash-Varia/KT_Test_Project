using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public void SpawnObject(ObjectFields myObject)
    {
        PrimitiveType type = GetObjectType(myObject.Type);

        GameObject currentObject =  GameObject.CreatePrimitive(type);

        SetPosition(currentObject, myObject);
        SetScale(currentObject, myObject);
        Setcolor(currentObject, myObject);
    }

    public PrimitiveType GetObjectType(string myType)
    {
        switch (myType)
        {
            case "Cuboid": case "Cube": return PrimitiveType.Cube;

            case "Sphere": return PrimitiveType.Sphere;

            default: return PrimitiveType.Cylinder;
        }
    }

    private void SetPosition(GameObject currentObject, ObjectFields myObject)
    {
        currentObject.transform.position = new Vector3(myObject.x, myObject.y, myObject.z);
    }

    private void Setcolor(GameObject currentObject, ObjectFields myObject)
    {
        MeshRenderer myRenderer = currentObject.GetComponent<MeshRenderer>();
        Color myColor = new Color(myObject.color1, myObject.color2, myObject.color3, myObject.transpoarency);
        myRenderer.material.color = myColor;
    }

    private void SetScale(GameObject currentObject, ObjectFields myObject)
    {
        currentObject.transform.localScale = Vector3.one * myObject.size;
    }

    
}

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
        SetColor(currentObject, myObject);
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

    private void SetColor(GameObject currentObject, ObjectFields myObject)
    {
        MeshRenderer myRenderer = currentObject.GetComponent<MeshRenderer>();

        float alpha = Mathf.InverseLerp(0f, 255f, myObject.transparency);

        Material mat = new Material(Shader.Find("Standard"));
        mat.SetColor("_Color",Color.clear);
        mat.SetColor("_Color", new Color(myObject.color1, myObject.color2, myObject.color3, alpha));

        mat.SetFloat("_Mode", 3);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.renderQueue = 3000;
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");

        myRenderer.material = mat;
    }

    private void SetScale(GameObject currentObject, ObjectFields myObject)
    {
        currentObject.transform.localScale = Vector3.one * myObject.size;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{   
    public GameObject PrimitiveCubePrefab;
    public GameObject PrimitiveSpherePrefab;

    public Material[] myTransparentMaterial;
    public int materialCounter = 0;


    //Spawn the objects
    public void SpawnObject(ObjectFields myObject)
    {
        GameObject currentObject;

        if (myObject.Type == "Cuboid" || myObject.Type == "Cube")
        {
            currentObject = Instantiate(PrimitiveCubePrefab);
        }
        else if (myObject.Type == "Sphere")
        {
            currentObject = Instantiate(PrimitiveSpherePrefab);
        }
        else 
        {
            currentObject = Instantiate(PrimitiveSpherePrefab);
        }

        SetPosition(currentObject, myObject);
        SetScale(currentObject, myObject);
        SetColor(currentObject, myObject);
    }

    //Set positions for the object
    private void SetPosition(GameObject currentObject, ObjectFields myObject)
    {
        currentObject.transform.position = new Vector3(myObject.x, myObject.y, myObject.z);
    }

    //Set color values for the object
    private void SetColor(GameObject currentObject, ObjectFields myObject)
    {   
        MeshRenderer myRenderer = currentObject.GetComponent<MeshRenderer>();

        float alpha = Mathf.InverseLerp(0f, 256f, myObject.transparency);
        myTransparentMaterial[materialCounter].SetColor("_Color", new Color(myObject.color1, myObject.color2, myObject.color3, alpha));

        myRenderer.material = myTransparentMaterial[materialCounter];

        materialCounter++;


        //Use this code to create new transparent material and apply it to the gameobject [Replace other code] [if replaced the material Array will be obsolete.]

        /*
        MeshRenderer myRenderer = currentObject.GetComponent<MeshRenderer>();

        float alpha = Mathf.InverseLerp(0f, 256f, myObject.transparency);
        mat.SetColor("_Color", new Color(myObject.color1, myObject.color2, myObject.color3, alpha));

        mat.SetFloat("_Mode", 3);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.renderQueue = 3000; 

        myRenderer.material = mat;
        */


        // Use this code to set the color to the default opaque material of the gameobject [Replace other code] [if replaced the material Array will be obsolete.]

        /*
        float alpha = Mathf.InverseLerp(0f, 255f, myObject.transparency);
        Color myColor = new Color(myObject.color1, myObject.color2, myObject.color3, alpha);
        myRenderer.material.color = myColor;
        */

        // while using one type of material code: comment out the other code [Use either trnsparent material code OR Opaque material code]
    }

    //Set the scale of the object
    private void SetScale(GameObject currentObject, ObjectFields myObject)
    {
        currentObject.transform.localScale = Vector3.one * myObject.size;
    }
}

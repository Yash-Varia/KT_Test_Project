using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class DataHandler : MonoBehaviour
{   
    public PlayerData playerData = new PlayerData();
    public ObjectManager objectManager;


    public void Start()
    {
        StartCoroutine(GetTextWithUWR());
    }

    IEnumerator GetTextWithUWR()
    {  
        UnityWebRequest request = UnityWebRequest.Get("https://dev.wikibedtimestories.com/webservices/ARIES/api/get_all_game_Char.php?page_size=4");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("error" + request.error);
        }
        else
        {
            string newJsonData = "{ \"Objects\" : " + request.downloadHandler.text + " }";
            ProcessJsonData(newJsonData);
        }
    }

    public void ProcessJsonData(string newJsonData)
    {
        playerData = JsonUtility.FromJson<PlayerData>(newJsonData);

        foreach(ObjectFields  myobject in playerData.Objects)
        {
            objectManager.SpawnObject(myobject);        
        }
    }

    

}

    

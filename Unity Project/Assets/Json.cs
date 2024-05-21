using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Valve.Newtonsoft.Json;

public class Json : MonoBehaviour
{
    public TextMeshPro machineName;
    public TextMeshPro machineInfo;
    public string URL;
    private JsonInfo jsonData;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetData() 
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(URL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "info.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success) 
        {
            machineName.text = "ERROR";
        }
        else 
        {
            Debug.Log("Download saved to " + resultFile);
            jsonData = JsonUtility.FromJson<JsonInfo>(File.ReadAllText(Application.persistentDataPath + "/info.json"));
            machineName.text = jsonData.Name.ToString();
            machineInfo.text = jsonData.Info.ToString();
            yield return GetData();
        }
        
    }
    [System.Serializable]
    public class JsonInfo 
    {
        public string Name;
        public string Info;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HUDSaveData : MonoBehaviour
{
    string keyWord = "123456789";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Save()
    {
        SaveDataH myData = new SaveDataH();
        myData.cores = GetComponent<HUDManager>().cores;
        myData.maxCores = GetComponent<HUDManager>().maxCores;
        myData.score = GetComponent<HUDManager>().score;
        myData.holdingCore = GetComponent<HUDManager>().holdingCore;
        myData.coresDone = GetComponent<HUDManager>().coresDone;
        string myDataString = JsonUtility.ToJson(myData);
        myDataString = EncryptDecryptData(myDataString);
        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        System.IO.File.WriteAllText(file, myDataString);
        Debug.Log(file);
    }

    public void Load()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        if (File.Exists(file))
        {
            string jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            Debug.Log(jsonData);
            SaveDataH myData = JsonUtility.FromJson<SaveDataH>(jsonData);
            GetComponent<HUDManager>().cores = myData.cores;
            GetComponent<HUDManager>().maxCores = myData.maxCores;
            GetComponent<HUDManager>().score = myData.score;
            GetComponent<HUDManager>().holdingCore = myData.holdingCore;
            GetComponent<HUDManager>().coresDone = myData.coresDone;
        }
    }

    public string EncryptDecryptData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }
        Debug.Log(result);
        return result;
    }
}

[System.Serializable]
public class SaveDataH
{
    public float score;
    public int cores;
    public int maxCores;
    public bool holdingCore;
    public bool coresDone;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InteractableSaveData : MonoBehaviour
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
        SaveDataI myData = new SaveDataI();
        myData.purchased = GetComponent<ObjectCosts>().purchased;
        myData.cost = GetComponent<ObjectCosts>().cost;
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
            SaveDataI myData = JsonUtility.FromJson<SaveDataI>(jsonData);
            GetComponent<ObjectCosts>().purchased = myData.purchased;
            GetComponent<ObjectCosts>().cost = myData.cost;
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
public class SaveDataI
{
    public bool purchased;
    public float cost;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class WaveSaveData : MonoBehaviour
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
        SaveDataW myData = new SaveDataW();
        myData.waveNumber = GetComponent<SpawnWavesController>().waveNumber;
        myData.currentHP = GetComponent<SpawnWavesController>().currentHP;
        myData.currentSpeed = GetComponent<SpawnWavesController>().currentSpeed;
        myData.spawnAmount = GetComponent<SpawnWavesController>().spawnAmount;
        myData.currentWaveTime = GetComponent<SpawnWavesController>().currentWaveTime;
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
            SaveDataW myData = JsonUtility.FromJson<SaveDataW>(jsonData);
            GetComponent<SpawnWavesController>().waveNumber = myData.waveNumber;
            GetComponent<SpawnWavesController>().currentHP = myData.currentHP;
            GetComponent<SpawnWavesController>().currentSpeed = myData.currentSpeed;
            GetComponent<SpawnWavesController>().spawnAmount = myData.spawnAmount;
            GetComponent<SpawnWavesController>().currentWaveTime = myData.currentWaveTime;
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
public class SaveDataW
{
    public int waveNumber;
    public float currentHP;
    public float currentSpeed;
    public int spawnAmount;
    public float currentWaveTime;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using StarterAssets;
public class Savesystem : MonoBehaviour
{
    string keyWord = "123456789";
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
    }

    public void Save()
    {
        SaveData myData = new SaveData();
        myData.x = transform.position.x;
        myData.y = transform.position.y;
        myData.z = transform.position.z;
        myData.health = GetComponent<PlayerHealth>().health;
        myData.maxHealth = GetComponent<PlayerHealth>().maxHealth;
        myData.speed = GetComponent<ThirdPersonController>().MoveSpeed;
        myData.sprintSpeed = GetComponent<ThirdPersonController>().SprintSpeed;
        myData.shootDamage = GetComponent<RaycastShoot>().shootDamage;
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
            SaveData myData = JsonUtility.FromJson<SaveData>(jsonData);
            characterController.enabled = false;
            transform.position = new Vector3(myData.x, myData.y, myData.z);
            characterController.enabled = true;
            GetComponent<RaycastShoot>().shootDamage = myData.shootDamage;
            GetComponent<ThirdPersonController>().SprintSpeed = myData.sprintSpeed;
            GetComponent<ThirdPersonController>().MoveSpeed = myData.speed;
            GetComponent<PlayerHealth>().maxHealth = myData.maxHealth;
            GetComponent<PlayerHealth>().health = myData.health;
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
public class SaveData
{
    public float x;
    public float y;
    public float z;
    public float health;
    public float maxHealth;
    public float speed;
    public float sprintSpeed;
    public float shootDamage;
}
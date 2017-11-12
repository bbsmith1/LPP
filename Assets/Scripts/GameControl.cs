using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Scripts;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl theStaticControl;

    public bool PersistWithXml;
    public int Health;
    public int Experience;
    private IPersist _Storage;

    // Use this for initialization
    void Awake()
    {
        Debug.Log("GameControl.Awake()");
        if (theStaticControl == null)
        {
            //DontDestroyOnLoad(gameObject);
            Debug.Log("ASSIGNING STATIC: theStaticControl");
            theStaticControl = this;
        }
        //else if (control != this)
        //{
        //    Destroy(gameObject);
        //}

        if (PersistWithXml)
            _Storage = new XmlStorage();
        else
            _Storage = new BinaryStorage();
        Debug.Assert(_Storage != null, "_Storage is null!");
    }

    //void Awake () {
    //if (control == null)
    //{
    //    DontDestroyOnLoad(gameObject);
    //    control = this;
    //}
    //else if (control != this)
    //{
    //    Destroy(gameObject);
    //}
    //}

    void Start()
    {
        Debug.Log("GameControl.Start()");
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        Load();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnApplicationQuit()
    {
        Save();
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Debug.Log("SceneChanged: " + arg0.name  + " - " + arg1.name);
    }

    private void SceneManager_sceneUnloaded(Scene arg0)
    {
        Debug.Log("-UNLOADED: " + arg0.name);
        Save();
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("+LOADED: " + arg0.name + " mode: " + arg1.ToString());
        Load();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        //gs.fixedWidth = 10;
        //gs.fixedHeight = 50;
        gs.fontSize = 50;
        gs.normal.textColor = Color.magenta;
        
        GUI.Label(new Rect(10, 280, 200,60), "health: " + Health, gs);
        GUI.Label(new Rect(20, 340, 200,60), "experience: " + Experience,gs);
    }

    //public void Load()
    //{
    //    var pd = _Storage.Load();
    //    health = pd.health;
    //    experience = pd.experience;

    //}
    //public void Save()
    //{
    //    _Storage.Save(new PlayerData(health, experience));
    //}

    private void Load()
    {
        PlayerData pd = _Storage.Load();
        Health = pd.Health;
        Experience = pd.Experience;
    }

    private void Save()
    {
        PlayerData pd = new PlayerData(Health, Experience);
        _Storage.Save(pd);
    }

    //public void Load()
    //{
    //    PlayerData data = null;
    //    if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
    //        data = (PlayerData)bf.Deserialize(file);
    //        Health = data.Health;
    //        Experience = data.Experience;
    //        file.Close();
    //    }
    //    Debug.Log("PlayerData LOADED");
    //}

    //public void Save()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
    //    PlayerData data = new PlayerData(Health, Experience);
    //    bf.Serialize(file, data);
    //    file.Close();
    //    Debug.Log("PlayerData SAVED");
    //}

}


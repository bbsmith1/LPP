using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Load/Save PlayerData in binary format
    /// </summary>
    class BinaryStorage : IPersist
    {
        private string _FileName = Application.persistentDataPath + "/playerData.dat";
        public PlayerData Load()
        {
            PlayerData data = null;
            if (File.Exists(_FileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(_FileName, FileMode.Open);
                data = (PlayerData)bf.Deserialize(file);
                file.Close();
                Debug.Log(Application.persistentDataPath);
            }
            return data;
        }

        public void Save(PlayerData data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(_FileName);
            bf.Serialize(file, data);
            file.Close();
        }
    }
}

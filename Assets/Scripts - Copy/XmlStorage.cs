using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts
{
    class XmlStorage : IPersist
    {
        private string _FileName = Application.persistentDataPath + "/playerData.xml";
        public PlayerData Load()
        {
            PlayerData r = null;
            if (File.Exists(_FileName))
            {
                XmlSerializer xs = new XmlSerializer(typeof(PlayerData));
                FileStream file = File.Open(_FileName, FileMode.Open);
                r = (PlayerData)xs.Deserialize(file);
                file.Close();
            }
            return r;
        }

        public void Save(PlayerData data)
        {
            XmlSerializer xs = new XmlSerializer(typeof(PlayerData));
            FileStream file = File.Create(_FileName);
            xs.Serialize(file, data);
            file.Close();
        }
    }
}

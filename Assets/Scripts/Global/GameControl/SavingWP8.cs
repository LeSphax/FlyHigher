using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class SavingWP8 : Saving{

    public void Save(FileStream file, GameData.PlayerData data)
    {
        XmlSerializer xs = new XmlSerializer(typeof(GameData.PlayerData));
        xs.Serialize(file, data);
    }

    public GameData.PlayerData Load(FileStream file)
    {
        XmlSerializer xs = new XmlSerializer(typeof(GameData.PlayerData));
        return (GameData.PlayerData)xs.Deserialize(file);
    }
}

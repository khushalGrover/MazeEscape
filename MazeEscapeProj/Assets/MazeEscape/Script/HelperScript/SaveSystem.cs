using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveSetting(Setting setting)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/setting.saved";    // making a new save file with "setting.saved" name
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingData data = new SettingData(setting);

        // write data in file and close stream
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SettingData LoadSetting()
    {
        string path = Application.persistentDataPath + "/setting.saved";    // making a new save file with "setting.saved" name
        if(File.Exists(path))
        {
            // save file found and trying to load...
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);


            SettingData data = formatter.Deserialize(stream) as SettingData;
            stream.Close();

            return data;

        }
        else
        {
            // save file not found
            Debug.LogError("Save file not find in " +  path);
            return null;
        }


    }

}

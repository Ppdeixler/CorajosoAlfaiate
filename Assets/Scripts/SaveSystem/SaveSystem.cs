using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static bool checkpointounao;


    //SAVE checkpoint
    public static void salvajogo(Inventory inv)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.lpd";
        FileStream stream = new FileStream(path, FileMode.Create);

        InvSave data = new InvSave(inv);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InvSave carregajogo()
    {
        string caminho = Application.persistentDataPath + "/scene.lpd";
        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(caminho, FileMode.Open);

            InvSave dados = formatter.Deserialize(stream) as InvSave;
            stream.Close();
            return dados;

        }
        else
        {
            Debug.LogError("ERROR NO FILE");
            return null;
        }
    }




    //SAVE entre cada fase
    public static void salvabetween(Inventory inv)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/between.lpd";
        FileStream stream = new FileStream(path, FileMode.Create);

        InvSave between = new InvSave(inv);
        formatter.Serialize(stream, between);
        stream.Close();
    }

    public static InvSave carregabetween()
    {
        string caminho = Application.persistentDataPath + "/between.lpd";
        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(caminho, FileMode.Open);

            InvSave between = formatter.Deserialize(stream) as InvSave;
            stream.Close();
            return between;

        }
        else
        {
            Debug.LogError("ERROR NO FILE");
            return null;
        }
    }


}
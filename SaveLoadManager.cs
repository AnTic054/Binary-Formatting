using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager<Type>: MonoBehaviour where Type: new()
{
    public static void Save(string p_path, Type p_file)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(p_path,FileMode.Create);

        bf.Serialize(stream, p_file);
        stream.Close();
    }

    public static void Load(string p_path, out Type p_file)
    {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(p_path, FileMode.Open);

            p_file = (Type)bf.Deserialize(stream);
            stream.Close();
    }
}
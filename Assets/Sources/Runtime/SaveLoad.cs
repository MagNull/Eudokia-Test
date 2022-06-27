using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    private static List<int> _savedRecords = new List<int>();
    private static readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();
    private const string RecordFileName = "/records.gd";

    public static IReadOnlyList<int> Records => _savedRecords;

    public static void Save(int record)
    {
        _savedRecords.Add(record);
        _savedRecords.Sort((a, b) => b.CompareTo(a));
        var file = File.Exists(Application.persistentDataPath + RecordFileName)
            ? File.Open(Application.persistentDataPath + RecordFileName, FileMode.Open)
            : File.Create(Application.persistentDataPath + RecordFileName);

        _binaryFormatter.Serialize(file, _savedRecords);
        file.Close();
    }

    public static void Load()
    {
        var file = File.Open(Application.persistentDataPath + RecordFileName, FileMode.Open);
        if (!File.Exists(Application.persistentDataPath + RecordFileName))
            return;

        _savedRecords = (List<int>) _binaryFormatter.Deserialize(file);
        file.Close();
    }
}
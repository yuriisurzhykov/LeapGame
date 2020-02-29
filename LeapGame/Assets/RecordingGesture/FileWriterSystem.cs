using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public interface IGestureWriter
{
    string Path { get; set; }
    string Write(Gesture gesture, string gestureName);
    Gesture Read(string gestureName);
}

public class JsonGestureWriter : IGestureWriter
{
    protected string _path;
    public string Path { get { return _path; } set { _path = value; } }

    public JsonGestureWriter(string path)
    {
        _path = path;
    }

    public Gesture Read(string gestureName)
    {
        Gesture returnedGesture = new Gesture();
        string jsonData = File.ReadAllText(_path + "\\" + gestureName + ".json");
        returnedGesture = JsonUtility.FromJson<Gesture>(jsonData);
        return returnedGesture;
    }

    public static Gesture Read(string path, string gestureName)
    {
        Gesture returnedGesture = new Gesture();
        string jsonData = File.ReadAllText(path + "\\" + gestureName + ".json");
        returnedGesture = JsonUtility.FromJson<Gesture>(jsonData);
        return returnedGesture;
    }

    public string Write(Gesture gesture, string gestureName)
    {
        string jsonData = JsonUtility.ToJson(gesture);
        File.WriteAllText(_path + "\\" + gestureName + ".json", jsonData);
        return jsonData;
    }
}

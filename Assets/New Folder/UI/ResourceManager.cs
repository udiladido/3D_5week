using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static GameObject Load(string path)
    {
        return Resources.Load<GameObject>($"Prefabs/{path}");
    }
    public static GameObject Instantiate(GameObject prefab, Transform parent = null)
    {
        return GameObject.Instantiate(prefab, parent);
    }
    public static GameObject Instantiate(string path, Transform parent = null)
    {
        return Instantiate(Load(path), parent);
    }
    public static GameObject Instantiate<T>(Transform parent = null)
    {
        string path = Utils.GetPath<T>();
        return Instantiate(path, parent);
    }
    public static GameObject Instantiate<T>(string name, Transform parent = null)
    {
        string path = Utils.GetPath<T>(name);
        return Instantiate(path, parent);
    }
}

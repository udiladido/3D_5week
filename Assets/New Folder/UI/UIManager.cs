using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<string, GameObject> _cache = new Dictionary<string, GameObject>();

    private string GetUIPath<T>(string name)
    {
        if (name == null)
        {
            return Utils.GetPath<T>();
        }
        else
        {
            return Utils.GetPath<T>(name);
        }
    }

    public T OpenUI<T>(string name = null)
    {
        string path = GetUIPath<T>(name);
        GameObject go;
        if (IsUIExist<T>(name))
        {
            go = _cache[path];
        }
        else
        {
            go = CreateUI<T>(name);
        }
        go.SetActive(true);
        return go.GetComponent<T>();
    }
    public GameObject CreateUI<T>(string name = null, Transform parent = null)
    {
        string path = GetUIPath<T>(name);
        if (IsUIExist<T>(name))
        {
            RemoveUI<T>();
        }
        GameObject go = ResourceManager.Instantiate(path);
        AddUI<T>(go, path);
        return go;
    }
    public void CloseUI<T>(string name = null) where T : UI
    {
        string path = GetUIPath<T>(name);
        if (IsUIExist<T>(name))
        {
            _cache[path].GetComponent<T>().Close();
        }
    }
    public void DestroyUI<T>(string name = null)
    {
        string path = GetUIPath<T>(name);
        if (IsUIExist<T>())
        {
            Destroy(_cache[path]);
        }
    }
    public void AddUI<T>(GameObject go, string path)
    {
        _cache.Add(path, go);
    }
    public void RemoveUI<T>(string name = null)
    {
        _cache.Remove(GetUIPath<T>(name));
    }
    public bool IsUIExist<T>(string name = null)
    {
        return _cache.ContainsKey(GetUIPath<T>(name));
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;


public static class Utils
{
    public static string GetPath<T>()
    {
        List<string> path = new List<string>();
        Type type = typeof(T);
        while (type != null && type != typeof(object))
        {
            if (type == typeof(MonoBehaviour))
                break;
            path.Add(type.Name);
            type = type.BaseType;
        }
        path.Reverse();
        return string.Join("/", path);
    }
    public static T AddUniqueComponent<T>(this GameObject go) where T : Component
    {
        if (go.TryGetComponent<T>(out T component))
        {
            return component;
        }
        return go.AddComponent<T>();
    }
    public static string GetPath<T>(string name)
    {
        GetPath<T>();
        return GetPath<T>() + $"/{name}";
    }
}
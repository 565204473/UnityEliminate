using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIToos
{
    public static Button ButtonAddListener(string path, GameObject go, UnityEngine.Events.UnityAction<GameObject> callBack)
    {
        Button btn = FindComponent<Button>(path, go);
        if (btn != null)
        {
            btn.onClick.AddListener(() => { callBack(btn.gameObject); });
            return btn;
        }
        return null;
    }


    public static Button ButtonAddListener(Button btn, UnityEngine.Events.UnityAction<GameObject> callBack)
    {
        if (btn != null)
        {
            btn.onClick.AddListener(() => { callBack(btn.gameObject); });
            return btn;
        }
        return null;
    }


    public static T FindComponent<T>(string path, GameObject go) where T : Component
    {
        Transform trans = FindTransform(path, go);
        if (trans == null)
        {
            return null;
        }
        else
        {
            return trans.GetComponent<T>();
        }
    }

    public static Transform FindTransform(string path, GameObject go)
    {
        if (null == go)
        {
            Debug.LogError("go is null" + path);
            return null;
        }

        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError("path is null" + path);
            return go.transform;
        }
        return go.transform.Find(path);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInit : MonoBehaviour
{

    void Awake()
    {
        Init();
    }

    public static void Init()
    {
        SaveTypeMgr.types = new Dictionary<System.Type, SaveType>();
        SaveTypeMgr.types[typeof(System.Int32)] = new SaveInt();
        SaveTypeMgr.types[typeof(System.String)] = new SaveString();

    }

}

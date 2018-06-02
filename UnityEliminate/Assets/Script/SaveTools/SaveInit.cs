﻿using System.Collections;
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
        StoredataTypeMgr.types = new Dictionary<System.Type, StoredataType>();
        StoredataTypeMgr.types[typeof(System.Int32)] = new SaveInt();
        StoredataTypeMgr.types[typeof(System.String)] = new SaveString();
    }

}

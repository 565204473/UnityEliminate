using System;
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
        StoredataTypeMgr.types = new Dictionary<System.Type, StoredataType>();
        StoredataTypeMgr.types[typeof(System.Int32)] = new SaveInt();
        StoredataTypeMgr.types[typeof(System.Int64)] = new SaveLong();
        StoredataTypeMgr.types[typeof(System.Double)] = new SaveDouble();
        StoredataTypeMgr.types[typeof(System.String)] = new SaveString();
        StoredataTypeMgr.types[typeof(System.Single)] = new SaveFloat();
        StoredataTypeMgr.types[typeof(System.Boolean)] = new SaveBool();
        StoredataTypeMgr.types[typeof(Vector2)] = new SaveVector2();
        StoredataTypeMgr.types[typeof(Vector3)] = new SaveVector3();
        StoredataTypeMgr.types[typeof(Vector4)] = new SaveVector4();
        StoredataTypeMgr.types[typeof(Quaternion)] = new SaveQuaternion();
        StoredataTypeMgr.types[typeof(Color)] = new SaveColor();
        StoredataTypeMgr.types[typeof(Enum)] = new SaveEnum();

    }

}

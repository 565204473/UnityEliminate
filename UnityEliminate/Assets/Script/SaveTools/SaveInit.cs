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
        StoredataTypeMgr.types[typeof(System.Int16)] = new SaveShort();
        StoredataTypeMgr.types[typeof(System.Int32)] = new SaveInt();
        StoredataTypeMgr.types[typeof(System.Int64)] = new SaveLong();
        StoredataTypeMgr.types[typeof(System.UInt32)] = new SaveUint();
        StoredataTypeMgr.types[typeof(System.UInt64)] = new SaveUlong();
        StoredataTypeMgr.types[typeof(System.UInt16)] = new SaveUshort();
        StoredataTypeMgr.types[typeof(System.Double)] = new SaveDouble();
        StoredataTypeMgr.types[typeof(System.String)] = new SaveString();
        StoredataTypeMgr.types[typeof(System.Single)] = new SaveFloat();
        StoredataTypeMgr.types[typeof(System.Boolean)] = new SaveBool();
        StoredataTypeMgr.types[typeof(System.Byte)] = new SaveByte();
        StoredataTypeMgr.types[typeof(System.Char)] = new SaveChar();
        StoredataTypeMgr.types[typeof(Vector2)] = new SaveVector2();
        StoredataTypeMgr.types[typeof(Vector3)] = new SaveVector3();
        StoredataTypeMgr.types[typeof(Vector4)] = new SaveVector4();
        StoredataTypeMgr.types[typeof(Quaternion)] = new SaveQuaternion();
        StoredataTypeMgr.types[typeof(Color)] = new SaveColor();
        StoredataTypeMgr.types[typeof(System.Enum)] = new SaveEnum();
        StoredataTypeMgr.types[typeof(List<>)] = new SaveList();
        StoredataTypeMgr.types[typeof(Dictionary<object, object>)] = new SaveDictionary();
        StoredataTypeMgr.types[typeof(DateTime)] = new SaveDateTime();
        StoredataTypeMgr.types[typeof(Array)] = new SaveArray();

    }

}

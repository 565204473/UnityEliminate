using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

public static class StoredataTypeMgr {
    public static Dictionary<Type, StoredataType> types = null;
    private static StoredataType cachedType = null;
    public static void AddSaveType(StoredataType type) {
        types[type.type] = type;
    }

    public static StoredataType GetStoredataType(Type type) {
        if (types.TryGetValue(type, out cachedType)) {
            return cachedType;
        }
        if (IsEnum(type)) {

            return new SaveEnum();
        }
        if (IsArray(type)) {

            return new SaveArray();
        }

        if (IsGenericType(type)) {

            return new SaveList();
        }

        return null;
    }


    private static bool IsEnum(Type type) {

        return type.IsEnum;
    }

    private static bool IsArray(Type type) {
        return type.IsArray;
    }

    private static bool IsGenericType(Type type) {

        return type.IsGenericType;
    }
}

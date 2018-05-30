using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

public static class SaveTypeMgr
{
    public static Dictionary<Type, SaveType> types = null;
    private static SaveType cachedType = null;
    public static void AddSaveType(SaveType type)
    {
        types[type.type] = type;
    }

    public static SaveType GetSaveType(Type type)
    {
        if (types.TryGetValue(type, out cachedType))
        {
            return cachedType;
        }
        return null;
    }

}

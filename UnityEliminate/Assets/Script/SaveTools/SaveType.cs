using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveType : ISaveType {

    public EnumSaveTypeKey key;
    public Type type;

    public SaveType(Type type) {

        this.type = type;
    }

    public virtual void Read(SaveRead reader, object c) {

        Debug.LogError("读取");
    }

    public virtual object Read(SaveRead reader) {

        Debug.LogError("This Load method is not supported on Types of " + this.type.ToString() + ". Try a self-assigning Load method instead");
        return null;
    }

    public abstract void Write(object data, Writer write);
}

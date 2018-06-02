using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoredataType : IStoredataType {

    public EnumStoredataTypeKey key;
    public Type type;

    public StoredataType(Type type) {

        this.type = type;
    }

    public virtual void Reader(Read reader, object c) {

        Debug.LogError("读取");
    }

    public virtual object Reader(Read reader) {

        Debug.LogError("This Load method is not supported on Types of " + this.type.ToString() + ". Try a self-assigning Load method instead");
        return null;
    }

    public abstract void Write(object data, Writer write);
}

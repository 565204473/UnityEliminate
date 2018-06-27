using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoredataType : IStoredataType {

    public EnumSaveTypeKey key;
    public Type type;

    public StoredataType(Type type) {

        this.type = type;
    }
   

    public virtual object Reader(Read reader) {

        Debug.LogError("This Load method is not supported on Types of " + this.type.ToString() + ". Try a self-assigning Load method instead");
        return null;
    }

    public  virtual object Reader(Read reader, object defaultValue) {
        Debug.LogError("This Load method is not supported on Types of " + this.type.ToString() + ". Try a self-assigning Load method instead");
        return null;
    }

    public abstract void Write(object data, Writer write);
}

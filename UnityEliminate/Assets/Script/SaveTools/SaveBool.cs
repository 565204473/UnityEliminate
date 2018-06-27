﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveBool : StoredataType {

    public SaveBool() : base(typeof(bool)) {

        base.key = EnumSaveTypeKey.SaveBool;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadBool();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadBool((bool)defaultValue);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteBool((bool)data);
    }
}

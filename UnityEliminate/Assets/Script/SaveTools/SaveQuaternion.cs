﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveQuaternion : StoredataType {

    public SaveQuaternion() : base(typeof(Quaternion)) {
        key = EnumSaveTypeKey.SaveQuaternion;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadQuaternion();
    }

    public override void Write(object data, Writer write) {

        write.writerData.WriteQuaternion((Quaternion)data);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDateTime : StoredataType {

    public SaveDateTime() : base(typeof(DateTime)) {
        key = EnumSaveTypeKey.SaveDateTime;
    }


    public override object Reader(Read reader) {
        return reader.readData.ReadDateTime(DateTime.Now);
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadDateTime((DateTime)defaultValue);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteDateTime((DateTime)data);
    }

}

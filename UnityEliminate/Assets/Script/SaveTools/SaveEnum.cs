﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveEnum : StoredataType
{
    public SaveEnum():base(typeof(Enum)){

        key = EnumSaveTypeKey.SaveEnum;
    }

    public override object Reader(Read reader)
    {
        return reader.readData.ReadEnum();
    }

    public override void Write(object data, Writer write)
    {
        write.writerData.WriteEnum((Enum)data);
    }
}

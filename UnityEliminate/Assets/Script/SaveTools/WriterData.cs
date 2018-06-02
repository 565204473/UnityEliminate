using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriterData : IDisposable {


    public void WriteInt(int value) {

        Debug.LogError("要写入文件的int" + value);
    }


    public void Dispose() {
      

    }
}

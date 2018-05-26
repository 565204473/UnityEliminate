using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesMgr : QMonoSingleton<ScenesMgr> {

    private Dictionary<int, Scene> dicScenes;
    public ScenesMgr() {

        dicScenes = new Dictionary<int, Scene>();
       
    }

    public void Init() {

    }

    protected override void OnDestroy() {
        base.OnDestroy();
        if (dicScenes.Count > 0) {
            dicScenes.Clear();
        }
    }
}

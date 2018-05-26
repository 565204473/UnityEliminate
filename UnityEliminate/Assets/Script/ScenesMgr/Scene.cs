using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType {

    SceneLogion,
    SceneLobby,
    SceneGame,
    SceneEnd
}


public abstract class Scene : ISyncTask {
    public virtual bool LoadScene() {

        return true;
    }

    public virtual bool recycleScene() {

        return true;
    }


    public virtual  void SelcetScene(SceneType type) {


    }
}

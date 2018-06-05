using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour {

    void Start() {
        ScenesMgr.Instance.OpenScene(SceneType.SceneLogion);
        DontDestroyOnLoad(this.transform.gameObject);
    }
}

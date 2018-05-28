using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesMgr : QSingleton<ScenesMgr> {

    private Dictionary<SceneType, Scene> dicScenes;
    private ScenesMgr() { }
    public override void OnSingletonInit() {
        base.OnSingletonInit();
        Init();
    }
    private void Init() {
        dicScenes = new Dictionary<SceneType, Scene>();
        dicScenes[SceneType.SceneLogion] = new SceneLogin();
        dicScenes[SceneType.SceneLobby] = new SceneLobby();
        dicScenes[SceneType.SceneGame] = new SceneGame();
    }

    public void OpenScene(SceneType type) {
        Scene scene = null;
        if (dicScenes.TryGetValue(type, out scene)) {
            scene.LoadScene();
        }
    }

    public void CloseScene(SceneType type) {
        Scene scene = null;
        if (dicScenes.TryGetValue(type, out scene)) {
            scene.recycleScene();
        }
    }

    public override void Dispose() {
        base.Dispose();
        if (dicScenes.Count > 0) {
            dicScenes.Clear();
        }
    }
}

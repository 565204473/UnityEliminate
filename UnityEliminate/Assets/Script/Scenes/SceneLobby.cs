using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLobby : Scene {

    public override bool LoadScene() {
        ScenesMgr.Instance.CloseScene(SceneType.SceneLogion);
        UIMgr.OpenPanel<LobbyGameLobbyPanel>();
        return base.LoadScene();
    }

    public override bool recycleScene() {
        return base.recycleScene();
    }
}

using QFramework;
using UnityEngine.SceneManagement;

public class SceneLogin : Scene {

    public override bool LoadScene() {
        UIMgr.OpenPanel<LobbyGameOpenPanel>(prefabName: "Resources/" + UIDefine.LobbyGameOpenPanel);
        return base.LoadScene();
    }

    public override bool recycleScene() {
        SceneManager.LoadScene((int)SceneType.SceneLobby);
        return base.recycleScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class SceneGame : Scene
{
    public override bool LoadScene()
    {
        UIMgr.OpenPanel<LobbyGamePanel>(prefabName: "Resources/" + UIDefine.LobbyGamePanel);
        return base.LoadScene();
    }

    public override bool recycleScene()
    {
        return base.recycleScene();
    }
}

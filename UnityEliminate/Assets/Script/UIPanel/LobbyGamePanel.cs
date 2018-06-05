using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public partial class LobbyGamePanel : QUIBehaviour {

    private string path;
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
        path = FilePath.PersistentDataPath4Res;
    }

    protected override void OnShow() {
        base.OnShow();
        SaveSetting saveSetting = new SaveSetting("1",path);     
        SaveToolsHelp.Save(98, "1", saveSetting);
        SaveSetting saveSetting1 = new SaveSetting("123", path);
        SaveToolsHelp.Save("123", "2",saveSetting1);

        SaveToolsHelp.Load<string>("2",saveSetting);
        SaveToolsHelp.Load<int>("1", saveSetting1);
    }

    protected override void OnHide() {
        base.OnHide();
    }
}

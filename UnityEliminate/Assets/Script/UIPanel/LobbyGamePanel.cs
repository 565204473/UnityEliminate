using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public partial class LobbyGamePanel : QUIBehaviour {

    private string path = FilePath.PersistentDataPath + "/TestSave/B.txt";
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
    }

    protected override void OnShow() {
        base.OnShow();
        SaveSetting saveSetting = new SaveSetting();
        saveSetting.path = path;
        SaveToolsHelp.Save(98, "1", saveSetting);
        SaveToolsHelp.Save("123", "2");

        SaveToolsHelp.Load<string>("2");
        SaveToolsHelp.Load<int>("1", saveSetting);
    }

    protected override void OnHide() {
        base.OnHide();
    }
}

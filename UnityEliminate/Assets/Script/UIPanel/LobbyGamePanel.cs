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

        SaveSetting saveSetting = new SaveSetting("1", path);
        SaveSetting saveSetting1 = new SaveSetting("2", path);
        SaveSetting saveSetting2 = new SaveSetting("3", path);
        SaveSetting saveSetting3 = new SaveSetting("4", path);
        SaveSetting saveSetting4 = new SaveSetting("5", path);
        SaveSetting saveSetting5 = new SaveSetting("6", path);
        SaveSetting saveSetting6 = new SaveSetting("7", path);
        //SaveToolsHelp.Save(98, "1", saveSetting);
        //SaveToolsHelp.Save("123", "2", saveSetting1);
        //SaveToolsHelp.Save(100, "3", saveSetting2);
        //SaveToolsHelp.Save(0.1f, "4", saveSetting3);
        //SaveToolsHelp.Save(0.2f, "5", saveSetting4);
        //SaveToolsHelp.Save(false, "6", saveSetting5);
        //SaveToolsHelp.Save(true, "7", saveSetting6);




        SaveToolsHelp.Load<int>("1", saveSetting);
        SaveToolsHelp.Load<int>("3", saveSetting2);
        SaveToolsHelp.Load<string>("2", saveSetting1);
        SaveToolsHelp.Load<float>("4", saveSetting3);
        SaveToolsHelp.Load<float>("5", saveSetting4);
        SaveToolsHelp.Load<bool>("6", saveSetting5);
        SaveToolsHelp.Load<bool>("7", saveSetting6);
    }

    protected override void OnHide() {
        base.OnHide();
    }
}

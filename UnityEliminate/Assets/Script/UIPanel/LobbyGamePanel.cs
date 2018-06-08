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
        SaveToolsHelp.Save(98, "1", saveSetting);
        SaveToolsHelp.Save("123", "2", saveSetting1);
        SaveToolsHelp.Save(100, "3", saveSetting2);
        SaveToolsHelp.Save(0.1f, "4", saveSetting3);
        SaveToolsHelp.Save(0.2f, "5", saveSetting4);
        SaveToolsHelp.Save(false, "6", saveSetting5);
        SaveToolsHelp.Save(true, "7", saveSetting6);
        SaveToolsHelp.Save(111, "8");
        SaveToolsHelp.Save(999, "9");

        Vector2 ve = new Vector2(88, 88);
        SaveToolsHelp.Save(ve, "10", SaveImplementType.ImplementXML);
        SaveToolsHelp.Save(66, "11", SaveImplementType.ImplementXML);

        //Debug.LogError(SaveToolsHelp.Load<int>("1", saveSetting));
        //Debug.LogError(SaveToolsHelp.Load<int>("3", saveSetting2));
        //Debug.LogError(SaveToolsHelp.Load<string>("2", saveSetting1));
        //Debug.LogError(SaveToolsHelp.Load<float>("4", saveSetting3));
        //Debug.LogError(SaveToolsHelp.Load<float>("5", saveSetting4));
        //Debug.LogError(SaveToolsHelp.Load<bool>("6", saveSetting5));
        Debug.LogError(SaveToolsHelp.Load<bool>("100"));
        Debug.LogError(SaveToolsHelp.Load<int>("111"));
        Debug.LogError(SaveToolsHelp.Load<Vector2>("10", SaveImplementType.ImplementXML));
        Debug.LogError(SaveToolsHelp.Load<int>("11", SaveImplementType.ImplementXML));
        //int num = SaveToolsHelp.Load<int>("8");
        //int num1 = SaveToolsHelp.Load<int>("9");
        //Debug.LogError(num + "****" + num1);
    }

    protected override void OnHide() {
        base.OnHide();
    }
}

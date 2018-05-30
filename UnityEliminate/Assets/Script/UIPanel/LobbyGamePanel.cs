using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public partial class LobbyGamePanel : QUIBehaviour {

    protected override void InitUI(IUIData uiData = null)
    {
        base.InitUI(uiData);
    }

    protected override void OnShow()
    {
        base.OnShow();
        SaveToolsHelp.Save(98, "1");
        SaveToolsHelp.Save("123", "2");

        SaveToolsHelp.Load<string>("2");
        SaveToolsHelp.Load<int>("1");   
    }

    protected override void OnHide()
    {
        base.OnHide();
    }
}

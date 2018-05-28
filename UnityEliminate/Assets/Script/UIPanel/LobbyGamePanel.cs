﻿using System.Collections;
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
        GameContainerHelp.CreateView(5, 5);
    }

    protected override void OnHide()
    {
        base.OnHide();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnWrite : ListItem {

    public Text TxtName;
    public Button Btn;
    private EnumSaveTypeKey curKey;
    public override void Init(int index) {
        base.Init(index);
        Btn.onClick.AddListener(OnBtnClick);
    }

    public override void OnRefresh() {
        base.OnRefresh();
        curKey = (EnumSaveTypeKey)base.index;
        TxtName.text = string.Format("写{0}", curKey.ToString());
    }

    private void OnBtnClick() {
        // SaveExampleHelp.WriterType(curKey);
        Debug.LogError(curKey);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRead : MonoBehaviour {

    public Text textName;
    public Button btn;
    private EnumSaveTypeKey curKey;
    public int index;
    void Awake() {
        btn.onClick.AddListener(OnBtnClick);
    }


    public void OnRefresh(EnumSaveTypeKey key) {
        curKey = key;
        textName.text = string.Format("读{0}", key.ToString());
    }

    private void OnBtnClick() {
        SaveExampleHelp.ReaderType(curKey);
    }

}

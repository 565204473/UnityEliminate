using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnWrite : MonoBehaviour {

    public Text TxtName;
    public Button Btn;
    private EnumSaveTypeKey curKey;
    void Awake() {
        Btn.onClick.AddListener(OnBtnClick);
    }


    public void OnRefresh(EnumSaveTypeKey key) {
        TxtName.text =  string.Format("写{0}", key.ToString());
    }

    private void OnBtnClick() {
        switch (curKey) {
            case EnumSaveTypeKey.SaveString:

                break;
        }
    }


}

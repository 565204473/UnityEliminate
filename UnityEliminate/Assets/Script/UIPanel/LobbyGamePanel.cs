using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

enum TestEnum {
    One,
    Two,
    Three
}


public partial class LobbyGamePanel : QUIBehaviour {


    private string[] readTypeName = new string[] { "Int", "Long", "String", "Float" , "Double", "Bool", "Vector2", "Vector3", "Vector4", "Quaternion", "Color", "Enum", "List", "Dictionary", "Byte", "Short",
        "Uint","Ulong","Ushort","Char","DateTime","Array" };
    private ResLoader mResLoader = ResLoader.Allocate();
    private string path;
    private Transform itemRead;
    private Transform itemWrite;
    private BtnRead itemReadData;
    private BtnWrite itemWriteData;
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
        path = FilePath.PersistentDataPath4Res;
        itemRead = mResLoader.LoadSync<GameObject>(PrefabPath.BtnRead).GetComponent<Transform>();
        itemWrite = mResLoader.LoadSync<GameObject>(PrefabPath.BtnWrite).GetComponent<Transform>();
        for (int i = 0; i < readTypeName.Length; i++) {
            itemReadData = itemRead.Instantiate().Parent(readBtnPos)
                .LocalPosition(Vector3.zero)
                .LocalScaleIdentity().GetComponent<BtnRead>();

            if (itemReadData != null) {
                itemReadData.index = i;
                itemReadData.OnRefresh((EnumSaveTypeKey)i + 1);
            }

            itemWriteData = itemWrite.Instantiate().Parent(writeBtnPos)
                 .LocalPosition(Vector3.zero)
                 .LocalScaleIdentity().GetComponent<BtnWrite>();
            if (itemWriteData != null) {
                itemWriteData.OnRefresh((EnumSaveTypeKey)i + 1);
            }

        }
    }


    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        writeBtn[0].onClick.AddListener(OnWriteBtnByteClick);
        writeBtn[1].onClick.AddListener(OnWriteBtnXmlClick);
        writeBtn[2].onClick.AddListener(OnWriteBtnJsonClick);
        writeBtn[3].onClick.AddListener(OnWriteBtnProtoClick);

        readerBtn[0].onClick.AddListener(OnReaderBtnByteClick);
        readerBtn[1].onClick.AddListener(OnReaderBtnXmlClick);
        readerBtn[2].onClick.AddListener(OnReaderBtnJsonClick);
        readerBtn[3].onClick.AddListener(OnReaderBtnProtoClick);
    }


    private void OnWriteBtnByteClick() {
        WriteFileData();
    }


    private void OnWriteBtnXmlClick() {

        WriteFileData(SaveImplementType.ImplementXML);
    }

    private void OnWriteBtnJsonClick() {
        WriteFileData(SaveImplementType.ImplementJson);
    }


    private void OnWriteBtnProtoClick() {

        WriteFileData(SaveImplementType.ImplementProto);
    }


    private void OnReaderBtnByteClick() {
        ReadFileData();
    }

    private void OnReaderBtnXmlClick() {
        ReadFileData(SaveImplementType.ImplementXML);
    }

    private void OnReaderBtnJsonClick() {
        ReadFileData(SaveImplementType.ImplementJson);
    }


    private void OnReaderBtnProtoClick() {
        ReadFileData(SaveImplementType.ImplementProto);
    }

    private void WriteFileData(SaveImplementType type = SaveImplementType.ImplementByte) {
        using (QFramework.Profiler p = new QFramework.Profiler("SaveToolsHelp.Write")) {
            for (int i = 0; i < count; i++) {
                SaveToolsHelp.Write(i, i + "文件", type);
            }
        }
    }

    private void ReadFileData(SaveImplementType type = SaveImplementType.ImplementByte) {
        using (QFramework.Profiler p = new QFramework.Profiler("SaveToolsHelp.Reader")) {
            for (int i = 0; i < count; i++) {
                SaveToolsHelp.Reader<int>(i + "文件", type);
            }
        }
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

        Debug.LogError(SaveToolsHelp.Reader<int>("1"));
    }

    protected override void OnHide() {
        base.OnHide();
    }
}

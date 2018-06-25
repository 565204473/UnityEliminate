using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveExampleHelp {

    public static void WriterType(EnumSaveTypeKey key) {

        switch (key) {
            case EnumSaveTypeKey.SaveString:
                SaveToolsHelp.Write("string类型", "string");
                break;
            case EnumSaveTypeKey.SaveInt:
                SaveToolsHelp.Write(1, "int");
                break;
            case EnumSaveTypeKey.SaveBool:
                SaveToolsHelp.Write(false, "bool");
                break;
            case EnumSaveTypeKey.SaveFolat:
                SaveToolsHelp.Write(0.1f, "folat");
                break;
            case EnumSaveTypeKey.SaveVector2:
                SaveToolsHelp.Write(Vector2.zero, "Vector2");
                break;
            case EnumSaveTypeKey.SaveVector3:
                SaveToolsHelp.Write(Vector3.zero, "Vector3");
                break;
            case EnumSaveTypeKey.SaveVector4:
                SaveToolsHelp.Write(Vector4.zero, "Vector4");
                break;
            case EnumSaveTypeKey.SaveLong:
                long lo = 1;
                SaveToolsHelp.Write(lo, "Long");
                break;
            case EnumSaveTypeKey.SaveQuaternion:
                SaveToolsHelp.Write(Quaternion.identity, "Quaternion");
                break;
            case EnumSaveTypeKey.SaveColor:
                SaveToolsHelp.Write(Color.black, "Color");
                break;
            case EnumSaveTypeKey.SaveDouble:
                double du = 0.1;
                SaveToolsHelp.Write(du, "Double");
                break;
            case EnumSaveTypeKey.SaveEnum:
                SaveToolsHelp.Write(TestEnum.Three, "Enum");
                break;
            case EnumSaveTypeKey.SaveList:

                break;
            case EnumSaveTypeKey.SaveDictionary:

                break;
            case EnumSaveTypeKey.Savebyte:
                byte bt = 1;
                SaveToolsHelp.Write(bt, "byte");
                break;
            case EnumSaveTypeKey.SaveShort:
                short sh = 1;
                SaveToolsHelp.Write(sh, "Short");
                break;
            case EnumSaveTypeKey.SaveUint:
                uint ui = 1;
                SaveToolsHelp.Write(ui, "Uint");
                break;
            case EnumSaveTypeKey.SaveUlong:
                ulong ul = 1;
                SaveToolsHelp.Write(ul, "Ulong");
                break;
            case EnumSaveTypeKey.SaveUshort:
                ushort us = 1;
                SaveToolsHelp.Write(us, "Ushort");
                break;
            case EnumSaveTypeKey.SaveChar:
                char ch = 'A';
                SaveToolsHelp.Write(ch, "char");
                break;
            case EnumSaveTypeKey.SaveDateTime:
                SaveToolsHelp.Write(DateTime.Now, "DateTime");
                break;
            case EnumSaveTypeKey.SaveArray:

                break;
        }
    }

    public static void ReaderType(EnumSaveTypeKey key) {

        switch (key) {
            case EnumSaveTypeKey.SaveString:
                string str = string.Format("{0}/{1}", SaveToolsHelp.Reader<string>("string"), SaveToolsHelp.Reader("string", "string"));
                Debug.LogError(str);
                break;
            case EnumSaveTypeKey.SaveInt:
                string strInt = string.Format("{0}/{1}", SaveToolsHelp.Reader<int>("int"), SaveToolsHelp.Reader("int", 2));
                Debug.LogError(strInt);
                break;
            case EnumSaveTypeKey.SaveBool:
                string strBool = string.Format("{0}/{1}", SaveToolsHelp.Reader<bool>("bool"), SaveToolsHelp.Reader("bool", true));
                Debug.LogError(strBool);
                break;
            case EnumSaveTypeKey.SaveFolat:
                string strFolat = string.Format("{0}/{1}", SaveToolsHelp.Reader<float>("folat"), SaveToolsHelp.Reader("folat", 0.2f));
                Debug.LogError(strFolat);
                break;
            case EnumSaveTypeKey.SaveVector2:
                string strVector2 = string.Format("{0}/{1}", SaveToolsHelp.Reader<Vector2>("Vector2"), SaveToolsHelp.Reader("Vector2", Vector2.one));
                Debug.LogError(strVector2);
                break;
            case EnumSaveTypeKey.SaveVector3:
                string strVector3 = string.Format("{0}/{1}", SaveToolsHelp.Reader<Vector3>("Vector3"), SaveToolsHelp.Reader("Vector3", Vector3.one));
                Debug.LogError(strVector3);
                break;
            case EnumSaveTypeKey.SaveVector4:
                string strVector4 = string.Format("{0}/{1}", SaveToolsHelp.Reader<Vector4>("Vector4"), SaveToolsHelp.Reader("Vector4", Vector4.one));
                Debug.LogError(strVector4);
                break;
            case EnumSaveTypeKey.SaveLong:
                long lo = 2;
                string strLong = string.Format("{0}/{1}", SaveToolsHelp.Reader<long>("Long"), SaveToolsHelp.Reader("Long", lo));
                Debug.LogError(strLong);
                break;
            case EnumSaveTypeKey.SaveQuaternion:
                string strQuayernion = string.Format("{0}/{1}", SaveToolsHelp.Reader<Quaternion>("Quaternion"), SaveToolsHelp.Reader("Quaternion", Quaternion.identity));
                Debug.LogError(strQuayernion);
                break;
            case EnumSaveTypeKey.SaveColor:
                string strColor = string.Format("{0}/{1}", SaveToolsHelp.Reader<Color>("Color"), SaveToolsHelp.Reader("Color", Color.black));
                Debug.LogError(strColor);
                break;
            case EnumSaveTypeKey.SaveDouble:
                Double du = 2;
                string strDouble = string.Format("{0}/{1}", SaveToolsHelp.Reader<double>("Double"), SaveToolsHelp.Reader("Double", du));
                Debug.LogError(strDouble);
                break;
            case EnumSaveTypeKey.SaveEnum:
                string strEnum = string.Format("{0}/{1}", SaveToolsHelp.Reader<Enum>("Enum"), SaveToolsHelp.Reader("Enum", TestEnum.One));
                Debug.LogError(strEnum);
                break;
            case EnumSaveTypeKey.SaveList:

                break;
            case EnumSaveTypeKey.SaveDictionary:

                break;
            case EnumSaveTypeKey.Savebyte:
                byte by = 2;
                string strByte = string.Format("{0}/{1}", SaveToolsHelp.Reader<byte>("byte"), SaveToolsHelp.Reader("byte", by));
                Debug.LogError(strByte);
                break;
            case EnumSaveTypeKey.SaveShort:
                short sh = 2;
                string strShort = string.Format("{0}/{1}", SaveToolsHelp.Reader<short>("Short"), SaveToolsHelp.Reader("Short", sh));
                Debug.LogError(strShort);
                break;
            case EnumSaveTypeKey.SaveUint:
                uint ui = 3;
                string strUint = string.Format("{0}/{1}", SaveToolsHelp.Reader<uint>("Uint"), SaveToolsHelp.Reader("Uint", ui));
                Debug.LogError(strUint);
                break;
            case EnumSaveTypeKey.SaveUlong:
                ulong uo = 4;
                string strUlong = string.Format("{0}/{1}", SaveToolsHelp.Reader<ulong>("Ulong"), SaveToolsHelp.Reader("Ulong", uo));
                Debug.LogError(strUlong);
                break;
            case EnumSaveTypeKey.SaveUshort:
                ushort us = 2;
                string strUshort = string.Format("{0}/{1}", SaveToolsHelp.Reader<ushort>("Ushort"), SaveToolsHelp.Reader("Ushort", us));
                Debug.LogError(strUshort);
                break;
            case EnumSaveTypeKey.SaveChar:
                char cr = 'A';
                string strChar = string.Format("{0}/{1}", SaveToolsHelp.Reader<char>("char"), SaveToolsHelp.Reader("char", cr));
                Debug.LogError(strChar);
                break;
            case EnumSaveTypeKey.SaveDateTime:
                string strDateTime = string.Format("{0}/{1}", SaveToolsHelp.Reader<DateTime>("DateTime"), SaveToolsHelp.Reader("DateTime", DateTime.Now));
                Debug.LogError(strDateTime);
                break;
            case EnumSaveTypeKey.SaveArray:

                break;
        }
    }
}

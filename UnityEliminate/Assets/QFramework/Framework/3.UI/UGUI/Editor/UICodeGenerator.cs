﻿/****************************************************************************
 * Copyright (c) 2017 xiaojun
 * Copyright (c) 2017 imagicbell
 * Copyright (c) 2017 ~ 2018.5 liangxie 
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

namespace QFramework
{
	using System;
	using System.Text;
	using UnityEngine;
	using System.Collections.Generic;
	using UnityEditor;
	using System.IO;
	using System.Linq;

	public class PanelCodeData
	{
		public string                     PanelName;
		public Dictionary<string, string> DicNameToFullName = new Dictionary<string, string>();
		public List<MarkedObjInfo>        MarkedObjInfos    = new List<MarkedObjInfo>();
		public List<ElementCodeData>      ElementCodeDatas  = new List<ElementCodeData>();
	}

	public class ElementCodeData
	{
		public string                     BehaviourName;
		public Dictionary<string, string> DicNameToFullName = new Dictionary<string, string>();
		public List<MarkedObjInfo>        MarkedObjInfos    = new List<MarkedObjInfo>();
		public List<ElementCodeData>      ElementCodeDatas  = new List<ElementCodeData>();
	}
	
	/// <summary>
	/// 存储一些Mark相关的信息
	/// </summary>
	public class MarkedObjInfo
	{
		public string Name;

		public string PathToElement;

		public IUIMark MarkObj;
	}

	public class UICodeGenerator
	{
		[MenuItem("Assets/QFramework - Create UICode")]
		public static void CreateUICode()
		{
			var objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets | SelectionMode.TopLevel);
			var displayProgress = objs.Length > 1;
			if (displayProgress) EditorUtility.DisplayProgressBar("", "Create UIPrefab Code...", 0);
			for (var i = 0; i < objs.Length; i++)
			{
				mInstance.CreateCode(objs[i] as GameObject, AssetDatabase.GetAssetPath(objs[i]));
				if (displayProgress)
					EditorUtility.DisplayProgressBar("", "Create UIPrefab Code...", (float) (i + 1) / objs.Length);
			}

			AssetDatabase.Refresh();
			if (displayProgress) EditorUtility.ClearProgressBar();
		}

		private void CreateCode(GameObject obj, string uiPrefabPath)
		{
			if (obj.IsNotNull())
			{
				var prefabType = PrefabUtility.GetPrefabType(obj);
				if (PrefabType.Prefab != prefabType)
				{
					return;
				}

				var clone = PrefabUtility.InstantiatePrefab(obj) as GameObject;
				if (null == clone)
				{
					return;
				}

				mPanelCodeData = new PanelCodeData();
				Debug.Log(clone.name);
				mPanelCodeData.PanelName = clone.name.Replace("(clone)", string.Empty);
				FindAllMarkTrans(clone.transform, "");
				CreateUIPanelCode(obj, uiPrefabPath);

				AddSerializeUIPrefab(obj);

				GameObject.DestroyImmediate(clone);
			}
		}

		private static string PathToParent(Transform trans, string parentName)
		{
			var retValue = new StringBuilder(trans.name);

			while (trans.parent != null)
			{
				if (trans.parent.name.Equals(parentName))
				{
					break;
				}

				retValue = trans.parent.name.Append("/").Append(retValue);
				trans = trans.parent;
			}

			return retValue.ToString();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="rootTrans"></param>
		/// <param name="curTrans"></param>
		/// <param name="transFullName"></param>
		private void FindAllMarkTrans(Transform curTrans, string transFullName, ElementCodeData parentElementCodeData = null)
		{
			foreach (Transform childTrans in curTrans)
			{
				var uiMark = childTrans.GetComponent<IUIMark>();

				if (null != uiMark)
				{
					if (null == parentElementCodeData)
					{
						if (!mPanelCodeData.MarkedObjInfos.Any(markedObjInfo => markedObjInfo.Name.Equals(uiMark.Transform.name)))
						{
							mPanelCodeData.MarkedObjInfos.Add(new MarkedObjInfo()
							{
								Name = uiMark.Transform.name,
								MarkObj = uiMark,
								PathToElement = PathToParent(childTrans, mPanelCodeData.PanelName)
							});
							mPanelCodeData.DicNameToFullName.Add(uiMark.Transform.name, transFullName + childTrans.name);
						}
						else
						{
							Debug.LogError("Repeat key: " + childTrans.name);
						}
					}
					else
					{
						if (!parentElementCodeData.MarkedObjInfos.Any(markedObjInfo => markedObjInfo.Name.Equals(uiMark.Transform.name)))
						{
							parentElementCodeData.MarkedObjInfos.Add(new MarkedObjInfo()
							{
								Name = uiMark.Transform.name,
								MarkObj = uiMark,
								PathToElement = PathToParent(childTrans, parentElementCodeData.BehaviourName)
							});
							parentElementCodeData.DicNameToFullName.Add(uiMark.Transform.name, transFullName + childTrans.name);
						}
						else
						{
							Debug.LogError("Repeat key: " + childTrans.name);
						}
					}
				}

				if (uiMark is UIElement)
				{
					var elementCodeData = new ElementCodeData {BehaviourName = uiMark.ComponentName};
					if (null == parentElementCodeData)
					{
						mPanelCodeData.ElementCodeDatas.Add(elementCodeData);
					}
					else
					{
						parentElementCodeData.ElementCodeDatas.Add(elementCodeData);
					}

					FindAllMarkTrans(childTrans, transFullName + childTrans.name + "/", elementCodeData);
				}
				else
				{
					FindAllMarkTrans(childTrans, transFullName + childTrans.name + "/", parentElementCodeData);
				}
			}
		}

		private void CreateUIPanelCode(GameObject uiPrefab, string uiPrefabPath)
		{
			if (null == uiPrefab)
				return;
 
			var behaviourName = uiPrefab.name;
 
			var strFilePath = string.Empty;
 
			var prefabDirPattern = QFrameworkSettingData.Load().UIPrefabDir;
 
			if (uiPrefabPath.Contains(prefabDirPattern))
			{
				strFilePath = uiPrefabPath.Replace(prefabDirPattern, GetScriptsPath());
 
			} else if (uiPrefabPath.Contains("/Resources"))
			{
				strFilePath = uiPrefabPath.Replace("/Resources", GetScriptsPath());
			}
			else
			{
				strFilePath = uiPrefabPath.Replace("/" + uiPrefabPath.GetLastDirName(), GetScriptsPath());
			}
 
			strFilePath.Replace(uiPrefab.name + ".prefab", string.Empty).CreateDirIfNotExists();
			
			strFilePath = strFilePath.Replace(".prefab", ".cs");
			
			if (File.Exists(strFilePath) == false)
			{
				UIPanelCodeTemplate.Generate(strFilePath, behaviourName, GetProjectNamespace());
			}
 
			CreateUIPanelComponentsCode(behaviourName, strFilePath);
			Debug.Log(">>>>>>>Success Create UIPrefab Code: " + behaviourName);
		}

		private void CreateUIPanelComponentsCode(string behaviourName, string uiUIPanelfilePath)
		{
			var dir = uiUIPanelfilePath.Replace(behaviourName + ".cs", "");
			var generateFilePath = dir + behaviourName + "Components.cs";

			UIPanelComponentsCodeTemplate.Generate(generateFilePath, behaviourName, GetProjectNamespace(), mPanelCodeData);

			foreach (var elementCodeData in mPanelCodeData.ElementCodeDatas)
			{
				var elementDir = (dir + behaviourName + "/").CreateDirIfNotExists();
				CreateUIElementCode(elementDir, elementCodeData);
			}
		}

		private static void CreateUIElementCode(string generateDirPath, ElementCodeData elementCodeData)
		{
			UIElementCodeTemplate.Generate(generateDirPath + elementCodeData.BehaviourName + "Components.cs",
				elementCodeData.BehaviourName, GetProjectNamespace(), elementCodeData);

			foreach (var childElementCodeData in elementCodeData.ElementCodeDatas)
			{
				var elementDir = (generateDirPath + elementCodeData.BehaviourName + "/").CreateDirIfNotExists();
				CreateUIElementCode(elementDir, childElementCodeData);
			}
		}

		private static void AddSerializeUIPrefab(GameObject uiPrefab)
		{
			var prefabPath = AssetDatabase.GetAssetPath(uiPrefab);
			if (string.IsNullOrEmpty(prefabPath))
				return;

			var pathStr = EditorPrefs.GetString("AutoGenUIPrefabPath");
			if (string.IsNullOrEmpty(pathStr))
			{
				pathStr = prefabPath;
			}
			else
			{
				pathStr += ";" + prefabPath;
			}

			EditorPrefs.SetString("AutoGenUIPrefabPath", pathStr);
		}

		[UnityEditor.Callbacks.DidReloadScripts]
		private static void SerializeUIPrefab()
		{
			var pathStr = EditorPrefs.GetString("AutoGenUIPrefabPath");
			if (string.IsNullOrEmpty(pathStr))
				return;

			EditorPrefs.DeleteKey("AutoGenUIPrefabPath");
			Debug.Log(">>>>>>>SerializeUIPrefab: " + pathStr);

			var assembly = ReflectionExtension.GetAssemblyCSharp();

			var paths = pathStr.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
			var displayProgress = paths.Length > 3;
			if (displayProgress) EditorUtility.DisplayProgressBar("", "Serialize UIPrefab...", 0);
			for (var i = 0; i < paths.Length; i++)
			{
				var uiPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(paths[i]);
				AttachSerializeObj(uiPrefab, uiPrefab.name, assembly);

				// uibehaviour
				var className = GetProjectNamespace() + "." + uiPrefab.name;
				var t = assembly.GetType(className);

				if (displayProgress)
					EditorUtility.DisplayProgressBar("", "Serialize UIPrefab..." + uiPrefab.name, (float) (i + 1) / paths.Length);
				Debug.Log(">>>>>>>Success Serialize UIPrefab: " + uiPrefab.name);
			}

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			if (displayProgress) EditorUtility.ClearProgressBar();
		}

		private static void AttachSerializeObj(GameObject obj, string behaviourName, System.Reflection.Assembly assembly,
			List<IUIMark> processedMarks = null)
		{
			if (null == processedMarks)
			{
				processedMarks = new List<IUIMark>();
			}

			var className = GetProjectNamespace() + "." + behaviourName;
			var t = assembly.GetType(className);
			var com = obj.GetComponent(t) ?? obj.AddComponent(t);
			var sObj = new SerializedObject(com);
			var uiMarks = obj.GetComponentsInChildren<UIElement>(true);

			foreach (var elementMark in uiMarks)
			{
				if (processedMarks.Contains(elementMark))
				{
					continue;
				}

				processedMarks.Add(elementMark);

				var uiType = elementMark.ComponentName;
				var propertyName = string.Format("{0}", elementMark.Transform.gameObject.name);

				if (sObj.FindProperty(propertyName) == null)
				{
					Log.I("sObj is Null:{0}", propertyName);
					continue;
				}

				sObj.FindProperty(propertyName).objectReferenceValue = elementMark.Transform.gameObject;
				AttachSerializeObj(elementMark.Transform.gameObject, elementMark.ComponentName, assembly, processedMarks);
			}

			var marks = obj.GetComponentsInChildren<QUIMark>(true);
			foreach (var elementMark in marks)
			{
				if (processedMarks.Contains(elementMark))
				{
					continue;
				}

				processedMarks.Add(elementMark);

				var propertyName = string.Format("{0}", elementMark.Transform.gameObject.name);
				Log.I(propertyName);
				sObj.FindProperty(propertyName).objectReferenceValue = elementMark.Transform.gameObject;
			}

			sObj.ApplyModifiedPropertiesWithoutUndo();
		}

		private static string GetScriptsPath()
		{
			return QFrameworkSettingData.Load().UIScriptDir;
		}

		private static string GetProjectNamespace()
		{
			return QFrameworkSettingData.Load().Namespace;
		}

		private PanelCodeData mPanelCodeData = null;

		private static readonly UICodeGenerator mInstance = new UICodeGenerator();
	}
}
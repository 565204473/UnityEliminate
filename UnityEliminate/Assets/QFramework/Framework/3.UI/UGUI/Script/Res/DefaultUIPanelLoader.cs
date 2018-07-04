﻿/****************************************************************************
 * Copyright (c) 2017 liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 * https://github.com/liangxiegame/QSingleton
 * https://github.com/liangxiegame/QChain
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

namespace QFramework {
    using UnityEngine;

    /// <summary>
    /// Default
    /// </summary>
    public class DefaultUIPanelLoader : IUIPanelLoader {
        ResLoader mResLoader = ResLoader.Allocate();

        public GameObject LoadPanelPrefab(string panelName) {
# if UNITY_EDITOR
            var retObj = mResLoader.LoadSync<GameObject>(string.Format("Resources/{0}", panelName));
            if (null != retObj) return retObj;
#endif

            return mResLoader.LoadSync<GameObject>(panelName);
        }

        public GameObject LoadPanelPrefab(string assetBundleName, string panelName) {
            return mResLoader.LoadSync<GameObject>(assetBundleName, panelName);
        }

        public void Unload() {
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }
    }
}
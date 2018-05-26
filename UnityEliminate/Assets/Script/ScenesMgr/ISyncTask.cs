using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISyncTask  {

    bool LoadScene();

    bool recycleScene();

    void SelcetScene(SceneType type);

}

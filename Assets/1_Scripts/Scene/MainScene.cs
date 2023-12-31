using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.MainScene;
        Managers.UI.ShowSceneUI<UI_Main>();
        Debug.Log("Enter Main");
        return true;
    }
}

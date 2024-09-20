using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class PanelManager : Singleton<PanelManager>
{
    private Dictionary<string, Panel> _panels;
    private void Awake(){
        _panels = new Dictionary<string,Panel>();
        // _panels = R
    }

    private void LoadPanel(){
        GameObject []panel = Resources.LoadAll<GameObject> ("PanelPrefabs/");
        foreach (GameObject it in panel){
            // _panels.Add(it.name, it)
        }
    }
}

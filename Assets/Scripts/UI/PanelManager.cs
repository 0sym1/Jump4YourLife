using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private Dictionary<string, Panel> _panels;
    private void Start(){
        _panels = new Dictionary<string,Panel>();
        LoadPanel();
    }

    private void LoadPanel(){
        Panel []panel = Resources.LoadAll<Panel> ("PanelPrefabs/");
        foreach (Panel it in panel){
            _panels.Add(it.name, it);
            Debug.Log(it.name);
        }
    }

    public Panel GetPanel(string name){
        Panel panel = _panels[name];
        return panel;
    }
    public void OpenPanel(string name)
    {
        Panel panel = GetPanel(name);
        panel.OpenPanel();
    }
    public void ClosePanel(string name)
    {
        Panel panel = GetPanel(name);
        panel.ClosePanel();
    }
    
}

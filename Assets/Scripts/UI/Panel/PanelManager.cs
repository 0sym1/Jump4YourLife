using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private Dictionary<string, Panel> _panelDictionary;
    private void Start(){
        _panelDictionary = new Dictionary<string,Panel>();
        LoadPanel();
    }

    private void LoadPanel(){
        Panel []panel = Resources.LoadAll<Panel> (GameConfig.PanelResourcePath);
        foreach (Panel it in panel){
            _panelDictionary.Add(it.name, it);
        }
    }

    public Panel GetPanel(string name){
        Panel panelPrefab = _panelDictionary[name];
        var panel = Instantiate(panelPrefab, transform);
        return panel;
    }
    public void OpenPanel(string name)
    {
        Panel panel = GetPanel(name);
        panel.Open();
    }
    public void ClosePanel(string name)
    {
        Panel panel = GetPanel(name);
        panel.Close();
    }
    
}

using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private Dictionary<string, Panel> _panelPrefabDict;
    
    private void Start(){
        _panelPrefabDict = new Dictionary<string, Panel>();
        LoadPanel();
    }

    private void LoadPanel(){
        Panel[] panel = Resources.LoadAll<Panel>(GameConfig.PanelResourcePath);
        foreach (Panel p in panel){
            _panelPrefabDict.Add(p.name, p);
            Debug.Log(p.name);
        }
    }
    
    public Panel CreatePanel(string panelName){
        Panel panelPrefab = _panelPrefabDict[panelName];
        var panel = Instantiate(panelPrefab, transform);
        panel.Init(panelName);
        return panel;
    }

    public Panel OpenPanel(string panelName){
        Panel panel = CreatePanel(panelName);
        panel.OpenPanel();
        return panel;
    }
    
    // public void ClosePanel(string panelName)
    // {
    //     Panel panel = OpenPanel(panelName);
    //     panel.ClosePanel();
    // }
}
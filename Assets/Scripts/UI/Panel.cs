using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Singleton<Panel>
{
    [SerializeField] protected GameObject panelPrefab;
    protected string panelName;
    public void ClosePanel(){panelPrefab.SetActive(false);}
}

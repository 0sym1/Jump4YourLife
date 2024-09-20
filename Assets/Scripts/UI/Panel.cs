using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Singleton<Panel>
{
    protected GameObject panelPrefab;
    protected string panelName;

    private void Awake(){
        panelPrefab = gameObject;
    }
    public void ClosePanel(){gameObject.SetActive(false);}
    public void OpenPanel(){gameObject.SetActive(true);}
    public void RemovePanel(){Destroy(gameObject);}
}

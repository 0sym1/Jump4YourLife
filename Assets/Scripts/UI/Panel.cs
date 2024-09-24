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
    public void OpenPanel(){
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.activeInHierarchy);
        Debug.Log(gameObject.activeSelf);
        gameObject.SetActive(true);
        Debug.Log(gameObject.activeInHierarchy);
        Debug.Log(gameObject.activeSelf);
        }
    public void RemovePanel(){Destroy(gameObject);}
}

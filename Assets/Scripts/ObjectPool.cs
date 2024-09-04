using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private int _amount;
    private List<GameObject> _listObjects;
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject _Objects;

    void Awake(){
        _amount = 10;
        _listObjects = new List<GameObject>(_amount);
        for(int i=1 ; i <= _amount ; i++){
            GameObject tmp = Instantiate(_object);
            tmp.transform.parent = _Objects.transform;
            tmp.SetActive(false);
            _listObjects.Add(tmp);
        }
    }

    public GameObject GetFromPool(){
        foreach(GameObject obj in _listObjects){
            if(obj.activeInHierarchy == false){
                return obj;
            }
        }
        GameObject tmp = Instantiate(_object);
        tmp.SetActive(false);
        _listObjects.Add(tmp);
        _amount++;
        return tmp;
    }

}

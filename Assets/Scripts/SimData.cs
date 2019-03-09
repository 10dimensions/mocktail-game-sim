using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimData : MonoBehaviour
{   
    private static SimData _instance;
    public static SimData Instance
    {
        get{return _instance;}
    }

    void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    } 

}

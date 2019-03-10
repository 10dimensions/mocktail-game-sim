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

    public string[] FruitsMenu={"Banana",
                                "Apple",
                                "Orange",
                                "Grapes",
                                "Pineapple",
                                "Lemon"};
    public Dictionary<string,int> FruitPrepTime;  // FruitTyp and Timer

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

    void Start()
    {
        AddToDict();
    }

    private void AddToDict()
    {
        FruitPrepTime = new Dictionary<string,int>();

        FruitPrepTime.Add("Banana", 5);
        FruitPrepTime.Add("Apple", 8);
        FruitPrepTime.Add("Orange", 4);

        FruitPrepTime.Add("Grapes", 4);
        FruitPrepTime.Add("Pineapple", 10);
        FruitPrepTime.Add("Lemon", 4);
    }

}

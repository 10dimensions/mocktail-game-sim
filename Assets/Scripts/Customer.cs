using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Customer : MonoBehaviour
{   
    public class CustomerOrder
    {
        private List<string> _orderList;
        private int _orderTime; 

        public List<string> OrderList
        {   get{return _orderList;}
            set{_orderList = value;}
        }

        public int OrderTime
        {   get{return _orderTime;}
            set{_orderTime = value;}
        }
    }

    ////
    
    public CustomerOrder Order;

    void Awake()
    {
       Order = new CustomerOrder();
       //PlaceOrder();
    }

    private void PlaceOrder()
    {   
        int len = SimData.Instance.FruitsMenu.Length;

        string rand1 =SimData.Instance.FruitsMenu[Random.Range(0, len)];
        string rand2 =SimData.Instance.FruitsMenu[Random.Range(0, len)];
        string rand3 =SimData.Instance.FruitsMenu[Random.Range(0, len)];
       
        Order.OrderList = new List<string>{rand1,rand1,rand1};
        Order.OrderTime = Random.Range(50,70);

    }
}

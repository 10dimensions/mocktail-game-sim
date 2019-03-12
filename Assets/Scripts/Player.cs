using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private string KeyUp;
    [SerializeField] private string KeyLeft;
    [SerializeField] private string KeyRight;
    [SerializeField] private string KeyPick;
    [SerializeField] private string KeyDrop;
    public LayerMask GroundLayer;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float TurnSpeed; 
    [SerializeField] private bool CanMove = true;

    [SerializeField] private int HoldFruitCount=3;
    [SerializeField] private bool HoldMug=false;

    [SerializeField] private List<string> GetFruits;
    [SerializeField] private List<string> JuiceMocktail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(CanMove)
        {
            MoveForward(); 
            TurnRightAndLeft();

            PickAndPlaceCheck();
        }
    }

    private void MoveForward()
    {
    
        if(Input.GetKey(KeyUp))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0,MoveSpeed * Time.deltaTime,0);
        }
    
    }
 
    private void TurnRightAndLeft()
    {
    
        if(Input.GetKey(KeyRight)) //Right arrow key to turn right
        {
            transform.Rotate(-Vector3.forward *TurnSpeed*20* Time.deltaTime);
        }
    
        if(Input.GetKey(KeyLeft))//Left arrow key to turn left
        {
            transform.Rotate(Vector3.forward *TurnSpeed*20 * Time.deltaTime);
        }
    
    }

    private void PickAndPlaceCheck()
    {
        if(Input.GetKeyDown(KeyPick))
        {
            RayCastCheck();
        }

        if(Input.GetKeyDown(KeyDrop))
        {
            RayDropCheck();
        }
    }

    private void RayCastCheck()
    {   
        var hit = Physics2D.Raycast(transform.position, transform.up, 4f, GroundLayer);

         if (hit.collider != null)
        {   
            string hitcollider = hit.collider.tag;

           if(hitcollider == "Apple" || hitcollider == "Orange" || hitcollider == "Banana" ||
                hitcollider == "Grapes" || hitcollider == "Pineapple" || hitcollider == "Lemon")
            {
                StoreFruits(hit.collider.tag);
            }

            else if(hitcollider == "Juicer")
            {
                BeginMocktail(hit.collider.tag);
            }
            else if(hitcollider == "Juicer")
            {
                CustomerDelivery();
            }
            
        }
        //Debug.DrawRay(transform.position, transform.up, Color.green, 0.1f);

    }


     private void RayDropCheck()
    {   
        var hit = Physics2D.Raycast(transform.position, transform.up, 4f, GroundLayer);

         if (hit.collider != null)
        {   

            string hitcollider = hit.collider.tag;

            if(hitcollider == GetFruits[GetFruits.Count-1])
            {
                DropFruits(hit.collider.tag);
            }
            
        }

    }


    private void StoreFruits(string _nam)
    {
       if(HoldFruitCount>0)
        {
            //add to list
            GetFruits.Add(_nam);
            HoldFruitCount--;

            //update ui
        }
    }

    private void DropFruits(string _fruit)
    {
        if(HoldFruitCount == 0)
        {
            // remove from list
            GetFruits.RemoveAt(GetFruits.IndexOf(_fruit));
            HoldFruitCount++;
            //update ui
        }
    }

    private void BeginMocktail(string _nam)
    {
        //get last item from list 
        

        //start timer 
        //return juicer list
    }

    private void CustomerDelivery()
    {

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private string KeyUp;
    [SerializeField] private string KeyLeft;
    [SerializeField] private string KeyRight;
    [SerializeField] private string KeyPick;
    public LayerMask GroundLayer;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float TurnSpeed; 
    [SerializeField] private bool CanMove = true;

    [SerializeField] private int HoldFruitCount=2;
    [SerializeField] private bool HoldMug=false;

    private List<string> GetFruits;
    private List<string> JuiceMocktail;

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
    }

    private void RayCastCheck()
    {   
        var hit = Physics2D.Raycast(transform.position, transform.up, 4f, GroundLayer);

         if (hit.collider != null)
        {
            switch(hit.collider.tag)
            {
                case "Apple":
                    StoreFruits(hit.collider.tag);
                break;

                case "Orange":
                    StoreFruits(hit.collider.tag);
                break;

                case "Banana":
                    StoreFruits(hit.collider.tag);
                break;

                case "Grapes":
                    StoreFruits(hit.collider.tag);
                break;

                case "Pineapple":
                    StoreFruits(hit.collider.tag);
                break;

                case "Lemon":
                    StoreFruits(hit.collider.tag);
                break;

                case "Juicer":
                    BeginMocktail(hit.collider.tag);
                break;

                case "Customer":
                    CustomerDelivery();
                break;

            }
            
        }
        Debug.DrawRay(transform.position, transform.up, Color.green, 0.1f);

    }

    private void StoreFruits(string _nam)
    {
        if(HoldFruitCount == 0)
        {
            // remove from list
            GetFruits.RemoveAt(GetFruits.IndexOf(_nam));

            //update ui
        }

        else if(HoldFruitCount>0)
        {
            //add to list
            GetFruits.Add(_nam);

            //pdate ui
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
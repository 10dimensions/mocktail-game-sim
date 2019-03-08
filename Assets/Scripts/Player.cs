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

    private int HoldFruitCount=2;
    private bool HoldMug=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(); 
        TurnRightAndLeft();

        PickAndPlaceCheck();
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
            print(hit.collider.tag);
        }
        Debug.DrawRay(transform.position, transform.up, Color.green, 0.1f);

        //print("raycast done");
    }

    // private void OnCollisionStay2D(Collision2D coll)
    // {
    //     print(coll.gameObject.tag);
    // }
}
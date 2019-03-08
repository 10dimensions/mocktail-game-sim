using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private string KeyUp;
    [SerializeField] private string KeyLeft;
    [SerializeField] private string KeyRight;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float TurnSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(); 
        TurnRightAndLeft();
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
            transform.Rotate(-Vector3.forward *TurnSpeed*20f* Time.deltaTime);
        }
    
        if(Input.GetKey(KeyLeft))//Left arrow key to turn left
        {
            transform.Rotate(Vector3.forward *TurnSpeed*20f* Time.deltaTime);
        }
    
    }
}

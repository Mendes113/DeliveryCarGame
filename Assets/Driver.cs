using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
   
    [SerializeField] float turnSpeed = 1.5f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] bool boost = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
         transform.Rotate(0,0, -turnAmount);
        transform.Translate(0,moveAmount,0);
        bool teste = true;
        
    }


    public void Boost(){
        moveSpeed = 5f;
        boost = true;
        
    }

    public void stopBoost(){
        if(boost){
            moveSpeed = 2f;
        }
       
    }
}

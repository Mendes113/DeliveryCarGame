using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
         [SerializeField] Color32 hasPackageColor = new Color32(241, 8, 8, 255);
          [SerializeField] Color32 hasNotPackageColor = new Color32(50, 0, 90, 255);
    bool heat = false;
         SpriteRenderer spriteRenderer = null;


    void Start(){



        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = hasNotPackageColor;
        
    }

     [SerializeField] float destroyDelay = 0.5f;
        bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
         heat = true;
          if(heat){
             Driver driver = FindObjectOfType<Driver>();
             driver.stopBoost();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "package" && !hasPackage)
        {
            Debug.Log("package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Costumer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
             Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasNotPackageColor;
        }

        if(other.tag == "Boost"){
            Debug.Log("Boost");
            Destroy(other.gameObject, destroyDelay);
            Driver driver = FindObjectOfType<Driver>();
            driver.Boost();


        }

       
    }
}

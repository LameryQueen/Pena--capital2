using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encenderLuces : MonoBehaviour
{
    public Light miluzcarcel1;
    public Light miluzcarcel2;
    public Light miluzcarcel3;
    public Light miluzcarcel4;
    public Light miluzcarcel5;
    public Light miluzcarcel6;
    public Light miluzcarcel7;
   public GameObject objectToCheck;
    // Start is called before the first frame update
    void Start()
    {
         miluzcarcel1.enabled = false;
         miluzcarcel2.enabled = false;
         miluzcarcel3.enabled = false;
         miluzcarcel4.enabled = false;
        miluzcarcel5.enabled = false;
         miluzcarcel6.enabled = false;
         miluzcarcel7.enabled = false;
    }

    // Update is called once per frame
     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToCheck)
        {
           // miluz1.enabled = !miluz1.enabled;
          //  miluz2.enabled = !miluz2.enabled;

            miluzcarcel1.enabled = true;
            miluzcarcel2.enabled = true;
            miluzcarcel3.enabled = true;
            miluzcarcel4.enabled = true;
            miluzcarcel5.enabled = true;
            miluzcarcel6.enabled = true;
            miluzcarcel7.enabled = true;
           // Debug.Log("ha entrado");
        }
    }
       
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagarluces : MonoBehaviour
{
    public Light miluz1;
    public Light miluz2;
    public Light miluz3;
    public Light miluz4;
   public GameObject objectToCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToCheck)
        {
           // miluz1.enabled = !miluz1.enabled;
          //  miluz2.enabled = !miluz2.enabled;

            miluz1.enabled = false;
            miluz2.enabled = false;
            miluz3.enabled = false;
            miluz4.enabled = false;
           // Debug.Log("ha entrado");
        }
    }
       
    
}

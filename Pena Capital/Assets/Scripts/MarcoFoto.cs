using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
public class MarcoFoto : MonoBehaviour
{
    public string[] fotos;
    public int activated;
    public string[] comprobar;
    public InventoryManager IM;
    public GameObject Inventory;
    private bool inRange;
    private bool espera;

    void Awake()
    {
        DisplayText.Instance.onTuto = false;
        espera = false;
        fotos = new string[4];
        activated=0;
        IM = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        foreach (GameObject x in Resources.FindObjectsOfTypeAll<GameObject>())
            if (((GameObject)x).CompareTag("Inventory"))
                Inventory = x;

    }
    public void Update(){
        FirstPersonController characterController = GameObject.FindGameObjectWithTag("FirstPersonController").GetComponent<FirstPersonController>();
        if(Vector3.Distance(transform.position, characterController.transform.position) <= 3)
        {inRange=true;}
        else{inRange=false;}
    }
    private void OnMouseDown()
    {
        if (inRange){
            if(activated<4){
            StartCoroutine("AddPhoto");
            }
        }
    }
    private IEnumerator AddPhoto(){
        if (!Inventory.activeSelf)
        {
            if (activated<4)
            {
                if (IM.selected != null)
                {
                    foreach(var x in comprobar)
                    {
                        //foreach (var y in fotos)
                        //{
                            
                            if (IM.selected.itemName == x)
                            {
                                GameObject.Find(x+"Marco").GetComponent<Renderer>().enabled = true;
                                fotos[activated]=x;
                                activated++;
                                var itemNameFull = IM.SelectedContent.GetChild(0).name;
                                var itemName = itemNameFull.Substring(0,itemNameFull.Length-7);
                                var objectContent = IM.ItemContent.Find(itemName);
                                var objectSelected = IM.SelectedContent.GetChild(0);
                                GameObject.DestroyImmediate(objectContent.gameObject);
                                GameObject.DestroyImmediate(objectSelected.gameObject);
                                IM.Remove(IM.selected);
                                IM.selected = null;
                                espera = true; 
                                if (activated<4){
                                    DisplayText.Instance.changeText("usado " + x);
                                    yield return new WaitForSeconds(2);
                                    DisplayText.Instance.changeText("");

                                }
                                if (activated==4){
                                DisplayText.Instance.changeText("Creo recordar...");
                                yield return new WaitForSeconds(2);
                                DisplayText.Instance.changeText("que sucedio algo en el lavabo");
                                yield return new WaitForSeconds(3);
                                DisplayText.Instance.changeText("");
                                yield return new WaitForSeconds(4);
                                DisplayText.Instance.changeText("Hasta aqui la beta");
                                yield return new WaitForSeconds(2);
                                DisplayText.Instance.changeText("Gracias por jugar");
                                yield return new WaitForSeconds(2);
                                DisplayText.Instance.changeText("");
                                }
                                espera = false;
                                break;
                            }
                        //}
                    }
                }
            }
        }
    }
    void OnMouseOver()
    {  
        if(!espera){
            if (inRange){
                if (activated<4){
                    if (!Inventory.activeSelf){
                        DisplayText.Instance.changeText("Poner foto");
                    }
                    else{
                        DisplayText.Instance.changeText("");
                    }
                }
                else{
                    DisplayText.Instance.changeText("");
                }
            }
            else{
                DisplayText.Instance.changeText("");
            }
        }
    }
    void OnMouseExit()
    {
        if(!espera){
        DisplayText.Instance.changeText("");
        }
    }
}
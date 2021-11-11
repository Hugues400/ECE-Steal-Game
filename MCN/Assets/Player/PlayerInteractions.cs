using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // Start is called before the first frame update

    public float characterReach;
    public Item current;
    public Item mem;
    public Camera PlayerCamera;

    void Start()
    {
        current = null;
        mem = null;
        characterReach = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void FixedUpdate()
    {
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit, characterReach, LayerMask.GetMask("Items Raycast")))
        {
            //Debug.Log("Ray detection");
            mem = hit.collider.GetComponent<Item>();

            if(current != null)
            {
                //Boucle normale : on regarde l'objet
                if(current == mem)
                {
                    //Debug.Log("Hello there");
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Interact(current);
                    }
                }
                //Boucle : plusieurs objets sur le raycast
                else if(current != mem)
                {
                    //Debug.Log("Double interactible");
                    current.OutlineStop();
                    mem.OutlineStart();
                }
            }
            
        }
        //Aucune détection
        else
        {
            //Debug.Log("Bye then!");
            if(current != null)
            {
                current.OutlineStop();
                current = null;
            }
        }
        current = mem;
    }*/

    void Interact(Item i)
    {
        i.Interaction();
    }

}

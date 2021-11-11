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

    public int selector;
    public int bag_size;
    public GameObject[] bag;

    void Start()
    {
        current = null;
        mem = null;
        characterReach = 20f;
        selector = 0;
        bag_size = 5;
        bag = new GameObject[5];
        //PlayerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerCamera.transform.localPosition.x.ToString());
        //Debug.DrawRay(PlayerCamera.transform.position, (PlayerCamera.transform.position + PlayerCamera.transform.forward), Color.red, Time.deltaTime, false);
    }

    void FixedUpdate()
    {
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit, characterReach/*, LayerMask.GetMask("Items Raycast")*/))
        {
            mem = hit.collider.GetComponent<Item>();

            if(current == null)
            {
                current = mem;
            }
            else
            {
                //Boucle normale : on regarde l'objet
                if(current == mem)
                {
                    Debug.Log("Hello there");
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
            Debug.Log("nope");
            if(current != null)
            {
                Debug.Log("Bye then!");
                current.OutlineStop();
                current = null;
                mem = null;
            }
        }
    }

    void Interact(Item i)
    {
        if(selector < bag_size)
        {
            Debug.Log("Picking up item");
            bag[selector++] = i.gameObject;
            i.Interaction();
        }
        
    }

}

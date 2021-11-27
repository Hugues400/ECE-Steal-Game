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

    public int playerScore;

    public float throwForce;

    public GameObject questManager;

    public Catch_Object Sound;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        current = null;
        mem = null;
        characterReach = 20f;
        selector = -1;
        bag_size = 5;
        bag = new GameObject[5];
        playerScore = 0;
        PlayerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Sound = GameObject.Find("CatchObject").GetComponent<Catch_Object>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerCamera.transform.localPosition.x.ToString());
        //Debug.DrawRay(PlayerCamera.transform.position, (PlayerCamera.transform.position + PlayerCamera.transform.forward), Color.red, Time.deltaTime, false);
        if(selector > -1 && Input.GetMouseButtonDown(0))
        {
            Throw(bag[selector].GetComponent<Item>());
            bag[selector] = null;
            selector --;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(selector);


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
                    //Debug.Log("Hello there");
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Interact(current);
                        Sound.PlaySound();

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
            //Debug.Log("nope");
            if(current != null)
            {
                //Debug.Log("Bye then!");
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
            selector++;
            bag[selector] = i.gameObject;
            i.Interaction();
        }
        
    }

    void Throw(Item i)
    {
        Rigidbody item = i.gameObject.GetComponent<Rigidbody>();


        Vector3 throwVect = PlayerCamera.transform.position;
        //throwVect.z += 4;
        //throwVect.y += 0.5f;
        i.gameObject.transform.position = throwVect;

        i.gameObject.SetActive(true);
        //son lacher objet
        
        item.velocity = Vector3.zero;
        item.AddForce(PlayerCamera.transform.forward*throwForce);

        item.angularVelocity = Vector3.zero;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(Random.Range(-50.0f, 20.0f), 0, Random.Range(-30.0f, 70.0f)) * Time.fixedDeltaTime);
        item.MoveRotation(item.rotation * deltaRotation);

        Quest[] quests = questManager.GetComponents<Quest>();

        if (quests.Length > 0)
        {
            for (int j=0; j< quests.Length; j++){
                quests[j].trackQuest("Throw");
            }
        }

        
    }

}

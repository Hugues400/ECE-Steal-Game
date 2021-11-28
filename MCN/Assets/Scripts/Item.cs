using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Item : MonoBehaviour
{
    public Outline outline; 

    public int weight;

    public string type;

    public bool is_triggered;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.AddComponent(typeof(Outline)) as Outline;
        OutlineStop();
        weight = (int) gameObject.GetComponent<Rigidbody>().mass;
        is_triggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interaction()
    {
        gameObject.SetActive(false);
    }
    public void OutlineStart()
    {
        outline.enabled = true;
    }
    public void OutlineStop()
    {
        outline.enabled = false;
    }
}

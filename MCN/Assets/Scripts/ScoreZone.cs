using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    PlayerInteractions pi;
    Scoremanager sm;
    // Start is called before the first frame update
    void Start()
    {
        pi = GameObject.Find("First Person Player").GetComponent<PlayerInteractions>();
        sm = GameObject.Find("Points").GetComponent<Scoremanager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Item it = other.gameObject.GetComponent<Item>();
        if(it != null && it.is_triggered == false)
        {
            it.is_triggered = true;
            pi.playerScore += it.weight*10 + 30;
            sm.refreshPoints(pi.playerScore);
            Debug.Log("Scored points");
        }
        
    }
}

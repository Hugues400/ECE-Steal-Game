using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public int questTracker;
   
    public int goal;

    public string title;
    public string type;

    // Start is called before the first frame update
    void Start()
    {
        questTracker = 0;
    }

    public void setAttributes(string t, int g, string ty)
    {
        title = t;
        goal = g;
        type = ty;
    }

    public void trackQuest(string type)
    {
        if (type == "Throw"){
            questTracker++;
            Debug.Log(questTracker);
        }
        if(checkEnd())
        {
            endQuest();
        }
    }

    public bool checkEnd (){
        if(questTracker>=goal)
            return true;
        else
            return false;

    } 

    public void endQuest()
    {
        Debug.Log("END QUEST");
        Destroy (this);
    }


}

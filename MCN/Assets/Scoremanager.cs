using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public Text scoreText;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Points: 0";
    }

    // Update is called once per frame
    public void AddPoints(int points)
    {
        scoreText.text = "Points: " + points.ToString();
    }
}

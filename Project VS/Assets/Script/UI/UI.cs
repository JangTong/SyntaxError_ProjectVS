using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider health;
    public Slider boost;
    private bool boolboost;

    void Update()
    {
        health.value = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetHealth();
        boolboost = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetBooster();
        if(boolboost == true) boost.value = 0;
        else boost.value = 1;
    }
}
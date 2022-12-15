using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider health;
    public Slider boost;
    private bool boolboost;

    void Start()
    {
        health.maxValue = Player.Instance.GetMaxHealth();
    }

    void Update()
    {
        health.value = Player.Instance.GetHealth();
        boolboost = Player.Instance.GetBooster();
        if(boolboost == true) boost.value = 0;
        else boost.value = 1;
    }
}
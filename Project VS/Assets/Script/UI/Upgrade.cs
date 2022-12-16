using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text select1;
    public TMP_Text select2;
    public TMP_Text select3;
    string[] wep = {"Gun", "Backshot", "DamageField", "Laser"};
    int[] upgrades = {0, 0, 0};

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if(Player.Instance.levelup)
        {
            panel.SetActive(true);

            if(Player.Instance.isRandom)
            {
                for(int i = 0; i<3; i++)
                {
                    upgrades[i] = Random.Range(0, 3);
                }
                Player.Instance.isRandom = false;
            }
            

            select1.text = wep[upgrades[0]];
            select2.text = wep[upgrades[1]];
            select3.text = wep[upgrades[2]];

            if(Input.GetKey(KeyCode.Alpha1))
            {
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
        }
    }

    /*void wepUpgrade(int a)
    {
        if(a == 0)
    }*/
}
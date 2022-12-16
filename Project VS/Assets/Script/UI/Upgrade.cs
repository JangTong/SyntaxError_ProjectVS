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
    Gun GunLV;
    BackShot BackShotLV;
    DmgFieldGenerator DamageFieldLV;
    Laser LaserLV;

    void Start()
    {
        panel.SetActive(false);
        GunLV = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
        BackShotLV = GameObject.FindGameObjectWithTag("Player").GetComponent<BackShot>();
        DamageFieldLV = GameObject.FindGameObjectWithTag("Player").GetComponent<DmgFieldGenerator>();
        LaserLV = GameObject.FindGameObjectWithTag("Player").GetComponent<Laser>();
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
                wepUpgrade(upgrades[0]);
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                wepUpgrade(upgrades[1]);
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                wepUpgrade(upgrades[2]);
                Player.Instance.levelup = false;
                panel.SetActive(false);
            }
        }
    }

    void wepUpgrade(int a)
    {
        if(a == 0) GunLV.weaponLev += 1;
        else if(a == 1) BackShotLV.weaponLev += 1;
        else if(a == 2) DamageFieldLV.weaponLev += 1;
        else LaserLV.weaponLev += 1;
    }
}
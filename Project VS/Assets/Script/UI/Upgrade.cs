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
    int upgradeCount;
    int upgradeNum;

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
        upgradeCount = 0;
        for(int i = 0; i<4; i++) if(wepLevel(i) == 5) upgradeCount += 1;

        if(Player.Instance.levelup)
        {
            if(upgradeCount == 4)
            {
                Player.Instance.levelup = false;
            }

            else
            {
                panel.SetActive(true);

                if(Player.Instance.isRandom)
                {
                    for(int i = 0; i<3; i++)
                    {
                        if(i >= (4 - upgradeCount)) break;
                        do
                        {
                            upgradeNum = Random.Range(0, 4);
                            upgrades[i] = upgradeNum;
                        }
                        while(wepLevel(upgradeNum) == 5);

                    }
                    Player.Instance.isRandom = false;
                }

                select1.text = wep[upgrades[0]];
                if(upgradeCount == 3) select2.text = " ";
                else select2.text = wep[upgrades[1]];
                if(upgradeCount >= 2) select3.text = " ";
                else select3.text = wep[upgrades[2]];

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
            
            if(Player.Instance.levelup == false) GameManager.Instance.ResumeGame();
        }
    }

    void wepUpgrade(int a)
    {
        if(a == 0) GunLV.weaponLev += 1;
        else if(a == 1) BackShotLV.weaponLev += 1;
        else if(a == 2) DamageFieldLV.weaponLev += 1;
        else LaserLV.weaponLev += 1;
    }

    int wepLevel(int a)
    {
        if(a == 0) return GunLV.weaponLev;
        else if(a == 1) return BackShotLV.weaponLev;
        else if(a == 2) return DamageFieldLV.weaponLev;
        else return LaserLV.weaponLev;
    }
}
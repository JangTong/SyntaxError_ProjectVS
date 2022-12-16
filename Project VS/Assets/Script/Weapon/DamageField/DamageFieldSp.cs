using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFieldSp : MonoBehaviour
{
    void Update()
    {
        this.transform.position = Player.Instance.transform.position;
    }
}

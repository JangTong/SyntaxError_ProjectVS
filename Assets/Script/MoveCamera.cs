using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] Transform player;

    void Update()
    {
        Vector3 dir = player.position - transform.position;
        transform.Translate(new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f));
    }
}
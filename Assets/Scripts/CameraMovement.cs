using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        transform.localEulerAngles = new Vector3(60, 0, 0);
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 8f, player.transform.position.z - 3f);
    }
}

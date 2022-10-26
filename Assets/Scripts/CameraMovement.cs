using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        transform.localEulerAngles = new Vector3(40, 0, 0);
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 7f, player.transform.position.z - 5f);
    }
}

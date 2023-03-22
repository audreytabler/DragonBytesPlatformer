using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f; //determines how fast the camera moves
    public Transform target; //player position
    public float yOffset = 1f; //has camera focus up slightly

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3 (target.position.x, target.position.y+yOffset, -10f);
        transform.position = Vector3.Slerp (transform.position, newPos, followSpeed*Time.deltaTime); //interpolates between two positions
    }
}

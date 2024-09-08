using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform player;
    [SerializeField] private float aheadDist;
    [SerializeField] private float camSpeed;
    private float lookAhead;
    public Vector3 offset;

    void Update()
    {
        //get the players position and add it with offset, then store it to transform.position aka the cameras position
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + 4, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDist * player.localScale.x), Time.deltaTime * camSpeed);
    }
}

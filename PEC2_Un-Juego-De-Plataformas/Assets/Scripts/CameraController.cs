using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffset = 5f;
    public float yOffset = 5f;
    public float cameraSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(player.transform.position.x + xOffset > transform.position.x)
        {
            var newPosition = new Vector3(player.transform.position.x + xOffset, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, cameraSpeed * Time.deltaTime);
        }*/
        var newPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraSpeed * Time.deltaTime);

    }
}

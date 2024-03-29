using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    [SerializeField] List<GameObject> Check;
    [SerializeField] Vector3 Playerpoint;
    public float threshold;
    public Vector3 playerPosition;

    private void Update()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(Playerpoint.x,Playerpoint.y,Playerpoint.z);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        { 
            playerPosition = other.transform.position;
            Playerpoint = playerPosition;
            Destroy(other.gameObject);
        }

    }
}

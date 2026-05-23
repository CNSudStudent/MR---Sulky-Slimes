using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public float distanceToMove;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    public float speed = 0.1f;
    public float direction = -1f;

    void Start()
    {
        startingPosition = transform.position;
        endingPosition = new Vector3(
            transform.position.x + distanceToMove,
            transform.position.y,
            transform.position.z
        );
    }

    
    void Update()
    {
        if(transform.position.x < startingPosition.x) {
            speed = -1f;
        }
        if(transform.position.x > endingPosition.x) {
            speed = 1f;
        }
        transform.position = new Vector3(
            transform.position.x + speed * direction * Time.deltaTime,
            transform.position.y,
            transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Slime")
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectable : MonoBehaviour
{
    public float distanceToMove;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    public float speed = 0.1f;
    public float direction = -1f;

    [Header("Scene to Load")]
    public int sceneNumber;

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
            Invoke("LoadNextScene", 2f);
        }
    }

    private void LoadNextScene ()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public int lives;
    public GameObject[] hearts;
    

    public void RemoveLife()
    {
        lives -= 1;
        hearts[lives].SetActive(false);

        if(lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }



}
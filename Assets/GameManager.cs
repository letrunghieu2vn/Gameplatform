using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject GameOverPanel;

    public void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

}

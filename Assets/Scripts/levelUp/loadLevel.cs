using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public int sLevelToLoad;

    public bool useIntegerToLoadLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if(useIntegerToLoadLevel)
        {
            ScreenChange.instance.ScenceChange(iLevelToLoad);
        }
        else
        {
            ScreenChange.instance.ScenceChange(sLevelToLoad);
        }
    }
}

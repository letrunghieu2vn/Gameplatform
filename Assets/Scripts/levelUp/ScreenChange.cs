using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChange : MonoBehaviour
{
    public static ScreenChange instance;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);

        }else
        {
            instance = this;
        }
    }
    public void ThayDoiManChoi(int index)
    {
        SceneManager.LoadScene(index);
    }
}

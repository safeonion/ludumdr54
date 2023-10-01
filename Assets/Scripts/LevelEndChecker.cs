using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndChecker : MonoBehaviour
{
    [SerializeField] private GameObject OutsideAreasContainer;
    [SerializeField] private GameObject RestrictedObjectsContainer;
    static public int levelNum = 1;
    static public bool haram = false;
    [SerializeField] private GameObject PopUpFail;

    public void EndLevelCheck()
    {
        if (IsAnyoneOutside()==false && haram == false)
        {
            Debug.Log("Level Passed");
            haram = false;
            Debug.Log(SceneManager.GetActiveScene().name);
            String sceneName = SceneManager.GetActiveScene().name;
            int sceneNum = Int32.Parse(sceneName);
            if(sceneNum == 6)
            {
                 SceneManager.LoadScene("Main");
            }
            else{SceneManager.LoadScene("" + (sceneNum + 1));}
            
            

        }
        else
        {
            PopUpFail.SetActive(true);
            Debug.Log("No");
        }
    }

    public void Restart() {
        Debug.Log(SceneManager.GetActiveScene().name);
        String sceneName = SceneManager.GetActiveScene().name;
        int sceneNum = Int32.Parse(sceneName);
        SceneManager.LoadScene("" + sceneNum);
    }

    private bool IsAnyoneOutside() 
    {
        foreach (Transform child in OutsideAreasContainer.transform)
        {
            Collider2D childCollider = child.GetComponent<Collider2D>();
            foreach (Transform item in RestrictedObjectsContainer.transform)
            {
                Collider2D itemCollider = item.GetComponent<Collider2D>();
                if (childCollider.IsTouching(itemCollider))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void CloseFail()
    {
        PopUpFail.SetActive(false);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

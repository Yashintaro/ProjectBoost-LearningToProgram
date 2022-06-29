using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Your adventure has begin!");
                break;
            case "Fuel":
                Debug.Log("Your fuel has increased by 15%");
                break;
            case "Finish":
                Debug.Log("You completed the level!");
                break;
            default:
                ReloadScene();
                break;
        }
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}

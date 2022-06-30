using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 0f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip landingSound;
    Rigidbody rb;
    AudioSource audioSource;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Your adventure has begin!");
                break;
            case "Finish":
                Debug.Log("test");
                StartLandingSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false; // Disables player movement
        Invoke("ReloadScene", invokeDelay);
    }
    void StartLandingSequence()
    {
        // todo add SFX upon landing
        // todo add particle effect upon landing
        audioSource.PlayOneShot(landingSound);
        GetComponent<Movement>().enabled = false; // Disables player movement
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll; // Freezes object in place
        Invoke("LoadNextLevel", invokeDelay);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Locates what scene user is currently in
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    void LoadNextLevel()
    {
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Locates what scene user is currently in
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // If there are no more scenes, go back to scene 0
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }    
    }
}

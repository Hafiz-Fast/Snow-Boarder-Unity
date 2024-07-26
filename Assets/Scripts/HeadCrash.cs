using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeadCrash : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem CrashEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            CrashEffect.Play();
            this.GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

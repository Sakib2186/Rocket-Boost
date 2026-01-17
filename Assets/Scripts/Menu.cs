using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource ads;

    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(clip);
        }
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

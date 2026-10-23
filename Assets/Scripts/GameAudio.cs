
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance;

    public AudioSource engineSource;
    public AudioSource effectSource;

    public AudioClip engineSound;
    public AudioClip crashSound;
    public AudioClip successSound;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (engineSound != null)
        {
            engineSource.clip = engineSound;
            engineSource.loop = true;
            engineSource.Play();
        }
    }

    public void PlayCrash()
    {
        engineSource.Stop();

        if (crashSound != null)
            effectSource.PlayOneShot(crashSound);
    }


public void PlaySuccess()
{
    if (successSound == null || effectSource == null)
        return;

    effectSource.Stop();
    effectSource.clip = successSound;
    effectSource.loop = false;
    effectSource.Play();

    CancelInvoke(nameof(StopSuccessSound));
    Invoke(nameof(StopSuccessSound), 0.5f);
}

void StopSuccessSound()
{
    effectSource.Stop();
}

}

using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource ac;

    private AudioClip soundRef;
    private AudioClip[] arrayRef;

    private void Awake()
    {
        ac = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip sound)
    {
        if (!ac.isPlaying)
        {
            ac.PlayOneShot(sound);
        }
    }
    public void PlayRandomSound(AudioClip[] sounds)
    {
        arrayRef = sounds;
        ac.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
    }
}

using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioSource ac;
    [SerializeField]
    private AudioClip confirmSFX;
    private void Awake()
    {
        ac = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        if (!ac.isPlaying)
        {

        }
    }
}

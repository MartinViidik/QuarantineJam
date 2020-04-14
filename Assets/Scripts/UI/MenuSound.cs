using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private AudioSource ac;

    [SerializeField]
    private AudioClip confirmSFX;
    private void OnEnable()
    {
        ac = GetComponent<AudioSource>();
    }
    public void PlayConfirmSound()
    {
        float volumeScale = Random.Range(0.5f, 0.75f);
        float pitch = Random.Range(0.85f, 1f);
        ac.pitch = pitch;
        ac.PlayOneShot(confirmSFX, volumeScale);
    }
}

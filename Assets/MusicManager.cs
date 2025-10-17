using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;

    [Header("Audio Settings")]
    public float pauseDuration = 1f;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        if (musicSource != null)
        {
            musicSource.loop = false;
            StartCoroutine(PlayMusicWithPause());
        }
    }

    IEnumerator PlayMusicWithPause()
    {
        while (true)
        {
            if (musicSource != null && musicSource.clip != null)
            {
                musicSource.Play();
                yield return new WaitForSeconds(musicSource.clip.length);
                yield return new WaitForSeconds(pauseDuration);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            StopAllCoroutines();
            musicSource.Stop();
        }
    }
}

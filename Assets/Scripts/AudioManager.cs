using UnityEngine.Audio;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public GameObject theme;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void PlaySkeleton()
    {
        Sound S = sounds[Random.Range(3,4)];
        S.source.Play();
    }

    public void InventoryHover()
    {
        Play("InventoryHover");
    }

    public void playHover()
    {
        Play("Hover3");
    }

    public void playQuit()
    {
        theme.SetActive(false);
        Play("Quit");
        Invoke("nesto", 4f);
        Application.Quit();
    }

    // FindObjectOfType<AudioManager>().Play("FinishHim");
    //  Tako mogu pozvati u bilo kojoj klasi 
}



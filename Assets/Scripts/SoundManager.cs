using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public List<SoundProperties> soundProperties = new List<SoundProperties>();
    private Dictionary<string, AudioSource> sfxMap = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (var item in soundProperties)
        {
            GameObject go = new GameObject();
            go.transform.parent = transform;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = item.clip;
            source.volume = item.volume;
            source.loop = false;
            source.playOnAwake = false;
            sfxMap.Add(item.name, source);
        }
    }

    public void PlaySFX(string sfxName)
    {
        if (sfxMap.ContainsKey(sfxName))
        {
            sfxMap[sfxName].Play();
        }
        else
        {
            Debug.LogWarning("Could not find a sound name " + sfxName);
        }
    }
}

[Serializable]
public class TPair<TKey, TValue>
{
    public TKey key;
    public TValue value;
}

[Serializable]
public class SoundProperties
{
    public string name;
    public AudioClip clip;
    [Range(0.0f, 1.0f)] public float volume;
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public List<TPair<string, AudioClip>> audioClips = new List<TPair<string, AudioClip>>();
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
        foreach (var item in audioClips)
        {
            GameObject go = new GameObject();
            go.transform.parent = transform;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = item.value;
            source.loop = false;
            source.playOnAwake = false;
            sfxMap.Add(item.key, source);
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

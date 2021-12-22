using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    public string sfxName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        SoundManager.instance.PlaySFX(sfxName);
    }
}

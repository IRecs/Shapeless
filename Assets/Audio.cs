using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audio;
    [SerializeField] private AudioSource _source;
    
    private void Start() =>
        StartCoroutine(Play());

    private IEnumerator Play()
    {
        for( int i = 0; i < _audio.Count; i++ )
        {
            _source.clip = _audio[i];
            _source.Play();
            yield return new WaitForSeconds(_audio[i].length);

            if(i + 1 >= _audio.Count)
                i = 0;
        }
    }
}

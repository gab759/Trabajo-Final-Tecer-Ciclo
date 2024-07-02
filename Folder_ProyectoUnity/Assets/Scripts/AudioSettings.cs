using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    [Range(0f, 3f)] public float masterVolume = 1.5f;
    [Range(0f, 3f)] public float musicVolume = 1.5f;
    [Range(0f, 3f)] public float sfxVolume = 1.5f;
}

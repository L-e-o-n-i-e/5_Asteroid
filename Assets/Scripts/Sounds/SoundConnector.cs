using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConnector : AbstractConnector
{
    public AudioClip Win;
    public AudioClip Lose;
    public AudioSource audioSource;

    public override void Connect()
    {
        LevelManager.Instance.Win = Win;
        LevelManager.Instance.Lose = Lose;
        ShipManager.Instance.Lose = Lose;
        LevelManager.Instance.audioSource = audioSource;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip playerShotSFX, playerDeadSFX, enemyDeadSFX, enemyShotSFX;
    [SerializeField] [Range(0, 1)] float masterVolume = 1f;
    [SerializeField] [Range(0, 1)] float sFXVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerDeadVolume = 1f;
    [SerializeField] [Range(0, 1)] float enemyShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float enemyDeadVolume = 1f;

    public void TriggerPlayerShotSFX()
    {
        AudioSource.PlayClipAtPoint(playerShotSFX, Camera.main.transform.position, playerShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerPlayerDeadSFX()
    {
        AudioSource.PlayClipAtPoint(playerDeadSFX, Camera.main.transform.position, playerShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerEnemyShotSFX()
    {
        AudioSource.PlayClipAtPoint(enemyShotSFX, Camera.main.transform.position, enemyShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerEnemyDeadSFX()
    {
        AudioSource.PlayClipAtPoint(enemyDeadSFX, Camera.main.transform.position, enemyShotVolume * (sFXVolume * masterVolume));
    }
}

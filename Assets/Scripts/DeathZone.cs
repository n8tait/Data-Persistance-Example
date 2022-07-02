using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        //Manager.m_Points = MenuManager.Instance.highScore;
        Manager.GameOver();
    }
}

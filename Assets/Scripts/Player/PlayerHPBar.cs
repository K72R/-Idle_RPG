using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Slider hpSlider;

    private void Update()
    {
        if (PlayerStats.Instance != null)
        {
            hpSlider.value = (float)PlayerStats.Instance.currentHp / PlayerStats.Instance.maxHp;
        }

        if (Camera.main != null)
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
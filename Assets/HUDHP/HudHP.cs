using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHP : MonoBehaviour
{
    private Image _hpImage;
    
    void Start()
    {
        _hpImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBar();
    }

    private void UpdateLifeBar()
    {
        var value = Playercontroller.P.life.health / Playercontroller.P.life.maxHp;
        
        value = (value > 1) ? 1f : value;
        value = (value < 0) ? 0f : value;
        
        _hpImage.fillAmount = value;
    }
}

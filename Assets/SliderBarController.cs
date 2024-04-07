using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SliderBarController : MonoBehaviour
{
    public GameObject hand;

    public string find;

    private HandStaminaProvider staminaValue;

    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find(find);
        staminaValue = hand.GetComponent<HandStaminaProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = staminaValue.staminaCurrValue;
    }
}

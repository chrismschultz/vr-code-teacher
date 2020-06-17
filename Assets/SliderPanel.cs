using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPanel : MonoBehaviour
{
    public sliderID id; 

    public enum sliderID
    {
        distance, size
    };

    public Slider slider;
    public TextMeshProUGUI textBox;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(id == sliderID.distance)
        {
            float distanceValue = slider.value * 5f;
            textBox.text = distanceValue.ToString("F2");
        }else if(id == sliderID.size)
        {
            textBox.text = slider.value.ToString("F2");
        }

        
    }
}

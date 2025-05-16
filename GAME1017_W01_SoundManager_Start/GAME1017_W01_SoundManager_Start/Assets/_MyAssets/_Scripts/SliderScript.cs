using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] TMP_Text value;
    private Slider sl;
    private float valstart;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<Slider>();
        valstart = value.transform.position.x;
        sl.minValue = 0.0f;
        sl.maxValue = 1.0f;
        sl.value = 1.0f; // Default to full volume
    }

    // Update is called once per frame
    void Update()
    {
        value.text = sl.value.ToString("F2");

        value.transform.position = new Vector3(handle.transform.position.x, value.transform.position.y, value.transform.position.z);
    }
}

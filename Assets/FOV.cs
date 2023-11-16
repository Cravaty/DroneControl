using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOV : MonoBehaviour
{

    Text currentText;

    // Start is called before the first frame update
    void Start()
    {
        currentText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float Value)
    {
        currentText.text = Mathf.RoundToInt( Value).ToString();
    }
}

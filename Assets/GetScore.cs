using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{

    public TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Score : " + PlayerPrefs.GetInt("score", 0);
    }
}

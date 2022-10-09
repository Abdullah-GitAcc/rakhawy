using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score, _time;
    private float _timer = 0;
    private float _seconds;
    private float _minutes;
    private string MinutesString = "";
    private string SecondString = "";
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score: " + 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
         _minutes = Mathf.Floor(_timer / 59);
        _seconds = Mathf.RoundToInt(_timer % 59);

    

        if (_minutes < 10)
        {
            MinutesString = "0" + _minutes.ToString();
        }
        else
        {
            MinutesString = _minutes.ToString();
        }
        if (_seconds < 10)
        {
            SecondString = "0" + Mathf.RoundToInt(_seconds).ToString();
        }
        else
        {
            SecondString = _seconds.ToString();
        }

        _time.text = "Time : " + MinutesString + ":"+ SecondString;        
    }
    public void ViewScore(int Score)
    {
        _score.text = "Score: " + Score;
    }
}

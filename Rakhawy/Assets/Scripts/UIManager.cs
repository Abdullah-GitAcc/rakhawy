using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score, _time, _StreakCounter;
    private float _timer = 0;
    private float _seconds;
    private float _minutes;
    private string MinutesString = "";
    private string SecondString = "";
    [SerializeField]
    private GameObject _Bar;
    [SerializeField]
    private float _KillStreakDoration;
    [SerializeField]
    private GameObject _mainBar;
    public bool _StillOnStreak = false;
    public int StreakCounter = 0;
    public bool EndOfStreak = false;
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

    public void StartStreak()
    {

        if (_StillOnStreak == false)
        {
            _Bar.transform.localScale = new Vector3(1, 1, 1);
            _mainBar.SetActive(true);
            _StillOnStreak = true;
            
            AnimateBar();
        }
        if(_StillOnStreak == true)
        {
            LeanTween.cancel(_Bar);
            _Bar.transform.localScale = new Vector3(1, 1, 1);
            Streak();
            AnimateBar();
        }



    }
    public void AnimateBar()
    {
        LeanTween.scaleX(_Bar, 0, _KillStreakDoration).setOnComplete(BarAction);


    }
    public void BarAction()
    {
        EndOfStreak = true;
        _mainBar.SetActive(false);
        _StillOnStreak = false;
    }
    public void Streak()
    {
        StreakCounter++;
        _StreakCounter.text = "Kill Streak:" + StreakCounter;
    }
    public void ViewScore(float Score)
    {
        _score.text = "Score: " + Score;
    }
}

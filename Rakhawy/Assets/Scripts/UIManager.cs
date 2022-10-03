using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ViewScore(int Score)
    {
        _score.text = "Score: " + Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private SpawnManager _Spawn;
    private Player _p;
    private UIManager _ui;
    public bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        _Spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        _p = GameObject.Find("Player").GetComponent<Player>();

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if(_Spawn._isdead == true)
        {
            Time.timeScale = 0.1f;
        }
        if (_p.IsDead == true)
        {
            
                if (_ui._timer < 120)
                {
                    _p._score += _ui._timer;
                    _ui.ViewScore(_p._score);
                    _p.IsDead = false;
                }
                else
                {
                    _p._score += _ui._timer * 2;
                    _ui.ViewScore(_p._score);
                    _p.IsDead = false;
            }
            
        }
    }
}

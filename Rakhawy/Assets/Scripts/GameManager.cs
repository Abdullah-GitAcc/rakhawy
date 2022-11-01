using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private SpawnManager _Spawn;
    // Start is called before the first frame update
    void Start()
    {
        _Spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _EnemyContainer;
    public bool _isdead = false;
    private float[] EnemyDirction = { 90f, -90f };
    private int arraylength;

    // Start is called before the first frame update
    void Start()
    {
        arraylength = EnemyDirction.Length;
        StartCoroutine(EnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_isdead == false)
        {
            int chosenEnemy = Random.Range(0, arraylength);

            Vector3 Enemy_Spawn = new Vector3(16f, Random.Range(-6.8f, 6.8f), EnemyDirction[chosenEnemy]);
            GameObject NewEnemy = Instantiate(_EnemyPrefab, Enemy_Spawn, Quaternion.AngleAxis(EnemyDirction[chosenEnemy],new Vector3(0,0,1)));
            NewEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(5f);

        }
    }


}

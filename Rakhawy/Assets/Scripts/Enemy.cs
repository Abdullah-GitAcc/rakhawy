using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigi;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _BackSpeed = 2f;
    private Player p;
    private SpawnManager _SpawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        p = GameObject.Find("Player").GetComponent<Player>();
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_SpawnManager == null)
        {
            Debug.Log("Spawn is NUll");
        }
        if (p == null)
        {
            Debug.Log("Player is NULL");

        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyMovement());
        if (transform.position.x > 14.5f)
        {
            transform.position = new Vector2(-14.5f, transform.position.y);
        }
        if (transform.position.x < -14.5f)
        {
            transform.position = new Vector2(14.5f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Weapon")
        {
            p.Enemy1 = true;
            p.SetScore();
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            _SpawnManager._isdead = true;
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(p.gameObject);
        }
    }
    IEnumerator EnemyMovement()
    {
        while (true)
        {
            if (transform.rotation.eulerAngles.z == 90f)
            {
                _rigi.AddForce(Vector2.left * _speed, ForceMode2D.Force);
                yield return new WaitForSeconds(5f);
                _rigi.AddForce(Vector2.right * _BackSpeed, ForceMode2D.Force);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                _rigi.AddForce(Vector2.right * _speed, ForceMode2D.Force);
                yield return new WaitForSeconds(5f);
                _rigi.AddForce(Vector2.left * _BackSpeed, ForceMode2D.Force);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}

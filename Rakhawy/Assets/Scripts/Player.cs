using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    private Vector2 Dir;
    private Rigidbody2D _rigi;
    private UIManager _ui;
    private int _score = 0;
    private Quaternion _lookRotation;
    [SerializeField]
    private float RotationSpeed = 5f;
    private float _angle;
    [SerializeField]
    private GameObject _attack;
    [SerializeField]
    private float _attackSpeed = 4f;
    public bool Enemy1 = false;
    public bool collectable1 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_ui == null)
        {
            Debug.Log("UI_Manager is null");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + 90f;


            _rigi.AddForce(Dir * _speed, ForceMode2D.Force);
            
        }
        _lookRotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, RotationSpeed * Time.deltaTime);
        if ( _rigi.velocity.magnitude >= _attackSpeed)
        {
            _attack.SetActive(true);
        }
        else
        {
            _attack.SetActive(false);
        }

        if (transform.position.y > 8.5f)
        {
            transform.position = new Vector2(transform.position.x, -8.5f);
        }
        if (transform.position.y < -8.5f)
        {
            transform.position = new Vector2(transform.position.x, 8.5f);
        }
        if (transform.position.x > 14f)
        {
            transform.position = new Vector2(-14f, transform.position.y);
        }
        if (transform.position.x < -14f)
        {
            transform.position = new Vector2(14f, transform.position.y);
        }








        /*  to move to where you click
        if (Input.GetMouseButtonDown(0))
        {
            _lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _moving = true;

        }
        if (_moving && (Vector2)transform.position != _lastClickedPos)
        {
             step = _speed * Time.deltaTime ;
            transform.position = Vector2.MoveTowards(transform.position, _lastClickedPos, step);
            StartCoroutine(Slowing());


        }
        */
    }

    public void SetScore()
    {
        if (collectable1 == true)
        {
            _score += 10;
            _ui.ViewScore(_score);
        }
        if (Enemy1 == true)
        {
            _score += 20;
            _ui.ViewScore(_score);
        }
        collectable1 = false;
        Enemy1 = false;
    }

}

using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]
public class AIChicken : MonoBehaviour
{
    private ParticleSystem _chickenEffect;

    NavMeshAgent nm;
    Rigidbody rb;
    //Animation anim;
    public Transform Target;
    public Transform[] WayPoints;
    public int Cur_WayPoints;
    public float speed, stop_distance;
    public float PauseTimer;

    [SerializeField] private float cur_timer;
    private Animator _animator;

    private int _stateMove;
    private int _stateStand;
    private bool _isMoving = false;

    private GameObject _obj;
    private float _lastScale = 1f;
    private float _timer;
    [SerializeField] private float _timerAbility= 20;



    void Start()
    {
        _chickenEffect = GetComponentInChildren<ParticleSystem>();
        _obj = gameObject;
        gameObject.GetComponent<TapObject>().OnСhangeTime += BigChicken;
        
        _animator = gameObject.GetComponent<Animator>();
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Target = WayPoints[Cur_WayPoints];
        cur_timer = PauseTimer;
        nm.stoppingDistance = stop_distance;
    }

    void FixedUpdate()
    {
        //Settings Updated

        AbilityChicken();

        float distance = Vector3.Distance(transform.position, Target.position);


        //Move to Waypoint
        if(distance > stop_distance && WayPoints.Length > 0)
        {
            if (_isMoving == false)
            {
                _isMoving = true;
                Stand(_stateStand, !_isMoving);
                Move(Random.Range(1,3), _isMoving);
            }
        }
        else if(distance <= stop_distance && WayPoints.Length > 0)
        {
            if(cur_timer > 0)
            {
                cur_timer -= Time.deltaTime;
                if (_isMoving == true)
                {
                    _isMoving = false;
                    Move(_stateMove, _isMoving);
                    Stand(Random.Range(1,3), !_isMoving);
                }
            }
            if (cur_timer <= 0)
            {
                int wayPoints;
                do
                {
                    wayPoints = Random.Range(0, WayPoints.Length);
                } while (Cur_WayPoints == wayPoints);
                Cur_WayPoints = wayPoints;
                
                Target = WayPoints[Cur_WayPoints];
                cur_timer = PauseTimer;
            }
        }

        //nm.SetDestination(Target.position);

    }


    private void Move(int strategy, bool active)
    {
        _stateMove = strategy;
        switch (strategy)
        {
            case 1:
                _animator.SetBool("Walk", active);
                nm.acceleration = speed;
                break;
            case 2:
                _animator.SetBool("Run", active);
                nm.acceleration = speed*2;
                break;
            default:
                break;
        }

        if (active == true)
        {
            Target = WayPoints[Cur_WayPoints];
            nm.SetDestination(Target.position); 
        }
    }

    private void Stand(int strategy, bool active)
    {
        _stateStand = strategy;
        switch (strategy)
        {
            case 1:
                _animator.SetBool("Eat", active);
                break;
            case 2:
                _animator.SetBool("Turn Head", active);
                break;
            default:
                break;
        }
    }

    private void AbilityChicken()
    {
        if (_obj.transform.localScale.x > 1 && Math.Abs(_obj.transform.localScale.x - _lastScale) <= 0)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _obj.transform.localScale = new Vector3(1,1,1);
                Debug.Log("сдувается");
                _chickenEffect.Play();
                /*var scale = Mathf.Round(_objScale.x - 1f);
                _objScale = new Vector3(scale,scale,scale);*/
            }
            
            
            

        }
    }
    
    public void BigChicken(float velu)
    {
        _timer = _timerAbility;
        float scale = (float)Math.Round((_obj.transform.localScale.x + 0.1f)*10)/10;
        _lastScale = scale;
        _obj.transform.localScale = new Vector3(scale,scale,scale); 
       

    }

    private void OnDestroy()
    {
        gameObject.GetComponent<TapObject>().OnСhangeTime -= BigChicken;
    }
}


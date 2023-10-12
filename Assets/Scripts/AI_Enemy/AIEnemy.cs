using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]
public class AIEnemy : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;
    //Animation anim;
    public Transform Target;
    public Transform[] WayPoints;
    public int Cur_WayPoints;
    public int speed, stop_distance;
    public float PauseTimer;
    
    [SerializeField] private float cur_timer;
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Target = WayPoints[Cur_WayPoints];
        cur_timer = PauseTimer;
    }

    void Update()
    {
        //Settings Updated
        nm.acceleration = speed;
        nm.stoppingDistance = stop_distance;

        float distance = Vector3.Distance(transform.position, Target.position);


        //Move to Waypoint
        if(distance > stop_distance && WayPoints.Length > 0)
        {
            _animator.SetTrigger("Run");
            //Animator : Set Bool for moving = True
            //Animator : Set Bool for Idle = false;
            //Find Waypoint
            Target = WayPoints[Cur_WayPoints];
        }
        else if(distance <= stop_distance && WayPoints.Length > 0)
        {
            if(cur_timer > 0)
            {
                cur_timer -= Time.deltaTime;
                _animator.SetTrigger("Idle");
                //Animator : Set Bool for moving = False
                //Animator : Set Bool for Idle = True;
            }
            if (cur_timer <= 0)
            {
                Cur_WayPoints++;
                if (Cur_WayPoints >= WayPoints.Length)
                {
                    Cur_WayPoints = 0;
                }
                Target = WayPoints[Cur_WayPoints];
                cur_timer = PauseTimer;
            }
        }

        nm.SetDestination(Target.position);

    }

    public void GoHuman()
    {
        float distance = Vector3.Distance(transform.position, Target.position);
        if (distance <= stop_distance && WayPoints.Length > 0)
        {
            cur_timer = 0;
        }
    }
}

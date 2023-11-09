using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    #region States
    public IdleState IdleState;
    public FollowState FollowState;
    private State currentState;
    #endregion

    #region Parameters
    public  Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 3f;
    public float Speed = 1f;
    public Transform FirePoint;
    public float CoolDownTime = 1.0f;
    #endregion

    #region Readonly Properties
    public Rigidbody rb {private set; get;}
    public Animator animator {private set; get;}
    public NavMeshAgent agent {private set; get;}
    #endregion

    [SerializeField]
    private float life = 3f;
    private float points;

    private void Awake() 
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Seteamos el estado inicial
        currentState = IdleState;    
    }

    private void Start() 
    {
        currentState.OnStart();
    }

    private void Update() 
    {
        foreach (var transition in currentState.Transitions)
        {
            if (transition.IsValid())
            {
                // Ejecutar Transicion
                currentState.OnFinish();
                currentState = transition.GetNextState();
                currentState.OnStart();
                break;
            }
        }
        currentState.OnUpdate();    
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Te estoy dañando");
        life -= damage;
        if (life <= 0f)
        {
            points = 1;
            FindObjectOfType<PointsCounter>().PointsUpdater(points);
            //pointsWatcher.GetComponent<PointsCounter>().PointsUpdater(points);
            Destroy(this.gameObject);
        }
    }
}
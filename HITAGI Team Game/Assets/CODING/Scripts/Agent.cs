using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;
    public Rigidbody2D rb;

    public float rbX;
    public float rbY;
    
    public SpriteRenderer sR;
    public NavMeshAgent agents;
    public float agentsX;
    public float agentsY;

    public bool alreadyHit;

    public Animator animator;
    
    public float timer;
    public float staggerTime;

    public GameObject attackVfx;
    public Vector3 playerPos;
    public Player_Stats playerStatsScript;
    public bool alarm = false;
    public GameObject detector;
    public bool needsDetector;
    public bool isChaser;

    public bool isRanged;
    public float distanceToPlayer;
    public bool onCd = false;
    public bool isChasing = false;
    void Start()
    {
        playerStatsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
        target = this.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = gameObject.GetComponent<Animator>();
        agents = gameObject.GetComponent<NavMeshAgent>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        alreadyHit = false;
        

}

    // Update is called once per frame
    void Update()
    {
        agentsX = agents.velocity.x;
        agentsY = agents.velocity.y;
        Flips();
        agent.SetDestination(target.position);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        distanceToPlayer = Vector3.Distance(playerPos, transform.position);


    }

    void FixedUpdate()
    {
        if (agentsX != 0 || agentsY != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if (agentsX == 0 && agentsY == 0)
        {
            animator.SetBool("IsRunning", false);
        }

        if (isChaser)
        {
            Chase();
        } 
        
        if (distanceToPlayer > 1 && alreadyHit != true)
        {
            agent.isStopped = false;
        }
        
        if (distanceToPlayer <= 1 && isRanged && alreadyHit != true)
        {
            agents.isStopped = true;
            if (onCd != true)
            {
                StartCoroutine(RangedAttack());
                onCd = true;
            }
        }
    }
     public void Flips()
    {
        if (agentsX < 0)
        {
            sR.flipX = false;
            sR.flipX = false;
        }
        if (agentsX > 0)
        {
            sR.flipX = true;
            sR.flipX = true;
        }
    }

    public void Hit()
    {
        Debug.Log("IS HIT");
        target = this.gameObject.transform;
        agents.isStopped = true;
        agents.velocity = Vector3.zero;
        alreadyHit = true;
    }
    public void NotHit()
    {
        Debug.Log("NO HIT");
        alreadyHit = false;
        agents.isStopped = false;
    }

    public void Chase()
    {
        if (isChasing != true)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            detector = gameObject.transform.GetChild(0).gameObject;
            if (needsDetector)
            {
                detector.GetComponent<PlayerDetector>().alarm = true;
            }
        }
    }

    public void Attacked()
    {
        Debug.Log("CHUUUUUUUUUUJ");
        playerStatsScript.IsHit(gameObject.GetComponent<Stats>().damage);
        target = this.gameObject.transform;
        StartCoroutine(Attacked2());
    }

    public IEnumerator Attacked2()
    {
        yield return new WaitForSeconds(0.2f);
        attackVfx.GetComponent<Attack_Vfx_Script>().attacked = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public IEnumerator RangedAttack()
    {
        animator.SetTrigger("IsAttacking");
        yield return new WaitForSeconds(1f);
        onCd = false;
    }

    public void RangedAttack2()
    {
        if (alreadyHit == false)
        {
            var shooting = gameObject.transform.GetChild(1).gameObject;
            shooting.GetComponent<Zombie_Ranged_Attack>().RangedAttacking();
            agents.isStopped = false;
        }
    }
}

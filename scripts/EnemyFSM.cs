using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}
    public EnemyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    NavMeshAgent agent;
    public GameObject bulletPrefab;
    public float fireRate;
    float lastShootTime;

    // Start is called before the first frame update
    void Awake()
    {
        baseTransform = GameObject.Find("MiBase").transform;
        agent = GetComponentInParent<NavMeshAgent>();
        lastShootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if (currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        else if (currentState == EnemyState.AttackPlayer)
        {
            AttackPlayer();
        }
        else if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
    }
    void GoToBase()
    {
        //print("Go to base");
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase <= baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }
    void AttackBase()
    {
        //print("Attack base");
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }
    void ChasePlayer()
    {
        //print("Chase player");
        agent.isStopped = false;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer <= playerAttackDistance )
        {
            currentState = EnemyState.AttackPlayer;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
    }
    void AttackPlayer()
    {
        //print("attack player");
        agent.isStopped = true;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance*1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(transform.position, playerAttackDistance);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, baseAttackDistance);
    //}
    void Shoot()
    {
        if(Time.timeScale>0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
                return;
            lastShootTime = Time.time;
            GameObject clone = Instantiate(bulletPrefab);
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
        }
    }
    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition-transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }
}

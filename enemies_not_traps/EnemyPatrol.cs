using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private bool checkings;

    private void Awake()
    {
        initScale = enemy.localScale;
        movingLeft = true;
        checkings = false;
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x && !checkings)
                MoveInDirection(1);
            else{
                checkings = true;
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x && !checkings)
                MoveInDirection(-1);
            else{
                checkings = true;
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;
        // Debug.Log(idleTimer);
        if(idleTimer > idleDuration){
            // Debug.Log("dir changed");
            idleTimer = 0;
            checkings = false;
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        // idleTimer = 0;
        anim.SetBool("moving", true);
        // Debug.Log("mvoing in " + _direction);
        Debug.Log(transform.tag);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
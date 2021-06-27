using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Tilemap islandMap;
    public GameObject birthPlace;
 
    private Animator anim;
    private PlayerGui playerGui;

    private float h, v;
    [HideInInspector] public bool inWater;
    private float moveSpd;

    // 氧气
    public float maxOxygen = 360;
    private float oxygen;

    //
    private bool died;

    public float walkSpd = 2;
    public float swimSpd = 1f;

    #region FSM
    public StateMachine stateMachine;

    public IdleState idleState;
    public SwimState swimState;
    public WalkState walkState;

    [HideInInspector]
    public int walkingParam = Animator.StringToHash("isWalking");
    [HideInInspector]
    public int swimmingParam = Animator.StringToHash("isSwimming");
    #endregion

    void Start()
    {
        stateMachine = new StateMachine();

        idleState = new IdleState(this, stateMachine);
        swimState = new SwimState(this, stateMachine);
        walkState = new WalkState(this, stateMachine);

        stateMachine.Initialize(idleState);

        // 节点
        anim = GetComponent<Animator>();
        playerGui = transform.Find("Canvas").GetComponent<PlayerGui>();

        // 状态
        PlayerReborn();
    }

    void Update()
    {
        inWater = !TileMgr.Instance.HasTile(islandMap, transform.position + new Vector3(0.5f, 0.5f, 0f));

        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();

        //GetInput();
        //Move();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void Move(float _hInput, float _vInput, float _spd)
    {
        Vector3 moveDir = new Vector3(_hInput, _vInput, 0).normalized;
        transform.position += moveDir * _spd * Time.deltaTime;
    }

    public void SetAnimationBool(int param, bool value)
    {
        anim.SetBool(param, value);
    }

    // 水中呼吸
    public void Breathe()
    {
        oxygen -= 0.25f;
        playerGui.UpdateOxygen(oxygen);

        if (oxygen <= 0)
        {
            PlayerDie();
        }
    }

    // 重置氧气。上岸。
    public void ResetOxygen()
    {
        oxygen = maxOxygen;
        playerGui.UpdateOxygen(oxygen);
    }

    void PlayerDie()
    {
        if (died == true) return;

        // TODO: 死亡音效
        died = true;
        FindObjectOfType<GameOverGui>().Play();
    }

    // 玩家复活
    public void PlayerReborn()
    {
        died = false;
        ResetOxygen();
        transform.position = birthPlace.transform.position;
    }

    /*
    void GetInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //keyXPressed = Input.GetKeyDown(KeyCode.X);
    }

    void OldMove()
    {
        inWater = !TileMgr.Instance.HasTile(islandMap, transform.position + new Vector3(0.5f, 0.5f, 0f));
        anim.SetBool("isSwimming", inWater);

        if (inWater)
        {
            Swim();
        }
        else
        {
            Walk();
        }

        moveSpd = inWater ? 1f : 2f;
        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        transform.position += moveDir * moveSpd * Time.deltaTime;
        anim.SetBool("isWalking", moveDir.magnitude > 0);

    }
    */

    /*
    private void Walk()
    {
        ResetOxygen();
    }

    private void Swim()
    {
        oxygen -= 0.25f;
        playerGui.UpdateOxygen(oxygen);

        if (oxygen <= 0)
        {
            PlayerDie();
        }
    }
    */

}

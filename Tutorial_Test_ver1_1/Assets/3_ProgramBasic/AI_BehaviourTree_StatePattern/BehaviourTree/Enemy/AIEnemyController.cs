// SelectorとSequenceのどちらを選ぶかは、AIがどのように振る舞うべきかによって決まります。


// 複数の条件を持つ場合:
// 例えば、HPがしきい値以下の場合に特殊攻撃を行いたい、そうでなければ通常攻撃を行いたい、さらにプレイヤーに近づかなければならない、といった複数の行動があり、いずれかの条件が満たされた時点でその行動を実行したい場合にSelectorを使います。


// 優先度のある条件:
// Selectorは優先度の高い条件から順に評価します。
//例えば、特殊攻撃が優先されるべきであり、次に通常攻撃やプレイヤーに近づく行動が評価されるべき場合に適しています。


// Sequenceが選ばれない理由
// Sequenceノードが選ばれない理由としては、以下の点が考えられます：

// 全ての条件が成功しなければならない:
// Sequenceは全ての子ノードが成功する必要があります。
//例えば、プレイヤーに近づく前にHPをチェックする必要がある場合、一つでも失敗するノードがあると、その全体が失敗と見なされます。

// 単一の条件で成功・失敗を判断:
// Sequenceは全ての子ノードを順番に実行し、全て成功する場合のみ成功と判断します。
// 条件が複数あり、それぞれが独立して成功する場合にはSelectorの方が適しています。


// 結論

// Selectorノードは「または」の条件を評価し、条件のいずれかが満たされた時点で成功と見なします。
//優先度がある場合や、いずれかの条件が満たされれば次のノードに進む必要がない場合に使用します。

// Sequenceノードは「かつ」の条件を評価し、全ての条件が満たされる場合に成功と見なします。
//全ての子ノードが成功する必要がある場合に使用します。

// 今回のシナリオでは、複数の条件の中から1つでも成功すればよいという要件があるため、Selectorが適しています。


namespace GameNamespace.Enemy
{
    using UnityEngine;
    using BehaviourTree;
    using Blackboard;
    using UnityEngine.AI;
    using System.Collections.Generic;
    using GameNamespace.Enemy;

    public class AIEnemyController : MonoBehaviour
    {

/*
    //     private Animator animator;
    //     private NavMeshAgent navMeshAgent;

    //     private Blackboard blackboard;
    //     private Selector behaviourTree;

    //     public EnemyStatus status; // ScriptableObjectのインスタンスを割り当てる
    //     public Transform player;
    //     public float attackRange = 5f;
    //     public float specialAttackRange = 3f;
    //     public float hp = 100f;
    //     public float specialAttackHpThreshold = 20f;
    //     public float detectionRange = 5f;

    //     void Start()
    //     {
    //         if (status == null)
    //         {
    //             Debug.LogError("EnemyStatus is not assigned.");
    //             return;
    //         }

    //         animator     = GetComponent<Animator>();
    //         navMeshAgent = GetComponent<NavMeshAgent>();

    //         // Blackboardにセット
    //         blackboard = new Blackboard();
    //         blackboard.SetValue("player", player);
    //         blackboard.SetValue("hp", hp);
    //         blackboard.SetValue("navMeshAgent", navMeshAgent);
    //         blackboard.SetValue("playerDetected", false);
    //         blackboard.SetValue("isDamaged", false);
    //         blackboard.SetValue("status", status);
    //         blackboard.SetValue("animator", animator);

 
    //         // ノードの初期化
    //         var moveToPlayer  = new MoveToPlayer(blackboard, player, transform, attackRange);
    //         var patrol        = new Patrol(blackboard, transform, 10f);
    //         var specialAttack = new SpecialAttack(blackboard, player, transform, specialAttackRange);
    //         var checkHealth   = new CheckHealth(blackboard, specialAttackHpThreshold);
    //         var stop          = new Stop(blackboard);
    //         var detectPlayer  = new DetectPlayer(blackboard, transform, player, detectionRange);
    //         var receiveDamage = new ReceiveDamage(blackboard);
    //         var die           = new Die(animator);

    //         var attackSelector = new AttackSelector(blackboard, player, transform);

    //         var attack = new Attack(blackboard, player, transform, attackRange);
    //         var comboAttack = new ComboAttack(blackboard, player, transform, attackRange);
    //         var flinch = new Flinch(blackboard);
    //         var resistAttack = new ResistAttack(blackboard);

    //         var randomAttackSelector = new RandomAttackSelector(new List<BTNode> { attack, comboAttack, flinch, resistAttack });


            

    //         // 攻撃シーケンスの構築(すべての子ノードが成功するまで次に進まない)
    //         var attackSequence = new Sequence();
    //         attackSequence.AddChild(receiveDamage);
    //         attackSequence.AddChild(die); // 死亡処理を追加
    //         attackSequence.AddChild(stop);
    //         attackSequence.AddChild(randomAttackSelector);


    //         // メインセレクタの設定(順番に評価し、最初に成功するノードを実行)
    //         var mainSelector = new Selector();
    //         mainSelector.AddChild(specialAttack);
    //         mainSelector.AddChild(attackSequence);
    //         mainSelector.AddChild(moveToPlayer);

    //         // パトロールシーケンスの設定(すべての子ノードが成功するまで次に進まない)
    //         var patrolSequence = new Sequence();
    //         patrolSequence.AddChild(detectPlayer); // プレイヤーを見つけたかどうかを判定
    //         patrolSequence.AddChild(mainSelector);

    //         // 最上位のBehaviour Treeの設定(順番に評価し、最初に成功するノードを実行)
    //         behaviourTree = new Selector();
    //         behaviourTree.AddChild(checkHealth);
    //         behaviourTree.AddChild(patrolSequence);
    //         behaviourTree.AddChild(patrol);

    //     }

    //     void Update()
    //     {
    //         if (status != null && !status.isDead)
    //         {
    //             var state = behaviourTree.Execute();
            
    //             UpdateAnimatorState(state);
    //         }
    //     }

    //     private void UpdateAnimatorState(NodeState state)
    //     {
    //         // Animatorとの状態連携のロジック
    //     }
*/










        // private Selector behaviourTree;
        // private Blackboard blackboard;

        // void Start()
        // {
        //     blackboard = new Blackboard();
        //     blackboard.SetValue("navMeshAgent", GetComponent<NavMeshAgent>());
        //     blackboard.SetValue("player", GameObject.FindWithTag("Player").transform);
        //     blackboard.SetValue("isPlayerDetected", false);
        //     blackboard.SetValue("waypoints", FindObjectOfType<Waypoint>().waypoints);

        //     var patrol = new Patrol(blackboard, transform, 10f);
        //     // var detectPlayer = new DetectPlayer(blackboard, transform, 20f);

        //     var patrolSequence = new Sequence();
        //     // patrolSequence.AddChild(detectPlayer);
        //     patrolSequence.AddChild(patrol);

        //     behaviourTree = new Selector();
        //     behaviourTree.AddChild(patrolSequence);

            
        // }

        // void Update()
        // {
        //     behaviourTree.Execute();
        // }


















        // public Waypoint waypointManager; // Waypointsの管理クラス
        // public float waitTime = 2f; // 次のポイントに移るまでの待機時間

        // private NavMeshAgent navMeshAgent;
        // private int currentWaypointIndex = 0;
        // private float waitTimer;
        // private bool waiting;

        // void Start()
        // {
        //     navMeshAgent = GetComponent<NavMeshAgent>();
        //     if (waypointManager != null)
        //     {
        //         MoveToNextWaypoint();
        //     }
        // }

        // void Update()
        // {
        //     if (waiting)
        //     {
        //         waitTimer += Time.deltaTime;
        //         if (waitTimer >= waitTime)
        //         {
        //             waiting = false;
        //             MoveToNextWaypoint();
        //         }
        //     }
        //     else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        //     {
        //         waiting = true;
        //         waitTimer = 0f;
        //     }
        // }

        // void MoveToNextWaypoint()
        // {
        //     Debug.Log("Moving to next waypoint");
        //     if (waypointManager != null)
        //     {
        //         navMeshAgent.SetDestination(waypointManager.GetNextWaypoint(currentWaypointIndex).position);
        //         currentWaypointIndex++;
        //     }
        // }









        private Selector behaviourTree;
        private NavMeshAgent agent;
        public Waypoint waypointManager;
        // public Transform[] waypoints;
        public Transform player;
        public float detectionRange = 10f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            // Patrolノード
            var patrol = new Patrol(agent, waypointManager);

            // DetectPlayerノード
            // var detectPlayer = new DetectPlayer(transform, player, detectionRange);


            // PlayerDetectedSequenceノードの設定
            var playerDetectedSequence = new Sequence();//攻撃されたか　近づいたかを判定する
            // playerDetectedSequence.AddChild(detectPlayer); // プレイヤー検知ノード
            // playerDetectedSequence.AddChild(attackSequence); // プレイヤーを認識した場合の攻撃シーケンス


            // Selectorノード
            var patrolSelector = new Selector();
            patrolSelector.AddChild(playerDetectedSequence);  //Playerを認知しているかどうかを判定
            patrolSelector.AddChild(patrol);                  // Playerが近くなければパトロールを続ける

            behaviourTree = patrolSelector;
        }

        void Update()
        {
            behaviourTree?.Execute();
        }







    }
}


//例
// var detectPlayer = new ConditionNode(() => playerIsVisible);
// var attackNode = new AttackNode(blackboard);
// var patrolNode = new PatrolNode(blackboard);

// var mainSelector = new Selector();
// mainSelector.AddChild(detectPlayer);
// mainSelector.AddChild(attackNode);

// var rootNode = new Sequence();
// rootNode.AddChild(mainSelector);
// rootNode.AddChild(patrolNode);

// behaviourTree = rootNode;
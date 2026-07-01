using UnityEngine;

namespace InterfacesHW
{
    public class EnemySpawner : MonoBehaviour
    {
        private const float YOffset = 0.6f;

        [SerializeField] private Enemy _enemyPrefab;

        [SerializeField] private RestType _restType;
        [SerializeField] private ReactionType _actionType;

        private Transform _player;

        private void Awake()
        {
            Player player = FindObjectOfType<Player>();

            if (player != null)
                _player = player.transform;
            else
                Debug.LogError("Игрок не найден на сцене");

            Vector3 enemySpawnPosition = new Vector3(transform.position.x, YOffset, transform.position.z);

            Enemy enemy = Instantiate(_enemyPrefab, enemySpawnPosition, Quaternion.identity);

            IRestBehaviour restBehaviour = SelectRestBehaviourFor(enemy);
            IReactionBehaviour reactionBehaviour = SelectReactionBehaviourFor(enemy);

            enemy.Initialize(_player, restBehaviour, reactionBehaviour);
        }

        private IRestBehaviour SelectRestBehaviourFor(Enemy enemy)
        {
            switch (_restType)
            {
                case RestType.Stand:
                    return new StandBehaviour();

                case RestType.Patrol:
                    PatrolPoint[] patrolPoints = GetComponentsInChildren<PatrolPoint>();

                    if (patrolPoints.Length == 0)
                        Debug.LogError("Точки патрулирования не найдены");

                    return new PatrolBehaviour(enemy, patrolPoints);

                case RestType.RandomMove:
                    return new RandomMoveBehaviour(enemy);

                default:
                    Debug.LogError("Некорректный тип поведения в покое");
                    return null;
            }
        }

        private IReactionBehaviour SelectReactionBehaviourFor(Enemy enemy)
        {
            switch (_actionType)
            {
                case ReactionType.RunAway:
                    return new RunAwayBehaviour(enemy, _player);

                case ReactionType.Chase:
                    return new ChaseBehaviour(enemy, _player);

                case ReactionType.Die:
                    ParticleSystem dieEffectPrefab = enemy.DieEffectPrefab;

                    if (dieEffectPrefab == null)
                        Debug.LogError("Префаб партиклов не найден");

                    return new DieBehaviour(enemy, dieEffectPrefab);

                default:
                    Debug.LogError("Некорректный тип поведения при агре");
                    return null;
            }
        }
    }
}
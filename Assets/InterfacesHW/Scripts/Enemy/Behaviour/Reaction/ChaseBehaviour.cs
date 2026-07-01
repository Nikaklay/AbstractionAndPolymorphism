using UnityEngine;

namespace InterfacesHW
{
    public class ChaseBehaviour : IReactionBehaviour
    {
        private const float ChaseSpeed = 3f;

        private Enemy _enemy;
        private Transform _player;

        public ChaseBehaviour(Enemy enemy, Transform player)
        {
            _enemy = enemy;
            _player = player;
        }

        public void DoReactionBehaviour()
        {
            Vector3 playerPosition = new Vector3(_player.position.x, 0, _player.position.z);
            Vector3 enemyPosition = new Vector3(_enemy.transform.position.x, 0, _enemy.transform.position.z);

            Vector3 direction = (playerPosition - enemyPosition).normalized;

            _enemy.transform.Translate(ChaseSpeed * Time.deltaTime * direction, Space.World);
        }
    }
}
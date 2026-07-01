using UnityEngine;

namespace InterfacesHW
{
    public class RunAwayBehaviour : IReactionBehaviour
    {
        private const float RunSpeed = 3f;

        private Enemy _enemy;
        private Transform _player;

        public RunAwayBehaviour(Enemy enemy, Transform player)
        {
            _enemy = enemy;
            _player = player;
        }

        public void DoReactionBehaviour()
        {
            Vector3 playerPosition = new Vector3(_player.position.x, 0, _player.position.z);
            Vector3 enemyPosition = new Vector3(_enemy.transform.position.x, 0, _enemy.transform.position.z);

            Vector3 direction = (enemyPosition - playerPosition).normalized;

            Move(direction);
        }

        private void Move(Vector3 direction)
            =>  _enemy.transform.Translate(RunSpeed * Time.deltaTime * direction, Space.World);
    }
}
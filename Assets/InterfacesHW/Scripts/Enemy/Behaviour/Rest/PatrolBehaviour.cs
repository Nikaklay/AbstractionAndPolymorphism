using UnityEngine;

namespace InterfacesHW
{
    public class PatrolBehaviour : IRestBehaviour
    {
        private const float Gap = 0.05f;
        private const float Speed = 1.5f;

        private Enemy _enemy;
        private PatrolPoint[] _patrolPoints;

        private Vector3 _currentTarget;
        private int _currentIndex;

        public PatrolBehaviour(Enemy enemy, PatrolPoint[] patrolPoints)
        {
            _enemy = enemy;
            _patrolPoints = patrolPoints;
            _currentTarget = _patrolPoints[0].transform.position;
        }

        public void DoRestAction()
        {
            _currentTarget = new Vector3(_currentTarget.x, _enemy.transform.position.y, _currentTarget.z);

            Vector3 direction = _currentTarget - _enemy.transform.position;

            float distanceToTarget = direction.magnitude;

            if (distanceToTarget > Gap)
                Move(direction);
            else
                UpdateTarget();
        }

        private void Move(Vector3 direction)
            => _enemy.transform.Translate(Speed * Time.deltaTime * direction.normalized, Space.World);

        private void UpdateTarget()
        {
            _currentIndex = (_currentIndex + 1) % _patrolPoints.Length;
            _currentTarget = _patrolPoints[_currentIndex].transform.position;
        }
    }
}
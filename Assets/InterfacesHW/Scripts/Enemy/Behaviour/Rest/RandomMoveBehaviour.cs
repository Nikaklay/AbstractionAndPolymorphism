using UnityEngine;

namespace InterfacesHW
{
    public class RandomMoveBehaviour : IRestBehaviour
    {
        private const int MinDirection = -1;
        private const int MaxDirection = 2;
        private const float LimitMoveTime = 1f;
        private const float MoveSpeed = 1.5f;

        private Enemy _enemy;
        private Vector3 _direction;
        private float _timeCounter;

        public RandomMoveBehaviour(Enemy enemy)
        {
            _enemy = enemy;
            _direction = GetDirection();
            _timeCounter = 0;
        }

        public void DoRestAction()
        {
            if (_timeCounter >= LimitMoveTime)
                UpdateMovement();

            _enemy.transform.Translate(MoveSpeed * Time.deltaTime * _direction, Space.World);

            _timeCounter += Time.deltaTime;
        }

        private void UpdateMovement()
        {
            _direction = GetDirection();
            _timeCounter = 0;
        }

        private Vector3 GetDirection()
        {
            int xDirection = Random.Range(MinDirection, MaxDirection);
            int zDirection = Random.Range(MinDirection, MaxDirection);

            Vector3 direction = new Vector3(xDirection, 0, zDirection).normalized;

            return direction;
        }
    }
}
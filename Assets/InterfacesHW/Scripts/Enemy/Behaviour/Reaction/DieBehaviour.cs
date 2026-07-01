using UnityEngine;

namespace InterfacesHW
{
    public class DieBehaviour : IReactionBehaviour
    {
        private Enemy _enemy;
        private ParticleSystem _dieEffectPrefab;

        public DieBehaviour(Enemy enemy, ParticleSystem dieEffectPrefab)
        {
            _enemy = enemy;
            _dieEffectPrefab = dieEffectPrefab;
        }

        public void DoReactionBehaviour()
        {
            ParticleSystem dieEffect = Object.Instantiate(_dieEffectPrefab, _enemy.transform.position, Quaternion.identity);
            
            dieEffect.Play();

            Object.Destroy(_enemy.gameObject);
        }
    }
}
using UnityEngine;

namespace InterfacesHW
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _dieEffectPrefab;

        private AggroDetector _aggroDetector;
        private Transform _target;

        private IRestBehaviour _restBehaviour;
        private IReactionBehaviour _reactionBehaviour;

        private bool _isReactionBehaviourActive;

        public ParticleSystem DieEffectPrefab => _dieEffectPrefab;

        private void Awake()
        {
            _aggroDetector = new AggroDetector();
        }

        public void Initialize(Transform target, IRestBehaviour restBehaviour, IReactionBehaviour reactionBehaviour)
        {
            _target = target;
            _restBehaviour = restBehaviour;
            _reactionBehaviour = reactionBehaviour;

            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = SetColor();
        }

        private void Update()
        {
            _aggroDetector.DrawLineOfAggroRadius(_target, transform);

            _isReactionBehaviourActive = _aggroDetector.IsAggroActive(_target, transform);

            if (_isReactionBehaviourActive)
                _reactionBehaviour.DoReactionBehaviour();
            else
                _restBehaviour.DoRestAction();
        }

        private Color SetColor() => Random.ColorHSV();
    }
}
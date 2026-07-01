using UnityEngine;

namespace InterfacesHW
{
    public class AggroDetector
    {
        private const float AggroRadius = 2.5f;

        public bool IsAggroActive(Transform target, Transform observer)
        {   
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            Vector3 observerPosition = new Vector3(observer.transform.position.x, 0, observer.transform.position.z);

            float currentDistance = (targetPosition - observerPosition).magnitude;

            bool isAggroActive = currentDistance <= AggroRadius;

            return isAggroActive;
        }

        public void DrawLineOfAggroRadius(Transform target, Transform observer)
            => Debug.DrawLine(observer.position, observer.position + (target.position - observer.position).normalized * AggroRadius);
    }
}
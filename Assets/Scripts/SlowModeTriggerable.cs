using UnityEngine;

namespace Assets.Scripts
{
    public class SlowModeTriggerable : MonoBehaviour
    {

        [HideInInspector] public float fallingSpeed = 0.01f;
        public GameObject mark;

        private Camera fpsCam;                                         


        public void Initialize()
        {
            fpsCam = GetComponentInParent<Camera>();
        }

        public void Slow()
        {
            mark.transform.Translate(new Vector3(0f, -fallingSpeed));

        }

    }
}
using UnityEngine;

namespace Assets.Code
{
    public class Player : MonoBehaviour
    {
        public Vector2 Min;
        public Vector2 Max;
        public float Speed;

        void Update()
        {
            UpdateControls();
        }

        private void UpdateControls()
        {
            var pos = new Vector2(transform.localPosition.x, transform.localPosition.y);
            pos += Speed * Input.GetAxis("Horizontal") * Vector2.right;
            pos += Speed * Input.GetAxis("Vertical") * Vector2.up;
            pos = new Vector2(Mathf.Clamp(pos.x, Min.x, Max.x), Mathf.Clamp(pos.y, Min.y, Max.y));

            transform.localPosition = new Vector3(pos.x, pos.y, transform.localPosition.z);
        }
    }
}

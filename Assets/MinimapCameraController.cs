using UnityEngine;

namespace RollABall
{
    public sealed class MinimapCameraController : MonoBehaviour
    {
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = _player.position + new Vector3(0f, 5.0f, 0f);
            transform.rotation = Quaternion.Euler(90.0f, 0f, 0f);

            var texture = Resources.Load<RenderTexture>("Minimap/MinimapTexture");

            GetComponent<Camera>().targetTexture = texture;
        }

        private void LateUpdate()
        {
            var newPos = _player.position;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
    }
}

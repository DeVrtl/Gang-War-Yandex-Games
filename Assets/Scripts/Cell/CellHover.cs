using UnityEngine;

namespace GangWar.Cell
{
    using GangWar.Unit;

    [RequireComponent(typeof(MeshRenderer), typeof(BoxCollider))]
    public class CellHover : MonoBehaviour
    {
        [SerializeField] private Material _standart;
        [SerializeField] private Material _bright;

        private BoxCollider _boxCollider;

        public MeshRenderer Renderer { get; private set; }

        public UnitFollowMouse UnitInCell { get; private set; }

        private void Awake()
        {
            Renderer = GetComponent<MeshRenderer>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UnitFollowMouse unit))
            {
                Renderer.material = _bright;
                UnitInCell = unit;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out UnitFollowMouse unit))
            {
                Renderer.material = _standart;
                UnitInCell = null;
            }
        }

        public void SwitchToStandartMaterial()
        {
            Renderer.material = _standart;
        }

        public void DisableCollider()
        {
            _boxCollider.enabled = false;
        }
    }
}
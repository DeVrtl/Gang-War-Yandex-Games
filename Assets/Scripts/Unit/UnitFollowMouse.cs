using UnityEngine;

public class UnitFollowMouse : MonoBehaviour
{
    private Camera _main;
    private Plane _floor;

    private void Start()
    {
        _main = Camera.main;

        _floor = new Plane(Vector3.up, Vector3.zero);
    }

    private void Update()
    {
        Ray ray = _main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && _floor.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);

            transform.position = hitPoint;
        }
    }
}
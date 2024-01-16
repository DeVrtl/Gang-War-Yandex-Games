using System.Collections.Generic;
using UnityEngine;

namespace GangWar.Unit
{
    public class UnitSpawner : MonoBehaviour
    {
        public List<Unit> Units { get; private set; } = new List<Unit>();

        public void Spawn(Unit unit)
        {
            GameObject unitGameObject = Instantiate(unit.gameObject);

            Unit spawnedUnit = unitGameObject.transform.GetComponent<Unit>();

            Units.Add(spawnedUnit);
        }
    }
}
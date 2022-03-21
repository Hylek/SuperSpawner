using System;
using PrototypePattern;
using Units;
using UnityEngine;

namespace GenericSystems
{
    public enum UnitType
    {
        Soldier, Tank, Gunner
    }
    
    public class UnitFactory : MonoBehaviour
    {
        public static Unit GetUnit(UnitType type)
        {
            return type switch
            {
                UnitType.Soldier => UnitPool.Instance.GetUnit("Soldier"),
                UnitType.Tank => UnitPool.Instance.GetUnit("Tank"),
                UnitType.Gunner => UnitPool.Instance.GetUnit("Gunnar"),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
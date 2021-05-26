using ScriptableObjects;
using System;
using UnityEngine;

[Serializable]
class Spawner
{
    [SerializeField]
    private SpawnerType _spawnerType;
    [SerializeField]
    private Vector3 _position;

    public SpawnerType SpawnerType => _spawnerType;
    public Vector3 Position => _position;
}

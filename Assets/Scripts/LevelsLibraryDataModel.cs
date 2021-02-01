using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class LevelsLibraryDataModel
{
    public List<CampaingDataModel> campaings;
    public LevelsLibraryDataModel(List<CampaingDataModel> _campaings)
    {
        campaings = _campaings;
    }
}
[Serializable]
public class CampaingDataModel
{
    public TranslationVariantDataModel nameTranslations;
    public TranslationVariantDataModel descriptionTranslations;
    public List<LevelDataModel> levels;
    public CampaingDataModel(TranslationVariantDataModel _nameTranslations, TranslationVariantDataModel _descriptionTranslations, List<LevelDataModel> _levels)
    {
        nameTranslations = _nameTranslations;
        descriptionTranslations = _descriptionTranslations;
        levels = _levels;
    }
}
[Serializable]
public class TranslationVariantDataModel
{
    public string english;
    public string russian;
    public TranslationVariantDataModel(string _english, string _russian)
    {
        english = _english;
        russian = _russian;
    }
}
[Serializable]
public class LevelDataModel
{
    public TranslationVariantDataModel nameTranslations;
    public TranslationVariantDataModel descriptionTranslations;
    public Vector3 cameraPosition;
    public Quaternion lightRotation;
    public List<PlaneDataModel> planes;
    public List<TerrainDataModel> terrains;
    public List<BuildingSlotDataModel> buildingSlots;
    public List<WaveDataModel> waves;
    public List<PathVariantDataModel> pathVariants;
    public LevelDataModel(TranslationVariantDataModel _nameTranslations, TranslationVariantDataModel _descriptionTranslations, Vector3 _cameraPosition, Quaternion _lightRotation,
        List<PlaneDataModel> _planes, List<TerrainDataModel> _terrains, List<BuildingSlotDataModel> _buildingSlots, List<WaveDataModel> _waves)
    {
        nameTranslations = _nameTranslations;
        descriptionTranslations = _descriptionTranslations;
        cameraPosition = _cameraPosition;
        lightRotation = _lightRotation;
        planes = _planes;
        terrains = _terrains;
        buildingSlots = _buildingSlots;
        waves = _waves;
    }
}
[Serializable]
public class PlaneDataModel
{
    public Vector3 position;
    public PlaneDataModel(Vector3 _position)
    {
        position = _position;
    }
}
[Serializable]
public class TerrainDataModel
{
    public int type;
    public Vector3 position;
    public Quaternion rotation;
    public TerrainDataModel(int _type, Vector3 _position, Quaternion _rotation)
    {
        type = _type;
        position = _position;
        rotation = _rotation;
    }
}
[Serializable]
public class BuildingSlotDataModel
{
    public Vector3 position;
    public Quaternion rotation;
    public BuildingSlotDataModel(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
[Serializable]
public class WaveDataModel
{
    public float spawnTime;
    public float waveTime;
    public int waveCost;
    public List<SubwaveDataModel> subwaves;
    public WaveDataModel(float _spawnTime, float _waveTime, int _waveCost, List<SubwaveDataModel> _subwaves)
    {
        spawnTime = _spawnTime;
        waveTime = _waveTime;
        waveCost = _waveCost;
        subwaves = _subwaves;
    }
}
[Serializable]
public class SubwaveDataModel
{
    public int id;
    public List<int> enemiesCodes;
    public int pathVariantCode;
    public SubwaveDataModel(List<int> _enemiesCodes, int _pathVariantCode)
    {
        enemiesCodes = _enemiesCodes;
        pathVariantCode = _pathVariantCode;
    }
}
[Serializable]
public class PathVariantDataModel
{
    public Vector3 spawnPointPosition;
    public Quaternion spawnPointRotation;
    public List<WayPointDataModel> wayPoints;
    public Vector3 endPointPosition;
    public Quaternion endPointRotation;
    public PathVariantDataModel(Vector3 _spawnPointPosition, Quaternion _spawnPointRotation, List<WayPointDataModel> _wayPoints, Vector3 _endPointPosition,
        Quaternion _endPointRotation)
    {
        spawnPointPosition = _spawnPointPosition;
        spawnPointRotation = _spawnPointRotation;
        wayPoints = _wayPoints;
        endPointPosition = _endPointPosition;
        endPointRotation = _endPointRotation;
    }
}
[Serializable]
public class WayPointDataModel
{
    public Vector3 wayPointPosition;
    public WayPointDataModel(Vector3 _wayPointPosition)
    {
        wayPointPosition = _wayPointPosition;
    }
}

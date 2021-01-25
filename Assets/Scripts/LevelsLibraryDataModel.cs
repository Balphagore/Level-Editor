using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class LevelsLibraryDataModel
{
    public int campaingsCount;
    public List<CampaingDataModel> campaings;
    public LevelsLibraryDataModel(int _campaingsCount, List<CampaingDataModel> _campaings)
    {
        campaingsCount = _campaingsCount;
        campaings = _campaings;
    }
}
[Serializable]
public class CampaingDataModel
{
    public int id;
    public TranslationVariantDataModel nameTranslations;
    public TranslationVariantDataModel descriptionTranslations;
    public List<LevelDataModel> levels;
    public CampaingDataModel(int _id, TranslationVariantDataModel _nameTranslations, TranslationVariantDataModel _descriptionTranslations, List<LevelDataModel> _levels)
    {
        id = _id;
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
    public int id;
    public TranslationVariantDataModel nameTranslations;
    public TranslationVariantDataModel descriptionTranslations;
    public Vector3 cameraPosition;
    public Quaternion lightRotation;
    public List<PlaneDataModel> planes;
    public List<TerrainDataModel> terrains;
    public List<BuildingSlotDataModel> buildingSlots;
    public List<WaveDataModel> waves;
    public List<PathVariantDataModel> pathVariants;
    public LevelDataModel(int _id, TranslationVariantDataModel _nameTranslations, TranslationVariantDataModel _descriptionTranslations, Vector3 _cameraPosition, Quaternion _lightRotation,
        List<PlaneDataModel> _planes, List<TerrainDataModel> _terrains, List<BuildingSlotDataModel> _buildingSlots, List<WaveDataModel> _waves)
    {
        id = _id;
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
    public int id;
    public Vector3 position;
    public PlaneDataModel(int _id, Vector3 _position)
    {
        id = _id;
        position = _position;
    }
}
[Serializable]
public class TerrainDataModel
{
    public int id;
    public int type;
    public Vector3 position;
    public Quaternion rotation;
    public TerrainDataModel(int _id, int _type, Vector3 _position, Quaternion _rotation)
    {
        id = _id;
        type = _type;
        position = _position;
        rotation = _rotation;
    }
}
[Serializable]
public class BuildingSlotDataModel
{
    public int id;
    public Vector3 position;
    public Quaternion rotation;
    public BuildingSlotDataModel(int _id, Vector3 _position, Quaternion _rotation)
    {
        id = _id;
        position = _position;
        rotation = _rotation;
    }
}
[Serializable]
public class WaveDataModel
{
    public int id;
    public float spawnTime;
    public float waveTime;
    public int waveCost;
    public List<SubwaveDataModel> subwaves;
    public WaveDataModel(int _id, float _spawnTime, float _waveTime, int _waveCost, List<SubwaveDataModel> _subwaves)
    {
        id = _id;
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
    public SubwaveDataModel(int _id, List<int> _enemiesCodes, int _pathVariantCode)
    {
        id = _id;
        enemiesCodes = _enemiesCodes;
        pathVariantCode = _pathVariantCode;
    }
}
[Serializable]
public class PathVariantDataModel
{
    public int id;
    public Vector3 spawnPointPosition;
    public Quaternion spawnPointRotation;
    public List<WayPointDataModel> wayPoints;
    public Vector3 endPointPosition;
    public Quaternion endPointRotation;
    public PathVariantDataModel(int _id, Vector3 _spawnPointPosition, Quaternion _spawnPointRotation, List<WayPointDataModel> _wayPoints, Vector3 _endPointPosition,
        Quaternion _endPointRotation)
    {
        id = _id;
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
    public int id;
    public Vector3 wayPointPosition;
    public WayPointDataModel(int _id, Vector3 _wayPointPosition)
    {
        id = _id;
        wayPointPosition = _wayPointPosition;
    }
}

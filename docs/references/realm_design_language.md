# Realm Design Language Reference

Every Nexus Realm scene follows this standard structure. The DebugRoom
(`scenes/debug/DebugRoom.tscn`) is the living reference implementation.

## Node Hierarchy Standard

```
RealmRoot (Node3D)
├── WorldEnvironment          ← sky, fog, tonemap
├── SunLight (DirectionalLight3D) ← primary directional, shadows on
├── AmbientFill (OmniLight3D)     ← soft fill, high range
├── Terrain (StaticBody3D)
│   ├── TerrainMesh (MeshInstance3D)
│   └── TerrainCollision (CollisionShape3D)
├── PlayerZone (Node3D)
│   └── PlayerSpawn (Marker3D)
├── EnemySpawns (Node3D)
│   └── EnemySpawn_{Type} (Marker3D)  ← naming: EnemySpawn_Wraith, EnemySpawn_Riftborn
├── Interactables (Node3D)
│   ├── AnchorNode_{N} (Area3D)       ← checkpoint, uses AnchorNode.cs
│   ├── ForgeNexus (Area3D)           ← upgrade station (hub only)
│   └── Collectible_{Name} (Area3D)   ← pickups: shards, tomes, crystals
├── Portals (Node3D)
│   └── NexusRift_{Destination} (Area3D) ← uses NexusRiftPortal.cs
├── LightingMood (Node3D)             ← realm-specific accent lights
│   └── Light_{MoodName} (OmniLight3D)
└── HUD (CanvasLayer)
    ├── HealthBar (ProgressBar)
    ├── ChronosBar (ProgressBar)
    ├── NexusEnergyLabel (Label)
    └── RealmName (Label)
```

## Naming Conventions

| Element | Pattern | Example |
|---------|---------|---------|
| Enemy spawn | `EnemySpawn_{Race}` | `EnemySpawn_Wraith` |
| Boss spawn | `BossSpawn_{Race}` | `BossSpawn_Sentinel` |
| Anchor checkpoint | `AnchorNode_{N}` | `AnchorNode_1` |
| Collectible | `Collectible_{Type}` | `Collectible_ResonanceShard` |
| Portal | `NexusRift_{Destination}` | `NexusRift_Hub` |
| Lighting mood | `Light_{Faction}` | `Light_Aetherian` |

## Color Language

| Faction / Mood | Primary Color | Hex | Use For |
|----------------|--------------|-----|---------|
| Player / UI | Cyan | `#00FFFF` | Player markers, HUD accents |
| Aetherian | Cool Blue | `#6699FF` | Scholarly areas, floating citadels |
| Riftborn | Bio Green | `#33FF4D` | Hive zones, organic areas |
| Void / Corruption | Crimson Red | `#CC1A4D` | Danger zones, boss arenas |
| Temporal Energy | Purple | `#9933FF` | Portals, Chronal Core effects |
| Forge / Upgrade | Amber | `#FF9900` | Crafting stations, NPC shops |
| Collectible | Violet | `#CC66FF` | Shards, tomes, loot |
| Warning / Boss | Bright Red | `#FF0000` | Boss labels, danger indicators |

## Physics Layers

| Layer | Name | Used By |
|-------|------|---------|
| 1 | Player | PlayerController |
| 2 | Enemies | BaseEnemy and variants |
| 3 | Environment | Static terrain, walls |
| 4 | Interactables | Anchors, forge, collectibles, portals |
| 5 | Projectiles | Player/enemy ranged attacks |

## Base Script

Realm scenes should attach `RealmTemplate.cs` (or a subclass) to the root node.
It handles: player spawning at PlayerSpawn marker, collectible pickup tracking,
portal activation after all shards collected, HUD realm name display.

---
name: new-realm
description: Scaffold a complete new Nexus Realm level following the design language. Creates scene, script, and documentation.
trigger: When the user wants to create a new game level/realm/world.
---

# New Realm Scaffolding Skill

Creates a complete realm scene following the Chrono Nexus Odyssey design language.

## Steps

1. **Gather Info** — Ask the user for:
   - Realm name (e.g., "Shattered Abyss")
   - Era/faction theme (Aetherian, Riftborn, Void)
   - Number of enemy spawn points
   - Number of anchor checkpoints
   - Number of collectible shards
   - Boss type (if any)
   - Connected portals (where does this realm link to?)

2. **Create Scene** — Write a .tscn file at `scenes/realms/{RealmName}.tscn` following the hierarchy:
   ```
   RealmRoot (Node3D) — script: RealmTemplate subclass
   ├── WorldEnvironment
   ├── SunLight + AmbientFill
   ├── Terrain (StaticBody3D + mesh + collision)
   ├── PlayerZone/PlayerSpawn
   ├── EnemySpawns/EnemySpawn_{Type}
   ├── Interactables/ (anchors, collectibles)
   ├── Portals/NexusRift_{Dest}
   ├── LightingMood/
   └── HUD (CanvasLayer)
   ```

3. **Create Script** — Write a C# class inheriting `RealmTemplate` at `scripts/systems/Realm{Name}.cs`

4. **Apply Color Theme** based on faction:
   - Aetherian: blue (#6699FF), cool lighting
   - Riftborn: green (#33FF4D), bio-luminescent
   - Void: red (#CC1A4D), dark corruption
   - Mixed: blend colors from multiple factions

5. **Build & Test**:
   ```bash
   dotnet build
   ```
   Then use MCP to run the scene and check debug output.

6. **Update Documentation** — Add to Obsidian vault `03-Technical/Scenes/Scene Index.md` and `02-GameDesign/Levels/`

7. **Commit** with descriptive message

## Reference
- Design language: `docs/references/realm_design_language.md`
- Debug room: `scenes/debug/DebugRoom.tscn`
- Color palette: see CLAUDE.md

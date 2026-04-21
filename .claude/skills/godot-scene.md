---
name: godot-scene
description: Build or modify Godot scenes using the godot-mcp tools. Creates scenes, adds nodes, runs and tests them.
trigger: When the user wants to create a new scene, add nodes to a scene, modify scene structure, or test a scene in Godot.
---

# Godot Scene Builder Skill

You have access to godot-mcp tools for programmatic scene creation and testing.

## Available MCP Tools
- `mcp__godot__create_scene` — create new .tscn scene files
- `mcp__godot__add_node` — add child nodes with properties
- `mcp__godot__save_scene` — save/resave scenes
- `mcp__godot__run_project` — run a scene for testing
- `mcp__godot__stop_project` — stop the running project
- `mcp__godot__get_debug_output` — check for runtime errors
- `mcp__godot__launch_editor` — open Godot editor GUI

## Project Path
Always use: `/home/jamesarslan/Documents/Gamingproject`

## Design Language
Every realm scene must follow the hierarchy from `docs/references/realm_design_language.md`:
- Root inherits `RealmTemplate.cs`
- Required children: WorldEnvironment, SunLight, AmbientFill, Terrain, PlayerZone, EnemySpawns, Interactables, Portals, LightingMood, HUD

## Important Notes
- The MCP `add_node` tool does NOT correctly handle complex Godot types (Color, Vector3) via the properties parameter — they get set to black/zero. For scenes needing correct values, write the .tscn file directly using the Write tool instead.
- Always `dotnet build` after adding scripts before running.
- After running, wait 5 seconds then call `get_debug_output` to check for errors.
- The debug room at `scenes/debug/DebugRoom.tscn` is the design reference — check it for conventions.

## Workflow
1. Create scene with `create_scene` (or Write for complex scenes)
2. Add nodes via `add_node` or direct .tscn editing
3. Write any needed C# scripts
4. Run `dotnet build` to compile
5. Test with `run_project`, check `get_debug_output`
6. Stop with `stop_project`
7. Commit changes

---
name: build-test
description: Compile the C# project and run a scene for testing. Reports build errors and runtime debug output.
trigger: When the user wants to build, test, run, or debug the game, or after making code changes.
---

# Build & Test Skill

## Quick Build
```bash
cd /home/jamesarslan/Documents/Gamingproject && dotnet build
```
Must pass with 0 warnings, 0 errors before any commit or test run.

## Run Specific Scene
Use MCP tool `mcp__godot__run_project` with:
- `projectPath`: `/home/jamesarslan/Documents/Gamingproject`
- `scene`: relative path like `scenes/debug/DebugRoom.tscn`

Then wait 5 seconds, call `mcp__godot__get_debug_output` to check for errors.

## Run Full Project (Main Scene)
Use `mcp__godot__run_project` without the `scene` parameter — runs the main scene (MainMenu).

## Common Test Scenes
| Scene | Path | Tests |
|-------|------|-------|
| Debug Room | `scenes/debug/DebugRoom.tscn` | All design elements, lighting, geometry |
| Main Menu | `scenes/main_menu/MainMenu.tscn` | UI flow, button events |
| Aether Vessel | `scenes/hub/AetherVessel.tscn` | Hub, player movement, interactables |
| Nexus Realm 01 | `scenes/realms/NexusRealm01.tscn` | Combat, enemies, collectibles |

## Stop Running Project
Call `mcp__godot__stop_project`

## Open Editor
Call `mcp__godot__launch_editor` to open the Godot editor GUI for visual inspection.

## Troubleshooting
- C# class not found → `dotnet build` first, Godot needs compiled assemblies
- Null reference in _Ready → check node paths match scene hierarchy
- No floor/falling → StaticBody3D needs both MeshInstance3D and CollisionShape3D children

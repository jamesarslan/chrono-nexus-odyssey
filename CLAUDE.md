# Chrono Nexus Odyssey — Agentic Game Development

## Project Overview
Dark Souls-like action RPG with time/space manipulation. Godot 4.6.2 Mono (C#).
Solo developer (James) + Claude Code as agentic AI partner.

**Repo**: https://github.com/jamesarslan/chrono-nexus-odyssey
**Engine**: Godot 4.6.2 Mono at `~/.local/bin/godot`
**Binary**: `/home/jamesarslan/Documents/Godot_v4.6.2-stable_mono_linux_x86_64/Godot_v4.6.2-stable_mono_linux.x86_64`

## Roles & Workflow

**James (Human)**:
- Generates reference images (Gemini) and 3D meshes (ComfyUI + Hunyuan3D-2.1)
- Downloads rigged/animated models from Mixamo
- Tests gameplay, provides creative direction
- Researches game dev fundamentals and shares findings

**Claude (Agent)**:
- Writes all C# game logic, scene scripts, systems
- Uses godot-mcp to create/modify scenes, add nodes, run/test project
- Maintains project structure, conventions, and documentation
- Helps understand Godot fundamentals when asked
- Commits code (James handles deploys/releases)

## Tools Available

### Godot MCP (godot-mcp)
Configured in `.mcp.json`. Available tools:
- `create_scene` / `add_node` / `save_scene` — build scenes programmatically
- `run_project` / `stop_project` / `get_debug_output` — test and debug
- `launch_editor` — open Godot editor GUI
- `get_project_info` / `get_godot_version` — project metadata

### ComfyUI
- Location: `~/Documents/ComfyUI`
- Launcher: `comfyui` (in PATH at `~/.local/bin/comfyui`)
- URL: `http://127.0.0.1:8188`
- Conda env: `comfyui` (Python 3.12, PyTorch + CUDA)
- Output meshes: `~/Documents/ComfyUI/output/mesh/`
- Workflow: Hunyuan3D-2.1 for image-to-3D

### Mixamo Animation Import (Godot 4)
1. Export character from Mixamo as FBX Binary "With Skin" (T-pose)
2. Export animations as FBX "Without Skin" (check "In Place" for locomotion)
3. In Godot Import tab: set Skeleton Profile to `SkeletonProfileHumanoid`
4. Import additional animations as Animation Libraries (.res)
5. Load libraries into AnimationPlayer, set looping on idle/walk/run

## Build & Run

```bash
dotnet build                    # Build C# project
godot --path . --editor         # Open editor
godot --path . -s scene.tscn    # Run specific scene
```

## Project Structure

```
scenes/
├── debug/DebugRoom.tscn       # Design language reference room
├── main_menu/MainMenu.tscn    # Title screen
├── hub/AetherVessel.tscn      # Central hub (bonfire equivalent)
├── realms/NexusRealm01.tscn   # First combat level
└── player/Player.tscn         # (TODO) Reusable player scene

scripts/
├── player/PlayerController.cs  # 3rd-person CharacterBody3D
├── enemies/BaseEnemy.cs        # AI state machine base
├── systems/
│   ├── GameManager.cs          # Autoload singleton
│   ├── RealmTemplate.cs        # Base class for all realm scenes
│   ├── AnchorNode.cs           # Checkpoint system
│   └── NexusRiftPortal.cs      # Scene transitions
└── ui/MainMenuController.cs    # Main menu logic

assets/
├── models/characters/          # GLB/FBX character meshes
├── models/enemies/             # Enemy meshes
├── models/props/               # Environment props
├── models/weapons/             # Weapon meshes
├── textures/reference_images/  # Source images for Hunyuan3D
└── audio/{music,sfx}/          # Sound assets

docs/
├── prompts/                    # Image generation prompts for Gemini
├── workflows/                  # Asset pipeline documentation
└── references/                 # Design language, conventions
```

## Design Language (Realm Scene Standard)

Every realm scene follows the hierarchy defined in `docs/references/realm_design_language.md`.
The DebugRoom (`scenes/debug/DebugRoom.tscn`) is the living reference.

### Required Node Hierarchy
```
RealmRoot (Node3D) — inherits RealmTemplate.cs
├── WorldEnvironment
├── SunLight (DirectionalLight3D)
├── AmbientFill (OmniLight3D)
├── Terrain (StaticBody3D) + mesh + collision
├── PlayerZone/PlayerSpawn (Marker3D)
├── EnemySpawns/EnemySpawn_{Type} (Marker3D)
├── Interactables/ — AnchorNode, ForgeNexus, Collectible_*
├── Portals/NexusRift_{Dest} (Area3D)
├── LightingMood/Light_{Faction} (OmniLight3D)
└── HUD (CanvasLayer) — health, chronos, energy, realm name
```

### Color Palette
| Element | Color | Hex |
|---------|-------|-----|
| Player/UI | Cyan | #00FFFF |
| Aetherian | Blue | #6699FF |
| Riftborn | Green | #33FF4D |
| Void/Corruption | Red | #CC1A4D |
| Temporal | Purple | #9933FF |
| Forge/Upgrade | Amber | #FF9900 |
| Collectible | Violet | #CC66FF |

### Physics Layers
1=Player, 2=Enemies, 3=Environment, 4=Interactables, 5=Projectiles

## Naming Conventions
- Scenes: PascalCase (`DebugRoom.tscn`, `NexusRealm01.tscn`)
- Scripts: PascalCase matching class name (`PlayerController.cs`)
- Nodes: PascalCase with type suffix when ambiguous (`FloorMesh`, `FloorCollision`)
- Spawn markers: `EnemySpawn_{Race}`, `BossSpawn_{Race}`
- Interactables: `AnchorNode_{N}`, `Collectible_{Type}`
- Portals: `NexusRift_{Destination}`

## Code Conventions
- C# with file-scoped namespaces (`namespace ChronoNexusOdyssey.Systems;`)
- Godot export attributes for inspector-tunable values
- No comments unless the WHY is non-obvious
- Build must pass `dotnet build` with 0 warnings before commit

## Git Conventions
- Local commits only — James handles push/deploy
- Commit messages: imperative mood, describe what changed and why
- Co-Authored-By trailer on all Claude commits
- Never force-push, never amend published commits

## Asset Pipeline
```
Gemini (image) → ComfyUI Hunyuan3D-2.1 (mesh) → Mixamo (rig+anim) → Godot (import)
```
- Characters: GLB/FBX with Mixamo rig, import as AnimationLibrary
- Props: GLB direct import, add collision in Godot
- Prompts stored in `docs/prompts/`

## Custom Skills (Claude Code)

These skills are in `.claude/skills/` and provide optimized workflows:

| Skill | Trigger | What It Does |
|-------|---------|-------------|
| `godot-scene` | "create a scene", "add nodes" | Scene building via MCP or direct .tscn writing |
| `asset-import` | "import model", "new mesh" | Copy ComfyUI/Mixamo assets into project |
| `build-test` | "build", "test", "run" | Compile C# + run scene + check errors |
| `obsidian-sync` | "update docs", "sync kb" | Update Obsidian knowledge base vault |
| `new-realm` | "create new realm/level" | Scaffold complete realm with scene + script + docs |

## Knowledge Base

Obsidian vault: `~/Documents/obsidianchrono/ChronoGame/`
KB Repo: https://github.com/jamesarslan/chrono-nexus-kb (private)

The knowledge base contains game design docs, technical architecture, asset registry,
sprint tracking, and research notes. Keep it in sync after major changes.

## Input Mappings
| Action | Key | Use |
|--------|-----|-----|
| move_forward/back/left/right | WASD | Movement |
| attack | Left Mouse | Combat |
| dodge | Space | Dodge/Jump |
| interact | E | Interact with objects |
| inventory | I | Open inventory |
| temporal_shift | Q | Time manipulation |
| pause_menu | Escape | Pause/cursor toggle |

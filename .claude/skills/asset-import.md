---
name: asset-import
description: Import 3D models, textures, and animations into the Godot project. Handles ComfyUI output, Mixamo FBX, and manual assets.
trigger: When the user has new 3D models, animations, or textures to import into the game project, or asks about the asset pipeline.
---

# Asset Import Skill

## Asset Pipeline Overview
```
Gemini (reference image) → ComfyUI Hunyuan3D-2.1 (3D mesh) → Mixamo (rig+anim) → Godot
```

## ComfyUI Mesh Import
ComfyUI outputs to: `~/Documents/ComfyUI/output/mesh/`

1. Check for new meshes: `ls ~/Documents/ComfyUI/output/mesh/`
2. Copy and rename to project:
   - Characters: `assets/models/characters/{name}.glb`
   - Enemies: `assets/models/enemies/{name}.glb`
   - Props: `assets/models/props/{name}.glb`
   - Weapons: `assets/models/weapons/{name}.glb`
3. Godot auto-imports on next editor load

## Mixamo Animation Import (Godot 4)
1. Character FBX "With Skin" → `assets/models/characters/{name}.fbx`
2. Animation FBX "Without Skin" → `assets/models/characters/{name}_{anim}.fbx`
3. In Godot Import tab:
   - Set Skeleton Profile to `SkeletonProfileHumanoid` for retargeting
   - Import animations as Animation Library (.res)
4. Load libraries into AnimationPlayer
5. Set looping on idle/walk/run animations

## File Naming Convention
- Models: `snake_case.glb` or `.fbx`
- Animations: `{character}_{animation}.fbx` (e.g., `elara_voss_idle.fbx`)
- Textures: `{name}_{type}.png` (e.g., `elara_voss_albedo.png`)

## Current Model Registry
Check `docs/references/model_registry.md` or the Obsidian vault at `04-Assets/Models/Model Registry.md`

## After Import
- Update the model registry document
- If it's a character, create a Player.tscn or Enemy.tscn scene using it
- Run `dotnet build` and test in debug room

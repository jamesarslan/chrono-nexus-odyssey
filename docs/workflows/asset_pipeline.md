# 3D Asset Pipeline: Image → 3D Model → Animated Game Asset

## Overview

```
Gemini Image Gen  →  ComfyUI + Hunyuan3D-2.1  →  Mixamo (characters only)  →  Godot 4.6.2
  (concept art)        (image to 3D mesh)         (auto-rig + animate)        (game engine)
```

## Step 1: Generate Reference Images (Gemini)

Use the prompts in `docs/prompts/` to generate clean reference images:
- Characters: T-pose or A-pose, white background, front view
- Props/Items: Isometric or front view, white background
- Environments: Isometric view, clean lighting

Tips:
- Generate multiple variations and pick the best
- Clean backgrounds are critical for Hunyuan3D quality
- Single-object images work best (no complex scenes)

## Step 2: Image to 3D (ComfyUI + Hunyuan3D-2.1)

### Setup
1. Start ComfyUI: `comfyui` (or `comfyui --port 8188`)
2. Open browser to `http://127.0.0.1:8188`
3. Load the Hunyuan3D-2.1 workflow (see below)

### Required Models
Download from https://huggingface.co/tencent/Hunyuan3D-2.1:
- Place in `ComfyUI/models/` appropriate subdirectories
- Follow the ComfyUI Hunyuan3D tutorial: https://docs.comfy.org/tutorials/3d/hunyuan3D-2

### Workflow
- Load the official Hunyuan3D-2.1 ComfyUI workflow
- Input: reference image from Step 1
- Output: 3D mesh (GLB format)
- Adjust quality settings based on asset importance:
  - Hero characters: highest quality, multiple reference angles
  - Props: medium quality
  - Distant environment pieces: lower poly count

## Step 3: Character Animation (Mixamo)

For characters and humanoid enemies only:

1. Export 3D model as FBX or OBJ from ComfyUI
2. Go to https://www.mixamo.com/
3. Upload character mesh → auto-rigging
4. Select animations:
   - **Elara Voss**: idle, walk, run, dodge_roll, sword_slash, sword_combo, jump, fall, land, death, interact
   - **Enemies**: idle, walk, attack_1, attack_2, hit_reaction, death, chase_run
   - **NPCs**: idle, talk, gesture
5. Download each animation as FBX (With Skin for first, Without Skin for rest)

### Recommended Mixamo Animations by Character

| Character | Animations to Download |
|-----------|----------------------|
| Elara Voss | Idle, Walking, Running, Sword And Shield Slash, Rolling, Jump, Falling Idle, Landing, Death, Picking Up |
| Paradox Wraith | Zombie Idle, Zombie Walk, Zombie Attack, Hit Reaction, Dying |
| Riftborn Scout | Idle, Walking, Running, Punching, Hit Reaction, Dying |
| Void Sentinel | Idle, Walking, Heavy Attack, Shield Block, Dying |

## Step 4: Import to Godot

### For Characters (with animations)
1. Place .glb/.fbx files in `assets/models/characters/`
2. Godot auto-imports with animation data
3. Create an AnimationTree for state-based blending:
   - Idle ↔ Walk ↔ Run (blend by speed)
   - Attack states (one-shot)
   - Hit/Death states (one-shot)
4. Attach to CharacterBody3D scene

### For Props/Environment
1. Place .glb files in `assets/models/props/` or `assets/models/environment/`
2. Godot auto-imports as scenes
3. Add collision shapes as needed
4. Add to level scenes

## File Organization

```
assets/
├── models/
│   ├── characters/
│   │   ├── elara_voss.glb
│   │   ├── elara_voss_idle.fbx
│   │   ├── elara_voss_run.fbx
│   │   └── ...
│   ├── enemies/
│   │   ├── paradox_wraith.glb
│   │   └── ...
│   ├── props/
│   │   ├── anchor_crystal.glb
│   │   ├── forge_nexus.glb
│   │   └── ...
│   ├── weapons/
│   │   ├── temporal_blade.glb
│   │   └── ...
│   └── environment/
│       ├── aetherian_pillar.glb
│       └── ...
├── textures/
│   └── reference_images/
│       ├── elara_front.png
│       ├── elara_side.png
│       └── ...
└── audio/
```

## Post-Reboot CUDA Setup

After rebooting to fix the NVIDIA driver mismatch (580.126 kernel vs 580.142 userspace):

```bash
conda activate comfyui
pip install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu130 --force-reinstall
```

This upgrades PyTorch to CUDA 13.0 which supports RTX 5090 (Blackwell/GB202).

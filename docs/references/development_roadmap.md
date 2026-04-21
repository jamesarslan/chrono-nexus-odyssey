# Chrono Nexus Odyssey — Development Roadmap

## Phase 1: Foundation (Current)
**Goal**: Prove the full pipeline works end-to-end. One playable room with basic movement and interaction.

### Completed
- [x] Project setup: Godot 4.6.2 Mono, GitHub repo, C# solution
- [x] Core scripts: GameManager, PlayerController, BaseEnemy, RealmTemplate
- [x] System scripts: AnchorNode (checkpoints), NexusRiftPortal (transitions)
- [x] UI: MainMenu with New Game / Continue / Settings / Quit
- [x] 4 scenes: MainMenu, AetherVessel (hub), NexusRealm01, DebugRoom
- [x] Asset pipeline proven: Gemini → ComfyUI Hunyuan3D-2.1 → GLB mesh
- [x] ComfyUI installed with PyTorch + CUDA
- [x] godot-mcp integration working
- [x] Debug room with design language reference (color-coded geometry)
- [x] First character model (Elara Voss) and boss model (Void Sentinel) generated
- [x] CLAUDE.md, skills, Obsidian knowledge base

### Remaining
- [ ] Import Mixamo-rigged Elara into playable Player.tscn scene
- [ ] Create reusable Player.tscn (CharacterBody3D + mesh + camera + collision)
- [ ] Basic attack animation and hitbox
- [ ] Replace placeholder capsule/boxes with actual 3D models
- [ ] First playable: walk around debug room, interact with anchor node

## Phase 2: Core Gameplay Loop
**Goal**: One complete realm playable start to finish with combat, checkpoints, and progression.

- [ ] Combat system: light attack, heavy attack, dodge roll, stamina bar
- [ ] Enemy AI: patrol, chase, attack patterns, stagger, death + loot drop
- [ ] Anchor checkpoint: rest, restore health, respawn on death with energy penalty
- [ ] Collectible system: Resonance Shards, Veil Tomes, Echo Crystals
- [ ] Basic inventory UI: equipped weapon, consumables
- [ ] Nexus Energy display and banking at anchors
- [ ] Forge Nexus: basic weapon upgrade (damage tiers)
- [ ] Scene transitions: MainMenu → Hub → Realm01 → Hub (full loop)
- [ ] Temporal Shift mechanic: slow-time ability with Chronos stamina cost
- [ ] Death screen with "Return to Anchor" flow
- [ ] First boss fight: Void Sentinel with multi-phase mechanics
- [ ] Audio: placeholder ambient + hit SFX

## Phase 3: Content & Polish
**Goal**: 3 playable realms with distinct themes, NPCs, and narrative.

- [ ] Realm 02: Riftborn Hive (green bio-organic theme)
- [ ] Realm 03: Aetherian Citadel (blue crystalline floating structures)
- [ ] NPC system: dialogue trees, quest givers
- [ ] Side quests: at least 2 per realm
- [ ] Aetherian merchant NPC in hub
- [ ] Equipment system: weapons, armor, accessories
- [ ] Tech tree: Veil Branches with meaningful upgrade choices
- [ ] VFX: temporal shift distortion, portal effects, hit sparks
- [ ] Music: ambient tracks per realm + boss themes
- [ ] Cutscene system for story beats
- [ ] Temporal Log (quest journal) UI

## Phase 4: Release Preparation
**Goal**: Complete game ready for Steam Early Access.

- [ ] Realms 04 + 05
- [ ] Shattered Collective (antagonist faction) encounters
- [ ] Multiple endings based on moral choices
- [ ] Game balance: damage curves, enemy scaling, pacing
- [ ] Save/Load system
- [ ] Settings menu: graphics, audio, controls
- [ ] Controller support (gamepad input mapping)
- [ ] Performance optimization: LOD, occlusion, draw call reduction
- [ ] Steam integration: achievements, cloud saves
- [ ] Store page: screenshots, trailer, description
- [ ] Localization framework

## Sprint Structure

Each sprint is ~1 week of solo development. Track progress in the Obsidian vault under `05-Sprints/`.

**Sprint format**:
1. Define 3-5 concrete deliverables
2. James generates needed art assets
3. Claude implements code/scenes
4. Test in engine
5. Commit, push, update knowledge base

## Current Sprint: Sprint 01 — Foundation Completion

**Deliverables**:
1. Playable Player.tscn with Elara mesh + Mixamo idle/walk animations
2. Basic interact system working (walk to anchor, press E)
3. Scene transition: MainMenu → AetherVessel working
4. All placeholder geometry replaced with generated models where available

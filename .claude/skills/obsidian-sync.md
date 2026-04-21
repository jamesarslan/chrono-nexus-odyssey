---
name: obsidian-sync
description: Update the Obsidian knowledge base vault with current project state — new scripts, scenes, assets, sprint progress, research notes.
trigger: When the user asks to update the knowledge base, sync documentation, or after significant project milestones.
---

# Obsidian Knowledge Base Sync Skill

## Vault Location
`/home/jamesarslan/Documents/obsidianchrono/ChronoGame/`

## Structure
```
01-Project/     — roadmap, workflow, tool setup
02-GameDesign/  — lore, mechanics, characters, levels
03-Technical/   — architecture, scripts, scenes
04-Assets/      — pipeline, model registry, animations
05-Sprints/     — sprint logs and progress
06-Research/    — fundamentals, tutorials, references
Templates/      — reusable templates
```

## Sync Checklist
When syncing, update these files as needed:

1. **Home.md** — update project status and recent changes
2. **03-Technical/Scripts/Core Scripts.md** — if new scripts were added
3. **03-Technical/Scenes/Scene Index.md** — if new scenes were created
4. **04-Assets/Models/Model Registry.md** — if new models were imported
5. **05-Sprints/Sprint XX.md** — update current sprint progress
6. **01-Project/Development Roadmap.md** — if milestones were completed

## How to Update
- Read the file first, then Edit to update specific sections
- Use [[wiki links]] for all cross-references
- Add YAML frontmatter tags to new pages
- Keep entries concise — the vault is a reference, not a narrative

## Commit & Push
After updating:
```bash
cd /home/jamesarslan/Documents/obsidianchrono/ChronoGame
git add -A && git commit -m "sync: {what changed}" && git push
```

## Cross-Repo References
- Game repo: https://github.com/jamesarslan/chrono-nexus-odyssey
- KB repo: https://github.com/jamesarslan/chrono-nexus-kb
- Reference game files from KB using GitHub URLs, not local paths

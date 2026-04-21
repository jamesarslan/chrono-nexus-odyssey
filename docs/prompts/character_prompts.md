# Character Image Prompts for 3D Asset Generation

Pipeline: Gemini Image Gen → ComfyUI Hunyuan3D-2.1 → Mixamo Animation → Godot Import

## Elara Voss (Protagonist)

### Front Reference
```
Full body front view of a female sci-fi archaeologist character, standing in T-pose for 3D reference. She has short dark hair with glowing cyan streaks, wearing a form-fitting dark purple combat suit with exposed mechanical components on her left arm (the Chronal Core device). The suit has subtle circuit-line patterns that glow faintly in teal/cyan. She wears armored boots and has a utility belt with small pouches. Her expression is determined but weary. Clean white background, game character concept art style, high detail, physically based rendering reference.
```

### Side Reference
```
Full body side profile view of a female sci-fi archaeologist warrior, standing upright for 3D reference. Short dark hair with cyan streaks, dark purple combat suit with mechanical arm device emitting soft cyan glow, armored boots, utility belt. Clean white background, game character concept art, orthographic side view, high detail.
```

### Combat Pose (Marketing/UI)
```
Dynamic action pose of a female sci-fi warrior archaeologist, leaping through a glowing purple rift in space-time. She has short dark hair with cyan streaks, dark purple combat suit with a glowing mechanical left arm. Temporal energy swirls around her in teal and violet. Dramatic lighting, dark cosmic background with fractured reality fragments, cinematic game art style.
```

## Paradox Wraith (Common Enemy)

### Reference Sheet
```
Full body front view of a spectral horror creature for game asset, T-pose reference. A shifting, translucent ghostly entity made of fragmented timelines - multiple overlapping versions of a humanoid form, each slightly offset and transparent. Glowing red core visible through the chest. Tendrils of temporal energy extend from its body. Ethereal, unsettling appearance. Dark form against white background, game enemy concept art, high detail.
```

## Riftborn Scout (Allied NPC / Enemy Variant)

### Reference Sheet
```
Full body front view of an insectoid alien creature, T-pose for 3D reference. Bipedal with four arms, iridescent dark green exoskeleton with bioluminescent amber markings. Compound eyes, mandibles, and antennae. Lean build, roughly humanoid proportions. Wears minimal chitinous armor plates. Clean white background, sci-fi game creature concept art, high detail.
```

## Void Sentinel (Mini-Boss / Allied NPC)

### Reference Sheet
```
Full body front view of a massive machine-organic hybrid guardian, standing pose for 3D reference. Ancient stone and metal body with exposed bio-mechanical internals glowing in warm amber. Towering humanoid form (3m tall), heavy armored plates with ancient rune-like engravings. Single large eye in the center of its head. Weapon arm on the right, shield-like structure on left. Clean white background, game boss concept art, high detail.
```

## Aetherian Scholar (NPC)

### Reference Sheet
```
Full body front view of an ethereal floating alien being for game NPC, reference pose. Translucent, luminous body made of gas-like substance contained in a vaguely humanoid shape. No legs - lower body trails into mist. Long flowing tendrils instead of arms, holding a crystalline object. Face is a smooth featureless surface with two glowing points for eyes. Soft blue and white color palette. Clean white background, sci-fi game NPC concept art.
```

---

## Notes for Hunyuan3D-2.1 Workflow
- Use single clean reference images (white/neutral background)
- T-pose or A-pose preferred for characters that need animation
- After 3D generation, export as GLB/GLTF
- Upload to Mixamo for auto-rigging and animation
- Import into Godot as .glb with animation libraries

# 🚒 Firefighter XR Simulation

This is a **VR Firefighting Training Simulation** built with **Unity** and the **XR Interaction Toolkit**.  
It was developed as part of the Wakeb Technical Assessment and focuses on simulating firefighting tasks in a simple city environment.

---

## 📂 Project Structure

- **Scenes/** → Main Unity scenes (cutscene, fire scene, etc.)
- **Scripts/** → Custom C# scripts for gameplay:
  - `CutsceneFader` → Handles intro cutscene transitions  
  - `FireGroupExtinguish` → Extinguishes fire (particle + audio fade)  
  - `MoveToPoint` / `MoveToTarget` → Moves NPCs/objects toward targets  
  - `OnTrigger` → Loads new scene when player enters a trigger  
  - `ParticleWatcher` → Watches particle state (fire finished)  
  - `TriggerAnimation` → Controls character animator parameters  
  - `WaterCollisionExtinguisher` → Extinguishes fire on collision  
  - `WaterSprayAction` → Water spray effect (input mapped, XR-based)  
- **Fire_Hose/** → Assets for water spraying  
- **SimplePoly City/** → Low-poly environment assets  
- **Convai/** → AI NPC assistant integration (dialogue system)  

---

## 🛠️ Tech Stack

- Unity 2022+ (URP pipeline)  
- C# scripting  
- XR Interaction Toolkit (Quest/VR Input)  
- Convai SDK for AI NPC conversations  
- Particle Systems for fire/water simulation  
- Audio Sources for fire crackling  

---

## 🎮 Gameplay Flow

1. The game starts with a **cutscene**.  
2. The player is introduced by an **AI assistant (John)**.  
3. John guides the player to the **fire truck**.  
4. Player sprays water to **extinguish the fire**.  
5. Fire particles and fire audio **fade out** smoothly.  
6. Once the fire is gone, a **UI screen appears** with success feedback.  

---

## 📌 Features

✔️ Cutscene fade-in / fade-out  
✔️ AI assistant with Convai integration  
✔️ Fire extinguishing system (particles + audio sync)  
✔️ XR-based water spray action (controller input planned)  
✔️ Scene transition flow  
✔️ Post-fire UI screen  

---

## 🚀 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/firefighter-xr-simulation.git

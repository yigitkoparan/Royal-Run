# 👑 Royal Run - 3D Endless Runner Game

A fast-paced 3D endless runner game developed using **Unity** and **C#**, based on the *Royal Run* project from the [GameDev.tv](https://www.gamedev.tv/) Complete Unity 3D Developer course.

This project was created to practice core 3D game development concepts, including procedural level generation, dynamic speed scaling, 3D physics and collisions, collectible pickups, post-processing effects, and UI management.

## ✨ Features

* **🏃 Responsive 3D Movement:** Smooth lateral movement and lane navigation (`WASD` / Arrow Keys) within bounded level tracks.

* **🛣️ Procedural Level Generation:** Endless track chunks dynamically spawned, moved, and recycled at runtime using C# lists and prefabs.

* **⚡ Dynamic Difficulty & Speed Scaling:** Game speed and world gravity dynamically adjust over time and via pickups to intensify the challenge.

* **🍎 Pickups & Power-Ups:** Interactive collectibles scattered across chunks, including **Coins** (to increase score), **Apples** (to boost movement/chunk speed), and **Checkpoints** (to extend remaining run time).

* **🚧 Obstacles & Hazards:** Dynamically spawned fences and falling/moving obstacles that test player reflexes and trigger stumble animations.

* **🎬 Character Animations & Camera Juice:** Animator state transitions, camera field-of-view (FOV) speed effects, particle systems, and post-processing visuals.

* **⏱️ Score & Timer UI:** Real-time countdown timer, score tracking, and game-over state management using Unity UI / TextMeshPro.

## 🛠️ Technologies Used

* **Game Engine:** Unity (3D / Unity 6)

* **Programming Language:** C#

* **Level & World Systems:** Procedural Chunk Spawner (`List<GameObject>`), Prefab Variants

* **Physics & Collisions:** `Rigidbody`, `Collider` (Box, Capsule, Mesh), Trigger Events

* **Visuals & Camera:** Unity Animator, Cinemachine, Post-Processing Volume, Particle Systems

* **UI:** Unity Canvas & TextMeshPro

## 🎯 Controls

| Action | Key(s) | 
| ----- | ----- | 
| **Move Left / Right / Forward / Back** | `W` `A` `S` `D` or Arrow Keys | 

## 📚 Acknowledgments

* Built while following the **Complete C# Unity Game Developer 3D** course by **GameDev.tv**.

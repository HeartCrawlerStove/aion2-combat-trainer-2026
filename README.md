# AION 2 Combat Trainer

![Windows](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6?style=flat-square&logo=windows&logoColor=white)
![Version](https://img.shields.io/badge/Version-1.0.0-brightgreen?style=flat-square)
![Downloads](https://img.shields.io/badge/Downloads-New-blue?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)

Desktop combat trainer for AION 2 — single-player modifiers, memory reader, and hotkey-driven controls for offline testing.

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/HeartCrawlerStove/aion2-combat-trainer-2026/releases/tag/1.0.0)

</div>

---

## ⚡ At a Glance

| | |
|---|---|
| **What it is** | Desktop combat trainer for AION 2 |
| **Who it's for** | Players who want to test builds and explore content without grinding |
| **What it solves** | Slow leveling, resource scarcity, punishing combat |
| **How it works** | Separate process, Win32 memory access, hotkey toggles |

---

## 🔥 Why This Exists

AION 2 launched globally on October 5, 2026, and hit 400,000+ concurrent players on Steam day one. The game has 8 classes — Templar, Gladiator, Sorcerer, Ranger, Cleric, Spiritmaster, Assassin, and Chanter — and class choice is permanent. Leveling a Templar or Cleric is slow. Grinding Kinah takes time. Some players want to test endgame builds, explore content, or just bypass the difficulty curve.

This trainer gives you that option. It's for offline testing and single-player exploration only — not for competitive play, not for Abyss PvP, not for anything that affects other players.

---

## 🧩 What It Does

### Combat Modifiers
- **God Mode** — player takes no damage
- **Infinite HP** — health never depletes
- **Infinite MP** — mana never depletes
- **One Hit Kill** — any hit eliminates enemies
- **Damage Multiplier** — adjust outgoing damage (x1 to x10)

### Resource Control
- **Infinite Kinah** — currency never decreases
- **No Cooldown** — abilities have no cooldown
- **Super Speed** — increased movement speed

### Technical Foundation
- Real C# WPF project with source code in `src/`
- Memory reader using Win32 API (`OpenProcess`, `ReadProcessMemory`, `WriteProcessMemory`)
- Hotkey manager with `RegisterHotKey` for F1–F8
- JSON-based configuration system
- Documentation in `docs/NOTES.md`

---

## 💻 System Requirements

| Component | Minimum | Recommended |
| :--- | :--- | :--- |
| **OS** | Windows 10 (64-bit) | Windows 11 |
| **RAM** | 8 GB | 16 GB |
| **Storage** | 100 MB | 200 MB |
| **Runtime** | .NET 8.0 (bundled) | .NET 8.0 |
| **Game** | AION 2 (Steam/PURPLE) | Latest patch |
| **Permissions** | Administrator | Administrator |

---

## 🚀 Quick Start

1. **Download** the archive using the button above
2. **Extract** with 7-Zip or WinRAR
3. **Run** `Aion2Trainer.exe` as administrator
4. **Launch** AION 2
5. **Press** `INSERT` to open the trainer menu

> The trainer detects the game process automatically. If it doesn't, run as administrator and try again.

---

## ❓ FAQ

**Is this safe to use?**
The trainer runs as a separate process and does not modify game files permanently. Use in offline/single-player only.

**Will I get banned?**
NCSoft has issued multiple ban waves against accounts using unauthorized programs — 10,326 accounts on October 16-17, and 15,380 accounts on October 20-21. These bans target bots, macros, RMT, and unauthorized programs in online modes. Using the trainer in any online content carries a high risk of account suspension. Restrict use to offline testing.

**Do I need to disable my antivirus?**
Some antivirus suites may flag trainers as a precaution. Add an exclusion for the trainer folder if needed.

**Does it work with updates?**
Yes — the trainer is updated for current patches. Memory offsets change with game updates; use the `docs/NOTES.md` guide to update them if needed.

**How do I uninstall?**
Delete the trainer folder. No registry entries or system changes are made.

---

## 🗺️ Roadmap

- [ ] Additional combat modifiers
- [ ] Profile system for saving toggle configurations
- [ ] Memory offset auto-updater
- [ ] Multi-language support

---

## 📄 License

MIT License — see [LICENSE](LICENSE) for details.

---

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/HeartCrawlerStove/aion2-combat-trainer-2026/releases/tag/1.0.0)

**Version 1.0.0** — Stable Release · Combat Trainer · MIT

</div>

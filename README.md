# Fallout Shelter Premium Pass Unlocker

Automatically unlocks the Premium Plus Season Pass for saves.

## Installation

1. [Install BepInEx](https://docs.bepinex.dev/v5.4.21/articles/user_guide/installation/index.html).
2. Download / extract [`fs-premium-pass-unlocker.dll`](https://github.com/torkelicious/fs-premium-pass-unlocker/releases/latest).
3. Place `fs-premium-pass-unlocker.dll` in `BepInEx/plugins`.
4. Launch the game :)

---

## Building

Clone the repo & copy the following files from your Fallout Shelter installation directory into `libs/`:

(found in `/Fallout Shelter/FalloutShelter_Data/Managed/`)
- `Assembly-CSharp.dll`
- `UnityEngine.dll`
- `UnityEngine.CoreModule.dll`

These assemblies are required for compilation and are not included in this repository.

Build the project in your IDE or run:

```sh
dotnet build
```

The compiled plugin DLL will be generated in the build output directory.

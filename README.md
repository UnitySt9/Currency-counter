# Currency Counter

A Unity game project featuring an animated currency collection system with gold, diamonds, and energy counters.

## Features

- **Currency Management**: Track gold, diamonds, and energy with real-time UI updates
- **Animated Collection**: Smooth DOTween animations for currency collection effects
- **Configurable Animation**: Adjustable animation speed and collection amounts
- **Modular Design**: Separate animators for each currency type (Gold, Diamond, Energy)

## Components

- `CurrencyController` - Main currency management system
- `CurrencyAnimator` - Abstract base class for currency animations
- `GoldAnimator`, `DiamondAnimator`, `EnergyAnimator` - Specific currency animators

## Requirements

- Unity 2022.3 or later
- DOTween (for animations)
- TextMeshPro

## Usage

1. Open the project in Unity
2. Load the main scene
3. Use the collect buttons to gather currency
4. Adjust animation speed with the slider
5. Watch your currency counters update in real-time

## Project Structure

```
Assets/_Project/
├── Scripts/          # Core currency system scripts
├── Scenes/          # Game scenes
├── Prefabs/         # Currency UI prefabs
└── Sprites/         # Currency icons and graphics
```
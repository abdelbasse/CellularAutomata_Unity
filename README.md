# Cellular Automata Unity Project

This project is a Unity-based implementation of cellular automata, allowing you to create and customize simulations of cellular evolution. This README file will guide you through setting up the project, understanding the core scripts, and running the simulation.

---

## Table of Contents
- [Cellular Automata Unity Project](#cellular-automata-unity-project)
  - [Table of Contents](#table-of-contents)
  - [Project Overview](#project-overview)
    - [What is Cellular Automata?](#what-is-cellular-automata)
  - [Installation and Setup](#installation-and-setup)
    - [Prerequisites](#prerequisites)
    - [Clone the Project](#clone-the-project)
    - [Running the Simulation](#running-the-simulation)
    - [Parameters Overview](#parameters-overview)
  - [Examples](#examples)
    - [Example 1: Setting Up a Basic Cellular Automata Simulation](#example-1-setting-up-a-basic-cellular-automata-simulation)
    - [Example 2: Implementing Custom Rules](#example-2-implementing-custom-rules)
  - [Customization](#customization)
    - [Visualization](#visualization)
  - [Future Improvements](#future-improvements)

---

## Project Overview

### What is Cellular Automata?

Cellular automata are discrete models composed of a grid of cells. Each cell can exist in a finite number of states (e.g., "alive" or "dead") and evolves based on rules that take into account the states of neighboring cells. These rules produce complex behaviors over time, starting from simple initial conditions.

Famous examples of cellular automata include **Conway's Game of Life** and **Wolfram's Rule 30**.

This Unity project offers a flexible system where you can:
- Customize the grid size.
- Set up random or predefined initial states.
- Define and modify evolution rules.
- Visualize the automata as they evolve over time.

---

## Installation and Setup

### Prerequisites

- **Unity**: You must have Unity installed. This project was built with Unity version 2021.3. Ensure you have a compatible version.
- **Git** (optional): If you want to clone the repository directly from GitHub, you will need Git installed.

### Clone the Project

If you have Git installed, you can clone the project by running the following command in your terminal:

```bash
git clone https://github.com/yourusername/CellularAutomataUnityProject.git
```
2. Open the project in Unity by selecting the folder `CellularAutomataUnityProject` in Unity Hub.

### Running the Simulation

1. In Unity, ensure you have a GameObject with the `CellularAutomataAllRules` script attached. This script will generate and manage a grid of cellular automata based on the parameters you specify.
2. Adjust the parameters in the `CellularAutomataAllRules` script via the Unity Inspector:
   - `Ref`: A reference to the GameObject representing a single cell.
   - `nbrOfRulesStart`: The starting rule number (usually 0).
   - `nbrOfRulesEnd`: The ending rule number (e.g., 100).
   - `CellSize`: The size of each cell.
   - `CellResolution`: The resolution of each cell's texture.
   - `GridSize`: The number of cells in the grid (X and Y axes).
   - `makeCellsStatRandom`: Set whether the initial cell states should be random.
   
3. Run the scene by pressing the Play button in Unity. The cellular automata grid will be generated and the simulation will run based on the rules you set.

### Parameters Overview

- **CellSize**: Determines the size of each cell in the grid. Larger values will result in larger cells.
- **CellResolution**: Sets the texture resolution for each cell.
- **GridSize**: Defines the size of the grid (in number of cells) for both the X and Y axes.
- **Rule**: A numerical value that represents a set of rules for cell evolution. You can modify the rules to change how the cellular automata behave.
- **makeCellsStatRandom**: This boolean determines whether the initial state of the cells is random or predefined.

---

## Examples

### Example 1: Setting Up a Basic Cellular Automata Simulation

1. Create a new empty GameObject in the Unity scene.
2. Attach the `CellularAutomataAllRules` script to the GameObject.
3. Assign a reference to a basic cell prefab (a simple 3D object, e.g., a cube) in the `Ref` field.
4. Set the following parameters in the Inspector:
   - `nbrOfRulesStart`: 0
   - `nbrOfRulesEnd`: 30
   - `CellSize`: 1
   - `GridSize`: (20, 20)
   - `makeCellsStatRandom`: true

5. Press Play in Unity, and observe the randomly initialized grid of cells evolving based on the selected rules.

### Example 2: Implementing Custom Rules

In the `CellularAutomata` script, you can modify the following function to change how cells evolve:

```csharp
private bool Rules(int stat)
{
    // Custom logic for determining if a cell should be alive or dead based on its neighbors
    return theRuleInBin[stat];
}
```

This function checks the state of a cell and its neighbors and returns whether the cell will be alive in the next generation. To implement custom rules, you can modify this logic.

For example, to simulate **Conway's Game of Life**:

```csharp
private bool rules(int neighborsCount, bool isAlive)
{
    if (isAlive && (neighborsCount == 2 || neighborsCount == 3)) return true;
    if (!isAlive && neighborsCount == 3) return true;
    return false;
}
```

This rule set follows Conway’s famous rules where:
- Any live cell with 2 or 3 live neighbors stays alive.
- Any dead cell with exactly 3 live neighbors becomes alive.

---

## Customization

You can further customize the behavior of the simulation by modifying the following variables:
- **ProbabilityOfItAlive**: Sets the probability that a cell is alive at the start when `makeCellsStatRandom` is true.
- **Rule**: Change this to use different sets of rules, which can be stored in binary format in the `theRuleInBin` list.

### Visualization

The project uses textures to visualize the cells. Each cell is represented as a square in the grid, and its color changes based on whether it is alive or dead:
- **Alive** cells are white.
- **Dead** cells are black.

These colors can be changed in the `DrowCell()` method.

---

## Future Improvements
Some potential improvements for this project include:
- Adding a UI to allow users to dynamically change rules while the simulation is running.
- Implementing more advanced cellular automata models (e.g., Rule 110, Langton’s Ant).
- Adding a feature to save and load grid configurations.
- Providing more visual feedback, such as highlighting cells that have changed states.
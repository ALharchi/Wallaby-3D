# Wallaby - Geometric Constraint Solver

Wallaby is a geometric constraint solver project developed in C#. 
It is a Grasshopper plugin that serves primarly as a teaching material for students to understand how geometric solvers, such as Kangaroo3d, work, and how to implement them. 

## Overview

Wallaby is a simple lightweight geometric constraint solver that can solve a wide range of problems in two and three dimensions. It is designed to integrate within Grasshopper, a popular graphical algorithm editor for Rhino3D. Wallaby provides a set of geometric goals, which define the constraints that need to be satisfied, and a solver that iteratively adjusts the position of the input geometry until all the constraints are satisfied.

## Project Scope and Limitations

While Wallaby is a functional geometric constraint solver, it is primarily a teaching project aimed at helping students understand how geometric solvers work and how to implement them. As such, users should not expect the same level of performance or accuracy as they would from a professional-grade solver. Wallaby is designed to be lightweight and easy to use, and it may not be suitable for solving complex problems or large-scale structures. 

## Installation

To use Wallaby, you need to have Rhino3D and Grasshopper installed on your computer. Then, follow these steps:

1. Download the latest release of Wallaby from the [Releases page](https://github.com/ALharchi/Wallaby-3D/releases).
2. Unzip the downloaded file and copy the `Wallaby.gha` file to the Grasshopper components folder, which is usually located in `%appdata%\Grasshopper\Libraries`.
3. Restart Rhino and Grasshopper. You should now see Wallaby components in the Grasshopper toolbar.

## Goals

Wallaby currently provides around a dozen of goals, which can be used to constrain and manipulate geometry in various ways. Here is a list of the available goals:

- `Anchor`: Fix the position of a point in space.
- `AnchorXYZ`: Fix the position of a point in a specific coordinate system.
- `Angle`: Constrain the angle between two lines.
- `Collinear`: Constrain multiple points to lie on the same line.
- `CoPlanar`: Constrain multiple points to lie on the same plane.
- `Length`: Constrain the length of a line.
- `Load`: Simulate forces and loads applied to a point.

It is also easy to add new goals to Wallaby by implementing them as C# scripts or Grasshopper components. See the wiki for examples.

## To Do

Wallaby is still in development, and there are plans to improve its performance and add new features. Some of the planned improvements include:

- **Optimization**: Optimize the solver algorithm for improved efficiency.
- **New goals**: Add new goals to provide more control over constraints.
- **Documentation**: Add more documentation and tutorials to assist users.

## Credits
Wallaby is developed by [Ayoub Lharchi](<https://www.lharchi.com>) at the [Center for IT and Architecture](<https://royaldanishacademy.com/CITA>).

## License
Wallaby is released under the MIT License. See the LICENSE file for details.

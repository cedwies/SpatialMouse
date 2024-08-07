# PhysComp SS23 Assignment - Week 12

> **Deadline:** 16.07.2024, 23:59 CEST

# Weekly Progress Report

## Overview

This week marked significant advancements in our Spatial Mouse prototype development. We focused on refining both software and hardware components, addressing key usability issues, and attempting to create an improved physical model.

## Software Improvements

Our team made substantial progress in optimizing the Arduino code and enhancing the Unity project integration:

- We fine-tuned the mouse sensitivity in our Arduino code, resolving cursor tracking issues that had been hampering user experience.
- A clever delay mechanism was implemented to smoothen the transition between mouse and VR controller modes, eliminating accidental mode switches.
- In our Unity project, we tackled the challenging issue of cursor confinement in the VR environment. We developed a keyboard shortcut system (using the 'L' key) that allows users to lock and unlock the cursor to the Unity window, greatly improving overall usability.

It's worth noting that we still observe a minor Bluetooth signal delay, likely due to the low-energy Bluetooth version used with our Arduino nano ESP32. While noticeable, we've determined this doesn't significantly impact usability for our current prototype stage.

## Hardware Enhancements

On the hardware front, we made several key improvements to our prototype design:

1. We completely redesigned the casing to better accommodate internal components, addressing previous space constraints.
2. A dedicated On/Off switch was integrated for improved power management.
3. The Spatial Mouse body is now designed in two parts for easier assembly, complemented by a new lid design.
4. We reduced tolerances for 3D printed pieces, aiming for a tighter, more precise fit.
5. Internal cable lengths were optimized to make better use of the limited space.

These changes collectively aim to create a more robust, user-friendly device that's easier to assemble and maintain.

## 3D Printing Attempt

In an effort to bring our improved design to life, we initiated a 3D print using a smaller nozzle (0.25mm) for higher accuracy. Unfortunately, we encountered technical difficulties with the printer, resulting in an unsuccessful print and damage to the equipment.

![Prototype](./Figures/redesign-f3d.png){width=500px}

## Challenges and Lessons Learned

The 3D printer incident has been a valuable learning experience. It underscores the importance of proper equipment handling and the need to seek expert assistance when facing complex technical issues. We're taking this as an opportunity to deepen our understanding of 3D printing processes and equipment maintenance.



Despite the setback with the 3D printing, we're excited about the progress we've made and remain committed to bringing the Spatial Mouse project to fruition. This experience has not only advanced our technical skills but also strengthened our project management and problem-solving abilities.




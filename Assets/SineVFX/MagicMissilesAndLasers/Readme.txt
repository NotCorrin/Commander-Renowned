Magic Missiles And Lasers
Version 1.1 (01.08.2018)


IMPORTANT NOTES:

- Turn on "HDR" on your Camera, Particles and Shaders requires it
- This VFX Asset looks much better in "Linear Rendering", but there is also optimized Prefabs for "Gamma Rendering" Mode
- Image Effects are necessary in order to make a great looking game, as well as our asset. Be sure you using "Tone Mapping" and "Bloom"
- We also recommend using Deferred Rendering for better performance


HOW TO USE:

First of all, check for Demo Scene in Scenes folder. Also, there is a Prefabs folder with complete effects and parts of them.
Just Drag and Drop some prefabs into your scene. We made all Shaders very tweakable, so you can create your own unique effects.

All Magic Missiles are emitted from Standart Shuriken Particle System, so you can change all the parameters as you want. Source Point of Mesh Enchant
Effect can be controlled with an EnchantPoint Empty GameObject. Enchant Material is in the second slot of Enchanted Mesh.

Continuous Lasers can be tweaked in "Con Laser" Component. Laser Shots are prefabs, so you can change their parameters directly in Prefab Folder.


SHADERS:

All shaders have similar range of parameters, here is a quick overview of most important ones:

Final Power - Final brightness of the image, you need to lower this value if you using "Gamma Rendering" Mode
Ramp - Gradient texture for better visual style, if you want to use single color just select Ramp00.png
Noise01-05 - Some Noise textures, feel free to experiment with these
Mask - Primary mask of shader, you can change it but I won't recommend to
Color - Simple Color tint of your effect




Support email "sinevfx@gmail.com"
# GAPhoto

GAPhoto is a image-to-SVG converter based on a genetic algorithm, in C#.NET

## Building

Please use Visual Studio 2015 or higher.

## Operation

Starting with a supplied image, GAPhoto creates a canvas with a set of random polygons (selectable). The image and the rendered canvas are then compared to produce a total difference. The random set is then mutated, and compared again. If the new mutated image is 'closer' to the original, the new set is kept, otherwise it is discarded. This process is repeated as fast as the computer will allow, usually around a hundred times a second.

Over a long enough runtime, the render of the set of polygons will approximate the original image to a high degree. The set can be saved in SVG format.

## Credits

* Original code 2012 - Tom Cully
* 2018 Repack and update for Visual Studio - Ciarán Irvine
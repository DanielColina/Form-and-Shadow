Folders have meta data inside, materials should be set up.

Each folder will be placed in the models folder(unless otherwise specified) and will have a group of assets, the only thing that should be used in the level is in the prefab folder inside of the main folder, there should only be one or two things in this folder to use. When you replace something, make sure to hide the mesh render of the objects that are being replaced so you still have their collider. You may have to make your own adjustments to colliders if there is any issue, but most things are 1 to 1 scaling unless they are ambient pieces.

I will list some specifics below and update this doc accordingly when things are added.


GRATE-This is just a material, you can place it on a plane and you wil have a grate to work with. Use this as you like, it is mostly there so I can use it to complement other objects in scene.

PIPE OBJECTS-In the prefabs folder, there will be a few prefabs you can work with and world build with, upload these before the other folders as some of them reference this folder. You can try making your own prefabs if you like, pretty hard to vert snap it all together in unity though. A lot of the pipe stuff will be a later thing when the artists can have some time in the scene and the technical stuff is no longer needing any tampering with.

LAVA-When placing the lava prefab(called lavaFall_Prefab), make sure to drag into hierarchy as to not affect position. You can move different pieces separately after it is placed if something seems misplaced(the actual lava parts are in groups and should be moved via the groups, not the separate components. This should be the only thing you need to do for the lava

WALL VENT-In the puzzle objects folder, you can delete out the old wall vent folder and add the new one I've placed in the folder. There are six prefabs, a lit vent wall, an unlit vent wall, a long lit wall, a long unlit wall, a single lit vent, and an unlit vent. The walls should fit the walls you have, but if you dislike the size, light color or anything else, you can take the single wall vent and form your own prefab by vert snapp the corners of the vents together to create a wall, or scaling the wall prefabs accordingly.

FURNACE-When placing the furnace, you should only need to place the prefab in the prefab folder, it includes a light for the center pit and is positionally correct if you drag into hierarchy. Scale it directionally if it doesnty fit your needs exactly.The glass already in the scene above it should be left where it is, gears should be removed.

FILLER BOX-This will be placed for platforms, supports or anything that needs to be covered basically until further attention to the level can be given. Use at your own discretion and scale as you need, stretching is inevitable.

CANISTER HOLDER-This is right after the first piston puzzle, with the first checkpoint, it should be dragged into the hiearchy and its placement should be perfect, if not, vert snap the corner to place it properly. The glass should remain where it is.

PISTON PUZZLE-There will be two objects in the prefab folder, one is the puzzle base, the other is the puzzle piston. The puzzle base is in position, so just drag it into the hierarchy, the puzzle pistons will have to be manually placed to your liking since there is a script involved with their motions.


There may be some connnection issues with materials and/or lights, these will likely have to be adjusted later and in person if they occur.They shouldn't affect the gameplay in anyway. 


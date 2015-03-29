Hi there,

Thanks for downloading.
uFrame 1.5 is required.

***Important:***
There is a bug in uFrame 1.5 beta which produces '... error CS1061: Type 'AsteroidView' does not contain definition for BindComponentTriggerWith ...'.

Cause of this error is that ExtendedCollisionBinding.cs file from uFrame is in the wrong place.

It's in the uFrameComplete\uFrame\Editor\ uFrameEditors folder but it should be in uFrameComplete\uFrame\Base\Bindings folder.

Solution is simple: just move the file :).


I whoud have included the moved file in the package but I'm not allowed to do that.
I hope that the next uFrame relase will solve this problem. 

Please refer to 
http://answers.invertgamestudios.com/chat/binding-missing-bindviewtrigger2dwith
if you need more info.



This project is a conversion of the Space Shooter project from Unity Technologies.

uFrame knowlege is required for understaning of the inner workings.

If you are not familiar with uFrame you can find tutorials&resources here:
http://invertgamestudios.com/uFrameAPI/Default/webframe.html#uFrame%201.5%20Overview%20Video.html

It has follwing features:
- Asteroids - contained in LevelSystem subsystem
- Player Ship - contained in PlayerShipSystem subsystem
- Weapon System - contained in WeaponSystemSystem subsystem
- Powerup System - contained in PowerUpSystem subsystem

This project can be edited as any other uFrame project, by adding subsystems, new models/views etc...

One example of project extension whould be adding a new powerup.
This whould require adding new element to the PowerUpSystem subsystem, making the element inherit from PowerUpBase and overriding the ApplyPowerUp method in the new controller. You can refer to FireRatePowerUpController for example.

Support: http://answers.invertgamestudios.com/chat/space-shooter-for-uframe

Thanks for reading,
Zeljko




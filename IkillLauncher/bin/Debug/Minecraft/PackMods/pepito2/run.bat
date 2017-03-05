@echo off
set APPDATA=C:\Users\Alvaro\Documents\IkillLauncher\IkillLauncher\bin\Debug\PackMods\pepito2
java  -Xincgc -Xmx1024m -cp "%APPDATA%\.minecraft\bin\minecraft.jar;%APPDATA%\.minecraft\bin\lwjgl.jar;%APPDATA%\.minecraft\bin\lwjgl_util.jar;%APPDATA%\.minecraft\bin\jinput.jar" -Djava.library.path="%APPDATA%\.minecraft\bin\natives" net.minecraft.client.Minecraft %1
break
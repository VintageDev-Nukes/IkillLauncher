@echo off
set APPDATA=C:\Users\Alvaro\Documents\IkillLauncher\IkillLauncher\bin\Debug\PackMods\klaverl
java  -Xincgc -Xmx%1m -Xms%2m -cp "%APPDATA%\.minecraft\bin\minecraft.jar;%APPDATA%\.minecraft\bin\lwjgl.jar;%APPDATA%\.minecraft\bin\lwjgl_util.jar;%APPDATA%\.minecraft\bin\jinput.jar" -Djava.library.path="%APPDATA%\.minecraft\bin\natives" net.minecraft.client.Minecraft %3
break

@Echo off
setlocal enabledelayedexpansion

For %%# in ("C:\Users\Alvaro\Documents\IkillLauncher\IkillLauncher\bin\Debug\Art\im\*.png") Do (
    set /A num+=1
    Ren "%%#" "!num!%%~x#"
)
pause
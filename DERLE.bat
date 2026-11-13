@echo off
chcp 65001 >nul
setlocal enabledelayedexpansion
cd /d "%~dp0"

echo ==================================================
echo   CILT BAKIM STOK ASISTANI - OTOMATIK EXE URETICI
echo ==================================================
echo.

set "PROJ=CiltBakimStokAsistani\CiltBakimStokAsistani.csproj"

REM --------------------------------------------------
REM 1) MSBuild'i bul (vswhere ile)
REM --------------------------------------------------
echo [1/3] MSBuild araniyor...
set "MSBUILD="
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist "%VSWHERE%" (
    for /f "usebackq tokens=*" %%i in (`"%VSWHERE%" -latest -prerelease -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe`) do set "MSBUILD=%%i"
)
if "%MSBUILD%"=="" (
    echo.
    echo HATA: MSBuild bulunamadi. Bilgisayarda Visual Studio veya
    echo "Build Tools for Visual Studio" yuklu olmali.
    pause
    exit /b 1
)
echo       Bulundu: !MSBUILD!

REM --------------------------------------------------
REM 2) NuGet paketlerini geri yukle (PackageReference)
REM    MSBuild paketi ve native SQLite.Interop.dll'leri otomatik cozer.
REM --------------------------------------------------
echo [2/3] Paketler geri yukleniyor (Restore)...
"!MSBUILD!" "%PROJ%" /t:Restore /p:Configuration=Release /v:minimal /nologo
if errorlevel 1 (
    echo.
    echo HATA: Paket geri yukleme basarisiz. Internet baglantinizi kontrol edin.
    pause
    exit /b 1
)

REM --------------------------------------------------
REM 3) Projeyi Release modunda derle
REM --------------------------------------------------
echo [3/3] Proje derleniyor (Release)...
"!MSBUILD!" "%PROJ%" /t:Rebuild /p:Configuration=Release /p:Platform=AnyCPU /v:minimal /nologo
if errorlevel 1 (
    echo.
    echo HATA: Derleme basarisiz oldu. Yukaridaki mesajlari kontrol edin.
    pause
    exit /b 1
)

REM --------------------------------------------------
REM EXE'yi .slnx'in BIR UST klasorune kopyala
REM (exe + System.Data.SQLite.dll + x86\ + x64\ birlikte)
REM --------------------------------------------------
for %%I in ("%~dp0..") do set "USTKLASOR=%%~fI"
echo Cikti dosyalari ust klasore kopyalaniyor:
echo    !USTKLASOR!
xcopy "CiltBakimStokAsistani\bin\Release\*" "!USTKLASOR!" /E /I /Y /Q >nul

echo.
echo ==================================================
echo   TAMAMLANDI!
echo.
echo   CiltBakimStokAsistani.exe artik .slnx'in BIR UST
echo   klasorunde:
echo   !USTKLASOR!
echo.
echo   Oradaki .exe ile birlikte System.Data.SQLite.dll,
echo   x86\ ve x64\ klasorlerini beraber baska bilgisayara
echo   kopyalayip calistirabilirsiniz. Veritabani (ornek
echo   15 urunle) ilk acilista otomatik olusur.
echo   (Verileri gormek icin girise "Damla" veya "hira" yazin.)
echo ==================================================
echo.

if exist "!USTKLASOR!\CiltBakimStokAsistani.exe" (
    start "" "!USTKLASOR!"
)
pause

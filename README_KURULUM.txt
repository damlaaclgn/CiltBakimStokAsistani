==========================================================
 CILT BAKIM STOK ASISTANI - GOMULU VERITABANI SURUMU
==========================================================

NE DEGISTI?
-----------
Eski surum SQL Server'a (.\SQLEXPRESS) / LocalDB'ye (.mdf) baglaniyordu;
bu yuzden baska bilgisayarda (SQL Server kurulu olmadigi icin) acilmiyordu.

Yeni surumde veritabani GOMULU SQLite'a tasindi:
  * Hicbir sunucu / kurulum gerektirmez.
  * Veritabani tek dosyadir: CiltBakimDb.db
  * Bu dosya, .exe'nin yaninda ILK ACILISTA OTOMATIK olusur.
  * Tablo (Urunler) otomatik kurulur ve ornek verilerle dolar.


EN KOLAY YOL: DERLE.bat (tek tik)
---------------------------------
DERLE.bat dosyasina cift tikla. Bu dosya:
  1) Visual Studio'nun MSBuild'ini bulur,
  2) SQLite paketini ve native SQLite.Interop.dll'leri OTOMATIK indirir,
  3) projeyi Release modunda derler ve exe'yi uretir,
  4) sonunda cikti klasorunu (bin\Release) otomatik acar.

NuGet ile elle ugrasmana GEREK YOK; bat hepsini halleder.

Sart: Bilgisayarda Visual Studio (veya "Build Tools for Visual
Studio") ve internet baglantisi olmali. (Projeyi zaten VS'de
derledigin icin ikisi de mevcut.)


BASKA BILGISAYARDA CALISTIRMA
-----------------------------
- Derleme bitince bin\Release klasorunun TAMAMINI kopyala.
  Icinde sunlar olur:
      CiltBakimStokAsistani.exe
      System.Data.SQLite.dll
      x86\SQLite.Interop.dll
      x64\SQLite.Interop.dll
  (Sadece .exe'yi tek basina degil, klasoru komple tasi.)

- Hedef bilgisayarda yalnizca .NET Framework 4.7.2 gerekir; bu da
  Windows 10/11'de zaten yukludur. Baska hicbir kurulum gerekmez.

- .exe ilk acildiginda yaninda CiltBakimDb.db kendiliginden olusur.


ALTERNATIF: Visual Studio ile elle
----------------------------------
1. CiltBakimStokAsistani.slnx dosyasini VS ile ac.
2. Build > Build Solution (Ctrl+Shift+B). VS, PackageReference
   sayesinde SQLite paketini otomatik geri yukler.


NOTLAR
------
- Ornek (baslangic) urunleri eski .mdf'ten kurtarilan yaklasik
  verilerdir. Istemiyorsan program icinden silip kendi urunlerini
  ekleyebilirsin. (Tablo bosken acilirsa ornekler yeniden yuklenir.)

- .exe'yi Program Files gibi yazma korumali bir klasore koyma;
  Masaustu, Belgeler veya USB gibi yazilabilir bir yer kullan,
  yoksa .db dosyasi olusturulamaz.

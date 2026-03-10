# DuckDBDemo UI Komponensek - Dokumentációs Index

Ez a dokumentációs gyűjtemény a **DuckDBDemo projekt** egyedi UI komponenseit és stílusait tartalmazza részletes leírással, példákkal és best practice-ekkel.

---

## 📚 Dokumentációk

### 🎨 Interaktív Komponensek

#### 1. [TileMenuItemControl](TileMenuItemControl-Documentation.md)
Modern, kártyastílusú menüelem komponens.

**Főbb Jellemzők:**
- ✅ Színes fejléc dekoratív hullámvonalakkal
- ✅ Image, Lottie vagy SVG path ikonok
- ✅ Hover effekt (sötétedő fejléc/border)
- ✅ Navigációs nyíl
- ✅ MVVM és Click event támogatás

**Ideális használat:** Főmenü, dashboard navigáció, funkciók gyors elérése

---

#### 2. [AuditCardControl](AuditCardControl-Documentation.md)
Kompakt statisztikai kártya komponens.

**Főbb Jellemzők:**
- ✅ Háromrétegű struktúra (fejléc, tartalom, lábléc)
- ✅ Ikonos fejléc (Image vagy SVG path)
- ✅ Nagy számok megjelenítése (28px)
- ✅ Hover és pressed effektek
- ✅ Opcionális navigációs nyíl

**Ideális használat:** Dashboard KPI-ok, statisztikai összefoglalók, metrikák

---

#### 3. [LottieControl](LottieControl-Documentation.md)
Lottie JSON animációk megjelenítése SkiaSharp-pal.

**Főbb Jellemzők:**
- ✅ Adobe After Effects animációk
- ✅ Hardveres gyorsítású rendering
- ✅ Play/Pause/Repeat vezérlés
- ✅ Skálázható vektoros animáció
- ✅ 60 FPS lejátszás

**Ideális használat:** Loading indicator-ok, success/error feedback, dekoratív animációk

---

### 🎭 Stílusok és Témák

#### 4. [Button Stílusok](Button-Documentation.md)
Globális Material Design inspirálta button stílusok.

**Főbb Jellemzők:**
- ✅ Implicit stílus (minden Button-ra)
- ✅ Attached Properties (CornerRadius, HoverBackground)
- ✅ Hover és Pressed állapotok
- ✅ Disabled állapot kezelés
- ✅ Színpaletta javaslatok

**Ideális használat:** Űrlapok, dialógusok, toolbar-ok

---

#### 5. [DataGrid Stílusok](DataGrid-Documentation.md)
Modern táblázat stílusok sötét fejléccel.

**Főbb Jellemzők:**
- ✅ Sötét fejléc (#2C3E50)
- ✅ Zebra csíkozás
- ✅ Kék kijelölés (#E3F2FD)
- ✅ Rendezés vizualizáció (nyíl)
- ✅ Virtualizáció (nagy adathalmazokhoz)
- ✅ Consolas font (számokhoz)

**Ideális használat:** Adattáblázatok, listák, jelentések, admin felületek

---

### 🎭 Segédeszközök

#### 6. [Emoji](Emoji-Documentation.md)
Előre definiált emoji konstansok gyűjteménye.

**Főbb Jellemzők:**
- ✅ Statikus konstansok (Emoji.Check, Emoji.Fire, stb.)
- ✅ Kategorizált (Common, Finance, Data, Tools)
- ✅ IntelliSense támogatás
- ✅ XAML és C# használat
- ✅ 60+ előre definiált emoji

**Ideális használat:** UI jelzések, státusz ikonok, user-friendly üzenetek

---

#### 7. [Colors](Colors-Documentation.md)
Központi színpaletta rendszer Bootstrap-szerű kategorizálással.

**Főbb Jellemzők:**
- ✅ Bootstrap kategóriák (Primary, Success, Danger, Warning, Info, Secondary)
- ✅ Material Design színek
- ✅ Color és Brush változatok
- ✅ Árnyalatok (Dark, Darker, Light, Lighter)
- ✅ Szürke skála (Gray100-Gray900)
- ✅ Grafikon színek (8 előre definiált szín)
- ✅ Helper metódusok (WithOpacity, FromHex)

**Ideális használat:** Egységes színséma, téma kezelés, brand colors

---

## 🚀 Gyors Kezdés

### Telepítés

1. Másold az `UI` mappát a projektedbe
2. Hivatkozd a komponenseket az XAML-ben:
   ```xaml
   xmlns:ui="clr-namespace:DuckDBDemo.UI"
   ```
3. Használd a komponenseket:
   ```xaml
   <ui:TileMenuItemControl ... />
   <ui:AuditCardControl ... />
   <ui:LottieControl ... />
   ```

### NuGet Csomagok

A következő csomagok szükségesek:
- **SkiaSharp** (LottieControl-hoz)
- **SkiaSharp.Skottie** (LottieControl-hoz)
- **SkiaSharp.Views.WPF** (LottieControl-hoz)

```bash
dotnet add package SkiaSharp
dotnet add package SkiaSharp.Skottie
dotnet add package SkiaSharp.Views.WPF
```

---

## 📖 Dokumentáció Struktúra

Minden dokumentáció tartalmazza:

1. **Áttekintés** - Komponens leírása és főbb jellemzők
2. **Dependency Properties** - Összes beállítható property táblázattal
3. **Vizuális Működés** - Hover, pressed, disabled állapotok
4. **Használati Példák** - 5-7 gyakorlati példa kóddal
5. **Layout Ajánlások** - Elrendezési javaslatok
6. **Színpaletta** - Javasolt színkombinációk
7. **Best Practices** - ✅ Jó / ❌ Kerülendő gyakorlatok
8. **Hibaelhárítás** - Gyakori problémák és megoldások

---

## 🎨 Színpaletta Gyorsreferencia

> **Megjegyzés**: A teljes színpaletta a [Colors osztályban](Colors-Documentation.md) található részletes leírással.

### Material Design Alapszínek (Colors osztály)

```
Kék:      #2196F3  (Info, alapértelmezett)
Zöld:     #2ECC71  (Siker, jóváhagyás)
Piros:    #E74C3C  (Hiba, törlés)
Narancs:  #FF9800  (Figyelmeztetés)
Lila:     #9B59B6  (Speciális, admin)
Szürke:   #95A5A6  (Semleges, mégse)
```

### Sötét Árnyalatok (Hover)

```
Kék:      #1976D2
Zöld:     #27AE60
Piros:    #C0392B
Narancs:  #F57C00
Lila:     #7B1FA2
Szürke:   #7F8C8D
```

---

## 🛠️ Egyedi Testreszabás

### Button Stílus Felülírása

```xaml
<Button 
    Content="Egyedi Gomb"
    Background="#E74C3C"
    ui:ButtonAssist.CornerRadius="10"
    ui:ButtonAssist.HoverBackground="#C0392B" />
```

### DataGrid Fejléc Színe

```xaml
<DataGrid.Resources>
    <Style TargetType="DataGridColumnHeader" BasedOn="{StaticResource {x:Type DataGridColumnHeader}}">
        <Setter Property="Background" Value="#9B59B6" />
    </Style>
</DataGrid.Resources>
```

### TileMenuItemControl Hover Effekt

```xaml
<ui:TileMenuItemControl
    HeaderBackground="#3498DB"
    ... />
<!-- Hover: opacity 0.7 automatikus -->
```

---

## 📋 Példa Projekt

A `MainWindow.xaml` fájl egy működő példát tartalmaz az összes komponens használatára:

```xaml
<!-- Fejléc Lottie animációkkal -->
<ui:LottieControl Source="Assets/duck-animation.json" IsPlaying="True" RepeatCount="-1" />

<!-- Tile menü -->
<ui:TileMenuItemControl
    TitleText="Adatbázis inicializálása"
    HeaderBackground="#2ECC71"
    HeaderLottieSource="Assets/server.json"
    Click="BtnInitialize_Click" />

<!-- Audit kártyák -->
<ui:AuditCardControl
    TitleText="Összes tétel"
    ContentText="12,450"
    TitleBackground="#3498DB" />

<!-- DataGrid -->
<DataGrid ItemsSource="{Binding Items}" />

<!-- Gombok -->
<Button Content="Mentés" />
<Button Content="{x:Static ui:Emoji.Check}" />
```

---

## 🔗 További Erőforrások

### Lottie Animációk

- [LottieFiles](https://lottiefiles.com/) - Ingyenes animáció könyvtár
- [Lordicon](https://lordicon.com/) - Prémium ikonok
- [Icons8 Animated Icons](https://icons8.com/animated-icons)

### Material Design

- [Material Design Colors](https://materialui.co/colors) - Színpaletta
- [Material Icons](https://fonts.google.com/icons) - SVG path ikonok
- [Material Design Guidelines](https://m3.material.io/)

### Emoji Referencia

- [Emojipedia](https://emojipedia.org/)
- [Unicode Tables](https://unicode-table.com/en/sets/emoji/)
- [Get Emoji](https://getemoji.com/)

---

## 📝 Verzió Történet

| Verzió | Dátum | Változások |
|--------|-------|-----------|
| 1.0 | 2024-01 | Kezdeti kiadás - Összes komponens és dokumentáció |

---

## 👥 Közreműködés

Ha hibát találsz vagy javítási javaslatod van:
1. Nyiss egy issue-t a GitHub repository-ban
2. Vagy küldj pull request-et a javítással
3. Vagy jelezd a projekt maintainer-ének

---

## 📄 Licence

Ezek a komponensek a **DuckDBDemo projekt** részei, és **belső felhasználásra** készültek.

---

**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt csapata  
**Contact**: [projekt email vagy link]

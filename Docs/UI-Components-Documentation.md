# UI Komponensek Programozói Dokumentáció

> **Megjegyzés**: Ez egy összefoglaló dokumentáció. Az egyes komponensekhez részletes, önálló dokumentációk is elérhetők:
> - [TileMenuItemControl](TileMenuItemControl-Documentation.md) - Csempe menü komponens
> - [AuditCardControl](AuditCardControl-Documentation.md) - Statisztikai kártya komponens  
> - [LottieControl](LottieControl-Documentation.md) - Lottie animációk megjelenítése  
> - [Button Stílusok](Button-Documentation.md) - Globális gomb stílusok  
> - [DataGrid Stílusok](DataGrid-Documentation.md) - Táblázat stílusok  
> - [Emoji](Emoji-Documentation.md) - Emoji konstansok gyűjteménye

---

## Tartalomjegyzék

1. [TileMenuItemControl](#tilemenuitemcontrol) - *Részletek a külön dokumentációban*
2. [AuditCardControl](#auditcardcontrol) - *Részletek a külön dokumentációban*
3. [LottieControl](#lottiecontrol) - *Részletek a külön dokumentációban*
4. [Button Stílusok](#button-stílusok) - *Részletek a külön dokumentációban*
5. [DataGrid Stílusok](#datagrid-stílusok) - *Részletek a külön dokumentációban*
6. [Emoji](#emoji) - *Részletek a külön dokumentációban*

---

## TileMenuItemControl

### Áttekintés

A `TileMenuItemControl` egy modern, kártyastílusú menüelem komponens WPF alkalmazásokhoz. A komponens támogatja a következő funkciókat:
- Színes fejléc dekoratív hullámvonalakkal
- Lebegő ikon konténer (Image, Lottie animáció vagy SVG path)
- Cím és leírás szöveg
- Hover effekt (sötétedő fejléc és border)
- Navigációs nyíl (opcionális)
- Click event és Command támogatás
- IsEnabled állapot kezelés

### Fájlok

- **XAML**: `UI/TileMenuItemControl.xaml`
- **Code-behind**: `UI/TileMenuItemControl.xaml.cs`
- **Namespace**: `DuckDBDemo.UI`

---

### Dependency Properties

#### Interaktivitás

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `Command` | `ICommand` | `null` | MVVM parancs, amit a tile kattintáskor végrehajt |
| `CommandParameter` | `object` | `null` | A Command-hoz tartozó paraméter |
| `ShowArrow` | `bool` | `true` | Navigációs nyíl megjelenítése (read-only, automatikus) |
| `Click` | `RoutedEvent` | - | Routed event a kattintás kezelésére |

#### Fejléc megjelenés

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `HeaderBackground` | `Brush` | `SteelBlue` | Fejléc háttérszíne (egyben a border színe is) |
| `HeaderText` | `string` | `""` | Fejlécben megjelenő szöveg (opcionális) |
| `HeaderTextColor` | `Brush` | `White` | Fejléc szöveg színe |

#### Ikon (prioritási sorrend)

Az ikon megjelenítésének prioritási sorrendje:
1. **Image** (`HeaderIcon`)
2. **Lottie** (`HeaderLottieSource`)
3. **Path** (`HeaderIconPathData`)

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `HeaderIcon` | `ImageSource` | `null` | Kép fájl (PNG, JPG, stb.) |
| `HeaderLottieSource` | `string` | `""` | Lottie JSON fájl elérési útja |
| `HeaderIconPathData` | `string` | `""` | SVG path adat (Material Design ikonok) |
| `HeaderIconForeground` | `Brush` | `White` | Path ikon színe |
| `HeaderIconSize` | `double` | `32` | Ikon mérete pixel-ben |

#### Tartalom

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `TitleText` | `string` | `""` | Fő cím szöveg (félkövér, 20px) |
| `TitleColor` | `Brush` | `Black` | Cím szöveg színe |
| `DescriptionText` | `string` | `""` | Leírás szöveg (13px, tördelve) |
| `DescriptionColor` | `Brush` | `Gray` | Leírás szöveg színe |
| `Background` | `Brush` | (örökölt) | Tile háttérszíne |

#### Belső állapotok (read-only)

Ezek a property-k automatikusan kezelődnek, nem kell külön beállítani őket:

| Property | Típus | Leírás |
|----------|-------|--------|
| `IsHeaderIconVisible` | `bool` | Bármilyen ikon látható-e |
| `IsHeaderImageIconVisible` | `bool` | Image ikon látható-e |
| `IsHeaderLottieIconVisible` | `bool` | Lottie ikon látható-e |
| `IsHeaderPathIconVisible` | `bool` | Path ikon látható-e |
| `IsHeaderTextVisible` | `bool` | Fejléc szöveg látható-e |

---

### Vizuális Működés

#### Hover Effekt

Amikor az egér a tile fölé kerül:
- A **fejléc** (`Header`) opacity-ja `0.7`-re csökken (sötétedés)
- A **border** színének opacity-ja `0.7`-re csökken
- Az **egérkursor** "kéz" ikonra vált
- **Smooth átmenet** (WPF automatikus trigger alapú)

#### Pressed Effekt

Amikor a tile-ra kattintanak:
- Az egész **tile opacity-ja** `0.96`-ra csökken

#### Disabled Állapot

Amikor `IsEnabled="False"`:
- Az egész **tile opacity-ja** `0.75`-re csökken
- A tile **nem kattintható**

#### Fejléc Dekoráció

A fejlécben 4 réteg dekoratív hullámvonal található:
- **Opacity**: 0.05, 0.12, 0.22, 0.08
- **Szín**: Fekete (overlay a HeaderBackground fölött)
- **Renderelés**: SVG path adatokból, Viewbox-ban skálázva

---

### Használati Példák

#### 1. Alapvető Click Event

```xaml
<ui:TileMenuItemControl
    TitleText="Adatbázis inicializálása"
    DescriptionText="DuckDB kapcsolat és alap táblák létrehozása"
    HeaderBackground="#2ECC71"
    HeaderIconPathData="M480-120q-151 0-255.5-46.5T120-280v-400..."
    HeaderIconForeground="White"
    HeaderIconSize="40"
    Click="BtnInitialize_Click" />
```

Code-behind:
```csharp
private void BtnInitialize_Click(object sender, RoutedEventArgs e)
{
    // Művelet végrehajtása
}
```

#### 2. Lottie Animációval

```xaml
<ui:TileMenuItemControl
    TitleText="Grafikonok demo"
    DescriptionText="LiveCharts2 grafikon galéria megnyitása"
    HeaderBackground="#3498DB"
    HeaderLottieSource="Assets/bar_chart.json"
    HeaderIconSize="40"
    Click="BtnCharts_Click" />
```

A Lottie animáció:
- Automatikusan **lejátszódik** (`IsPlaying="True"`)
- **Végtelen ciklusban** ismétlődik (`RepeatCount="-1"`)

#### 3. MVVM Command Binding

```xaml
<ui:TileMenuItemControl
    TitleText="Mentés"
    DescriptionText="Adatok mentése"
    HeaderBackground="#E74C3C"
    HeaderIconPathData="M..."
    Command="{Binding SaveCommand}"
    CommandParameter="{Binding CurrentData}" />
```

ViewModel:
```csharp
public ICommand SaveCommand { get; }

public MainViewModel()
{
    SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
}

private void ExecuteSave(object parameter)
{
    // Mentés logika
}

private bool CanExecuteSave(object parameter)
{
    return true; // vagy feltétel
}
```

#### 4. Dinamikus Enable/Disable

```xaml
<ui:TileMenuItemControl
    TitleText="Főkönyvi kivonat"
    DescriptionText="Számlaegyenlegek megtekintése"
    HeaderBackground="#2C3E50"
    HeaderLottieSource="Assets/finance.json"
    IsEnabled="{Binding ElementName=btnAccountBalances, Path=IsEnabled}"
    Click="BtnAccountBalances_Click" />

<!-- Hidden state carrier -->
<Button x:Name="btnAccountBalances" 
        IsEnabled="False" 
        Visibility="Collapsed" />
```

Code-behind:
```csharp
// Engedélyezés után importálás
btnAccountBalances.IsEnabled = true;
```

#### 5. Image Ikon Használata

```xaml
<ui:TileMenuItemControl
    TitleText="Profil"
    DescriptionText="Felhasználói beállítások"
    HeaderBackground="#34495E"
    HeaderIcon="Assets/user-avatar.png"
    HeaderIconSize="45"
    Click="BtnProfile_Click" />
```

---

### Layout és Méretek

#### Javasolt Elrendezés

A tile-ok **Grid** layoutban, egyenlő oszlopokkal:

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="12" />  <!-- Spacing -->
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="12" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>
    
    <ui:TileMenuItemControl Grid.Column="0" MaxWidth="400" ... />
    <ui:TileMenuItemControl Grid.Column="2" MaxWidth="400" ... />
    <ui:TileMenuItemControl Grid.Column="4" MaxWidth="400" ... />
</Grid>
```

#### Méret Ajánlások

- **Magasság**: ~140px (auto, tartalom alapján)
- **Szélesség**: Flexibilis (*), max. 400-420px ajánlott
- **Ikon méret**: 32-45px (HeaderIconSize)
- **Padding**: 16px körül a Grid-ben
- **Spacing**: 12px tile-ok között

---

### Színpaletta Javaslatok

#### Zöld árnyalatok (Siker, Létrehozás)
```
#2ECC71 - Smaragdzöld
#27AE60 - Sötétzöld
#5FA46A - Olívazöld
```

#### Kék árnyalatok (Info, Lekérdezés)
```
#3498DB - Tiszta kék
#2980B9 - Sötétkék
#5DADE2 - Világoskék
```

#### Szürke árnyalatok (Semleges, Törlés)
```
#95A5A6 - Világosszürke
#7F8C8D - Közép szürke
#2C3E50 - Sötétszürke (csaknem fekete)
```

#### Lila árnyalatok (Speciális, Admin)
```
#9B59B6 - Ametiszt
#8E44AD - Lila
```

#### Piros árnyalatok (Veszély, Figyelmeztetés)
```
#E74C3C - Világospiros
#C0392B - Sötétpiros
```

---

### Belső Működés

#### UpdateInteractivity()

Ez a metódus automatikusan kezeli a `ShowArrow` property értékét:

```csharp
private void UpdateInteractivity()
{
    ShowArrow = Command is not null || _clickHandlerCount > 0;
}
```

- Ha van `Command` VAGY van `Click` handler → `ShowArrow = true`
- Különben → `ShowArrow = false`

**Megjegyzés**: Alapértelmezetten a `ShowArrow` értéke `true`, így az arrow minden tile-on megjelenik.

#### UpdateHeaderVisibility()

Ez a metódus kezeli az ikon típusok prioritását:

```csharp
private void UpdateHeaderVisibility()
{
    var hasImage = HeaderIcon is not null;
    var hasPath = !string.IsNullOrWhiteSpace(HeaderIconPathData);
    var hasLottie = !string.IsNullOrWhiteSpace(HeaderLottieSource);

    // Priority: Image > Lottie > Path
    IsHeaderImageIconVisible = hasImage;
    IsHeaderLottieIconVisible = !hasImage && hasLottie;
    IsHeaderPathIconVisible = !hasImage && !hasLottie && hasPath;
    
    IsHeaderIconVisible = IsHeaderImageIconVisible || 
                          IsHeaderPathIconVisible || 
                          IsHeaderLottieIconVisible;
    
    IsHeaderTextVisible = !string.IsNullOrWhiteSpace(HeaderText);
}
```

**Prioritás**:
1. Ha van `HeaderIcon` (kép), csak azt mutatja
2. Ha nincs kép, de van `HeaderLottieSource`, akkor Lottie-t
3. Ha nincs kép és Lottie, de van `HeaderIconPathData`, akkor path-ot

---

### XAML Struktúra

```
UserControl (TileMenuItemControl)
└── Button (RootButton, transparent)
    └── ControlTemplate
        └── Border (Card) ← Hover/Press effekt célpontja
            └── Grid (Background=Transparent) ← Teljes terület hover-érzékeny
                ├── Border (Header) ← Színes fejléc
                │   └── Grid
                │       └── 4× Viewbox/Path (Dekoratív hullámok)
                ├── Border (Lebegő ikon konténer)
                │   └── Grid
                │       ├── Image (HeaderIcon)
                │       ├── LottieControl (HeaderLottieSource)
                │       └── Viewbox/Path (HeaderIconPathData)
                └── Grid (Body)
                    ├── StackPanel
                    │   ├── TextBlock (TitleText)
                    │   └── TextBlock (DescriptionText)
                    └── Border (Arrow konténer)
                        └── Viewbox/Path (Nyíl)
```

---

### Best Practices

#### ✅ Jó Gyakorlatok

1. **Használj MaxWidth-et** a tile-okon a túl széles megjelenés elkerülésére
2. **Színes HeaderBackground** használata a vizuális megkülönböztetéshez
3. **Rövid, tömör** TitleText (1-3 szó)
4. **Egy mondatos** DescriptionText (max. 2 sor)
5. **Konzisztens** ikon méretek (HeaderIconSize)
6. **Lottie animációk** használata a dinamikus megjelenéshez
7. **IsEnabled binding** használata dinamikus állapotkezeléshez

#### ❌ Kerülendő

1. ❌ Túl hosszú TitleText (több sor)
2. ❌ Túl részletes DescriptionText (3+ sor)
3. ❌ Több ikon típus egyszerre (auto prioritás van)
4. ❌ Túl apró (< 25px) vagy túl nagy (> 50px) ikonok
5. ❌ Alacsony kontrasztú színek (olvashatóság)
6. ❌ Click és Command egyidejű használata (válassz egyet)

---

### Hibaelhárítás

#### Arrow nem jelenik meg

**Probléma**: A navigációs nyíl nem látszik.

**Megoldás**:
- Ellenőrizd, hogy a `ShowArrow` property értéke `true`
- A `ShowArrow` alapértelmezetten `true`, de ha programozottan `false`-ra van állítva, akkor nem jelenik meg

#### Hover effekt nem működik az egész tile-on

**Probléma**: Csak a fejléc és a szövegek felett működik a hover.

**Megoldás**:
- A belső Grid-nek **Background="Transparent"** kell lennie
- Ez biztosítja, hogy az üres területek is reagáljanak az egér eseményekre

#### Lottie animáció nem töltődik be

**Probléma**: A Lottie JSON fájl nem jelenik meg.

**Megoldás**:
1. Ellenőrizd a fájl elérési útját (`HeaderLottieSource`)
2. Győződj meg róla, hogy a JSON fájl **Build Action = Content** és **Copy to Output Directory = Copy if newer**
3. Ellenőrizd, hogy nincs-e `HeaderIcon` beállítva (az elsőbbséget élvez)

#### Border színe nem változik hover-nél

**Probléma**: A border színe nem sötétedik hover esetén.

**Megoldás**:
- A `HeaderBackground`-nak **SolidColorBrush**-nak kell lennie
- Ha GradientBrush-t vagy más összetett brush-t használsz, a hover effekt nem fog működni

---

## LottieControl

### Áttekintés

A `LottieControl` egy WPF UserControl, amely Lottie JSON animációkat jelenít meg. A komponens a SkiaSharp és SkiaSharp.Skottie könyvtárakra épül.

### Fájlok

- **XAML**: `UI/LottieControl.xaml`
- **Code-behind**: `UI/LottieControl.xaml.cs`
- **Namespace**: `DuckDBDemo.UI`

### Dependency Properties

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `Source` | `string` | `""` | Lottie JSON fájl elérési útja |
| `IsPlaying` | `bool` | `false` | Animáció lejátszása |
| `RepeatCount` | `int` | `0` | Ismétlések száma (-1 = végtelen) |

### Használati Példák

#### Alapvető használat

```xaml
<ui:LottieControl
    Width="60"
    Height="60"
    Source="Assets/duck-animation-02.json"
    IsPlaying="True"
    RepeatCount="-1" />
```

#### Programozott vezérlés

```csharp
// Start
lottieControl.IsPlaying = true;

// Stop
lottieControl.IsPlaying = false;

// Egyszeri lejátszás
lottieControl.RepeatCount = 1;
lottieControl.IsPlaying = true;
```

---

## Stílusok és Témák

### Globális Színpaletta

A `MainWindow.xaml`-ben használt konzisztens színek:

```xaml
<!-- Háttér -->
<Window Background="#F8F9FA" />

<!-- Kártyák háttere -->
<Border Background="White" 
        BorderBrush="#E0E0E0" 
        BorderThickness="1" />

<!-- Szöveg színek -->
<TextBlock Foreground="#2C3E50" />  <!-- Fő szöveg -->
<TextBlock Foreground="Gray" />     <!-- Másodlagos szöveg -->

<!-- Árnyék effekt -->
<DropShadowEffect BlurRadius="10" 
                  Opacity="0.1" 
                  ShadowDepth="2" 
                  Color="Black" />
```

### Custom Stílusok

A `UI/Button.xaml` és `UI/DataGrid.xaml` fájlok egyedi stílusokat tartalmaznak a gombok és táblázatok formázásához.

---

## Összefoglalás

A `TileMenuItemControl` és `LottieControl` komponensek együtt modern, animált és interaktív felhasználói felületet biztosítanak WPF alkalmazásokhoz. A komponensek teljesen testreszabhatók, támogatják az MVVM mintát, és könnyen integrálhatók meglévő projektekbe.

### Főbb Előnyök

✅ **Modern megjelenés** - Material Design inspirálta vizuális stílus  
✅ **Animált ikonok** - Lottie JSON támogatás  
✅ **Flexibilis** - Image, Lottie és SVG path ikonok  
✅ **MVVM kompatibilis** - Command és Click event támogatás  
✅ **Reszponzív** - Hover és pressed állapotok  
✅ **Könnyen használható** - Declaratív XAML szintaxis  

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Licence**: Belső felhasználásra

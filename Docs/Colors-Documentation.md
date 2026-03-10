# Colors Osztály Dokumentáció

## Áttekintés

A `Colors` osztály egy **központi színpaletta rendszer**, amely Bootstrap-szerű kategorizálást és Material Design színeket használ. Célja az egységes színhasználat biztosítása az egész alkalmazásban.

### Főbb Jellemzők

- ✅ **Bootstrap-szerű kategorizálás**: Primary, Success, Danger, Warning, Info, Secondary
- ✅ **Material Design színek**: Modern, professzionális paletta
- ✅ **Color és Brush verzió**: Mindkettő elérhető
- ✅ **Árnyalatok**: Dark, Darker, Light, Lighter változatok
- ✅ **Szürke skála**: Gray100-Gray900 (10 árnyalat)
- ✅ **Grafikon színek**: 8 előre definiált szín adatvizualizációhoz
- ✅ **Helper metódusok**: WithOpacity, WithAlpha, FromHex

---

## Fájlok

- **Code**: `UI/Colors.cs`
- **Namespace**: `DuckDBDemo.UI`

---

## Színkategóriák

> **Új funkció**: Minden fő színkategória most **Tailwind CSS-szerű 50-900 skálával** is elérhető a finomabb kontroll érdekében!

### Primary (Elsődleges - Kék) - Teljes Skála

Alapértelmezett akció gombok, linkek, elsődleges UI elemek.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Primary50` | #E3F2FD | Legvilágosabb - háttér, kijelölés |
| `Primary100` | #BBDEFB | Nagyon világos |
| `Primary200` | #90CAF9 | Világos |
| `Primary300` | #64B5F6 | Közepes világos |
| `Primary400` | #42A5F5 | Világos-közepes |
| `Primary500` | #2196F3 | **Alap kék** - normál állapot |
| `Primary600` | #1E88E5 | Közepes sötét |
| `Primary700` | #1976D2 | Sötét - **hover** |
| `Primary800` | #1565C0 | Nagyon sötét - **pressed** |
| `Primary900` | #0D47A1 | Legsötétebb |

#### Legacy Nevek (Backward Compatibility)

| Konstans | Alias | Hex | Használat |
|----------|-------|-----|-----------|
| `Primary` | `Primary500` | #2196F3 | Normál állapot |
| `PrimaryDark` | `Primary700` | #1976D2 | Hover állapot |
| `PrimaryDarker` | `Primary800` | #1565C0 | Pressed állapot |
| `PrimaryLight` | `Primary50` | #E3F2FD | Kijelölés háttér |
| `PrimaryLighter` | `Primary100` | #BBDEFB | Hover kijelölés |

### Success (Siker - Zöld) - Teljes Skála

Sikeres műveletek, jóváhagyások, pozitív visszajelzések.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Success50` | #E8F5E9 | Legvilágosabb |
| `Success100` | #C8E6C9 | Nagyon világos - **háttér** |
| `Success200` | #A5D6A7 | Világos |
| `Success300` | #81C784 | Közepes világos |
| `Success400` | #66BB6A | Világos-közepes |
| `Success500` | #4CAF50 | **Alap zöld** - normál |
| `Success600` | #43A047 | Közepes sötét |
| `Success700` | #388E3C | Sötét - **hover** |
| `Success800` | #2E7D32 | Nagyon sötét - **pressed** |
| `Success900` | #1B5E20 | Legsötétebb |

#### Legacy Nevek (Custom Értékek)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Success` | #2ECC71 | Normál (custom) |
| `SuccessDark` | #27AE60 | Hover (custom) |
| `SuccessDarker` | #229954 | Pressed (custom) |
| `SuccessLight` | `Success100` | Háttér |
| `SuccessAlt` | #5FA46A | Alternatív |

### Danger (Veszély - Piros) - Teljes Skála

Hibák, törlések, kritikus műveletek, figyelmeztetések.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Danger50` | #FFEBEE | Legvilágosabb |
| `Danger100` | #FFCCBC | Nagyon világos - **háttér** |
| `Danger200` | #EF9A9A | Világos |
| `Danger300` | #E57373 | Közepes világos |
| `Danger400` | #EF5350 | Világos-közepes |
| `Danger500` | #F44336 | **Alap piros** - normál |
| `Danger600` | #E53935 | Közepes sötét |
| `Danger700` | #D32F2F | Sötét - **hover** |
| `Danger800` | #C62828 | Nagyon sötét - **pressed** |
| `Danger900` | #B71C1C | Legsötétebb |

#### Legacy Nevek (Custom Értékek)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Danger` | #E74C3C | Normál (custom) |
| `DangerDark` | #C0392B | Hover (custom) |
| `DangerDarker` | #A93226 | Pressed (custom) |
| `DangerLight` | `Danger100` | Háttér |
| `DangerAlt` | `Danger500` | Alternatív |

### Warning (Figyelmeztetés - Narancs) - Teljes Skála

Fontos értesítések, figyelmeztetések, várakozó állapotok.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Warning50` | #FFF8E1 | Legvilágosabb |
| `Warning100` | #FFF9C4 | Nagyon világos - **háttér** |
| `Warning200` | #FFE082 | Világos |
| `Warning300` | #FFD54F | Közepes világos |
| `Warning400` | #FFCA28 | Világos-közepes |
| `Warning500` | #FFC107 | **Alap narancs** - normál |
| `Warning600` | #FFB300 | Közepes sötét |
| `Warning700` | #FFA000 | Sötét - **hover** |
| `Warning800` | #FF8F00 | Nagyon sötét - **pressed** |
| `Warning900` | #FF6F00 | Legsötétebb |

#### Legacy Nevek (Custom Értékek)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Warning` | #FF9800 | Normál (custom) |
| `WarningDark` | #F57C00 | Hover (custom) |
| `WarningDarker` | #E65100 | Pressed (custom) |
| `WarningLight` | `Warning100` | Háttér |
| `WarningAlt` | #F39C12 | Alternatív (custom) |

### Info (Információ - Világoskék) - Teljes Skála

Tájékoztató üzenetek, információs panelek.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Info50` | #E1F5FE | Legvilágosabb |
| `Info100` | #B3E5FC | Nagyon világos |
| `Info200` | #81D4FA | Világos |
| `Info300` | #4FC3F7 | Közepes világos |
| `Info400` | #29B6F6 | Világos-közepes |
| `Info500` | #03A9F4 | **Alap világoskék** - normál |
| `Info600` | #039BE5 | Közepes sötét - **hover** |
| `Info700` | #0288D1 | Sötét - **pressed** |
| `Info800` | #0277BD | Nagyon sötét |
| `Info900` | #01579B | Legsötétebb |

#### Legacy Nevek (Custom Értékek)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Info` | #3498DB | Normál (custom) |
| `InfoDark` | #2980B9 | Hover (custom) |
| `InfoLight` | #5DADE2 | Háttér (custom) |

### Secondary (Másodlagos - Lila) - Teljes Skála

Speciális funkciók, admin területek, kiegészítő gombok.

#### Tailwind-szerű Skála (50-900)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Secondary50` | #F3E5F5 | Legvilágosabb |
| `Secondary100` | #E1BEE7 | Nagyon világos |
| `Secondary200` | #CE93D8 | Világos |
| `Secondary300` | #BA68C8 | Közepes világos |
| `Secondary400` | #AB47BC | Világos-közepes |
| `Secondary500` | #9C27B0 | **Alap lila** - normál |
| `Secondary600` | #8E24AA | Közepes sötét |
| `Secondary700` | #7B1FA2 | Sötét - **hover** |
| `Secondary800` | #6A1B9A | Nagyon sötét - **pressed** |
| `Secondary900` | #4A148C | Legsötétebb |

#### Legacy Nevek (Custom Értékek)

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Secondary` | #9B59B6 | Normál (custom) |
| `SecondaryDark` | `Secondary700` | Hover |
| `SecondaryDarker` | `Secondary800` | Pressed |
| `SecondaryAlt` | #8E44AD | Alternatív (custom) |

### Gray Scale (Szürke Skála)

Háttér, szöveg, border, semleges elemek - 10 árnyalat.

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Gray100` | #F8F9FA | Oldal háttér |
| `Gray200` | #FAFAFA | Váltakozó sorok |
| `Gray300` | #F5F5F5 | Hover háttér |
| `Gray400` | #E0E0E0 | Border, elválasztó |
| `Gray500` | #BDBDBD | Vonal |
| `Gray600` | #95A5A6 | Disabled szöveg |
| `Gray700` | #7F8C8D | Másodlagos szöveg |
| `Gray800` | #2C3E50 | Normál szöveg |
| `Gray900` | #34495E | Fejléc, sötét elem |

### Accent Colors (Kiegészítő Színek)

Speciális használatra, adatvizualizációhoz, változatossághoz.

| Konstans | Hex | Használat |
|----------|-----|-----------|
| `Teal` | #1ABC9C | Speciális |
| `Cyan` | #00BCD4 | Adatvizualizáció |
| `Pink` | #E91E63 | Kiemelt |
| `Amber` | #FFC107 | Figyelmeztetés alt. |
| `Lime` | #CDDC39 | Pozitív változás |
| `Indigo` | #3F51B5 | Adminisztráció |

---

## Tailwind CSS-szerű Használat

### Skála Koncepció

Minden fő színkategória (Primary, Success, Danger, Warning, Info, Secondary) most **10 árnyalatban** (50-900) is elérhető:

- **50-300**: Világos árnyalatok - háttér, kijelölés, subtle elemek
- **400-500**: Közepes árnyalatok - **500 az alap szín**
- **600-900**: Sötét árnyalatok - hover, pressed, kiemelt elemek

### Használati Példák - Tailwind Skála

#### 1. Finomhangolt Hover Állapotok

```xaml
<!-- Normál: 500, Hover: 600, Pressed: 700 -->
<Button Background="{x:Static ui:Colors.Primary500Brush}" />
```

Code-behind hover:
```csharp
button.Background = Colors.Primary500Brush;
button.MouseEnter += (s, e) => button.Background = Colors.Primary600Brush;
button.PreviewMouseDown += (s, e) => button.Background = Colors.Primary700Brush;
button.MouseLeave += (s, e) => button.Background = Colors.Primary500Brush;
```

#### 2. Fokozatos Háttér (Gradient Effect)

```csharp
// Világostól sötétig
var gradient = new[]
{
    Colors.Primary50,
    Colors.Primary100,
    Colors.Primary200,
    Colors.Primary300,
    Colors.Primary400,
    Colors.Primary500,
    Colors.Primary600,
    Colors.Primary700,
    Colors.Primary800,
    Colors.Primary900
};
```

#### 3. Heatmap Színezés

```csharp
public Brush GetHeatmapColor(double value, double min, double max)
{
    var normalized = (value - min) / (max - min);
    
    return normalized switch
    {
        <= 0.1 => Colors.Primary50Brush,
        <= 0.2 => Colors.Primary100Brush,
        <= 0.3 => Colors.Primary200Brush,
        <= 0.4 => Colors.Primary300Brush,
        <= 0.5 => Colors.Primary400Brush,
        <= 0.6 => Colors.Primary500Brush,
        <= 0.7 => Colors.Primary600Brush,
        <= 0.8 => Colors.Primary700Brush,
        <= 0.9 => Colors.Primary800Brush,
        _ => Colors.Primary900Brush
    };
}
```

#### 4. ProgressBar Finomhangolt Színezés

```csharp
public Brush GetProgressColor(double percentage)
{
    return percentage switch
    {
        >= 90 => Colors.Success800Brush,
        >= 75 => Colors.Success600Brush,
        >= 60 => Colors.Success400Brush,
        >= 50 => Colors.Warning600Brush,
        >= 40 => Colors.Warning400Brush,
        >= 30 => Colors.Danger600Brush,
        >= 20 => Colors.Danger500Brush,
        _ => Colors.Danger800Brush
    };
}
```

#### 5. Nested Borders (Fokozatos Keretezés)

```xaml
<Border Background="{x:Static ui:Colors.Primary50Brush}"
        BorderBrush="{x:Static ui:Colors.Primary100Brush}"
        BorderThickness="5"
        Padding="10">
    <Border Background="{x:Static ui:Colors.Primary200Brush}"
            BorderBrush="{x:Static ui:Colors.Primary300Brush}"
            BorderThickness="5"
            Padding="10">
        <Border Background="{x:Static ui:Colors.Primary400Brush}"
                BorderBrush="{x:Static ui:Colors.Primary500Brush}"
                BorderThickness="5"
                Padding="20">
            <TextBlock Text="Nested Content" 
                       Foreground="{x:Static ui:Colors.TextOnDarkBrush}" />
        </Border>
    </Border>
</Border>
```

#### 6. Táblázat Sorok Színezése

```csharp
public Brush GetRowBackground(double value)
{
    return value switch
    {
        < 0 => Colors.Danger50Brush,
        >= 0 and < 25 => Colors.Warning50Brush,
        >= 25 and < 50 => Colors.Warning100Brush,
        >= 50 and < 75 => Colors.Success50Brush,
        >= 75 and < 90 => Colors.Success100Brush,
        >= 90 => Colors.Success200Brush,
        _ => Colors.Gray100Brush
    };
}
```

### Legacy vs. Tailwind Skála

| Használat | Legacy | Tailwind Skála |
|-----------|--------|----------------|
| **Alap szín** | `Colors.Primary` | `Colors.Primary500` |
| **Hover** | `Colors.PrimaryDark` | `Colors.Primary600` vagy `Primary700` |
| **Pressed** | `Colors.PrimaryDarker` | `Colors.Primary700` vagy `Primary800` |
| **Világos háttér** | `Colors.PrimaryLight` | `Colors.Primary50` vagy `Primary100` |
| **Még világosabb** | `Colors.PrimaryLighter` | `Colors.Primary50` |

### Mikor Melyiket Használd?

**Legacy Nevek (`Primary`, `PrimaryDark`, stb.):**
- ✅ Gyors fejlesztés
- ✅ Egyszerű állapotok (normál, hover, pressed)
- ✅ Backward compatibility
- ✅ Kevesebb komplexitás

**Tailwind Skála (`Primary50`-`Primary900`):**
- ✅ Finomhangolt kontroll
- ✅ Heatmap, gradient, data viz
- ✅ Fokozatos átmenetek
- ✅ Komplex UI elemek
- ✅ 10 árnyalat közül választhatsz

---

## Használati Példák

### 1. XAML-ben (StaticResource)

```xaml
<!-- Button háttér -->
<Button Background="{x:Static ui:Colors.PrimaryBrush}" 
        Foreground="{x:Static ui:Colors.TextOnDarkBrush}"
        Content="Mentés" />

<!-- Border szín -->
<Border BorderBrush="{x:Static ui:Colors.BorderBrush}" 
        BorderThickness="1"
        Background="{x:Static ui:Colors.SurfaceBrush}">
    <TextBlock Text="Tartalom" />
</Border>

<!-- TextBlock szöveg szín -->
<TextBlock Text="Cím" 
           Foreground="{x:Static ui:Colors.TextPrimaryBrush}" 
           FontSize="18" 
           FontWeight="SemiBold" />

<!-- DataGrid fejléc -->
<DataGrid>
    <DataGrid.Resources>
        <Style TargetType="DataGridColumnHeader">
            <Setter Property="Background" Value="{x:Static ui:Colors.Gray800Brush}" />
            <Setter Property="Foreground" Value="{x:Static ui:Colors.TextOnDarkBrush}" />
        </Style>
    </DataGrid.Resources>
</DataGrid>
```

### 2. Code-behind (C#)

```csharp
using DuckDBDemo.UI;

// Button színezése
myButton.Background = Colors.SuccessBrush;
myButton.Foreground = Colors.TextOnDarkBrush;

// Border színezése
myBorder.BorderBrush = Colors.DangerBrush;
myBorder.Background = Colors.DangerLightBrush;

// TextBlock színezése
myTextBlock.Foreground = Colors.TextPrimaryBrush;
```

### 3. Helper Metódusok Használata

```csharp
// Opacity-vel
var transparentBlue = Colors.WithOpacity(Colors.Primary, 0.5);
myElement.Background = transparentBlue;

// Alpha csatornával
var semiTransparentRed = Colors.WithAlpha(Colors.Danger, 128); // 50%
overlay.Background = semiTransparentRed;

// Hex string-ből
var customColor = Colors.FromHex("#FF5733");
var customBrush = Colors.BrushFromHex("#FF5733");
myButton.Background = customBrush;
```

### 4. Dinamikus Színezés

```csharp
// Állapot szerint
public SolidColorBrush GetStatusBrush(string status)
{
    return status switch
    {
        "Success" => Colors.SuccessBrush,
        "Error" => Colors.DangerBrush,
        "Warning" => Colors.WarningBrush,
        "Info" => Colors.InfoBrush,
        _ => Colors.Gray600Brush
    };
}

// Használat
statusIndicator.Fill = GetStatusBrush(currentStatus);
```

### 5. Grafikon Színek

```csharp
// LiveCharts2 példa
var series = new LineSeries<double>
{
    Values = data,
    Stroke = Colors.Chart1Brush, // Kék
    Fill = Colors.WithOpacity(Colors.Chart1, 0.2)
};

// Több sorozat különböző színekkel
var chartColors = new[]
{
    Colors.Chart1Brush, // Kék
    Colors.Chart2Brush, // Zöld
    Colors.Chart3Brush, // Narancs
    Colors.Chart4Brush, // Piros
    Colors.Chart5Brush  // Lila
};
```

---

## Migrációs Útmutató

### Régi Kód Frissítése

**Előtte:**
```xaml
<Button Background="#2196F3" Foreground="White" />
```

**Utána:**
```xaml
<Button Background="{x:Static ui:Colors.PrimaryBrush}" 
        Foreground="{x:Static ui:Colors.TextOnDarkBrush}" />
```

**Előtte (C#):**
```csharp
myButton.Background = new SolidColorBrush(Color.FromRgb(0x21, 0x96, 0xF3));
```

**Utána (C#):**
```csharp
myButton.Background = Colors.PrimaryBrush;
```

---

## Komponensek Frissítése

### Button.xaml

```xaml
<Setter Property="Background" Value="{x:Static ui:Colors.PrimaryBrush}" />
<Setter Property="Foreground" Value="{x:Static ui:Colors.TextOnDarkBrush}" />
<Setter Property="ui:ButtonAssist.HoverBackground" Value="{x:Static ui:Colors.PrimaryDarkBrush}" />
<Setter Property="ui:ButtonAssist.PressedBackground" Value="{x:Static ui:Colors.PrimaryDarkerBrush}" />
```

### DataGrid.xaml

```xaml
<Setter Property="Background" Value="{x:Static ui:Colors.SurfaceBrush}" />
<Setter Property="BorderBrush" Value="{x:Static ui:Colors.BorderBrush}" />
<Setter Property="AlternatingRowBackground" Value="{x:Static ui:Colors.AlternateRowBrush}" />

<!-- Fejléc -->
<Setter Property="Background" Value="{x:Static ui:Colors.Gray800Brush}" />
<Setter Property="Foreground" Value="{x:Static ui:Colors.TextOnDarkBrush}" />

<!-- Kijelölés -->
<Setter Property="Background" Value="{x:Static ui:Colors.SelectionBrush}" />
```

### TileMenuItemControl.xaml

```xaml
<!-- Példa használat -->
<ui:TileMenuItemControl
    HeaderBackground="{x:Static ui:Colors.SuccessBrush}"
    TitleColor="{x:Static ui:Colors.TextPrimaryBrush}"
    DescriptionColor="{x:Static ui:Colors.TextSecondaryBrush}"
    ... />
```

---

## Best Practices

### ✅ Jó Gyakorlatok

1. **Használj konstansokat** hardcoded hex értékek helyett
2. **Brush változat** XAML-ben (`Colors.PrimaryBrush`)
3. **Color változat** dinamikus számításokhoz (`Colors.Primary`)
4. **Kategória követése**: Success = zöld, Danger = piros
5. **Árnyalatok használata**: Dark/Darker hover/pressed-hez
6. **Szürke skála**: Gray100-900 következetes használata
7. **Helper metódusok**: WithOpacity átlátszósághoz

### ❌ Kerülendő

1. ❌ Hardcoded hex értékek (#2196F3)
2. ❌ Inline new SolidColorBrush() létrehozás
3. ❌ Saját színek a palettán kívül
4. ❌ Nem megfelelő kategória (piros gombon Success)
5. ❌ Alacsony kontrasztú kombinációk

---

## Kontrasztus Ellenőrzés

### Jó Kombinációk

```csharp
// Sötét háttér + világos szöveg ✅
Background = Colors.Gray800Brush;
Foreground = Colors.TextOnDarkBrush;

// Világos háttér + sötét szöveg ✅
Background = Colors.SurfaceBrush;
Foreground = Colors.TextPrimaryBrush;

// Színes gomb + fehér szöveg ✅
Background = Colors.PrimaryBrush;
Foreground = Colors.TextOnDarkBrush;
```

### Rossz Kombinációk

```csharp
// Alacsony kontraszt ❌
Background = Colors.Gray300Brush;
Foreground = Colors.Gray400Brush;

// Színes háttér + színes szöveg ❌
Background = Colors.PrimaryBrush;
Foreground = Colors.SuccessBrush;
```

---

## Színséma Változatok

### Világos Téma (Alapértelmezett)

```csharp
Background = Colors.BackgroundBrush;      // #F8F9FA
Surface = Colors.SurfaceBrush;            // #FFFFFF
TextPrimary = Colors.TextPrimaryBrush;    // #2C3E50
```

### Sötét Téma (Jövőbeli Kiterjesztés)

*Megjegyzés: Jelenleg a Colors osztály világos témát támogat. Sötét téma implementálásához új konstansok hozzáadása szükséges.*

```csharp
// Példa sötét téma konstansok (jövőbeli)
public static readonly Color DarkBackground = Color.FromRgb(0x12, 0x12, 0x12);
public static readonly Color DarkSurface = Color.FromRgb(0x1E, 0x1E, 0x1E);
public static readonly Color DarkTextPrimary = Color.FromRgb(0xE0, 0xE0, 0xE0);
```

---

## Teljesítmény Megjegyzések

### Freeze() Használata

A Colors osztályban minden Brush automatikusan **Freeze()**-elve van, ami teljesítmény optimalizálást eredményez:

```csharp
public static readonly SolidColorBrush PrimaryBrush = new(Primary);
// Automatikusan freeze-elve a static konstruktorban
```

### Újrafelhasználás

```csharp
// ✅ Jó - konstans újrafelhasználás
button1.Background = Colors.PrimaryBrush;
button2.Background = Colors.PrimaryBrush;

// ❌ Rossz - minden alkalommal új példány
button1.Background = new SolidColorBrush(Color.FromRgb(0x21, 0x96, 0xF3));
button2.Background = new SolidColorBrush(Color.FromRgb(0x21, 0x96, 0xF3));
```

---

## Bővítés

Ha új színeket szeretnél hozzáadni:

```csharp
// UI/Colors.cs
public static class Colors
{
    // ... meglévő színek ...
    
    // Új kategória
    #region Custom Colors
    
    /// <summary>Egyedi márka szín</summary>
    public static readonly Color BrandColor = Color.FromRgb(0x12, 0x34, 0x56);
    public static readonly SolidColorBrush BrandColorBrush = new(BrandColor);
    
    #endregion
}
```

---

## Összefoglalás

A `Colors` osztály egy **központosított színpaletta rendszer**, amely:

✅ **Bootstrap-szerű kategorizálást** használ (Primary, Success, Danger, stb.)  
✅ **Material Design színeket** tartalmaz  
✅ **Color és Brush változatokat** egyaránt biztosít  
✅ **Árnyalatokat** (Dark, Darker, Light) tartalmaz  
✅ **Szürke skálát** (Gray100-900) definiál  
✅ **Helper metódusokat** nyújt (WithOpacity, FromHex)  
✅ **Teljesítmény optimalizált** (Freeze()-elt brushok)  

Használata **egységes színsémát** és **könnyű karbantarthatóságot** biztosít az alkalmazásban.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Licence**: Belső felhasználásra

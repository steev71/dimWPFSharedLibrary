# AuditCardControl Dokumentáció

## Áttekintés

Az `AuditCardControl` egy kompakt, statisztikai adatok megjelenítésére optimalizált kártya komponens WPF alkalmazásokhoz. Ideális dashboard-okhoz, KPI mutatókhoz és összefoglaló információk vizualizálásához.

### Főbb Jellemzők

- ✅ **Háromrétegű struktúra**: Fejléc, tartalom, lábléc
- ✅ **Ikonos fejléc**: Image vagy SVG path ikon támogatás
- ✅ **Nagy számok megjelenítése**: 28px félkövér szöveg
- ✅ **Hover effekt**: Árnyék és border változás
- ✅ **Pressed effekt**: Kártya kicsinyítés (scale)
- ✅ **Opcionális nyíl**: Navigációs jelző
- ✅ **Command és Click támogatás**: MVVM és code-behind

---

## Fájlok

- **XAML**: `UI/AuditCardControl.xaml`
- **Code-behind**: `UI/AuditCardControl.xaml.cs`
- **Namespace**: `DuckDBDemo.UI`

---

## Dependency Properties

### Interaktivitás

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `Command` | `ICommand` | `null` | MVVM parancs végrehajtása kattintáskor |
| `CommandParameter` | `object` | `null` | Command paraméter |
| `IsClickable` | `bool` | `true` | Kártya kattintható-e |
| `ShowArrow` | `bool` | `false` | Navigációs nyíl megjelenítése (auto) |
| `Click` | `RoutedEvent` | - | Routed event kattintás kezelésére |

### Fejléc (Title Bar)

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `TitleText` | `string` | `""` | Fejléc szöveg |
| `TitleBackground` | `Brush` | `SteelBlue` | Fejléc háttérszín |
| `TitleColor` | `Brush` | `White` | Fejléc szöveg szín |
| `TitleIcon` | `ImageSource` | `null` | Fejléc ikon (kép) |
| `TitleIconPathData` | `string` | `""` | Fejléc ikon (SVG path) |
| `TitleIconForeground` | `Brush` | `White` | Path ikon színe |
| `TitleIconSize` | `double` | `22` | Ikon mérete (px) |

### Tartalom (Main Content)

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `ContentText` | `string` | `""` | Fő tartalom (nagy szám/szöveg) |
| `ContentColor` | `Brush` | `Black` | Tartalom szöveg színe |
| `Background` | `Brush` | `White` | Kártya háttérszín |

### Lábléc (Footer)

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `FooterText` | `string` | `""` | Lábléc szöveg (kiegészítő info) |
| `FooterColor` | `Brush` | `Gray` | Lábléc szöveg színe |

### Belső Állapotok (read-only)

| Property | Típus | Leírás |
|----------|-------|--------|
| `IsTitleIconVisible` | `bool` | Bármilyen ikon látható-e a fejlécben |
| `IsTitleImageIconVisible` | `bool` | Image ikon látható-e |
| `IsTitlePathIconVisible` | `bool` | Path ikon látható-e |

---

## Vizuális Működés

### Alapállapot

- **Border**: `#E0E0E0`, 1px vastag
- **CornerRadius**: 10px
- **DropShadow**: BlurRadius=10, Opacity=0.15, Depth=2
- **Méret**: ~140px magasság (auto), ~320px szélesség (rugalmas)

### Hover Effekt

Amikor az egér a kártya fölé kerül:
- **Kéz kurzor** jelenik meg
- **Border színe**: `#C7D2E2` (világoskék)
- **Árnyék erősödik**: BlurRadius=14, Opacity=0.22, Depth=3

### Pressed Effekt

Amikor a kártyára kattintanak:
- **Border színe**: `#9FB4D6` (sötétebb kék)
- **Scale transzformáció**: 0.995x (enyhe összenyomás)

### Disabled Állapot

Amikor `IsClickable="False"`:
- **Normál kurzor** (nem kéz)
- **Opacity**: 0.95 (kissé átlátszó)
- **Nem kattintható**

---

## Struktúra

```
UserControl (AuditCardControl)
└── Button (RootButton, transparent)
    └── ControlTemplate
        └── Border (Card) ← Hover/Press effekt célpontja
            └── Grid (3 sor)
                ├── Border (Title Bar, 44px) ← Színes fejléc
                │   └── Grid
                │       ├── Image/Path (Ikon)
                │       └── TextBlock (TitleText)
                ├── Grid (Main Content, *) ← Nagy számok
                │   └── TextBlock (ContentText, 28px)
                └── Grid (Footer, 36px) ← Kiegészítő info
                    ├── TextBlock (FooterText, 12px)
                    └── Border (Nyíl, 26px kör)
```

---

## Használati Példák

### 1. Alapvető Statisztika Kártya

```xaml
<ui:AuditCardControl
    Width="280"
    TitleText="Összes tétel"
    TitleBackground="#3498DB"
    ContentText="12,450"
    FooterText="Utolsó frissítés: ma"
    Click="OnCardClick" />
```

Code-behind:
```csharp
private void OnCardClick(object sender, RoutedEventArgs e)
{
    // Részletek megjelenítése
    ShowDetails();
}
```

### 2. Ikonos Kártya (Image)

```xaml
<ui:AuditCardControl
    Width="280"
    TitleText="Bevétel"
    TitleIcon="Assets/money-icon.png"
    TitleIconSize="20"
    TitleBackground="#2ECC71"
    ContentText="1,234,567 Ft"
    ContentColor="#27AE60"
    FooterText="↗️ +12% az előző hónaphoz képest" />
```

### 3. SVG Path Ikonnal

```xaml
<ui:AuditCardControl
    Width="280"
    TitleText="Bizonylatok"
    TitleIconPathData="M240-80q-33 0-56.5-23.5T160-160v-640q0-33 23.5-56.5T240-880h480q33 0 56.5 23.5T800-800v640q0 33-23.5 56.5T720-80H240Z"
    TitleIconForeground="White"
    TitleIconSize="22"
    TitleBackground="#9B59B6"
    ContentText="8,921"
    FooterText="Ebből feldolgozva: 8,920"
    Click="ShowDocuments" />
```

### 4. MVVM Command Binding

```xaml
<ui:AuditCardControl
    Width="280"
    TitleText="Hibák"
    TitleBackground="#E74C3C"
    ContentText="{Binding ErrorCount}"
    ContentColor="#C0392B"
    FooterText="Azonnali figyelmet igényel"
    Command="{Binding ShowErrorsCommand}" />
```

ViewModel:
```csharp
public class DashboardViewModel
{
    public int ErrorCount { get; set; } = 42;
    
    public ICommand ShowErrorsCommand { get; }
    
    public DashboardViewModel()
    {
        ShowErrorsCommand = new RelayCommand(ExecuteShowErrors);
    }
    
    private void ExecuteShowErrors(object parameter)
    {
        // Hibák megjelenítése
    }
}
```

### 5. Nem Kattintható Információs Kártya

```xaml
<ui:AuditCardControl
    Width="280"
    TitleText="Utolsó szinkronizálás"
    TitleBackground="#95A5A6"
    ContentText="2024-01-15"
    ContentColor="#7F8C8D"
    FooterText="14:35:22"
    IsClickable="False" />
```

A nyíl automatikusan eltűnik, mert `IsClickable="False"`.

---

## Layout Ajánlások

### UniformGrid Layout (Dashboard)

```xaml
<UniformGrid Columns="3" Rows="2">
    <ui:AuditCardControl ... />
    <ui:AuditCardControl ... />
    <ui:AuditCardControl ... />
    <ui:AuditCardControl ... />
    <ui:AuditCardControl ... />
    <ui:AuditCardControl ... />
</UniformGrid>
```

### WrapPanel Layout (Rugalmas)

```xaml
<WrapPanel Orientation="Horizontal">
    <ui:AuditCardControl Width="280" Margin="10" ... />
    <ui:AuditCardControl Width="280" Margin="10" ... />
    <ui:AuditCardControl Width="280" Margin="10" ... />
</WrapPanel>
```

### Grid Layout (Egyedi Elrendezés)

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="10" />
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="10" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>
    
    <ui:AuditCardControl Grid.Column="0" ... />
    <ui:AuditCardControl Grid.Column="2" ... />
    <ui:AuditCardControl Grid.Column="4" ... />
</Grid>
```

---

## Méret Ajánlások

| Méret | Használat | Leírás |
|-------|-----------|--------|
| **280-320px** | Standard | Általános dashboard kártyák |
| **240-260px** | Kompakt | Több kártya kisebb helyen |
| **340-400px** | Nagy | Kiemelt metrikák, részletes info |

**Magasság**: Alapértelmezett ~140px, de rugalmas (auto)

---

## Színpaletta Javaslatok

### Kategória Szerinti Színek

```csharp
// Pozitív / Siker
TitleBackground="#2ECC71" // Zöld
ContentColor="#27AE60"    // Sötétzöld

// Semleges / Info
TitleBackground="#3498DB" // Kék
ContentColor="#2C3E50"    // Sötétszürke

// Figyelmeztetés
TitleBackground="#F39C12" // Narancssárga
ContentColor="#E67E22"    // Sötét narancs

// Hiba / Veszély
TitleBackground="#E74C3C" // Piros
ContentColor="#C0392B"    // Sötétpiros

// Semleges / Inaktív
TitleBackground="#95A5A6" // Világosszürke
ContentColor="#7F8C8D"    // Szürke
```

---

## Belső Működés

### UpdateShowArrow()

Automatikusan kezeli a nyíl megjelenítését:

```csharp
private void UpdateShowArrow()
{
    ShowArrow = IsClickable && (Command is not null || _clickHandlerCount > 0);
}
```

**Logika**:
- Ha `IsClickable = false` → nyíl mindig rejtve
- Ha `IsClickable = true` ÉS (van Command VAGY van Click handler) → nyíl látható

### OnTitleIconChanged()

Kezeli az ikon típusok prioritását (Image > Path):

```csharp
private static void OnTitleIconChanged(...)
{
    var hasImage = control.TitleIcon is not null;
    var hasPath = !string.IsNullOrWhiteSpace(control.TitleIconPathData);

    control.IsTitleImageIconVisible = hasImage;
    control.IsTitlePathIconVisible = !hasImage && hasPath;
    control.IsTitleIconVisible = hasImage || hasPath;
}
```

---

## Best Practices

### ✅ Jó Gyakorlatok

1. **Rövid címek** - Max 2-3 szó a TitleText-ben
2. **Nagy számok** - ContentText ideális számokhoz (FormattedText)
3. **Kiegészítő kontextus** - FooterText használata változásokhoz (↗️ +12%)
4. **Konzisztens méretek** - Egyforma szélesség dashboard-on
5. **Színkódolás** - Kategóriák szerint (zöld=jó, piros=rossz)
6. **Ikonok használata** - Vizuális azonosítás gyorsítása
7. **Formázott számok** - `{Binding Value, StringFormat=N0}` vagy `{Binding Value, StringFormat=C}`

### ❌ Kerülendő

1. ❌ Hosszú TitleText (több sor)
2. ❌ Túl sok szöveg a ContentText-ben (ideális: 1-8 karakter)
3. ❌ Több soros FooterText
4. ❌ Túl apró (< 200px) kártyák
5. ❌ Vegyítés: Click és Command egyszerre

---

## Formázási Példák

### Számok Formázása

```xaml
<!-- Ezres elválasztó -->
<ui:AuditCardControl
    ContentText="{Binding Count, StringFormat=N0}" />
<!-- 12,450 -->

<!-- Pénznem -->
<ui:AuditCardControl
    ContentText="{Binding Amount, StringFormat=C0}" />
<!-- 1 234 567 Ft -->

<!-- Százalék -->
<ui:AuditCardControl
    ContentText="{Binding Percentage, StringFormat=P1}" />
<!-- 12.5% -->

<!-- Egyedi formázás -->
<ui:AuditCardControl
    ContentText="{Binding Value, StringFormat={}{0:N2} kg}" />
<!-- 123.45 kg -->
```

### Emoji Használata

```xaml
<ui:AuditCardControl
    TitleText="📊 Statisztika"
    ContentText="42"
    FooterText="↗️ +15% növekedés" />

<ui:AuditCardControl
    TitleText="⚠️ Figyelmeztetések"
    ContentText="5"
    FooterText="🔍 Ellenőrzés szükséges"
    TitleBackground="#F39C12" />
```

---

## Hibaelhárítás

### A nyíl nem jelenik meg

**Probléma**: ShowArrow mindig false.

**Megoldás**:
1. Ellenőrizd az `IsClickable` értékét (alapértelmezett: true)
2. Adj meg `Click` event handler-t vagy `Command`-ot
3. Ha egyik sincs, a nyíl nem jelenik meg (szándékos)

### Ikon nem látszik

**Probléma**: Sem Image, sem Path ikon nem jelenik meg.

**Megoldás**:
1. **Image esetén**: Ellenőrizd a fájl elérési útját és Build Action-t (Content, Copy if newer)
2. **Path esetén**: Ellenőrizd a `TitleIconPathData` értékét (nem üres string)
3. Az Image prioritást élvez a Path-tal szemben

### Hover effekt nem működik

**Probléma**: Border nem változik hover-nél.

**Megoldás**:
- Ellenőrizd, hogy az `IsClickable` értéke `true`
- A disabled állapotban (IsClickable=false) a hover effekt kikapcsol

### Kártya összenyomódik pressed-nél

**Probléma**: Ez a várt működés, de túl erős.

**Megoldás**:
- A `ScaleTransform` értéke 0.995 (0.5% kicsinyítés)
- Ha nem tetszik, módosítsd az XAML-ben: `ScaleX="0.998" ScaleY="0.998"`

---

## Összefoglalás

Az `AuditCardControl` egy kompakt, statisztikai adatok megjelenítésére tervezett komponens, amely:

✅ Háromrétegű struktúrával (fejléc, tartalom, lábléc)  
✅ Ikonos fejléccel (Image vagy SVG path)  
✅ Nagy számok/metrikák megjelenítésével  
✅ Interaktív hover és pressed effektekkel  
✅ MVVM és code-behind támogatással  

Ideális **dashboard-okhoz**, **KPI kártyákhoz** és **összefoglaló nézetek**hez.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Licence**: Belső felhasználásra

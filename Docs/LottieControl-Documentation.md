# LottieControl Dokumentáció

## Áttekintés

A `LottieControl` egy WPF UserControl, amely **Lottie JSON animációkat** jelenít meg a SkiaSharp rendering engine-t használva. Lehetővé teszi vektoros, skálázható animációk beágyazását WPF alkalmazásokba.

### Főbb Jellemzők

- ✅ **Lottie JSON támogatás**: Adobe After Effects exportált animációk
- ✅ **SkiaSharp rendering**: Hardveres gyorsítású megjelenítés
- ✅ **Lejátszás vezérlés**: Play/Pause/Stop
- ✅ **Ismétlés vezérlés**: Egyszeri, véges vagy végtelen ciklus
- ✅ **Skálázható**: Vektoros animáció, bármilyen méret
- ✅ **Teljesítmény optimalizált**: 60 FPS lejátszás

---

## Fájlok

- **Code-behind**: `UI/LottieControl.cs`
- **XAML**: Nincs (pure code control)
- **Namespace**: `DuckDBDemo.UI`

---

## Dependency Properties

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `Source` | `string` | `""` | Lottie JSON fájl elérési útja |
| `IsPlaying` | `bool` | `false` | Animáció lejátszása (play/pause) |
| `RepeatCount` | `int` | `0` | Ismétlések száma (-1 = végtelen, 0 = egyszeri) |

---

## Technikai Részletek

### Renderelési Stack

```
LottieControl (UserControl)
└── SKElement (SkiaSharp.Views.WPF)
    └── SKCanvas (SkiaSharp rendering surface)
        └── Skottie Animation (Lottie player)
```

### NuGet Csomagok

A következő csomagok szükségesek:

```xml
<PackageReference Include="SkiaSharp" Version="2.88.x" />
<PackageReference Include="SkiaSharp.Skottie" Version="2.88.x" />
<PackageReference Include="SkiaSharp.Views.WPF" Version="2.88.x" />
```

### Rendering Loop

- **Frame Rate**: 60 FPS (CompositionTarget.Rendering)
- **Animáció előrehaladás**: Duration-alapú időzítés
- **Invalidation**: Automatikus újrarajzolás minden frame-nél

---

## Használati Példák

### 1. Alapvető Animáció

```xaml
<ui:LottieControl
    Width="100"
    Height="100"
    Source="Assets/loading-spinner.json"
    IsPlaying="True"
    RepeatCount="-1" />
```

Végtelen ciklusban játszódik le (loading indicator-hoz ideális).

### 2. Egyszeri Lejátszás

```xaml
<ui:LottieControl
    x:Name="successAnimation"
    Width="80"
    Height="80"
    Source="Assets/success-checkmark.json"
    IsPlaying="False"
    RepeatCount="1" />
```

Code-behind:
```csharp
// Animáció indítása programozottan
successAnimation.IsPlaying = true;

// Esemény figyelése (egyedi implementáció szükséges)
// successAnimation.AnimationCompleted += OnAnimationCompleted;
```

### 3. Programozott Vezérlés

```csharp
// Play
lottieControl.IsPlaying = true;

// Pause
lottieControl.IsPlaying = false;

// Restart
lottieControl.IsPlaying = false;
await Task.Delay(50); // Rövid késleltetés
lottieControl.IsPlaying = true;

// Végtelen ismétlés beállítása
lottieControl.RepeatCount = -1;
lottieControl.IsPlaying = true;

// 3x ismétlés
lottieControl.RepeatCount = 3;
lottieControl.IsPlaying = true;
```

### 4. Dinamikus Animáció Csere

```xaml
<ui:LottieControl
    x:Name="dynamicLottie"
    Width="120"
    Height="120"
    IsPlaying="True"
    RepeatCount="-1" />
```

Code-behind:
```csharp
// Animáció váltás
private void SwitchAnimation(string animationPath)
{
    dynamicLottie.IsPlaying = false;
    dynamicLottie.Source = animationPath;
    dynamicLottie.IsPlaying = true;
}

// Példa váltás
SwitchAnimation("Assets/animation-1.json");
// később...
SwitchAnimation("Assets/animation-2.json");
```

### 5. Feltételes Lejátszás (Binding)

```xaml
<ui:LottieControl
    Width="60"
    Height="60"
    Source="Assets/loading.json"
    IsPlaying="{Binding IsLoading}"
    RepeatCount="-1" />
```

ViewModel:
```csharp
public class MyViewModel : INotifyPropertyChanged
{
    private bool _isLoading;
    
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }
    
    public async Task LoadDataAsync()
    {
        IsLoading = true; // Animáció elindul
        try
        {
            await FetchDataAsync();
        }
        finally
        {
            IsLoading = false; // Animáció megáll
        }
    }
}
```

---

## Lottie JSON Források

### Ingyenes Animáció Könyvtárak

1. **LottieFiles** - https://lottiefiles.com/
   - Legnagyobb Lottie animáció gyűjtemény
   - Ingyenes és prémium animációk
   - Előnézet, letöltés JSON formátumban

2. **Lordicon** - https://lordicon.com/
   - Prémium minőségű ikonok és animációk
   - Lottie export támogatás

3. **Icons8 Animated Icons** - https://icons8.com/animated-icons
   - Egyszerű, tiszta animált ikonok
   - Lottie JSON export

### Adobe After Effects Export

Ha saját animációkat készítesz:

1. Adobe After Effects-ben dolgozz
2. Telepítsd a **Bodymovin** plugint
3. Exportáld Lottie JSON formátumban
4. Helyezd az `Assets` mappába

---

## Fájl Kezelés

### Lottie JSON Fájlok Elhelyezése

```
ProjectRoot/
├── Assets/
│   ├── loading.json
│   ├── success.json
│   ├── error.json
│   └── duck-animation.json
└── UI/
    └── LottieControl.cs
```

### Build Action Beállítások

Visual Studio-ban:
1. Jobb klikk a JSON fájlon
2. Properties
3. **Build Action**: `Content`
4. **Copy to Output Directory**: `Copy if newer`

Vagy `.csproj` fájlban:
```xml
<ItemGroup>
  <Content Include="Assets\*.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```

---

## Teljesítmény Optimalizálás

### Best Practices

#### ✅ Jó Gyakorlatok

1. **Előre betöltés**: Töltsd be az animációkat alkalmazás indulásakor
2. **Méret optimalizálás**: Komplex animációknál kisebb felbontás
3. **Cache-elés**: Ugyanazt az animációt többször felhasználni
4. **Pause when hidden**: Állítsd le az animációt, ha nem látható
5. **RepeatCount**: Ha nem végtelen, használj konkrét számot

```csharp
// Pause amikor ablak háttérben
this.Deactivated += (s, e) => lottieControl.IsPlaying = false;
this.Activated += (s, e) => lottieControl.IsPlaying = true;

// Pause amikor control rejtett
lottieControl.IsVisibleChanged += (s, e) =>
{
    if (lottieControl.IsVisible)
        lottieControl.IsPlaying = true;
    else
        lottieControl.IsPlaying = false;
};
```

#### ❌ Kerülendő

1. ❌ Túl nagy fájlok (> 500KB) egyszerű ikonokhoz
2. ❌ Túl sok egyidejű animáció (max 5-10 egyszerre)
3. ❌ Felesleges végtelen ismétlés (ha egyszeri elég)
4. ❌ Animáció lejátszása háttérben (nem látható területen)

---

## Animáció Típusok és Használat

### Loading Indicators

```xaml
<!-- Spinner -->
<ui:LottieControl
    Width="50"
    Height="50"
    Source="Assets/spinner.json"
    IsPlaying="{Binding IsLoading}"
    RepeatCount="-1" />

<!-- Dots pulsing -->
<ui:LottieControl
    Width="60"
    Height="20"
    Source="Assets/dots-loading.json"
    IsPlaying="True"
    RepeatCount="-1" />
```

### Success/Error Feedback

```xaml
<!-- Success checkmark (egyszeri) -->
<ui:LottieControl
    x:Name="successCheck"
    Width="80"
    Height="80"
    Source="Assets/success.json"
    IsPlaying="False"
    RepeatCount="1" />

<!-- Error cross (egyszeri) -->
<ui:LottieControl
    x:Name="errorCross"
    Width="80"
    Height="80"
    Source="Assets/error.json"
    IsPlaying="False"
    RepeatCount="1" />
```

### Dekoratív Animációk

```xaml
<!-- Mascot animáció (végtelen) -->
<ui:LottieControl
    Width="100"
    Height="100"
    Source="Assets/duck-mascot.json"
    IsPlaying="True"
    RepeatCount="-1" />

<!-- Háttér részecskék -->
<ui:LottieControl
    Width="200"
    Height="200"
    Source="Assets/particles.json"
    IsPlaying="True"
    RepeatCount="-1"
    Opacity="0.3" />
```

### Interaktív Ikonok

```xaml
<!-- Hover animáció -->
<Button>
    <Button.Template>
        <ControlTemplate>
            <ui:LottieControl
                x:Name="hoverIcon"
                Width="40"
                Height="40"
                Source="Assets/button-icon.json"
                RepeatCount="1" />
            <ControlTemplate.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter TargetName="hoverIcon" Property="IsPlaying" Value="True" />
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    </Button.Template>
</Button>
```

---

## Hibakezelés

### Gyakori Hibák

#### 1. Animáció nem töltődik be

**Probléma**: JSON fájl nem található.

**Megoldás**:
```csharp
// Ellenőrzés
if (File.Exists(jsonPath))
{
    lottieControl.Source = jsonPath;
}
else
{
    MessageBox.Show($"Lottie fájl nem található: {jsonPath}");
}
```

#### 2. Animáció nem játszódik le

**Probléma**: `IsPlaying` false maradt.

**Megoldás**:
```csharp
// Explicit beállítás
lottieControl.Source = "Assets/animation.json";
lottieControl.IsPlaying = true; // Ne felejtsd el!
```

#### 3. Animáció "ugrál" vagy szakadozik

**Probléma**: Túl komplex animáció vagy alacsony teljesítmény.

**Megoldás**:
- Egyszerűsítsd az animációt After Effects-ben
- Csökkentsd a control méretét
- Csökkentsd az egyidejű animációk számát

#### 4. Memória probléma sok animációval

**Megoldás**:
```csharp
// Dispose amikor már nem kell
lottieControl.IsPlaying = false;
lottieControl.Source = null;

// Vagy rejtsd el
lottieControl.Visibility = Visibility.Collapsed;
```

---

## Layout Példák

### Grid Layout

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="*" />
    </Grid.RowDefinitions>
    
    <!-- Header animáció -->
    <ui:LottieControl
        Grid.Row="0"
        Width="120"
        Height="120"
        HorizontalAlignment="Center"
        Source="Assets/logo-animation.json"
        IsPlaying="True"
        RepeatCount="-1" />
    
    <!-- Tartalom -->
    <ContentControl Grid.Row="1" ... />
</Grid>
```

### StackPanel (Mellékelt Ikon)

```xaml
<StackPanel Orientation="Horizontal">
    <ui:LottieControl
        Width="24"
        Height="24"
        Margin="0,0,8,0"
        VerticalAlignment="Center"
        Source="Assets/icon.json"
        IsPlaying="True"
        RepeatCount="-1" />
    <TextBlock
        VerticalAlignment="Center"
        Text="Betöltés folyamatban..." />
</StackPanel>
```

### Overlay (Teljes Képernyős Loading)

```xaml
<Grid>
    <!-- Fő tartalom -->
    <ContentControl Content="{Binding MainContent}" />
    
    <!-- Loading overlay -->
    <Grid Background="#80FFFFFF" 
          Visibility="{Binding IsLoading, Converter={StaticResource BoolToVis}}">
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
            <ui:LottieControl
                Width="100"
                Height="100"
                Source="Assets/loading.json"
                IsPlaying="True"
                RepeatCount="-1" />
            <TextBlock
                Margin="0,20,0,0"
                FontSize="16"
                Text="Kérem várjon..."
                TextAlignment="Center" />
        </StackPanel>
    </Grid>
</Grid>
```

---

## Méret és Felbontás

### Ajánlott Méretek

| Használat | Méret | Leírás |
|-----------|-------|--------|
| **Kis ikon** | 16-24px | Inline ikonok, gombok |
| **Normál ikon** | 32-48px | Menüelemek, lista ikonok |
| **Nagy ikon** | 64-96px | Kiemelt funkciók |
| **Illustration** | 120-200px | Dekoratív elemek |
| **Hero** | 300-500px | Landing oldal, splash screen |

### Aspect Ratio

```xaml
<!-- Négyzet (1:1) -->
<ui:LottieControl Width="80" Height="80" />

<!-- Széles (16:9) -->
<ui:LottieControl Width="160" Height="90" />

<!-- Magas (9:16) -->
<ui:LottieControl Width="90" Height="160" />
```

---

## Styling és Testreszabás

### Opacity Effekt

```xaml
<ui:LottieControl
    Opacity="0.5"
    Source="Assets/background.json"
    IsPlaying="True"
    RepeatCount="-1" />
```

### RenderTransform (Forgatás)

```xaml
<ui:LottieControl
    Width="60"
    Height="60"
    Source="Assets/icon.json">
    <ui:LottieControl.RenderTransform>
        <RotateTransform Angle="45" CenterX="30" CenterY="30" />
    </ui:LottieControl.RenderTransform>
</ui:LottieControl>
```

### Effect (DropShadow)

```xaml
<ui:LottieControl
    Width="80"
    Height="80"
    Source="Assets/logo.json">
    <ui:LottieControl.Effect>
        <DropShadowEffect
            BlurRadius="10"
            ShadowDepth="3"
            Opacity="0.5" />
    </ui:LottieControl.Effect>
</ui:LottieControl>
```

---

## Összefoglalás

A `LottieControl` egy hatékony, skálázható animáció komponens, amely:

✅ **Lottie JSON animációkat** támogat (Adobe After Effects kompatibilis)  
✅ **SkiaSharp rendering**-et használ (hardveres gyorsítás)  
✅ **Programozott vezérlést** biztosít (play, pause, repeat)  
✅ **Skálázható vektoros** minőséget nyújt  
✅ **Teljesítmény optimalizált** (60 FPS lejátszás)  

Ideális **loading indicator-okhoz**, **success/error feedback**-hez, **dekoratív animációkhoz** és **interaktív ikon**okhoz.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Függőségek**: SkiaSharp, SkiaSharp.Skottie, SkiaSharp.Views.WPF  
**Licence**: Belső felhasználásra

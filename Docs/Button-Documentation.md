# Button Stílusok Dokumentáció

## Áttekintés

A `UI/Button.xaml` egy globális ResourceDictionary, amely **modern, Material Design inspirálta button stílusokat** tartalmaz WPF alkalmazásokhoz. Az implicit stílus miatt **minden Button** az alkalmazásban automatikusan ezt a megjelenést kapja.

### Főbb Jellemzők

- ✅ **Globális implicit stílus**: Automatikus alkalmazás minden Button-ra
- ✅ **Material Design színek**: Kék (#2196F3) alapértelmezett
- ✅ **Hover és Pressed állapotok**: Sötétedő háttér
- ✅ **Kerek sarkok**: CornerRadius=5
- ✅ **ButtonAssist attached properties**: Testreszabható attribútumok
- ✅ **Disabled állapot**: Szürke megjelenés

---

## Fájlok

- **XAML**: `UI/Button.xaml`
- **Code-behind**: `UI/ButtonAssist.cs` (Attached Properties)
- **Namespace**: `DuckDBDemo.UI`

---

## Beépített Stílusok

### BaseButtonStyle

Ez az **alap stílus**, amely tartalmazza az összes alapértelmezett beállítást.

```xaml
<Style x:Key="BaseButtonStyle" TargetType="Button">
    <Setter Property="Background" Value="#2196F3" />
    <Setter Property="Foreground" Value="White" />
    <Setter Property="BorderThickness" Value="0" />
    <Setter Property="Padding" Value="12,8" />
    <Setter Property="FontSize" Value="13" />
    <Setter Property="FontWeight" Value="SemiBold" />
    <Setter Property="Cursor" Value="Hand" />
    <Setter Property="ui:ButtonAssist.CornerRadius" Value="5" />
    <Setter Property="ui:ButtonAssist.HoverBackground" Value="#1976D2" />
    <Setter Property="ui:ButtonAssist.PressedBackground" Value="#1565C0" />
</Style>
```

### Globális (Implicit) Stílus

Az alkalmazás **minden Button**-jára automatikusan alkalmazódik:

```xaml
<Style BasedOn="{StaticResource BaseButtonStyle}" TargetType="Button" />
```

---

## ButtonAssist Attached Properties

A `ButtonAssist` osztály lehetővé teszi a gombok testreszabását XAML-ből:

| Property | Típus | Alapértelmezett | Leírás |
|----------|-------|----------------|--------|
| `CornerRadius` | `CornerRadius` | `5` | Sarok lekerekítése |
| `HoverBackground` | `Brush` | `#1976D2` | Hover állapot háttérszíne |
| `PressedBackground` | `Brush` | `#1565C0` | Pressed állapot háttérszíne |

---

## Használati Példák

### 1. Alapértelmezett Gomb

```xaml
<Button Content="Mentés" Click="SaveButton_Click" />
```

Ez automatikusan megkapja a kék Material Design stílust.

### 2. Egyedi Háttérszín

```xaml
<Button 
    Content="Törlés"
    Background="#E74C3C"
    ui:ButtonAssist.HoverBackground="#C0392B"
    ui:ButtonAssist.PressedBackground="#A93226" />
```

### 3. Zöld "Siker" Gomb

```xaml
<Button 
    Content="Jóváhagyás"
    Background="#2ECC71"
    ui:ButtonAssist.HoverBackground="#27AE60"
    ui:ButtonAssist.PressedBackground="#229954" />
```

### 4. Szürke Semleges Gomb

```xaml
<Button 
    Content="Mégse"
    Background="#95A5A6"
    ui:ButtonAssist.HoverBackground="#7F8C8D"
    ui:ButtonAssist.PressedBackground="#707B7C" />
```

### 5. Kerekebb Sarkok

```xaml
<Button 
    Content="Pills Button"
    ui:ButtonAssist.CornerRadius="15"
    Padding="20,8" />
```

### 6. Teljesen Kerek Gomb (Ikon)

```xaml
<Button 
    Width="40"
    Height="40"
    Content="+"
    FontSize="18"
    ui:ButtonAssist.CornerRadius="20" />
```

### 7. Binding ViewModel-hez

```xaml
<Button 
    Content="Betöltés"
    Command="{Binding LoadCommand}"
    IsEnabled="{Binding IsNotLoading}" />
```

ViewModel:
```csharp
public class MainViewModel : INotifyPropertyChanged
{
    private bool _isLoading;
    
    public bool IsNotLoading => !_isLoading;
    
    public ICommand LoadCommand { get; }
    
    public MainViewModel()
    {
        LoadCommand = new RelayCommand(ExecuteLoad);
    }
    
    private async void ExecuteLoad(object parameter)
    {
        _isLoading = true;
        OnPropertyChanged(nameof(IsNotLoading));
        
        await Task.Delay(2000); // Betöltés szimuláció
        
        _isLoading = false;
        OnPropertyChanged(nameof(IsNotLoading));
    }
}
```

---

## Színpaletta Javaslatok

### Material Design Színek

#### Kék (Alapértelmezett, Info)
```xaml
Background="#2196F3"              <!-- Normal -->
HoverBackground="#1976D2"         <!-- Hover -->
PressedBackground="#1565C0"       <!-- Pressed -->
```

#### Zöld (Siker, Jóváhagyás)
```xaml
Background="#4CAF50"              <!-- Normal -->
HoverBackground="#388E3C"         <!-- Hover -->
PressedBackground="#2E7D32"       <!-- Pressed -->

<!-- Világos Zöld -->
Background="#2ECC71"              
HoverBackground="#27AE60"
PressedBackground="#229954"
```

#### Piros (Hiba, Törlés)
```xaml
Background="#F44336"              <!-- Normal -->
HoverBackground="#D32F2F"         <!-- Hover -->
PressedBackground="#C62828"       <!-- Pressed -->

<!-- Élénk Piros -->
Background="#E74C3C"
HoverBackground="#C0392B"
PressedBackground="#A93226"
```

#### Narancs (Figyelmeztetés)
```xaml
Background="#FF9800"              <!-- Normal -->
HoverBackground="#F57C00"         <!-- Hover -->
PressedBackground="#E65100"       <!-- Pressed -->
```

#### Lila (Speciális, Admin)
```xaml
Background="#9C27B0"              <!-- Normal -->
HoverBackground="#7B1FA2"         <!-- Hover -->
PressedBackground="#6A1B9A"       <!-- Pressed -->
```

#### Szürke (Semleges, Mégse)
```xaml
Background="#9E9E9E"              <!-- Normal -->
HoverBackground="#757575"         <!-- Hover -->
PressedBackground="#616161"       <!-- Pressed -->

<!-- Világos Szürke -->
Background="#BDBDBD"
HoverBackground="#9E9E9E"
PressedBackground="#757575"
```

---

## Vizuális Állapotok

### Normal Állapot

- **Background**: #2196F3 (kék)
- **Foreground**: White
- **Cursor**: Hand
- **Padding**: 12,8 (bal/jobb, fel/le)
- **FontWeight**: SemiBold

### Hover Állapot

- **Background**: #1976D2 (sötétebb kék)
- Egyéb tulajdonságok változatlanok

### Pressed Állapot

- **Background**: #1565C0 (még sötétebb kék)

### Disabled Állapot

- **Background**: #BDBDBD (világosszürke)
- **Foreground**: #757575 (sötétszürke)
- **Cursor**: Arrow (normál nyíl, nem kéz)

---

## ButtonAssist Implementáció

Ha használni szeretnéd az attached property-ket, szükséged van a `ButtonAssist` osztályra:

```csharp
// UI/ButtonAssist.cs
using System.Windows;
using System.Windows.Media;

namespace DuckDBDemo.UI;

public static class ButtonAssist
{
    // CornerRadius Attached Property
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.RegisterAttached(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(ButtonAssist),
            new PropertyMetadata(new CornerRadius(5)));

    public static CornerRadius GetCornerRadius(DependencyObject obj)
        => (CornerRadius)obj.GetValue(CornerRadiusProperty);

    public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        => obj.SetValue(CornerRadiusProperty, value);

    // HoverBackground Attached Property
    public static readonly DependencyProperty HoverBackgroundProperty =
        DependencyProperty.RegisterAttached(
            "HoverBackground",
            typeof(Brush),
            typeof(ButtonAssist),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x19, 0x76, 0xD2))));

    public static Brush GetHoverBackground(DependencyObject obj)
        => (Brush)obj.GetValue(HoverBackgroundProperty);

    public static void SetHoverBackground(DependencyObject obj, Brush value)
        => obj.SetValue(HoverBackgroundProperty, value);

    // PressedBackground Attached Property
    public static readonly DependencyProperty PressedBackgroundProperty =
        DependencyProperty.RegisterAttached(
            "PressedBackground",
            typeof(Brush),
            typeof(ButtonAssist),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x15, 0x65, 0xC0))));

    public static Brush GetPressedBackground(DependencyObject obj)
        => (Brush)obj.GetValue(PressedBackgroundProperty);

    public static void SetPressedBackground(DependencyObject obj, Brush value)
        => obj.SetValue(PressedBackgroundProperty, value);
}
```

---

## Layout Példák

### Egymás Mellett (StackPanel)

```xaml
<StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
    <Button Content="Mégse" Background="#95A5A6" Margin="0,0,10,0" />
    <Button Content="Mentés" />
</StackPanel>
```

### Teljes Szélesség

```xaml
<Button 
    Content="Bejelentkezés"
    HorizontalAlignment="Stretch"
    Padding="0,12" />
```

### Gomb Csoport (UniformGrid)

```xaml
<UniformGrid Columns="3">
    <Button Content="1" />
    <Button Content="2" />
    <Button Content="3" />
</UniformGrid>
```

### Floating Action Button (Jobb Alsó Sarok)

```xaml
<Grid>
    <!-- Fő tartalom -->
    <ContentControl ... />
    
    <!-- FAB -->
    <Button
        Width="56"
        Height="56"
        Margin="20"
        HorizontalAlignment="Right"
        VerticalAlignment="Bottom"
        Content="+"
        FontSize="24"
        ui:ButtonAssist.CornerRadius="28" />
</Grid>
```

---

## Méret Variációk

### Kis Gomb

```xaml
<Button 
    Content="OK"
    Padding="8,4"
    FontSize="11" />
```

### Normál Gomb (Alapértelmezett)

```xaml
<Button 
    Content="Mentés"
    Padding="12,8"
    FontSize="13" />
```

### Nagy Gomb

```xaml
<Button 
    Content="Kezdés"
    Padding="20,12"
    FontSize="16" />
```

### Széles Gomb

```xaml
<Button 
    Content="Teljes Regisztráció"
    MinWidth="200"
    Padding="20,10" />
```

---

## Best Practices

### ✅ Jó Gyakorlatok

1. **Konzisztens színek**: Használj színkategóriákat (zöld=siker, piros=hiba)
2. **Rövid szövegek**: Max 2-3 szó a gombon
3. **Ikonok hozzáadása**: Vizuális segédlet (emoji vagy ikon)
4. **Hierarchia**: Elsődleges gomb = kék, másodlagos = szürke
5. **Disabled állapot**: Használd az `IsEnabled` binding-ot
6. **Command pattern**: MVVM-ben használj ICommand-ot

### ❌ Kerülendő

1. ❌ Túl hosszú szöveg (több sor)
2. ❌ Túl apró gombok (< 32px magasság)
3. ❌ Alacsony kontrasztú színek
4. ❌ Sok különböző szín egymás mellett
5. ❌ Click és Command egyszerre

---

## Emoji Ikonok Gombokban

```xaml
<!-- Mentés -->
<Button Content="💾 Mentés" />

<!-- Törlés -->
<Button Content="🗑️ Törlés" Background="#E74C3C" />

<!-- Keresés -->
<Button Content="🔍 Keresés" />

<!-- Letöltés -->
<Button Content="⬇️ Letöltés" Background="#2ECC71" />

<!-- Beállítások -->
<Button Content="⚙️ Beállítások" Background="#9E9E9E" />

<!-- Bezárás -->
<Button Content="❌ Bezárás" Background="#E74C3C" />
```

---

## Összefoglalás

A `Button.xaml` ResourceDictionary egy **globális, Material Design inspirálta button stílust** biztosít, amely:

✅ **Automatikusan alkalmazódik** minden Button-ra (implicit stílus)  
✅ **Testreszabható** attached property-ken keresztül  
✅ **Modern megjelenés** hover és pressed effektekkel  
✅ **Színpaletta támogatás** különböző kategóriákhoz  
✅ **Disabled állapot kezelés** szürke megjelenéssel  

Ideális **űrlapokhoz**, **dialógusokhoz**, **toolbar-okhoz** és **navigációs gombokhoz**.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Függőségek**: ButtonAssist.cs (attached properties)  
**Licence**: Belső felhasználásra

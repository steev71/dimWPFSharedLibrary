# DataGrid Stílusok Dokumentáció

## Áttekintés

A `UI/DataGrid.xaml` egy globális ResourceDictionary, amely **modern, táblázat-szerű stílusokat** tartalmaz WPF `DataGrid` komponenshez. Az implicit stílus miatt **minden DataGrid** automatikusan ezt a megjelenést kapja.

### Főbb Jellemzők

- ✅ **Sötét fejléc**: Material Design (#2C3E50) színnel
- ✅ **Zebra csíkozás**: Váltakozó sorok (#FAFAFA)
- ✅ **Hover és Selection**: Kék (#E3F2FD) kijelölés
- ✅ **Rendezés vizualizáció**: Nyíl ikon a fejlécben
- ✅ **Virtualizáció**: Nagy adathalmazokhoz optimalizált
- ✅ **Consolas font**: Monospace betűtípus számokhoz
- ✅ **Globális implicit stílus**: Automatikus alkalmazás

---

## Fájlok

- **XAML**: `UI/DataGrid.xaml`
- **Namespace**: System.Windows.Controls (beépített)

---

## Beépített Stílusok

### 1. DataGrid (Főkomponens)

```xaml
<Style TargetType="DataGrid">
    <Setter Property="Background" Value="White" />
    <Setter Property="BorderBrush" Value="#E0E0E0" />
    <Setter Property="RowBackground" Value="White" />
    <Setter Property="AlternatingRowBackground" Value="#FAFAFA" />
    <Setter Property="GridLinesVisibility" Value="Horizontal" />
    <Setter Property="HorizontalGridLinesBrush" Value="#F0F0F0" />
    <Setter Property="RowHeight" Value="25" />
    <Setter Property="ColumnHeaderHeight" Value="30" />
    <Setter Property="FontSize" Value="12" />
    <Setter Property="FontFamily" Value="Consolas" />
    <Setter Property="EnableRowVirtualization" Value="True" />
    <Setter Property="EnableColumnVirtualization" Value="True" />
</Style>
```

### 2. DataGridColumnHeader (Fejléc)

```xaml
<Style TargetType="DataGridColumnHeader">
    <Setter Property="Background" Value="#2C3E50" />
    <Setter Property="Foreground" Value="White" />
    <Setter Property="FontWeight" Value="SemiBold" />
    <Setter Property="FontSize" Value="13" />
    <Setter Property="Padding" Value="12,0" />
    <Setter Property="Height" Value="30" />
</Style>
```

Hover állapotban:
- **Background**: #34495E (sötétebb szürke)

Rendezés esetén:
- **Nyíl ikon** jelenik meg (fel/le)

### 3. DataGridCell (Cella)

```xaml
<Style TargetType="DataGridCell">
    <Setter Property="BorderThickness" Value="0" />
    <Setter Property="Padding" Value="5,0" />
</Style>
```

Kijelölve:
- **Background**: #E3F2FD (világoskék)
- **Foreground**: #1976D2 (sötétkék)

### 4. DataGridRow (Sor)

```xaml
<Style TargetType="DataGridRow">
    <Setter Property="Background" Value="Transparent" />
</Style>
```

Hover állapotban:
- **Background**: #F5F5F5 (világosszürke)
- **Cursor**: Hand (kéz ikon)

Kijelölve:
- **Background**: #E3F2FD (világoskék)

Kijelölve + Hover:
- **Background**: #BBDEFB (sötétebb kék)

---

## Használati Példák

### 1. Alapvető DataGrid

```xaml
<DataGrid ItemsSource="{Binding Items}" />
```

Ez automatikusan megkapja a modern stílust.

### 2. AutoGenerateColumns

```xaml
<DataGrid
    ItemsSource="{Binding AccountBalances}"
    AutoGenerateColumns="True"
    CanUserSortColumns="True"
    IsReadOnly="True" />
```

### 3. Egyedi Oszlopok

```xaml
<DataGrid ItemsSource="{Binding Products}" AutoGenerateColumns="False">
    <DataGrid.Columns>
        <DataGridTextColumn 
            Header="Termék Név" 
            Binding="{Binding Name}" 
            Width="*" />
        
        <DataGridTextColumn 
            Header="Ár" 
            Binding="{Binding Price, StringFormat=C}" 
            Width="Auto" />
        
        <DataGridTextColumn 
            Header="Készlet" 
            Binding="{Binding Stock}" 
            Width="80" />
        
        <DataGridCheckBoxColumn 
            Header="Aktív" 
            Binding="{Binding IsActive}" 
            Width="60" />
    </DataGrid.Columns>
</DataGrid>
```

### 4. Formázott Oszlopok

```xaml
<DataGrid ItemsSource="{Binding Transactions}" AutoGenerateColumns="False">
    <DataGrid.Columns>
        <!-- Dátum formázás -->
        <DataGridTextColumn 
            Header="Dátum" 
            Binding="{Binding Date, StringFormat=yyyy-MM-dd}" 
            Width="100" />
        
        <!-- Pénznem formázás -->
        <DataGridTextColumn 
            Header="Összeg" 
            Binding="{Binding Amount, StringFormat=C0}" 
            Width="120" />
        
        <!-- Százalék formázás -->
        <DataGridTextColumn 
            Header="ÁFA" 
            Binding="{Binding VatRate, StringFormat=P1}" 
            Width="80" />
        
        <!-- Ezres elválasztó -->
        <DataGridTextColumn 
            Header="Tétel szám" 
            Binding="{Binding Count, StringFormat=N0}" 
            Width="100" />
    </DataGrid.Columns>
</DataGrid>
```

### 5. Színezett Cellák (ConditionalFormatting)

```xaml
<DataGrid ItemsSource="{Binding Scores}">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Név" Binding="{Binding Name}" />
        
        <DataGridTemplateColumn Header="Pontszám">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Border Padding="5,2" CornerRadius="3">
                        <Border.Style>
                            <Style TargetType="Border">
                                <Setter Property="Background" Value="Transparent" />
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding Score, Converter={StaticResource ScoreToCategory}}" Value="High">
                                        <Setter Property="Background" Value="#C8E6C9" />
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding Score, Converter={StaticResource ScoreToCategory}}" Value="Medium">
                                        <Setter Property="Background" Value="#FFF9C4" />
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding Score, Converter={StaticResource ScoreToCategory}}" Value="Low">
                                        <Setter Property="Background" Value="#FFCCBC" />
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </Border.Style>
                        <TextBlock Text="{Binding Score}" />
                    </Border>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
    </DataGrid.Columns>
</DataGrid>
```

### 6. Dupla Kattintás Esemény

```xaml
<DataGrid 
    x:Name="dataGrid"
    ItemsSource="{Binding Items}"
    MouseDoubleClick="DataGrid_MouseDoubleClick" />
```

Code-behind:
```csharp
private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
{
    if (dataGrid.SelectedItem is MyItem selectedItem)
    {
        // Részletek megjelenítése
        ShowDetails(selectedItem);
    }
}
```

### 7. Sorválasztás Esemény

```xaml
<DataGrid 
    ItemsSource="{Binding Items}"
    SelectionChanged="DataGrid_SelectionChanged" />
```

Code-behind:
```csharp
private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (dataGrid.SelectedItem is MyItem item)
    {
        SelectedItemDetails.Text = $"Kiválasztva: {item.Name}";
    }
}
```

---

## Vizuális Állapotok

### Fejléc (Header)

#### Normal
- **Background**: #2C3E50 (sötétszürke)
- **Foreground**: White
- **FontWeight**: SemiBold

#### Hover
- **Background**: #34495E (világosabb szürke)

#### Rendezés (Ascending)
- Felfelé mutató **nyíl** (▲)

#### Rendezés (Descending)
- Lefelé mutató **nyíl** (▼)

### Sorok (Rows)

#### Normal (Páros sorok)
- **Background**: White

#### Váltakozó sorok (Páratlan)
- **Background**: #FAFAFA (világosszürke)

#### Hover
- **Background**: #F5F5F5 (kicsit sötétebb szürke)
- **Cursor**: Hand

#### Kijelölt (Selected)
- **Background**: #E3F2FD (világoskék)

#### Kijelölt + Hover
- **Background**: #BBDEFB (sötétebb kék)

### Cellák (Cells)

#### Normal
- **Border**: Nincs
- **Padding**: 5,0 (bal/jobb)

#### Kijelölt
- **Background**: #E3F2FD
- **Foreground**: #1976D2

---

## Virtualizáció és Teljesítmény

A stílus alapértelmezetten **engedélyezi a virtualizációt**, ami nagy adathalmazok esetén kritikus:

```xaml
<Setter Property="EnableRowVirtualization" Value="True" />
<Setter Property="EnableColumnVirtualization" Value="True" />
<Setter Property="VirtualizingPanel.IsVirtualizing" Value="True" />
<Setter Property="VirtualizingPanel.VirtualizationMode" Value="Recycling" />
```

### Teljesítmény Tippek

1. **Virtualizáció**: Mindig engedélyezve (alapértelmezett)
2. **Egyszerű cellák**: Ne használj túl komplex Template-eket
3. **Lazy Loading**: Nagy adatokat lapozva töltsd be
4. **Disable AutoGenerate**: Ha tudsz, használj explicit oszlopokat
5. **ReadOnly**: Ha nem kell szerkeszteni, `IsReadOnly="True"`

---

## Oszlop Típusok

### DataGridTextColumn

```xaml
<DataGridTextColumn 
    Header="Név" 
    Binding="{Binding Name}" 
    Width="200" />
```

### DataGridCheckBoxColumn

```xaml
<DataGridCheckBoxColumn 
    Header="Aktív" 
    Binding="{Binding IsActive}" 
    Width="60" />
```

### DataGridComboBoxColumn

```xaml
<DataGridComboBoxColumn 
    Header="Kategória" 
    SelectedItemBinding="{Binding Category}"
    ItemsSource="{Binding DataContext.Categories, RelativeSource={RelativeSource AncestorType=DataGrid}}"
    Width="150" />
```

### DataGridTemplateColumn (Egyedi)

```xaml
<DataGridTemplateColumn Header="Akciók" Width="100">
    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <Button Content="✏️" Margin="2" Padding="4" />
                <Button Content="🗑️" Margin="2" Padding="4" Background="#E74C3C" />
            </StackPanel>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
</DataGridTemplateColumn>
```

---

## Szélességek Beállítása

### Auto (Tartalomhoz igazodó)

```xaml
<DataGridTextColumn Width="Auto" ... />
```

### Pixel-based (Fix)

```xaml
<DataGridTextColumn Width="150" ... />
```

### Star-based (Arányos)

```xaml
<DataGridTextColumn Width="*" ... />    <!-- 1x -->
<DataGridTextColumn Width="2*" ... />   <!-- 2x -->
<DataGridTextColumn Width="3*" ... />   <!-- 3x -->
```

### SizeToCells (Alapértelmezett)

```xaml
<DataGrid ColumnWidth="SizeToCells" ... />
```

---

## Rendezés (Sorting)

### Alapértelmezett Rendezés

```xaml
<DataGrid 
    ItemsSource="{Binding Items}"
    CanUserSortColumns="True" />
```

A felhasználó kattintással rendezheti az oszlopokat.

### Programozott Rendezés

```csharp
// CollectionView használata
var view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

// Rendezés növekvő sorrendben
view.SortDescriptions.Clear();
view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

// Rendezés csökkenő sorrendben
view.SortDescriptions.Clear();
view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));
```

### Többszintű Rendezés

```csharp
var view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
view.SortDescriptions.Clear();
view.SortDescriptions.Add(new SortDescription("Category", ListSortDirection.Ascending));
view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
```

---

## Export

### CSV Export

```csharp
public void ExportToCSV(DataGrid dataGrid, string filePath)
{
    var sb = new StringBuilder();
    
    // Fejlécek
    var headers = dataGrid.Columns
        .Select(c => c.Header.ToString())
        .ToList();
    sb.AppendLine(string.Join(",", headers));
    
    // Sorok
    foreach (var item in dataGrid.Items)
    {
        var values = dataGrid.Columns
            .Select(c => GetCellValue(item, c))
            .Select(v => $"\"{v}\"");
        sb.AppendLine(string.Join(",", values));
    }
    
    File.WriteAllText(filePath, sb.ToString());
}

private string GetCellValue(object item, DataGridColumn column)
{
    if (column is DataGridBoundColumn boundColumn &&
        boundColumn.Binding is Binding binding)
    {
        var property = item.GetType().GetProperty(binding.Path.Path);
        return property?.GetValue(item)?.ToString() ?? "";
    }
    return "";
}
```

---

## Best Practices

### ✅ Jó Gyakorlatok

1. **AutoGenerateColumns = False**: Ha tudsz, add meg explicit az oszlopokat
2. **IsReadOnly = True**: Ha nem kell szerkeszteni
3. **CanUserResizeColumns = True**: Engedélyezd a méretezést
4. **Virtualizáció**: Mindig engedélyezve nagy adatoknál
5. **Formázás**: Használj StringFormat-ot számokhoz/dátumokhoz
6. **Consolas font**: Jó számok és kódok megjelenítéséhez

### ❌ Kerülendő

1. ❌ Túl sok oszlop (> 15-20)
2. ❌ Komplex cellák heavy Template-tel
3. ❌ Virtualizáció kikapcsolva nagy adatoknál
4. ❌ AutoGenerateColumns = True production-ben
5. ❌ Inline eseménykezelők (használj MVVM-et)

---

## Összefoglalás

A `DataGrid.xaml` ResourceDictionary egy **modern, Material Design inspirálta táblázat stílust** biztosít, amely:

✅ **Sötét fejléccel** és **világos sorokkal** (#2C3E50 + White/Gray)  
✅ **Zebra csíkozással** a jobb olvashatóság érdekében  
✅ **Kék kijelöléssel** (#E3F2FD) és hover effektekkel  
✅ **Rendezési vizualizációval** nyíl ikonokkal  
✅ **Virtualizációval** nagy adathalmazokhoz  
✅ **Consolas betűtípussal** számokhoz és kódokhoz  

Ideális **adattáblázatokhoz**, **listákhoz**, **jelentésekhez** és **admin felületekhez**.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Licence**: Belső felhasználásra

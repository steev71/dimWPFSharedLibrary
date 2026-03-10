# Emoji Osztály Dokumentáció

## Áttekintés

Az `Emoji` egy **statikus helper osztály**, amely **előre definiált emoji konstansokat** tartalmaz gyakori használati esetekhez. Célja a kód tisztaságának megőrzése és az emoji-k könnyű újrafelhasználása WPF alkalmazásokban.

### Főbb Jellemzők

- ✅ **Statikus konstansok**: Egyszerű használat `Emoji.Check` formában
- ✅ **Kategorizált**: Logikai csoportokban (Common, Finance, Data, stb.)
- ✅ **Unicode támogatás**: Minden modern platformon működik
- ✅ **IntelliSense támogatás**: Gyors kódolás Visual Studio-ban
- ✅ **String konstansok**: Könnyen beilleszthető szövegekbe

---

## Fájlok

- **Code-behind**: `UI/Emoji.cs`
- **Namespace**: `DuckDBDemo.UI`

---

## Emoji Kategóriák

### 1. Common (Általános)

A leggyakrabban használt jelzések:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Check` | ✅ | Siker, kész, engedélyezve |
| `CheckAlt` | ✔️ | Siker (alternatív) |
| `Cross` | ❌ | Hiba, törlés, tiltva |
| `Warning` | ⚠️ | Figyelmeztetés |
| `Info` | ℹ️ | Információ |
| `Fire` | 🔥 | Népszerű, trend, fontos |
| `Star` | ⭐ | Kedvenc, kiemelt |

```csharp
public const string Check = "✅";
public const string Cross = "❌";
public const string Warning = "⚠️";
```

### 2. Navigation (Navigációs Nyilak)

Irányjelzők és navigációs ikonok:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Right` | ➡️ | Következő, tovább |
| `Left` | ⬅️ | Előző, vissza |
| `Up` | ⬆️ | Fel, növekedés |
| `Down` | ⬇️ | Le, csökkenés |
| `UpRight` | ↗️ | Növekedés, pozitív trend |
| `DownRight` | ↘️ | Csökkenés, negatív trend |
| `ReturnLeft` | ↩️ | Visszatérés |
| `ReturnRight` | ↪️ | Átirányítás |
| `UpTriangle` | 🔼 | Rendezés növekvő |
| `DownTriangle` | 🔽 | Rendezés csökkenő |

```csharp
public const string Right = "➡️";
public const string UpRight = "↗️";
```

### 3. Search (Keresés)

Keresési ikonok:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `SearchLeft` | 🔍 | Keresés |
| `SearchRight` | 🔎 | Keresés (alternatív) |

```csharp
public const string SearchLeft = "🔍";
```

### 4. Data (Adatvizualizáció)

Grafikonok és diagramok:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Chart` | 📊 | Grafikon, diagram |
| `ChartUp` | 📈 | Növekvő grafikon |
| `ChartDown` | 📉 | Csökkenő grafikon |
| `Abacus` | 🧮 | Számítás, analitika |

```csharp
public const string Chart = "📊";
public const string ChartUp = "📈";
```

### 5. Documents (Dokumentumok)

Fájlok és dokumentáció:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Memo` | 📝 | Jegyzet, szerkesztés |
| `Page` | 📄 | Dokumentum |
| `PageCurl` | 📃 | Oldal |
| `Receipt` | 🧾 | Bizonylat, számla |
| `Pin` | 📌 | Kitűzött, fontos |
| `Paperclip` | 📎 | Csatolmány |
| `CardIndexDividers` | 🗂️ | Rendszerezés |
| `Folder` | 📁 | Mappa |
| `CardFileBox` | 🗃️ | Archívum |
| `FilingCabinet` | 🗄️ | Tárolás |

```csharp
public const string Memo = "📝";
public const string Receipt = "🧾";
```

### 6. Finance (Pénzügy)

Pénzügyi ikonok:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `MoneyBag` | 💰 | Pénz, vagyon |
| `Banknote` | 💵 | Bankjegy, készpénz |
| `CreditCard` | 💳 | Bankkártya, fizetés |
| `Bank` | 🏦 | Bank, pénzintézet |
| `MoneyWithWings` | 💸 | Kiadás, veszteség |

```csharp
public const string MoneyBag = "💰";
public const string Bank = "🏦";
```

### 7. PeopleAndOrg (Emberek és Szervezetek)

Személyek és cégek:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Person` | 👤 | Felhasználó, profil |
| `People` | 👥 | Csapat, több felhasználó |
| `OfficeWorker` | 🧑‍💼 | Alkalmazott, üzletember |
| `OfficeBuilding` | 🏢 | Iroda, cég |
| `Factory` | 🏭 | Gyár, termelés |
| `Store` | 🏪 | Üzlet, bolt |

```csharp
public const string Person = "👤";
public const string OfficeBuilding = "🏢";
```

### 8. Time (Idő)

Idővel kapcsolatos ikonok:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `SpiralCalendar` | 🗓️ | Naptár (spirál) |
| `Calendar` | 📅 | Naptár |
| `Stopwatch` | ⏱️ | Időmérő |
| `AlarmClock` | ⏰ | Ébresztő, határidő |
| `Clock` | 🕒 | Óra |

```csharp
public const string Calendar = "📅";
public const string Stopwatch = "⏱️";
```

### 9. Tools (Eszközök)

Beállítások és eszközök:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Puzzle` | 🧩 | Plugin, integráció |
| `Brain` | 🧠 | Intelligencia, AI |
| `TestTube` | 🧪 | Teszt, kísérlet |
| `ToolsEmoji` | 🛠️ | Eszközök |
| `Wrench` | 🔧 | Javítás, karbantartás |
| `Gear` | ⚙️ | Beállítások |

```csharp
public const string Gear = "⚙️";
public const string Wrench = "🔧";
```

### 10. Audit (Könyvvizsgálat)

Speciális audit kategória:

| Konstans | Emoji | Használat |
|----------|-------|-----------|
| `Balance` | ⚖️ | Egyensúly, mérleg, audit |

```csharp
public const string Balance = "⚖️";
```

---

## Használati Példák

### 1. TextBlock-ban

```xaml
<TextBlock Text="{x:Static ui:Emoji.Check}" FontSize="16" />

<TextBlock>
    <Run Text="{x:Static ui:Emoji.Check}" />
    <Run Text=" Sikeres mentés" />
</TextBlock>
```

### 2. Button-ban

```xaml
<Button Content="{x:Static ui:Emoji.MoneyBag}" />

<Button>
    <StackPanel Orientation="Horizontal">
        <TextBlock Text="{x:Static ui:Emoji.SearchLeft}" Margin="0,0,5,0" />
        <TextBlock Text="Keresés" />
    </StackPanel>
</Button>
```

### 3. String Interpolation (Code-behind)

```csharp
// Egyszerű használat
string message = $"{Emoji.Check} Művelet sikeres!";

// Több emoji
string warning = $"{Emoji.Warning} Figyelem! {Emoji.Fire} Fontos üzenet!";

// Formázott szöveg
string report = $"{Emoji.Chart} Adatok: {count} tétel {Emoji.ChartUp} +15%";

// MessageBox
MessageBox.Show(
    $"{Emoji.Check} Sikeres importálás!\n\n{Emoji.Receipt} {count} bizonylat feldolgozva.",
    "Siker",
    MessageBoxButton.OK,
    MessageBoxImage.Information);
```

### 4. Függvény Visszatérési Érték

```csharp
public string GetStatusIcon(bool isSuccess)
{
    return isSuccess ? Emoji.Check : Emoji.Cross;
}

// Használat
txtStatus.Text = $"{GetStatusIcon(result)} {message}";
```

### 5. Lista Elemekben

```csharp
var logEntries = new ObservableCollection<string>
{
    $"{Emoji.Info} Alkalmazás elindult",
    $"{Emoji.SearchLeft} Keresés folyamatban...",
    $"{Emoji.Check} Adatok betöltve",
    $"{Emoji.Warning} Alacsony memória",
    $"{Emoji.Cross} Kapcsolat hiba"
};

logListBox.ItemsSource = logEntries;
```

### 6. DataGrid-ben

```xaml
<DataGrid ItemsSource="{Binding Transactions}" AutoGenerateColumns="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Állapot" Width="60">
            <DataGridTextColumn.Binding>
                <Binding Path="IsCompleted">
                    <Binding.Converter>
                        <local:BoolToEmojiConverter TrueEmoji="✅" FalseEmoji="⏳" />
                    </Binding.Converter>
                </Binding>
            </DataGridTextColumn.Binding>
        </DataGridTextColumn>
        
        <DataGridTextColumn Header="Név" Binding="{Binding Name}" />
        <DataGridTextColumn Header="Összeg" Binding="{Binding Amount, StringFormat=C}" />
    </DataGrid.Columns>
</DataGrid>
```

### 7. Tooltip-ben

```xaml
<Button Content="Mentés">
    <Button.ToolTip>
        <TextBlock>
            <Run Text="{x:Static ui:Emoji.Info}" />
            <Run Text=" Ctrl+S gyorsbillentyű" />
        </TextBlock>
    </Button.ToolTip>
</Button>
```

### 8. Dinamikus Állapot Jelzés

```csharp
public string GetTrendEmoji(decimal change)
{
    if (change > 0) return Emoji.UpRight;
    if (change < 0) return Emoji.DownRight;
    return Emoji.Right;
}

// Használat
var changeText = $"{GetTrendEmoji(percentChange)} {percentChange:P2}";
txtChange.Text = changeText;
```

---

## Kategória Stringek

Az osztály tartalmaz előre összeállított kategória stringeket is:

```csharp
// Összes emoji egy kategóriában
string commonEmojis = Emoji.Common;      // "✅ ✔️ ❌ ⚠️ ℹ️ 🔥 ⭐"
string financeEmojis = Emoji.Finance;    // "💰 💵 💳 🏦 💸"
string dataEmojis = Emoji.Data;          // "📊 📈 📉 🧮"

// Összes emoji
string allEmojis = Emoji.All;
```

Használható például egy emoji picker-ben vagy referencia dokumentációban.

---

## Best Practices

### ✅ Jó Gyakorlatok

1. **Konzisztencia**: Használd ugyanazt az emoji-t ugyanarra a funkcióra
2. **Olvashatóság**: Ne használj túl sok emoji-t egy szövegben
3. **Kontrasztus**: Sötét háttéren is jól láthatóak
4. **Méret**: 14-16px FontSize ideális
5. **Spacing**: Adj margót az emoji után (5-8px)
6. **Statikus referencia**: `Emoji.Check` jobb mint `"✅"`

```xaml
<!-- Jó példa -->
<TextBlock>
    <Run Text="{x:Static ui:Emoji.Check}" FontSize="14" />
    <Run Text=" " />
    <Run Text="Sikeres művelet" />
</TextBlock>
```

### ❌ Kerülendő

1. ❌ Túl sok emoji egy szövegben (max 2-3)
2. ❌ Inline unicode karakterek helyett használd a konstansokat
3. ❌ Túl apró méret (< 12px)
4. ❌ Emoji a kód logikájában (csak UI-ban)
5. ❌ Nem támogatott emoji-k régi Windows verziókon

---

## Platform Kompatibilitás

### Windows 10/11

✅ Teljes támogatás, színes emoji-k

### Windows 8.1/7

⚠️ Korlátozott támogatás, néhány emoji fekete-fehér vagy nem jelenik meg

### Font Fallback

Ha egy emoji nem renderelődik:
```xaml
<TextBlock FontFamily="Segoe UI Emoji, Arial" />
```

---

## Emoji Picker Implementáció

Példa egy egyszerű emoji picker-re:

```xaml
<Window ...>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        
        <!-- Emoji Toolbar -->
        <UniformGrid Grid.Row="0" Columns="10">
            <Button Content="{x:Static ui:Emoji.Check}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Cross}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Warning}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Info}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Fire}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Star}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.SearchLeft}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Chart}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.MoneyBag}" Click="InsertEmoji_Click" />
            <Button Content="{x:Static ui:Emoji.Person}" Click="InsertEmoji_Click" />
        </UniformGrid>
        
        <!-- Szöveg editor -->
        <TextBox Grid.Row="1" x:Name="txtEditor" TextWrapping="Wrap" />
    </Grid>
</Window>
```

Code-behind:
```csharp
private void InsertEmoji_Click(object sender, RoutedEventArgs e)
{
    if (sender is Button button && button.Content is string emoji)
    {
        int caretIndex = txtEditor.CaretIndex;
        txtEditor.Text = txtEditor.Text.Insert(caretIndex, emoji + " ");
        txtEditor.CaretIndex = caretIndex + emoji.Length + 1;
        txtEditor.Focus();
    }
}
```

---

## Bővítés

Ha új emoji-kat szeretnél hozzáadni:

```csharp
// UI/Emoji.cs
public static class Emoji
{
    // ... meglévő konstansok ...
    
    // Új kategória: Weather
    public const string Sun = "☀️";
    public const string Cloud = "☁️";
    public const string Rain = "🌧️";
    public const string Thunder = "⚡";
    
    // Kategória string
    public const string Weather = "☀️ ☁️ 🌧️ ⚡";
}
```

---

## Unicode Referencia

Ha manuálisan szeretnél emoji-kat keresni:
- **Emojipedia**: https://emojipedia.org/
- **Unicode Tables**: https://unicode-table.com/en/sets/emoji/
- **Get Emoji**: https://getemoji.com/

---

## Összefoglalás

Az `Emoji` osztály egy **statikus helper**, amely:

✅ **Előre definiált konstansokat** tartalmaz gyakori emoji-khoz  
✅ **Kategorizálva** van (Common, Finance, Data, Tools, stb.)  
✅ **IntelliSense támogatást** biztosít Visual Studio-ban  
✅ **Könnyű használat** XAML-ben és C#-ban  
✅ **Kód tisztaság** - kerüld az inline unicode karaktereket  

Ideális **UI jelzésekhez**, **státusz ikonokhoz**, **vizuális feedback**-hez és **user-friendly üzenetekhez**.

---

**Verzió**: 1.0  
**Utolsó frissítés**: 2024  
**Szerző**: DuckDBDemo projekt  
**Licence**: Belső felhasználásra

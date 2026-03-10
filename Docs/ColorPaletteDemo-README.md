# Color Palette Demo - Használati Útmutató

## Áttekintés

A **Color Palette Demo** egy interaktív WPF ablak, amely bemutatja a DuckDBDemo projekt teljes színpalettáját Bootstrap-szerű kategóriákkal és Tailwind CSS-szerű árnyalat skálákkal.

## Funkciók

### 🎨 Színskálák

Minden fő színkategória **10 árnyalatban** (50-900) jelenik meg:

- **Primary (Kék)** - 50 → 900 (10 árnyalat)
- **Success (Zöld)** - 50 → 900 (10 árnyalat)
- **Danger (Piros)** - 50 → 900 (10 árnyalat)
- **Warning (Narancs)** - 50 → 900 (10 árnyalat)
- **Info (Világoskék)** - 50 → 900 (10 árnyalat)
- **Secondary (Lila)** - 50 → 900 (10 árnyalat)
- **Gray Scale** - 100 → 900 (9 árnyalat)
- **Accent Colors** - 6 kiegészítő szín (Teal, Cyan, Pink, Amber, Lime, Indigo)

### 🖱️ Interaktív Funkciók

#### Kattintás → Vágólapra Másolás

Minden színmintára kattintva:
1. A hex kód automatikusan a vágólapra másolódik (#RRGGBB formátumban)
2. Zöld border villanással visszajelzés (300ms)
3. Azonnal beillesztheted a kódodba

#### Tooltip (Hover)

Minden színmintára mutatva:
- Megjelenik a szín neve (pl. "Primary500")
- Megjelenik a hex kód (pl. "#2196F3")

### 📋 Megnyitás

A Color Palette Demo-t a főablakból nyithatod meg:

1. Indítsd el a DuckDBDemo alkalmazást
2. Kattints a **"🎨 Színpaletta Demo"** csempére
3. Új ablak nyílik meg a színpalettával

Vagy kódból:

```csharp
var colorPaletteWindow = new ColorPaletteDemo();
colorPaletteWindow.Show();
```

### 🎯 Használat Fejlesztés Közben

#### Gyors Színválasztás

1. **Nyisd meg** a Color Palette Demo-t
2. **Kattints** a kívánt színmintára
3. **Illeszd be** (Ctrl+V) a kódodba

```xaml
<!-- Példa: Primary500 színt választottál -->
<Button Background="#2196F3" />

<!-- Vagy a Colors osztályt használva -->
<Button Background="{x:Static ui:Colors.Primary500Brush}" />
```

#### Színkombinációk Tervezése

A demo segít:
- **Kontrasztus ellenőrzésben**: lásd, melyik szövegszín jó sötét/világos háttéren
- **Árnyalat választásban**: finomhangold a hover/pressed állapotokat
- **Paletta tervezésben**: válaszd ki a 2-3 fő színt a projektedhez

### 📊 Példa Gombok

A demo alján látható példa gombok mutatják:
- Hogyan néznek ki a színek gombként
- Fehér vs. sötét szöveg kontrasztja
- Alap (500-as) színek használata

### 💡 Tippek

1. **Alap szín (500)**: Minden skála közepén a ⭐ jelöli
2. **Hover (600-700)**: Használd interaktív elemekhez
3. **Pressed (800-900)**: Használd lenyomott állapothoz
4. **Háttér (50-100)**: Használd világos háttérként
5. **Tailwind stílus**: Az árnyalatok ugyanúgy működnek, mint a Tailwind CSS-ben

### 🔗 További Információk

- **Teljes dokumentáció**: `Docs/Colors-Documentation.md`
- **Használati példák**: `Examples/ColorsUsageExamples.cs`
- **Tailwind példák**: `Examples/TailwindScaleExamples.cs`

### 🎨 Gyors Referencia

| Kategória | Alap (500) | Hover (700) | Pressed (800) | Háttér (50) |
|-----------|------------|-------------|---------------|-------------|
| Primary   | #2196F3    | #1976D2     | #1565C0       | #E3F2FD     |
| Success   | #4CAF50    | #388E3C     | #2E7D32       | #E8F5E9     |
| Danger    | #F44336    | #D32F2F     | #C62828       | #FFEBEE     |
| Warning   | #FFC107    | #FFA000     | #FF8F00       | #FFF8E1     |
| Info      | #03A9F4    | #0288D1     | #0277BD       | #E1F5FE     |
| Secondary | #9C27B0    | #7B1FA2     | #6A1B9A       | #F3E5F5     |

---

**Készítette**: DuckDBDemo projekt  
**Verzió**: 1.0  
**Utolsó frissítés**: 2024

using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

/// <summary>
/// Központi színpaletta osztály a DuckDBDemo projekthez.
/// Bootstrap-szerű kategorizálással és Material Design színekkel.
/// </summary>
public static class Colors
{
    #region Primary Purple Scale (Lila Skála - Tailwind-szerű)

    /// <summary>Primary 50 - Legvilágosabb lila</summary>
    public static readonly Color Primary50 = Color.FromRgb(0xFA, 0xF5, 0xFF);
    public static readonly SolidColorBrush Primary50Brush = new(Primary50);

    /// <summary>Primary 100</summary>
    public static readonly Color Primary100 = Color.FromRgb(0xF3, 0xE8, 0xFF);
    public static readonly SolidColorBrush Primary100Brush = new(Primary100);

    /// <summary>Primary 200</summary>
    public static readonly Color Primary200 = Color.FromRgb(0xE9, 0xD5, 0xFF);
    public static readonly SolidColorBrush Primary200Brush = new(Primary200);

    /// <summary>Primary 300</summary>
    public static readonly Color Primary300 = Color.FromRgb(0xD8, 0xB4, 0xFE);
    public static readonly SolidColorBrush Primary300Brush = new(Primary300);

    /// <summary>Primary 400</summary>
    public static readonly Color Primary400 = Color.FromRgb(0xC0, 0x84, 0xFC);
    public static readonly SolidColorBrush Primary400Brush = new(Primary400);

    /// <summary>Primary 500 - Alap lila (normál állapot)</summary>
    public static readonly Color Primary500 = Color.FromRgb(0xA8, 0x55, 0xF7);
    public static readonly SolidColorBrush Primary500Brush = new(Primary500);

    /// <summary>Primary 600 - Sötétebb lila (hover)</summary>
    public static readonly Color Primary600 = Color.FromRgb(0x93, 0x33, 0xEA);
    public static readonly SolidColorBrush Primary600Brush = new(Primary600);

    /// <summary>Primary 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Primary700 = Color.FromRgb(0x7E, 0x22, 0xCE);
    public static readonly SolidColorBrush Primary700Brush = new(Primary700);

    /// <summary>Primary 800</summary>
    public static readonly Color Primary800 = Color.FromRgb(0x6B, 0x21, 0xA8);
    public static readonly SolidColorBrush Primary800Brush = new(Primary800);

    /// <summary>Primary 900 - Legsötétebb lila</summary>
    public static readonly Color Primary900 = Color.FromRgb(0x58, 0x1C, 0x87);
    public static readonly SolidColorBrush Primary900Brush = new(Primary900);

    // Backward compatibility (régi nevek)
    /// <summary>Elsődleges lila - alapértelmezett (alias Primary500)</summary>
    public static readonly Color Primary = Primary500;
    public static readonly SolidColorBrush PrimaryBrush = Primary500Brush;

    /// <summary>Sötétebb lila - hover (alias Primary700)</summary>
    public static readonly Color PrimaryDark = Primary700;
    public static readonly SolidColorBrush PrimaryDarkBrush = Primary700Brush;

    /// <summary>Még sötétebb - pressed (alias Primary800)</summary>
    public static readonly Color PrimaryDarker = Primary800;
    public static readonly SolidColorBrush PrimaryDarkerBrush = Primary800Brush;

    /// <summary>Világos lila - kijelölések (alias Primary50)</summary>
    public static readonly Color PrimaryLight = Primary50;
    public static readonly SolidColorBrush PrimaryLightBrush = Primary50Brush;

    /// <summary>Nagyon világos - hover kijelölés (alias Primary100)</summary>
    public static readonly Color PrimaryLighter = Primary100;
    public static readonly SolidColorBrush PrimaryLighterBrush = Primary100Brush;

    #endregion

    #region Success Green Scale (Zöld Skála - Tailwind-szerű)

    /// <summary>Success 50 - Legvilágosabb zöld</summary>
    public static readonly Color Success50 = Color.FromRgb(0xE8, 0xF5, 0xE9);
    public static readonly SolidColorBrush Success50Brush = new(Success50);

    /// <summary>Success 100</summary>
    public static readonly Color Success100 = Color.FromRgb(0xC8, 0xE6, 0xC9);
    public static readonly SolidColorBrush Success100Brush = new(Success100);

    /// <summary>Success 200</summary>
    public static readonly Color Success200 = Color.FromRgb(0xA5, 0xD6, 0xA7);
    public static readonly SolidColorBrush Success200Brush = new(Success200);

    /// <summary>Success 300</summary>
    public static readonly Color Success300 = Color.FromRgb(0x81, 0xC7, 0x84);
    public static readonly SolidColorBrush Success300Brush = new(Success300);

    /// <summary>Success 400</summary>
    public static readonly Color Success400 = Color.FromRgb(0x66, 0xBB, 0x6A);
    public static readonly SolidColorBrush Success400Brush = new(Success400);

    /// <summary>Success 500 - Alap zöld (normál)</summary>
    public static readonly Color Success500 = Color.FromRgb(0x4C, 0xAF, 0x50);
    public static readonly SolidColorBrush Success500Brush = new(Success500);

    /// <summary>Success 600 - Sötétebb zöld (hover)</summary>
    public static readonly Color Success600 = Color.FromRgb(0x43, 0xA0, 0x47);
    public static readonly SolidColorBrush Success600Brush = new(Success600);

    /// <summary>Success 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Success700 = Color.FromRgb(0x38, 0x8E, 0x3C);
    public static readonly SolidColorBrush Success700Brush = new(Success700);

    /// <summary>Success 800</summary>
    public static readonly Color Success800 = Color.FromRgb(0x2E, 0x7D, 0x32);
    public static readonly SolidColorBrush Success800Brush = new(Success800);

    /// <summary>Success 900 - Legsötétebb zöld</summary>
    public static readonly Color Success900 = Color.FromRgb(0x1B, 0x5E, 0x20);
    public static readonly SolidColorBrush Success900Brush = new(Success900);

    // Backward compatibility
    /// <summary>Siker zöld (alias Success500, de custom érték miatt külön)</summary>
    public static readonly Color Success = Color.FromRgb(0x2E, 0xCC, 0x71);
    public static readonly SolidColorBrush SuccessBrush = new(Success);

    /// <summary>Sötét zöld - hover (alias Success700)</summary>
    public static readonly Color SuccessDark = Color.FromRgb(0x27, 0xAE, 0x60);
    public static readonly SolidColorBrush SuccessDarkBrush = new(SuccessDark);

    /// <summary>Még sötétebb - pressed (alias Success800)</summary>
    public static readonly Color SuccessDarker = Color.FromRgb(0x22, 0x99, 0x54);
    public static readonly SolidColorBrush SuccessDarkerBrush = new(SuccessDarker);

    /// <summary>Világos zöld - háttér (alias Success100)</summary>
    public static readonly Color SuccessLight = Success100;
    public static readonly SolidColorBrush SuccessLightBrush = Success100Brush;

    /// <summary>Alternatív zöld (alias Success400)</summary>
    public static readonly Color SuccessAlt = Color.FromRgb(0x5F, 0xA4, 0x6A);
    public static readonly SolidColorBrush SuccessAltBrush = new(SuccessAlt);

    #endregion

    #region Danger Red Scale (Piros Skála - Tailwind-szerű)

    /// <summary>Danger 50 - Legvilágosabb piros</summary>
    public static readonly Color Danger50 = Color.FromRgb(0xFF, 0xEB, 0xEE);
    public static readonly SolidColorBrush Danger50Brush = new(Danger50);

    /// <summary>Danger 100</summary>
    public static readonly Color Danger100 = Color.FromRgb(0xFF, 0xCC, 0xBC);
    public static readonly SolidColorBrush Danger100Brush = new(Danger100);

    /// <summary>Danger 200</summary>
    public static readonly Color Danger200 = Color.FromRgb(0xEF, 0x9A, 0x9A);
    public static readonly SolidColorBrush Danger200Brush = new(Danger200);

    /// <summary>Danger 300</summary>
    public static readonly Color Danger300 = Color.FromRgb(0xE5, 0x73, 0x73);
    public static readonly SolidColorBrush Danger300Brush = new(Danger300);

    /// <summary>Danger 400</summary>
    public static readonly Color Danger400 = Color.FromRgb(0xEF, 0x53, 0x50);
    public static readonly SolidColorBrush Danger400Brush = new(Danger400);

    /// <summary>Danger 500 - Alap piros (normál)</summary>
    public static readonly Color Danger500 = Color.FromRgb(0xF4, 0x43, 0x36);
    public static readonly SolidColorBrush Danger500Brush = new(Danger500);

    /// <summary>Danger 600 - Sötétebb piros (hover)</summary>
    public static readonly Color Danger600 = Color.FromRgb(0xE5, 0x39, 0x35);
    public static readonly SolidColorBrush Danger600Brush = new(Danger600);

    /// <summary>Danger 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Danger700 = Color.FromRgb(0xD3, 0x2F, 0x2F);
    public static readonly SolidColorBrush Danger700Brush = new(Danger700);

    /// <summary>Danger 800</summary>
    public static readonly Color Danger800 = Color.FromRgb(0xC6, 0x28, 0x28);
    public static readonly SolidColorBrush Danger800Brush = new(Danger800);

    /// <summary>Danger 900 - Legsötétebb piros</summary>
    public static readonly Color Danger900 = Color.FromRgb(0xB7, 0x1C, 0x1C);
    public static readonly SolidColorBrush Danger900Brush = new(Danger900);

    // Backward compatibility
    /// <summary>Veszély piros (custom érték)</summary>
    public static readonly Color Danger = Color.FromRgb(0xE7, 0x4C, 0x3C);
    public static readonly SolidColorBrush DangerBrush = new(Danger);

    /// <summary>Sötét piros - hover</summary>
    public static readonly Color DangerDark = Color.FromRgb(0xC0, 0x39, 0x2B);
    public static readonly SolidColorBrush DangerDarkBrush = new(DangerDark);

    /// <summary>Még sötétebb - pressed</summary>
    public static readonly Color DangerDarker = Color.FromRgb(0xA9, 0x32, 0x26);
    public static readonly SolidColorBrush DangerDarkerBrush = new(DangerDarker);

    /// <summary>Világos piros - háttér (alias Danger100)</summary>
    public static readonly Color DangerLight = Danger100;
    public static readonly SolidColorBrush DangerLightBrush = Danger100Brush;

    /// <summary>Alternatív piros (alias Danger500)</summary>
    public static readonly Color DangerAlt = Danger500;
    public static readonly SolidColorBrush DangerAltBrush = Danger500Brush;

    #endregion

    #region Warning Orange Scale (Narancs Skála - Tailwind-szerű)

    /// <summary>Warning 50 - Legvilágosabb narancs</summary>
    public static readonly Color Warning50 = Color.FromRgb(0xFF, 0xF8, 0xE1);
    public static readonly SolidColorBrush Warning50Brush = new(Warning50);

    /// <summary>Warning 100</summary>
    public static readonly Color Warning100 = Color.FromRgb(0xFF, 0xF9, 0xC4);
    public static readonly SolidColorBrush Warning100Brush = new(Warning100);

    /// <summary>Warning 200</summary>
    public static readonly Color Warning200 = Color.FromRgb(0xFF, 0xE0, 0x82);
    public static readonly SolidColorBrush Warning200Brush = new(Warning200);

    /// <summary>Warning 300</summary>
    public static readonly Color Warning300 = Color.FromRgb(0xFF, 0xD5, 0x4F);
    public static readonly SolidColorBrush Warning300Brush = new(Warning300);

    /// <summary>Warning 400</summary>
    public static readonly Color Warning400 = Color.FromRgb(0xFF, 0xCA, 0x28);
    public static readonly SolidColorBrush Warning400Brush = new(Warning400);

    /// <summary>Warning 500 - Alap narancs (normál)</summary>
    public static readonly Color Warning500 = Color.FromRgb(0xFF, 0xC1, 0x07);
    public static readonly SolidColorBrush Warning500Brush = new(Warning500);

    /// <summary>Warning 600 - Sötétebb narancs (hover)</summary>
    public static readonly Color Warning600 = Color.FromRgb(0xFF, 0xB3, 0x00);
    public static readonly SolidColorBrush Warning600Brush = new(Warning600);

    /// <summary>Warning 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Warning700 = Color.FromRgb(0xFF, 0xA0, 0x00);
    public static readonly SolidColorBrush Warning700Brush = new(Warning700);

    /// <summary>Warning 800</summary>
    public static readonly Color Warning800 = Color.FromRgb(0xFF, 0x8F, 0x00);
    public static readonly SolidColorBrush Warning800Brush = new(Warning800);

    /// <summary>Warning 900 - Legsötétebb narancs</summary>
    public static readonly Color Warning900 = Color.FromRgb(0xFF, 0x6F, 0x00);
    public static readonly SolidColorBrush Warning900Brush = new(Warning900);

    // Backward compatibility
    /// <summary>Figyelmeztetés narancs (alias Warning500, de custom)</summary>
    public static readonly Color Warning = Color.FromRgb(0xFF, 0x98, 0x00);
    public static readonly SolidColorBrush WarningBrush = new(Warning);

    /// <summary>Sötét narancs - hover</summary>
    public static readonly Color WarningDark = Color.FromRgb(0xF5, 0x7C, 0x00);
    public static readonly SolidColorBrush WarningDarkBrush = new(WarningDark);

    /// <summary>Még sötétebb - pressed</summary>
    public static readonly Color WarningDarker = Color.FromRgb(0xE6, 0x51, 0x00);
    public static readonly SolidColorBrush WarningDarkerBrush = new(WarningDarker);

    /// <summary>Világos narancs - háttér (alias Warning100)</summary>
    public static readonly Color WarningLight = Warning100;
    public static readonly SolidColorBrush WarningLightBrush = Warning100Brush;

    /// <summary>Alternatív narancs (custom arany)</summary>
    public static readonly Color WarningAlt = Color.FromRgb(0xF3, 0x9C, 0x12);
    public static readonly SolidColorBrush WarningAltBrush = new(WarningAlt);

    #endregion

    #region Info Light Blue Scale (Világoskék Skála - Tailwind-szerű)

    /// <summary>Info 50 - Legvilágosabb kék</summary>
    public static readonly Color Info50 = Color.FromRgb(0xE1, 0xF5, 0xFE);
    public static readonly SolidColorBrush Info50Brush = new(Info50);

    /// <summary>Info 100</summary>
    public static readonly Color Info100 = Color.FromRgb(0xB3, 0xE5, 0xFC);
    public static readonly SolidColorBrush Info100Brush = new(Info100);

    /// <summary>Info 200</summary>
    public static readonly Color Info200 = Color.FromRgb(0x81, 0xD4, 0xFA);
    public static readonly SolidColorBrush Info200Brush = new(Info200);

    /// <summary>Info 300</summary>
    public static readonly Color Info300 = Color.FromRgb(0x4F, 0xC3, 0xF7);
    public static readonly SolidColorBrush Info300Brush = new(Info300);

    /// <summary>Info 400</summary>
    public static readonly Color Info400 = Color.FromRgb(0x29, 0xB6, 0xF6);
    public static readonly SolidColorBrush Info400Brush = new(Info400);

    /// <summary>Info 500 - Alap világoskék (normál)</summary>
    public static readonly Color Info500 = Color.FromRgb(0x03, 0xA9, 0xF4);
    public static readonly SolidColorBrush Info500Brush = new(Info500);

    /// <summary>Info 600 - Sötétebb (hover)</summary>
    public static readonly Color Info600 = Color.FromRgb(0x03, 0x9B, 0xE5);
    public static readonly SolidColorBrush Info600Brush = new(Info600);

    /// <summary>Info 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Info700 = Color.FromRgb(0x02, 0x88, 0xD1);
    public static readonly SolidColorBrush Info700Brush = new(Info700);

    /// <summary>Info 800</summary>
    public static readonly Color Info800 = Color.FromRgb(0x02, 0x77, 0xBD);
    public static readonly SolidColorBrush Info800Brush = new(Info800);

    /// <summary>Info 900 - Legsötétebb</summary>
    public static readonly Color Info900 = Color.FromRgb(0x01, 0x57, 0x9B);
    public static readonly SolidColorBrush Info900Brush = new(Info900);

    // Backward compatibility
    /// <summary>Info kék (custom érték)</summary>
    public static readonly Color Info = Color.FromRgb(0x34, 0x98, 0xDB);
    public static readonly SolidColorBrush InfoBrush = new(Info);

    /// <summary>Sötét info kék - hover</summary>
    public static readonly Color InfoDark = Color.FromRgb(0x29, 0x80, 0xB9);
    public static readonly SolidColorBrush InfoDarkBrush = new(InfoDark);

    /// <summary>Világos info kék - háttér</summary>
    public static readonly Color InfoLight = Color.FromRgb(0x5D, 0xAD, 0xE2);
    public static readonly SolidColorBrush InfoLightBrush = new(InfoLight);

    #endregion

    #region Secondary Amber Scale (Borostyán Skála - Tailwind-szerű)

    /// <summary>Secondary 50 - Legvilágosabb borostyán</summary>
    public static readonly Color Secondary50 = Color.FromRgb(0xFF, 0xFB, 0xEB);
    public static readonly SolidColorBrush Secondary50Brush = new(Secondary50);

    /// <summary>Secondary 100</summary>
    public static readonly Color Secondary100 = Color.FromRgb(0xFE, 0xF3, 0xC7);
    public static readonly SolidColorBrush Secondary100Brush = new(Secondary100);

    /// <summary>Secondary 200</summary>
    public static readonly Color Secondary200 = Color.FromRgb(0xFD, 0xE6, 0x8A);
    public static readonly SolidColorBrush Secondary200Brush = new(Secondary200);

    /// <summary>Secondary 300</summary>
    public static readonly Color Secondary300 = Color.FromRgb(0xFC, 0xD3, 0x4D);
    public static readonly SolidColorBrush Secondary300Brush = new(Secondary300);

    /// <summary>Secondary 400</summary>
    public static readonly Color Secondary400 = Color.FromRgb(0xFB, 0xBF, 0x24);
    public static readonly SolidColorBrush Secondary400Brush = new(Secondary400);

    /// <summary>Secondary 500 - Alap borostyán (normál)</summary>
    public static readonly Color Secondary500 = Color.FromRgb(0xF5, 0x9E, 0x0B);
    public static readonly SolidColorBrush Secondary500Brush = new(Secondary500);

    /// <summary>Secondary 600 - Sötétebb (hover)</summary>
    public static readonly Color Secondary600 = Color.FromRgb(0xD9, 0x77, 0x06);
    public static readonly SolidColorBrush Secondary600Brush = new(Secondary600);

    /// <summary>Secondary 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Secondary700 = Color.FromRgb(0xB4, 0x53, 0x09);
    public static readonly SolidColorBrush Secondary700Brush = new(Secondary700);

    /// <summary>Secondary 800</summary>
    public static readonly Color Secondary800 = Color.FromRgb(0x92, 0x40, 0x0E);
    public static readonly SolidColorBrush Secondary800Brush = new(Secondary800);

    /// <summary>Secondary 900 - Legsötétebb borostyán</summary>
    public static readonly Color Secondary900 = Color.FromRgb(0x78, 0x35, 0x0F);
    public static readonly SolidColorBrush Secondary900Brush = new(Secondary900);

    // Backward compatibility
    /// <summary>Másodlagos borostyán (alias Secondary500)</summary>
    public static readonly Color Secondary = Secondary500;
    public static readonly SolidColorBrush SecondaryBrush = Secondary500Brush;

    /// <summary>Sötét borostyán - hover (alias Secondary700)</summary>
    public static readonly Color SecondaryDark = Secondary700;
    public static readonly SolidColorBrush SecondaryDarkBrush = Secondary700Brush;

    /// <summary>Még sötétebb - pressed (alias Secondary800)</summary>
    public static readonly Color SecondaryDarker = Secondary800;
    public static readonly SolidColorBrush SecondaryDarkerBrush = Secondary800Brush;

    /// <summary>Alternatív borostyán (alias Secondary400)</summary>
    public static readonly Color SecondaryAlt = Secondary400;
    public static readonly SolidColorBrush SecondaryAltBrush = Secondary400Brush;

    #endregion

    #region Tertiary Teal Scale (Türkiz Skála - Tailwind-szerű)

    /// <summary>Tertiary 50 - Legvilágosabb türkiz</summary>
    public static readonly Color Tertiary50 = Color.FromRgb(0xF0, 0xFD, 0xFA);
    public static readonly SolidColorBrush Tertiary50Brush = new(Tertiary50);

    /// <summary>Tertiary 100</summary>
    public static readonly Color Tertiary100 = Color.FromRgb(0xCC, 0xFB, 0xF1);
    public static readonly SolidColorBrush Tertiary100Brush = new(Tertiary100);

    /// <summary>Tertiary 200</summary>
    public static readonly Color Tertiary200 = Color.FromRgb(0x99, 0xF6, 0xE4);
    public static readonly SolidColorBrush Tertiary200Brush = new(Tertiary200);

    /// <summary>Tertiary 300</summary>
    public static readonly Color Tertiary300 = Color.FromRgb(0x5E, 0xEA, 0xD4);
    public static readonly SolidColorBrush Tertiary300Brush = new(Tertiary300);

    /// <summary>Tertiary 400</summary>
    public static readonly Color Tertiary400 = Color.FromRgb(0x2D, 0xD4, 0xBF);
    public static readonly SolidColorBrush Tertiary400Brush = new(Tertiary400);

    /// <summary>Tertiary 500 - Alap türkiz (normál)</summary>
    public static readonly Color Tertiary500 = Color.FromRgb(0x14, 0xB8, 0xA6);
    public static readonly SolidColorBrush Tertiary500Brush = new(Tertiary500);

    /// <summary>Tertiary 600 - Sötétebb (hover)</summary>
    public static readonly Color Tertiary600 = Color.FromRgb(0x0D, 0x94, 0x88);
    public static readonly SolidColorBrush Tertiary600Brush = new(Tertiary600);

    /// <summary>Tertiary 700 - Még sötétebb (pressed)</summary>
    public static readonly Color Tertiary700 = Color.FromRgb(0x0F, 0x76, 0x6E);
    public static readonly SolidColorBrush Tertiary700Brush = new(Tertiary700);

    /// <summary>Tertiary 800</summary>
    public static readonly Color Tertiary800 = Color.FromRgb(0x11, 0x5E, 0x59);
    public static readonly SolidColorBrush Tertiary800Brush = new(Tertiary800);

    /// <summary>Tertiary 900 - Legsötétebb türkiz</summary>
    public static readonly Color Tertiary900 = Color.FromRgb(0x13, 0x4E, 0x4A);
    public static readonly SolidColorBrush Tertiary900Brush = new(Tertiary900);

    // Backward compatibility
    /// <summary>Harmadlagos türkiz (alias Tertiary500)</summary>
    public static readonly Color Tertiary = Tertiary500;
    public static readonly SolidColorBrush TertiaryBrush = Tertiary500Brush;

    /// <summary>Sötét türkiz - hover (alias Tertiary700)</summary>
    public static readonly Color TertiaryDark = Tertiary700;
    public static readonly SolidColorBrush TertiaryDarkBrush = Tertiary700Brush;

    /// <summary>Még sötétebb - pressed (alias Tertiary800)</summary>
    public static readonly Color TertiaryDarker = Tertiary800;
    public static readonly SolidColorBrush TertiaryDarkerBrush = Tertiary800Brush;

    /// <summary>Alternatív türkiz (alias Tertiary400)</summary>
    public static readonly Color TertiaryAlt = Tertiary400;
    public static readonly SolidColorBrush TertiaryAltBrush = Tertiary400Brush;

    #endregion

    #region Neutral Colors (Semleges Színek)

    /// <summary>Fehér</summary>
    public static readonly Color White = Color.FromRgb(0xFF, 0xFF, 0xFF);
    public static readonly SolidColorBrush WhiteBrush = new(White);

    /// <summary>Fekete</summary>
    public static readonly Color Black = Color.FromRgb(0x00, 0x00, 0x00);
    public static readonly SolidColorBrush BlackBrush = new(Black);

    #endregion

    #region Gray Scale (Szürke Skála - Teljes Tailwind tartomány 50-950)

    /// <summary>Gray 50 - Legvilágosabb szürke</summary>
    public static readonly Color Gray50 = Color.FromRgb(0xF9, 0xFA, 0xFB);
    public static readonly SolidColorBrush Gray50Brush = new(Gray50);

    /// <summary>Gray 100 - Nagyon világos szürke - háttér</summary>
    public static readonly Color Gray100 = Color.FromRgb(0xF8, 0xF9, 0xFA);
    public static readonly SolidColorBrush Gray100Brush = new(Gray100);

    /// <summary>Gray 200 - Világos szürke - váltakozó sorok</summary>
    public static readonly Color Gray200 = Color.FromRgb(0xFA, 0xFA, 0xFA);
    public static readonly SolidColorBrush Gray200Brush = new(Gray200);

    /// <summary>Gray 300 - Közepes világos szürke - hover háttér</summary>
    public static readonly Color Gray300 = Color.FromRgb(0xF5, 0xF5, 0xF5);
    public static readonly SolidColorBrush Gray300Brush = new(Gray300);

    /// <summary>Gray 400 - Szürke - border, elválasztó</summary>
    public static readonly Color Gray400 = Color.FromRgb(0xE0, 0xE0, 0xE0);
    public static readonly SolidColorBrush Gray400Brush = new(Gray400);

    /// <summary>Gray 500 - Közepes szürke - vonal</summary>
    public static readonly Color Gray500 = Color.FromRgb(0xBD, 0xBD, 0xBD);
    public static readonly SolidColorBrush Gray500Brush = new(Gray500);

    /// <summary>Gray 600 - Sötét szürke - disabled szöveg</summary>
    public static readonly Color Gray600 = Color.FromRgb(0x95, 0xA5, 0xA6);
    public static readonly SolidColorBrush Gray600Brush = new(Gray600);

    /// <summary>Gray 700 - Még sötétebb szürke - másodlagos szöveg</summary>
    public static readonly Color Gray700 = Color.FromRgb(0x7F, 0x8C, 0x8D);
    public static readonly SolidColorBrush Gray700Brush = new(Gray700);

    /// <summary>Gray 800 - Sötét szöveg - normál szöveg</summary>
    public static readonly Color Gray800 = Color.FromRgb(0x2C, 0x3E, 0x50);
    public static readonly SolidColorBrush Gray800Brush = new(Gray800);

    /// <summary>Gray 900 - Nagyon sötét szürke - fejléc</summary>
    public static readonly Color Gray900 = Color.FromRgb(0x34, 0x49, 0x5E);
    public static readonly SolidColorBrush Gray900Brush = new(Gray900);

    /// <summary>Gray 950 - Legsötétebb szürke</summary>
    public static readonly Color Gray950 = Color.FromRgb(0x1A, 0x24, 0x2F);
    public static readonly SolidColorBrush Gray950Brush = new(Gray950);

    #endregion

    #region Text Colors (Szöveg Színek)

    /// <summary>Elsődleges szöveg - fekete</summary>
    public static readonly Color TextPrimary = Gray800;
    public static readonly SolidColorBrush TextPrimaryBrush = Gray800Brush;

    /// <summary>Másodlagos szöveg - szürke</summary>
    public static readonly Color TextSecondary = Gray700;
    public static readonly SolidColorBrush TextSecondaryBrush = Gray700Brush;

    /// <summary>Disabled szöveg - világos szürke</summary>
    public static readonly Color TextDisabled = Gray600;
    public static readonly SolidColorBrush TextDisabledBrush = Gray600Brush;

    /// <summary>Fehér szöveg - sötét háttéren</summary>
    public static readonly Color TextOnDark = White;
    public static readonly SolidColorBrush TextOnDarkBrush = WhiteBrush;

    #endregion

    #region Background Colors (Háttér Színek)

    /// <summary>Alapértelmezett háttér - nagyon világos szürke</summary>
    public static readonly Color Background = Gray100;
    public static readonly SolidColorBrush BackgroundBrush = Gray100Brush;

    /// <summary>Kártya/panel háttér - fehér</summary>
    public static readonly Color Surface = White;
    public static readonly SolidColorBrush SurfaceBrush = WhiteBrush;

    /// <summary>Váltakozó sor háttér - világos szürke</summary>
    public static readonly Color AlternateRow = Gray200;
    public static readonly SolidColorBrush AlternateRowBrush = Gray200Brush;

    /// <summary>Hover háttér - közepes világos szürke</summary>
    public static readonly Color Hover = Gray300;
    public static readonly SolidColorBrush HoverBrush = Gray300Brush;

    #endregion

    #region Border Colors (Keret Színek)

    /// <summary>Alapértelmezett border - világos szürke</summary>
    public static readonly Color Border = Gray400;
    public static readonly SolidColorBrush BorderBrush = Gray400Brush;

    /// <summary>Sötétebb border - hover</summary>
    public static readonly Color BorderDark = Color.FromRgb(0xC7, 0xD2, 0xE2);
    public static readonly SolidColorBrush BorderDarkBrush = new(BorderDark);

    /// <summary>Még sötétebb border - pressed</summary>
    public static readonly Color BorderDarker = Color.FromRgb(0x9F, 0xB4, 0xD6);
    public static readonly SolidColorBrush BorderDarkerBrush = new(BorderDarker);

    #endregion

    #region Extended Tailwind Color Scales (Kibővített Tailwind Színskálák)

    // Red Scale (Piros)
    public static readonly Color Red50 = Color.FromRgb(0xFE, 0xF2, 0xF2);
    public static readonly SolidColorBrush Red50Brush = new(Red50);
    public static readonly Color Red100 = Color.FromRgb(0xFE, 0xE2, 0xE2);
    public static readonly SolidColorBrush Red100Brush = new(Red100);
    public static readonly Color Red200 = Color.FromRgb(0xFE, 0xCA, 0xCA);
    public static readonly SolidColorBrush Red200Brush = new(Red200);
    public static readonly Color Red300 = Color.FromRgb(0xFC, 0xA5, 0xA5);
    public static readonly SolidColorBrush Red300Brush = new(Red300);
    public static readonly Color Red400 = Color.FromRgb(0xF8, 0x71, 0x71);
    public static readonly SolidColorBrush Red400Brush = new(Red400);
    public static readonly Color Red500 = Color.FromRgb(0xEF, 0x44, 0x44);
    public static readonly SolidColorBrush Red500Brush = new(Red500);
    public static readonly Color Red600 = Color.FromRgb(0xDC, 0x26, 0x26);
    public static readonly SolidColorBrush Red600Brush = new(Red600);
    public static readonly Color Red700 = Color.FromRgb(0xB9, 0x1C, 0x1C);
    public static readonly SolidColorBrush Red700Brush = new(Red700);
    public static readonly Color Red800 = Color.FromRgb(0x99, 0x1B, 0x1B);
    public static readonly SolidColorBrush Red800Brush = new(Red800);
    public static readonly Color Red900 = Color.FromRgb(0x7F, 0x1D, 0x1D);
    public static readonly SolidColorBrush Red900Brush = new(Red900);
    public static readonly Color Red950 = Color.FromRgb(0x45, 0x0A, 0x0A);
    public static readonly SolidColorBrush Red950Brush = new(Red950);

    // Orange Scale (Narancs)
    public static readonly Color Orange50 = Color.FromRgb(0xFF, 0xF7, 0xED);
    public static readonly SolidColorBrush Orange50Brush = new(Orange50);
    public static readonly Color Orange100 = Color.FromRgb(0xFF, 0xED, 0xD5);
    public static readonly SolidColorBrush Orange100Brush = new(Orange100);
    public static readonly Color Orange200 = Color.FromRgb(0xFE, 0xD7, 0xAA);
    public static readonly SolidColorBrush Orange200Brush = new(Orange200);
    public static readonly Color Orange300 = Color.FromRgb(0xFD, 0xBA, 0x74);
    public static readonly SolidColorBrush Orange300Brush = new(Orange300);
    public static readonly Color Orange400 = Color.FromRgb(0xFB, 0x92, 0x3C);
    public static readonly SolidColorBrush Orange400Brush = new(Orange400);
    public static readonly Color Orange500 = Color.FromRgb(0xF9, 0x73, 0x16);
    public static readonly SolidColorBrush Orange500Brush = new(Orange500);
    public static readonly Color Orange600 = Color.FromRgb(0xEA, 0x58, 0x0C);
    public static readonly SolidColorBrush Orange600Brush = new(Orange600);
    public static readonly Color Orange700 = Color.FromRgb(0xC2, 0x41, 0x0C);
    public static readonly SolidColorBrush Orange700Brush = new(Orange700);
    public static readonly Color Orange800 = Color.FromRgb(0x9A, 0x34, 0x12);
    public static readonly SolidColorBrush Orange800Brush = new(Orange800);
    public static readonly Color Orange900 = Color.FromRgb(0x7C, 0x2D, 0x12);
    public static readonly SolidColorBrush Orange900Brush = new(Orange900);
    public static readonly Color Orange950 = Color.FromRgb(0x43, 0x14, 0x07);
    public static readonly SolidColorBrush Orange950Brush = new(Orange950);

    // Amber Scale (Borostyán)
    public static readonly Color Amber50 = Color.FromRgb(0xFF, 0xFB, 0xEB);
    public static readonly SolidColorBrush Amber50Brush = new(Amber50);
    public static readonly Color Amber100 = Color.FromRgb(0xFE, 0xF3, 0xC7);
    public static readonly SolidColorBrush Amber100Brush = new(Amber100);
    public static readonly Color Amber200 = Color.FromRgb(0xFD, 0xE6, 0x8A);
    public static readonly SolidColorBrush Amber200Brush = new(Amber200);
    public static readonly Color Amber300 = Color.FromRgb(0xFC, 0xD3, 0x4D);
    public static readonly SolidColorBrush Amber300Brush = new(Amber300);
    public static readonly Color Amber400 = Color.FromRgb(0xFB, 0xBF, 0x24);
    public static readonly SolidColorBrush Amber400Brush = new(Amber400);
    public static readonly Color Amber500 = Color.FromRgb(0xF5, 0x9E, 0x0B);
    public static readonly SolidColorBrush Amber500Brush = new(Amber500);
    public static readonly Color Amber600 = Color.FromRgb(0xD9, 0x77, 0x06);
    public static readonly SolidColorBrush Amber600Brush = new(Amber600);
    public static readonly Color Amber700 = Color.FromRgb(0xB4, 0x53, 0x09);
    public static readonly SolidColorBrush Amber700Brush = new(Amber700);
    public static readonly Color Amber800 = Color.FromRgb(0x92, 0x40, 0x0E);
    public static readonly SolidColorBrush Amber800Brush = new(Amber800);
    public static readonly Color Amber900 = Color.FromRgb(0x78, 0x35, 0x0F);
    public static readonly SolidColorBrush Amber900Brush = new(Amber900);
    public static readonly Color Amber950 = Color.FromRgb(0x45, 0x1A, 0x03);
    public static readonly SolidColorBrush Amber950Brush = new(Amber950);

    // Yellow Scale (Sárga)
    public static readonly Color Yellow50 = Color.FromRgb(0xFE, 0xFC, 0xE8);
    public static readonly SolidColorBrush Yellow50Brush = new(Yellow50);
    public static readonly Color Yellow100 = Color.FromRgb(0xFE, 0xF9, 0xC3);
    public static readonly SolidColorBrush Yellow100Brush = new(Yellow100);
    public static readonly Color Yellow200 = Color.FromRgb(0xFE, 0xF0, 0x8A);
    public static readonly SolidColorBrush Yellow200Brush = new(Yellow200);
    public static readonly Color Yellow300 = Color.FromRgb(0xFD, 0xE0, 0x47);
    public static readonly SolidColorBrush Yellow300Brush = new(Yellow300);
    public static readonly Color Yellow400 = Color.FromRgb(0xFA, 0xCC, 0x15);
    public static readonly SolidColorBrush Yellow400Brush = new(Yellow400);
    public static readonly Color Yellow500 = Color.FromRgb(0xEA, 0xB3, 0x08);
    public static readonly SolidColorBrush Yellow500Brush = new(Yellow500);
    public static readonly Color Yellow600 = Color.FromRgb(0xCA, 0x8A, 0x04);
    public static readonly SolidColorBrush Yellow600Brush = new(Yellow600);
    public static readonly Color Yellow700 = Color.FromRgb(0xA1, 0x62, 0x07);
    public static readonly SolidColorBrush Yellow700Brush = new(Yellow700);
    public static readonly Color Yellow800 = Color.FromRgb(0x85, 0x4D, 0x0E);
    public static readonly SolidColorBrush Yellow800Brush = new(Yellow800);
    public static readonly Color Yellow900 = Color.FromRgb(0x71, 0x3F, 0x12);
    public static readonly SolidColorBrush Yellow900Brush = new(Yellow900);
    public static readonly Color Yellow950 = Color.FromRgb(0x42, 0x20, 0x06);
    public static readonly SolidColorBrush Yellow950Brush = new(Yellow950);

    // Lime Scale (Limezöld)
    public static readonly Color Lime50 = Color.FromRgb(0xF7, 0xFE, 0xE7);
    public static readonly SolidColorBrush Lime50Brush = new(Lime50);
    public static readonly Color Lime100 = Color.FromRgb(0xEC, 0xFC, 0xCB);
    public static readonly SolidColorBrush Lime100Brush = new(Lime100);
    public static readonly Color Lime200 = Color.FromRgb(0xD9, 0xF9, 0x9D);
    public static readonly SolidColorBrush Lime200Brush = new(Lime200);
    public static readonly Color Lime300 = Color.FromRgb(0xBE, 0xF2, 0x64);
    public static readonly SolidColorBrush Lime300Brush = new(Lime300);
    public static readonly Color Lime400 = Color.FromRgb(0xA3, 0xE6, 0x35);
    public static readonly SolidColorBrush Lime400Brush = new(Lime400);
    public static readonly Color Lime500 = Color.FromRgb(0x84, 0xCC, 0x16);
    public static readonly SolidColorBrush Lime500Brush = new(Lime500);
    public static readonly Color Lime600 = Color.FromRgb(0x65, 0xA3, 0x0D);
    public static readonly SolidColorBrush Lime600Brush = new(Lime600);
    public static readonly Color Lime700 = Color.FromRgb(0x4C, 0x7C, 0x0F);
    public static readonly SolidColorBrush Lime700Brush = new(Lime700);
    public static readonly Color Lime800 = Color.FromRgb(0x3F, 0x62, 0x12);
    public static readonly SolidColorBrush Lime800Brush = new(Lime800);
    public static readonly Color Lime900 = Color.FromRgb(0x36, 0x53, 0x14);
    public static readonly SolidColorBrush Lime900Brush = new(Lime900);
    public static readonly Color Lime950 = Color.FromRgb(0x1A, 0x2E, 0x05);
    public static readonly SolidColorBrush Lime950Brush = new(Lime950);

    // Green Scale (Zöld)
    public static readonly Color Green50 = Color.FromRgb(0xF0, 0xFD, 0xF4);
    public static readonly SolidColorBrush Green50Brush = new(Green50);
    public static readonly Color Green100 = Color.FromRgb(0xDC, 0xFC, 0xE7);
    public static readonly SolidColorBrush Green100Brush = new(Green100);
    public static readonly Color Green200 = Color.FromRgb(0xBB, 0xF7, 0xD0);
    public static readonly SolidColorBrush Green200Brush = new(Green200);
    public static readonly Color Green300 = Color.FromRgb(0x86, 0xEF, 0xAC);
    public static readonly SolidColorBrush Green300Brush = new(Green300);
    public static readonly Color Green400 = Color.FromRgb(0x4A, 0xDE, 0x80);
    public static readonly SolidColorBrush Green400Brush = new(Green400);
    public static readonly Color Green500 = Color.FromRgb(0x22, 0xC5, 0x5E);
    public static readonly SolidColorBrush Green500Brush = new(Green500);
    public static readonly Color Green600 = Color.FromRgb(0x16, 0xA3, 0x4A);
    public static readonly SolidColorBrush Green600Brush = new(Green600);
    public static readonly Color Green700 = Color.FromRgb(0x15, 0x80, 0x3D);
    public static readonly SolidColorBrush Green700Brush = new(Green700);
    public static readonly Color Green800 = Color.FromRgb(0x16, 0x65, 0x34);
    public static readonly SolidColorBrush Green800Brush = new(Green800);
    public static readonly Color Green900 = Color.FromRgb(0x14, 0x53, 0x2D);
    public static readonly SolidColorBrush Green900Brush = new(Green900);
    public static readonly Color Green950 = Color.FromRgb(0x05, 0x2E, 0x16);
    public static readonly SolidColorBrush Green950Brush = new(Green950);

    // Emerald Scale (Smaragdzöld)
    public static readonly Color Emerald50 = Color.FromRgb(0xEC, 0xFD, 0xF5);
    public static readonly SolidColorBrush Emerald50Brush = new(Emerald50);
    public static readonly Color Emerald100 = Color.FromRgb(0xD1, 0xFA, 0xE5);
    public static readonly SolidColorBrush Emerald100Brush = new(Emerald100);
    public static readonly Color Emerald200 = Color.FromRgb(0xA7, 0xF3, 0xD0);
    public static readonly SolidColorBrush Emerald200Brush = new(Emerald200);
    public static readonly Color Emerald300 = Color.FromRgb(0x6E, 0xE7, 0xB7);
    public static readonly SolidColorBrush Emerald300Brush = new(Emerald300);
    public static readonly Color Emerald400 = Color.FromRgb(0x34, 0xD3, 0x99);
    public static readonly SolidColorBrush Emerald400Brush = new(Emerald400);
    public static readonly Color Emerald500 = Color.FromRgb(0x10, 0xB9, 0x81);
    public static readonly SolidColorBrush Emerald500Brush = new(Emerald500);
    public static readonly Color Emerald600 = Color.FromRgb(0x05, 0x9B, 0x69);
    public static readonly SolidColorBrush Emerald600Brush = new(Emerald600);
    public static readonly Color Emerald700 = Color.FromRgb(0x04, 0x7A, 0x57);
    public static readonly SolidColorBrush Emerald700Brush = new(Emerald700);
    public static readonly Color Emerald800 = Color.FromRgb(0x06, 0x5F, 0x46);
    public static readonly SolidColorBrush Emerald800Brush = new(Emerald800);
    public static readonly Color Emerald900 = Color.FromRgb(0x06, 0x4E, 0x3B);
    public static readonly SolidColorBrush Emerald900Brush = new(Emerald900);
    public static readonly Color Emerald950 = Color.FromRgb(0x02, 0x2C, 0x22);
    public static readonly SolidColorBrush Emerald950Brush = new(Emerald950);

    // Teal Scale (Türkiz)
    public static readonly Color Teal50 = Color.FromRgb(0xF0, 0xFD, 0xFA);
    public static readonly SolidColorBrush Teal50Brush = new(Teal50);
    public static readonly Color Teal100 = Color.FromRgb(0xCC, 0xFB, 0xF1);
    public static readonly SolidColorBrush Teal100Brush = new(Teal100);
    public static readonly Color Teal200 = Color.FromRgb(0x99, 0xF6, 0xE4);
    public static readonly SolidColorBrush Teal200Brush = new(Teal200);
    public static readonly Color Teal300 = Color.FromRgb(0x5E, 0xEA, 0xD4);
    public static readonly SolidColorBrush Teal300Brush = new(Teal300);
    public static readonly Color Teal400 = Color.FromRgb(0x2D, 0xD4, 0xBF);
    public static readonly SolidColorBrush Teal400Brush = new(Teal400);
    public static readonly Color Teal500 = Color.FromRgb(0x14, 0xB8, 0xA6);
    public static readonly SolidColorBrush Teal500Brush = new(Teal500);
    public static readonly Color Teal600 = Color.FromRgb(0x0D, 0x94, 0x88);
    public static readonly SolidColorBrush Teal600Brush = new(Teal600);
    public static readonly Color Teal700 = Color.FromRgb(0x0F, 0x76, 0x6E);
    public static readonly SolidColorBrush Teal700Brush = new(Teal700);
    public static readonly Color Teal800 = Color.FromRgb(0x11, 0x5E, 0x59);
    public static readonly SolidColorBrush Teal800Brush = new(Teal800);
    public static readonly Color Teal900 = Color.FromRgb(0x13, 0x4E, 0x4A);
    public static readonly SolidColorBrush Teal900Brush = new(Teal900);
    public static readonly Color Teal950 = Color.FromRgb(0x04, 0x2F, 0x2E);
    public static readonly SolidColorBrush Teal950Brush = new(Teal950);

    // Cyan Scale (Cián)
    public static readonly Color Cyan50 = Color.FromRgb(0xEC, 0xFE, 0xFF);
    public static readonly SolidColorBrush Cyan50Brush = new(Cyan50);
    public static readonly Color Cyan100 = Color.FromRgb(0xCF, 0xFA, 0xFE);
    public static readonly SolidColorBrush Cyan100Brush = new(Cyan100);
    public static readonly Color Cyan200 = Color.FromRgb(0xA5, 0xF3, 0xFC);
    public static readonly SolidColorBrush Cyan200Brush = new(Cyan200);
    public static readonly Color Cyan300 = Color.FromRgb(0x67, 0xE8, 0xF9);
    public static readonly SolidColorBrush Cyan300Brush = new(Cyan300);
    public static readonly Color Cyan400 = Color.FromRgb(0x22, 0xD3, 0xEE);
    public static readonly SolidColorBrush Cyan400Brush = new(Cyan400);
    public static readonly Color Cyan500 = Color.FromRgb(0x06, 0xB6, 0xD4);
    public static readonly SolidColorBrush Cyan500Brush = new(Cyan500);
    public static readonly Color Cyan600 = Color.FromRgb(0x08, 0x91, 0xB2);
    public static readonly SolidColorBrush Cyan600Brush = new(Cyan600);
    public static readonly Color Cyan700 = Color.FromRgb(0x0E, 0x74, 0x90);
    public static readonly SolidColorBrush Cyan700Brush = new(Cyan700);
    public static readonly Color Cyan800 = Color.FromRgb(0x15, 0x5E, 0x75);
    public static readonly SolidColorBrush Cyan800Brush = new(Cyan800);
    public static readonly Color Cyan900 = Color.FromRgb(0x16, 0x4E, 0x63);
    public static readonly SolidColorBrush Cyan900Brush = new(Cyan900);
    public static readonly Color Cyan950 = Color.FromRgb(0x08, 0x33, 0x44);
    public static readonly SolidColorBrush Cyan950Brush = new(Cyan950);

    // Sky Scale (Égkék)
    public static readonly Color Sky50 = Color.FromRgb(0xF0, 0xF9, 0xFF);
    public static readonly SolidColorBrush Sky50Brush = new(Sky50);
    public static readonly Color Sky100 = Color.FromRgb(0xE0, 0xF2, 0xFE);
    public static readonly SolidColorBrush Sky100Brush = new(Sky100);
    public static readonly Color Sky200 = Color.FromRgb(0xBA, 0xE6, 0xFD);
    public static readonly SolidColorBrush Sky200Brush = new(Sky200);
    public static readonly Color Sky300 = Color.FromRgb(0x7D, 0xD3, 0xFC);
    public static readonly SolidColorBrush Sky300Brush = new(Sky300);
    public static readonly Color Sky400 = Color.FromRgb(0x38, 0xBD, 0xF8);
    public static readonly SolidColorBrush Sky400Brush = new(Sky400);
    public static readonly Color Sky500 = Color.FromRgb(0x0E, 0xA5, 0xE9);
    public static readonly SolidColorBrush Sky500Brush = new(Sky500);
    public static readonly Color Sky600 = Color.FromRgb(0x02, 0x84, 0xC7);
    public static readonly SolidColorBrush Sky600Brush = new(Sky600);
    public static readonly Color Sky700 = Color.FromRgb(0x03, 0x69, 0xA1);
    public static readonly SolidColorBrush Sky700Brush = new(Sky700);
    public static readonly Color Sky800 = Color.FromRgb(0x07, 0x59, 0x85);
    public static readonly SolidColorBrush Sky800Brush = new(Sky800);
    public static readonly Color Sky900 = Color.FromRgb(0x0C, 0x4A, 0x6E);
    public static readonly SolidColorBrush Sky900Brush = new(Sky900);
    public static readonly Color Sky950 = Color.FromRgb(0x08, 0x2F, 0x49);
    public static readonly SolidColorBrush Sky950Brush = new(Sky950);

    // Blue Scale (Kék)
    public static readonly Color Blue50 = Color.FromRgb(0xEF, 0xF6, 0xFF);
    public static readonly SolidColorBrush Blue50Brush = new(Blue50);
    public static readonly Color Blue100 = Color.FromRgb(0xDB, 0xEA, 0xFE);
    public static readonly SolidColorBrush Blue100Brush = new(Blue100);
    public static readonly Color Blue200 = Color.FromRgb(0xBF, 0xDB, 0xFE);
    public static readonly SolidColorBrush Blue200Brush = new(Blue200);
    public static readonly Color Blue300 = Color.FromRgb(0x93, 0xC5, 0xFD);
    public static readonly SolidColorBrush Blue300Brush = new(Blue300);
    public static readonly Color Blue400 = Color.FromRgb(0x60, 0xA5, 0xFA);
    public static readonly SolidColorBrush Blue400Brush = new(Blue400);
    public static readonly Color Blue500 = Color.FromRgb(0x3B, 0x82, 0xF6);
    public static readonly SolidColorBrush Blue500Brush = new(Blue500);
    public static readonly Color Blue600 = Color.FromRgb(0x25, 0x63, 0xEB);
    public static readonly SolidColorBrush Blue600Brush = new(Blue600);
    public static readonly Color Blue700 = Color.FromRgb(0x1D, 0x4E, 0xD8);
    public static readonly SolidColorBrush Blue700Brush = new(Blue700);
    public static readonly Color Blue800 = Color.FromRgb(0x1E, 0x40, 0xAF);
    public static readonly SolidColorBrush Blue800Brush = new(Blue800);
    public static readonly Color Blue900 = Color.FromRgb(0x1E, 0x3A, 0x8A);
    public static readonly SolidColorBrush Blue900Brush = new(Blue900);
    public static readonly Color Blue950 = Color.FromRgb(0x17, 0x25, 0x54);
    public static readonly SolidColorBrush Blue950Brush = new(Blue950);

    // Indigo Scale (Indigó)
    public static readonly Color Indigo50 = Color.FromRgb(0xEE, 0xF2, 0xFF);
    public static readonly SolidColorBrush Indigo50Brush = new(Indigo50);
    public static readonly Color Indigo100 = Color.FromRgb(0xE0, 0xE7, 0xFF);
    public static readonly SolidColorBrush Indigo100Brush = new(Indigo100);
    public static readonly Color Indigo200 = Color.FromRgb(0xC7, 0xD2, 0xFE);
    public static readonly SolidColorBrush Indigo200Brush = new(Indigo200);
    public static readonly Color Indigo300 = Color.FromRgb(0xA5, 0xB4, 0xFC);
    public static readonly SolidColorBrush Indigo300Brush = new(Indigo300);
    public static readonly Color Indigo400 = Color.FromRgb(0x81, 0x8C, 0xF8);
    public static readonly SolidColorBrush Indigo400Brush = new(Indigo400);
    public static readonly Color Indigo500 = Color.FromRgb(0x63, 0x66, 0xF1);
    public static readonly SolidColorBrush Indigo500Brush = new(Indigo500);
    public static readonly Color Indigo600 = Color.FromRgb(0x4F, 0x46, 0xE5);
    public static readonly SolidColorBrush Indigo600Brush = new(Indigo600);
    public static readonly Color Indigo700 = Color.FromRgb(0x43, 0x38, 0xCA);
    public static readonly SolidColorBrush Indigo700Brush = new(Indigo700);
    public static readonly Color Indigo800 = Color.FromRgb(0x3A, 0x30, 0xA3);
    public static readonly SolidColorBrush Indigo800Brush = new(Indigo800);
    public static readonly Color Indigo900 = Color.FromRgb(0x31, 0x2E, 0x81);
    public static readonly SolidColorBrush Indigo900Brush = new(Indigo900);
    public static readonly Color Indigo950 = Color.FromRgb(0x1E, 0x1B, 0x4B);
    public static readonly SolidColorBrush Indigo950Brush = new(Indigo950);

    // Violet Scale (Ibolya)
    public static readonly Color Violet50 = Color.FromRgb(0xF5, 0xF3, 0xFF);
    public static readonly SolidColorBrush Violet50Brush = new(Violet50);
    public static readonly Color Violet100 = Color.FromRgb(0xED, 0xE9, 0xFE);
    public static readonly SolidColorBrush Violet100Brush = new(Violet100);
    public static readonly Color Violet200 = Color.FromRgb(0xDD, 0xD6, 0xFE);
    public static readonly SolidColorBrush Violet200Brush = new(Violet200);
    public static readonly Color Violet300 = Color.FromRgb(0xC4, 0xB5, 0xFD);
    public static readonly SolidColorBrush Violet300Brush = new(Violet300);
    public static readonly Color Violet400 = Color.FromRgb(0xA7, 0x8B, 0xFA);
    public static readonly SolidColorBrush Violet400Brush = new(Violet400);
    public static readonly Color Violet500 = Color.FromRgb(0x8B, 0x5C, 0xF6);
    public static readonly SolidColorBrush Violet500Brush = new(Violet500);
    public static readonly Color Violet600 = Color.FromRgb(0x7C, 0x3A, 0xED);
    public static readonly SolidColorBrush Violet600Brush = new(Violet600);
    public static readonly Color Violet700 = Color.FromRgb(0x6D, 0x28, 0xD9);
    public static readonly SolidColorBrush Violet700Brush = new(Violet700);
    public static readonly Color Violet800 = Color.FromRgb(0x5B, 0x21, 0xB6);
    public static readonly SolidColorBrush Violet800Brush = new(Violet800);
    public static readonly Color Violet900 = Color.FromRgb(0x4C, 0x1D, 0x95);
    public static readonly SolidColorBrush Violet900Brush = new(Violet900);
    public static readonly Color Violet950 = Color.FromRgb(0x2E, 0x10, 0x65);
    public static readonly SolidColorBrush Violet950Brush = new(Violet950);

    // Purple Scale (Lila)
    public static readonly Color Purple50 = Color.FromRgb(0xFA, 0xF5, 0xFF);
    public static readonly SolidColorBrush Purple50Brush = new(Purple50);
    public static readonly Color Purple100 = Color.FromRgb(0xF3, 0xE8, 0xFF);
    public static readonly SolidColorBrush Purple100Brush = new(Purple100);
    public static readonly Color Purple200 = Color.FromRgb(0xE9, 0xD5, 0xFF);
    public static readonly SolidColorBrush Purple200Brush = new(Purple200);
    public static readonly Color Purple300 = Color.FromRgb(0xD8, 0xB4, 0xFE);
    public static readonly SolidColorBrush Purple300Brush = new(Purple300);
    public static readonly Color Purple400 = Color.FromRgb(0xC0, 0x84, 0xFC);
    public static readonly SolidColorBrush Purple400Brush = new(Purple400);
    public static readonly Color Purple500 = Color.FromRgb(0xA8, 0x55, 0xF7);
    public static readonly SolidColorBrush Purple500Brush = new(Purple500);
    public static readonly Color Purple600 = Color.FromRgb(0x93, 0x33, 0xEA);
    public static readonly SolidColorBrush Purple600Brush = new(Purple600);
    public static readonly Color Purple700 = Color.FromRgb(0x7E, 0x22, 0xCE);
    public static readonly SolidColorBrush Purple700Brush = new(Purple700);
    public static readonly Color Purple800 = Color.FromRgb(0x6B, 0x21, 0xA8);
    public static readonly SolidColorBrush Purple800Brush = new(Purple800);
    public static readonly Color Purple900 = Color.FromRgb(0x58, 0x1C, 0x87);
    public static readonly SolidColorBrush Purple900Brush = new(Purple900);
    public static readonly Color Purple950 = Color.FromRgb(0x3B, 0x09, 0x64);
    public static readonly SolidColorBrush Purple950Brush = new(Purple950);

    // Fuchsia Scale (Fukszia)
    public static readonly Color Fuchsia50 = Color.FromRgb(0xFD, 0xF4, 0xFF);
    public static readonly SolidColorBrush Fuchsia50Brush = new(Fuchsia50);
    public static readonly Color Fuchsia100 = Color.FromRgb(0xFA, 0xE8, 0xFF);
    public static readonly SolidColorBrush Fuchsia100Brush = new(Fuchsia100);
    public static readonly Color Fuchsia200 = Color.FromRgb(0xF5, 0xD0, 0xFE);
    public static readonly SolidColorBrush Fuchsia200Brush = new(Fuchsia200);
    public static readonly Color Fuchsia300 = Color.FromRgb(0xF0, 0xAB, 0xFC);
    public static readonly SolidColorBrush Fuchsia300Brush = new(Fuchsia300);
    public static readonly Color Fuchsia400 = Color.FromRgb(0xE8, 0x79, 0xF9);
    public static readonly SolidColorBrush Fuchsia400Brush = new(Fuchsia400);
    public static readonly Color Fuchsia500 = Color.FromRgb(0xD9, 0x46, 0xEF);
    public static readonly SolidColorBrush Fuchsia500Brush = new(Fuchsia500);
    public static readonly Color Fuchsia600 = Color.FromRgb(0xC0, 0x26, 0xD3);
    public static readonly SolidColorBrush Fuchsia600Brush = new(Fuchsia600);
    public static readonly Color Fuchsia700 = Color.FromRgb(0xA2, 0x1C, 0xAF);
    public static readonly SolidColorBrush Fuchsia700Brush = new(Fuchsia700);
    public static readonly Color Fuchsia800 = Color.FromRgb(0x86, 0x19, 0x8F);
    public static readonly SolidColorBrush Fuchsia800Brush = new(Fuchsia800);
    public static readonly Color Fuchsia900 = Color.FromRgb(0x70, 0x1A, 0x75);
    public static readonly SolidColorBrush Fuchsia900Brush = new(Fuchsia900);
    public static readonly Color Fuchsia950 = Color.FromRgb(0x4A, 0x04, 0x4E);
    public static readonly SolidColorBrush Fuchsia950Brush = new(Fuchsia950);

    // Pink Scale (Rózsaszín)
    public static readonly Color Pink50 = Color.FromRgb(0xFD, 0xF2, 0xF8);
    public static readonly SolidColorBrush Pink50Brush = new(Pink50);
    public static readonly Color Pink100 = Color.FromRgb(0xFC, 0xE7, 0xF3);
    public static readonly SolidColorBrush Pink100Brush = new(Pink100);
    public static readonly Color Pink200 = Color.FromRgb(0xFB, 0xCF, 0xE8);
    public static readonly SolidColorBrush Pink200Brush = new(Pink200);
    public static readonly Color Pink300 = Color.FromRgb(0xF9, 0xA8, 0xD4);
    public static readonly SolidColorBrush Pink300Brush = new(Pink300);
    public static readonly Color Pink400 = Color.FromRgb(0xF4, 0x72, 0xB6);
    public static readonly SolidColorBrush Pink400Brush = new(Pink400);
    public static readonly Color Pink500 = Color.FromRgb(0xEC, 0x48, 0x99);
    public static readonly SolidColorBrush Pink500Brush = new(Pink500);
    public static readonly Color Pink600 = Color.FromRgb(0xDB, 0x27, 0x77);
    public static readonly SolidColorBrush Pink600Brush = new(Pink600);
    public static readonly Color Pink700 = Color.FromRgb(0xBE, 0x18, 0x5D);
    public static readonly SolidColorBrush Pink700Brush = new(Pink700);
    public static readonly Color Pink800 = Color.FromRgb(0x9D, 0x17, 0x4D);
    public static readonly SolidColorBrush Pink800Brush = new(Pink800);
    public static readonly Color Pink900 = Color.FromRgb(0x83, 0x18, 0x43);
    public static readonly SolidColorBrush Pink900Brush = new(Pink900);
    public static readonly Color Pink950 = Color.FromRgb(0x50, 0x07, 0x24);
    public static readonly SolidColorBrush Pink950Brush = new(Pink950);

    // Rose Scale (Rózsavörös)
    public static readonly Color Rose50 = Color.FromRgb(0xFF, 0xF1, 0xF2);
    public static readonly SolidColorBrush Rose50Brush = new(Rose50);
    public static readonly Color Rose100 = Color.FromRgb(0xFF, 0xE4, 0xE6);
    public static readonly SolidColorBrush Rose100Brush = new(Rose100);
    public static readonly Color Rose200 = Color.FromRgb(0xFE, 0xCD, 0xD3);
    public static readonly SolidColorBrush Rose200Brush = new(Rose200);
    public static readonly Color Rose300 = Color.FromRgb(0xFD, 0xA4, 0xAF);
    public static readonly SolidColorBrush Rose300Brush = new(Rose300);
    public static readonly Color Rose400 = Color.FromRgb(0xFB, 0x71, 0x85);
    public static readonly SolidColorBrush Rose400Brush = new(Rose400);
    public static readonly Color Rose500 = Color.FromRgb(0xF4, 0x3F, 0x5E);
    public static readonly SolidColorBrush Rose500Brush = new(Rose500);
    public static readonly Color Rose600 = Color.FromRgb(0xE1, 0x1D, 0x48);
    public static readonly SolidColorBrush Rose600Brush = new(Rose600);
    public static readonly Color Rose700 = Color.FromRgb(0xBE, 0x12, 0x3C);
    public static readonly SolidColorBrush Rose700Brush = new(Rose700);
    public static readonly Color Rose800 = Color.FromRgb(0x9F, 0x12, 0x39);
    public static readonly SolidColorBrush Rose800Brush = new(Rose800);
    public static readonly Color Rose900 = Color.FromRgb(0x88, 0x13, 0x37);
    public static readonly SolidColorBrush Rose900Brush = new(Rose900);
    public static readonly Color Rose950 = Color.FromRgb(0x4C, 0x06, 0x19);
    public static readonly SolidColorBrush Rose950Brush = new(Rose950);

    // Slate Scale (Palaszürke)
    public static readonly Color Slate50 = Color.FromRgb(0xF8, 0xFA, 0xFC);
    public static readonly SolidColorBrush Slate50Brush = new(Slate50);
    public static readonly Color Slate100 = Color.FromRgb(0xF1, 0xF5, 0xF9);
    public static readonly SolidColorBrush Slate100Brush = new(Slate100);
    public static readonly Color Slate200 = Color.FromRgb(0xE2, 0xE8, 0xF0);
    public static readonly SolidColorBrush Slate200Brush = new(Slate200);
    public static readonly Color Slate300 = Color.FromRgb(0xCB, 0xD5, 0xE1);
    public static readonly SolidColorBrush Slate300Brush = new(Slate300);
    public static readonly Color Slate400 = Color.FromRgb(0x94, 0xA3, 0xB8);
    public static readonly SolidColorBrush Slate400Brush = new(Slate400);
    public static readonly Color Slate500 = Color.FromRgb(0x64, 0x74, 0x8B);
    public static readonly SolidColorBrush Slate500Brush = new(Slate500);
    public static readonly Color Slate600 = Color.FromRgb(0x47, 0x55, 0x69);
    public static readonly SolidColorBrush Slate600Brush = new(Slate600);
    public static readonly Color Slate700 = Color.FromRgb(0x33, 0x41, 0x55);
    public static readonly SolidColorBrush Slate700Brush = new(Slate700);
    public static readonly Color Slate800 = Color.FromRgb(0x1E, 0x29, 0x3B);
    public static readonly SolidColorBrush Slate800Brush = new(Slate800);
    public static readonly Color Slate900 = Color.FromRgb(0x0F, 0x17, 0x2A);
    public static readonly SolidColorBrush Slate900Brush = new(Slate900);
    public static readonly Color Slate950 = Color.FromRgb(0x02, 0x06, 0x17);
    public static readonly SolidColorBrush Slate950Brush = new(Slate950);

    // Zinc Scale (Cinköszürke)
    public static readonly Color Zinc50 = Color.FromRgb(0xFA, 0xFA, 0xFA);
    public static readonly SolidColorBrush Zinc50Brush = new(Zinc50);
    public static readonly Color Zinc100 = Color.FromRgb(0xF4, 0xF4, 0xF5);
    public static readonly SolidColorBrush Zinc100Brush = new(Zinc100);
    public static readonly Color Zinc200 = Color.FromRgb(0xE4, 0xE4, 0xE7);
    public static readonly SolidColorBrush Zinc200Brush = new(Zinc200);
    public static readonly Color Zinc300 = Color.FromRgb(0xD4, 0xD4, 0xD8);
    public static readonly SolidColorBrush Zinc300Brush = new(Zinc300);
    public static readonly Color Zinc400 = Color.FromRgb(0xA1, 0xA1, 0xAA);
    public static readonly SolidColorBrush Zinc400Brush = new(Zinc400);
    public static readonly Color Zinc500 = Color.FromRgb(0x71, 0x71, 0x7A);
    public static readonly SolidColorBrush Zinc500Brush = new(Zinc500);
    public static readonly Color Zinc600 = Color.FromRgb(0x52, 0x52, 0x5B);
    public static readonly SolidColorBrush Zinc600Brush = new(Zinc600);
    public static readonly Color Zinc700 = Color.FromRgb(0x3F, 0x3F, 0x46);
    public static readonly SolidColorBrush Zinc700Brush = new(Zinc700);
    public static readonly Color Zinc800 = Color.FromRgb(0x27, 0x27, 0x2A);
    public static readonly SolidColorBrush Zinc800Brush = new(Zinc800);
    public static readonly Color Zinc900 = Color.FromRgb(0x18, 0x18, 0x1B);
    public static readonly SolidColorBrush Zinc900Brush = new(Zinc900);
    public static readonly Color Zinc950 = Color.FromRgb(0x09, 0x09, 0x0B);
    public static readonly SolidColorBrush Zinc950Brush = new(Zinc950);

    // Neutral Scale (Semleges szürke)
    public static readonly Color Neutral50 = Color.FromRgb(0xFA, 0xFA, 0xFA);
    public static readonly SolidColorBrush Neutral50Brush = new(Neutral50);
    public static readonly Color Neutral100 = Color.FromRgb(0xF5, 0xF5, 0xF5);
    public static readonly SolidColorBrush Neutral100Brush = new(Neutral100);
    public static readonly Color Neutral200 = Color.FromRgb(0xE5, 0xE5, 0xE5);
    public static readonly SolidColorBrush Neutral200Brush = new(Neutral200);
    public static readonly Color Neutral300 = Color.FromRgb(0xD4, 0xD4, 0xD4);
    public static readonly SolidColorBrush Neutral300Brush = new(Neutral300);
    public static readonly Color Neutral400 = Color.FromRgb(0xA3, 0xA3, 0xA3);
    public static readonly SolidColorBrush Neutral400Brush = new(Neutral400);
    public static readonly Color Neutral500 = Color.FromRgb(0x73, 0x73, 0x73);
    public static readonly SolidColorBrush Neutral500Brush = new(Neutral500);
    public static readonly Color Neutral600 = Color.FromRgb(0x52, 0x52, 0x52);
    public static readonly SolidColorBrush Neutral600Brush = new(Neutral600);
    public static readonly Color Neutral700 = Color.FromRgb(0x40, 0x40, 0x40);
    public static readonly SolidColorBrush Neutral700Brush = new(Neutral700);
    public static readonly Color Neutral800 = Color.FromRgb(0x26, 0x26, 0x26);
    public static readonly SolidColorBrush Neutral800Brush = new(Neutral800);
    public static readonly Color Neutral900 = Color.FromRgb(0x17, 0x17, 0x17);
    public static readonly SolidColorBrush Neutral900Brush = new(Neutral900);
    public static readonly Color Neutral950 = Color.FromRgb(0x0A, 0x0A, 0x0A);
    public static readonly SolidColorBrush Neutral950Brush = new(Neutral950);

    // Stone Scale (Kőszürke)
    public static readonly Color Stone50 = Color.FromRgb(0xFA, 0xFA, 0xF9);
    public static readonly SolidColorBrush Stone50Brush = new(Stone50);
    public static readonly Color Stone100 = Color.FromRgb(0xF5, 0xF5, 0xF4);
    public static readonly SolidColorBrush Stone100Brush = new(Stone100);
    public static readonly Color Stone200 = Color.FromRgb(0xE7, 0xE5, 0xE4);
    public static readonly SolidColorBrush Stone200Brush = new(Stone200);
    public static readonly Color Stone300 = Color.FromRgb(0xD6, 0xD3, 0xD1);
    public static readonly SolidColorBrush Stone300Brush = new(Stone300);
    public static readonly Color Stone400 = Color.FromRgb(0xA8, 0xA2, 0x9E);
    public static readonly SolidColorBrush Stone400Brush = new(Stone400);
    public static readonly Color Stone500 = Color.FromRgb(0x78, 0x71, 0x6C);
    public static readonly SolidColorBrush Stone500Brush = new(Stone500);
    public static readonly Color Stone600 = Color.FromRgb(0x57, 0x53, 0x4E);
    public static readonly SolidColorBrush Stone600Brush = new(Stone600);
    public static readonly Color Stone700 = Color.FromRgb(0x44, 0x40, 0x3C);
    public static readonly SolidColorBrush Stone700Brush = new(Stone700);
    public static readonly Color Stone800 = Color.FromRgb(0x29, 0x25, 0x24);
    public static readonly SolidColorBrush Stone800Brush = new(Stone800);
    public static readonly Color Stone900 = Color.FromRgb(0x1C, 0x19, 0x17);
    public static readonly SolidColorBrush Stone900Brush = new(Stone900);
    public static readonly Color Stone950 = Color.FromRgb(0x0C, 0x0A, 0x09);
    public static readonly SolidColorBrush Stone950Brush = new(Stone950);

    // Backward compatibility (régi accent színek)
    /// <summary>Türkiz - speciális (alias Teal500)</summary>
    public static readonly Color Teal = Teal500;
    public static readonly SolidColorBrush TealBrush = Teal500Brush;

    /// <summary>Cián - adatvizualizáció (alias Cyan500)</summary>
    public static readonly Color Cyan = Cyan500;
    public static readonly SolidColorBrush CyanBrush = Cyan500Brush;

    /// <summary>Rózsaszín - kiemelt (alias Pink500)</summary>
    public static readonly Color Pink = Pink500;
    public static readonly SolidColorBrush PinkBrush = Pink500Brush;

    /// <summary>Borostyán - figyelmeztetés alternatíva (alias Amber500)</summary>
    public static readonly Color Amber = Amber500;
    public static readonly SolidColorBrush AmberBrush = Amber500Brush;

    /// <summary>Lime - pozitív változás (alias Lime500)</summary>
    public static readonly Color Lime = Lime500;
    public static readonly SolidColorBrush LimeBrush = Lime500Brush;

    /// <summary>Indigó - adminisztráció (alias Indigo500)</summary>
    public static readonly Color Indigo = Indigo500;
    public static readonly SolidColorBrush IndigoBrush = Indigo500Brush;

    #endregion

    #region Special UI Colors (Speciális UI Színek)

    /// <summary>Kijelölés háttér - világoskék</summary>
    public static readonly Color Selection = PrimaryLight;
    public static readonly SolidColorBrush SelectionBrush = PrimaryLightBrush;

    /// <summary>Focus outline - elsődleges kék</summary>
    public static readonly Color Focus = Primary;
    public static readonly SolidColorBrush FocusBrush = PrimaryBrush;

    /// <summary>Overlay háttér - félig átlátszó fekete</summary>
    public static readonly Color Overlay = Color.FromArgb(0x80, 0x00, 0x00, 0x00);
    public static readonly SolidColorBrush OverlayBrush = new(Overlay);

    /// <summary>Árnyék szín</summary>
    public static readonly Color Shadow = Color.FromArgb(0x26, 0x00, 0x00, 0x00);
    public static readonly SolidColorBrush ShadowBrush = new(Shadow);

    #endregion

    #region Chart Colors (Grafikon Színek)

    /// <summary>Grafikon szín 1 - kék</summary>
    public static readonly Color Chart1 = Primary;
    public static readonly SolidColorBrush Chart1Brush = PrimaryBrush;

    /// <summary>Grafikon szín 2 - zöld</summary>
    public static readonly Color Chart2 = Success;
    public static readonly SolidColorBrush Chart2Brush = SuccessBrush;

    /// <summary>Grafikon szín 3 - narancs</summary>
    public static readonly Color Chart3 = Warning;
    public static readonly SolidColorBrush Chart3Brush = WarningBrush;

    /// <summary>Grafikon szín 4 - piros</summary>
    public static readonly Color Chart4 = Danger;
    public static readonly SolidColorBrush Chart4Brush = DangerBrush;

    /// <summary>Grafikon szín 5 - lila</summary>
    public static readonly Color Chart5 = Secondary;
    public static readonly SolidColorBrush Chart5Brush = SecondaryBrush;

    /// <summary>Grafikon szín 6 - türkiz</summary>
    public static readonly Color Chart6 = Teal;
    public static readonly SolidColorBrush Chart6Brush = TealBrush;

    /// <summary>Grafikon szín 7 - rózsaszín</summary>
    public static readonly Color Chart7 = Pink;
    public static readonly SolidColorBrush Chart7Brush = PinkBrush;

    /// <summary>Grafikon szín 8 - indigó</summary>
    public static readonly Color Chart8 = Indigo;
    public static readonly SolidColorBrush Chart8Brush = IndigoBrush;

    #endregion

    #region Helper Methods (Segéd Metódusok)

    /// <summary>
    /// Létrehoz egy SolidColorBrush-t opacity-vel.
    /// </summary>
    /// <param name="color">Alap szín</param>
    /// <param name="opacity">Átlátszóság (0.0 - 1.0)</param>
    /// <returns>SolidColorBrush a megadott opacity-vel</returns>
    public static SolidColorBrush WithOpacity(Color color, double opacity)
    {
        var brush = new SolidColorBrush(color)
        {
            Opacity = opacity
        };
        brush.Freeze(); // Teljesítmény optimalizálás
        return brush;
    }

    /// <summary>
    /// Létrehoz egy SolidColorBrush-t alpha értékkel.
    /// </summary>
    /// <param name="color">Alap szín</param>
    /// <param name="alpha">Alpha csatorna (0-255)</param>
    /// <returns>SolidColorBrush a megadott alpha értékkel</returns>
    public static SolidColorBrush WithAlpha(Color color, byte alpha)
    {
        var newColor = Color.FromArgb(alpha, color.R, color.G, color.B);
        var brush = new SolidColorBrush(newColor);
        brush.Freeze();
        return brush;
    }

    /// <summary>
    /// Hex string-ből Color létrehozása.
    /// </summary>
    /// <param name="hex">Hex string (#RRGGBB vagy #AARRGGBB formátumban)</param>
    /// <returns>Color objektum</returns>
    public static Color FromHex(string hex)
    {
        return (Color)ColorConverter.ConvertFromString(hex);
    }

    /// <summary>
    /// Hex string-ből SolidColorBrush létrehozása.
    /// </summary>
    /// <param name="hex">Hex string (#RRGGBB vagy #AARRGGBB formátumban)</param>
    /// <returns>SolidColorBrush objektum</returns>
    public static SolidColorBrush BrushFromHex(string hex)
    {
        var brush = new SolidColorBrush(FromHex(hex));
        brush.Freeze();
        return brush;
    }

    #endregion
}

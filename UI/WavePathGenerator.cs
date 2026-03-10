using System;

namespace Dim.WPF.Shared.Library.UI;

/// <summary>
/// Véletlenszerű SVG wave path generátor a TileMenuItemControl header dekorációjához.
/// Hasonló wave mintákat generál, mint a beépített path-ok, de véletlenszerű variációkkal.
/// </summary>
public static class WavePathGenerator
{
    /// <summary>
    /// Generál egy véletlenszerű wave path-ot SVG Path Data formátumban.
    /// </summary>
    /// <param name="width">A path szélessége (alapértelmezett: 1440)</param>
    /// <param name="height">A path magassága (alapértelmezett: 320)</param>
    /// <param name="points">Hány pont legyen a wave-ben (alapértelmezett: 120, minden 12. pixelnél)</param>
    /// <param name="seed">Random seed (opcionális, reprodukálható eredményekhez)</param>
    /// <returns>SVG Path Data string</returns>
    public static string GenerateWavePath(int width = 1440, int height = 320, int points = 120, int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        var step = width / points;
        var pathData = $"M0,{random.Next(height / 2, height)}";
        
        for (int i = 1; i <= points; i++)
        {
            var x = i * step;
            var y = random.Next(0, height);
            
            // Bezier curve control points for smoother waves
            if (i == 1)
            {
                pathData += $"L{x},{y}";
            }
            else
            {
                pathData += $"C{(i - 1) * step + step / 3},{random.Next(0, height)},{x - step / 3},{random.Next(0, height)},{x},{y}";
            }
        }
        
        // Close path to bottom-right, bottom-left, back to start
        pathData += $"L{width},{height}L{width},{height}";
        
        for (int i = points; i >= 0; i--)
        {
            var x = i * step;
            pathData += $"L{x},{height}";
        }
        
        pathData += "Z";
        
        return pathData;
    }

    /// <summary>
    /// Generál egy simább wave path-ot, ami jobban hasonlít az eredeti path-okra.
    /// Kisebb amplitúdójú hullámokat hoz létre.
    /// </summary>
    /// <param name="width">A path szélessége (alapértelmezett: 1440)</param>
    /// <param name="height">A path magassága (alapértelmezett: 320)</param>
    /// <param name="waveCount">Hány teljes hullám legyen (alapértelmezett: 8-16 között)</param>
    /// <param name="amplitude">A hullám amplitúdója (0.0-1.0, alapértelmezett: 0.3)</param>
    /// <param name="seed">Random seed (opcionális)</param>
    /// <returns>SVG Path Data string</returns>
    public static string GenerateSmoothWavePath(
        int width = 1440, 
        int height = 320, 
        int? waveCount = null, 
        double amplitude = 0.3, 
        int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        // Random wave count between 8-16 if not specified
        var waves = waveCount ?? random.Next(8, 17);
        var pointsPerWave = 3; // 3 points per wave (peak, valley, transition)
        var totalPoints = waves * pointsPerWave;
        var step = width / totalPoints;
        
        // Start point at bottom
        var startY = height - random.Next(0, (int)(height * amplitude));
        var pathData = $"M0,{startY}";
        
        // Generate wave points
        for (int i = 1; i <= totalPoints; i++)
        {
            var x = i * step;
            var baseY = height * 0.6; // Center line around 60% height
            var randomAmplitude = random.NextDouble() * amplitude * height;
            
            // Alternate between peaks and valleys with some randomness
            var y = i % 2 == 0 
                ? (int)(baseY - randomAmplitude) // Peak (higher)
                : (int)(baseY + randomAmplitude); // Valley (lower)
            
            // Add some noise to make it more organic
            y += random.Next(-(int)(height * 0.1), (int)(height * 0.1));
            
            // Clamp to valid range
            y = Math.Clamp(y, 0, height);
            
            pathData += $"L{x},{y}";
        }
        
        // Close path
        pathData += $"L{width},{height}L0,{height}Z";
        
        return pathData;
    }

    /// <summary>
    /// Generál egy organikus, természetes wave path-ot Perlin noise-szerű algoritmust használva.
    /// Ez a legreálisabb eredményt adja, hasonló az eredeti path-okhoz.
    /// Lassú, lágy, elnyújtott hullámokat generál.
    /// </summary>
    /// <param name="width">A path szélessége (alapértelmezett: 1440)</param>
    /// <param name="height">A path magassága (alapértelmezett: 320)</param>
    /// <param name="frequency">A hullám gyakorisága (alapértelmezett: 0.0015-0.003 között - LASSÚ)</param>
    /// <param name="amplitude">A hullám amplitúdója (alapértelmezett: 0.15-0.25 között - LÁGY)</param>
    /// <param name="octaves">Noise rétegek száma (alapértelmezett: 1-2 között - SIMÁBB)</param>
    /// <param name="seed">Random seed (opcionális)</param>
    /// <returns>SVG Path Data string</returns>
    public static string GenerateOrganicWavePath(
        int width = 1440,
        int height = 320,
        double? frequency = null,
        double? amplitude = null,
        int? octaves = null,
        int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        // Random parameters if not specified - MUCH SLOWER, GENTLER waves
        var freq = frequency ?? random.NextDouble() * 0.0015 + 0.0015; // 0.0015-0.003 (was 0.005-0.015)
        var amp = amplitude ?? random.NextDouble() * 0.10 + 0.15;      // 0.15-0.25 (was 0.2-0.4)
        var oct = octaves ?? random.Next(1, 3);                        // 1-2 (was 2-4)
        
        var step = 24; // 24 pixels per point (was 12) - fewer points = smoother
        var points = width / step;
        
        // Generate noise values for smooth wave
        var noiseValues = new double[points + 1];
        for (int i = 0; i <= points; i++)
        {
            noiseValues[i] = GenerateNoise(i * freq, oct, random);
        }
        
        // Start point
        var startY = (int)(height * 0.6 + noiseValues[0] * amp * height);
        startY = Math.Clamp(startY, 0, height);
        var pathData = $"M0,{startY}";
        
        // Generate wave points
        for (int i = 1; i <= points; i++)
        {
            var x = i * step;
            var noiseValue = noiseValues[i];
            var y = (int)(height * 0.6 + noiseValue * amp * height);
            
            // Add slight random variation (reduced)
            y += random.Next(-(int)(height * 0.02), (int)(height * 0.02)); // 2% (was 5%)
            
            // Clamp to valid range
            y = Math.Clamp(y, 0, height);
            
            pathData += $"L{x},{y}";
        }
        
        // Close path
        pathData += $"L{width},{height}L0,{height}Z";
        
        return pathData;
    }

    /// <summary>
    /// Egyszerű multi-octave noise generátor (Perlin noise-szerű).
    /// </summary>
    private static double GenerateNoise(double x, int octaves, Random random)
    {
        double value = 0;
        double amplitude = 1;
        double frequency = 1;
        double maxValue = 0;
        
        for (int i = 0; i < octaves; i++)
        {
            // Simple sine-based noise
            var offset = random.NextDouble() * 1000;
            value += Math.Sin((x + offset) * frequency) * amplitude;
            
            maxValue += amplitude;
            amplitude *= 0.5;
            frequency *= 2;
        }
        
        // Normalize to -1 to 1 range
        return value / maxValue;
    }

    /// <summary>
    /// Generál 4 különböző wave path-ot egy TileMenuItemControl-hoz.
    /// Ezek egymásra rétegezve hozzák létre a komplex wave mintát.
    /// Lágy, lassú, elnyújtott hullámok.
    /// </summary>
    /// <param name="seed">Random seed (opcionális, reprodukálható eredményekhez)</param>
    /// <returns>Tuple 4 path data string-gel</returns>
    public static (string path1, string path2, string path3, string path4) GenerateFourWavePaths(int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        // Generate 4 different wave paths with SLOW, GENTLE characteristics
        var path1 = GenerateOrganicWavePath(
            frequency: random.NextDouble() * 0.0010 + 0.0015, // 0.0015-0.0025 (very slow)
            amplitude: random.NextDouble() * 0.08 + 0.12,      // 0.12-0.20 (gentle)
            octaves: 1,                                        // single octave (smooth)
            seed: random.Next());
        
        var path2 = GenerateOrganicWavePath(
            frequency: random.NextDouble() * 0.0012 + 0.0018, // 0.0018-0.0030 (very slow)
            amplitude: random.NextDouble() * 0.09 + 0.14,      // 0.14-0.23 (gentle)
            octaves: 1,                                        // single octave (smooth)
            seed: random.Next());
        
        var path3 = GenerateOrganicWavePath(
            frequency: random.NextDouble() * 0.0015 + 0.0020, // 0.0020-0.0035 (slow)
            amplitude: random.NextDouble() * 0.10 + 0.16,      // 0.16-0.26 (gentle)
            octaves: 2,                                        // two octaves (bit more detail)
            seed: random.Next());
        
        var path4 = GenerateOrganicWavePath(
            frequency: random.NextDouble() * 0.0008 + 0.0016, // 0.0016-0.0024 (very slow)
            amplitude: random.NextDouble() * 0.07 + 0.13,      // 0.13-0.20 (gentle)
            octaves: 1,                                        // single octave (smooth)
            seed: random.Next());
        
        return (path1, path2, path3, path4);
    }

    /// <summary>
    /// Generál véletlenszerű opacity értékeket 4 wave path-hoz (0.05-0.25 között).
    /// </summary>
    /// <param name="seed">Random seed (opcionális)</param>
    /// <returns>Tuple 4 opacity értékkel</returns>
    public static (double opacity1, double opacity2, double opacity3, double opacity4) GenerateRandomOpacities(int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        return (
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20
        );
    }
}

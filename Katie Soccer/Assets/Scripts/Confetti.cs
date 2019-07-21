using UnityEngine;

public class Confetti : MonoBehaviour
{
    public ParticleSystem ConfettiSystem;

    private Gradient SetColorGradient(Color teamColor)
    {
        Gradient gradient = new Gradient();
        gradient.mode = GradientMode.Fixed;

        GradientColorKey[] colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(Color.white, 0.333f),
            new GradientColorKey(Color.grey, 0.666f),
            new GradientColorKey(teamColor, 1f)
        };

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(1f, 0f),
            new GradientAlphaKey(1f, 1f)
        };

        gradient.SetKeys(colorKeys, alphaKeys);
        return gradient;
    }

    public void Play(Color teamColor)
    {
        var gradient = new ParticleSystem.MinMaxGradient(SetColorGradient(teamColor))
        {
            mode = ParticleSystemGradientMode.RandomColor
        };
        var main = ConfettiSystem.main;
        main.startColor = gradient;
        ConfettiSystem.Play();
    }

    public void Stop()
    {
        ConfettiSystem.Stop();
    }
}

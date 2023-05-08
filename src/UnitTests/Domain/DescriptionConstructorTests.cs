using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Domain;

public class DescriptionConstructorTests
{
    [Fact]
    public void EmptyString_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new Description(""));
    }

    [Fact]
    public void ShortString_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new Description("Short"));
    }

    [Fact]
    public void NormalDescription_SuccessfullyCreateInstance()
    {
        var result = new Description("Very normal description");
    }

    [Fact]
    public void LongDescription_ThrowException()
    {
        string longString = "The moon is made of cheese, a fact that I'm sure of, although I prefer the sweetness of " +
                            "strawberries. Elephants, on their Sundays, put on tutus and delight the world with their " +
                            "violin-playing skills. The grass sways gently in the wind, singing songs to the sky, while " +
                            "the clouds gracefully dance to the beat. My pencil is a tree, standing tall and proud, and " +
                            "my eraser is a bird, soaring through the air. Yesterday, I dove into a sea of chocolate, " +
                            "swimming with all my might, until I found a mermaid with wings, a magical creature beyond " +
                            "compare. The sun dons a stylish hat, while the stars ride bicycles across the universe. I " +
                            "communicate with my feet, expressing myself through every step, and walk with my mouth " +
                            "closed, lost in my own thoughts. The ocean is a vast and endless desert, while the desert " +
                            "itself is a vibrant and lush jungle. My thoughts are as light as feathers, floating " +
                            "aimlessly through my mind, and my dreams are vivid and colorful, made of pure, radiant rainbows.";
        Assert.Throws<DomainValidationException>(() => new Description(longString));
    }
}
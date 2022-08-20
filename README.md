# Ancient Numerals

## Introduction

This project is an example of the use of Proterty Based Tests with .NET. The challenge here is to build a class that can parse and generate numbers in the Cistercian system.

![Cistercian numerals](https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Cistercian_digits_%28vertical%29.svg/754px-Cistercian_digits_%28vertical%29.svg.png)

> The medieval Cistercian numerals, or "ciphers" in nineteenth-century parlance, were developed by the Cistercian monastic order in the early thirteenth century at about the time that Arabic numerals were introduced to northwestern Europe. They are more compact than Arabic or Roman numerals, with a single glyph able to indicate any integer from 1 to 9,999. - [Wikipedia](https://en.wikipedia.org/wiki/Cistercian_numerals)

The output of this class is just a string representing the Cistercian notation, for example, below is the representation for **5555**.

````
.----.----.
 \   |   / 
  \  |  /  
   \ | /   
    \|/    
     |     
.    |    .
     |     
    /|\    
   / | \   
  /  |  \ 
 /   |   \ 
.----.----.
````
## Property-based test usage

[FsCheck](https://fscheck.github.io/FsCheck/) library is used here to validade the following property of the system:

*Every number that is transformed to a textual representation can be parse back to its original value.*

So, given the previous example, after we get the textual representation for 5555, this text can be parsed back to 5555. This test can be found [here](https://github.com/fabiogouw/AncientNumerals/blob/ad50bb47e4fab8482e22812ae15dbd13bf536447/src/AncientNumerals.Tests/CistercianTests.cs#L45).

## Cistercian class usage

The basic usage of the Cistercian class is the following

````csharp
var cistercian = new Cistercian(1);
cistercian.ToString();  // this will output the ASCII representation

var stringOne = 
@".    .----.
      |     
      |     
      |     
      |     
      |     
 .    |    .
      |     
      |     
      |     
      |     
      |     
 .    .    .";
var one = Cistercian.Parse(stringOne);
one.Value; // this will return 1
````

## References

* [Property-Based Testing with C#](https://www.codit.eu/blog/property-based-testing-with-c/)
* [Input generators in property-based tests with FsCheck](https://blog.miguelbernard.com/input-generators-in-property-based-tests-with-fscheck)
* [Understanding FsCheck](https://fsharpforfunandprofit.com/posts/property-based-testing-1/)
* [Choosing properties for property-based testing](https://fsharpforfunandprofit.com/posts/property-based-testing-2/) - this one is pretty interesting because it categorizes 7 patterns that can be used to write properties to the system (I think the most challeging part ot property-based testing is to figure out the right properties).
* [FsCheck.Xunit.PropertyFailedException when "Arguments exhausted after 99 tests.](https://github.com/fscheck/FsCheck/issues/245) - the shortest and the best explanation of the "arguments exhausted" error


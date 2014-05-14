module SetsAndFunctions

open NUnit.Framework



[<TestFixture>]
type SetsAndFunctionsFixture() = class
    
        [<Test>]
        member this.SetsOfAllEvenNumbers() =
            let rec evenNumbers() = seq { 
                                        yield 0
                                        for n in evenNumbers() do yield n+2
                                      }
            
            let evenNumbersFrom0To10 = Seq.take 10 (evenNumbers())
            Assert.That(evenNumbersFrom0To10, Has.No.Member 1)
            Assert.That(evenNumbersFrom0To10, Has.Member 2)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 3)
            Assert.That(evenNumbersFrom0To10, Has.Member 4)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 5)
            Assert.That(evenNumbersFrom0To10, Has.Member 6)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 7)
end


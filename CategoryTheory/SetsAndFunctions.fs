module SetsAndFunctions

open NUnit.Framework

 // Sets and Functions

let SetOfNumbers = Seq.initInfinite(fun i->i)
 
let rec SetOfEvenNumbers = seq {  
                                    for n in SetOfNumbers do
                                        let candidateNumbers = Seq.takeWhile(fun m->m<=n/2) SetOfNumbers
                                        if Seq.exists(fun m->2*m=n) candidateNumbers then yield n     
                                 }
                             
let SetOfOddNumbers = seq {
                             for n in SetOfNumbers do
                                 let evenNumbers = Seq.takeWhile(fun m->m<=n) SetOfEvenNumbers
                                 if not (Seq.exists(fun m->m = n) evenNumbers) then yield n     
                          }

// Tests
[<TestFixture>]
type SetsAndFunctionsFixture() = class
    
        [<Test>]
        member this.SetOfAllEvenNumbers() =
            let evenNumbersFrom0To10 = Seq.take 10 SetOfEvenNumbers
            Assert.That(evenNumbersFrom0To10, Has.No.Member 1)
            Assert.That(evenNumbersFrom0To10, Has.Member 2)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 3)
            Assert.That(evenNumbersFrom0To10, Has.Member 4)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 5)
            Assert.That(evenNumbersFrom0To10, Has.Member 6)
            Assert.That(evenNumbersFrom0To10, Has.No.Member 7)

        [<Test>]
        member this.SetOfOddNumbers() = 
            let oddNumbersFrom0To10 = Seq.take 10 SetOfOddNumbers
            Assert.That(oddNumbersFrom0To10, Has.Member 1)
            Assert.That(oddNumbersFrom0To10, Has.No.Member 2)
            Assert.That(oddNumbersFrom0To10, Has.Member 3)
            Assert.That(oddNumbersFrom0To10, Has.No.Member 4)
            Assert.That(oddNumbersFrom0To10, Has.Member 5)
            Assert.That(oddNumbersFrom0To10, Has.No.Member 6)
            Assert.That(oddNumbersFrom0To10, Has.Member 7)
end


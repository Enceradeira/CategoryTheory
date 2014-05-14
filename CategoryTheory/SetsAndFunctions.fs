module SetsAndFunctions

open NUnit.Framework


[<TestFixture>]
type SetsAndFunctionsFixture() = class
    
        [<Test>]
        [<TestCaseSource("TestCasesForAdd")>]
        member this.SetsOfAllEvenNumbers() =
            Assert.That(0, Is.EqualTo 1)


end


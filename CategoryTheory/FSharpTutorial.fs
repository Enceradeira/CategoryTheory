module FSharpTutorial

open System
open NUnit.Framework

// Functions
let add (x:int,y) = x+y

let ifThenElse(c,a,b) = 
    if c then a else b

let swapElements (a,b) = (b,a)

let listOfDays(year) = 
    [ for month in 1 .. 12 do
        for day in 1 .. DateTime.DaysInMonth(year,month) do
            yield System.DateTime(year,month,day) ]

let squares(list) = 
    list
    |> Seq.map(fun i->i*i)
    

// Classes
type ISalaryRepository = 
    abstract GetSalary : unit -> float

type UnemployedSalaryRepo() =  
    interface ISalaryRepository with
        member this.GetSalary() = 0.0

type ManagerSalaryRepo() =  
    interface ISalaryRepository with
        member this.GetSalary() = 250.25

type Person<'T 
        when 'T : (new : unit -> 'T) 
        and 'T :> ISalaryRepository>
        (firstName, surname) =
    member private this.FirstName = firstName
    member private this.Surname = surname

    member this.Name = sprintf "%s %s" this.FirstName this.Surname
    member this.Salary() = (new 'T()).GetSalary()
    
        

// Tests
// Tests
[<TestFixture>]
type FSharpTutorialFixture() = class
        [<Test>]
        member this.person() =
            let jj = Person<UnemployedSalaryRepo>("Jorg", "Jenni")
            Assert.That(jj.Name, Is.EqualTo "Jorg Jenni")

        [<Test>]
        member this.personSalary() = 
            let jj = Person<ManagerSalaryRepo>("Jorg", "Jenni")
            Assert.That(jj.Salary, Is.EqualTo 250.25)

        [<Test>]
        member this.add() =
            Assert.That(add(2, 4), Is.EqualTo 6)

        [<Test>]
        member this.ifThenElse() = 
            Assert.That(ifThenElse(1=1,true,false), Is.True)
            Assert.That(ifThenElse(1=2,"True","False"), Is.EqualTo "False")

        [<Test>]
        member this.printfn() =
            printfn "Hello"

        [<Test>]
        member this.swapElements() = 
            Assert.That(swapElements((1,"Hello")), Is.EqualTo ("Hello",1))

        [<Test>]
        member this.concatLists() = 
            Assert.That( 4 :: [1;2], Is.EqualTo [4;1;2])

        [<Test>]
        member this.listOfDays() = 
            let days = listOfDays(1974)
            Assert.That(days, Has.Member(DateTime(1974,3,25)))
            Assert.That(days, Has.No.Member(DateTime(2014,5,15)))
        
        [<Test>]
        member this.squares() = 
            Assert.That(squares([1;3]), Is.EqualTo [1;9])
end

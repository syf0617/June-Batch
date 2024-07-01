# Understanding Data Types
1. 
What type would you choose for the following “numbers”? 
- A person’s telephone number 
> string
- A person’s height
> decimal
- A person’s age
> uint
- A person’s gender (Male, Female, Prefer Not To Answer)
> string
- A person’s salary
> decimal
- A book’s ISBN
> string
- A book’s price
> decimal
- A book’s shipping weight
> decimal
- A country’s population
> ulong
- The number of stars in the universe
> ulong
- The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business)
> uint
2. What are the difference between value type and reference type variables? What is boxing and unboxing?

> Value vs Reference Type
> - Value type will directly hold the value while reference type will hold the memeory address or reference for the value
> - Value type is stored in stack memeory and referency type is stored in heap memory
> - Value type will not be collected by garbage collector (managed by runtime environment) but reference type will be collected by garbage collector
> - Value type can be created by struct or enum while reference type can be created by class, interface, delegate or array
> - Value type can not accept any null values while reference type can accept null values

> Boxing vs Unboxing
> - Boxing is conversion of value type to reference type
> - Unboxing is conversion of reference type to value type

3. What is meant by the terms managed resource and unmanaged resource in .NET
> Managed Resource: value/reference types, garbage collector
> Unmanaged Resource: database connection, file transimission

4. Whats the purpose of Garbage Collector in .NET?
> in managed heap memory; is divided into three generations: 0,1,2

# Controlling Flow and Converting Types
1. What happens when you divide an int variable by 0?
> Compiler Error: Arithemtic problem in constant value
2. What happens when you divide a double variable by 0?
> Infinity mark
3. What happens when you overflow an int variable, that is, set it to a value beyond its range?
> Compiler Error: Intergral constant is too large
4. What is the difference between x = y++; and x = ++y;? 
> x = y; y increment by 1
> y increment by 1 first; x = y
5. What is the difference between break, continue, and return when used inside a loop statement? 
> break: break curremnt loop
> continue: skip current loop
> return: exit the whole program

6. What are the three parts of a for statement and which of them are required? 
> Intialization
> limitation: required
> Step size

7. What is the difference between the = and == operators? 
> =: assign
> ==: equal to comparator

8. Does the following statement compile? for ( ; true; ) ; 
> Compiles. Infinity loop

9. What does the underscore _ represent in a switch expression? 
> Default case

10. What interface must an object implement to be enumerated over by using the foreach statement?
> IEnumreable

# Arrays and Strings
1. When to use String vs. StringBuilder in C# ?
> String: for concantaction
> StringBuilder: for sting input and process

2. What is the base class for all arrays in C#?
> Object

3. How do you sort an array in C#?
> Array.Sort(array)

4. What property of an array object can be used to get the total number of elements in an array?
> array.Length

5. Can you store multiple data types in System.Array?
> No

6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
> The Clone() method returns a new array (a shallow copy) object containing all the elements in the original array
> The CopyTo() method copies the elements into another existing array
> Both perform a shallow copy

# OOP
1. What are the six combinations of access modifier keywords and what do they do?
> Public: members can be accessed anywhere
> Private: members can be accessed only in a current class
> Protected: members can be accessed in current class and children classes
> Internal: members can be accessed in the current assembly (assembly is a compiled unit of executable code. When project compiles, it turns into an assembly which will in turn become a .dll file or .exe file)
> Private:
> File:

2. What is the difference between the static, const, and readonly keywords when applied to a type member?
> static: When a member is declared static, it can be accessed with the name of its class directly
> const: For the const keyword, the value must be known by compile time; static by default
> readonly: For the readonly keyword, the latest value is known by the runtime; not implictly static

3. What does a constructor do?
> Is used to create an object of the class and initialize the class member

4. Why is the partial keyword useful?
> This keyword is also useful to split the functionality of methods, interfaces, or structure into multiple files

5. What is a tuple?
> A tuple is a collection which is ordered and unchangeable. Tuples are written with round brackets
> The tuples feature provides concise syntax to group multiple data elements in a lightweight data structure.
> Value type

6. What does the C# record keyword do?
> A record in C# is a class or struct that provides special syntax and behavior for working with data models.
> The record modifier instructs the compiler to synthesize members that are useful for types whose primary role is storing data.

7. What does overloading and overriding mean?
> Method Overriding: happens between base class and derived class, we have the same method signature including the access modifier, method name, and input/output parameters; and we will give different implementation for the same method
> Method Overloading: happens in the same class; they have the same method name, access modifiers but they may have different input/output parameters

8. What is the difference between a field and a property?
> field: a variable (that can be of any type) that is defined inside a class. It can be used to define the characteristics of an object or a class
> property: is a member of the class that provides an abstraction to set (write) and get (read) the value of a private field

9. How do you make a method parameter optional?
> By using the parameter arrays (using the params keyword)

10. What is an interface and how is it different from abstract class?
> Abstract class will provide base class to its subclasses; is a wise choice when we have class hierarchy
> Interface will define common functionalities and behaviors that can be implemented by any class
> Once class can only inherit from one abstract or concrete class but one class can implement multiple interfaces
> Methods in abstract class can be abstract method or non-abstract method but methods in an interface is by default public and abstract

11. What accessibility level are members of an interface?
> public

12. True/False. Polymorphism allows derived classes to provide different implementations
of the same method.
> True

13. True/False. The override keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
> True

14. True/False. The new keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
> False

15. True/False. Abstract methods can be used in a normal (non-abstract) class.
> False

16. True/False. Normal (non-abstract) methods can be used in an abstract class.
> True

17. True/False. Derived classes can override methods that were virtual in the base class.
> True

18. True/False. Derived classes can override methods that were abstract in the base class.
> True

19. True/False. In a derived class, you can override a method that was neither virtual non abstract in the base class.
> True

20. True/False. A class that implements an interface does not have to provide an implementation for all of the members of the interface.
> True

21. True/False. A class that implements an interface is allowed to have other members that aren’t defined in the interface.
> False

22. True/False. A class can have more than one base class.
> False

23. True/False. A class can implement more than one interface.
> True

# Generics
Describe the problem generics address.
1. How would you create a list of strings, using the generic List class?
> List<string> lstOfStrings = new List<string>

2. How many generic type parameters does the Dictionary class have?
> Two types: key, value

3. True/False. When a generic class has multiple type parameters, they must all match.
> True

4. What method is used to add items to a List object?
> Insert(int index, T item)

5. Name two methods that cause items to be removed from a List.
> Remove(), Clear()

6. How do you indicate that a class has a generic type parameter?
> Class<T> ();

7. True/False. Generic classes can only have one generic type parameter.
> True

8. True/False. Generic type constraints limit what can be used for the generic type.
> False

9. True/False. Constraints let you use the methods of the thing you are constraining to.
> True

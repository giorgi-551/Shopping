Reflection on Encapsulation, Abstraction & Polymorphism Across Python, C#, and TypeScript

Encapsulation

Python:

Used private attribute __products inside ShoppingCart.
Python does not enforce true privacy but uses name-mangling to discourage access.
Provided get_products() to offer read-only access.
C#:

Strongest encapsulation of the three.
Used private List<Product> _products.
C# explicitly enforces access modifiers.
Provided IReadOnlyList<Product> to give safe external access.
Encapsulation feels most natural and strict in C#.
TypeScript:

Used private products: Product[].
TypeScript privacy is enforced at compile time, not runtime.
Provided getProducts(): ReadonlyArray<Product> to prevent modification.
Encapsulation is strict when using TypeScript, but JavaScript output cannot enforce real privacy (unless using #private fields).
Abstraction

Python:

Implemented using abc.ABC and @abstractmethod.
Abstract classes require developers to implement abstract methods.
C#:

Uses abstract class and abstract methods (classic OOP style).
Most robust and strict implementation of abstraction.
TypeScript:

Also supports abstract class and abstract methods.
Abstraction is enforced only at compile time, not runtime.
Polymorphism

All three languages use method overriding:

finalPrice() → computed differently in FoodProduct and ElectronicProduct.
A list/array of products is iterated, and the correct method runs depending on the object type.
Differences:

Python: Dynamic typing makes polymorphism very flexible.
C#: Strict typing; polymorphism is classic and enforced strongly.
TypeScript: Structural typing allows flexible polymorphism but is checked only during compilation.
Observed Differences Between Languages

Typing: Python uses dynamic typing, C# uses strong static typing, and TypeScript uses static typing (compile-time only).
Encapsulation Strength: Python has the weakest encapsulation, C# has the strongest, and TypeScript is in the middle (compiles to JavaScript).
Abstract Classes: Python requires the abc module, C# has built-in strict support, and TypeScript has built-in support that is enforced at compile-time.
Polymorphism Style: Python uses duck typing, C# follows classical OOP, and TypeScript employs structural typing.
Runtime Behavior: Python is interpreted, C# is compiled, and TypeScript compiles to JavaScript.
Privacy: Python relies on conventions only, C# ensures true enforcement, and TypeScript provides compile-time privacy only.

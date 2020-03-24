Hello, Gaurav!
I am translating this book to Russian. Could you tell me something about an fragment below:

_What this means is, when the service is requested, a string will be supplied to determine the
specific type. Because the dependency changed, this means the
CatalogService constructor requires updating:_

```csharp
public CatalogService(IUserInterface userInterface, Func<string,
InventoryCommand> commandFactory)
{
_userInterface = userInterface;
_commandFactory = commandFactory;
}
```

_When the service is requested, a string will be supplied to determine the specific. Because
the dependency changed, the CatalogueService constructor requires updating:_

`/* Here you can see an empty space after the colon above. You can find it on pages 146-147 */`

_Now when the string the user has entered is supplied to the CommandFactory dependency,
the correct command is supplied:_

I saw the code in the chapter and I think it is the typo. But I do not sure. Thanks for your time!

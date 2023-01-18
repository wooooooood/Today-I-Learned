## Move to next Entry if `Enter key` pressed
⚡ Event: `Completed`  

**Ex1.** Move to Next Entry's End of the text
```cs
NameEntry.Completed += (sender, e) =>
{
    NameEntry.Unfocus();
    EmailEntry.Focus();
    EmailEntry.CursorPosition = EmailEntry.Text.Length;
};
EmailEntry.Completed += (sender, e) =>
{
    EmailEntry.Unfocus();
    PasswordEntry.Focus();
    PasswordEntry.CursorPosition = PasswordEntry.Text.Length;
};
```

**Ex2.** 단순 focus이며 이 경우 **Cursor position은 0**
```cs
NameEntry.Completed += (sender, e) =>
{
    NameEntry.Unfocus();
    EmailEntry.Focus();
};
EmailEntry.Completed += (sender, e) =>
{
    EmailEntry.Unfocus();
    PasswordEntry.Focus();
};
```

**Ex3.** 최종 융합
```cs
NameEntry.Completed += (sender, e) =>
{
    EmailEntry.Focus();
    EmailEntry.CursorPosition = EmailEntry.Text.Length;
};
EmailEntry.Completed += (sender, e) =>
{
    PasswordEntry.Focus();
    PasswordEntry.CursorPosition = PasswordEntry.Text.Length;
};
```

**Caution.** 이렇게 단독작성하는 경우 어느 Entry도 focus되지 않는다. (= keyboard 안뜬다)
```cs
NameEntry.Completed += (sender, e) => EmailEntry.CursorPosition = PasswordEntry.Text.Length;
EmailEntry.Completed += (sender, e) => PasswordEntry.CursorPosition = PasswordEntry.Text.Length;
```

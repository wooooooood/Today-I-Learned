# Access Modifier

### Public  
Can be accessed by any other code in the same assembly or another assembly that references it.  
![alt text](https://i.stack.imgur.com/VGgjh.png "public")

### Private
Can only be accessed by code in the **same class or struct**.
![alt text](https://i.stack.imgur.com/SdeM9.png "private")

### Protected
Can only be accessed by code in the **same class or struct**, or in a **derived class**.
![alt text](https://i.stack.imgur.com/uniOu.png "protected")

### Private protected (added in C# 7.2)
Can only be accessed by code in the **same class or struct**, or in a **derived class from the same assembly**, but *not* from another assembly.  
`private` outside (the same assembly) `protected` inside (same assembly)  
![alt text](https://i.stack.imgur.com/ACp0t.png "private protected")

### Internal  
Can be accessed by any code in the **same assembly**, but *not* from another assembly.
![alt text](https://i.stack.imgur.com/8o7Dm.png "internal")

### Protected internal
Can be accessed by any code in the **same assembly**, or by any **derived class in another assembly**.  
`protected` outside (the same assembly) `internal` inside (same assembly)
![alt text](https://i.stack.imgur.com/VaQQ9.png "protected internal")

### Default types
- `internal` in class, struct
- `private` in class members, struct members

### Static
`static class`
- 클래스가 인스턴스화 될 수 없다.
- 클래스의 모든 멤버는 `static`
- one-and-only instance of itself  

<br />

> https://stackoverflow.com/questions/614818/in-c-what-is-the-difference-between-public-private-protected-and-having-no  
> https://stackoverflow.com/questions/3763612/default-visibility-for-c-sharp-classes-and-members-fields-methods-etc
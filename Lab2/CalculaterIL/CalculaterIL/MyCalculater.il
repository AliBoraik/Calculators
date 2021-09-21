.class public auto ansi beforefieldinit
  CalculaterIL.MyCalculater
    extends [System.Runtime]System.Object
{

  .method public hidebysig instance string
    Addition(
      string s1,
      string s2
    ) cil managed
  {
    .locals init (
      [0] valuetype [System.Runtime.Numerics]System.Numerics.BigInteger V_0,
      [1] string V_1
    )

     nop
     ldarg.1      // first number (s1)
    call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     ldarg.2      // second number (s2)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Add(valuetype [System.Runtime.Numerics]System.Numerics.BigInteger, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger)
     stloc.0     
     constrained. [System.Runtime.Numerics]System.Numerics.BigInteger
     callvirt     instance string [System.Runtime]System.Object::ToString()   
     ret

  }

  .method public hidebysig instance string
    Subtract(
      string s1,
      string s2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype [System.Runtime.Numerics]System.Numerics.BigInteger V_0,
      [1] string V_1
    )
    nop
     ldarg.1     // first number (s1)
    call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
    ldarg.2     // second number (s2)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Subtract(valuetype [System.Runtime.Numerics]System.Numerics.BigInteger, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger)
    stloc.0     
    constrained. [System.Runtime.Numerics]System.Numerics.BigInteger
     callvirt     instance string [System.Runtime]System.Object::ToString()     
    ret

  }

  .method assembly hidebysig static bool
    IsOperation(
      string operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3
    )
    nop
    ldstr        "+"
    call         void [System.Console]System.Console::WriteLine(string)
    nop
     ldarg.0      // operation
     ldstr        "+"
     call         bool [System.Runtime]System.String::op_Equality(string, string)
     ldarg.0      // operation
     ldstr        "-"
     call         bool [System.Runtime]System.String::op_Equality(string, string)
     ldarg.0      // operation
     ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
     ldarg.0      // operation
    ldstr        "/"
     call         bool [System.Runtime]System.String::op_Equality(string, string)
     nop
     nop
     ldstr        "operation is not correct!!"
     call         void [System.Console]System.Console::WriteLine(string)
    nop
     nop
     ret
  }

  .method public hidebysig instance string
    Multiply(
      string s1,
      string s2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype [System.Runtime.Numerics]System.Numerics.BigInteger V_0,
      [1] string V_1
    )
    nop
     ldarg.1     
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     ldarg.2     
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Multiply(valuetype [System.Runtime.Numerics]System.Numerics.BigInteger, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger)
     stloc.0    
     constrained. [System.Runtime.Numerics]System.Numerics.BigInteger
     callvirt     instance string [System.Runtime]System.Object::ToString()
     stloc.1      
     ldloc.1     
     ret
  } 

  .method public hidebysig instance string
    Divide(
      string s1,
      string s2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype [System.Runtime.Numerics]System.Numerics.BigInteger V_0,
      [1] string V_1
    )

    nop
    ldarg.1      
    call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     ldarg.2     
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Parse(string)
     call         valuetype [System.Runtime.Numerics]System.Numerics.BigInteger [System.Runtime.Numerics]System.Numerics.BigInteger::Divide(valuetype [System.Runtime.Numerics]System.Numerics.BigInteger, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger)
     stloc.0     
     ldloca.s     V_0
     constrained. [System.Runtime.Numerics]System.Numerics.BigInteger
    callvirt     instance string [System.Runtime]System.Object::ToString()
     stloc.1     
    ldloc.1     
     ret
  }

  .method public hidebysig instance bool
    IsNumbers(
      string n1,
      string n2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype [System.Runtime.Numerics]System.Numerics.BigInteger V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3
    )

    nop
    ldarg.1     
    call         bool [System.Runtime.Numerics]System.Numerics.BigInteger::TryParse(string, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger&)

     nop
     call         bool [System.Runtime.Numerics]System.Numerics.BigInteger::TryParse(string, valuetype [System.Runtime.Numerics]System.Numerics.BigInteger&)
     nop
     ldstr        "The second orgument is not number!!"
     call         void [System.Console]System.Console::WriteLine(string)
     nop
    ldstr        "The first orgument is not number!!"
    call         void [System.Console]System.Console::WriteLine(string)
    nop
     nop
     ret
  } 

  .method public hidebysig instance string
    Proces(
      string n1,
      string oper,
      string n2
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] string V_0,
      [1] string V_1,
      [2] string V_2,
      [3] string V_3,
      [4] string V_4
    )

    nop  
     ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)

     ldloc.2     
     ldstr        "-"
     call         bool [System.Runtime]System.String::op_Equality(string, string)

     ldloc.2      
     ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
     call         instance string Calculater.MyCalculater::Addition(string, string)   
     call         instance string Calculater.MyCalculater::Subtract(string, string)
     ldloc.1     
     call         instance string Calculater.MyCalculater::Multiply(string, string)
     stloc.s      
     ret
     }
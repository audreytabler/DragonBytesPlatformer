VAR charName = "Professor"
EXTERNAL startClass(hi)
VAR ClassNum = 1

{ClassNum ==1 } -> Class1
{ClassNum ==2 } -> Class2
{ClassNum ==3 } -> Class3

==Class1==
    Finally you're here. Ready for class?
    + [yes] -> yes
    + [no] -> no

    =yes
    Excellent. Have a seat please.
    ~ startClass("hi")
    --> END

    =no
    No? Well you'd better not be late...
    --> END
==Class2==
Hm you better not try any airplane shenanigans this class.
Are you ready to begin this class?
    + [yes] -> yes
    + [no] -> no

    =yes
    Good. Class will begin shortly.
    ~ startClass("hi")
    --> END

    =no
    No? Well you'd better not be late...
    --> END
    
    ==Class3==
Hm you'd better remember to put your phone away this class.. that was quite the disruption.
Are you ready to begin this class?
    + yes -> yes
    + no -> no

    =yes
    Please do your best to pay attention this time...
    ~ startClass("hi")
    --> END

    =no
    No? Well you'd better not be late...
    --> END
    

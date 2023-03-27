
VAR charName = "Taco"
EXTERNAL hasCoffee(status)

Hello there! I'm Tacomarious, or Taco for short. 

Would you like to order a drink? ->drinkYN

==drinkYN==
*yes ->yes
*no ->no


==yes
    Wonderful! Would you like something hot or iced? ->HotIced
    ==HotIced
    *hot ->hot
    *iced -> iced
    
    ==hot
    mmm a nice warm drink! Which of these hot drinks would you like?
    +latte -> serve("latte")
    +mocha -> serve("mocha")
    +brewed coffee -> serve("coffee")
    +tea -> serve("tea")
    
    =serve(drinkType)
    aaand here's your {drinkType}! Enjoy!
    ~ hasCoffee(true)
    -->END
    
    ==iced
    mmm a nice iced drink! Which of these cold drinks would you like?
    +latte -> serve("latte")
    +mocha -> serve("mocha")
    +brewed coffee -> serve("coffee")
    +tea -> serve("tea")
    
    =serve(drinkType)
    aaand here's your iced {drinkType}! Enjoy!
    ~ hasCoffee(true)
    --> DONE
    
    
==no
    Alrighty then! If you'd ever like a caffenated beverage you know where to find me!
    -->END
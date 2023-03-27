VAR charName = "Professor"
VAR HP = 50
VAR PHP = 60
VAR Question = 1
VAR correctQs = 0
EXTERNAL bossEnding(hi)

->BattleOptions
===BattleOptions===
Your Turn!
+Plea ->plea
        
+Provoke -> provoke
    
+Item -> item

==plea
   +[I'm So Sorry!]
        ~PHP = PHP - 4
        It's too Late to Apologize! ->PAttack
    +[Bro Just cut me some slack??]
        Cut you some slack?? You've slacked off in my class all year!!->PAttack
==provoke
    +[Ask for Extra Credit]
        ~PHP = PHP - 4
        I SAID NOT TO ASK FOR THAT AT THE END OF THE SEMESTER! AGHH! ->PAttack
    +[Was this in the syllabus?? I didn't read it.]
        ~PHP = PHP - 4
        I TOLD YOU TO READ THAT ON THE FIRST DAY! ->PAttack
    +[ChatGPT Teaches Better than you!!]
        ~PHP = PHP - 4
        NOT TRUUUUUUUUE! ->PAttack
        
    +[You know what they say, Those who can, do. Those who can't, teach.]
        ~PHP = PHP - 4
        I CAN DO IT BETTER THAN MOST!!! ->PAttack

==item
    +[Granola Bar]
        You opened up a granola bar
        . . . 
        It did nothing, but it sure tasted yummy! -> PAttack
    +[Look at Notes]
        You open your notebook, but it is blank. 
        That's right. You didn't take notes. ->PAttack
        
-->PAttack

===PAttack===
...
MY TURN!

{Question:
- 1: What is 3+3?
    ~Question = Question + 1
    *5
        ~HP = HP - 10
        Incorrect! ->BattleOptions
    *6
        Psh. Don't get too excited. That was an easy one. ->BattleOptions
    *7
        ~HP = HP - 10
        Incorrect!->BattleOptions
    *Math is a construct, it doesn't actually exist
        ~HP = HP - 10
        Wrong!->BattleOptions
-2: In Greek Mythology, who is the Queen of the Underworld and wife of Hades?
    ~Question = Question + 1
    *Athena
        ~HP = HP - 10
        Nope! ->BattleOptions
    *Hera
        ~HP = HP - 10
        Nope! ->BattleOptions
    *Persephone
        Psh. I bet you cheated didn't you. ->BattleOptions
    *Lilith
         ~HP = HP - 10
        Nope! -> BattleOptions
-3:What is the name of Han Solo’s ship?
    ~Question = Question + 1
*Decade Hawk
    ~HP = HP - 10
    Nope! -> BattleOptions
    
*Millennium Falcon
    Yeah, yeah. That was an easy one. -> BattleOptions
*Century Eagle
     ~HP = HP - 10
    Nope!-> BattleOptions
   
*Weekly Bird
    ~HP = HP - 10
    Nope! ->BattleOptions
    
-4: What temperature (in Fahrenheit) does water freeze at?
     ~Question = Question + 1
    *0 Degrees
         ~HP = HP - 10
         Nope, YOU DIDN'T STUDY, DID YOU?!!! -> BattleOptions
    *30 Degrees
        ~HP = HP - 10
        Nope, YOU DIDN'T STUDY, DID YOU?!!! -> BattleOptions
    *32 Degrees
        Haha, that one was SOOO easy. -> BattleOptions
    *10 Degrees
        ~HP = HP - 10
       Nope, YOU DIDN'T STUDY, DID YOU?!!! -> BattleOptions
    
-5:What are the 3 Primary Colors?
    ~Question = Question + 1
*Red, Yellow, Blue
    ~HP = HP - 10
    That one was easy-peasy!
    Those were some of my easiest questions!Time to get more EXTREME
    -> BattleOptions
*Red, Yellow, Green
    ~HP = HP - 10
    Nope, YOU DIDN'T STUDY, DID YOU?!!!
    Those were some of my easiest questions!Time to get more EXTREME
    -> BattleOptions
    
*Red, Orange, Blue
    ~HP = HP - 10
     Haha! WRONG!
     Those were some of my easiest questions!Time to get more EXTREME
     -> BattleOptions
*Red, Green, Orange
    ~HP = HP - 10
     Haha! WRONG!
     Those were some of my easiest questions!Time to get more EXTREME
     -> BattleOptions 
     
-6:Which U.S. President had the middle name Milhous?
    ~Question = Question + 1
    *Jimmy Carter
        ~HP = HP - 10
        Nope!->BattleOptions
    *Grover Cleveland
        ~HP = HP - 10
        Nope!->BattleOptions
    *Woodrow Wilson
        ~HP = HP - 10
        Nope!->BattleOptions
    *Richard Nixon
        Did you cheat on that question? ->BattleOptions
-7: People with Plutophobia are afraid of what?
    ~Question = Question + 1
    *Planets
        ~HP = HP - 10
         Nope! ->BattleOptions
    *Money
        Easy. Peasy.->BattleOptions
    *The Unknown
        ~HP = HP - 10
        Nope!->BattleOptions
    *Socks
        ~HP = HP - 10
        Nope!->BattleOptions
        
-8:Who was the first person to suggest Daylight Saving Times?
    ~Question = Question + 1
    *Thomas Jefferson
        ~HP = HP - 10
        Nope!->BattleOptions
    *John Adams
        ~HP = HP - 10
        Nope!->BattleOptions
    *Benjamin Franklin
        Guess I should make it harder, huh?->BattleOptions
    *Samuel Adams
        ~HP = HP - 10
        Nope!->BattleOptions
        
-9:If you order “murgh” from the menu at an Indian restaurant, what meat will you get?
    ~Question = Question + 1
    *Chicken
        UGH, How are you so good at this?! ->BattleOptions
    *Pork
        ~HP = HP - 10
        Nope!->BattleOptions
    *Fish
        ~HP = HP - 10
        Nope!->BattleOptions
    *Lamb
        ~HP = HP - 10
        Nope!->BattleOptions
-10:What famous actress once tried to hire a hitman to kill her?
    ~Question = Question + 1
    *Lindsay Lohan
        ~HP = HP - 10
        Nope!->BattleOptions
    *Angelina Jolie
        That was way too easy!->BattleOptions
    *Gwyneth Paltrow
        ~HP = HP - 10
        Nope!->BattleOptions
    *Jennifer Lopez
        ~HP = HP - 10
        Nope!->BattleOptions

-else: -> Ending
}

==Ending==
~charName = "Professor"
{correctQs:
-1:
-2:
-3:
-4:
-5: -> failed
-else: -> passed
}

==passed==
Okay OK!
Fine!
You... ugh... You passed the class.
. . .
. . .
. . .
Just kidding. That wasn't the real test. The only thing you passed at was being annoying. Come back in 20 minutes for the real final. Ciao!
~ bossEnding("hi")

-->END
==failed==
Yep just as I suspected, you were not paying attention and entirely failed that test.
You'll probably have to retake this class next semester ugh...
Just kidding. That wasn't the real test. The only thing you passed at was being annoying. Come back in 20 minutes for the real final. Ciao!

~ bossEnding("hi")
--> BattleOptions



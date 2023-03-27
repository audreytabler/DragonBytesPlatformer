VAR charName = "You"
VAR activityPoints = 1

(click text box to progress dialogue)
I can’t believe that tomorrow is finals day! This semester has really flown by.

~ charName = "Paisley"
Hey there! Are you ready to go to our Intro to Game Design class? I heard the professor is extra irritable today, so I don’t think it’d be a good idea to be late. 

~ charName = "You"
Sure thing! Let me just grab a coffee and I’ll head that way. See you in class!
(you have three classes today -- each time you interact with the professor it starts a new class)
--> END

==Study 
    It’d probably be a good idea to go over these notes before class. They could use some tidying up!
    . . .
    Okay I should probably head to class now!
    ~activityPoints = activityPoints -1
    --> END
==Game 
    Oh, Paisley is on Human Crossing! We could play together :)
    . . . 
    Okay I should probably head to class now!
    ~activityPoints = activityPoints -1
    --> END
    





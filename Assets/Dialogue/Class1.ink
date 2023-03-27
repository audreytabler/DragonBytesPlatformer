VAR charName = "Professor"
EXTERNAL endClass(yea)
EXTERNAL angryProfSprite(hi)
EXTERNAL casualProfSprite(hi)

~ casualProfSprite("hi")
Okay everyone. We are now starting our unit on Digital Illustration. . . Can anyone explain to me what exactly that is?
Yes? Mhmm, that is correct. . .
~ charName = "Narrator"
As he says that, a paper airplane with words written on it glides through the air, and lands directly in front of you. You look over, and see Paisley smiling at you. 
What would you like to do?
    * [Open it up and read it] -> read
    * [Throw it back to Paisley] -> throw
    * [Throw it in the trash] -> trash
    
==read
You open up the note and read it. 
“From Paisley: We are all grabbing coffee and snacks after class. You should come with! You in?”

~ charName = "Professor"
~ angryProfSprite("hi")
Passing notes in class are we? You’re paying to be here, I don’t know why you come to class if you’re not going to pay any attention. 
    --> EndClass

==throw
~ charName = "You"
“Ugh, I don’t care what you have to say, you’re going to get us in trouble. Take the airplane back.”
~ charName = "Professor"
~ angryProfSprite("hi")
“WHY are you tossing paper airplanes during my lecture? Are you trying to make me angry? Seriously, why AIRPLANES?? It’s 2023, you have cell phones! Agh!. . . Now please. Pay attention.”
    --> EndClass
==trash
~ charName = "You"
Ugh, I don’t care what you have to say, you’re going to get us in trouble. Take the airplane back.

~ charName = "Professor"
~ angryProfSprite("hi")
Paisley, why are we passing notes in my classroom? And a paper airplane note at that. I’d like to talk to you after class. Now go sit down 
    -->EndClass
    
==EndClass
~ casualProfSprite("hi")
~ charName = "Professor"
Now please remember to read pages 12-28 before class tomorrow. This is what your final test will be over. Use your time wisely!
    ~ endClass("hi")
    -->END








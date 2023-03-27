VAR charName = "Professor"
EXTERNAL endClass(hi)
EXTERNAL angryProfSprite(hi)
EXTERNAL casualProfSprite(hi)

Today we will be going over the final study guide,
    so please be sure to pay attention. . .

~charName = "You"
~ casualProfSprite("hi")

Buzzz...Buzzz....Buzz Buzz... Buzzzzzz
Oh no. Someone is blowing up my phone. 
What should I do?
    *Read It -> read
    *Keep Ignoring It -> ignore
    *Read It and Reply Back ->read_reply

==read
"From Paisley"
"Hey girl, I found this video and it totally reminds me of you. You have to watch this right now!"

~charName = "Narrator"
You pull out your earbuds and listen to the video. 
It's just a Spongebob Square pants parody.

~charName = "Professor"
~ angryProfSprite("hi")
Are you listening to music in my class?? Seriously, you're going to fail this test if you keep ignoring everything I say. It's meant to be hard, but I'm literally telling you some of the answers! Ugh, why do I even try?
-->EndClass


==ignore
~charName = "You"
No way. I am not getting in trouble for being on my phone today. Whatever it is, it can wait. 

. . . 
Buzzz
. . . 
Buzzz
. . .

Buzzzz Buzzz
. . . 

Buzz Buzz

. . . 

BUZZZZZZZZ

~charName = "Professor"
~ angryProfSprite("hi")
For the love of savory snacks, will you PLEASE just turn the phone OFF? The buzzing is ridiculously distracting. We're trying to study for a FINAL.

. . . Now. Pay. Attention. 

-->EndClass

==read_reply

~charName = "Narrator"
You pull your phone out and check the message.

"From Paisley"

"Hey girl! Here is a funny meme that I saw!"
"Isn't it funny?"
"Isn't it?"
"Isn't it?"
"Hello?"
"Are you mad at me?"
"Why are you ignoring me?"


~charName = "You"
"No, I'm not mad. I'm just in class -- like you are! We can meet after and talk if you wan-"

~charName = "Professor"
~ angryProfSprite("hi")
WHY are you more focused on your phone conversation than you are on this lecture? We are going over important final information. Also, if you read my syllabus 12 weeks ago like you were supposed to, you'd know I am VERY anti-cellphones in the classroom. PLEASE, put it away and pay attention. 
-->EndClass

==EndClass
~charName = "Professor"
~ casualProfSprite("hi")
Woof. . Woof woof woof.
Woof woof. Woof Woof.
Woof Woof, Bark.
. . .
Hope you guys paid attention. If I do not see you in class again today, good luck on your final tests!
~ endClass("hi")
-->END

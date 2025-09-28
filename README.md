https://youtu.be/73BaTm1TCKA

Style FLASHES
-
Hi my name is tsoh otherwise known as jeivc and this is my first mod...
Essentially what this mod does is display an image and play a sound when you get certain style bonuses. What style bonuses trigger what images and sounds are entirely customisable!

Note that this "flash" is independent from the usual parry flash, as to work with other mods like AnyParry.

Credits too to that mod for some code snippets, and to random reddit users for some of the images.

Now, here's a probably not nuanced guide on how to use this mod.

The "assets" folder contains all of the images and audio used. There's already some in there, and you can glean what they're used for from the names. These are displayed/played when their respective style bonus is triggered.

For example, when you get +RIDE THE LIGHTNING, the image and sound corresponding to "ultrakill.lightningbolt" are used.

How do you go about adding new images and audio, then?

Accepted File Types
-
First, you'll need the correct type of file; it won't work with the mod otherwise.

Images can be of type ".png", ".jpeg", ".jpg" or ".bmp".

Audio can be of type ".mp3", ".aif", ".ogg" or ".wav".

Styles
-
The clear course of action is to get an image and/or audio, and rename them to a specific style bonus. *However, that is not likely to work!*

In the game's code, most style bonuses are recognised *not by what you see on the screen, but as representative IDs*. You have already seen this with the +RIDE THE LIGHTNING bonus. That means that you cannot just name a file something like "RIDE THE LIGHTNING" (unless in some circumstances, which will be expanded upon later). So, you will need to name the files by the style's **ID**.

Here is the full list of all the IDs that are formally registered in the code, and what their style bonus is:

- ultrakill.kill >> KILL
- ultrakill.doublekill >> DOUBLE KILL
- ultrakill.triplekill >> TRIPLE KILL
- ultrakill.bigkill >> BIG KILL
- ultrakill.bigfistkill >> BIG FISTKILL
- ultrakill.headshot >> HEADSHOT
- ultrakill.bigheadshot >> BIG HEADSHOT
- ultrakill.headshotcombo >> HEADSHOT COMBO
- ultrakill.criticalpunch >> CRITICAL PUNCH
- ultrakill.ricoshot >> RICOSHOT
- ultrakill.limbhit >> LIMB HIT
- ultrakill.secret >> SECRET
- ultrakill.cannonballed >> CANNONBALLED
- ultrakill.cannonballedfrombounce >> DUNKED
- ultrakill.cannonboost >> CANNONBOOST
- ultrakill.insurrknockdown >> TIME OUT
- ultrakill.quickdraw >> QUICKDRAW
- ultrakill.interruption >> INTERRUPTION
- ultrakill.fistfullofdollar >> FISTFUL OF DOLLAR
- ultrakill.homerun >> HOMERUN
- ultrakill.arsenal >> ARSENAL
- ultrakill.catapulted >> CATAPULTED
- ultrakill.splattered >> SPLATTERED
- ultrakill.enraged >> ENRAGED
- ultrakill.instakill >> INSTAKILL
- ultrakill.fireworks >> FIREWORKS
- ultrakill.fireworksweak >> JUGGLE
- ultrakill.airslam >> AIR SLAM
- ultrakill.airshot >> AIRSHOT
- ultrakill.downtosize >> DOWN TO SIZE
- ultrakill.projectileboost >> PROJECTILE BOOST
- ultrakill.parry >> PARRY
- ultrakill.chargeback >> CHARGEBACK
- ultrakill.disrespect >> DISRESPECT
- ultrakill.groundslam >> GROUND SLAM
- ultrakill.overkill >> OVERKILL
- ultrakill.friendlyfire >> FRIENDLY FIRE
- ultrakill.exploded >> EXPLODED
- ultrakill.fried >> FRIED
- ultrakill.finishedoff >> FINISHED OFF
- ultrakill.halfoff >> HALF OFF
- ultrakill.mauriced >> MAURICED
- ultrakill.bipolar >> BIPOLAR
- ultrakill.attripator >> ATTRAPTOR
- ultrakill.nailbombed >> NAILBOMBED
- ultrakill.nailbombedalive >> NAILBOMBED
- ultrakill.multikill >> MULTIKILL
- ultrakill.compressed >> COMPRESSED
- ultrakill.strike >> STRIKE!
- ultrakill.rocketreturn >> ROCKET RETURN
- ultrakill.roundtrip >> ROUND TRIP
- ultrakill.serve >> SERVED
- ultrakill.landyours >> LANDYOURS
- ultrakill.iconoclasm >> ICONOCLASM
- ultrakill.drillpunch >> CORKSCREW BLOW
- ultrakill.drillpunchkill >> GIGA DRILL BREAK
- ultrakill.hammerhitheavy >> BLASTING AWAY
- ultrakill.hammerhitred >> FULL IMPACT
- ultrakill.hammerhityellow >> HEAVY HITTER
- ultrakill.hammerhitgreen >> BLUNT FORCE
- ultrakill.lightningbolt >> RIDE THE LIGHTNING

There are also some style bonuses that don't show up in the style HUD, but can be used with this mod.

- ultrakill.shotgunhit
- ultrakill.nailhit
- ultrakill.explosionhit
- ultrakill.firehit
- ultrakill.zapperhit
- ultrakill.drillhit
- ultrakill.hammerhit

I wouldn't recommend using ultrakill.nailhit, ultrakill.shotgunhit or any sort of thing that fires repeatedly in a short timeframe, as the hitstop slows the game down quite a bit.

If you do not see the bonus you're looking for, it's likely just the bonus verbatim. For example, +PANCAKED isn't "ultrakill.pancaked" in the code but rather just "PANCAKED". If these types of bonuses have colour, use these:

- Orange bonuses = \_OrangeTEXT\_e
- Green bonuses = \_GreenTEXT\_e
- Cyan bonuses = \_CyanTEXT\_e
- Red bonuses = \_RedTEXT\_e
- Grey bonuses = \_GreyTEXT\_e

(These are PROBABLY not case-sensitive but like just in case)

You may use these for styles like, +STOP HITTING YOURSELF, +CONDUCTOR, bonuses with dead variants, or mods that implement new style bonuses (things like Masquerade Divinity and Straymode).

Note that if you have mods that edit existing style names, you need to reflect that in your file names (of course, if these style bonuses do not have IDs).

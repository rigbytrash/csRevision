# csRevision
An A-Level Computer Science Revision Tool; based on the AQA specification


KNOWN BUGS:
<li>The typewriter animation effect will cause a crash when the form is refreshed too quickly mid-animation; this has to do with the wanted text being only half grabbed but the length is still registered as the old one, so an out of bounds error occurs.</li>
<li>When opening/ closing submenu, there is instant teleportation to the top; also exess space exists when collapsing</li>
<li>A little ammount of text is not scrolled down to, when text is being printed to the screen with the typeweriter effect (check LRPN)</li>


FIXED BUGS:

<li><i>The submenu animations get faster and faster each time they are trigered... After 15 submenu clicks (between them, not individaully) it almost looks as though there is no animation. I think this occurs  because the timer tick event is not getting destroyed, so for each subsequent time the submenu animation is triggered it has an extra event causing to change in size faster.</i>
</li>

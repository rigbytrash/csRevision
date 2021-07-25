# csRevision
An A-Level Computer Science Revision Tool; based on the AQA specification


KNOWN BUGS:




FIXED BUGS:

<li><i>The submenu animations get faster and faster each time they are trigered... After 15 submenu clicks (between them, not individaully) it almost looks as though there is no animation. I think this occurs  because the timer tick event is not getting destroyed, so for each subsequent time the submenu animation is triggered it has an extra event causing to change in size faster.</i>
</li>

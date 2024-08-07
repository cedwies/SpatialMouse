# PhysComp SS23 Assignment - Week 11

> **Deadline:** 09.07.2024, 23:59 CEST

## Weekly Progress Report
1.	**Progress Report:** What have you achieved this week with regards to your project? As usual, if your *concept* has changed, briefly describe this (and post pictures). Report on your progress in *developing your prototype*.

This week we started off by building all of our hardware components into the prototype which we developed last week. During assembly we encountered space issues, since it was quite difficult to fit everything into the body of the spatial mouse. However, after making some modification (cracking open the lower front of the grip), we were able to accomodate for the missing space. With this is was also possible to connect the Arduino to the computer without removing all the buttons. However, we will have to think about these issues for a possible future prototype.

After assembling the components into the 3D printed body and testing it out ourselves, we conducted user studies with 3 participants in order to get our first impressions on our spatial mouse.

Based on the results of our studies, we thought about how to improve our concept in order to improve the user experience of the spatial mouse. 

In addition to that, we keept working on the unity project, which now handels the input of the Spatial Mouse pretty good. But there are still some small bugs which need to be fixed.

This is a example video of the use of the prototype in action:

![Prototype](./Figures/SpatialMousePrototypeVid.mp4){width=500px}


2. **Evaluation Report**

    a) Report on your usability testing with a think **aloud study**.
    -	Whom did you evaluate with (3 users)? When, where, how did you recruit your users?

    All 3 evaluations were conducted consecutively on Wednesday (we started during the lecture slot) in the Mediaroom. This was necessary, since we need the computer located in the Mediaroom for our testing environment. We recruited one participant of the Physical Computing course and 2 fellow computer science students. We simply asked them if they are interested in participating in a study which will take up 20-30 minutes of their time.

    -	What functionality did you test, what did you fake (Wizard of Oz)?

    Fortunately, we were able to test our full functionality and were not forced to fake anything.
    We tested the mouse and VR component of our spatial mouse, as well the two input buttons and the tactile switch.

    -	What instructions did you give the users? What tasks did you ask them to do?

   First we asked some general questions about the users, to gather information about their experience, etc.
   We then asked them to grab the device and think aloud while they explore the spatial mouse. Afterwards, we asked them questions about the exploration in order to collect feedback.
   Lastly, we instructed them to complete the Unity task which we created over the past weeks. Here the participants also needed to share they thoughts while completing the task. Afterwards we again asked questions to our participants.

    -	What are your main observations and findings? Does your overall idea work? Did any unexpected issues occur?

    One of our main observations were that the tactile switch on the side of our spatial mouse was not fixated well enough, leading to dislocation when being used extensively. Additionally, the mouse sensitivity was too high, leading to all participants struggling with the mouse component functionality.
   Another main finding was that the function of the tactile switch (which is responsible for scrolling) was not immediately clear to the users. While all other inputs were obvious, the participants had various ideas about what the switch might do.

    b) Report on any **additional evaluation techniques** that you used:

    We complemented the think aloud study with a survey.

    -	What did you find out and how?

    With the help of the questionnaire, we encouraged the participants even more to think about what was good/bad about the usage of the spatial mouse. Some of our main findings stem from the survey which we conducted after the practical parts of our study.

    c) Finally, what **conclusions** do you draw from your evaluation? 

    From our evaluations we conclude that our overall concept is already quite good. Our conecept allows for an ergonomic hand grip. The layout was fairly intuitive (except for the tactile switch).

    On the other hand, even though the general shape goes into the right direction, the current shape is not yet perfect and needs further adjustments.
    
    - How can/should/will you change your *concept* (sketches/story boards)? 

    We will keep our general concept. However we will try to improve some functionalities:

    Firstly, we will try to improve the mouse functionality (mainly by lowering the mouse a constant scroll speed is possible with the tactile switch.sensitivity), as well as fixating the input buttons more thoroughly. We have problems with the mouse sensitivity since we first tried out the sensor. We already tried a lot of different things to improve the mouse function in the code, but it does not really get better. In the worst case we have to try another mouse sensor (if there would be other mouse sensors in the internet).
    Furthermore, we will try to reduce the issues regarding space for all hardware components in our spatial mouse. Lastly, our device does not yet work properly when using only a battery instead of a cable as power source. 

    - Which of these changes can you actually realize in your *prototype* (think both about ideal and feasible changes for the next 2 weeks)?

    Hopefuly we are able to realize all of the above changes.



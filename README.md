# ImmersiveLanguage

Virtual Reality project created by [Remi Alkemade](https://github.com/rremigius) and [Wouter van den Heuvel](https://github.com/spassvogel). This is a prototype Unity (5.4) project demonstrating the use of VR (via Google Cardboard) for use in a language-learning scenario. 


### Screenshots

![Alt text](/Misc/Screenshots/Screenshot_20161105-012114.png?raw=true "Screenshot 1")
![Alt text](/Misc/Screenshots/Screenshot_20161105-014629.png?raw=true "Screenshot 2")


### Project

The presents a multi-user virtual environment where language students (at the moment just two players are supported), represented as virtual avatars, can communicate in a foreign language whilst a teacher observes, gives instructions and feedback.

The idea is to portray a realistic scenario, preferably applicable to the language being studied. Typical scenarios will be commercial situations (a shop, a market, a train station, an airport) or social ones (a bar, a beach). In the current prototype one 'shop' scenario is developed.

Players are wearing (Google cardboard) headsets and can use the built-in microphone of their smartphone. A pair of headphones is recommended. They can look around in the room but not move. The when they are looking around the head movement and rotation is actually visible to the other player. Also, when a player talks, the other player will see the lips of his avatar move.

The benefit to using VR is that you can start to have conversations about (virtual) physical things in the room, e.g. one player (a buyer) might be given the instruction to buy a perticular object in the environment (the shop). Or two friends at a tourist attraction might have a conversation about their environment. We believe head tracking a very important aspect in this. Of course role-playing scenarios are commonplace in language learning, but adding extra fidelity (visual and sound) will add to realism, as well as fun. Add to the fact that a VR solution will increase efficiency as the three people won’t have to be in the same room


### Features

- [x] Able to run stand-alone (on Windows) or on Android 
- [x] Stereoscopic image output and Google cardboard eye gaze input
- [x] Networked code, transmitting audio (voice over IP) 
- [x] Rich, immersive environment


### Future work

Future work entails a teacher mode with more features. The teacher can observe all (will probably not be required to wear a VR headset) and provide each actor with a minimal background story and assignments to keep the conversation going and adjust if necessary. There has to be a way for private communication between a teacher and one specific student as well as communication between all. Medium of communication of teacher can be written text (perhaps through some sort of preset snippets for more effiency) but also voice messages. A useful feature would be for the teacher to somehow highlight an object in the room as to direct the attention of a student to it. A future addition (not necessary now) could be the possibility to maintain various ‘rooms’ in parallel) such that the teacher can divide her class into groups and have all of them have conversations at the same time.



### Recording

![Alt text](/Misc/Movies/demo.gif?raw=true "Demo")




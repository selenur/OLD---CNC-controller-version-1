# CNC-controller-for-mk1
C# program for managing controller mk1 from the company planet-cnc

Программа для управления контроллером mk1 (данный контроллер разработан компанией planet-cnc) но активно клонируется в китае.
Программа написана на C#, и пока единственный поддерживаемый язык, - русский.

![CNC_Controller Screenshot](https://github.com/selenur/CNC-controller-for-mk1/blob/master/cnc.PNG?raw=true)

Поддерживает: G0,G1,G4, M0, M3, M5, M6

Требования к некоторым кодам:
Код G4 должен иметь параметр "P" (пауза в мсек.) пример -> G04 P500;
Код M6 должен иметь параметр "T" (№ инструмента), и "D" (диаметр инструмента) пример -> M6 T1 D0,9
 
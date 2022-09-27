# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #1 выполнил(а):
- Паханов Александр Александрович
- РИ-300018
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### В разделе «ход работы» пошагово выполнить каждый пункт с описанием и примера реализации задач по теме видео «Практическая работа 1-4».
### Ход работы:
- Создать новый проект из шаблона 3D – Core;
- Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);
- Создать объект Plane;
- Создать объект Cube;
- Создать объект Sphere;
- Установить компонент Sphere Collider для объекта Sphere;
- Настроить Sphere Collider в роли триггера;
- Объект куб перекрасить в красный цвет;
- Добавить кубу симуляцию физики, при это куб не должен проваливаться под Plane;
- Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;
- При столкновении Cube должен менять свой цвет на зелёный, а при завершении столкновения обратно на красный.

Созданные объекты:

![](/Pics/Объекты.jpg)

Компоненты объекта Plane:

![](/Pics/Plane.jpg)

Компоненты объекта Cube:

![](/Pics/Cube.jpg)

Компоненты объекта Sphere:

![](/Pics/Sphere.jpg)

Скрипт для объекта Sphere:
```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IintersectionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sphere столкнулся с объектом " + other.gameObject.name);
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
```
Для проверки физики и срипта расположим куб над сферой и плоскостью:

![](/Pics/Сцена1.jpg)

Пересечение объектов:

![](/Pics/Сцена2.jpg)

Куб лежит на плоскости и при этом не проваливается:

![](/Pics/Сцена3.jpg)


## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
- Что произойдёт с координатами объекта, если он перестанет быть дочерним?
- Создайте три различных примера работы компонента RigidBody?
### Ход Работы:
- Что произойдёт с координатами объекта, если он перестанет быть дочерним?
Создадим у объекта Sphere дочерний объект Cylinder:

![](/Pics/Cylinder1.jpg)
![](/Pics/Cylinder2.jpg)

Видим, что у объекта Cylinder координаты 0 0 3.
Теперь сделаем его самостоятельным:

![](/Pics/Cylinder3.jpg)
![](/Pics/Cylinder4.jpg)

При этом координаты изменились на 0 1,94 3.
Смена координат произошла из-за того, что в начале объект Cylinder был дочерним объектом и имел локальные координаты относительно родителя, а потом, когда стал самостоятельным объектом, его координаты стали мировыми.

- Создайте три различных примера работы компонента RigidBody?
Создадим 3 куба, добавим им компонент RigitBody и измениим им настройки:
- у синего куба уберем Use Gravity (по умолчанию включено);
- зеленому кубу добавим Is Kinematic (по умолчанию выключено);
- у желтого куба оставим настройки по умолчанию.

Первоначальное состояние кубов:

![](/Pics/cubes1.jpg)

При запуске сцены:

![](/Pics/cubes2.jpg)

Желтый куб начал падать вниз, т. к. у него работает настройка Use Gravity.
Зеленый и синий кубы остались на месте, т. к. у первого отключена физика (Is Kinematic), а второй не будет двигаться до тех пор, пока на него не будет взаимодействовать какая-то сила, потому что мы отключили для него силу гравитации.

Пробуем столкнуть синий и зеленый кубы, из-за чего первый начал движение, а второй остался на месте:

![](/Pics/cubes3.jpg)



## Задание 3
### Какова роль параметра Lr? Ответьте на вопрос, приведите пример выполнения кода, который подтверждает ваш ответ. В качестве эксперимента можете изменить значение параметра.

- Перечисленные в этом туториале действия могут быть выполнены запуском на исполнение скрипт-файла, доступного [в репозитории](https://github.com/Den1sovDm1triy/hfss-scripting/blob/main/ScreatingSphereInAEDT.py).
- Для запуска скрипт-файла откройте Ansys Electronics Desktop. Перейдите во вкладку [Automation] - [Run Script] - [Выберите файл с именем ScreatingSphereInAEDT.py из репозитория].

```py

import ScriptEnv
ScriptEnv.Initialize("Ansoft.ElectronicsDesktop")
oDesktop.RestoreWindow()
oProject = oDesktop.NewProject()
oProject.Rename("C:/Users/denisov.dv/Documents/Ansoft/SphereDIffraction.aedt", True)
oProject.InsertDesign("HFSS", "HFSSDesign1", "HFSS Terminal Network", "")
oDesign = oProject.SetActiveDesign("HFSSDesign1")
oEditor = oDesign.SetActiveEditor("3D Modeler")
oEditor.CreateSphere(
	[
		"NAME:SphereParameters",
		"XCenter:="		, "0mm",
		"YCenter:="		, "0mm",
		"ZCenter:="		, "0mm",
		"Radius:="		, "1.0770329614269mm"
	], 
)

```

## Выводы

Абзац умных слов о том, что было сделано и что было узнано.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**

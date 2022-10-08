## Задание

Игра "Сейф братьев пилотов".

На сейфе множество поворачиваемых рукояток, которые могут быть расположены горизонтально или вертикально. 
Рукоятки расположены квадратом, как 2-мерный массив NxN. 
Есть одно правило - при повороте рукоятки (кликом мышки меняется положение рукоятки с вертикального в горизонтальный и обратно), поворачиваются все рукоятки в одной строке и в одном столбце. 
Сейф открывается, только если удается расположить все ручки параллельно друг другу (т.е. все вертикально или все горизонтально). 
Изначально поле должно быть запутано, но так, чтобы было решение. 
Число N должно быть настраиваемое.

Пользовательский интерфейс значения не имеет, единственное условие всё должно запускаться и работать =)
Работа должна быть выполнена на C#.
Желательно оформить в качестве проекта Visual Studio.
____________________________
## Задачи
Поскольку нет тасктрекера, именование веток будет хаотичным, в зависимости от задачи 

- Обязательные:  
✅ Добавить генерацию рукояток (master)  
✅ Добавить отображение рукояток на UI (master)  
✅ Добавить смену положения одной рукоятки (master)  
✅ Добавить смену положения остальных рукояток, расположенных в том же ряду и столбце (changeRowAndColumn)  
✅ Вынести логику в отдельную библиотеку (moveToLibraries)  
✅ Добавить открытие сейфа (openSafe)  
✅ Добавить проверку на наличие решения при генерации рукояток (deckHasSolution)  
✅ Добавить возможность изменения N пользователем (addMatrixSizeSelection)  

- Опциональные:  
✅ Добавить список задач в файл README.md  
✅ Добавить кнопку Restart  
✅ Добавить счетчик ходов (addPlayCounter)  
⬜ Добавить сохранение текущей игры  
✅ Спрашивать пользователя "Продолжить игру/Начать новую игру" (openSafe)  
⬜ Добавить таймер  
⬜ Добавить таблицу результатов (первые 10)  
⬜ Добавить unit-тесты  
⬜ Использовать MVVM

# Цели работы:
1.	Изучение особенностей работы многопоточных приложений
2.	Изучение механизмов сетевого взаимодействия
# Задача: реализовать два приложения (клиент и сервер), которые обмениваются сообщениями согласно вашему варианту и ряду требований.
# Общие требования:
1.	Приложения обмениваются сообщениями по протоколу TCP
2.	Адрес и Порт должны быть конфигурируемыми
3.	Приложения должны вести журнал своих действий с указанием даты/времени и номера потока, в котором это действие было выполнено. 
# Возможные действия для записи: 
a.	отправленные/полученные сообщения
i.	для сервера с указанием идентификатора клиента
ii.	для клиента с интерпретацией результатов ответа от сервера
b.	отметки о начале/завершении приложения, основных потоков
c.	сообщения пользователю приложения
4.	Необходимо предусмотреть возможность корректного завершения работы приложения по запросу пользователя.
# Требования по вариантам:
1.	В ходе выполнения работы происходи взаимодействие одного сервера и N (3) клиентов
2.	Клиент: 
2.1.	Отправляет запросы с параметром, указанным в варианте работы (5) 
2.2.	с интервалом точно равным или равным случайному значению из интервала T2 (2)
3.	Сервер:
3.1.	Обрабатывает запрос приблизительно в течении времени T1 (1), выполняя действие, указанное в варианте работы (6), задачи разных клиентов выполняются независимо и параллельно
3.2.	Отслеживает выполнение уже запущенных задач, а также других задач одного клиента:
3.2.1.	При получении значения, которое уже находится в обработке, не зависимо от того, какой клиент отправил это значение, 
выполняется «Присоединение» – новая задача ожидает завершения начатой задачи и возвращает ее результат,
3.2.2.	Иначе, при поступлении значения от того же клиента, применяется одна из следующих политик по вариантам (4):
3.2.2.1.	Ожидание – ожидает завершения начатых задачи, после начинает работу;
3.2.2.2.	Прерывание – возвращает состояние «ошибки» обработки запроса (сервер занят)
3.2.2.3.	Перезапуск –отменяет исполнение начатой задачи, после начинает работу;
# Результат работы
1.	Исходный код в личном репозитории
2.	Отчет содержащий
a.	титульный лист и заключение
b.	скриншоты результатов работы всех приложений (журнал действий), по одному на каждое приложение
c.	журнал действий для каждого приложения от запуска до завершения работы

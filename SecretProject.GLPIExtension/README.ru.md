## Идеи
### Сценарий может формироваться как в JSON, так и в XML, но обрабатываться будет только сжатый json-сценарий!

## Objects
Scenario - Сценарий - root object
    Аттрибуты:
        type - тип - <incident | request>
        category - категория

Object - Объект - общая сущность, которая декларирует данные
Типы объектов:
    Простые:
        Общие атрибуты:
            type - тип: <собственный>
            order - порядок - <номер начиная с нуля>
            title - подпись - <строка>

        Text - Текст
            Аттрибуты:
                макс: <число - максимальное кол-во букв | null>
                мин: <число - минимальное кол-во букв | null>
            Потомки:
                <строка>

        Select - Выбор
            Аттрибуты:
                тип: default \ radio \ checkbox

        DateTime - ДатаВремя
            Аттрибуты:
                тип: default(и дата и время) \ time (время) \ date (дата)
    Работа с клиентом:
        Request - Запрос - объект, который декларирует сущность запроса к пользователю
            
        Answer - Ответ - объек, который декларирует сущность ответа к пользователю

        Notification - Оповещение - сущность, которая декларирует обратную связь для пользователя
            Аттрибуты:
                timeout - ожидание - определяет в *секундах*, сколько необходимо ждать перед тем как отправить пользователю информацию о статусе заявки.
            Потомки:
                Mechanism - Механизм
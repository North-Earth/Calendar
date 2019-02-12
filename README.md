# Сalendar
Прототип календаря отпусков.

# Данные для тестирования

Данные команды можно использовать в PowerShell или консоли VS.

### Тестирование StaffController

Контроллер обеспечивает возможность взаимодействия с источником персонала(пользователей).

Метод GET, возвращает все данные из таблицы Staff.

```sh
Invoke-RestMethod http://localhost:5000/api/staff -Method GET
```

Метод GET, возвращает данные в соответсвии с переданным ID.

```sh
Invoke-RestMethod http://localhost:5000/api/staff/5 -Method GET
```

Метод PUT, записывает полученные данные в таблицу в БД.

```sh
Invoke-RestMethod http://localhost:5000/api/staff -Method PUT -Body (@{name = "Alex"; colorId = "27"} | ConvertTo-Json) -ContentType "application/json"
```
Метод DELETE, удаляет данные по переданному ID.

```sh
Invoke-RestMethod http://localhost:5000/api/staff/5 -Method DELETE
```

### Тестирование VacationController

Контроллер обеспечивает возможность взаимодействия с источником отпусков.

Метод GET, возвращает все данные из таблицы Vacation.

```sh
Invoke-RestMethod http://localhost:5000/api/vacation -Method GET
```

Метод GET, возвращает все записи об отпусках конкретного пользователя.

```sh
Invoke-RestMethod http://localhost:5000/api/vacation/5 -Method GET
```

Метод PUT, записывает полученные данные в таблицу в БД.

```sh
Invoke-RestMethod http://localhost:5000/api/vacation -Method PUT -Body (@{userId = "1"; startDate = "2019-02-13"; endDate = "2019-02-20"; countDays = "19"} | ConvertTo-Json) -ContentType "application/json"
```
Метод DELETE, удаляет данные по переданному ID.

```sh
Invoke-RestMethod http://localhost:5000/api/vacation/5 -Method DELETE
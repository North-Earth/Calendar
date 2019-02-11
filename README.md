# Сalendar
Прототип календаря отпусков.

# Данные для тестирования

Данные команды можно использовать в PowerShell или консоли VS.

### Тестирование StaffController

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
Invoke-RestMethod http://localhost:5000/api/users -Method PUT -Body (@{name = "Alex"; colorId = "27"} | ConvertTo-Json) -ContentType "application/json"
```
# MeetupAPI

## Запуск проекта
1. Склонируйте репозиторий.
2. Запустите свою среду разработки и откройте склонированный проект.
3. Если потребуется, то установите необходимые NuGet пакеты, которые запрашивает среда разработки.
4. В файле appsettings.json задайте Ваш localhost для поля jwt, а также можете изменить название для БД.
5. Выполните запуск без отладки, Вам откроется страница в браузере (Swagger UI).
6. Для того, чтобы выполнять вызов различных методов для событий, необходимо пройти регистрацию и авторизацию.
При вызове метода Login Вам в ответ вернется json web token, после чего нужно нажать на кнопку Authorize и вставить свой токен для авторизации.
7. После всего Вы можете вызывать различные методы для событий.

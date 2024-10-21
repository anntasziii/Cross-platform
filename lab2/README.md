# Лабораторна робота №2

### Для побудови проекту слід використовувати команду:
```
dotnet msbuild build.proj /p:Solution=lab2 /t:Build
```
### Для запуску слід використовувати команду:
```
dotnet msbuild build.proj /p:Solution=lab2 /t:Run
```
### Для тестування застосунку слід використовувати команду:
```
dotnet msbuild build.proj /p:Solution=lab2 /t:Test
```
## Варіант 32

Розглянемо нескінченну праворуч і вгору шахівницю, на якій стоїть ферзь. Двоє по черзі рухають цього ферзя. Дозволяється рухати ферзя тільки вниз, вліво або діагоналі вниз вліво на будь-яку позитивну кількість клітин у вибраному напрямку. Мета гри – засунути ферзя у кут, тобто клітину з координатами (1, 1). На малюнку показані дозволені рухи ферзя. Потрібно написати програму, яка знайде номер гравця, який виграє за правильної гри.

## Вхідні дані

Вхідний файл INPUT.TXT містить координати ферзя перед першим ходом - два числа M і N, записані через пропуск (1 ≤ M, N ≤ 250). Гарантується, що ферзь спочатку не знаходиться у клітині з координатами (1,1).

## Вихідні дані

Вихідний файл OUTPUT.TXT повинен мати знайдений номер переможця.

## Приклади

| №  | INPUT.TXT   | OUTPUT.TXT  |
|----|-------------|------------ |
| 1  | 3 2         | 2           |
| 2  | 6 7         | 1           |
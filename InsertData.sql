INSERT INTO public.user(user_id, first_name, last_name)
OVERRIDING SYSTEM VALUE
VALUES(1,'Иван','Иванов'),(2,'Петр','Петров'),
(3,'Андрей','Андреев'),(4,'Семен','Семенов'), (5,'Никита','Никитин');

INSERT INTO public.category(category_id, name)
OVERRIDING SYSTEM VALUE
VALUES(1, 'Транспорт'), (2, 'Недвижимость'), (3, 'Работа'), (4, 'Услуги'), (5, 'Личные вещи');

INSERT INTO public.announcement(author, category, description)
VALUES(1, 1, 'Супер авто, Недорого'),
(2, 2, 'Мега квартира и дешево'),
(3, 3, 'Работа каменщика'),
(4, 4, 'Муж на час, недорого'),
(4, 5, 'Платья на девочку 7-8 лет')

